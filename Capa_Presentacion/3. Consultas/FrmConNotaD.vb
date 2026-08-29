Imports Capa_Negocios
Public Class FrmConNotaD
    Dim c_Neg_NotaD As New Neg_NotaD : Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConNotaD_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then FrmIngND.Enabled = True
    End Sub

    Private Sub FrmConNotaD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConNotaD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConNotaD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_NotaD.get_NotaD_Datos(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            .Columns("Nota").Width = 45
            .Columns("Debito").Width = 50
            .Columns("Fecha").Width = 75
            .Columns("Cliente").Width = 320
            .Columns("Total").Width = 70
            'Alineacion
            .Columns("Nota").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Visibles
            .Columns("c_anula_reg").Visible = False
            'Validamos si registro esta activo...
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Rango_Fechas As String = ""
        If DtpFec_Fin.Text = DtpFec_Inicio.Text Then
            Rango_Fechas = " "
        Else
            Rango_Fechas = " And c_fecha_emi>='" & DtpFec_Inicio.Text & "' and c_fecha_emi<='" & DtpFec_Fin.Text & "' "
        End If
        Call Cargar_Grid(" and c_desc_clie like '%" & TxtBuscar.Text & "%' " & Rango_Fechas)
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario Salidas...
                    If Val(TxtVar.Text) = 1 Then
                        FrmIngND.TxtBus_Serie.Text = .Rows(fila).Cells("Nota").Value
                        FrmIngND.TxtBus_ND.Text = .Rows(fila).Cells("Debito").Value
                        FrmIngND.Mostrar_NotaD()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
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
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class