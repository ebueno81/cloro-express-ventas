Public Class FrmListaNotaC
    'Avanzamos presionando la tecla enter...
    Private Sub FrmListaNotaC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmListaNotaC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeries.get_Series_Cbo(" and c_anula_reg=0 and c_codi_doc='03' order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        DtpFec_Inicio.Text = "01/" & Strings.Right(Month(Date.Now) + 100, 2) & "/" & Year(Date.Now)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVendedor)
    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_NotaC.get_NotaC_Datos(Cadena, "LIS", FrmMenu.TxtCod_Emp.Text)
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                If .Rows(i).Cells(" ").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_3 = Tot_3 + Val(.Rows(i).Cells("Total").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_4 = Tot_4 + Val(.Rows(i).Cells("Total").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_03.Text = Format(Val(Tot_3), Forma_2_2)
            TxtTot_04.Text = Format(Val(Tot_4), Forma_2_2)

            .Columns("Nro.Nota C.").Width = 90
            .Columns("Cliente").Width = 240
            .Columns("Fecha Emision").Width = 100
            .Columns(" ").Width = 30
            .Columns("Total").Width = 70
            .Columns("Tipo").Width = 100
            .Columns("Serie").Width = 50
            .Columns("Documento").Width = 80

            .Columns("c_anula_reg").Visible = False
            .Columns("Nro.Nota C.").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Nro.Nota C.").HeaderCell.Style.ForeColor = Color.Blue
            ' Metodo para llamar a los registros por el grid seleccionado '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Vendedor As String = ""
        Dim Saldo As String = "" : Dim Anula As String = "" : Dim Fecha As String = "" : Dim Cliente As String = ""
        'Facturas Anuladas...
        If Rdb05.Checked = True Then Anula = " and N.c_anula_reg=0 "
        If Rdb06.Checked = True Then
            Anula = " and N.c_anula_reg=1 " : Saldo = " "
        End If
        If Len(TxtClie.Text) > 0 Then Cliente = " And Cl.c_desc_clie like '%" & TxtClie.Text & "%' "
        'Fecha de emision
        Fecha = " and N.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and N.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        ' Vendedor
        If Len(CboVendedor.Text) > 0 Then Vendedor = " and Cl.c_codi_vende='" & CboVendedor.SelectedValue & "' "
        Call Cargar_Grid(Saldo & Anula & Fecha & Cliente & Vendedor)
    End Sub
    'Mostramos los datos de la factura al presionar la tecla enter...
    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtFactura.Text) > 0 Then
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Call Cargar_Grid(" and N.c_nro_nc='" & TxtFactura.Text & "' and N.c_nro_serie='" & CboSerie.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub
    'Cerramos formulario...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    'Inicio
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
    ' Abrimos Archivo '
    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            TxtRuta.Text = Folder01.SelectedPath
        End If
    End Sub
    ' Abrimos archivo de ruta '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_NotaCredito.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_NotaCredito.XLS"
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
    ' Impresion de Listado de Nota de Credito '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = ""
        Dim Saldo As String = "" : Dim Anula As String = "" : Dim Fecha As String = "" : Dim Cliente As String = ""
        'Facturas Anuladas...
        If Rdb05.Checked = True Then
            Anula = " and N.c_anula_reg=0 "
            Titulo = "Listado de Nota de Crédito DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If

        If Rdb06.Checked = True Then
            Anula = " and N.c_anula_reg=1 " : Saldo = " "
            Titulo = "Listado de Nota de Crédito Anuladas DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        If Len(TxtClie.Text) > 0 Then Cliente = " And Cl.c_desc_clie like '%" & TxtClie.Text & "%' "
        'Fecha de emision
        Fecha = " and N.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and N.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        Call Cargar_Grid(Saldo & Anula & Fecha & Cliente)
        c_Neg_NotaC.get_NotaC_Datos(Saldo & Anula & Fecha & Cliente, "RPT", FrmMenu.TxtCod_Emp.Text)
        FrmReportes.Reporte_ListaDoc(Titulo, "NOTA CREDITO", TxtTot_03.Text, TxtTot_04.Text,
                                     0, 0, TxtTot_03.Text, TxtTot_04.Text)
    End Sub
End Class