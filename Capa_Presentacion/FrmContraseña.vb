Imports System.IO
Public Class FrmContraseña
    Dim x As Integer = 0
    Private Sub FrmContraseña_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then End
    End Sub

    Private Sub FrmContraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmContraseña_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'c_Neg_MnEmpresa.Get_Empresa_Cbo(" And E.c_anula_reg=0 order by c_codi_emp", CboEmpresa)
        'If CboEmpresa.Items.Count > 0 Then CboEmpresa.SelectedIndex = 0
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'InputBox("", "", " and c_anula_reg=0 and c_codi_usua='" & TxtUser.Text & "' and c_clave_usua='" & TxtClave.Text & "'")
        With c_Neg_Usuario.get_Usuario_Datos(" and c_anula_reg=0 and c_codi_usua='" & TxtUser.Text & "' and c_clave_usua='" & TxtClave.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                FrmMenu.Show()
                FrmMenu.lblusuario.Text = .Rows(0)("c_codi_usua").ToString
                FrmMenu.TxtSerie_Guia.Text = .Rows(0)("c_serie_guia").ToString
                FrmMenu.TxtSerie_Fact.Text = .Rows(0)("c_serie_fact").ToString
                FrmMenu.TxtSerie_Bol.Text = .Rows(0)("c_serie_bol").ToString
                FrmMenu.TxtSerie_Nc.Text = .Rows(0)("c_serie_nc").ToString
                FrmMenu.TxtSerie_ND.Text = .Rows(0)("c_serie_nd").ToString
                ' Validamos el usuario admin '
                If Val(.Rows(0)("c_usua_admin").ToString) = 1 Then
                    FrmMenu.ChkUsuaAdmin.Checked = True
                Else
                    FrmMenu.ChkUsuaAdmin.Checked = False
                End If
                ' Validamos el usuario precio '
                If Val(.Rows(0)("c_usua_precio").ToString) = 1 Then
                    FrmMenu.ChkUsuaPrecio.Checked = True
                Else
                    FrmMenu.ChkUsuaPrecio.Checked = False
                End If


                Me.Hide()
                With c_Neg_MnEmpresa.get_Empresa_Datos(" AND E.c_codi_emp='FA' ", "DAT")
                    If .Rows.Count > 0 Then
                        FrmMenu.TxtRuta_Concar.Text = .Rows(0)("c_ruta_concar").ToString
                        FrmMenu.TxtEmpresa.Text = .Rows(0)("c_raz_emp").ToString
                        FrmMenu.TxtRuc.Text = .Rows(0)("c_ruc_emp").ToString
                    End If
                End With
                FrmMenu.TxtCod_Emp.Text = "FA"
                'Cargamos los permisos por usuarios para ver si el usuario puede grabar editar eliminar...
                FrmMenu.Dgv01.DataSource = c_Neg_Usuario.get_UsuaPermiso_Datos(" And P.c_codi_usua='" & TxtUser.Text & "' and P.c_anula_reg=0 and M.c_anula_reg=0", "DAT")
                FrmMenu.Validar_Menu()
                Call Cargar_Archivo() ': Call Cargar_Datos_BD()
            Else
                x = x + 1
                MsgBox("Usuario o Clave son incorrectos...", MsgBoxStyle.Critical, Compañia)
                If x = 3 Then
                    MsgBox("Excedio el número de intentos...", vbCritical, Compañia)
                    End
                End If
            End If
        End With
    End Sub
    Private Sub Cargar_Archivo()
        Dim fic As String = My.Application.Info.DirectoryPath & "\config.ini"
        Dim texto As String = ""
        Dim objReader As New StreamReader(fic)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        'Leemos Archivos
        Dim Servidor_Reportes As String = "" : Dim Carpeta_Reporte As String = "" : Dim Zoom As String = ""
        Dim Factura_Electronica As String = "" : Dim Ruta_PDF As String = ""
        Servidor_Reportes = Trim(Mid(arrText.Item(13).ToString, 10, 50))
        Carpeta_Reporte = Trim(Mid(arrText.Item(18).ToString, 13, 70))
        Zoom = Replace(arrText.Item(19).ToString, "Zoom=", "")
        Factura_Electronica = Replace(arrText.Item(22).ToString, "Facturas.Electronico=", "")
        Ruta_PDF = Replace(arrText.Item(23).ToString, "Ruta.PDF=", "")


        'Enviamos Ruta Para el servidor de Reportes...
        FrmMenu.LblRutaReport.Text = Servidor_Reportes
        FrmMenu.TxtRptCarpeta.Text = Carpeta_Reporte
        FrmMenu.TxtZoom.Text = Zoom
        FrmMenu.TxtRuta_Pdf.Text = Ruta_PDF

        'Enviamos la ruta de la base de datos...
        Dim Servidor, DbProcesos, Usuario, Password, Timeout, Provider As String


        Servidor = Trim(Mid(arrText.Item(7).ToString, 10, 30))
        DbProcesos = Trim(Mid(arrText.Item(8).ToString, 12, 30))
        Usuario = Trim(Mid(arrText.Item(9).ToString, 9, 30))
        Password = Trim(Mid(arrText.Item(10).ToString, 10, 30))
        Timeout = Trim(Mid(arrText.Item(11).ToString, 9, 30))
        Provider = Trim(Mid(arrText.Item(12).ToString, 10, 30))

        Dim Conex As String = "Data Source=" & Servidor & ";Initial Catalog=" & DbProcesos & ";User Id=" & fEncripta_Key(Usuario, False).ToString & _
        ";Password=" & fEncripta_Key(Password, False).ToString & ";Connect Timeout=" & Timeout
        FrmMenu.lblsqlruta.Text = Conex
        FrmMenu.Text = "Sistema Administrativo de Ventas 3.0 - [\\" & Servidor & "\" & DbProcesos & "]"
        If UCase(Factura_Electronica) = "SI" Then FrmMenu.ChkElectronico.Checked = True
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

    Private Sub TxtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClave.TextChanged

    End Sub

    Private Sub TxtUser_TextChanged(sender As Object, e As EventArgs) Handles TxtUser.TextChanged

    End Sub
End Class