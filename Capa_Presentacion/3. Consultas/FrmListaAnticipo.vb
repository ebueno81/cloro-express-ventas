Public Class FrmListaAnticipo
    Private Sub FrmListaAnticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 ", CboDoc)
        CboDoc.SelectedIndex = 0
        Dgv03.Rows.Add()
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        Dim vOpt As String = "" : Dim Anula As String = "" : Dim Fecha As String = "" : Dim Cliente As String = ""
        Dim Serie As String = "" : Dim vende As String = ""
        ' Validamos su hay vendededor activo
        If Len(CboVende.Text) > 0 Then vende = " and C.c_codi_vende ='" & CboVende.SelectedValue & "' "
        'Amortizados o cancelados...
        If Rdb03.Checked = True Then vOpt = "AN2"
        If Rdb04.Checked = True Then vOpt = "ANC"
        'Facturas Anuladas...
        If Rdb05.Checked = True Then Anula = " and C.c_anula_reg=0 "
        If Rdb06.Checked = True Then
            Anula = " and C.c_anula_reg=1 " : vOpt = "ANU"
        End If
        If Len(TxtClie.Text) > 0 Then Cliente = " And Cl.c_desc_clie like '%" & TxtClie.Text & "%' "
        'Fecha de emision
        Fecha = " and C.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and C.c_fecha_emi<='" & DtpFec_Final.Text & "' "

        Call Cargar_Grid(Serie & Anula & Fecha & Cliente & vende, vOpt)

    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String, ByVal vOpt As String)
        With Dgv01

            If CboDoc.SelectedValue = "01" Then .DataSource = c_Neg_FactCab.get_FactCab_Datos(Cadena, vOpt, "")
            If CboDoc.SelectedValue = "02" Then .DataSource = c_Neg_BolCab.get_BolCab_Datos(Cadena, vOpt, "")

            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Vendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Facturado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                If .Rows(i).Cells(" ").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_3 = Tot_3 + Val(.Rows(i).Cells("Total").Value)
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Facturado").Value)
                    Tot_7 = Tot_7 + Val(.Rows(i).Cells("Saldo").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_4 = Tot_4 + Val(.Rows(i).Cells("Total").Value)
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Facturado").Value)
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

            .Columns("Serie").Width = 50
            .Columns("Documento").Width = 70
            .Columns("Cliente").Width = 300
            .Columns("Fecha").Width = 100
            .Columns("Vendedor").Width = 100

            .Columns(" ").Width = 30
            .Columns("Total").Width = 80
            .Columns("Facturado").Width = 80
            .Columns("Saldo").Width = 80

            .Columns("c_anula_reg").Visible = False
            .Columns("Documento").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Documento").HeaderCell.Style.ForeColor = Color.Blue
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
        If ChkMostrar.Checked = True Then Call MostrarDetalles()
    End Sub
    Private Sub MostrarDetalles()
        With Dgv01
            Dgv02.DataSource = Nothing
            If .RowCount > 0 Then
                Dim F As Integer = .CurrentCellAddress.Y
                If F > -1 Then
                    ' Facturas '
                    If CboDoc.SelectedValue = "01" Then
                        Dgv02.DataSource = c_Neg_FactAnexo.get_FactAnexo_Datos(" AND A.c_anula_reg=0 and A.c_serie_anexo='" & .Rows(F).Cells("Serie").Value &
                                                                             "' and A.c_factura_anexo='" & .Rows(F).Cells("Documento").Value & "' ", "DET")
                    End If
                    ' Boletas '
                    If CboDoc.SelectedValue = "02" Then
                        Dgv02.DataSource = c_Neg_BolAnexo.get_BolAnexo_Datos(" AND A.c_anula_reg=0 and A.c_serie_anexo='" & .Rows(F).Cells("Serie").Value &
                                                                             "' and A.c_boleta_anexo='" & .Rows(F).Cells("Documento").Value & "' ", "DET")
                    End If
                    With Dgv02
                        .Columns("Fecha").Width = 70
                        .Columns("Cliente").Width = 160
                        .Columns("Documento").Width = 100
                        .Columns("Total").Width = 60
                        .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With
                    Call CalcularDetalles()
                    ' Validamos Visibilidad '
                    If Dgv02.RowCount > 0 Then
                        Dgv02.Visible = True : Dgv03.Visible = True
                    Else
                        Dgv02.Visible = False : Dgv03.Visible = False
                    End If
                End If
            End If
        End With

    End Sub
    Private Sub CalcularDetalles()
        With Dgv02
            Dim Conta As Integer = 0
            Dim TotalDet As Decimal = 0
            For i = 0 To .RowCount - 1
                TotalDet = TotalDet + Val(.Rows(i).Cells("Total").Value)
            Next
            Dgv03.Rows(0).Cells("Total").Value = Format(TotalDet, Forma_2_2)
            Dgv03.Rows(0).Cells("Conta").Value = Dgv02.RowCount
            Dgv03.Rows(0).Cells("Titulo").Value = "Totales"

        End With
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

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            TxtRuta.Text = Folder01.SelectedPath
        End If
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnImp_Click(sender As Object, e As EventArgs) Handles BtnImp.Click
        MsgBox("Modulo pendiente por definir con el usuario...", vbExclamation, Compañia)
    End Sub

    Private Sub TxtFactura_TextChanged(sender As Object, e As EventArgs) Handles TxtFactura.TextChanged

    End Sub

    Private Sub TxtFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFactura.KeyDown

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub FrmListaAnticipo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dgv02.Visible = False : Dgv03.Visible = False
        End If
    End Sub

    Private Sub ChkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMostrar.CheckedChanged
        If ChkMostrar.Checked = True Then
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        Else
            Dgv02.Visible = False : Dgv03.Visible = False
        End If
    End Sub
End Class