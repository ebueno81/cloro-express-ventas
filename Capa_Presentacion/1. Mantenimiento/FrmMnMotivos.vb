Public Class FrmMnMotivos
    Private Sub FrmMnMotivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnMotivos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnMotivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Neg_mnmtmov.get_MtMov_Datos(" and c_anula_reg=0 order by c_codi_mt", "DGV")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Motivo").Width = 320

            'alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Motivo").Width = 320
            'color
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            Call Grid_Registros_anulados(Dgv01)
            .Columns("c_anula_reg").Visible = False
            .Columns("c_opc_prove").Visible = False

        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro() : Call Cargar_Grid()
        End If
    End Sub
    ' metodo para cancelar registro
    Private Sub Cancelar_Registro()
        With Dgv01
            .Size = New Size(486, 241) : .Location = New Point(2, 60)
            BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False : Pan01.Enabled = True
            TxtCod.Clear() : TxtDesc.Clear() : TxtCod_Sunat.Enabled = False
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Validamos el registro anulados '
    Private Sub Dgv01_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    ' Validamos si grabamos '
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtDesc.Text) > 0 Then
            Dim F As String = MsgBox("Desea Grabar el Registro", MsgBoxStyle.OkOnly + vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Motivo("ADD") : Call BtnCerrar_Click(Nothing, Nothing) : Call Cargar_Grid()
            End If
        Else
            MsgBox("Falta ingresar el mótivo...", vbCritical, Compañia)
        End If
    End Sub
    ' Metodo para grabar registro '
    Private Sub Grabar_Motivo(ByVal cOpcion As String)
        With c_Ent_MnMtMov
            Dim c_opc_prove As Integer = 0
            .c_codi_mt = TxtCod.Text
            .c_desc_mt = TxtDesc.Text
            If ChkOpc.Checked = True Then c_opc_prove = 1
            .c_opc_prove = c_opc_prove
            .c_codi_sunat = TxtCod_Sunat.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_mnmtmov.set_MnMtMov_Save(c_Ent_MnMtMov)
        End With
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro()
    End Sub
    ' metodo para un nuevo registro
    Private Sub Nuevo_Registro()
        With Dgv01
            .Size = New Size(486, 218) : .Location = New Point(2, 83)
            BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False : Pan01.Enabled = True
            TxtCod.Clear() : TxtDesc.Clear() : Pan01.Enabled = False : BtnGrabar.Enabled = True
            BtnCerrar.Text = "Cancelar" : ChkOpc.Checked = False : TxtCod_Sunat.Enabled = True
        End With
    End Sub
    ' Editamos registro '
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Call Nuevo_Registro()
                        TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtDesc.Text = .Rows(Fila).Cells("Motivo").Value
                        TxtCod_Sunat.Text = .Rows(Fila).Cells("Sunat").Value
                        ' Validamos si trabaja con los proveedores '
                        If Val(.Rows(Fila).Cells("c_opc_prove").Value.ToString) = 1 Then
                            ChkOpc.Checked = True
                        Else
                            ChkOpc.Checked = False
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Eliminamos registro '
    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea eliminar el registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                            Call Grabar_Motivo("DEL") : Call Cargar_Grid()
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado no podra realizar ninguna Eliminación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
End Class