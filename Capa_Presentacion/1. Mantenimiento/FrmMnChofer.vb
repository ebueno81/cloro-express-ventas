Public Class FrmMnChofer
    Private Sub FrmMnDiseño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnDiseño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnDiseño_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        c_Neg_MnEmprServ.Get_EmpServ_Cbo(" and c_anula_reg=0 order by c_desc_empserv", CboEmpServ)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_MnChofer.get_Chofer_Datos(Cadena, "DGV")
            .Columns("brevete").Width = 80
            .Columns("Nombres").Width = 140
            .Columns("Apellidos").Width = 140
            .Columns("Dni").Width = 70
            .Columns("Empresa").Width = 180
            .Columns("c_anula_Reg").Visible = False
            'Alienacion
            .Columns("brevete").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("dni").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
    Private Sub Mostrar_Chofer(ByVal Fila As Integer)
        With c_Neg_MnChofer.get_Chofer_Datos(" and c_nro_brevete='" & Dgv01.Rows(Fila).Cells("Brevete").Value & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan01)
                TxtBrevete.Text = .Rows(0)("c_nro_brevete").ToString
                CboEmpServ.SelectedValue = .Rows(0)("c_codi_empserv")
                TxtChofer.Text = .Rows(0)("c_nom_chofer").ToString
                TxtApeChofer.Text = .Rows(0)("c_ape_chofer").ToString
                TxtDni.Text = .Rows(0)("c_nro_dni").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub
    'Grabamos Tela 
    Private Sub Grabar_Chofer(ByVal cOpcion As String)
        With c_Ent_MnChofer
            .c_nro_brevete = TxtBrevete.Text
            .c_codi_empserv = CboEmpServ.SelectedValue
            .c_nom_chofer = TxtChofer.Text
            .c_ape_chofer = TxtApeChofer.Text
            .c_nro_dni = TxtDni.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnChofer.get_Chofer_Save(c_Ent_MnChofer)
        End With
        Call Cargar_Grid(" order by c_nom_chofer")
        BtnCancelar_Click(Nothing, Nothing) : BtnGrabar.Enabled = False
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : Pan01.Enabled = True : TxtBrevete.Focus() : BtnGrabar.Enabled = True
    End Sub
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01)
        TxtBrevete.Enabled = True : CboEmpServ.Enabled = True : TxtDni.Enabled = True : TxtChofer.Enabled = True
        CboEmpServ.Enabled = True : TxtApeChofer.Enabled = True
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro() : Pan01.Enabled = True
                        Call Tbc01_Click(Nothing, Nothing) : TxtChofer.Focus() : BtnGrabar.Enabled = True
                        TxtBrevete.Enabled = False
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
                            TxtBrevete.Text = .Rows(fila).Cells("brevete").Value
                            Call Grabar_Chofer("DEL")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Function ValidarDatos() As Boolean
        If Len(TxtChofer.Text) > 0 Then
            If Len(TxtApeChofer.Text) > 0 Then
                If Len(TxtDni.Text) >= 8 Then
                    If Len(TxtBrevete.Text) >= 8 Then
                        ValidarDatos = True
                    Else
                        MsgBox("1. Falta ingresar el numero de brevete correcto...", vbCritical, Compañia)
                    End If
                Else
                    MsgBox("2. Falta ingresar el numero de DNI de forma correcta...", vbCritical, Compañia)
                End If
            Else
                MsgBox("3. Falta ingresar el apellido...", vbCritical, Compañia)
            End If
        Else
            MsgBox("4. Falta ingresar el nombre del chofer...", vbCritical, Compañia)
        End If
    End Function
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Call Grabar_Chofer("ADD")
        End If
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False : Pan01.Enabled = False
        Call Desactivar(Pan01) : TxtChofer.Enabled = False : CboEmpServ.Enabled = False
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
                        Call Mostrar_Chofer(Fila)
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

End Class