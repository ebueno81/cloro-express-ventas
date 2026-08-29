Public Class FrmConComisDocs

    Private Sub FrmConComisDocs_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConComisDocs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Cargamos grid para facturas...
    Public Sub Cargar_Grid(ByVal Cadena As String, ByVal Opcion As String)
        Dgv01.DataSource = c_Neg_ComisDocs.get_ComisDocs_Datos(Cadena, "DGV")

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
                    If .Rows(i).Cells("_").Value = "S/." Then Tot_Sol = Tot_Sol + Val(.Rows(i).Cells("Monto").Value)
                    If .Rows(i).Cells("_").Value = "$." Then Tot_Dol = Tot_Dol + Val(.Rows(i).Cells("Monto").Value)
                End If
            Next
            TxtTol_Dol.Text = Format(Tot_Dol, Forma_2_2)
            TxtTol_Sol.Text = Format(Tot_Sol, Forma_2_2)

            .Columns("Tipo").Width = 50
            .Columns("Documento").Width = 80
            .Columns("Tipo").Width = 100
            .Columns("Vendedor").Width = 155
            .Columns("_").Width = 30
            .Columns("Monto").Width = 80
            .Columns("Observaciones").Width = 220
            .Columns("c_anula_reg").Visible = False
            .Columns("c_nro_correl").Visible = False
            .Columns("Tipo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Tipo").HeaderCell.Style.ForeColor = Color.Blue
            Call Grid_Registros_anulados(Dgv01)
            If .RowCount = 0 Then
                Me.Close()
                MsgBox("No existen documentos anexos a la factura...", vbCritical, Compañia)
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Anulamos registro '
    Private Sub Dgv01_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub Dgv01_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        With Dgv01
            If e.KeyCode = Keys.Delete Then
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Dim F As String = MsgBox("¿Confirma la Eliminacíon del Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            Call Grabar_ComisAnexos(Fila, "DEL")
                            Dgv01.Rows(Fila).Cells("c_anula_reg").Value = 1
                            Dgv01.Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    ' metodo para grabar registro '
    Private Sub Grabar_ComisAnexos(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_ComisDocs
            .c_nro_correl = Dgv01.Rows(Fila).Cells("c_nro_correl").Value
            .c_nro_comis = TxtNro_Comis.Text
            .c_codi_vende = ""
            .c_codi_doc = ""
            .c_serie_doc = ""
            .c_nro_doc = ""
            .c_codi_mon = ""
            .c_imp_doc = 0
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_ComisDocs.set_ComisDocs_Save(c_Ent_ComisDocs)

        End With
    End Sub
End Class