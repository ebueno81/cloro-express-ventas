Public Class FrmRetenConsul

    Private Sub FrmRetenConsul_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FrmRetenConsul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    ' Avanzamos presionando la tecla enter... '
    Private Sub FrmRetenConsul_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRetenConsul_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Mostrar_Retenciones()
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid(" and cL.c_desc_clie like '%" & TxtBus.Text & "%' and R.c_fecha_emi>='" & DtpFec_Inicio.Text & _
                                                            "' and R.c_fecha_emi<='" & DtpFec_Final.Text & "' order by c_nro_serie,c_nro_reten")
    End Sub
    ' Cargar Grid '
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RetenCab.get_RetenCab_Datos(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Call Grid_Registros_anulados(Dgv01)

            .Columns("Nro.").Width = 50
            .Columns("Retencion").Width = 70
            .Columns("Cliente").Width = 280
            .Columns("Fecha").Width = 80
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 80
            .Columns("c_anula_reg").Visible = False
            .Columns("c_nro_ing").Visible = False
            .Columns("Retencion").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Retencion").HeaderCell.Style.ForeColor = Color.Blue
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
                    FrmRetencion.Mostrar_Retenciones(" and R.c_nro_ing='" & .Rows(Fila).Cells("c_nro_ing").Value & "'")
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'Mostramos datos de la factura al presionar la tecla enter...
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
        
    End Sub
    ' Buscamos por numero de facturas '
    Private Sub TxtBus_Fact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Fact.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtBus_Fact.Text) > 0 Then
                TxtBus_Fact.Text = Strings.Right(Val(TxtBus_Fact.Text) + 10000000, 7)
                Dim Retencion As String = ""
                With c_Neg_RetenDet.get_RetenDet_Datos(" And R.c_nro_doc='" & TxtBus_Fact.Text & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If I = 0 Then
                                Retencion = "'" & .Rows(I)("c_nro_serie").ToString & .Rows(I)("c_nro_reten").ToString & "'"
                            Else
                                Retencion = Retencion & ",'" & .Rows(I)("c_nro_serie").ToString & .Rows(I)("c_nro_reten").ToString & "'"
                            End If
                        Next
                        If Len(Retencion) > 0 Then
                            Retencion = " and R.c_nro_serie + R.c_nro_reten In (" & Retencion & ") "
                            Call Cargar_Grid(Retencion)
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub TxtBus_Fact_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Fact.TextChanged

    End Sub
End Class