Public Class FrmRepVtasGerencial
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnConTg_Click(sender As System.Object, e As System.EventArgs) Handles BtnConTg.Click
        With FrmConTg
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
            .TxtVar.Text = 2
        End With
    End Sub

    Private Sub BtnConCd_Click(sender As System.Object, e As System.EventArgs) Handles BtnConCd.Click
        With FrmConCd
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCodTg.Text & "' order by c_desc_cd")
            .TxtCod_Tg.Text = TxtCodTg.Text : .TxtVar.Text = 2
        End With
    End Sub

    Private Sub BtnConScd_Click(sender As System.Object, e As System.EventArgs) Handles BtnConScd.Click
        With FrmConScd
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCodTg.Text &
                "' and S.c_codi_cd='" & TxtCodCd.Text & "' order by c_desc_scd")
            .TxtVar.Text = 2 : .TxtCod_Tg.Text = TxtCodTg.Text : .TxtCod_Cd.Text = TxtCodCd.Text
        End With
    End Sub

    Private Sub BtnConClie_Click(sender As Object, e As EventArgs) Handles BtnConClie.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
        FrmConClientes.TxtVar.Text = 13 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub

    Private Sub FrmRepVtasGerencial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmRepVtasGerencial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub TxtCodClie_TextChanged(sender As Object, e As EventArgs) Handles TxtCodClie.TextChanged

    End Sub

    Private Sub TxtCodClie_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodClie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCodClie.Text) = 0 Then
                TxtClie.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCodTg_TextChanged(sender As Object, e As EventArgs) Handles TxtCodTg.TextChanged

    End Sub

    Private Sub TxtCodTg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodTg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCodTg.Text) = 0 Then
                TxtTg.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCodCd_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCd.TextChanged

    End Sub

    Private Sub TxtCodCd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodCd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCodCd.Text) = 0 Then
                TxtCd.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCodScd_TextChanged(sender As Object, e As EventArgs) Handles TxtCodScd.TextChanged

    End Sub

    Private Sub TxtCodScd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodScd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCodScd.Text) = 0 Then
                TxtScd.Clear()
            End If
        End If
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        If CboTpo.SelectedIndex = 0 Then Call Cargar_Grid_Articulos()
        If CboTpo.SelectedIndex = 1 Then Call Cargar_Grid_Clientes()


    End Sub
    Private Sub Cargar_Grid_Articulos()
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "CAB")
            Dgv01.DataSource = Nothing
            Dgv01.Columns.Clear()
            Dgv01.Columns.Add("Codigo", "Codigo")
            Dgv01.Columns.Add("Articulo", "Articulo")
            Dgv01.Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For I = 0 To .Rows.Count - 1
                Dgv01.Columns.Add(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate), FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate))
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).Width = 75
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Next
            Dgv01.Columns.Add("Total", "Total")
            Dgv01.Columns.Add("Stock", "Stock")
            Dgv01.Columns("Total").Width = 65
            Dgv01.Columns("Stock").Width = 65

            Dgv01.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dgv01.Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            Dgv01.Columns("Codigo").Width = 65
            Dgv01.Columns("Articulo").Width = 200
        End With
        ' cargamos los items de articulos '
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "ART")
            For i = 0 To .Rows.Count - 1
                Dgv01.Rows.Add()
                Dgv01.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                Dgv01.Rows(i).Cells("Articulo").Value = .Rows(i)("c_desc_articulo").ToString
                Dgv01.Rows(i).Cells("Stock").Value = Format(Val(.Rows(i)("c_cant_stock").ToString), Forma_2_0)
            Next
        End With
        ' cargamos el detalle '
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "DET")
            For i = 0 To .Rows.Count - 1
                For u = 0 To Dgv01.RowCount - 1
                    ' validamos si coincide el codigo de articulo '
                    If Dgv01.Rows(u).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString Then
                        Dgv01.Rows(u).Cells(FormatDateTime(.Rows(i)("c_fecha_emi").ToString, DateFormat.ShortDate)).Value = Format(Val(.Rows(i)("Kg.").ToString), Forma_1_2)
                        u = Dgv01.RowCount
                    End If
                Next
            Next
        End With
        ' Calculamos totales por columnas '
        With Dgv01
            For i = 0 To .RowCount - 1
                Dim TotCol As Decimal = 0
                For u = 2 To .ColumnCount - 2
                    TotCol = TotCol + Val(.Rows(i).Cells(u).Value)
                Next
                .Rows(i).Cells("Total").Value = Format(TotCol, Forma_1_2)
            Next
        End With


        ' Calculamos  los totales por filas y detalles '
        With Dgv01
            .Rows.Add()
            Dim pos As Integer = .RowCount - 1
            Dim Tot As Decimal = 0
            .Rows(pos).Cells("Articulo").Value = "TOTAL REGISTRO:"
            For i = 2 To .ColumnCount - 1
                For u = 0 To .RowCount - 2
                    Tot = Tot + Val(.Rows(u).Cells(i).Value)
                Next
                .Rows(pos).Cells(i).Value = Format(Tot, Forma_1_2)
                Tot = 0
            Next
            Dim ColTot, ColStock As Integer
            ColTot = Dgv01.ColumnCount - 2
            ColStock = Dgv01.ColumnCount - 1
            For i = 0 To .RowCount - 1
                For u = 0 To .ColumnCount - 1
                    ' Columna Codigo y articulo '
                    If u = 0 Or u = 1 Then
                        .Rows(i).Cells(u).Style.BackColor = Color.PapayaWhip
                        .Rows(i).Cells(u).Style.BackColor = Color.PapayaWhip
                    Else
                        If u = ColTot Or u = ColStock Then
                            .Rows(i).Cells(u).Style.BackColor = Color.Gainsboro
                        Else
                            .Rows(i).Cells(u).Style.BackColor = Color.White
                        End If
                    End If
                Next
            Next

            .Rows(pos).DefaultCellStyle.BackColor = Color.Gainsboro
            .Rows(pos).DefaultCellStyle.ForeColor = Color.Maroon
        End With

    End Sub
    Private Sub Cargar_Grid_Clientes()
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "CAB")
            Dgv01.DataSource = Nothing
            Dgv01.Columns.Clear()
            Dgv01.Rows.Clear()
            Dgv01.Columns.Add("Codigo", "Codigo")
            Dgv01.Columns.Add("Cliente", "Cliente")
            Dgv01.Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For I = 0 To .Rows.Count - 1
                Dgv01.Columns.Add(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate), FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate))
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).Width = 75
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dgv01.Columns(FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Next
            Dgv01.Columns.Add("Total", "Total")
            Dgv01.Columns("Total").Width = 65
            Dgv01.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dgv01.Columns("Codigo").Width = 65
            Dgv01.Columns("Cliente").Width = 200
        End With
        ' cargamos los items de articulos '
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "CLC")
            For i = 0 To .Rows.Count - 1
                Dgv01.Rows.Add()
                Dgv01.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_clie").ToString
                Dgv01.Rows(i).Cells("Cliente").Value = .Rows(i)("c_desc_clie").ToString
            Next
        End With
        ' cargamos el detalle '
        With c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, "CLI")
            For i = 0 To .Rows.Count - 1
                For u = 0 To Dgv01.RowCount - 1
                    ' validamos si coincide el codigo de articulo '
                    If Dgv01.Rows(u).Cells("Codigo").Value = .Rows(i)("c_codi_clie").ToString Then
                        Dgv01.Rows(u).Cells(FormatDateTime(.Rows(i)("c_fecha_emi").ToString, DateFormat.ShortDate)).Value = Format(Val(.Rows(i)("Kg.").ToString), Forma_1_2)
                        u = Dgv01.RowCount
                    End If
                Next
            Next
        End With
        ' Calculamos totales por columnas '
        With Dgv01
            For i = 0 To .RowCount - 1
                Dim TotCol As Decimal = 0
                For u = 2 To .ColumnCount - 1
                    TotCol = TotCol + Val(.Rows(i).Cells(u).Value)
                Next
                .Rows(i).Cells("Total").Value = Format(TotCol, Forma_1_2)
            Next
        End With


        ' Calculamos  los totales por filas y detalles '
        With Dgv01
            .Rows.Add()
            Dim pos As Integer = .RowCount - 1
            Dim Tot As Decimal = 0
            .Rows(pos).Cells("Cliente").Value = "TOTAL REGISTRO:"
            For i = 2 To .ColumnCount - 1
                For u = 0 To .RowCount - 2
                    Tot = Tot + Val(.Rows(u).Cells(i).Value)
                Next
                .Rows(pos).Cells(i).Value = Format(Tot, Forma_1_2)
                Tot = 0
            Next
            Dim ColTot, ColStock As Integer
            ColTot = Dgv01.ColumnCount - 1
            For i = 0 To .RowCount - 1
                For u = 0 To .ColumnCount - 1
                    ' Columna Codigo y articulo '
                    If u = 0 Or u = 1 Then
                        .Rows(i).Cells(u).Style.BackColor = Color.PapayaWhip
                        .Rows(i).Cells(u).Style.BackColor = Color.PapayaWhip
                    Else
                        If u = ColTot Or u = ColStock Then
                            .Rows(i).Cells(u).Style.BackColor = Color.Gainsboro
                        Else
                            .Rows(i).Cells(u).Style.BackColor = Color.White
                        End If
                    End If
                Next
            Next

            .Rows(pos).DefaultCellStyle.BackColor = Color.Gainsboro
            .Rows(pos).DefaultCellStyle.ForeColor = Color.Maroon
        End With

    End Sub
    Private Sub Cargar_Grid(ByVal vOpt As String)
        With Dgv01
            .DataSource = Nothing : .Columns.Clear()
            .DataSource = c_Neg_AlmSalTADet.get_AlmSalGerencial_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCodClie.Text, TxtCodTg.Text,
                                                                    TxtCodCd.Text, TxtCodScd.Text, vOpt)
            .Columns("Guia R.").Width = 75
            .Columns("Documento").Width = 75
            .Columns("Motivo").Width = 80
            .Columns("Fecha").Width = 80
            .Columns("Cliente").Width = 135
            .Columns("Codigo").Width = 65
            .Columns("Articulo").Width = 135
            .Columns("Bultos").Width = 45
            .Columns("Cantidad").Width = 75
            .Columns("_").Width = 30
            .Columns("Precio").Width = 65
            .Columns("Total").Width = 75
            ' Alineacion de Columnas '
            .Columns("Guia R.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("_").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Bultos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Columnas Visibles '
            .Columns("Codi_Clie").Visible = False
            '.Columns("c_codi_tg").Visible = False : .Columns("c_codi_cd").Visible = False
            '.Columns("c_desc_cd").Visible = False
            '.Columns("c_desc_tg").Visible = False : .Columns("c_codi_scd").Visible = False

            Call Calcular_Totales() ': Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' Calculamos Totales '
    Private Sub Calcular_Totales()
        With Dgv01
            TxtConta_1.Clear() : TxtConta_2.Clear()
            TxtTot_05.Clear() : TxtTot_06.Clear() : TxtTot_07.Clear() : TxtTot_08.Clear()
            Dim Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("_").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Cantidad").Value.ToString)
                    Tot_7 = Tot_7 + Val(.Rows(i).Cells("Total").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Cantidad").Value.ToString)
                    Tot_8 = Tot_8 + Val(.Rows(i).Cells("Total").Value.ToString)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1
            TxtConta_2.Text = Tot_Reg_2
            TxtTot_05.Text = Format(Val(Tot_5), Forma_2_2)
            TxtTot_06.Text = Format(Val(Tot_6), Forma_2_2)
            TxtTot_07.Text = Format(Val(Tot_7), Forma_2_2)
            TxtTot_08.Text = Format(Val(Tot_8), Forma_2_2)
        End With
    End Sub
End Class