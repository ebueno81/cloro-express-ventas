Public Class FrmIngNC
    Dim Swicht As Integer = 0 : Dim Focos As Integer = 0
    Private Sub FrmIngNC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim f As String = MsgBox(" ¿Desea cerrar la aplicación...?", vbYesNo + MsgBoxStyle.Question, Compañia)
            If f = vbYes Then Me.Close()
        End If
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.P Then If BtnImprimir.Enabled = True Then Call BtnImprimir_Click(Nothing, Nothing)
        ' Volver a Generar la facturacion electronica '
        If e.KeyCode = Keys.F8 And BtnGrabar.Enabled = False Then
            Dim F As String = MsgBox("¿Desea volver a generar la Facturacion electronica?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_NC.Text, "03", "ADD")
                If ValidarEnvio(CboSerie.Text, TxtNro_NC.Text, "03", 1) = True Then
                    MsgBox("Registro subio correctamente...", vbExclamation, Compañia)
                End If
            End If
        End If
    End Sub

    Private Sub FrmIngNC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    ' Cargamos Datos iniciales '
    Private Sub FrmIngNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='03' order by c_nro_serie ", CboSerie, FrmMenu.TxtCod_Emp.Text)
        TxtBus_Serie.Text = FrmMenu.TxtSerie_Nc.Text : Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConClientes.MdiParent = FrmMenu
        FrmConClientes.Show()
        FrmConClientes.Cargar_Grid(" and c_anula_reg=0 AND c_desc_clie like '%" & TxtClie.Text & "%' order by c_desc_clie")
        FrmConClientes.TxtVar.Text = 6
    End Sub
    'metodo que nos permite mostrar los documentos de fact
    Public Sub Mostrar_documentos()
          'buscamos por el tipo de moneda y solo los documentos perteneciente al proveedor y que tenga un saldo por factura...
        If CboMon.SelectedIndex > -1 Then
            With c_Neg_NotaC.get_NotaC_Datos(" And C.c_codi_clie='" & TxtCod_Clie.Text & "' and C.c_codi_mon='" & CboMon.SelectedValue & "' ", "ANE", FrmMenu.TxtCod_Emp.Text)
                Dgv01.Rows.Clear()
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Dgv01.Rows.Add()
                        Dgv01.Rows(i).Cells("check").Value = False
                        Dgv01.Rows(i).Cells("tpo").Value = .Rows(i)("Doc").ToString
                        Dgv01.Rows(i).Cells("doc").Value = .Rows(i)("Nro_Doc").ToString '& " " & .Rows(i)("c_nro_doc").ToString
                        Dgv01.Rows(i).Cells("total").Value = .Rows(i)("Saldo").ToString
                        Dgv01.Rows(i).Cells("saldo").Value = .Rows(i)("Saldo").ToString
                        Dgv01.Rows(i).Cells("codigo").Value = .Rows(i)("c_codi_doc").ToString
                        Dgv01.Rows(i).Cells("Fecha_Doc").Value = FormatDateTime(.Rows(i)("Fecha").ToString, DateFormat.ShortDate)
                    Next
                End If
            End With
        End If
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03)
        Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05)
        ChkExportacion.Checked = False
        DtpFec_Emi.Text = Date.Now : DtpFec_Prd.Text = Date.Now
        CboMon.Enabled = True : BtnCon1.Enabled = True
        CboMon.SelectedIndex = -1
        CboMon.Focus() : CboMon.Select()
        Dgv01.Rows.Clear() : Dgv01.Enabled = True
        Call Nuevo_Registro()
        TxtObs.Clear() : CboSerie.Enabled = True
        BtnEstado.Visible = False : Swicht = 0
        CboSerie_SelectedIndexChanged(Nothing, Nothing)
        TxtTpoMotivo.Enabled = True : ChkExportacion.Enabled = True
        TxtTpoMotivo.Clear() : ChkExportacion.Checked = False : TxtLetras.Clear()
    End Sub
    Private Sub Nuevo_Registro()
        TxtBus_Ing.Clear()
        BtnGrabar.Enabled = True
        BtnEditar.Enabled = False
        BtnNuevo.Enabled = False
        BtnEliminar.Enabled = False
        BtnCerrar.Text = "&Cancelar"
        TxtObs.Enabled = True
        DtpFec_Prd.Enabled = True
        Pan04.Enabled = True : BtnImprimir.Enabled = False : Pan01.Enabled = False
        Pan06.Enabled = False : BtnCon1.Enabled = True
    End Sub
    Private Sub Cancela_Registro()
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05)
        CboMon.Enabled = False
        TxtBus_Ing.Clear()
        BtnGrabar.Enabled = False
        BtnEditar.Enabled = True : TxtObs.Enabled = False
        BtnNuevo.Enabled = True : BtnImprimir.Enabled = True
        BtnEliminar.Enabled = True
        BtnCerrar.Text = "&Cerrar"
        Dgv01.Rows.Clear() : TxtClie.Enabled = False : BtnCon1.Enabled = False
        Pan04.Enabled = False : DtpFec_Emi.Enabled = False : DtpFec_Prd.Enabled = False
        Pan06.Enabled = True : TxtObs.Clear() : Pan01.Enabled = True
        TxtTpoMotivo.Enabled = False : ChkExportacion.Enabled = False
    End Sub
    'editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If Val(TxtHora.Text) > 0 Then 'validamos que exista un registro activo
                If BtnEstado.Visible = False Then
                    BtnCon1.Enabled = False : TxtClie.Enabled = False
                    DtpFec_Prd.Focus() : CboMon.Enabled = False
                    CboMon.Enabled = False : Dgv01.Enabled = False
                    Call Nuevo_Registro() : Swicht = 1 : CboSerie.Enabled = False : TxtSubTotal.Enabled = False
                    BtnCon1.Enabled = False : TxtTpoMotivo.Enabled = True : ChkExportacion.Enabled = False
                Else
                    MsgBox("Registro se encuentra anulado, no podra realizar ninguna modificación", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        End If
    End Sub

    Private Sub TxtProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClie.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtProve_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClie.TextChanged

    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Buscar_TC_IGV() : DtpFec_Prd.Text = DtpFec_Emi.Text
    End Sub
    Private Sub Buscar_TC_IGV()
        Call Mostrar_IGV(DtpFec_Emi.Text, TxtPor_Igv) 'Hallamos % IGV
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC) 'hallamos el tipo de cambio
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick
        '
        ' Detecta si se ha seleccionado el header de la grilla
        '
        If e.RowIndex = -1 Then
            Return
        End If

        If Dgv01.Columns(e.ColumnIndex).Name = "Check" Then

            '
            ' Se toma la fila seleccionada
            '
            Dim row As DataGridViewRow = Dgv01.Rows(e.RowIndex)

            '
            ' Se selecciona la celda del checkbox
            '
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("check"), DataGridViewCheckBoxCell)
            Dim fila As Integer = 0
            row.Cells("Cantidad").Value = ""
            If Convert.ToBoolean(cellSelecion.Value) Then 'Activo

            Else 'Eliminamos registro de la oc de compra que fue desabilitada...
                Dgv01.Columns("Cantidad").ReadOnly = True 'Inactivo...
            End If
            Dgv01.Columns("Cantidad").ReadOnly = False
            Call Calcular_Totales()
            If Strings.Left(row.Cells("Tpo").Value, 1) = "F" Then CboSerie.SelectedValue = "FC01"
            If Strings.Left(row.Cells("Tpo").Value, 1) = "B" Then CboSerie.SelectedValue = "BC01"
            If Strings.Left(row.Cells("Tpo").Value, 1) = "N" Then CboSerie.SelectedValue = "NC01"

        End If
    End Sub
    Private Sub Dgv01_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.CurrentCellDirtyStateChanged
        If Dgv01.IsCurrentCellDirty Then
            Dgv01.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Dgv01_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellEndEdit
        If e.ColumnIndex = 4 Then
            With Dgv01
                On Error Resume Next
                Dim Value As Decimal = Val(.CurrentCell.Value.ToString)
                Dim row As DataGridViewRow = .CurrentRow
                If Value > Val(row.Cells("Total").Value) Then
                    MsgBox("Esta ingresando un monto mayor al documento...", MsgBoxStyle.Critical, Compañia)
                    row.Cells("Cantidad").Value = 0.0
                End If
                row.Cells("Cantidad").Value = Format(Val(row.Cells("Cantidad").Value), Forma_1_2)
                row.Cells("Saldo").Value = Format(Val(row.Cells("Total").Value) - Val(row.Cells("Cantidad").Value), Forma_1_2)
            End With
            Call Calcular_Totales()
        End If
    End Sub
    'metodo que nos permite calcular los registros...
    Private Sub Calcular_Totales()
        With Dgv01
            Call Limpiar_Texto(Pan05)
            On Error Resume Next
            For i = 0 To .RowCount - 1
                TxtTotal.Text = Format(Val(TxtTotal.Text) + Val(.Rows(i).Cells("Cantidad").Value.ToString), Forma_1_2)
            Next
            ' validamos si es por exportacion o inaf '
            If ChkExportacion.Checked = True Then
                TxtIgv.Text = "0.00"
            Else
                TxtIgv.Text = Format((Val(TxtTotal.Text) / Val(1 & "." & TxtPor_Igv.Text)) * (Val(TxtPor_Igv.Text) / 100), Forma_1_2)
            End If
            TxtSubTotal.Text = Format(Val(TxtTotal.Text) - Val(TxtIgv.Text), Forma_1_2)
            If Val(TxtTotal.Text) > 0 Then
                If CboMon.Text = "$." Then
                    TxtLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 DOLARES AMERICANOS", VbStrConv.Uppercase)
                Else
                    TxtLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 SOLES", VbStrConv.Uppercase)
                End If
            Else
                TxtTotal.Text = ""
            End If
        End With
    End Sub
    Private Function Validar_Doc() As Boolean
        With Dgv01
            If .RowCount > 0 Then
                For I = 0 To .RowCount - 1
                    If .Rows(I).Cells("Check").Value = True Then
                        I = .RowCount
                        Validar_Doc = True
                    Else
                        Validar_Doc = False
                    End If
                Next
                If Validar_Doc = False Then MsgBox("1. No se ha seleccionado ningun registro...", vbCritical, Compañia)
            Else
                Validar_Doc = False
                MsgBox("2. No existen registros activos por grabar...", vbCritical, Compañia)
            End If
        End With
    End Function
    ' Funcion para validar datos '
    Private Function ValidarDatos() As Boolean
        If Len(TxtTpoMotivo.Text) > 0 Then
            If CboMon.SelectedIndex > -1 Then
                If Len(TxtCod_Clie.Text) > 0 Then
                    If Val(TxtTC.Text) > 0 Then
                        If Val(TxtPor_Igv.Text) > 0 Then
                            If Len(TxtNro_NC.Text) > 0 Then
                                If Len(TxtObs.Text) > 0 Then
                                    ValidarDatos = True
                                Else
                                    ValidarDatos = False
                                    MsgBox("1. Falta ingresar el número de nota de crédito...", MsgBoxStyle.Critical, Compañia)
                                End If
                            Else
                                ValidarDatos = False
                                MsgBox("2. Falta ingresar el número de nota de crédito......", MsgBoxStyle.Critical, Compañia)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("3. Falta ingresar el I.G.V. comunicarse con el administrador del sistema...", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("4. Falta ingresar el tipo de cambio...", MsgBoxStyle.Critical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("5. Falta seleccionar el cliente...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("6. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("7. Falta ingresar el motivo de la nota de crédito  ...", MsgBoxStyle.Critical, Compañia)
        End If
    End Function
    'Grabamos la nueva nota de credito...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If Val(TxtTotal.Text) = 0 Then MsgBox("1.1 Falta ingresar el monto para la nota de crédito...", MsgBoxStyle.Critical, Compañia)
            If ValidarDatos() = True Then
                If Validar_Doc() = True Then
                    Dim f As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        Call TxtNro_NC_LostFocus(Nothing, Nothing)
                        If Swicht = 0 Then
                            Call Grabar_NC("ADD")
                        Else
                            Call Grabar_NC("EDI")
                        End If
                        ' Validamos si esta activa la facturacion electronica '
                        If FrmMenu.ChkElectronico.Checked = True Then
                            If IsNumeric(Strings.Left(CboSerie.Text, 1)) = False Then
                                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_NC.Text, "03", "ADD")
                            End If
                        Else
                            ' Call BtnImprimir_Click(Nothing, Nothing)
                        End If
                        Call BtnImprimir_Click(Nothing, Nothing)
                        If Val(TxtHora.Text) = 0 Then
                            Call BtnFin_Click(Nothing, Nothing)
                        Else
                            Call Mostrar_NotaC(" and c_nro_nc=" & TxtNro_NC.Text & "")
                        End If
                    End If
                    Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_NC(ByVal cOpcion As String)
        With c_Ent_NotaC
            'Mostramos el codigo de la moneda para poder grabar...
            Dim c_codi_doc, c_serie_doc
            Dim c_nro_factura As String = "" : Dim c_nro_boleta As String = "" : Dim c_nro_nd As String = ""
            Dim c_fecha_doc As Date
            Dim c_total_doc As Decimal = 0
            With Dgv01
                Dim Valor As Integer = 0
                If .RowCount > 0 Then
                    For i = 0 To .RowCount - 1
                        If .Rows(i).Cells("Check").Value = True Then
                            c_codi_doc = .Rows(i).Cells("codigo").Value
                            If .Rows(i).Cells("Codigo").Value = "01" Then c_nro_factura = Strings.Right(.Rows(i).Cells("doc").Value, 7)
                            If .Rows(i).Cells("Codigo").Value = "02" Then c_nro_boleta = Strings.Right(.Rows(i).Cells("doc").Value, 7)
                            If .Rows(i).Cells("Codigo").Value = "04" Then c_nro_nd = Strings.Right(.Rows(i).Cells("doc").Value, 7)
                            c_serie_doc = Strings.Left(.Rows(i).Cells("Doc").Value, 4)
                            c_total_doc = Val(.Rows(i).Cells("Total").Value)
                            c_codi_doc = .Rows(i).Cells("codigo").Value : c_fecha_doc = .Rows(i).Cells("Fecha_Doc").Value
                            i = .RowCount
                        End If
                        If i = .RowCount - 1 Then Valor = 1
                    Next
                End If
                If Valor = 1 Then
                    c_codi_doc = "00" : c_serie_doc = "0000" : c_nro_factura = "0000000" : c_fecha_doc = Date.Now
                End If
            End With
            Dim Moneda As String = ""
            If CboMon.SelectedIndex = 0 Then
                Moneda = "01"
            Else
                Moneda = "02"
            End If
            .c_nro_serie = CboSerie.Text : .c_nro_nc = TxtNro_NC.Text
            .c_codi_clie = TxtCod_Clie.Text : .c_codi_mon = Moneda
            .c_codi_doc = c_codi_doc : .c_fecha_emi = DtpFec_Emi.Text : .c_fecha_doc = c_fecha_doc
            .c_tpo_cambio = Val(TxtTC.Text) : .c_serie_doc = c_serie_doc
            .c_nro_factura = c_nro_factura : .c_nro_boleta = c_nro_boleta
            .c_nro_nd = c_nro_nd : .c_total_doc = c_total_doc
            .c_imp_nc = Val(TxtSubTotal.Text) : .c_imp_igv = Val(TxtIgv.Text)
            .c_imp_total = Val(TxtTotal.Text) : .c_cant_igv = Val(TxtPor_Igv.Text)
            .c_motivo_nc = TxtObs.Text : .c_letras_nc = TxtLetras.Text
            .c_tpo_motivo = TxtTpoMotivo.Text
            If ChkExportacion.Checked = True Then
                .c_opc_exporta = 1
            Else
                .c_opc_exporta = 0
            End If
            .c_opc_inaf = 0
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion

            c_Neg_NotaC.set_NotaC_Save(c_Ent_NotaC, FrmMenu.TxtCod_Emp.Text)
            MsgBox("Los datos se grabaron correctamente...", MsgBoxStyle.Exclamation, Compañia)
        End With
    End Sub
    'cerramos o cancelamos registro de nota de credito...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Swicht > 0 Then
                Call Mostrar_NotaC(" and c_nro_nc='" & TxtNro_NC.Text & "'")
            Else
                Call BtnFin_Click(Nothing, Nothing)
            End If
            Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        End If
    End Sub

    Private Sub TxtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call solonumeros(e)
    End Sub


    Private Sub TxtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtNro_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNro_NC.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtNro_NC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNro_NC.LostFocus
        If Val(TxtNro_NC.Text) > 0 Then
            TxtNro_NC.Text = Strings.Right(Val(TxtNro_NC.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtNro_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_NC.TextChanged

    End Sub

    Private Sub TxtBus_Ing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBus_Ing.KeyPress
        Call solonumeros(e)
    End Sub


    Private Sub TxtBus_Serie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call solonumeros(e)
    End Sub



    Private Sub TxtBus_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call solonumeros(e)
    End Sub
    'mostramos los detalles de las nota de credito...
    Private Sub Mostrar_NotaC(ByVal Cadena As String)
        With c_Neg_NotaC.get_NotaC_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Cancela_Registro()
            If .Rows.Count > 0 Then
                TxtBus_Ing.Text = .Rows(0)("c_nro_nc").ToString
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtClie.Text = .Rows(0)("c_desc_clie").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString
                TxtPor_Igv.Text = .Rows(0)("c_cant_igv").ToString
                CboSerie.SelectedValue = .Rows(0)("c_nro_serie").ToString
                TxtNro_NC.Text = .Rows(0)("c_nro_nc").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Prd.Text = .Rows(0)("c_fecha_emi").ToString
                TxtLetras.Text = .Rows(0)("c_letras_nc").ToString
                'validamos si nota de credito se encuentra anulada
                Dim Cadena2 As String = "" 'Variable que nos permitira trabajar con los anulados...
                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    BtnEstado.Visible = True
                    Cadena2 = " and D.c_anula_reg=1 and D.c_nro_nc='" & TxtHora.Text & "'"
                Else
                    BtnEstado.Visible = False
                    Cadena2 = " and D.c_anula_reg=0 and D.c_nro_nc='" & TxtHora.Text & "'"
                End If
                ' We validate if the credit note is exportation '
                If Val(.Rows(0)("c_opc_exporta").ToString) = 1 Then
                    ChkExportacion.Checked = True
                Else
                    ChkExportacion.Checked = False
                End If
                TxtTpoMotivo.Text = .Rows(0)("c_tpo_motivo").ToString

                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                TxtIgv.Text = .Rows(0)("c_imp_igv").ToString
                TxtSubTotal.Text = .Rows(0)("c_imp_nc").ToString
                TxtTotal.Text = .Rows(0)("c_imp_total").ToString
                TxtObs.Text = .Rows(0)("c_motivo_nc").ToString
                If Val(.Rows(0)("c_opc_Exporta").ToString) = 1 Then
                    ChkExportacion.Checked = True
                Else
                    ChkExportacion.Checked = False
                End If
                TxtTpoMotivo.Text = .Rows(0)("c_tpo_motivo").ToString
                'Mostramos los detalles de las facturas amarradas...
                Dim c_nro_doc As String = "" : Dgv01.Rows.Clear()
                If Len(.Rows(0)("c_nro_factura").ToString) > 0 Then c_nro_doc = .Rows(0)("c_nro_factura").ToString
                If Len(.Rows(0)("c_nro_boleta").ToString) > 0 Then c_nro_doc = .Rows(0)("c_nro_boleta").ToString
                If Len(.Rows(0)("c_nro_nd").ToString) > 0 Then c_nro_doc = .Rows(0)("c_nro_nd").ToString
                Dgv01.Rows.Add()
                Dgv01.Rows(0).Cells("check").Value = True
                Dgv01.Rows(0).Cells("codigo").Value = .Rows(0)("c_codi_doc").ToString
                Dgv01.Rows(0).Cells("Tpo").Value = .Rows(0)("c_desc_doc").ToString
                Dgv01.Rows(0).Cells("Doc").Value = .Rows(0)("c_serie_doc").ToString & " " & c_nro_doc
                Dgv01.Rows(0).Cells("Total").Value = Format(Val(.Rows(0)("c_total_doc").ToString), Forma_1_2)
                Dgv01.Rows(0).Cells("Cantidad").Value = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                Dgv01.Rows(0).Cells("Saldo").Value = Format(Val(.Rows(0)("c_total_doc").ToString) - Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                Dgv01.Rows(0).Cells("Fecha_Doc").Value = .Rows(0)("c_fecha_doc").ToString
                Dgv01.Enabled = False
            End If
        End With
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_NotaC(" and N.c_nro_serie='" & TxtBus_Serie.Text & "' and N.c_nro_nc=(select max(c_nro_nc) from Sca_Fa_NotaC WHERE c_nro_serie='" & TxtBus_Serie.Text & "')")
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_NotaC(" and N.c_nro_serie='" & TxtBus_Serie.Text & "' and N.c_nro_nc=(select min(c_nro_nc) From Sca_Fa_notac WHERE c_nro_serie='" & TxtBus_Serie.Text & "')")
    End Sub

    Private Sub TxtBus_Ing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Ing.TextChanged

    End Sub
    Private Sub TxtBus_Ing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Ing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Ing.Text) > 0 Then
                TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000000, 7)
                Call Mostrar_NotaC(" and c_nro_nc='" & TxtBus_Ing.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")
            End If
        End If
    End Sub
    'Metodo que trabaja con el listado de Nota de Credito...
    Public Sub Mostrar_NotaC()
        Call Mostrar_NotaC(" and c_nro_nc='" & TxtBus_Ing.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")
    End Sub
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_Ing.Text) > 1 Then
            TxtBus_Ing.Text = Strings.Right((Val(TxtBus_Ing.Text) - 1) + 10000000, 7)
            Call Mostrar_NotaC(" and c_nro_nc='" & TxtBus_Ing.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")

        End If
    End Sub
    'avanzamos
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_Ing.Text) > 0 Then
            TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000001, 7)
            Call Mostrar_NotaC(" and c_nro_nc='" & TxtBus_Ing.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "' ")
        End If
    End Sub
    ' Eliminamos Nota de Crédito '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If BtnEstado.Visible = False Then
                Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                If f = vbYes Then
                    Call Grabar_NC("DEL") : BtnEstado.Visible = True
                    ' Validamos si esta activa la facturacion electronica '
                    If FrmMenu.ChkElectronico.Checked = True Then
                        c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_NC.Text, "03", "DEL")
                    End If
                End If
            Else
                MsgBox("Registro ya fue eliminado, no podra realizar esta operación", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub
    'mostramos el tipo de moneda
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        If CboMon.Enabled = True Then
            LblMon1.Text = CboMon.Text : LblMon2.Text = CboMon.Text : LblMon3.Text = CboMon.Text
            Call Mostrar_documentos()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TxtHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub CboSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSerie.LostFocus
        If Focos = 1 Then
            Focos = 0 : CboSerie.Focus()
        End If
    End Sub

    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        If CboSerie.Enabled = True Then
            With c_Neg_MnSeriesDoc.get_Series_Datos(" and c_anula_reg=0 and c_codi_doc='03' and c_nro_serie='" & CboSerie.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                TxtNro_NC.Clear()
                If .Rows.Count > 0 Then TxtNro_NC.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
                TxtBus_Ing.Text = TxtNro_NC.Text
            End With
        End If
    End Sub
    'Impresión de Nota de Crédito...
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If IsNumeric(Strings.Left(CboSerie.Text, 1)) = True Then
            FrmReportes.Impresion_NotaC(CboSerie.Text, TxtNro_NC.Text)
        Else
            If ValidarEnvio(CboSerie.Text, TxtNro_NC.Text, "03", 0) = True Then
                ' Call Abrir_Pdf("07-" & CboSerie.Text & "-0" & TxtNro_NC.Text &
                '           "\" & FrmMenu.TxtRuc.Text & "-07-" & CboSerie.Text & "-0" & TxtNro_NC.Text & ".pdf")
                Abrir_PDf_2(CboSerie.Text & "-0" & TxtNro_NC.Text, "07", DtpFec_Emi.Text)
            End If
        End If
    End Sub
    'Listado de nota de Credito
    Private Sub LnkConNotaC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkConNotaC.LinkClicked
        FrmConNotaC.MdiParent = FrmMenu : FrmConNotaC.Show() : FrmConNotaC.TxtVar.Text = 1
    End Sub

    Private Sub DtpFec_Prd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFec_Prd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : CboSerie.Focus()
        End If
    End Sub

    Private Sub DtpFec_Prd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Prd.ValueChanged

    End Sub

    Private Sub Dgv01_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv01.KeyDown

    End Sub

    Private Sub ChkExportacion_CheckedChanged(sender As Object, e As EventArgs) Handles ChkExportacion.CheckedChanged

    End Sub

    Private Sub ChkExportacion_Click(sender As Object, e As EventArgs) Handles ChkExportacion.Click
        If ChkExportacion.Enabled = True Then Call Calcular_Totales()
    End Sub
End Class