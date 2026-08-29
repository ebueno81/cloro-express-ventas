Imports Capa_Negocios
Public Class FrmConBol
    Dim c_neg_bolcab As New Neg_BolCab

    Private Sub FrmConBol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    'Avanzamos al presionar la tecla enter...
    Private Sub FrmConBol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConBol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        With Dgv01
            .DataSource = c_neg_bolcab.get_BolCab_Datos(" and Cl.c_desc_clie like '%" & TxtBus.Text & "%' and B.c_fecha_emi>='" & DtpFec_Inicio.Text & _
                                                        "' and B.c_fecha_emi<='" & DtpFec_Final.Text & "' order by c_nro_serie,c_nro_boleta", "DGV", FrmMenu.TxtCod_Emp.Text)
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next

            .Columns("Nro.").Width = 50
            .Columns("Boleta").Width = 70
            .Columns("Cliente").Width = 280
            .Columns("Fecha").Width = 80
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 80
            .Columns("c_anula_reg").Visible = False
            .Columns("Boleta").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Boleta").HeaderCell.Style.ForeColor = Color.Blue
            .Focus()
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Mostramos registros al dar doble click
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmBoletas.Mostrar_Boletas(" and c_nro_serie='" & .Rows(Fila).Cells("Nro.").Value & "' and c_nro_boleta='" & .Rows(Fila).Cells("Boleta").Value & "'")
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'Mostramos datos de la factura al presionar la tecla enter...
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TxtBus_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub
End Class