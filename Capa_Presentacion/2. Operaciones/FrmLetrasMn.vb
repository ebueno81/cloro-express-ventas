Public Class FrmLetrasMn
    Dim edit As Integer = 0
    ' Cerramos Registros '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    ' Metodo para cancelar registro '
    Private Sub Cancelar_Registro()
        Pan11.Enabled = True : BtnCerrar.Text = "Cerrar" : BtnGrabar.Enabled = False : PanRenova.Visible = False
        Call Desactivar(Pan02) : Call Desactivar(Pan04) : Call Desactivar(Pan05) : Call Desactivar(Pan10)
        Call Desactivar(Pan09) : Call Desactivar(Pan08) : CboStatus.Enabled = False
        Call Validar_Permiso(Me.Name, BtnRenovac, BtnEditar, BtnAnular) : TxtDias.Enabled = False
        TxtNro_Unico.Enabled = False
    End Sub
    Private Sub FrmLetrasMn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub FrmLetrasMn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    ' Iniciamos  formularios '
    Private Sub FrmLetrasMn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_desc_stletra", CboStatus)
        c_Neg_MnBcos.Get_Bcos_Cbo(" order by c_desc_bco", CboBco)
        Dgv03.Columns.Clear() : Dgv04.Columns.Clear() : Dgv05.Rows.Add() : Dgv06.Rows.Add()
        Call Validar_Permiso(Me.Name, BtnRenovac, BtnEditar, BtnAnular)
    End Sub
    ' Buscar por numero de letra '
    Private Sub TxtBus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 1000000, 6) : TxtBus_Nro.Text = 0
                Call Mostrar_Letras(" And L.c_nro_letra='" & TxtBus.Text & "' ")
            End If
        End If
    End Sub
    ' Mostrar Letras '
    Private Sub Mostrar_Letras(ByVal Cadena As String)
        With c_Neg_LetCab.get_LetCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Nuevo_Registro() : Call Cancelar_Registro()
            If .Rows.Count > 0 Then
                TxtBus.Text = .Rows(0)("c_nro_letra").ToString : TxtBus_Nro.Text = .Rows(0)("c_renov_letra").ToString
                TxtAño.Text = .Rows(0)("c_año_liq").ToString
                TxtNro_Letra.Text = .Rows(0)("c_nro_letra").ToString
                TxtRenov.Text = .Rows(0)("c_renov_letra").ToString
                TxtNro_Liq.Text = .Rows(0)("c_nro_liq").ToString
                TxtTc.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                DtpFec_Giro.Text = .Rows(0)("c_fecha_giro").ToString
                DtpFec_Venci.Text = .Rows(0)("c_fecha_venci").ToString
                TxtMon.Text = .Rows(0)("c_nick_mon").ToString
                TxtCod_Mon.Text = .Rows(0)("c_codi_mon").ToString
                TxtSist_Bahia.Text = Val(.Rows(0)("c_sist_bahia").ToString)
                TxtTotal.Text = Format(Val(.Rows(0)("c_imp_letra").ToString), Forma_1_2)
                TxtCod_Status.Text = .Rows(0)("c_codi_stletra").ToString
                CboStatus.SelectedValue = .Rows(0)("c_codi_stletra").ToString
                CboStatus.Text = .Rows(0)("c_codi_stletra").ToString
                TxtDias_Let.Text = .Rows(0)("c_nro_dias").ToString
                LblEmpresa.Text = FrmMenu.TxtEmpresa.Text
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtCliente.Text = .Rows(0)("c_desc_clie").ToString
                TxtDireccion.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & _
                                    " " & .Rows(0)("c_prov_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                TxtFono_Clie.Text = .Rows(0)("c_telf_clie").ToString
                TxtFiador.Text = .Rows(0)("c_fiador_letra").ToString
                TxtAval.Text = .Rows(0)("c_aval_letra").ToString
                TxtDir_Fiador.Text = .Rows(0)("c_direcc_letra").ToString
                TxtDni.Text = .Rows(0)("c_dni_letra").ToString
                TxtFono_Fiador.Text = .Rows(0)("c_telf_letra").ToString
                TxtNom_Rep.Text = .Rows(0)("c_rep_letra").ToString
                TxtNro_Unico.Text = .Rows(0)("c_num_unico").ToString
                DtpFec_Presenta.Text = .Rows(0)("c_fecha_presenta").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtDias.Text = ""
                TxtInteres.Text = ""
                TxtTea.Text = .Rows(0)("c_porc_pago").ToString
                TxtCargos.Text = ""
                TxtImporte.Text = .Rows(0)("c_imp_pago").ToString
                TxtCod_Prov.Text = ""
                TxtProve.Text = ""
                TxtCod_Bco.Text = .Rows(0)("c_codi_bco").ToString
                CboBco.SelectedValue = .Rows(0)("c_codi_bco").ToString
                TxtNro_Cuenta.Text = .Rows(0)("c_nro_cuenta").ToString
                TxtSectorista.Text = .Rows(0)("c_sector_bco").ToString
                DtpFec_Abono.Text = .Rows(0)("c_fecha_cancel").ToString
                ' Status pagado por cliente '
                If Val(.Rows(0)("c_pagado_clie").ToString) = 1 Then
                    ChkStatus.Checked = True
                Else
                    ChkStatus.Checked = False
                End If
                'Validamos si documento se encuentra anulado
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_cancel_letra").ToString) = 0 Then
                        If Val(.Rows(0)("c_opc_dscto").ToString) = 1 Then
                            BtnEstado.Text = "DESCUENTO" : BtnEstado.BackColor = Color.Maroon
                        Else
                            BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Color.Maroon
                        End If
                    Else
                        If Val(.Rows(0)("c_cancel_letra").ToString) = 1 Then
                            BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Color.Gray
                        Else
                            BtnEstado.Text = "AMORTIZADO" : BtnEstado.BackColor = Color.Gainsboro
                        End If
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                End If
                'Validamos para la conversion de numeros a letras...
                If Val(TxtTotal.Text) > 0 Then
                    If TxtMon.Text = "$." Then
                        LblLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 DOLARES AMERICANOS", VbStrConv.Uppercase)
                    Else
                        LblLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 SOLES", VbStrConv.Uppercase)
                    End If
                Else
                    LblLetras.Text = ""
                End If
                ' Mostramos datos de las letras amarradas a la letra '
                Dgv03.DataSource = c_Neg_LetCab.get_LetCab_Datos(" and L.c_año_liq=" & Val(TxtAño.Text) & "  and L.c_nro_liq='" & TxtNro_Liq.Text & "' and Convert(Nvarchar(7),L.c_nro_letra) +'-'+ Convert(Nvarchar(1),L.c_renov_letra) not in ('" & TxtNro_Letra.Text & "-" & TxtRenov.Text & "') order by c_renov_letra ", _
                                                                 "DG2", FrmMenu.TxtCod_Emp.Text)
                With Dgv03
                    .Columns("Letra").Width = 50
                    .Columns("R").Width = 30
                    .Columns("Fecha Giro").Width = 100
                    .Columns("Fecha Venci.").Width = 110
                    .Columns(" ").Width = 30
                    .Columns("Importe").Width = 60
                    .Columns("c_anula_reg").Visible = False
                    Call Grid_Registros_anulados(Dgv03)
                    ' Alineacion '
                    .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("R").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Fecha Giro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Fecha Venci.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(" ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End With
                ' Mostramos documentos amarrados a la letra '
                With Dgv04
                    .DataSource = c_Neg_LetDet.get_LetDet_Datos(" And L.c_nro_liq='" & TxtNro_Liq.Text & "' and L.c_año_liq='" & TxtAño.Text & "'", "DG2", FrmMenu.TxtCod_Emp.Text)
                    .Columns("Tipo").Width = 120
                    .Columns("Nro. Documento").Width = 140
                    .Columns("Importe").Width = 80
                    ' Columnas Alineacion
                    .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Nro. Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    ' Columnas Visibles '
                    .Columns("c_codi_doc").Visible = False
                    .Columns("c_cant_detracc").Visible = False
                    .Columns("c_opc_apertura").Visible = False
                End With
                ' llamamos al metodo para calcular los totales de la factura calculamos totales por facturacion'
                Call Calcular_Totales_Letra()
            Else

            End If
        End With
    End Sub
    ' Metodo que nos permite calcular el total de letras '
    Private Sub Calcular_Totales_Letra()
        With Dgv03
            Dim Tot_letra As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_letra = Tot_letra + Val(.Rows(i).Cells("Importe").Value)
            Next
            Dgv05.Rows(0).Cells("Tot_Det2").Value = Format(Tot_letra, Forma_1_2)
            Dgv05.Rows(0).Cells("Titulo_2").Value = "Nro de Letras"
            Dgv05.Rows(0).Cells("Total_2").Value = Dgv03.RowCount
            ' Alineacion '
            Dgv05.Columns("Total_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgv05.Columns("Tot_Det2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        With Dgv04
            Dim Tot_letra As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_letra = Tot_letra + Val(.Rows(i).Cells("Importe").Value)
            Next
            Dgv06.Rows(0).Cells("Importe_Det").Value = "Nro de Documentos"
            Dgv06.Rows(0).Cells("Titulo_1").Value = Dgv04.RowCount
            Dgv06.Rows(0).Cells("Importe_1").Value = Format(Tot_letra, Forma_1_2)
            Dgv06.Columns("Importe_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgv06.Columns("Importe_Det").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Metodo para activar y limpiar las ventanas '
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04)
        Call Limpiar_Texto(Pan05) : Call Limpiar_Texto(Pan06) : Call Limpiar_Texto(Pan07)
        Call Limpiar_Texto(Pan08) : Call Limpiar_Texto(Pan09) : Call Limpiar_Texto(Pan10)
        On Error Resume Next
        Dgv03.Rows.Clear() : Dgv04.Rows.Clear() : Dgv05.Rows.Clear() : Dgv06.Rows.Clear()
        Dgv05.Rows.Add() : Dgv06.Rows.Add()
    End Sub
    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub
    ' Editamos registros '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarFactu("LETRA", " And L.c_nro_letra='" & TxtNro_Letra.Text & "' and L.c_renov_letra=" & Val(TxtRenov.Text)) = True Then
            If BtnEstado.Text = "PENDIENTE" Then
                Call Activar(Pan05) : Call Activar(Pan10) : Call Activar(Pan09) : Call Activar(Pan08) : TxtCod_Bco.Enabled = False
                TxtFiador.Focus() : BtnGrabar.Enabled = True : BtnCerrar.Text = "Cancelar" : Pan11.Enabled = False
                DtpFec_Abono.Enabled = True : DtpFec_Presenta.Enabled = True : CboStatus.Enabled = True
                TxtDias.Enabled = True : ChkStatus.Enabled = False
            Else
                If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
                    ChkStatus.Enabled = True : ChkStatus.Enabled = True : CboBco.Enabled = True
                    Pan11.Enabled = False : BtnGrabar.Enabled = True : CboStatus.Enabled = True : CboStatus.Focus() : BtnCerrar.Text = "&Cancelar"
                    TxtNro_Unico.Enabled = True : ChkStatus.Enabled = False
                Else
                    MsgBox(" Registro se encuentra Anulado o esta cerrado no podra realizar ninguna modificación...", vbExclamation, Compañia)
                End If
            End If
        End If
    End Sub
    ' Grabamos Registro de letras '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        ' Validamos si grabamos una nueva letra por renovacion o solo actualizamos datos '
        If PanRenova.Visible = True Then
            Dim F As String = MsgBox(" ¿Desea Actualizar el registro? ", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Letras_Cab("REN") : MsgBox(" Registro se Grabo Correctamente...", vbExclamation, Compañia)
                Call BtnCerrar_Click(Nothing, Nothing) : ChkStatus.Enabled = False : CboStatus.Enabled = False
                CboBco.Enabled = False
            End If
        Else
            Dim F As String = MsgBox(" ¿Desea Grabar el registro? ", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Dim vOpt As String = "EDI"
                If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
                    vOpt = "PAG"
                End If
                Call Grabar_Letras_Cab(vOpt) : MsgBox(" Registro se Grabo Correctamente...", vbExclamation, Compañia)
                Call BtnCerrar_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    ' Metodo para grabar la cabecera de la letra '
    Private Sub Grabar_Letras_Renovac(ByVal cOpcion As String)
        With c_Ent_LetCab
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_letra = TxtNro_Letra.Text
            .c_renov_letra = Val(TxtRenov.Text)
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_mon = TxtCod_Mon.Text
            .c_codi_stletra = "01"
            .c_valor_letra = "RECIBIDO"
            .c_nro_dias = Val(TxtDias_4.Text)
            .c_tpo_cambio = Val(TxtTc2.Text)
            .c_fecha_giro = DtpFec_Giro4.Text
            .c_fecha_venci = DtpFec_Venci4.Text
            .c_fecha_presenta = DtpFec_Venci4.Text
            .c_codi_bco = "00"
            .c_motivo_anula = "" : .c_cancel_letra = 0 : .c_imp_letra = Val(TxtImporte4.Text)
            .c_fiador_letra = "" : .c_aval_letra = "" : .c_direcc_letra = ""
            .c_dni_letra = "" : .c_telf_letra = "" : .c_rep_letra = ""
            .c_num_unico = "" : .c_nro_cuenta = "" : .c_sector_bco = ""
            .c_imp_pago = 0
            .c_porc_pago = Val(TxtPor.Text)
            .c_fecha_cancel = DtpFec_Venci4.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para grabar la cabecera de la letra '
    Private Sub Grabar_Letras_Cab(ByVal cOpcion As String)
        With c_Ent_LetCab
            Dim c_pagado_clie As Integer = 0
            If ChkStatus.Checked = True Then c_pagado_clie = 1
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_letra = TxtNro_Letra.Text
            .c_renov_letra = Val(TxtRenov.Text)
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_mon = ""
            .c_codi_stletra = TxtCod_Status.Text
            .c_valor_letra = ""
            .c_nro_dias = Val(TxtDias_Let.Text)
            .c_fecha_giro = DtpFec_Giro.Text
            .c_fecha_venci = DtpFec_Venci.Text
            .c_fecha_presenta = DtpFec_Presenta.Text
            .c_codi_bco = TxtCod_Bco.Text
            .c_motivo_anula = "" : .c_cancel_letra = 0 : .c_imp_letra = 0
            .c_fiador_letra = TxtFiador.Text : .c_aval_letra = TxtAval.Text : .c_direcc_letra = TxtDir_Fiador.Text
            .c_dni_letra = TxtDni.Text : .c_telf_letra = TxtFono_Fiador.Text : .c_rep_letra = TxtNom_Rep.Text
            .c_num_unico = TxtNro_Unico.Text : .c_nro_cuenta = TxtNro_Cuenta.Text : .c_sector_bco = TxtSectorista.Text
            .c_imp_pago = 0
            .c_porc_pago = TxtTea.Text
            .c_fecha_cancel = DtpFec_Abono.Text
            .c_pagado_clie = c_pagado_clie
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub CboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboStatus.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboStatus, TxtCod_Status)
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Letras(" AND c_nro_letra= (select max(c_nro_letra) from sca_Fa_letcab) ")
    End Sub
    ' Renovacion de letras '
    Private Sub BtnRenovac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRenovac.Click
        If ValidarFactu("LETRA", " And L.c_nro_letra='" & TxtNro_Letra.Text & "' and L.c_renov_letra=" & Val(TxtRenov.Text)) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Or UCase(BtnEstado.Text) = "AMORTIZADO" Then
                If Len(TxtNro_Letra.Text) > 0 Then
                    Call Limpiar_Texto(PanRenova)
                    PanRenova.Visible = True
                    TxtLetra_3.Text = TxtNro_Letra.Text : TxtLetra_4.Text = TxtNro_Letra.Text
                    DtpFec_Giro3.Text = DateAdd("d", 1, DtpFec_Giro.Text)
                    DtpFec_Venci3.Text = DateAdd("d", 1, DtpFec_Giro.Text)
                    TxtMon3.Text = TxtMon.Text : TxtMon4.Text = TxtMon.Text
                    TxtImporte3.Text = Format(Val(TxtTotal.Text) - Val(TxtImporte.Text), Forma_1_2)
                    TxtDias_3.Text = DateDiff("d", DtpFec_Giro3.Text, DtpFec_Venci3.Text)
                    Call Nuevo_Ingreso_2()
                    TxtPor.Focus() : Call Mostrar_TpoCambio(DtpFec_Giro3.Text, TxtTc2)
                Else
                    MsgBox("1. Debe seleccionar un registro, para poder realizar la renovación...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("2. Registro se encuentra cerrado o esta anulado, no podra realizar ninguna operación...", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub
    ' Metodo que trabaja con la renovacion de leltras '
    Private Sub Nuevo_Ingreso_2()
        BtnGrabar.Enabled = True : BtnCerrar.Text = "Cancelar" : Pan11.Enabled = False
    End Sub
    ' Buscamos por numero de orden '
    Private Sub TxtBus_Nro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Nro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Nro.Text) > -1 Then
                Call Mostrar_Letras(" And L.c_nro_letra='" & TxtBus.Text & "' and L.c_renov_letra=" & Val(TxtBus_Nro.Text))
            End If
        End If
    End Sub

    Private Sub TxtBus_Nro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Nro.TextChanged

    End Sub

    Private Sub TxtPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPor.TextChanged
        TxtImporte3.Text = Format((Val(TxtTotal.Text) - Val(TxtImporte.Text)) * (Val(TxtPor.Text) / 100), Forma_1_2)
        TxtImporte4.Text = Format((Val(TxtTotal.Text) - Val(TxtImporte.Text)) - Val(TxtImporte3.Text), Forma_1_2)
    End Sub
    ' Actualizamos letras '
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Val(TxtTc2.Text) > 0 Then
            Dim F As String = MsgBox(" ¿Desea Grabar la renovación de Letras? ", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Letras_Renovac("REN") : PanRenova.Visible = False
                TxtBus.Text = TxtNro_Letra.Text : TxtBus_Nro.Text = Val(TxtRenov.Text) + 1
                Call Mostrar_Letras(" And L.c_nro_letra='" & TxtBus.Text & "' and L.c_renov_letra=" & Val(TxtBus_Nro.Text))
                Call Cancelar_Registro()
            End If
        Else
            MsgBox("Falta ingresar el tipo de cambio...", vbCritical, Compañia)
        End If
    End Sub
    ' Cargamos los dias por la fecha de vencimiento... '
    Private Sub TxtDias_4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDias_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpFec_Venci4.Text = DateAdd("d", Val(TxtDias_4.Text), DtpFec_Giro4.Text)
        End If
    End Sub

    Private Sub TxtDias_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDias_4.TextChanged

    End Sub
    ''' Hallamos los dias por la fecha de vencimiento '''
    Private Sub DtpFec_Venci4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Venci4.ValueChanged
        TxtDias_4.Text = DateDiff("d", DtpFec_Giro4.Text, DtpFec_Venci4.Text)
    End Sub
    ' Validamos si deseamos eliminar la letra de cambio '
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        If ValidarFactu("LETRA", " And L.c_nro_letra='" & TxtNro_Letra.Text & "' and L.c_renov_letra=" & Val(TxtRenov.Text)) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                Dim f As String = MsgBox("¿Desea Eliminar la Letra?", vbYesNo + vbQuestion)
                If f = vbYes Then
                    Call Grabar_Letras_Cab("DEL")
                    ' Eliminamos todos los documentos amarrados a la letra siempre que renovacion sea cero '
                    ' Grabamos Detalles de Facturas '
                    If Val(TxtRenov.Text) = 0 Then
                        With Dgv04
                            For u = 0 To .RowCount - 1
                                Call Grabar_Letras_Det(u, "DEL")
                            Next
                        End With
                        ' Eliminamos letras renovadas y las no renovadas '
                        With Dgv03
                            For u = 0 To .RowCount - 1
                                If Val(.Rows(u).Cells("R").Value) <> Val(TxtRenov.Text) Then
                                    If Val(.Rows(u).Cells("c_anula_reg").Value) = 0 Then
                                        Call Eliminar_Letras_Cab(u, "DE2")
                                    End If
                                End If
                            Next
                        End With
                    Else
                        With Dgv03
                            For u = .RowCount - 1 To 0 Step -1
                                If Val(.Rows(u).Cells("c_anula_reg").Value) = 0 Then
                                    Call Eliminar_Letras_Cab(u, "DE2")
                                    u = .RowCount
                                End If
                            Next
                        End With
                    End If
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                    MsgBox(" Registro se Anulo correctamente...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    ' Metodo para Grabar Letras Detalles '
    Private Sub Grabar_Letras_Det(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_LetDet
            ' Validamos si es factura boleta o nota de debito
            Dim c_nro_factura As String = "" : Dim c_nro_boleta As String = "" : Dim c_nro_nd As String = ""
            If Dgv04.Rows(Fila).Cells("c_codi_doc").Value = "01" Then c_nro_factura = Strings.Right(Dgv04.Rows(Fila).Cells("Nro. Documento").Value, 7)
            If Dgv04.Rows(Fila).Cells("c_codi_doc").Value = "02" Then c_nro_boleta = Strings.Right(Dgv04.Rows(Fila).Cells("Nro. Documento").Value, 7)
            If Dgv04.Rows(Fila).Cells("c_codi_doc").Value = "04" Then c_nro_nd = Strings.Right(Dgv04.Rows(Fila).Cells("Nro. Documento").Value, 7)
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = TxtAño.Text
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_doc = Strings.Right(Dgv04.Rows(Fila).Cells("Nro. Documento").Value, 7)
            .c_codi_doc = Dgv04.Rows(Fila).Cells("c_codi_doc").Value
            .c_codi_mon = TxtCod_Mon.Text
            .c_nro_serie = Strings.Left(Dgv04.Rows(Fila).Cells("Nro. Documento").Value, 4)
            .c_nro_factura = c_nro_factura
            .c_nro_boleta = c_nro_boleta
            .c_nro_nd = c_nro_nd
            .c_imp_doc = Format(Val(Dgv04.Rows(Fila).Cells("Importe").Value), Forma_1_2)
            .c_cant_detracc = Format(Val(Dgv04.Rows(Fila).Cells("c_Cant_detracc").Value), Forma_1_2)
            .c_nro_letra = TxtNro_Letra.Text
            .c_renov_letra = 0
            .c_opc_apertura = Val(Dgv04.Rows(Fila).Cells("c_opc_apertura").Value)
            .copcion = cOpcion
            'MsgBox(Val(Dgv04.Rows(Fila).Cells("Importe").Value) & " Cantidad de Detracciones " & Val(Dgv04.Rows(Fila).Cells("c_cant_detracc").Value))
            c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para grabar la cabecera de la letra '
    Private Sub Eliminar_Letras_Cab(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_LetCab
            .c_nro_liq = TxtNro_Liq.Text
            .c_año_liq = Val(TxtAño.Text)
            .c_sist_bahia = Val(TxtSist_Bahia.Text)
            .c_nro_letra = Dgv03.Rows(Fila).Cells("Letra").Value
            .c_renov_letra = Val(Dgv03.Rows(Fila).Cells("R").Value)
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_mon = TxtCod_Mon.Text
            .c_codi_stletra = "" : .c_valor_letra = "" : .c_nro_dias = Val(TxtDias.Text)
            .c_fecha_giro = DtpFec_Giro.Text : .c_fecha_venci = DtpFec_Venci.Text
            .c_fecha_presenta = DtpFec_Presenta.Text : .c_codi_bco = TxtCod_Bco.Text
            .c_motivo_anula = "" : .c_cancel_letra = 0 : .c_imp_letra = 0
            .c_fiador_letra = TxtFiador.Text : .c_aval_letra = TxtAval.Text : .c_direcc_letra = TxtDir_Fiador.Text
            .c_dni_letra = TxtDni.Text : .c_telf_letra = TxtFono_Fiador.Text : .c_rep_letra = TxtNom_Rep.Text
            .c_num_unico = TxtNro_Unico.Text : .c_nro_cuenta = TxtNro_Cuenta.Text : .c_sector_bco = TxtSectorista.Text
            .c_imp_pago = 0
            .c_porc_pago = TxtTea.Text
            .c_fecha_cancel = DtpFec_Abono.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Inicio de Documentos '
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Letras(" AND c_nro_letra= (select min(c_nro_letra) from sca_" & FrmMenu.TxtCod_Emp.Text & "_letcab) ")
    End Sub

    Private Sub CboBco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboBco.KeyDown

    End Sub
    ' Jalamos codigo de bancos '
    Private Sub CboBco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBco.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboBco, TxtCod_Bco)
    End Sub
    ' Historial de Cancelacion '
    Private Sub LblHistorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and A.c_nro_doc='" & TxtNro_Letra.Text & "' AND A.c_serie_doc='" & Val(TxtRenov.Text) & "' ", "LET")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub
    ' nos vamos hacia atras '
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 0 Then
            If Val(TxtBus.Text) > 1 Then
                TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 1000000, 6) : TxtBus_Nro.Text = 0
                Call Mostrar_Letras(" And L.c_nro_letra='" & TxtBus.Text & "' ")
            End If
        End If
    End Sub
    ' Avanzamos hacia adelante '
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) + 1) + 1000000, 6)
            Call Mostrar_Letras(" And L.c_nro_letra='" & TxtBus.Text & "' ") : TxtBus_Nro.Text = 0
        End If
    End Sub
    ' Mostramos el tipo de cambio para la fecha '
    Private Sub DtpFec_Giro4_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtpFec_Giro4.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Giro4.Text, TxtTc2)
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        If Val(TxtNro_Letra.Text) > 0 Then
            Dim Mon As String = ""
            If TxtMon.Text = "$." Then
                Mon = "US"
            Else
                Mon = "S/"
            End If
            Dim Fact_01 As String = "" : Dim Fact_02 As String = "" : Dim Fact_03 As String = ""
            Dim Fact_04 As String = "" : Dim Fact_05 As String = "" : Dim Fact_06 As String = ""
            With Dgv04
                For i = 0 To .RowCount - 1
                    If i = 0 Then Fact_01 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                    If i = 1 Then Fact_02 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                    If i = 2 Then Fact_03 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                    If i = 3 Then Fact_04 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                    If i = 4 Then Fact_05 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                    If i = 5 Then Fact_06 = Strings.Right(.Rows(i).Cells("Nro. Documento").Value, 5)
                Next

            End With
            FrmReportes.Impresion_Letras(TxtNro_Letra.Text, Val(TxtRenov.Text), Mon, TxtDireccion.Text, LblLetras.Text, Fact_01, Fact_02, Fact_03, Fact_04, Fact_05, Fact_06)
        End If
    End Sub
    ' Calculamos dias '
    Private Sub TxtDias_Let_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDias_Let.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpFec_Venci.Text = DateAdd("d", Val(TxtDias_Let.Text), DtpFec_Giro.Text)
        End If
    End Sub

    Private Sub TxtDias_Let_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDias_Let.TextChanged

    End Sub

    Private Sub Dgv03_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv03.CellContentClick

    End Sub

    Private Sub Dgv03_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv03.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv03)
    End Sub
End Class