Public Class FrmLetras
    
    Private Sub FrmLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" AND c_anula_reg=0 order by c_codi_mon ", CboMon)
        With c_Neg_MnSeriesDoc.get_Series_Datos(" and c_codi_doc='05' and c_anula_reg=0 order by c_nro_serie", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                TxtNro_Liq.Text = .Rows(0)("c_nro_doc").ToString
                TxtAño.Text = Year(Date.Now)
            End If
        End With
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_codi_StLetra", CboStatus)
        Dgv03.Rows.Add() : Dgv04.Rows.Add() : Call Validar_Permiso(Me.Name, BtnGrabar, BtnEdit, BtnDel)
        CboStatus.SelectedIndex = 0
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
        FrmConClientes.TxtVar.Text = 8

        FrmConClientes.Cargar_Grid(" and c_anula_reg=0  order by c_desc_clie")

    End Sub
    'metodo que nos permite mostrar los documentos de fact
    Public Sub Mostrar_documentos()
        'buscamos por el tipo de moneda y solo los documentos perteneciente al proveedor y que tenga un saldo por factura...
        If Len(CboMon.Text) > 0 And Len(TxtCod_Clie.Text) > 0 Then
            With c_Neg_LetCab.get_LetCab_Datos(" And C.c_codi_clie='" & TxtCod_Clie.Text & "' and C.c_codi_mon='" & CboMon.SelectedValue & "' ", _
                                                "DOC", " And C.c_codi_clie='" & TxtCod_Clie.Text & "' and C.c_codi_mon='" & CboMon.SelectedValue & "' ")
                Dgv02.Rows.Clear()
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Dgv02.Rows.Add()
                        Dgv02.Rows(i).Cells("chk").Value = False
                        Dgv02.Rows(i).Cells("c_codi_doc").Value = .Rows(i)("c_codi_doc").ToString
                        Dgv02.Rows(i).Cells("tipo").Value = .Rows(i)("Doc").ToString
                        Dgv02.Rows(i).Cells("Nro_Doc").Value = .Rows(i)("Nro_Doc").ToString
                        Dgv02.Rows(i).Cells("Fec_Emision").Value = FormatDateTime(.Rows(i)("Fecha").ToString, DateFormat.ShortDate)
                        Dgv02.Rows(i).Cells("Importe_2").Value = Format(Val(.Rows(i)("Saldo").ToString) - Val(.Rows(i)("Retencion").ToString), Forma_1_2)
                        Dgv02.Rows(i).Cells("Retencion").Value = Format(Val(.Rows(i)("Retencion").ToString), Forma_1_2)
                        Dgv02.Rows(i).Cells("c_opc_apertura").Value = .Rows(i)("c_opc_apertura").ToString
                    Next
                End If
            End With
        End If
    End Sub
    ' Mostramos documentos si esta habilitado la moneda '
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        If CboMon.SelectedIndex > -1 Then Call Mostrar_documentos()
    End Sub
    'Cerramos Formulario...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick
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
            'row.Cells("Cantidad").Value = ""
            If Convert.ToBoolean(cellSelecion.Value) Then 'Activo

            Else 'Eliminamos registro de la oc de compra que fue desabilitada...
                'Dgv01.Columns("Cantidad").ReadOnly = True 'Inactivo...
            End If

            Call Calcular_Totales()
        End If
    End Sub

    Private Sub Dgv02_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellEndEdit

    End Sub
    Private Sub Dgv02_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.CurrentCellDirtyStateChanged
        If Dgv02.IsCurrentCellDirty Then
            Dgv02.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        Call Calcular_Totales()
    End Sub
    Private Sub Calcular_Totales()
        With Dgv02
            If .Rows.Count > 0 Then
                Dim Tot As Decimal = 0 : Dim Det As Decimal = 0
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells("Chk").Value = True Then
                        Tot = Tot + Val(.Rows(i).Cells("Importe_2").Value)
                        Det = Det + Val(.Rows(i).Cells("Retencion").Value)
                    End If
                Next
                Dgv04.Rows(0).Cells("Total_2").Value = Format(Tot, Forma_1_2)
                Dgv04.Rows(0).Cells("Total_Det").Value = Format(Det, Forma_1_2)
                TxtTot_Detrac.Text = Format(Det, Forma_1_2) : TxtTotal.Text = Format(Tot, Forma_1_2)
            End If
        End With
    End Sub

    Private Sub Dgv02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.SelectionChanged
        Call Calcular_Totales()
    End Sub
    'Cantidad de Letras...
    Private Sub TxtCant_Letra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCant_Letra.KeyDown
        If e.KeyCode = Keys.Enter Then
            With Dgv01
                .Rows.Clear()
                If Val(TxtCant_Letra.Text) > 0 Then
                    Call Mostrar_TpoCambio(Now.Date, TxtTc)
                    Dim c_nro_doc As Integer = 0
                    With c_Neg_MnSeriesDoc.get_Series_Datos(" And c_codi_doc='05' ", "DAT", FrmMenu.TxtCod_Emp.Text)
                        If .Rows.Count > 0 Then
                            c_nro_doc = Val(.Rows(0)("c_nro_doc").ToString)
                        End If
                    End With
                    For i = 1 To Val(TxtCant_Letra.Text)
                        .Rows.Add()
                        .Rows(i - 1).Cells("Letra").Value = ""
                        .Rows(i - 1).Cells("Cod_Status").Value = "01"
                        .Rows(i - 1).Cells("Status").Value = "POR ACEPTAR"
                        .Rows(i - 1).Cells("Dias").Value = 30
                        .Rows(i - 1).Cells("fec_giro").Value = FormatDateTime(Date.Now, DateFormat.ShortDate)
                        .Rows(i - 1).Cells("fec_venci").Value = FormatDateTime(DateAdd("d", 30, Now.Date), DateFormat.ShortDate)
                        .Rows(i - 1).Cells("Importe").Value = Format(Val(TxtTotal.Text) / Val(TxtCant_Letra.Text), Forma_1_2)
                        .Rows(i - 1).Cells("c_tpo_cambio").Value = Format(Val(TxtTc.Text), Forma_1_3)
                    Next
                    ' Metodo para Calcular '
                    Call Calcular_Total_Letras()
                End If
            End With
        End If
    End Sub
    ' Metodo para calcular los totales por letras '
    Private Sub Calcular_Total_Letras()
        With Dgv01
            Dim Tot_Letras As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_Letras = Format(Tot_Letras + Val(.Rows(i).Cells("Importe").Value), Forma_1_2)
            Next
            Dgv03.Rows(0).Cells("Total_1").Value = Tot_Letras
        End With
    End Sub
    Private Sub TxtCant_Letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCant_Letra.TextChanged

    End Sub
    ' Editamos los registro de las letras '
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    Call Nuevo_Ingreso() : TxtDias.Focus()
                    TxtLetra.Text = .Rows(fila).Cells("Letra").Value
                    TxtStatus.Text = .Rows(fila).Cells("Status").Value
                    TxtDias.Text = .Rows(fila).Cells("Dias").Value
                    DtpFec_Giro.Text = .Rows(fila).Cells("Fec_Giro").Value
                    DtpFec_Venci.Text = .Rows(fila).Cells("Fec_Venci").Value
                    TxtImporte.Text = Format(Val(.Rows(fila).Cells("Importe").Value), Forma_1_2)
                    TxtTc.Text = Format(Val(.Rows(fila).Cells("c_tpo_cambio").Value), Forma_1_3)
                End If
            End If
        End With
    End Sub
    Private Sub Nuevo_Ingreso()
        With Dgv01
            .Size = New Size(714, 115) : .Location = New Point(1, 43) : Dgv01.Enabled = False : Call Limpiar_Texto(Pan02)
        End With
    End Sub
    Private Sub Cancela_Ingreso()
        With Dgv01
            .Size = New Size(714, 138) : .Location = New Point(1, 20) : Dgv01.Enabled = True
            Call Limpiar_Texto(Pan02)
        End With
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancela_Ingreso()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(TxtTc.Text) > 0 Then
                        If ValidarCierre(DtpFec_Giro.Text) = True Then
                            .Rows(fila).Cells("Letra").Value = TxtLetra.Text
                            .Rows(fila).Cells("Status").Value = TxtStatus.Text
                            .Rows(fila).Cells("Dias").Value = TxtDias.Text
                            .Rows(fila).Cells("Fec_Giro").Value = DtpFec_Giro.Text
                            .Rows(fila).Cells("Fec_Venci").Value = DtpFec_Venci.Text
                            .Rows(fila).Cells("Importe").Value = Format(Val(TxtImporte.Text), Forma_1_2)
                            Call Cancela_Ingreso() : Call Calcular_Total_Letras()
                        End If
                    Else
                        MsgBox("Debe ingresar el tipo de cambio...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub TxtDias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDias.Click

    End Sub
    ' Cargamos datos al aceptar '
    Private Sub TxtDias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDias.KeyDown

    End Sub

    Private Sub TxtDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDias.KeyPress
        Call solonumeros(e)
    End Sub
    Private Sub Calcular_dias()
        DtpFec_Venci.Text = DateAdd("d", Val(TxtDias.Text), DtpFec_Giro.Text)
    End Sub

    Private Sub TxtDias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDias.TextChanged
        Call Calcular_dias()
    End Sub
    ' Mostramos el tipo de cambio '
    Private Sub DtpFec_Giro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Giro.ValueChanged
        Call Calcular_dias() : Call Mostrar_TpoCambio(DtpFec_Giro.Text, TxtTc)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        Call BtnEdit_Click(Nothing, Nothing)
    End Sub
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim F As String = MsgBox(" ¿Desea Grabar las Letras? ", vbQuestion + vbYesNo, Compañia)
            If F = vbYes Then
                Call Grabar_Liquidacion("ADD")
                ' Grabamos Letras '
                With Dgv01
                    For I = 0 To .RowCount - 1
                        Grabar_Letras_Cab(I, "ADD")
                    Next
                End With
                ' Grabamos Detalles de Facturas '
                With Dgv02
                    For u = 0 To .RowCount - 1
                        If .Rows(u).Cells("Chk").Value = True Then
                            Call Grabar_Letras_Det(u, "ADD")
                        End If
                    Next
                End With
                MsgBox(" Registro se grabo correctamente...", vbExclamation, Compañia)
                Me.Close()
            End If
        End If
    End Sub
    ' Funcion para validar la grabación '
    Function ValidarDatos() As Boolean
        If Dgv01.RowCount > 0 Then
            If Val(Dgv03.Rows(0).Cells("Total_1").Value) = Val(TxtTotal.Text) Then
                For i = 0 To Dgv01.RowCount - 1
                    If Val(Dgv01.Rows(i).Cells("c_tpo_cambio").Value) = 0 Then
                        ValidarDatos = False
                        i = Dgv01.RowCount
                    Else
                        ValidarDatos = True
                    End If
                Next
                If ValidarDatos = False Then MsgBox("Falta ingresar el Tipo de Cambio..", vbCritical, Compañia)
            Else
                MsgBox("1. Total de Letras no Coincide con el Total de la Liquidación...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("2. Falta ingresar el # de Letras...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    ' Metodo para grabar Liquidaciones '
    Private Sub Grabar_Liquidacion(ByVal cOpcion As String)
        With c_Ent_Liquidac
            TxtNro_Liq.Clear()
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_codi_clie = TxtCod_Clie.Text
            .c_reten_liq = Val(TxtPor_Detrac.Text)
            .c_cant_reten = Val(TxtTot_Detrac.Text)
            .c_total_liq = Val(TxtTotal.Text)
            .c_codi_mon = CboMon.SelectedValue
            .c_motivo_anula = ""
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            TxtNro_Liq.Text = c_Neg_Liquidac.set_Liquidac_Save(c_Ent_Liquidac, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para grabar la cabecera de la letra '
    Private Sub Grabar_Letras_Cab(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_LetCab
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_letra = Dgv01.Rows(Fila).Cells("Letra").Value
            .c_renov_letra = 0
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_codi_stletra = Dgv01.Rows(Fila).Cells("Cod_Status").Value
            .c_valor_letra = TxtValor.Text
            .c_nro_dias = Val(Dgv01.Rows(Fila).Cells("Dias").Value)
            .c_tpo_cambio = Val(Dgv01.Rows(Fila).Cells("c_tpo_cambio").Value)
            .c_fecha_giro = Dgv01.Rows(Fila).Cells("Fec_Giro").Value
            .c_fecha_venci = Dgv01.Rows(Fila).Cells("Fec_venci").Value
            .c_fecha_presenta = Dgv01.Rows(Fila).Cells("fec_venci").Value
            .c_codi_bco = "00"
            .c_motivo_anula = ""
            .c_cancel_letra = 0
            .c_imp_letra = Val(Dgv01.Rows(Fila).Cells("Importe").Value)
            .c_fiador_letra = ""
            .c_aval_letra = ""
            .c_direcc_letra = ""
            .c_dni_letra = ""
            .c_telf_letra = ""
            .c_rep_letra = ""
            .c_num_unico = ""
            .c_nro_cuenta = ""
            .c_sector_bco = ""
            .c_imp_pago = 0
            .c_porc_pago = 0
            .c_fecha_cancel = Dgv01.Rows(Fila).Cells("fec_venci").Value
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            Dgv01.Rows(Fila).Cells("Letra").Value = c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para Grabar Letras Detalles '
    Private Sub Grabar_Letras_Det(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_LetDet
            ' Validamos si es factura boleta o nota de debito
            Dim c_nro_factura As String = "" : Dim c_nro_boleta As String = "" : Dim c_nro_nd As String = ""
            If Dgv02.Rows(Fila).Cells("c_codi_doc").Value = "01" Then c_nro_factura = Strings.Right(Dgv02.Rows(Fila).Cells("Nro_Doc").Value, 7)
            If Dgv02.Rows(Fila).Cells("c_codi_doc").Value = "02" Then c_nro_boleta = Strings.Right(Dgv02.Rows(Fila).Cells("Nro_Doc").Value, 7)
            If Dgv02.Rows(Fila).Cells("c_codi_doc").Value = "04" Then c_nro_nd = Strings.Right(Dgv02.Rows(Fila).Cells("Nro_Doc").Value, 7)
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_doc = Strings.Right(Dgv02.Rows(Fila).Cells("Nro_Doc").Value, 7)
            .c_codi_doc = Dgv02.Rows(Fila).Cells("c_codi_doc").Value
            .c_codi_mon = CboMon.SelectedValue
            .c_nro_serie = Strings.Left(Dgv02.Rows(Fila).Cells("Nro_Doc").Value, 4)
            .c_nro_factura = c_nro_factura
            .c_nro_boleta = c_nro_boleta
            .c_nro_nd = c_nro_nd
            .c_imp_doc = Format(Val(Dgv02.Rows(Fila).Cells("Importe_2").Value), Forma_1_2)
            .c_cant_detracc = Format(Val(Dgv02.Rows(Fila).Cells("Retencion").Value), Forma_1_2)
            .c_nro_letra = ""
            .c_renov_letra = 0
            .c_opc_apertura = Val(Dgv02.Rows(Fila).Cells("c_opc_apertura").Value)
            .copcion = cOpcion
            c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub DtpFec_Venci_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Venci.ValueChanged

    End Sub
    ' Calculamos total de importe '
    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        If e.KeyCode = Keys.Enter Then If Val(TxtImporte.Text) > 0 Then Call BtnAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImporte.TextChanged

    End Sub
End Class