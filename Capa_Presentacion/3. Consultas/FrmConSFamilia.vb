Public Class FrmConSFamilia
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConSFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConSFamilia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConSFamilia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnSFamilia.get_sfamilia_Datos(Cadena, "DGV")
        With Dgv01
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Width = 60
            .Columns(1).Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
            .Columns("c_anula_reg").Visible = False
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
        Call Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & Txtcod_Linea.Text & "' and c_codi_familia='" & TxtCod_Familia.Text & _
                         "' and c_desc_sfamilia like '%" & TxtBus_Art.Text & "%' order by c_desc_sfamilia")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al Orden de Transformacion...
                    If Val(TxtVar.Text) = 1 Then
                        FrmRepEnvases.TxtCod_SFamilia.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepEnvases.TxtSFamilia.Text = .Rows(fila).Cells("Descripcion").Value
                    End If
                    'Mostramos Salidas x articulos...
                    If Val(TxtVar.Text) = 2 Then
                        FrmRptSalAlm.TxtCod_SFamilia.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptSalAlm.TxtSFamilia.Text = .Rows(fila).Cells("Descripcion").Value
                    End If
                    'Mostramos reporte de estado de envases...
                    If Val(TxtVar.Text) = 3 Then
                        FrmRepEnvasesEstado.TxtCod_SFamilia.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepEnvasesEstado.TxtSFamilia.Text = .Rows(fila).Cells("Descripcion").Value
                        FrmRepEnvasesEstado.BtnConArt.Focus()
                    End If
                    'Mostramos reporte de VENTAS VALORIZADO...
                    If Val(TxtVar.Text) = 4 Then
                        FrmRptSalAlmValor.TxtCod_SFamilia.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptSalAlmValor.TxtSFamilia.Text = .Rows(fila).Cells("Descripcion").Value
                        FrmRptSalAlmValor.BtnConArt.Focus()
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
End Class