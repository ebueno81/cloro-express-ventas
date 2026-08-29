Public Class FrmMnVendedor
    Private Sub FrmMnVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnVendedor.get_Vendedor_Datos(Cadena, "DGV")
        With Dgv01 'Ajustamos Tamaño
            .Columns("Codigo").Width = 60
            .Columns("Vendedor").Width = 180
            .Columns("Dni").Width = 70
            .Columns("Telefono").Width = 120
            .Columns("Celular").Width = 120
            .Columns("E-Mail").Width = 120
            .Columns("c_anula_reg").Visible = False
            'Alineacion
            .Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Colores
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            'Coloreamos los registros inactivos...
            Call Grid_Registros_anulados(Dgv01)
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub

    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    'Nuevo Ingreso...
    Private Sub nuevo_ingreso()
        Tbc01.SelectedTab = Tab02
        BtnGrabar.Enabled = True
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Mostramos datos del vendedor al dar doble click...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y : Call Mostrar_Vendedor(fila) : Tbc01.SelectedTab = Tab02
            End If
        End With
    End Sub
    Private Sub Mostrar_Vendedor(ByVal Fila As Integer)
        With c_Neg_MnVendedor.get_Vendedor_Datos(" and V.c_codi_vende='" & Dgv01.Rows(Fila).Cells("Codigo").Value & "'", "DAT")
            Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan04)
            If .Rows.Count > 0 Then
                TxtCod_Vende.Text = .Rows(0)("c_codi_vende").ToString : TxtVende.Text = .Rows(0)("c_nom_vende").ToString
                TxtDni.Text = .Rows(0)("c_dni_vende").ToString : TxtDir.Text = .Rows(0)("c_direc_vende").ToString
                TxtDis.Text = .Rows(0)("c_dist_vende").ToString : TxtFono.Text = .Rows(0)("c_telf_vende").ToString
                TxtCel.Text = .Rows(0)("c_cel_vende").ToString : TxtMail.Text = .Rows(0)("c_mail_vende").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_Crea").ToString : TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFec_Crea.Text = .Rows(0)("c_fecha_crea").ToString : TxtFec_Mod.Text = .Rows(0)("c_fecha_modi").ToString
                TxtPorc_Comis.Text = Format(Val(.Rows(0)("c_porc_comi").ToString), Forma_1_3)
                If Val(.Rows(0)("c_afecto_comi").ToString) = 1 Then
                    ChkAfecto.Checked = True
                Else
                    ChkAfecto.Checked = False
                End If
                Tbc01.SelectedTab = Tab02
            End If
        End With
    End Sub
    Private Sub Cancela_Registro()
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02)
        Call Desactivar(Pan01) : Call Desactivar(Pan02) : Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Call Cancela_Registro()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtVende.Text) > 0 Then
            Dim f As String = MsgBox("¿Desea grabar el registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
            If f = vbYes Then
                Call Grabar_Vendedor("ADD") : MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Information, Compañia)
            End If
        Else
            MsgBox("Falta ingresar el nombre del vendedor...", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub
    'Grabamos vendedor...
    Private Sub Grabar_Vendedor(ByVal cOpcion As String)
        With c_Ent_MnVendedor
            Dim Afecto As Integer = 0
            If ChkAfecto.Checked = True Then Afecto = 1
            .c_codi_vende = TxtCod_Vende.Text
            .c_nom_vende = TxtVende.Text
            .c_dni_vende = TxtDni.Text
            .c_direc_vende = TxtDir.Text
            .c_dist_vende = TxtDis.Text
            .c_telf_vende = TxtFono.Text
            .c_cel_vende = TxtCel.Text
            .c_mail_vende = TxtMail.Text
            .c_afecto_comi = Afecto
            .c_porc_comi = Val(txtporc_comis.text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtCod_Vende.Text) = 0 Then
                TxtCod_Vende.Text = c_Neg_MnVendedor.set_Cliente_Save(c_Ent_MnVendedor)
            Else
                c_Neg_MnVendedor.set_Cliente_Save(c_Ent_MnVendedor)
            End If
            BtnGrabar.Enabled = False : Call BtnMostrar_Click(Nothing, Nothing)

        End With
    End Sub

    'Actualizamos
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            With Dgv01
                If .RowCount > 0 Then
                    Dim fila As Integer = .CurrentCellAddress.Y
                    If fila > -1 Then
                        Call Mostrar_Vendedor(fila)
                    End If
                End If
            End With
        End If
    End Sub
    'Buscamos por nombre de vendedor...
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid(" AND c_nom_vende like '%" & TxtBus.Text & "%' order by c_nom_vende ")
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan04)
        Call Activar(Pan01) : Call Activar(Pan04)
        TxtCod_Vende.Enabled = False : TxtVende.Focus()
        Call nuevo_ingreso()
    End Sub
    ' Editamos Registro '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Activar(Pan01) : Call Activar(Pan04)
                        TxtCod_Vende.Enabled = False : TxtVende.Focus()
                        Call nuevo_ingreso() : Call Mostrar_Vendedor(fila)
                    Else
                        MsgBox(" Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Eliminamos vendedor...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Confirma la eliminación del registro?...", vbYesNo + vbCritical, Compañia)
                        If F = vbYes Then
                            TxtCod_Vende.Text = .Rows(fila).Cells("Codigo").Value
                            Call Grabar_Vendedor("DEL") : MsgBox(" Registro se elimino Correctamente...", vbCritical, Compañia)
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado, no podra realizar ninguna Modificación...", vbCritical, Compañia)
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
End Class