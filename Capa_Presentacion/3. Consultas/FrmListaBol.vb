Public Class FrmListaBol
    Private Sub FrmListaBol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmListaBol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeries.get_Series_Cbo(" and c_anula_reg=0 and c_codi_doc='02' order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        DtpFec_Inicio.Text = "01/" & Strings.Right(Month(Date.Now) + 100, 2) & "/" & Year(Date.Now)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVendedor)
    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String, ByVal Cadena2 As String)
        With Dgv01
            .DataSource = c_neg_BolCab.get_BolCab_Datos(Cadena, "LIS", Cadena2)

            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Peso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Amortizado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                If .Rows(i).Cells(" ").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_1 = Tot_1 + Val(.Rows(i).Cells("Peso").Value)
                    Tot_3 = Tot_3 + Val(.Rows(i).Cells("Total").Value)
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Amortizado").Value)
                    Tot_7 = Tot_7 + Val(.Rows(i).Cells("Saldo").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_2 = Tot_2 + Val(.Rows(i).Cells("Peso").Value)
                    Tot_4 = Tot_4 + Val(.Rows(i).Cells("Total").Value)
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Amortizado").Value)
                    Tot_8 = Tot_8 + Val(.Rows(i).Cells("Saldo").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_01.Text = Format(Val(Tot_1), Forma_2_2)
            TxtTot_02.Text = Format(Val(Tot_2), Forma_2_2)
            TxtTot_03.Text = Format(Val(Tot_3), Forma_2_2)
            TxtTot_04.Text = Format(Val(Tot_4), Forma_2_2)
            TxtTot_05.Text = Format(Val(Tot_5), Forma_2_2)
            TxtTot_06.Text = Format(Val(Tot_6), Forma_2_2)
            TxtTot_07.Text = Format(Val(Tot_7), Forma_2_2)
            TxtTot_08.Text = Format(Val(Tot_8), Forma_2_2)

            .Columns("Nro.Boleta").Width = 90
            .Columns("Cliente").Width = 200
            .Columns("Fecha Emision").Width = 100
            .Columns("Peso").Width = 80
            .Columns(" ").Width = 30
            .Columns("Total").Width = 80
            .Columns("Amortizado").Width = 80
            .Columns("Saldo").Width = 80
            .Columns("Dias").Width = 40
            .Columns("Fecha-Pago").Width = 80

            .Columns("c_anula_reg").Visible = False
            .Columns("Nro.Boleta").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Nro.Boleta").HeaderCell.Style.ForeColor = Color.Blue
            ' Metodo para mostrar los registros seleccionados del grid '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            Call Calcular_Dias_Cancel()
        End With
    End Sub
    ' metodo para calcular el tiempo pendiente
    Private Sub Calcular_Dias_Cancel()
        With Dgv01
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("Saldo").Value) = 0 And Val(.Rows(i).Cells("c_anula_reg").Value) = 0 Then
                    If Len(.Rows(i).Cells("Fecha-Pago").Value.ToString) > 0 Then
                        .Rows(i).Cells("Dias").Value = DateDiff("d", .Rows(i).Cells("Fecha Emision").Value, .Rows(i).Cells("Fecha-Pago").Value)
                    End If
                End If
            Next
        End With
    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Saldo As String = "" : Dim Anula As String = "" : Dim Fecha As String = "" : Dim Cliente As String = ""
        Dim Saldo2 As String = "" : Dim vendedor As String = ""
        'Amortizados o cancelados...
        If Rdb03.Checked = True Then
            Saldo = " and B.c_cancel_bol IN(0,2) "
            Saldo2 = " and B.c_opc_cancel IN(0,2) "
        End If

        If Rdb04.Checked = True Then
            Saldo = " and B.c_cancel_bol NOT IN(0,2) "
            Saldo2 = " and B.c_opc_cancel NOT IN(0,2) "
        End If

        'Facturas Anuladas...
        If Rdb05.Checked = True Then Anula = " and B.c_anula_reg=0 "
        If Rdb06.Checked = True Then
            Anula = " and B.c_anula_reg=1 " : Saldo = " "
        End If
        If Len(TxtClie.Text) > 0 Then Cliente = " And Cl.c_codi_clie ='" & TxtCod_Clie.Text & "' "
        'Fecha de emision
        Fecha = " and B.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and B.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        ' Vendedor '
        If Len(CboVendedor.Text) > 0 Then vendedor = " and B.c_codi_vende='" & CboVendedor.SelectedValue & "' "

        Call Cargar_Grid(Saldo & Anula & Fecha & Cliente & vendedor, Saldo2 & Anula & Fecha & Cliente & vendedor)
    End Sub
    'Mostramos los datos de la factura al presionar la tecla enter...
    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtFactura.Text) > 0 Then
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Call Cargar_Grid(" and B.c_nro_boleta='" & TxtFactura.Text & "' and B.c_nro_serie='" & CboSerie.Text & "'",
                                 " and B.c_nro_doc='" & TxtFactura.Text & "' and B.c_nro_serie='" & CboSerie.Text & "'")
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

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            TxtRuta.Text = Folder01.SelectedPath
        End If
    End Sub
    ' Abrimos '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Boletas.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Boletas.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros '
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
    ' Impresion de Boletas
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Saldo As String = "" : Dim Anula As String = "" : Dim Fecha As String = "" : Dim Cliente As String = ""
        Dim Titulo As String = "" : Dim Saldo2 As String = "" : Dim vendedor As String = ""
        'Amortizados o cancelados...
        If Rdb03.Checked = True Then
            Saldo = " and B.c_cancel_bol IN(0,2) "
            Saldo2 = " and B.c_opc_cancel IN(0,2) "
            Titulo = "Listado de Boletas Pendientes - Amortizados DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        If Rdb04.Checked = True Then
            Saldo = " and B.c_cancel_bol NOT IN(0,2) "
            Saldo2 = " and B.c_opc_cancel NOT IN(0,2) "
            Titulo = "Listado de Boletas Canceladas DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If

        'Facturas Anuladas...
        If Rdb05.Checked = True Then Anula = " and B.c_anula_reg=0 "
        If Rdb06.Checked = True Then
            Titulo = "Listado de Boletas Anuladas DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
            Anula = " and B.c_anula_reg=1 " : Saldo = " "
        End If
        If Len(TxtClie.Text) > 0 Then Cliente = " And Cl.c_codi_clie ='" & TxtCod_Clie.Text & "' "
        'Fecha de emision
        Fecha = " and B.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and B.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        ' Vendedor '
        If Len(CboVendedor.Text) > 0 Then vendedor = " and B.c_codi_vende='" & CboVendedor.SelectedValue & "' "
        Dim Cadena As String = ""
        Cadena = Saldo & Anula & Fecha & Cliente & vendedor
        c_neg_BolCab.get_BolCab_Datos(Cadena, "RPT", Cadena)
        Call Cargar_Grid(Saldo & Anula & Fecha & Cliente & vendedor, Saldo2 & Anula & Fecha & Cliente & vendedor)
        FrmReportes.Reporte_ListaDoc(Titulo, "NRO. BOLETA", TxtTot_03.Text, TxtTot_04.Text,
                                     TxtTot_07.Text, TxtTot_08.Text, TxtTot_05.Text, TxtTot_06.Text)
    End Sub

    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
        FrmConClientes.TxtVar.Text = 12 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub
End Class