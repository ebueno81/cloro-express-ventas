Public Class FrmConTg
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConTg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConTg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnTblGral.get_TblGral_Datos(Cadena, "DG2")
        With Dgv01
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Width = 60
            .Columns(1).Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
        End With
    End Sub

    Private Sub TxtBus_Art_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBus_Art.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBus_Art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Art.KeyDown
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
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_tg like '%" & TxtBus_Art.Text & "%' order by c_desc_tg")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    ' Transformaciones '
                    If Val(TxtVar.Text) = 1 Then
                        FrmRepTransforma.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepTransforma.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                        FrmRepTransforma.TxtCod_Cd.Focus()
                    End If
                    ' Reporte Gerencial '
                    If Val(TxtVar.Text) = 2 Then
                        FrmRepVtasGerencial.TxtCodTg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepVtasGerencial.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                        FrmRepVtasGerencial.TxtCodCd.Focus()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'mostramos al dar doble clic
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub FrmConTg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class