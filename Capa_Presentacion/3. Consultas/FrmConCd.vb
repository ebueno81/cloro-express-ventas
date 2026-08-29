Public Class FrmConCd
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    ' Reporte de Transformacion '
                    If Val(TxtVar.Text) = 1 Then
                        FrmRepTransforma.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepTransforma.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                        FrmRepTransforma.TxtCod_Scd.Focus()
                    End If
                    ' Reporte de Transformacion '
                    If Val(TxtVar.Text) = 2 Then
                        FrmRepVtasGerencial.TxtCodCd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepVtasGerencial.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                        FrmRepVtasGerencial.TxtCodScd.Focus()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnCaidas.get_Caidas_Datos(Cadena, "DG2")
        With Dgv01
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).DefaultCellStyle.BackColor = Color.Ivory
            .Columns(0).Width = 60
            .Columns(1).Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
        End With
    End Sub

    Private Sub TxtBus_Art_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBus_Art.GotFocus
        With Dgv01
            'On Error Resume Next
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBus_Art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Art.KeyDown
        With Dgv01
            ' Dim caja As New TextBox
            If .RowCount > 0 Then
                ' On Error Resume Next
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1
                    x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True
                    x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then
                        Call Dgv01_DoubleClick(Nothing, Nothing)
                    End If
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' and c_desc_cd like '%" & TxtBus_Art.Text & "%' order by c_desc_cd")
    End Sub


    Private Sub FrmConCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConCd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConCd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class