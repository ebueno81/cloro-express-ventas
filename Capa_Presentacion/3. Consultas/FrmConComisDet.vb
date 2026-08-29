Public Class FrmConComisDet
    Private Sub FrmConComisDet_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConComisDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Cargamos grid para facturas...
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_ComisDet.get_ComisDet_Datos(Cadena, "COM")

        With Dgv01
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            Dim Tot_Dol, Tot_Sol As Decimal
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                Else
                    If .Rows(i).Cells(" ").Value = "S/" Then Tot_Sol = Tot_Sol + Val(.Rows(i).Cells("Comision").Value)
                    If .Rows(i).Cells(" ").Value = "$." Then Tot_Dol = Tot_Dol + Val(.Rows(i).Cells("Comision").Value)
                End If
            Next
            TxtTol_Dol.Text = Format(Tot_Dol, Forma_2_2)
            TxtTol_Sol.Text = Format(Tot_Sol, Forma_2_2)
            .Columns("Nro.Comision").Width = 70
            .Columns("Estado").Width = 100
            .Columns("Fecha").Width = 80
            .Columns(" ").Width = 30
            .Columns("Importe").Width = 80
            .Columns("Comision").Width = 80
            .Columns("c_anula_reg").Visible = False
            .Columns("Nro.Comision").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Nro.Comision").HeaderCell.Style.ForeColor = Color.Blue
            Call Grid_Registros_anulados(Dgv01)
            If .RowCount = 0 Then
                MsgBox("No existen pagos de comisiones...", vbCritical, Compañia)
                Me.Close()
            End If
        End With
    End Sub
    ' Seleccionamos columnas del grid '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
End Class