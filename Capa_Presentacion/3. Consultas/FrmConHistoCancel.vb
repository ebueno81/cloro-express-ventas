Imports Capa_Negocios
Public Class FrmConHistoCancel
    Dim c_Neg_FactCab As New Neg_FactCab
    Dim c_Neg_BolCab As New Neg_BolCab
    'Cerramos ventana al presionar la tecla enter...
    Private Sub FrmConHistoCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConHistoCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Cargamos grid para facturas...
    Public Sub Cargar_Grid(ByVal Cadena As String, ByVal Opcion As String)
        If Opcion = "FACT" Then Dgv01.DataSource = c_Neg_FactCab.get_FactCab_Datos(Cadena, "PAG", FrmMenu.TxtCod_Emp.Text)
        If Opcion = "BOL" Then Dgv01.DataSource = c_Neg_BolCab.get_BolCab_Datos(Cadena, "PAG", FrmMenu.TxtCod_Emp.Text)
        If Opcion = "LET" Then Dgv01.DataSource = c_Neg_LetCab.get_LetCab_Datos(Cadena, "PAG", FrmMenu.TxtCod_Emp.Text)
        If Opcion = "NOD" Then Dgv01.DataSource = c_Neg_NotaD.get_NotaD_Datos(Cadena, "PAG", FrmMenu.TxtCod_Emp.Text)

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
                    If .Rows(i).Cells(" ").Value = "S/" Then Tot_Sol = Tot_Sol + Val(.Rows(i).Cells("Monto").Value)
                    If .Rows(i).Cells(" ").Value = "$." Then Tot_Dol = Tot_Dol + Val(.Rows(i).Cells("Monto").Value)
                End If
            Next
            TxtTol_Dol.Text = Format(Tot_Dol, Forma_2_2)
            TxtTol_Sol.Text = Format(Tot_Sol, Forma_2_2)

            .Columns("Nro.").Width = 50
            .Columns("Voucher").Width = 70
            .Columns("Tipo").Width = 100
            .Columns("Fecha").Width = 80
            .Columns("T.C.").Width = 40
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 80
            .Columns("c_anula_reg").Visible = False
            .Columns("Voucher").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Voucher").HeaderCell.Style.ForeColor = Color.Blue
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Seleccionamos columnas del grid '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
End Class