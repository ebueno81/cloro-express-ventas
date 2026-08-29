Public Class FrmMnClientes
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If UCase(CboBusca.Text) = "RAZON SOCIAL" Then Call Cargar_Grid(" And c_desc_clie like '%" & TxtBus.Text.Replace("'", "''") & "%' order by c_desc_clie")
        If UCase(CboBusca.Text) = "R.U.C." Then Call Cargar_Grid(" And c_ruc_clie like '" & TxtBus.Text.Replace("'", "''") & "%' order by c_desc_clie")
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_MnCliente.get_Cliente_Datos(Cadena, "DG2")
            .Columns("Codigo").Width = 55
            .Columns("Cliente").Width = 220
            .Columns("Dni").Width = 60
            .Columns("Ruc").Width = 80
            .Columns("Direccion").Width = 260
            .Columns("Telefono").Width = 100
            .Columns("Celular").Width = 100
            .Columns("E-Mail").Width = 150

            .Columns("Ubigeo").Width = 55

            .Columns("Distrito").Width = 100
            .Columns("Ciudad").Width = 120
            .Columns("Pais").Width = 100
            .Columns("Observaciones").Width = 260
            'Coloreamos
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            'Alnieacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ruc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ubigeo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Visibles
            .Columns("c_anula_reg").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub
    ' Agregamos Nuevo Cliente '
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro()
        'Activamos registro
        Call Activar(Pan03)
        TxtAbrev.Focus() : BtnGrabar.Enabled = True
        Pan02.Enabled = False : Pan04.Enabled = False : TxtCod_Clie.Enabled = False : Rdb02.Checked = True
        Call Cargar_Grid_Servicios() : TxtDni.Enabled = True : ChkRetencion.Enabled = True
        Call Validar_Permiso(Me.Name, BtnAdd2, BtnEdit2, BtnDel2)
    End Sub
    Private Sub Nuevo_Registro()
        On Error Resume Next
        Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan05) : BtnAdd2.Enabled = True : BtnEdit2.Enabled = True : BtnDel2.Enabled = True
        Pan04.Enabled = True : CboVende.SelectedValue = "" : Rdb01.Checked = False : Rdb02.Checked = False : Dgv02.Rows.Clear()
    End Sub
    Private Sub Cancela_Registro()
        On Error Resume Next
        Tbc01.SelectedTab = Tab01
        Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan05)
        'Activamos registro
        Call Desactivar(Pan03) : Call Desactivar(Pan05)
        Dgv02.Rows.Clear() : TxtRuc.Focus() : BtnGrabar.Enabled = False
        Pan04.Enabled = False
    End Sub

    Private Sub FrmMnClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnAdd.Enabled = True Then Call BtnAdd_Click(Nothing, Nothing) 'Nuevo Registro
        If e.Control And e.KeyCode = Keys.E Then If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing) 'Editar Registro
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing) 'Grabar registro
        'Consultamos ruc en la pagina de la sunat
        If e.KeyCode = 112 Then
            Dim proceso As New System.Diagnostics.Process
            With proceso
                .StartInfo.FileName = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"
                .Start()
            End With
        End If
    End Sub
    'Avanzamos presionando la tecla enter...
    Private Sub FrmMnClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboBusca.SelectedIndex = 0
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVende)
        c_Neg_MnTpoPago.Get_Fpago_Cbo(" and c_anula_reg=0 order by c_desc_pago", CboFpago)
        c_Neg_MnArticulo.Get_Articulo_Cbo(" and A.c_anula_reg=0 order by c_desc_articulo", CboArticulo)
        Call Validar_Permiso(Me.Name, BtnAdd, BtnEdit, BtnDel)
        Call Validar_Permiso(Me.Name, BtnAdd2, BtnEdit2, BtnDel2)
        Call Cancelar_Detalles_2()
    End Sub
    ' metodo para validar precios de servicios '
    Private Sub Validar_Permisos_Precios()
        With FrmMenu.Dgv01
            For i = 0 To .RowCount - 1
                If UCase(.Rows(i).Cells("c_desc_formu").Value.ToString) = "PRECIOS DE SERVICIOS" Then
                    If Val(.Rows(i).Cells("c_add_obj").Value) = 0 Then BtnAdd2.Enabled = False
                    If Val(.Rows(i).Cells("c_edit_obj").Value) = 0 Then BtnEdit2.Enabled = False
                    If Val(.Rows(i).Cells("c_del_obj").Value) = 0 Then BtnDel2.Enabled = False
                    i = .RowCount
                End If
            Next
        End With
    End Sub
    ' Metodo para Validar Abrev Cliente '
    Private Sub Validar_Abrev_Cliente(ByVal x As TextBox, ByVal Abrev_clie As String)
        If Len(Abrev_clie) = 2 Then
            With c_Neg_MnCliente.get_Cliente_Datos(" And c_abrev_clie='" & Abrev_clie & "'", "DAT")
                If .Rows.Count > 0 Then
                    x.Text = 1
                Else
                    x.Text = 0
                End If
            End With
        End If
    End Sub
    ' Validar Ruc del Cliente '
    Private Function ValidarRuc() As Boolean
        If Len(TxtRuc.Text) > 0 Then
            With c_Neg_MnCliente.get_Cliente_Datos(" and c_ruc_clie='" & TxtRuc.Text & "' and c_anula_reg=0", "DAT")
                If .Rows.Count > 0 Then
                    If TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString Then
                        ValidarRuc = True
                    Else
                        ValidarRuc = False
                        MsgBox("R.U.C. ya fue ingresado anteriormente para el Cliente: " & .Rows(0)("c_codi_clie").ToString, vbExclamation, Compañia)
                    End If
                Else
                    ValidarRuc = True
                End If
            End With
        Else
            If Len(TxtDni.Text) > 0 Then
                ValidarRuc = True
            Else
                MsgBox("Esta ingresado un cliente sin Ruc y sin Dni, revisar...", vbCritical, Compañia)
                ValidarRuc = False
            End If
        End If
    End Function
    ' Function for validate data '
    Private Function ValidarDatos() As Boolean
        If CboFpago.SelectedIndex > -1 Then
            If Len(TxtRaz.Text) > 0 Then
                If CboVende.SelectedIndex > -1 Then
                    If Len(TxtCodUbigeo.Text) >= 5 Then
                        ValidarDatos = True
                    Else
                        ValidarDatos = True
                        MsgBox(" 1. Importante ingresar el codigo de Ubigeo Sunat...", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox(" 2. Debe Seleccionar el Vendedor...", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox(" 3. Falta ingresar la razon social...", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox(" 4. Falta seleccionar la fomra de pago...", vbCritical, Compañia)
        End If
    End Function
    '---Grabar Registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            If ValidarRuc() = True Then
                Dim F As String = MsgBox(" ¿Desea Grabar el Registro? ", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    If Len(TxtCod_Clie.Text) = 0 Then
                        Dim X As New TextBox
                        Call Validar_Abrev_Cliente(X, TxtAbrev.Text)
                        If Val(X.Text) = 0 Then
                            Call Grabar_Clientes("ADD") : Call BtnCerrar_Click(Nothing, Nothing)
                            BtnMostrar_Click(Nothing, Nothing)
                        Else
                            MsgBox(" Abreviatura de Cliente ya fue ingresada anteriormente...", vbCritical, Compañia)
                        End If
                    Else
                        Call Grabar_Clientes("EDI") : Call BtnCerrar_Click(Nothing, Nothing)
                        BtnMostrar_Click(Nothing, Nothing)
                    End If
                    Pan04.Enabled = True : Pan02.Enabled = True : BtnOficinas.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_Clientes(ByVal cOpcion As String)
        With c_Ent_Cliente
            Dim c_opc_reten As Integer = 0
            If ChkRetencion.Checked = True Then c_opc_reten = 1
            .c_codi_clie = TxtCod_Clie.Text
            .c_abrev_clie = TxtAbrev.Text
            .c_desc_clie = TxtRaz.Text
            .c_pais_clie = "PERU"
            .c_ciudad_clie = TxtCiu.Text
            .c_prov_clie = TxtProv.Text
            .c_dist_clie = TxtDis.Text
            .c_direc_clie = TxtDir.Text
            .c_ruc_clie = TxtRuc.Text
            .c_dni_clie = TxtDni.Text
            .c_telf_clie = TxtFono.Text
            .c_cel_clie = TxtCel.Text
            .c_contac_clie = TxtCon.Text
            .c_mail_clie = TxtMail.Text
            .c_web_clie = TxtWeb.Text
            .c_codi_vende = CboVende.SelectedValue
            ' Validamos el Tipo de Cliente '
            If Rdb01.Checked = True Then
                .c_tpo_clie = 0
            Else
                .c_tpo_clie = 1
            End If
            .c_opc_reten = c_opc_reten
            .c_codi_pago = CboFpago.SelectedValue
            .c_codi_ubigeo = TxtCodUbigeo.Text
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtCod_Clie.Text) = 0 Then
                TxtCod_Clie.Text = c_Neg_MnCliente.set_Cliente_Save(c_Ent_Cliente).ToString
            Else
                c_Neg_MnCliente.set_Cliente_Save(c_Ent_Cliente)
            End If
            MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Tbc01.SelectedTab = Tab01
        Call Cancela_Registro() : Call Validar_Permiso(Me.Name, BtnAdd, BtnEdit, BtnDel)
        Call Cancelar_Detalles() : BtnEstado.Visible = False
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Mostramos Proveedor...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    Tbc01.SelectedTab = Tab02 : CboVende.Enabled = False : Rdb01.Enabled = False : Rdb02.Enabled = False
                    Call Mostrar_Cliente(fila) : Pan02.Enabled = False : Pan04.Enabled = False : BtnGrabar.Enabled = False
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_Cliente(ByVal Fila As Integer)
        With c_Neg_MnCliente.get_Cliente_Datos(" and c_codi_clie='" & Dgv01.Rows(Fila).Cells("Codigo").Value & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Nuevo_Registro()
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtRaz.Text = .Rows(0)("c_desc_clie").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                TxtDni.Text = .Rows(0)("c_dni_clie").ToString
                TxtCon.Text = .Rows(0)("c_contac_clie").ToString
                TxtDis.Text = .Rows(0)("c_dist_clie").ToString
                TxtDir.Text = .Rows(0)("c_direc_clie").ToString
                TxtProv.Text = .Rows(0)("c_prov_clie").ToString
                TxtCiu.Text = .Rows(0)("c_ciudad_clie").ToString
                TxtFono.Text = .Rows(0)("c_telf_clie").ToString
                TxtCel.Text = .Rows(0)("c_cel_clie").ToString
                TxtWeb.Text = .Rows(0)("c_web_clie").ToString
                TxtMail.Text = .Rows(0)("c_mail_clie").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFec_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFec_Mod.Text = .Rows(0)("c_fecha_modi").ToString
                TxtAbrev.Text = .Rows(0)("c_abrev_clie").ToString
                CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                CboFpago.SelectedValue = .Rows(0)("c_codi_pago").ToString
                TxtCodUbigeo.Text = .Rows(0)("c_codi_ubigeo").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                'validamos si cliente es prueba on Fornal
                If Val(.Rows(0)("c_tpo_clie").ToString) = 0 Then
                    Rdb01.Checked = True
                Else
                    Rdb02.Checked = True
                End If
                'si es cliete retenedor
                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                    ChkRetencion.Checked = True
                Else
                    ChkRetencion.Checked = False
                End If

                'Seleccionamos el codigo de vendedor...
                CboVende.SelectedValue = .Rows(0)("c_codi_Vende").ToString
                Call Cargar_Grid_Servicios()
                'Validamos si cliente se encuentra activo...
                If Val(.Rows(0)("c_anula_Reg").ToString) = 1 Then
                    BtnEstado.Text = "INACTIVO" : BtnEstado.BackColor = Color.Red
                Else
                    BtnEstado.Text = "ACTIVO" : BtnEstado.BackColor = Color.Navy
                End If
                BtnEstado.Visible = True
            End If
        End With
    End Sub
    'Eliminamos registro...
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            Call Mostrar_Cliente(fila)
                            Call Grabar_Clientes("DEL")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If

        End With
    End Sub
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then
            BtnEstado.Visible = False
        End If
        If Tbc01.SelectedIndex = 1 Then
            BtnEstado.Visible = True : BtnGrabar.Enabled = False
            With Dgv01
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_Cliente(Fila)
                    End If
                End If
            End With
            If FrmMenu.ChkUsuaAdmin.Checked = True Then
                Pan12.Visible = True
            Else
                If FrmMenu.ChkUsuaPrecio.Checked = True Then
                    Pan12.Visible = True
                Else
                    Pan12.Visible = False
                End If
            End If
        End If
        ' Datos de Oficinas '
        If Tbc01.SelectedIndex = 2 Then
            BtnEstado.Visible = True
            With Dgv01
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_Cliente(Fila)
                        Call Cargar_Grid_Ofi(TxtCod_Clie.Text) : Pan17.Enabled = False : Pan18.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub TxtBus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        With Dgv01
            If .RowCount > 0 Then
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1 : x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True : x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then Call Dgv01_DoubleClick(Nothing, Nothing)
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro()
                        Call Activar(Pan03) : ChkRetencion.Enabled = True
                        TxtRuc.Focus() : BtnGrabar.Enabled = True : Pan04.Enabled = False
                        Call Tbc01_Click(Nothing, Nothing)
                        TxtCod_Clie.Enabled = False : TxtAbrev.Enabled = False : TxtDni.Enabled = True
                        Call Validar_Permiso(Me.Name, BtnAdd2, BtnEdit2, BtnDel2)
                        BtnGrabar.Enabled = True
                    Else
                        MsgBox("Registro se encuentra anulado, no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Validamos Ruc 2'
    Private Sub TxtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRuc.TextChanged
        If Strings.Left(TxtRuc.Text, 1) = "2" Then
            TxtDni.Enabled = False : TxtDni.Clear()
        Else
            TxtDni.Enabled = True
        End If
    End Sub

    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub

    Private Sub Dgv02_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv02)
    End Sub

    Private Sub BtnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd2.Click
        Call Nuevo_Detalles() : CboArticulo.Focus() : TxtCod_Serv.Enabled = False
    End Sub
    ' Metodo para agregar nuevo detalles '
    Private Sub Nuevo_Detalles()
        With Dgv02
            .Size = New Size(429, 171) : .Location = New Point(2, 50) : Call Limpiar_Texto(Pan01) : Pan01.Enabled = True
            Call Activar(Pan01) : Pan02.Enabled = True : Pan04.Enabled = False : CboArticulo.SelectedValue = ""
        End With
    End Sub
    ' Metodo para cancelar Detalles '
    Private Sub Cancelar_Detalles()
        With Dgv02
            .Size = New Size(429, 196) : .Location = New Point(2, 25) : Call Desactivar(Pan01) : Pan01.Enabled = False
            Pan02.Enabled = False : Pan04.Enabled = True
        End With
    End Sub
    ' Aceptamos Registro '
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Len(TxtCod_Serv.Text) > 0 Then
            Call Grabar_ClienteServ("ADD") : Call Cancelar_Detalles()
            Call Cargar_Grid_Servicios() : Call Validar_Permiso(Me.Name, BtnAdd2, BtnEdit2, BtnDel2)
        End If
    End Sub
    ' Metodo para Grabar Clientes por Servicios '
    Private Sub Grabar_ClienteServ(ByVal cOpcion As String)
        With c_Ent_MnClienteServ
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_articulo = TxtCod_Serv.Text
            .c_precio_srv_mn = Val(TxtPrecio_Mn.Text)
            .c_precio_srv_us = Val(TxtPrecio_Us.Text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnClienteArt.get_ClienteArt_Save(c_Ent_MnClienteServ)
        End With
    End Sub
    ' Metodo para cargar grid de servicios
    Private Sub Cargar_Grid_Servicios()
        ' Mostramos precios por servicios '
        With Dgv02
            .DataSource = c_Neg_MnClienteArt.get_ClienteArt_Datos(" And S.c_codi_clie='" & TxtCod_Clie.Text & "' order by Sv.c_desc_articulo", "DGV")
            .Columns("Codigo").Width = 60
            .Columns("Articulo").Width = 180
            .Columns("Precio(S/.)").Width = 70
            .Columns("Precio($.)").Width = 70
            ' Visible
            .Columns("c_anula_reg").Visible = False
            ' Alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Precio(S/.)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio($.)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Coloreamos Cabecera '
            ' .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            ' Coloreamos Grid '
            Call Grid_Registros_anulados(Dgv02)
        End With
    End Sub
    ' Editamos Registro '
    Private Sub BtnEdit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit2.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Nuevo_Detalles()
                    CboArticulo.SelectedValue = .Rows(Fila).Cells("Codigo").Value
                    TxtPrecio_Mn.Text = Format(Val(.Rows(Fila).Cells("Precio(S/.)").Value), Forma_1_7)
                    TxtPrecio_Us.Text = Format(Val(.Rows(Fila).Cells("Precio($.)").Value), Forma_1_7)
                    CboArticulo.Enabled = False : TxtPrecio_Mn.Focus()
                End If
            End If
        End With
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnDel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel2.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Dim F As String = MsgBox("¿Desea Eliminar el Precio x Servicio?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        TxtCod_Serv.Text = .Rows(Fila).Cells("Codigo").Value
                        Call Grabar_ClienteServ("DEL") : Call Cargar_Grid_Servicios()
                        MsgBox("Registro fue eliminado correctamente...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub

    Private Sub CboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboArticulo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.F4 Then Call CboServicio_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    ' convertimos a mayusculas '
    Private Sub CboServicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboArticulo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboArticulo.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboArticulo, TxtCod_Serv)
    End Sub
    ' Aceptamos precios y grabamos '
    Private Sub TxtPrecio_Us_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio_Us.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Serv.Text) > 0 Then
                Call BtnAceptar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub TxtPrecio_Us_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecio_Us.TextChanged

    End Sub
    ' Editamos Registro '
    Private Sub Dgv02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.DoubleClick
        If Pan04.Enabled = True Then Call BtnEdit2_Click(Nothing, Nothing)
    End Sub

    ' Cargamos registros por oficinas '
    Private Sub Cargar_Grid_Ofi(ByVal c_codi_clie As String)
        With Dgv03
            .DataSource = c_Neg_MnClienteOfi.get_ClienteOfi_Datos(" and c_codi_clie='" & c_codi_clie & "' order by c_codi_oficina", "DGV")
            .Columns("Codigo").Width = 50
            .Columns("Ubigeo").Width = 50
            .Columns("Direccion").Width = 140
            .Columns("Distrito").Width = 80
            .Columns("Provincia").Width = 80
            .Columns("Dpto.").Width = 70
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Seleccionamos registro '
    Private Sub Dgv03_SelectionChanged(sender As Object, e As System.EventArgs) Handles Dgv03.SelectionChanged
        With Dgv03
            Call Limpiar_Texto(Pan19)
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    TxtClieOfi.Text = TxtRaz.Text
                    TxtCodiOfi.Text = .Rows(Fila).Cells("Codigo").Value
                    TxtUbigeo2.Text = .Rows(Fila).Cells("Ubigeo").Value.ToString
                    TxtDireccOfi.Text = .Rows(Fila).Cells("Direccion").Value
                    TxtDistOfi.Text = .Rows(Fila).Cells("distrito").Value
                    TxtProvOfi.Text = .Rows(Fila).Cells("Provincia").Value
                    TxtDptoOfi.Text = .Rows(Fila).Cells("Dpto.").Value
                End If
            End If
        End With
    End Sub
    Private Sub BtnCancel3_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel3.Click
        Call Cancelar_Detalles_2()
    End Sub
    ' Cancelamos detalles '
    Private Sub Cancelar_Detalles_2()
        With Dgv03
            .Size = New Size(462, 120) : .Location = New Point(2, 25)
            Call Limpiar_Texto(Pan16) : Call Desactivar(Pan16) : Pan17.Enabled = True : Pan18.Enabled = False
            Dgv03.Enabled = True
        End With
    End Sub
    ' nuevo detalle '
    Private Sub BtnAdd3_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd3.Click
        Call Nuevo_Detalles_2() : TxtCod_Oficina.Enabled = False
    End Sub
    ' Nuevo Detalles '
    Private Sub Nuevo_Detalles_2()
        With Dgv03
            .Size = New Size(462, 70) : .Location = New Point(2, 75)
            Call Limpiar_Texto(Pan16) : Call Activar(Pan16) : TxtDirec_Ofi.Focus() : Pan18.Enabled = True : Pan17.Enabled = False
            Dgv03.Enabled = False
        End With
    End Sub
    ' Grabamos registro '
    Private Sub BtnAceptar3_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar3.Click
        If Len(TxtUbigeo.Text) >= 5 Then
            If Len(TxtDirec_Ofi.Text) > 0 And Len(TxtDis_Ofi.Text) > 0 Then
                Call Grabar_ClienteOfi("ADD") : Call Cancelar_Detalles_2() : Call Cargar_Grid_Ofi(TxtCod_Clie.Text)
            Else
                MsgBox("1. Falta ingresar la dirección de la oficina...", vbCritical, Compañia)
            End If
        Else
            MsgBox("2. Falta ingresar el ubigeo de la oficina...", vbCritical, Compañia)
        End If
    End Sub
    ' Metodo para grabar oficina '
    Private Sub Grabar_ClienteOfi(ByVal cOpcion As String)
        With c_Ent_MnClienteOfi
            .c_codi_oficina = TxtCod_Oficina.Text
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_ubigeo = TxtUbigeo.Text
            .c_direc_clie = TxtDirec_Ofi.Text
            .c_dist_clie = TxtDis_Ofi.Text
            .c_prov_clie = TxtProv_Ofi.Text
            .c_dpto_clie = TxtDpto_Ofi.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnClienteOfi.get_ClienteOfi_Save(c_Ent_MnClienteOfi)
        End With
    End Sub

    Private Sub BtnEdit3_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit3.Click
        With Dgv03
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Nuevo_Detalles_2() : TxtCod_Oficina.Enabled = False
                    TxtCod_Oficina.Text = .Rows(Fila).Cells("Codigo").Value
                    TxtDirec_Ofi.Text = .Rows(Fila).Cells("Direccion").Value
                    TxtDis_Ofi.Text = .Rows(Fila).Cells("Distrito").Value
                    TxtProv_Ofi.Text = .Rows(Fila).Cells("Provincia").Value
                    TxtDpto_Ofi.Text = .Rows(Fila).Cells("Dpto.").Value
                    TxtUbigeo.Text = .Rows(Fila).Cells("Ubigeo").Value
                End If
            End If
        End With
    End Sub
    ' Eliminamos registro '
    Private Sub BtnDel3_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel3.Click
        With Dgv03
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    TxtCod_Oficina.Text = .Rows(Fila).Cells("Codigo").Value
                    Dim F As String = MsgBox("¿Desea Eliminar la Oficina?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_ClienteOfi("DEL") : Call Cargar_Grid_Ofi(TxtCod_Clie.Text)
                    End If
                End If
            End If
        End With
    End Sub
    ' Oficinas '
    Private Sub BtnOficinas_Click(sender As System.Object, e As System.EventArgs) Handles BtnOficinas.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Tbc01.SelectedTab = Tab03
                    Call Mostrar_Cliente(Fila)
                    Call Cargar_Grid_Ofi(TxtCod_Clie.Text) : Pan17.Enabled = True : Pan18.Enabled = False
                    Dgv03_SelectionChanged(Nothing, Nothing)
                End If
            End If
        End With
    End Sub

    Private Sub Dgv03_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv03.CellContentClick

    End Sub
    ' Editamos registro de oficina '
    Private Sub Dgv03_DoubleClick(sender As Object, e As System.EventArgs) Handles Dgv03.DoubleClick
        If Pan17.Enabled = True Then
            Call BtnEdit3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnVolver_Click(sender As System.Object, e As System.EventArgs) Handles BtnVolver.Click
        Tbc01.SelectedTab = Tab02
    End Sub

    Private Sub Tab02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab02.Click

    End Sub
End Class