Public Class FrmIngND
    Dim Swicht As Integer = 0 : Dim T As Integer = 0
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_NotaD(" and N.c_nro_serie='" & TxtBus_Serie.Text & "' and N.c_nro_nd=(select max(c_nro_nd) from sca_Fa_NotaD Where c_nro_serie='" & TxtBus_Serie.Text & "')")
    End Sub
    'mostramos los detalles de las nota de credito...
    Private Sub Mostrar_NotaD(ByVal Cadena As String)
        With c_Neg_NotaD.get_NotaD_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Cancela_Registro()
            If .Rows.Count > 0 Then
                'Mostramos si es igual
                'Validamos si esta afecto a detraccion...
                If Val(.Rows(0)("c_opc_detrac").ToString) = 1 Then
                    Rdb01.Checked = True
                Else
                    Rdb02.Checked = True
                End If
                CboSerie.SelectedValue = .Rows(0)("c_nro_serie").ToString
                TxtBus_ND.Text = .Rows(0)("c_nro_nd").ToString
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString : TxtDir.Text = .Rows(0)("c_direc_clie").ToString
                TxtClie.Text = .Rows(0)("c_desc_clie").ToString : TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString : LblLetras.Text = .Rows(0)("c_letras_nd").ToString
                TxtPor_Igv.Text = .Rows(0)("c_cant_igv").ToString
                TxtNro_ND.Text = .Rows(0)("c_nro_nd").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                    ChkRetencion.Checked = True
                Else
                    ChkRetencion.Checked = False
                End If
                'validamos si nota de credito se encuentra anulada
                Dim Cadena2 As String = "" 'Variable que nos permitira trabajar con los anulados...
                BtnEstado.Visible = True
                'Validamos si factura se encuentra anulada...
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then 'Validamos si factura esta cancelado
                    If Val(.Rows(0)("c_cancel_nd").ToString) = 1 Or Val(.Rows(0)("c_cancel_nd").ToString) = 3 Then
                        BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Drawing.Color.RoyalBlue
                    Else 'Validamos si factura se encuentra amortizado...
                        If Val(.Rows(0)("c_cancel_nd").ToString) = 2 Then
                            BtnEstado.Text = "AMORTIZADO" : BtnEstado.BackColor = Drawing.Color.SteelBlue
                        Else
                            BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon
                        End If
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                End If
                If .Rows(0)("c_codi_mon").ToString = "01" Then
                    CboMon.SelectedIndex = 0
                Else
                    CboMon.SelectedIndex = 1
                End If
                TxtIgv.Text = .Rows(0)("c_imp_igv").ToString
                TxtSub_Total.Text = .Rows(0)("c_imp_nd").ToString
                TxtTotal.Text = .Rows(0)("c_imp_total").ToString
                TxtObs.Text = .Rows(0)("c_motivo_nd").ToString
                TxtPorDet.Text = Val(.Rows(0)("c_detracc_porc").ToString)
                ' last data '
                TxtTpoMotivo.Text = .Rows(0)("c_tpo_motivo").ToString
                CboDoc.SelectedValue = .Rows(0)("c_codi_doc").ToString
                TxtSerieDoc.Text = .Rows(0)("c_serie_doc").ToString
                TxtNro_Doc.Text = .Rows(0)("c_nro_doc").ToString
                TxtFecha_Doc.Text = .Rows(0)("c_fecha_doc").ToString
                ' We validate if credit note is the exportation '
                If Val(.Rows(0)("c_opc_exporta").ToString) = 1 Then
                    ChkExportacion.Checked = True
                Else
                    ChkExportacion.Checked = False
                End If
                ' --> We validate if credit note not is affected <-- '
                If Val(.Rows(0)("c_opc_inaf").ToString) = 1 Then
                    ChkInafecto.Checked = True
                Else
                    ChkInafecto.Checked = False
                End If

            End If
        End With
    End Sub
    ' Cancelamos Registro '
    Private Sub Cancela_Registro()
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03)
        Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05)
        CboMon.Enabled = False : BtnGrabar.Enabled = False : BtnEditar.Enabled = True
        BtnNuevo.Enabled = True : Rdb01.Enabled = False : Rdb02.Enabled = False : TxtPorDet.Enabled = False
        BtnEliminar.Enabled = True : BtnCerrar.Text = "&Cerrar" : TxtObs.ReadOnly = True
        Pan04.Enabled = False : DtpFec_Emi.Enabled = False : TxtSub_Total.Enabled = False
        Pan06.Enabled = True : BtnCon1.Enabled = False : TxtClie.Enabled = False : BtnImprimir.Enabled = True
        BtnEstado.Visible = True : CboDoc.Enabled = False : TxtSerieDoc.Enabled = False : TxtNro_Doc.Enabled = False
        TxtTpoMotivo.Enabled = False : ChkInafecto.Enabled = False : ChkExportacion.Enabled = False
        CboDoc.SelectedIndex = -1 : TxtSerieDoc.Clear() : TxtNro_Doc.Clear() : TxtTpoMotivo.Clear() : ChkInafecto.Checked = False
        ChkExportacion.Checked = False : Pan08.Enabled = True
    End Sub
    'Teclas de función...
    Private Sub FrmIngND_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            'VALIDAMOS QUE NO SEA nota de debito hecha por SUNAT'
            If Strings.Left(CboSerie.Text, 1) <> "E" Then
                If IsNumeric(Strings.Left(CboSerie.Text, 1)) = False Then
                    Dim F As String = MsgBox("¿Desea volver a generar la Facturacion electronica?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_ND.Text, "04", "ADD")
                        If ValidarEnvio(CboSerie.Text, TxtNro_ND.Text, "04", 1) = True Then
                            MsgBox("Registro subio correctamente...", vbExclamation, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FrmIngND_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmIngND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='04' order by c_nro_serie ", CboSerie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" And c_anula_reg=0 order by c_codi_mon", CboMon)
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 and c_opc_electronico=1 order by c_codi_doc", CboDoc)
        TxtBus_Serie.Text = FrmMenu.TxtSerie_ND.Text : Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Pan08.Enabled = False
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan01)
        DtpFec_Emi.Text = Date.Now : CboMon.Enabled = True : BtnCon1.Enabled = True
        CboMon.SelectedIndex = -1 : CboMon.Focus() : CboMon.Select() : Call Nuevo_Registro()
        TxtObs.Clear() : CboSerie.Enabled = True
        BtnEstado.Visible = False : Swicht = 0 : TxtSub_Total.Enabled = True
        With c_Neg_MnSeriesDoc.get_Series_Datos(" And c_nro_serie='" & CboSerie.Text & "' and c_codi_doc='04'", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                TxtNro_ND.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
            End If
        End With
        BtnCon1.Focus() : ChkRetencion.Enabled = True : BtnEstado.Visible = False
        CboDoc.Enabled = True : TxtSerieDoc.Enabled = True : TxtNro_Doc.Enabled = True : TxtTpoMotivo.Enabled = True
        ChkInafecto.Enabled = True : ChkExportacion.Enabled = True : CboDoc.SelectedValue = ""
        TxtNro_Doc.Clear() : TxtSerieDoc.Clear() : TxtFecha_Doc.Clear() : TxtTpoMotivo.Clear()
        ChkInafecto.Checked = False : ChkExportacion.Checked = False : ChkRetencion.Checked = False
        Rdb01.Checked = False : Rdb02.Checked = True
    End Sub
    ' Nuevo Registro '
    Private Sub Nuevo_Registro()
        BtnGrabar.Enabled = True : BtnEditar.Enabled = False : BtnNuevo.Enabled = False : BtnEliminar.Enabled = False
        BtnImprimir.Enabled = False : BtnCerrar.Text = "&Cancelar" : TxtObs.Enabled = True : DtpFec_Emi.Enabled = False
        Pan04.Enabled = True : TxtObs.ReadOnly = False : Pan06.Enabled = False : BtnCon1.Enabled = True
        Rdb01.Enabled = True : Rdb02.Enabled = True : TxtPorDet.Enabled = False : Rdb02.Checked = True : BtnEstado.Visible = False
    End Sub

    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConClientes.MdiParent = FrmMenu : Me.Enabled = False
        FrmConClientes.Show()
        FrmConClientes.Cargar_Grid(" and c_anula_reg=0  order by c_desc_clie")
        FrmConClientes.TxtVar.Text = 7
    End Sub


    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged
        If Rdb01.Checked = True Then
            TxtPorDet.Text = 10 : TxtPorDet.Enabled = True
        End If
    End Sub

    Private Sub Rdb02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb02.CheckedChanged
        If Rdb02.Checked = True Then
            TxtPorDet.Text = 0 : TxtPorDet.Enabled = False
        End If
    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
        Call Mostrar_IGV(DtpFec_Emi.Text, TxtPor_Igv)
    End Sub
    ' Function for validate the data '
    Private Function ValidarDatos() As Boolean
        If Len(TxtNro_ND.Text) > 0 Then
            If Len(TxtCod_Clie.Text) > 0 Then
                If Len(TxtObs.Text) > 0 Then
                    If Val(TxtTC.Text) > 0 Then
                        If CboMon.SelectedIndex > -1 Then
                            If Len(TxtSerieDoc.Text) > 0 Then
                                If Len(TxtNro_Doc.Text) > 0 Then
                                    ValidarDatos = True
                                Else
                                    ValidarDatos = False
                                    MsgBox("6. Falta ingresar el numero de documento...  ", vbCritical, Compañia)
                                End If
                            Else
                                ValidarDatos = False
                                MsgBox("7. Falta ingresar la serie de documento...  ", vbCritical, Compañia)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("1. Falta seleccionar el tipo de moneda...  ", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("2. Falta el ingresar tipo de cambio...  ", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("3. Falta ingresar el motivo de la Nota de Débito...  ", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("4. Falta seleccionar el cliente...  ", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox(" 5. Debe seleccionar la Serie para la Nota de Débito", vbCritical, Compañia)
        End If
    End Function
    'Grabamos el registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarDatos() = True Then
                Dim f As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
                If f = vbYes Then
                    If Swicht = 0 Then
                        Call Grabar_ND("ADD")
                    Else
                        Call Grabar_ND("EDI")
                    End If
                    ' Validamos si esta activa la facturacion electronica '
                    If FrmMenu.ChkElectronico.Checked = True Then
                        If IsNumeric(Strings.Left(CboSerie.Text, 1)) = False Then
                            If Strings.Left(CboSerie.Text, 1) <> "E" Then
                                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_ND.Text, "04", "ADD")
                            End If
                        End If
                    Else
                        ' Call BtnImprimir_Click(Nothing, Nothing)
                    End If
                    Call BtnImprimir_Click(Nothing, Nothing)
                    Call BtnCerrar_Click(Nothing, Nothing)
                    Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_ND(ByVal cOpcion As String)
        With c_Ent_NotaD
            'Mostramos el codigo de la moneda para poder grabar...
            Dim Detrac As Decimal = 0 : Dim c_opc_detrac As Integer = 0
            Dim c_total_doc As Decimal = 0 : Dim c_opc_reten As Integer = 0
            If ChkRetencion.Checked = True Then c_opc_reten = 1
            ' Validamos tipo de detraccion '
            If Rdb01.Checked = True Then
                c_opc_detrac = 1
                Detrac = Format(Val(TxtTotal.Text) * (Val(TxtPorDet.Text) / 100))
            Else
                c_opc_detrac = 0 : Detrac = 0
            End If
            .c_nro_serie = CboSerie.Text
            .c_nro_nd = TxtNro_ND.Text
            .c_codi_clie = TxtCod_Clie.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_codi_mon = CboMon.SelectedValue
            .c_cant_igv = Val(TxtPor_Igv.Text)
            .c_motivo_nd = TxtObs.Text
            .c_imp_nd = Val(TxtSub_Total.Text)
            .c_imp_igv = Val(TxtIgv.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .c_opc_detrac = c_opc_detrac
            .c_opc_reten = c_opc_reten
            .c_detracc_nd = Detrac
            .c_detracc_por = Val(TxtPorDet.Text)
            .c_letras_nd = LblLetras.Text
            .c_codi_doc = CboDoc.SelectedValue
            .c_serie_doc = TxtSerieDoc.Text
            .c_nro_doc = TxtNro_Doc.Text
            .c_fecha_doc = TxtFecha_Doc.Text
            ' We validate if invoice is affected '
            If ChkInafecto.Checked = True Then
                .c_opc_inaf = 1
            Else
                .c_opc_inaf = 0
            End If
            ' We validate if invoice is of exportation '
            If ChkExportacion.Checked = True Then
                .c_opc_exporta = 1
            Else
                .c_opc_exporta = 0
            End If
            .c_tpo_motivo = TxtTpoMotivo.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_NotaD.set_NotaD_Save(c_Ent_NotaD, FrmMenu.TxtCod_Emp.Text)
            MsgBox("Los datos se grabaron correctamente...", MsgBoxStyle.Exclamation, Compañia)
        End With
    End Sub
    'Calculamos 
    Private Sub TxtSub_Total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSub_Total.TextChanged
        If TxtSub_Total.Enabled = True Then
            If ChkInafecto.Checked = True Then
                TxtIgv.Text = "0.00"
                TxtTotal.Text = Format(Val(TxtSub_Total.Text), Forma_1_2)
            Else
                TxtIgv.Text = Format(Val(TxtSub_Total.Text) * (Val(TxtPor_Igv.Text) / 100), Forma_1_2)
                TxtTotal.Text = Format(Val(TxtIgv.Text) + Val(TxtSub_Total.Text), Forma_1_2)
            End If
            'Validamos para la conversion de numeros a letras...
            If Val(TxtTotal.Text) > 0 Then
                If CboMon.Text = "$." Then
                    LblLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 DOLARES AMERICANOS", VbStrConv.Uppercase)
                Else
                    LblLetras.Text = StrConv(num2text(Mid(TxtTotal.Text, 1, Len(TxtTotal.Text) - 3)) & " Y " & Strings.Right(TxtTotal.Text, 2) & "/100 SOLES", VbStrConv.Uppercase)
                End If
            Else
                LblLetras.Text = ""
            End If
        End If
    End Sub
    ' Validamos Edoocopm '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarFactu("DEBITO", " and c_nro_serie='" & CboSerie.Text & "' and c_nro_nd='" & TxtNro_ND.Text & "' ") = True Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then 'Validamos que exista un registro activo
                    TxtClie.Enabled = False : BtnCon1.Enabled = False : TxtClie.Enabled = False
                    BtnCon1.Enabled = False : CboMon.Enabled = True : CboSerie.Enabled = False
                    Call Nuevo_Registro() : Swicht = 1 : TxtSub_Total.Enabled = False : ChkRetencion.Enabled = True
                    CboDoc.Enabled = False : TxtSerieDoc.Enabled = False : TxtNro_Doc.Enabled = False
                    TxtTpoMotivo.Enabled = False : ChkInafecto.Enabled = False : ChkExportacion.Enabled = False
                    Pan08.Enabled = False
                Else
                    MsgBox("Registro se encuentra anulado o esta Cancelado, no podra realizar ninguna modificación", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        End If
    End Sub
    'cerramos o cancelamos registro de nota de credito...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            ChkRetencion.Enabled = False
            If Swicht > 0 Then
                Call Mostrar_NotaD(" and c_nro_nd='" & TxtNro_ND.Text & "' and c_nro_serie='" & CboSerie.Text & "'")
                ' Call BtnFin_Click(Nothing, Nothing)
            Else
                Call BtnFin_Click(Nothing, Nothing)
            End If
            Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        End If
    End Sub

    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        If CboSerie.Enabled = True Then
            With c_Neg_MnSeriesDoc.get_Series_Datos(" and c_anula_reg=0 and c_codi_doc='04' and c_nro_serie='" & CboSerie.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                TxtNro_ND.Clear()
                If .Rows.Count > 0 Then TxtNro_ND.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
                TxtBus_ND.Text = TxtNro_ND.Text
            End With
        End If
    End Sub
    ' Eliminamos Desplazados '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarFactu("DEBITO", " and c_nro_serie='" & CboSerie.Text & "' and c_nro_nd='" & TxtNro_ND.Text & "' ") = True Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        Call Grabar_ND("DEL") : BtnEstado.Visible = True : BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                        ' Validamos si esta activa la facturacion electronica '
                        If FrmMenu.ChkElectronico.Checked = True Then
                            c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtNro_ND.Text, "04", "DEL")
                        End If
                    End If
                Else
                    MsgBox("Registro ya fue cancelado o se encuentra eliminado, no podra realizar esta operación", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        End If
    End Sub
    'Consultamos clientes al presionar la tecla F1...
    Private Sub TxtClie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClie.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
    End Sub


    Private Sub TxtClie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClie.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TxtHora.Text = Date.Now.ToLongTimeString
        If T = 10 Then
            '  T = 0 : BtnDoc.ForeColor = Color.Maroon
        Else
            ' T = T + 1 : BtnDoc.ForeColor = Color.White
        End If
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_NotaD(" and N.c_nro_nd=(select min(c_nro_nd) from Sca_Fa_notaD where c_nro_serie='" & TxtBus_Serie.Text & "')  and c_nro_serie='" & TxtBus_Serie.Text & "'")
    End Sub

    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_ND.Text) > 1 Then
            TxtBus_ND.Text = Strings.Right((Val(TxtBus_ND.Text) - 1) + 10000000, 7)
            Call Mostrar_NotaD(" and c_nro_nd='" & TxtBus_ND.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")

        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_ND.Text) > 0 Then
            TxtBus_ND.Text = Strings.Right(Val(TxtBus_ND.Text) + 10000001, 7)
            Call Mostrar_NotaD(" and c_nro_nd='" & TxtBus_ND.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")
        End If
    End Sub

    Private Sub TxtBus_ND_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_ND.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_ND.Text) > 0 Then
                TxtBus_ND.Text = Strings.Right(Val(TxtBus_ND.Text) + 10000000, 7)
                Call Mostrar_NotaD(" and c_nro_nd='" & TxtBus_ND.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")
            End If
        End If
    End Sub
    Public Sub Mostrar_NotaD()
        Call Mostrar_NotaD(" and c_nro_nd='" & TxtBus_ND.Text & "' and c_nro_serie='" & TxtBus_Serie.Text & "'")
    End Sub
    Private Sub TxtBus_ND_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_ND.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmConNotaD.MdiParent = FrmMenu : FrmConNotaD.Show() : FrmConNotaD.TxtVar.Text = 1
    End Sub
    'Impresión de Nota de Débito...
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If IsNumeric(Strings.Left(CboSerie.Text, 1)) = True Then
            FrmReportes.Impresion_NotaD(CboSerie.Text, TxtNro_ND.Text)
        Else
            If Strings.Left(CboSerie.Text, 1) <> "E" Then
                If ValidarEnvio(CboSerie.Text, TxtNro_ND.Text, "04", 0) = True Then
                    ' Call Abrir_Pdf("08-" & CboSerie.Text & "-0" & TxtNro_ND.Text &
                    '           "\" & FrmMenu.TxtRuc.Text & "-08-" & CboSerie.Text & "-0" & TxtNro_ND.Text & ".pdf")
                    Abrir_PDf_2(CboSerie.Text & "-0" & TxtNro_ND.Text, "08", DtpFec_Emi.Text)
                End If
            End If
        End If
    End Sub

    Private Sub TxtBus_Serie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Serie.KeyDown
        If Len(TxtBus_Serie.Text) > 0 Then
            If IsNumeric(TxtBus_Serie.Text) = True Then
                TxtBus_Serie.Text = Strings.Right(Val(TxtBus_Serie.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtBus_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Serie.TextChanged

    End Sub

    Private Sub LnkComision_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkComision.LinkClicked
        FrmConComisDet.MdiParent = FrmMenu : FrmConComisDet.Show() : FrmConComisDet.Cargar_Grid(" and D.c_Codi_doc='04' and D.c_serie_Doc='" & CboSerie.Text & "' and D.c_nro_doc='" &
                                                                                                TxtNro_ND.Text & "' order by C.c_fecha_crea ")
    End Sub

    Private Sub TxtSerieDoc_TextChanged(sender As Object, e As EventArgs) Handles TxtSerieDoc.TextChanged

    End Sub

    Private Sub TxtSerieDoc_LostFocus(sender As Object, e As EventArgs) Handles TxtSerieDoc.LostFocus
        If IsNumeric(TxtSerieDoc.Text) = True Then
            If Val(TxtSerieDoc.Text) > 0 Then
                TxtSerieDoc.Text = Strings.Right(Val(TxtSerieDoc.Text) + 1000, 3)
            End If
        End If
        TxtFecha_Doc.Clear() : TxtNro_Doc.Clear() ': TxtNro_Doc.Focus()
    End Sub

    Private Sub TxtSerieDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSerieDoc.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSerieDoc_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TxtNro_Doc_TextChanged(sender As Object, e As EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub

    Private Sub TxtNro_Doc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNro_Doc.KeyDown
        '  If e.KeyCode = Keys.Enter Then Call TxtNro_Doc_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub TxtNro_Doc_LostFocus(sender As Object, e As EventArgs) Handles TxtNro_Doc.LostFocus
        If IsNumeric(TxtNro_Doc.Text) = True Then
            TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
            Call ValidarDocumentos()
        End If
    End Sub
    ' Validar documento
    Private Sub ValidarDocumentos()
        ' Validamos Facturas '
        If CboDoc.SelectedValue = "01" Then
            With c_Neg_FactCab.get_FactCab_Datos(" and F.c_codi_clie='" & TxtCod_Clie.Text & "' and F.c_anula_reg=0 and F.c_nro_Serie='" & TxtSerieDoc.Text &
                                                 "' and F.c_nro_factura='" & TxtNro_Doc.Text & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    TxtSerieDoc.Text = .Rows(0)("c_nro_serie").ToString
                    TxtNro_Doc.Text = .Rows(0)("c_nro_factura").ToString
                    TxtFecha_Doc.Text = .Rows(0)("c_fecha_emi").ToString
                Else
                    MsgBox("No existe factura  revisar si esta anulado o pertenece a este cliente", vbCritical, Compañia)
                    TxtSerieDoc.Clear() : TxtNro_Doc.Clear() : TxtFecha_Doc.Clear()
                End If
            End With
        End If
        ' Validamos boletas '
        If CboDoc.SelectedValue = "02" Then
            With c_Neg_BolCab.get_BolCab_Datos(" and B.c_codi_clie='" & TxtCod_Clie.Text & "' and B.c_anula_reg=0 and B.c_nro_Serie='" & TxtSerieDoc.Text &
                                                 "' and B.c_nro_boleta='" & TxtNro_Doc.Text & "' ", "DAT", " and B.c_codi_clie='" & TxtCod_Clie.Text & "' and B.c_anula_reg=0 and B.c_nro_Serie='" & TxtSerieDoc.Text &
                                                 "' and B.c_nro_boleta='" & TxtNro_Doc.Text & "' ")
                If .Rows.Count > 0 Then
                    TxtSerieDoc.Text = .Rows(0)("c_nro_serie").ToString
                    TxtNro_Doc.Text = .Rows(0)("c_nro_boleta").ToString
                    TxtFecha_Doc.Text = .Rows(0)("c_fecha_emi").ToString
                Else
                    MsgBox("No existe factura  revisar si esta anulado o pertenece a este cliente", vbCritical, Compañia)
                    TxtSerieDoc.Clear() : TxtNro_Doc.Clear() : TxtFecha_Doc.Clear()
                End If
            End With
        End If
    End Sub

    Private Sub CboDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDoc.SelectedIndexChanged
        If CboDoc.Enabled = True Then
            If Strings.Left(CboDoc.Text, 1) = "F" Then CboSerie.SelectedValue = "FD01"
            If Strings.Left(CboDoc.Text, 1) = "B" Then CboSerie.SelectedValue = "BD01"
            TxtFecha_Doc.Clear() : TxtSerieDoc.Clear() : TxtNro_Doc.Clear()
        End If
    End Sub

    Private Sub CboMon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMon.SelectedIndexChanged

    End Sub

    Private Sub Rdb02_KeyDown(sender As Object, e As KeyEventArgs) Handles Rdb02.KeyDown

    End Sub
    ' Calculamos los totales 
    Private Sub ChkInafecto_CheckedChanged(sender As Object, e As EventArgs) Handles ChkInafecto.CheckedChanged
        If ChkInafecto.Enabled = True Then
            Call TxtSub_Total_TextChanged(Nothing, Nothing)
        End If
    End Sub
End Class