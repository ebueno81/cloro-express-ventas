Public Class FrmConArticulos
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    ' Cargamos registro '
    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click
        Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RptStockIQ.get_StockIQ_Datos(Cadena, Year(Now.Date), Month(Now.Date), TxtCod_Alm.Text, "02", "GUI")
            .Columns("Mot").Width = 50
            .Columns("Cd").Width = 50
            .Columns("Scd").Width = 50
            .Columns("Codigo I.Q.").Width = 90
            .Columns("Articulo").Width = 290
            .Columns("Cantidad").Width = 80
            ' Validamos el tipo de moneda '
            .Columns("Total").Width = 70
            .Columns("Precio").Width = 70
            ' Alineacion '
            .Columns("Mot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Scd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo I.Q.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Validamos el tipo de moneda '

            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Visible '
            .Columns("Total").Visible = False
            .Columns("Precio").Visible = False

        End With
    End Sub

    Private Sub TxtBus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
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

                    If Dgv01.RowCount > 0 Then Foco = 2
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBus_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBus.TextChanged
        Call Cargar_Grid(" and c_codi_alm='" & TxtCod_Alm.Text & "' and c_desc_articulo like '" & TxtBus.Text & "%' order by c_desc_articulo")
    End Sub

    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(sender As Object, e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmAlmSalTA.TxtCodigo.Text = .Rows(Fila).Cells("Codigo I.Q.").Value
                    FrmAlmSalTA.TxtDescripcion.Text = .Rows(Fila).Cells("Articulo").Value
                    FrmAlmSalTA.TxtPrecio.Text = Val(.Rows(Fila).Cells("Precio").Value.ToString)
                    FrmAlmSalTA.TxtStock.Text = Val(.Rows(Fila).Cells("Cantidad").Value.ToString)
                    FrmAlmSalTA.TxtCod_Mon.Text = "02"
                    FrmAlmSalTA.Mostrar_Articulo(.Rows(Fila).Cells("Codigo I.Q.").Value)
                    Me.Close()
                End If
            End If
        End With
    End Sub
    ' Cerramos Ventana '
    Private Sub FrmConArticulos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then
            FrmAlmSalTA.TxtBultos.Focus()
        End If
    End Sub
    ' Cerramos al presionar la tecla escape '
    Private Sub FrmConArticulos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConArticulos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConArticulos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Dgv01_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    ' EVITAMOS SE PIERDA EL ENFOQUE
    Private Sub Dgv01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.LostFocus
        If Foco = 2 Then
            Foco = 0 : Dgv01.Focus()
        End If
    End Sub
End Class