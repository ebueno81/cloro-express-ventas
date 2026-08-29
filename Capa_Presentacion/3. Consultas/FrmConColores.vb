Imports Capa_Negocios
Public Class FrmConColores
    Dim c_Neg_MnLstPrecios As New Neg_MnLstPrecios

    Private Sub FrmConColores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Generación de facturas...
        If Val(TxtVar.Text) = 1 Then
            
        End If
    End Sub

    Private Sub FrmConColores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConColores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConColores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnLstPrecios.get_ColorVta_Dgv(Cadena)
        With Dgv01
            .Columns("Codigo").Width = 80
            .Columns("Color").Width = 180
            .Columns("c_anula_reg").Visible = False
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(TxtVar.Text) = 1 Then
                         
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = 13 Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_color like '%" & TxtBus_Art.Text & "%' order by c_desc_color")
    End Sub
End Class