Public Class FrmRepEstadoCuenta
    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        Call CargarGrid()
    End Sub
    Public Sub CargarGrid()
        With Dgv01
            .DataSource = c_Neg_RptVtasTdas.get_RegEstadoCuentas_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, "DGV")
            .Columns("Tipo").Width = 60
            .Columns("Documento").Width = 80
            .Columns("Fecha").Width = 70
            .Columns("Estado").Width = 75
            .Columns("Status").Width = 70
            .Columns("Factura").Width = 140
            .Columns("N.Abono").Width = 80
            '.Columns("Monto").Width = 55
            .Columns("N.Debito").Width = 80
            '.Columns("Monto ").Width = 55
            .Columns("Cliente").Width =120
            .Columns("M").Width = 35
            ' .Columns("Tc").Width = 45
            .Columns("Total").Width = 60
            .Columns("Acta.").Width = 60
            .Columns("Saldo").Width = 60
            ' Alineacion '
            .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("N.Abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Factura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("N.Debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '   .Columns("Monto ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("M").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '   .Columns("Tc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Acta.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
          

            Call CalcularTotales()
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    Private Sub CalcularTotales()
        With Dgv01
            Dim TotRecordMn, TotRecordUs As Integer
            Dim TotMn, TotUs, TotActaMn, TotActaUs, TotSaldoMn, TotSaldoUs As Decimal
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("M").Value = "S/" Then
                    TotRecordMn = TotRecordMn + 1
                    TotMn = TotMn + Val(.Rows(i).Cells("Total").Value)
                    TotActaMn = TotActaMn + Val(.Rows(i).Cells("Acta.").Value)
                    TotSaldoMn = TotSaldoMn + Val(.Rows(i).Cells("Saldo").Value)
                Else
                    TotRecordUs = TotRecordUs + 1
                    TotUs = TotUs + Val(.Rows(i).Cells("Total").Value)
                    TotActaUs = TotActaUs + Val(.Rows(i).Cells("Acta.").Value)
                    TotSaldoUs = TotSaldoUs + Val(.Rows(i).Cells("Saldo").Value)
                End If
            Next
            TxtConta_1.Text = TotRecordMn
            TxtConta_2.Text = TotRecordUs

            TxtTot_03.Text = Format(TotMn, Forma_2_2)
            TxtTot_04.Text = Format(TotUs, Forma_2_2)
            TxtTot_05.Text = Format(TotActaMn, Forma_2_2)
            TxtTot_06.Text = Format(TotActaUs, Forma_2_2)
            TxtTot_07.Text = Format(TotSaldoMn, Forma_2_2)
            TxtTot_08.Text = Format(TotSaldoUs, Forma_2_2)

        End With
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Abrimos ruta de archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "ReporteEstadoCuenta.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\ReporteEstadoCuenta.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros de Boletas '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnImp_Click(sender As Object, e As EventArgs) Handles BtnImp.Click
        Dim Titulo As String = ""
        Dim Fecha As String = "" : Dim Cliente As String = ""
        If Len(TxtCod_Clie.Text) > 0 Then
            Cliente = " - " & TxtClie.Text
        End If
        'Amortizados o cancelados...
        If Rdb01.Checked = True Then
            Titulo = "Listado de Documentos Pendientes - Amortizados DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        If Rdb02.Checked = True Then
            Titulo = "Listado de Documentos Cancelados DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        BtnMostrar_Click(Nothing, Nothing)
        c_Neg_RptVtasTdas.get_RegEstadoCuentas_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, "RPT")

        FrmReportes.Close()
        FrmReportes.ReporteEstadoCuenta(Titulo, TxtTot_03.Text, TxtTot_04.Text, TxtTot_05.Text, TxtTot_06.Text,
                                        TxtTot_07.Text, TxtTot_08.Text)
    End Sub

    Private Sub TxtCod_Clie_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Clie.TextChanged

    End Sub

    Private Sub TxtCod_Clie_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Clie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Clie.Text) = 0 Then
                TxtClie.Clear()
            End If
        End If
    End Sub

    Private Sub BtnCon1_Click(sender As Object, e As EventArgs) Handles BtnCon1.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
        FrmConClientes.TxtVar.Text = 14 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmRepEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class