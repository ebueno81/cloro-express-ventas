Public Class FrmConScd
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConScd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConScd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConScd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Reporte de Ingresos...
                    If Val(TxtVar.Text) = 1 Then
                        FrmRepTransforma.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepTransforma.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmRepTransforma.Txtcod_Articulo.Text = .Rows(fila).Cells("Articulo").Value
                        FrmRepTransforma.BtnMostrar.Focus()
                    End If
                    'Reporte de Gerencia...
                    If Val(TxtVar.Text) = 2 Then
                        FrmRepVtasGerencial.TxtCodScd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepVtasGerencial.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmRepTransforma.BtnMostrar.Focus()
                    End If
                    'Reporte de transformaciones...
                    If Val(TxtVar.Text) = 3 Then
                        FrmRptTransforVentas.TxtCodArt.Text = .Rows(fila).Cells("Articulo").Value
                        FrmRptTransforVentas.TxtArt.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmRptTransforVentas.BtnMostrar.Focus()
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
        Dgv01.DataSource = c_Neg_MnScaidas.get_sCaidas_Datos(Cadena, "DG2")
        With Dgv01
            .Columns("Tg").Width = 45
            .Columns("Cd").Width = 45
            .Columns("Codigo").Width = 45
            .Columns("Articulo").Width = 60

            .Columns(0).DefaultCellStyle.BackColor = Color.Ivory
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("SubCaida").Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
            '.Columns(2).Visible = False
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
    ' Buscamos por Codigo de Tabla General '
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_anula_reg=0 and c_desc_scd like '%" & TxtBus_Art.Text & "%' order by c_desc_scd")
    End Sub
End Class