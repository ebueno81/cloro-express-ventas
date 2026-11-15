Imports Microsoft.Reporting.WinForms

Public Class FrmVisorReporte

    Private Sub FrmVisorReporte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try

            RptVisor.LocalReport.DataSources.Clear()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmVisorReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmVisorReporte_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class