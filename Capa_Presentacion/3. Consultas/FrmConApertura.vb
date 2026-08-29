Public Class FrmConApertura

    Private Sub FrmConApertura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConApertura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConApertura_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboTpoDoc)
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid(" and T.c_codi_doc ='" & CboTpoDoc.SelectedValue & "' and F.c_fecha_emi>='" & DtpFec_Inicio.Text & _
                                                         "' and F.c_fecha_emi<='" & DtpFec_Final.Text & "' order by c_nro_serie,c_nro_doc")
    End Sub
    ' metodo para cargar grid
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_Apertura.get_Apertura_Datos(Cadena, "DGV")
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

            .Columns("Ingreso").Width = 50
            .Columns("Tipo").Width = 75
            .Columns("Nro.").Width = 50
            .Columns("Documento").Width = 70
            .Columns("Cliente").Width = 230
            .Columns("Fecha").Width = 80
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 80
            .Columns("c_anula_reg").Visible = False
            .Columns("Documento").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Documento").HeaderCell.Style.ForeColor = Color.Blue
            .Focus()
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Mostramos registros al dar doble click
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmApertura.Mostrar_documentos(.Rows(Fila).Cells("Ingreso").Value)
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'Mostramos datos de la factura al presionar la tecla enter...
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TxtBus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtBus.Text) > 0 Then
                Call Cargar_Grid(" and F.c_nro_doc like '%" & TxtBus.Text & "%' order by c_fecha_emi")
            End If
        End If
    End Sub

    Private Sub TxtBus_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub
End Class