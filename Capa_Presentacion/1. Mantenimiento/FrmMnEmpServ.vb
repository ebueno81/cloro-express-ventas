Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmMnEmpServ
    Dim c_neg_MnEmpServ As New Neg_MnEmpServ : Dim c_Ent_MnEmpServ As New Ent_MnEmpServ

    Private Sub FrmMnEmpServ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnEmpServ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnEmpServ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_neg_MnEmpServ.get_EmpServ_Datos(Cadena, "DGV")
            .Columns("Codigo").Width = 50
            .Columns("Razon Social").Width = 260
            .Columns("Ruc").Width = 100
            .Columns("Distrito").Width = 120
            .Columns("Direccion").Width = 180
            .Columns("Telefono").Width = 210
            .Columns("Celular").Width = 210
            .Columns("Ruc").Width = 210
            .Columns("Web").Width = 210
            .Columns("Contacto").Width = 210
            .Columns("c_anula_Reg").Visible = False
            Call Grid_Registros_anulados(Dgv01)
            'Alienacion
            .Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Call Dgv01_SelectionChanged(Nothing, Nothing)
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
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.Click
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    Private Sub Mostrar_EmpServ(ByVal Fila As Integer)
        With c_neg_MnEmpServ.get_EmpServ_Datos(" and c_codi_empserv='" & Dgv01.Rows(Fila).Cells("Codigo").Value & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan01)
                TxtCodigo.Text = .Rows(0)("c_codi_empserv").ToString
                TxtEmpresa.Text = .Rows(0)("c_desc_empserv").ToString
                TxtDistrito.Text = .Rows(0)("c_dist_empserv").ToString
                TxtDirec.Text = .Rows(0)("c_direcc_empserv").ToString
                TxtFono.Text = .Rows(0)("c_telf_empserv").ToString
                TxtCel.Text = .Rows(0)("c_cel_empserv").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_empserv").ToString
                TxtWeb.Text = .Rows(0)("c_web_empserv").ToString
                TxtMail.Text = .Rows(0)("c_mail_empserv").ToString
                TxtContacto.Text = .Rows(0)("c_contac_empserv").ToString
                TxtNroTarjetaCircula.Text = .Rows(0)("c_nro_tarjcircula").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub
    'Grabamos tipo de cambio
    Private Sub Grabar_Empserv(ByVal cOpcion As String)
        With c_Ent_MnEmpServ
            .c_codi_empserv = TxtCodigo.Text
            .c_desc_empserv = TxtEmpresa.Text
            .c_dist_empserv = TxtDistrito.Text
            .c_direcc_empserv = TxtDirec.Text
            .c_telf_empserv = TxtFono.Text
            .c_cel_empserv = TxtCel.Text
            .c_ruc_empserv = TxtRuc.Text
            .c_web_empserv = TxtWeb.Text
            .c_mail_empserv = TxtMail.Text
            .c_contac_empserv = TxtContacto.Text
            .c_nro_tarjcircula = TxtNroTarjetaCircula.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtCodigo.Text) = 0 Then
                TxtCodigo.Text = c_neg_MnEmpServ.set_EmpServ_Save(c_Ent_MnEmpServ)
            Else
                c_neg_MnEmpServ.set_EmpServ_Save(c_Ent_MnEmpServ)
            End If
        End With
        Call Cargar_Grid(" order by c_codi_empserv")
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        BtnCancelar_Click(Nothing, Nothing) : BtnGrabar.Enabled = False
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : Pan01.Enabled = True : TxtEmpresa.Focus() : BtnGrabar.Enabled = True
    End Sub
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01)
        TxtEmpresa.Enabled = True : TxtDirec.Enabled = True : TxtDistrito.Enabled = True : TxtRuc.Enabled = True
        TxtFono.Enabled = True : TxtCel.Enabled = True : TxtWeb.Enabled = True : TxtMail.Enabled = True
        TxtContacto.Enabled = True
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro()
                        Call Tbc01_Click(Nothing, Nothing) : BtnGrabar.Enabled = True : Pan01.Enabled = True : TxtEmpresa.Focus()
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Eliminar Registros
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            'Call Mostrar_EmpServ(Dgv01.Rows(fila).Cells("Codigo").Value)
                            TxtCodigo.Text = .Rows(fila).Cells("Codigo").Value
                            Call Grabar_Empserv("DEL")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtEmpresa.Text) > 0 Then
            Call Grabar_Empserv("ADD")
        Else
            MsgBox("Falta ingresar el nombre de la Empresa...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False : Pan01.Enabled = False
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub
    'Cerramos formularios...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then
            Pan01.Enabled = False : BtnGrabar.Enabled = False
        Else
            With Dgv01
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_EmpServ(Fila) : Pan01.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
End Class