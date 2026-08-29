Public Class FrmBolAnexo
    Dim x As Integer = 0
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Detalles()
        End If

    End Sub

    Private Sub FrmBolAnexo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Cancelar_Detalles()
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String, ByVal c_codi_doc As String)
        With Dgv01
            If c_codi_doc = "01" Then .DataSource = c_Neg_FactAnexo.get_FactAnexo_Datos(Cadena, "DGV")
            If c_codi_doc = "02" Then .DataSource = c_Neg_BolAnexo.get_BolAnexo_Datos(Cadena, "DGV")

            .Columns("Fecha").Width = 80
            .Columns("Cliente").Width = 220
            .Columns("Documento").Width = 120
            .Columns("Total").Width = 60
            .Columns("Anexo").Width = 120
            .Columns("Acta.").Width = 60
            .Columns("Item").Visible = False
            .Columns("c_anula_reg").Visible = False
            ' alignment '
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Anexo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Acta.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Call Calcular_Totales()
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot1 As Decimal
            Call Limpiar_Texto(Pan01)
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("c_anula_reg").Value) = 0 Then
                        Tot1 = Tot1 + Val(.Rows(i).Cells("Acta.").Value)
                    End If
                Next
                TxtTotal.Text = Format(Val(.Rows(0).Cells("Total").Value), Forma_1_2)
                TxtActa.Text = Format(Tot1, Forma_1_2)
                TxtSaldo.Text = Format(Val(TxtTotal.Text) - Val(TxtActa.Text), Forma_1_2)
            End If
        End With
    End Sub
    Private Function ValidarDatos2() As Boolean
        If Len(TxtNroDocAnexo.Text) = 7 Then
            If Len(TxtSerieDocAnexo.Text) = 4 Then
                ValidarDatos2 = True
            Else
                ValidarDatos2 = False
                MsgBox("1. La serie del documento debe tener 4 caracteres...", vbCritical, Compañia)
            End If
        Else
            MsgBox("2. El número de documento debe tener 7 caracteres...", vbCritical, Compañia)
            ValidarDatos2 = False
        End If
    End Function
    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        If ValidarDatos2() = True Then
            Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                ' Boletas '
                If Val(TxtVar.Text) = 1 Then
                    Call Grabar_Registro_Bol("ADD") : Call BtnCerrar_Click(Nothing, Nothing)
                    Cargar_Grid(" and (C.c_nro_serie + C.c_nro_boleta ='" & FrmBoletas.CboSerie.Text & FrmBoletas.TxtBoleta.Text &
                                    "' or A.c_serie_anexo + A.c_boleta_anexo='" & FrmBoletas.CboSerie.Text & FrmBoletas.TxtBoleta.Text & "') order by C.c_fecha_emi ", "02")
                End If
                ' Facturas '
                If Val(TxtVar.Text) = 2 Then
                    Call Grabar_Registro_Fact("ADD") : Call BtnCerrar_Click(Nothing, Nothing)
                    Cargar_Grid(" and (C.c_nro_serie + C.c_nro_factura='" & FrmFacturas.CboSerie.Text & FrmFacturas.TxtFactura.Text &
                                    "' or A.c_serie_anexo + A.c_factura_anexo='" & FrmFacturas.CboSerie.Text & FrmFacturas.TxtFactura.Text & "') order by C.c_fecha_emi ", "01")
                End If
            End If
        End If
    End Sub
    ' method to records
    Private Sub Grabar_Registro_Bol(ByVal vOpt As String)
        With c_Ent_BolAnexo
            .c_nro_correl = Val(TxtItem.Text)
            .c_nro_serie = TxtSerieDoc.Text
            .c_nro_boleta = TxtNroDoc.Text
            .c_total_boleta = Val(TxtTotalDoc.Text)
            .c_serie_anexo = TxtSerieDocAnexo.Text 'boleta original hecha por anticipo
            .c_boleta_anexo = TxtNroDocAnexo.Text 'boleta original hecha por anticipo
            .c_monto_anexo = Val(TxtDocActa.Text) 'monto a cuenta
            .c_obs = ""
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = vOpt
            c_Neg_BolAnexo.set_BolAnexo_Save(c_Ent_BolAnexo)
        End With
    End Sub
    ' method to records
    Private Sub Grabar_Registro_Fact(ByVal vOpt As String)
        With c_Ent_FactAnexo
            .c_nro_correl = Val(TxtItem.Text)
            .c_nro_serie = TxtSerieDoc.Text
            .c_nro_factura = TxtNroDoc.Text
            .c_total_factura = Val(TxtTotalDoc.Text)
            .c_serie_anexo = TxtSerieDocAnexo.Text 'factura original hecha por anticipo
            .c_factura_anexo = TxtNroDocAnexo.Text 'factura original hecha por anticipo
            .c_monto_anexo = Val(TxtDocActa.Text)
            .c_obs = ""
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = vOpt
            c_Neg_FactAnexo.set_FactAnexo_Save(c_Ent_FactAnexo)
        End With
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Detalles() : TxtSerieDocAnexo.Focus()
        ' boletas
        If Val(TxtVar.Text) = 1 Then
            TxtFecha.Text = FrmBoletas.DtpFec_Emi.Text
            TxtClie.Text = FrmBoletas.CboClie.Text
            TxtTotalDoc.Text = Format(Val(FrmBoletas.LblSub_Total.Text), Forma_1_2)
            TxtDocActa.Text = Format(Val(FrmBoletas.LblSub_Total.Text), Forma_1_2)
            TxtSerieDoc.Text = FrmBoletas.CboSerie.Text
            TxtNroDoc.Text = FrmBoletas.TxtBoleta.Text
        End If
        ' facturas
        If Val(TxtVar.Text) = 2 Then
            Dim totalFactura As Decimal = Format(Val(Replace(FrmFacturas.LblImporte_3.Text, ",", "")) + (Val(Replace(FrmFacturas.LblImporte_3.Text, ",", "")) * (Val(FrmFacturas.TxtCant_IGV.Text) / 100)), Forma_1_2)
            TxtFecha.Text = FrmFacturas.DtpFec_Emi.Text
            TxtClie.Text = FrmFacturas.CboClie.Text
            TxtTotalDoc.Text = Format(totalFactura, Forma_1_2)
            TxtDocActa.Text = Format(totalFactura, Forma_1_2)
            TxtSerieDoc.Text = FrmFacturas.CboSerie.Text
            TxtNroDoc.Text = FrmFacturas.TxtFactura.Text
        End If

    End Sub
    Private Sub Nuevo_Detalles()
        With Dgv01
            .Size = New Size(680, 126)
            .Location = New Point(9, 25)
            Call Limpiar_Texto(Pan01)
            x = 0 : TxtSerieDocAnexo.Enabled = True : TxtNroDocAnexo.Enabled = True : TxtDocActa.Enabled = True
            Dgv01.Enabled = False
            BtnCerrar.Text = "&Cancelar"
            Pan02.Enabled = False
            BtnGrabar.Enabled = True
        End With
    End Sub
    Private Sub Cancelar_Detalles()
        With Dgv01
            .Size = New Size(680, 148)
            .Location = New Point(9, 3)
            Call Limpiar_Texto(Pan01)
            x = 0 : Call Desactivar(Pan01)
            Dgv01.Enabled = True : Pan02.Enabled = True
            BtnGrabar.Enabled = False
            BtnCerrar.Text = "&Cerrar"
        End With
    End Sub
    Private Sub TxtSerieDoc_TextChanged(sender As Object, e As EventArgs) Handles TxtSerieDoc.TextChanged

    End Sub

    Private Sub TxtSerieDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSerieDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtSerieDoc.Text) = True Then
                TxtSerieDoc.Text = Strings.Right(Val(TxtSerieDoc.Text) + 1000, 3)
            Else

            End If
        End If
    End Sub

    Private Sub TxtNroDoc_TextChanged(sender As Object, e As EventArgs) Handles TxtNroDoc.TextChanged

    End Sub

    Private Sub TxtNroDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNroDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtNroDoc.Text) > 0 Then
                TxtNroDoc.Text = Strings.Right(Val(TxtNroDoc.Text) + 10000000, 7)
                Dim c_codi_doc As String = ""
                If Val(TxtVar.Text) = 1 Then c_codi_doc = "02"
                If Val(TxtVar.Text) = 2 Then c_codi_doc = "01"
                Call ValidarDocAdelantos(txtCodClie.Text, TxtSerieDoc.Text, TxtNroDoc.Text, c_codi_doc, TxtTotalDoc)
            Else

            End If
        End If
    End Sub

    Private Sub FrmBolAnexo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmBolAnexo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If BtnGrabar.Enabled = True Then
                Call BtnCerrar_Click(Nothing, Nothing)
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TxtNroDocAnexo_TextChanged(sender As Object, e As EventArgs) Handles TxtNroDocAnexo.TextChanged

    End Sub

    Private Sub TxtNroDocAnexo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNroDocAnexo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtNroDocAnexo.Text) > 0 Then
                TxtNroDocAnexo.Text = Strings.Right(Val(TxtNroDocAnexo.Text) + 10000000, 7)
                Dim c_codi_doc As String = ""
                If Val(TxtVar.Text) = 1 Then c_codi_doc = "02"
                If Val(TxtVar.Text) = 2 Then c_codi_doc = "01"
                Call ValidarDocAdelantos(txtCodClie.Text, TxtSerieDocAnexo.Text, TxtNroDocAnexo.Text, c_codi_doc, TxtDocActa)
                ' Facturas '
                If Val(TxtVar.Text) = 2 Then
                    '  InputBox("", "", " and C.c_anula_reg=0 and C.c_nro_Serie='" & TxtSerieDocAnexo.Text & "' and C.c_nro_factura='" & TxtNroDocAnexo.Text & "' ")
                    With c_Neg_FactCab.get_FactCab_Datos(" and C.c_anula_reg=0 and C.c_nro_Serie='" & TxtSerieDocAnexo.Text & "' and C.c_nro_factura='" & TxtNroDocAnexo.Text & "' ", "AN2", "")
                        If .Rows.Count > 0 Then
                            TxtDocActa.Text = Format(Val(.Rows(0)("Saldo").ToString), Forma_1_2)
                        Else
                            TxtDocActa.Text = "0.00"
                        End If
                    End With
                End If
                ' Boletas '
                If Val(TxtVar.Text) = 1 Then
                    With c_Neg_BolCab.get_BolCab_Datos(" and C.c_anula_reg=0 and C.c_nro_Serie='" & TxtSerieDocAnexo.Text & "' and C.c_nro_boleta='" & TxtNroDocAnexo.Text & "' ", "AN2", "")
                        If .Rows.Count > 0 Then
                            TxtDocActa.Text = Format(Val(.Rows(0)("Saldo").ToString), Forma_1_2)
                        Else
                            TxtDocActa.Text = "0.00"
                        End If
                    End With
                End If
            Else

            End If
        End If
    End Sub
    Private Function validarDatos() As Boolean
        If Val(TxtDocActa.Text) > 0 Then
            If Len(TxtSerieDoc.Text) > 0 Then
                If Len(TxtNroDoc.Text) > 0 Then
                    If Val(TxtTotalDoc.Text) > 0 Then
                        validarDatos = True
                    Else
                        validarDatos = False
                        MsgBox("1. Falta el monto del documento...", vbCritical, Compañia)
                    End If
                Else
                    validarDatos = False
                    MsgBox("2. Falta ingresar el número de documento...", vbCritical, Compañia)
                End If
            Else

            End If
        Else

        End If
    End Function

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(sender As Object, e As EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim F As Integer = .CurrentCellAddress.Y
                If F = -1 Then F = 0
                If F > -1 Then
                    If Val(.Rows(F).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Detalles() : Call Desactivar(Pan01) : TxtDocActa.Enabled = True : TxtDocActa.Focus()
                        TxtItem.Text = .Rows(F).Cells("Item").Value
                        TxtFecha.Text = .Rows(F).Cells("Fecha").Value
                        TxtClie.Text = .Rows(F).Cells("Cliente").Value
                        TxtSerieDoc.Text = Strings.Left(.Rows(F).Cells("Documento").Value, 4)
                        TxtNroDoc.Text = Strings.Right(.Rows(F).Cells("Documento").Value, 7)
                        TxtTotalDoc.Text = Format(Val(.Rows(F).Cells("Total").Value), Forma_1_2)
                        TxtSerieDocAnexo.Text = Strings.Left(.Rows(F).Cells("Anexo").Value, 4)
                        TxtNroDocAnexo.Text = Strings.Right(.Rows(F).Cells("Anexo").Value, 7)
                        TxtDocActa.Text = Format(Val(.Rows(F).Cells("Acta.").Value), Forma_1_2)
                    Else
                        MsgBox("Registro no puede ser editado, esta anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TxtDocActa_TextChanged(sender As Object, e As EventArgs) Handles TxtDocActa.TextChanged

    End Sub

    Private Sub TxtDocActa_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDocActa.KeyDown
        If e.KeyCode = Keys.Enter Then
            If validarDatos() = True Then
                Call BtnGrabar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim F As Integer = .CurrentCellAddress.Y
                If F = -1 Then F = 0
                If F > -1 Then
                    If Val(.Rows(F).Cells("c_anula_reg").Value) = 0 Then
                        Dim G As String = MsgBox("¿Confirma la anulación del registro?", vbYesNo, Compañia)
                        If G = vbYes Then
                            TxtItem.Text = .Rows(F).Cells("Item").Value
                            TxtFecha.Text = .Rows(F).Cells("Fecha").Value
                            TxtClie.Text = .Rows(F).Cells("Cliente").Value
                            TxtSerieDoc.Text = Strings.Left(.Rows(F).Cells("Documento").Value, 4)
                            TxtNroDoc.Text = Strings.Right(.Rows(F).Cells("Item").Value, 7)
                            TxtTotalDoc.Text = Format(Val(.Rows(F).Cells("Total").Value), Forma_1_2)
                            TxtSerieDocAnexo.Text = Strings.Left(.Rows(F).Cells("Anexo").Value, 4)
                            TxtNroDocAnexo.Text = Strings.Right(.Rows(F).Cells("Anexo").Value, 7)
                            TxtDocActa.Text = Format(Val(.Rows(F).Cells("Acta.").Value), Forma_1_2)
                            ' Boletas '
                            If Val(TxtVar.Text) = 1 Then
                                Call Grabar_Registro_Bol("DEL")
                                Cargar_Grid(" and (C.c_nro_serie + C.c_nro_boleta ='" & FrmBoletas.CboSerie.Text & FrmBoletas.TxtBoleta.Text &
                                        "' or A.c_serie_anexo + A.c_boleta_anexo='" & FrmBoletas.CboSerie.Text & FrmBoletas.TxtBoleta.Text & "') order by C.c_fecha_emi ", "02")
                            End If
                            ' Facturas '
                            If Val(TxtVar.Text) = 2 Then
                                Call Grabar_Registro_Fact("DEL")
                                Cargar_Grid(" and (C.c_nro_serie + C.c_nro_factura='" & FrmFacturas.CboSerie.Text & FrmFacturas.TxtFactura.Text &
                                       "' or A.c_serie_anexo + A.c_factura_anexo='" & FrmFacturas.CboSerie.Text & FrmFacturas.TxtFactura.Text & "') order by C.c_fecha_emi ", "01")
                            End If
                        End If
                    Else
                        MsgBox("Registro no puede ser anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnGenerarFactura_Click(sender As Object, e As EventArgs) Handles BtnGenerarFactura.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim f As String = MsgBox("¿Desea generar una factura de Anticipo?", vbYesNo + vbQuestion, Compañia)
                If f = vbYes Then
                    ' Boletas '
                    If Val(TxtVar.Text) = 1 Then
                        c_Neg_FactCab.set_FactElectronico_Save(TxtSerieDoc2.Text, TxtNroDoc2.Text, "02", "ADD")
                    End If
                    ' Facturas '
                    If Val(TxtVar.Text) = 2 Then
                        c_Neg_FactCab.set_FactElectronico_Save(TxtSerieDoc2.Text, TxtNroDoc2.Text, "01", "ADD")
                    End If
                    MsgBox("Documento se genero de manera correcta...", vbExclamation, Compañia)
                    BtnGenerarFactura.Enabled = False : Me.Close()
                End If
            Else
                MsgBox("1. No existen Documentos Anexos para generar un documento por anticipo...", vbCritical, Compañia)
            End If
        End With
    End Sub
End Class