Imports Capa_Negocios

Public Class FrmContraseña

    Dim x As Integer = 0

    Private NegConexion As New Neg_Conexion

    '===============================================================
    ' TECLADO
    '===============================================================
    Private Sub FrmContraseña_KeyDown(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyEventArgs
    ) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then End

    End Sub


    Private Sub FrmContraseña_KeyPress(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs
    ) Handles Me.KeyPress

        Call Avanzar_Enter(e)

    End Sub


    '===============================================================
    ' CARGAR FORMULARIO
    '===============================================================
    Private Sub FrmContraseña_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CargarTipoConexion()

        CargarGiros(CboGiro)

        If CboGiro.Items.Count > 0 Then CboGiro.SelectedIndex = 0

    End Sub

    '===============================================================
    ' CARGAR TIPO DE CONEXIÓN
    '===============================================================
    Private Sub CargarTipoConexion()

        Try

            CboTipoConexion.Items.Clear()

            CboTipoConexion.Items.Add("LOCAL")
            CboTipoConexion.Items.Add("REMOTO")

            Dim tipoActual As String =
            NegConexion.GetTipoConexion()

            If tipoActual = "LOCAL" OrElse
           tipoActual = "REMOTO" Then

                CboTipoConexion.SelectedItem = tipoActual

            Else

                CboTipoConexion.SelectedIndex = 0

            End If

        Catch ex As Exception

            MsgBox(
            "Error al cargar el tipo de conexión: " &
            ex.Message,
            vbCritical,
            Compañia)

        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    '===============================================================
    ' LOGIN
    '===============================================================
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Try

            '-------------------------------------------------------
            '1. Validar tipo de conexión
            '-------------------------------------------------------
            If CboTipoConexion.SelectedIndex = -1 Then

                MsgBox(
                "Debe seleccionar el tipo de conexión.",
                vbExclamation,
                Compañia)

                CboTipoConexion.Focus()
                Exit Sub

            End If


            '-------------------------------------------------------
            '2. Guardar LOCAL / REMOTO
            '-------------------------------------------------------
            NegConexion.GuardarTipoConexion(
            CboTipoConexion.Text)


            '-------------------------------------------------------
            '3. Probar conexión
            '-------------------------------------------------------
            Dim mensajeConexion As String = ""

            If Not NegConexion.ProbarConexion(mensajeConexion) Then

                Dim tipo As String =
                NegConexion.GetTipoConexion()

                If tipo = "LOCAL" Then

                    MsgBox(
                    "No fue posible conectarse al servidor LOCAL." &
                    vbCrLf & vbCrLf &
                    "Si se encuentra fuera de la oficina, " &
                    "seleccione REMOTO (Internet)." &
                    vbCrLf & vbCrLf &
                    "Detalle técnico:" &
                    vbCrLf &
                    mensajeConexion,
                    vbExclamation,
                    Compañia)

                Else

                    MsgBox(
                    "No fue posible conectarse al servidor REMOTO." &
                    vbCrLf & vbCrLf &
                    "Verifique su conexión a Internet." &
                    vbCrLf & vbCrLf &
                    "Detalle técnico:" &
                    vbCrLf &
                    mensajeConexion,
                    vbExclamation,
                    Compañia)

                End If

                Exit Sub

            End If

            '-------------------------------------------------------
            '5. Validar giro
            '-------------------------------------------------------
            If CboGiro.SelectedIndex = -1 Then

                MsgBox("Debe seleccionar el giro de negocio.", vbExclamation, Compañia)
                CboGiro.Focus()
                Exit Sub

            End If


            '-------------------------------------------------------
            '6. Validar usuario
            '-------------------------------------------------------
            Dim dtUsuario As DataTable =
            c_Neg_Usuario.get_Usuario_Datos(
                " and c_anula_reg=0 " &
                " and c_codi_usua='" & TxtUser.Text & "'" &
                " and c_clave_usua='" & TxtClave.Text & "'",
                "DAT")


            With dtUsuario

                If .Rows.Count > 0 Then

                    '-----------------------------------------------
                    'Usuario correcto
                    '-----------------------------------------------
                    UsuarioActual =
                    .Rows(0)("c_codi_usua").ToString()


                    FrmMenu.lblusuario.Text =
                    .Rows(0)("c_codi_usua").ToString()

                    FrmMenu.TxtSerie_Guia.Text =
                    .Rows(0)("c_serie_guia").ToString()

                    FrmMenu.TxtSerie_Fact.Text =
                    .Rows(0)("c_serie_fact").ToString()

                    FrmMenu.TxtSerie_Bol.Text =
                    .Rows(0)("c_serie_bol").ToString()

                    FrmMenu.TxtSerie_Nc.Text =
                    .Rows(0)("c_serie_nc").ToString()

                    FrmMenu.TxtSerie_ND.Text =
                    .Rows(0)("c_serie_nd").ToString()


                    '-----------------------------------------------
                    'Usuario administrador
                    '-----------------------------------------------
                    If Val(.Rows(0)("c_usua_admin").ToString()) = 1 Then
                        FrmMenu.ChkUsuaAdmin.Checked = True
                    Else
                        FrmMenu.ChkUsuaAdmin.Checked = False
                    End If


                    '-----------------------------------------------
                    'Usuario precio
                    '-----------------------------------------------
                    If Val(.Rows(0)("c_usua_precio").ToString()) = 1 Then
                        FrmMenu.ChkUsuaPrecio.Checked = True
                    Else
                        FrmMenu.ChkUsuaPrecio.Checked = False
                    End If


                    '-----------------------------------------------
                    'Empresa
                    '-----------------------------------------------
                    With c_Neg_MnEmpresa.get_Empresa_Datos(
                    " AND E.c_codi_emp='FA' ",
                    "DAT")

                        If .Rows.Count > 0 Then

                            FrmMenu.TxtRuta_Concar.Text =
                            .Rows(0)("c_ruta_concar").ToString()

                            FrmMenu.TxtEmpresa.Text =
                            .Rows(0)("c_raz_emp").ToString()

                            FrmMenu.TxtRuc.Text =
                            .Rows(0)("c_ruc_emp").ToString()

                        End If

                    End With

                    FrmMenu.TxtCod_Emp.Text = "FA"


                    '-----------------------------------------------
                    'Permisos
                    '-----------------------------------------------
                    FrmMenu.Dgv01.DataSource =
                    c_Neg_Usuario.get_UsuaPermiso_Datos(
                        " And P.c_codi_usua='" &
                        TxtUser.Text &
                        "' and P.c_anula_reg=0 " &
                        "and M.c_anula_reg=0",
                        "DAT")

                    FrmMenu.Validar_Menu()

                    Call Cargar_Archivo()


                    '-----------------------------------------------
                    'Mostrar sistema
                    '-----------------------------------------------
                    FrmMenu.Show()
                    Me.Hide()

                Else

                    x = x + 1

                    MsgBox(
                    "Usuario o Clave son incorrectos...",
                    MsgBoxStyle.Critical,
                    Compañia)

                    If x = 3 Then

                        MsgBox(
                        "Excedió el número de intentos...",
                        vbCritical,
                        Compañia)

                        End

                    End If

                End If

            End With


        Catch ex As Exception

            MsgBox(
            "No fue posible iniciar sesión." &
            vbCrLf & vbCrLf &
            ex.Message,
            vbCritical,
            Compañia)

        End Try

    End Sub

    '===============================================================
    ' CARGAR CONFIGURACIÓN
    '===============================================================
    Private Sub Cargar_Archivo()

        Try

            '-------------------------------------------------------
            'Tipo de conexión
            '-------------------------------------------------------
            Dim TipoConexion As String =
                NegConexion.GetTipoConexion()


            '-------------------------------------------------------
            'Determinar servidor
            '-------------------------------------------------------
            Dim Servidor As String

            If TipoConexion = "LOCAL" Then

                Servidor =
                    NegConexion.LeerConfiguracion("ServidorLocal")

            Else

                Servidor =
                    NegConexion.LeerConfiguracion("ServidorRemoto")

            End If


            '-------------------------------------------------------
            'Base de datos
            '-------------------------------------------------------
            Dim DbProcesos As String =
                NegConexion.LeerConfiguracion("DbProcesos")


            '-------------------------------------------------------
            'Servidor de reportes
            '-------------------------------------------------------
            Dim Servidor_Reportes As String

            If TipoConexion = "LOCAL" Then

                Servidor_Reportes =
                    NegConexion.LeerConfiguracion("ReportesLocal")

            Else

                Servidor_Reportes =
                    NegConexion.LeerConfiguracion("ReportesRemoto")

            End If


            '-------------------------------------------------------
            'Otras configuraciones
            '-------------------------------------------------------
            Dim Carpeta_Reporte As String =
                NegConexion.LeerConfiguracion("Carpeta.Reporte")

            Dim Zoom As String =
                NegConexion.LeerConfiguracion("Zoom")

            Dim Factura_Electronica As String =
                NegConexion.LeerConfiguracion(
                    "Facturas.Electronico")

            Dim Ruta_PDF As String =
                NegConexion.LeerConfiguracion("Ruta.PDF")


            '-------------------------------------------------------
            'Configuración del menú
            '-------------------------------------------------------
            FrmMenu.LblRutaReport.Text =
                Servidor_Reportes

            FrmMenu.TxtRptCarpeta.Text =
                Carpeta_Reporte

            FrmMenu.TxtZoom.Text =
                Zoom

            FrmMenu.TxtRuta_Pdf.Text =
                Ruta_PDF

            '-------------------------------------------------------
            'Título del ERP
            '-------------------------------------------------------
            FrmMenu.Text =
                "Sistema Administrativo de Ventas 3.0 - [" &
                TipoConexion &
                " - \\" &
                Servidor &
                "\" &
                DbProcesos &
                "]"


            '-------------------------------------------------------
            'Factura electrónica
            '-------------------------------------------------------
            If UCase(Factura_Electronica) = "SI" Then

                FrmMenu.ChkElectronico.Checked = True

            Else

                FrmMenu.ChkElectronico.Checked = False

            End If


        Catch ex As Exception

            MsgBox(
                "Error al cargar la configuración." &
                vbCrLf & vbCrLf &
                ex.Message,
                vbCritical,
                Compañia)

        End Try

    End Sub

    Private Sub Opcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opcion.Click
        With c_Neg_Usuario.get_Usuario_Datos(" And c_anula_reg=0 and c_codi_usua='" & TxtUser.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Nueva_Clave()
            Else
                MsgBox("Usuario no existe...", vbCritical, Compañia)
            End If
        End With
    End Sub
    'Nueva Clave...
    Private Sub Nueva_Clave()
        Me.Size = New Size(480, 417)
        OK.Visible = False : Cancel.Visible = False : Opcion.Visible = False : LblCopy.Visible = False
        TxtUser.Enabled = False : TxtClave_Ant.Clear() : TxtClave_Nueva.Clear() : TxtClave_Confirma.Clear() : TxtClave_Ant.Focus()
    End Sub
    Private Sub Cancela_Clave()
        Me.Size = New Size(480, 247)
        OK.Visible = True : Cancel.Visible = True : LblCopy.Visible = True : Opcion.Visible = True
        TxtUser.Enabled = True : TxtUser.Focus()
    End Sub

    Private Sub Ok2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok2.Click
        With c_Neg_Usuario.get_Usuario_Datos(" And c_codi_usua='" & TxtUser.Text & "' and c_clave_usua='" & TxtClave_Ant.Text & "' and c_anula_reg=0", "DAT")
            If .Rows.Count > 0 Then
                If Len(TxtClave_Nueva.Text) > 0 Then
                    If UCase(TxtClave_Nueva.Text) = UCase(TxtClave_Confirma.Text) Then
                        Dim F As String = MsgBox("¿Esta UD. Seguro de querer cambiar la clave para su Usuario?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            Grabar_Usuario() : Call Cancela_Clave()
                        End If
                    Else
                        MsgBox("La nueva clave no coincide con la clave de confirmación", vbCritical, Compañia)
                    End If
                Else
                    MsgBox("Debe ingresar una clave valida...", vbCritical, Compañia)
                End If
            Else
                MsgBox("Contraseña anterior incorrecta...", vbCritical, Compañia)
            End If
        End With
    End Sub
    Private Sub Grabar_Usuario()
        With c_Ent_Usuario
            .c_codi_usua = TxtUser.Text
            .c_clave_usua = TxtClave_Nueva.Text
            .c_nom_usua = ""
            .c_nom_pc = ""
            .c_codi_area = ""
            .c_email_usua = ""
            .c_serie_bol = "" : .c_serie_fact = ""
            .c_serie_guia = ""
            .c_serie_nc = "" : .c_serie_nd = ""
            .c_codi_alm = ""
            .c_codi_vende = ""
            .c_fecha_activa = 0
            .c_obs = ""
            .c_usuario = TxtUser.Text
            .copcion = "CAM"
            c_Neg_Usuario.set_Usuario_Save(c_Ent_Usuario)
        End With
    End Sub
    'Cancelamos clave 
    Private Sub Cancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel2.Click
        Call Cancela_Clave()
    End Sub

    Private Sub TxtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then Call OK_Click(Nothing, Nothing)
    End Sub

    Private Sub CboGiro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboGiro.SelectedIndexChanged

        If CboGiro.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim item As ItemGiro =
        TryCast(CboGiro.SelectedItem, ItemGiro)

        If item Is Nothing Then
            Exit Sub
        End If

        'Guardar giro en la sesión
        ModSesion.IdGiro = item.IdGiro
        ModSesion.GiroActual = item.Descripcion

        'Determinar modo automáticamente
        If item.Modo = "MEDXPRESS" Then

            ModSesion.ModoMedXpress = True

        ElseIf item.Modo = "CLOROEXPRESS" Then

            ModSesion.ModoMedXpress = False

        Else

            ModSesion.ModoMedXpress = Nothing

        End If

    End Sub

End Class