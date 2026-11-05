Public Class FrmSalAlmContrato

    Public Property SerieOT As String
    Public Property NroOT As String
    Public Property Cliente As String

    Private Sub FrmSalAlmContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtSerieOT.Text = SerieOT
        TxtNroOT.Text = NroOT
        TxtCliente.Text = Cliente

        '  ModUtils.CargarComboMoneda(CboMoneda)
    End Sub
End Class