Public Class FrmApertura
    Dim edit As Integer = 0 : Dim Focos As Integer = 0
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : DtpFec_Emi.Text = Now.Date : BtnCon1_Click(Nothing, Nothing) : edit = 0
        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Red : Call Activar(Grb01)
    End Sub
    'metodo para iniciar nuevo registro
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan07) : Pan04.Enabled = False : BtnGrabar.Enabled = True
        BtnCerrar.Text = "&Cancelar" : TxtImp_Doc.Enabled = True : TxtNro_Serie.Enabled = True : TxtNro_Doc.Enabled = True
        DtpFec_Emi.Enabled = True : BtnCon1.Enabled = True : Pan01.Enabled = False : CboMon.Enabled = True : CboTpoDoc.Enabled = True
    End Sub
    ' metodo para cancelar registro '
    Private Sub Cancelar_Registro()
        Call Desactivar(Pan02) : BtnCon1.Enabled = False : DtpFec_Emi.Enabled = False : BtnGrabar.Enabled = False
        BtnCerrar.Text = "&Cerrar" : Pan01.Enabled = True : Pan04.Enabled = True : Call Limpiar_Texto(Pan02)
        Call Desactivar(Grb01)
    End Sub
    Private Function ValidarDatos() As Boolean
        If Len(TxtNro_Serie.Text) > 0 Then
            If Len(TxtNro_Doc.Text) > 0 Then
                If Len(TxtCod_Clie.Text) > 0 Then
                    If CboMon.SelectedIndex > -1 Then
                        If CboTpoDoc.SelectedIndex > -1 Then
                            ValidarDatos = True
                        Else
                            MsgBox("1. Falta seleccionar el tipo de documento...", vbCritical, Compañia)
                            ValidarDatos = False
                        End If
                    Else
                        MsgBox("2. Falta seleccionar la moneda...", vbCritical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("3. Falta seleccionar el cliente...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("4. Falta ingresar la serie del documento...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("5. Falta ingresar el número de documento...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    ' funcion para validar si el documento ya fue grabado anteriormente '
    Private Function ValidarDoc() As Boolean
        If edit = 0 Then
            With c_Neg_Apertura.get_Apertura_Datos(" and A.c_nro_serie='" & TxtNro_Serie.Text & "' and A.c_nro_doc='" & TxtNro_Doc.Text & "' and A.c_codi_clie='" & _
                                                   TxtCod_Clie.Text & "' and A.c_codi_doc='" & CboTpoDoc.SelectedValue & "' and A.c_anula_reg=0 ", "DAT")
                If .Rows.Count > 0 Then
                    MsgBox("Documento ya fue registrado anteriormente...", vbCritical, Compañia)
                    ValidarDoc = False
                Else
                    ValidarDoc = True
                End If
            End With
        Else
            With c_Neg_Apertura.get_Apertura_Datos(" and A.c_nro_serie='" & TxtNro_Serie.Text & "' and A.c_nro_doc='" & TxtNro_Doc.Text & "' and A.c_codi_clie='" & _
                                                   TxtCod_Clie.Text & "' and A.c_codi_doc='" & CboTpoDoc.SelectedValue & "' and A.c_anula_reg=0 and A.c_nro_apertura='" & TxtNro_Apertura.Text & "'", "DAT")
                If .Rows.Count = 1 Then
                    ValidarDoc = True
                Else
                    ValidarDoc = False
                    MsgBox("Documento no puede ser registrado...", vbCritical, Compañia)
                End If
            End With
        End If
    End Function
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDoc() = True Then
            If ValidarDatos() = True Then
                Dim F As String = MsgBox("¿Desea Grabar el Registro?", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    If edit = 3 Then
                        Call Grabar_Registro("LET")
                    Else
                        Call Grabar_Registro("ADD")
                    End If
                    Call BtnCerrar_Click(Nothing, Nothing)
                End If
            End If
        End If
    End Sub
    ' Metodo para grabar registro '
    Private Sub Grabar_Registro(ByVal cOpcion As String)
        With c_Ent_Apertura
            Dim StLetra As Integer = 0 : Dim c_opc_reten As Integer = 0
            If ChkStatus.Checked = True Then StLetra = 1
            If ChkRetencion.Checked = True Then c_opc_reten = 1
            .c_nro_apertura = TxtNro_Apertura.Text
            .c_codi_doc = CboTpoDoc.SelectedValue
            .c_codi_clie = TxtCod_Clie.Text
            .c_nro_serie = TxtNro_Serie.Text
            .c_nro_doc = TxtNro_Doc.Text
            .c_codi_clie = TxtCod_Clie.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_imp_doc = Val(TxtImp_Doc.Text)
            If Len(CboBco.Text) = 0 Then
                .c_codi_bco = ""
            Else
                .c_codi_bco = CboBco.SelectedValue
            End If
            ' status de letras '
            If Len(CboStatus.Text) = 0 Then
                .c_codi_stletra = ""
            Else
                .c_codi_stletra = CboStatus.SelectedValue
            End If
            .c_pagado_clie = StLetra
            .c_opc_reten = c_opc_reten
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Val(TxtNro_Apertura.Text) > 0 Then
                c_Neg_Apertura.set_Apertura_Save(c_Ent_Apertura)
            Else
                TxtNro_Apertura.Text = c_Neg_Apertura.set_Apertura_Save(c_Ent_Apertura)
            End If
        End With
    End Sub

    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConClientes.Show() : FrmConClientes.MdiParent = FrmMenu
        FrmConClientes.TxtVar.Text = 9 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub

    Private Sub FrmApertura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If Pan04.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If Pan04.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)

    End Sub

    Private Sub FrmApertura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmApertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_Desc_doc", CboTpoDoc)
        c_Neg_MnMonedas.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_desc_mon", CboMon)
        c_Neg_MnBcos.Get_Bcos_Cbo(" and B.c_anula_reg=0 order by c_desc_bco", CboBco)
        c_Neg_StatusLetra.Get_StatusLetra_Cbo("  order by c_desc_stletra", CboStatus)
        Call BtnFin_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Len(TxtNro_Apertura.Text) > 0 Then
                Call Mostrar_Apertura(" and c_nro_apertura='" & TxtNro_Apertura.Text & "'")
            Else
                Call BtnFin_Click(Nothing, Nothing)
            End If
            Focos = 1 : BtnNuevo.Focus()
        End If
    End Sub
    Public Sub Mostrar_Apertura(ByVal Cadena As String)
        With c_Neg_Apertura.get_Apertura_Datos(Cadena, "DAT")
            Call Cancelar_Registro()
            If .Rows.Count > 0 Then
                TxtBus_Lote.Text = .Rows(0)("c_nro_apertura").ToString
                TxtNro_Apertura.Text = .Rows(0)("c_nro_apertura").ToString
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtClie.Text = .Rows(0)("c_desc_clie").ToString
                CboTpoDoc.SelectedValue = .Rows(0)("c_codi_doc").ToString
                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                TxtNro_Serie.Text = .Rows(0)("c_nro_serie").ToString
                TxtNro_Doc.Text = .Rows(0)("c_nro_doc").ToString
                TxtImp_Doc.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                ' Validamos el estado del registro '
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_opc_cancel").ToString) = 0 Then
                        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
                    Else
                        If Val(.Rows(0)("c_opc_cancel").ToString) = 2 Then
                            BtnEstado.Text = "Amortizado" : BtnEstado.BackColor = Color.SteelBlue
                        Else
                            BtnEstado.Text = "Cancelado" : BtnEstado.BackColor = Color.Blue
                        End If
                    End If
                Else
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                End If
                ' mostramos datos de las letras '
                CboBco.SelectedValue = .Rows(0)("c_codi_bco").ToString
                CboStatus.SelectedValue = .Rows(0)("c_codi_stletra").ToString
                '--> pagado por cliente <--'
                If Val(.Rows(0)("c_pagado_clie").ToString) = 1 Then
                    ChkStatus.Checked = True
                Else
                    ChkStatus.Checked = False
                End If
            End If
        End With
    End Sub
    ' Iniciamos Registro '
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Apertura(" and c_nro_apertura= (select min(c_nro_apertura) from Sca_Apertura)")
    End Sub
    ' Nos vamos hacia el registro anterior '
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_Lote.Text) > 1 Then
            TxtBus_Lote.Text = Strings.Right((Val(TxtBus_Lote.Text) - 1) + 10000000, 7)
            Call Mostrar_Apertura(" and c_nro_apertura='" & TxtBus_Lote.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_Lote.Text) > 0 Then
            TxtBus_Lote.Text = Strings.Right(Val(TxtBus_Lote.Text) + 100000001, 7)
            Call Mostrar_Apertura(" and c_nro_apertura='" & TxtBus_Lote.Text & "'")
        End If
    End Sub
    ' Buscamos al presionar la tecla enter '
    Private Sub TxtBus_Lote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Lote.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Lote.Text) > 0 Then
                TxtBus_Lote.Text = Strings.Right(Val(TxtBus_Lote.Text) + 10000000, 7)
                Call Mostrar_Apertura(" and c_nro_apertura='" & TxtBus_Lote.Text & "'")
            End If
        End If
    End Sub
    ' mostramos datos
    Public Sub Mostrar_documentos(ByVal c_nro_ingreso As String)
        Call Mostrar_Apertura(" and c_nro_apertura='" & c_nro_ingreso & "'")
    End Sub
    ' Final de Comisiones '
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Apertura(" and c_nro_apertura= (select max(c_nro_apertura) from Sca_Apertura)")
    End Sub

    Private Sub TxtBus_Lote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Lote.TextChanged

    End Sub
    'editamos registro
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If BtnEstado.Text = "Pendiente" Then
            edit = 1 : DtpFec_Emi.Enabled = True : CboMon.Enabled = True : TxtImp_Doc.Enabled = True : BtnGrabar.Enabled = True
            BtnCerrar.Text = "&Cancelar" : Pan04.Enabled = False
        Else
            ' Validamos el tipo de documentos '
            If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
                If CboTpoDoc.SelectedValue = "05" Then
                    edit = 3 : DtpFec_Emi.Enabled = True : CboMon.Enabled = True : TxtImp_Doc.Enabled = True : BtnGrabar.Enabled = True
                    BtnCerrar.Text = "&Cancelar" : Pan04.Enabled = False : Call Desactivar(Pan02) : CboBco.Focus()
                    ChkStatus.Enabled = True : DtpFec_Emi.Enabled = False : Call Activar(Grb01)
                Else
                    MsgBox("Registro no puede ser editado...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    ' Eliminamos registro '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If BtnEstado.Text = "Pendiente" Then
            Dim F As String = MsgBox("¿Desea Eliminar el registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Registro("DEL") : BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
            End If
        Else
            MsgBox("Registro no puede ser eliminado...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtNro_Serie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Serie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CboTpoDoc.SelectedValue <> "05" Then
                TxtNro_Serie.Text = Strings.Right(Val(TxtNro_Serie.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtNro_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_Serie.TextChanged

    End Sub

    Private Sub TxtNro_Doc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Doc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CboTpoDoc.SelectedValue <> "05" Then
                TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
            End If
        End If
    End Sub

    Private Sub TxtNro_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub

    Private Sub BtnNuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnNuevo.Focus()
        End If
    End Sub

    Private Sub LnkHistorial_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            Dim vOpt As String = "" : Dim Cadena As String = ""
            If CboTpoDoc.SelectedValue = "01" Then
                vOpt = "FACT" : Cadena = " and P.c_Serie_doc='" & TxtNro_Serie.Text & "' and P.c_nro_factura='" & TxtNro_Doc.Text & "' AND P.c_opc_apertura=1 "
            End If
            If CboTpoDoc.SelectedValue = "02" Then
                vOpt = "BOL" : Cadena = " and P.c_Serie_doc='" & TxtNro_Serie.Text & "' and P.c_nro_boleta='" & TxtNro_Doc.Text & "' AND P.c_opc_apertura=1 "
            End If

            If CboTpoDoc.SelectedValue = "04" Then
                vOpt = "NOT" : Cadena = " and A.c_Serie_doc='" & TxtNro_Serie.Text & "' and A.c_nro_doc='" & TxtNro_Doc.Text & "' AND A.c_opc_apertura=1 "
            End If
            If CboTpoDoc.SelectedValue = "05" Then
                vOpt = "LET" : Cadena = " and A.c_Serie_doc='" & TxtNro_Serie.Text & "' and A.c_nro_doc='" & TxtNro_Doc.Text & "' AND A.c_opc_apertura=1 "
            End If
            FrmConHistoCancel.Cargar_Grid(Cadena, vOpt)
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoDocAnexos.MdiParent = FrmMenu : FrmConHistoDocAnexos.Show()
            Dim vOpt As String = "" : Dim Cadena As String = ""
            If CboTpoDoc.SelectedValue = "01" Then
                vOpt = "FACT" ': Cadena = " and P.c_Serie_doc='" & TxtNro_Serie.Text & "' and P.c_nro_factura='" & TxtNro_Doc.Text & "' AND P.c_opc_apertura=1 "
                Cadena = " and C.c_nro_factura='" & TxtNro_Doc.Text & "'  " ', " and C.c_nro_doc='" & TxtFactura.Text & "'  "
                FrmConHistoDocAnexos.Cargar_Grid(Cadena, "", vOpt)
            End If

        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub LnkListado_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListado.LinkClicked
        FrmConApertura.MdiParent = FrmMenu : FrmConApertura.Show() ':
    End Sub
End Class