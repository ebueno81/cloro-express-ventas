Public Class FrmRptTransforVentas
    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        Call CargarGrid()
    End Sub
    Public Sub CargarGrid()
        With Dgv01
            'Sp_Scal_Rpt_TransVenta
            .DataSource = c_Neg_AlmTransforCab.get_RptTransformaVentas_Datos(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtcodTg.Text,
                                                                             TxtCodCd.Text, TxtCodArt.Text, TxtCod_Alm.Text, "DGV")
            .Columns("Fecha Venta").Width = 70
            .Columns("Factura").Width = 80
            .Columns("Cliente").Width = 130
           ' .Columns("Codigo").Width = 60
            .Columns("Articulo").Width = 260
            .Columns("Venta").Width = 60
            .Columns("Fecha Transforma.").Width = 80
            .Columns("Vale").Width = 60
            .Columns("%").Width = 40
            .Columns("Salida").Width = 75
            .Columns("Ingreso").Width = 75
            ' Alineacion '
         '   .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Factura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fecha Transforma.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Vale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("%").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Call CalcularTotales()
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    Private Sub CalcularTotales()
        With Dgv01

            Dim TotCompra, TotSal, TotIng As Decimal
            For i = 0 To .RowCount - 1
                TotCompra = TotCompra + Val(.Rows(i).Cells("Venta").Value.ToString)
                TotIng = TotIng + Val(.Rows(i).Cells("Ingreso").Value.ToString)
                TotSal = TotSal + Val(.Rows(i).Cells("Salida").Value.ToString)
            Next

            TxtConta_2.Text = .RowCount

            TxtTot_04.Text = Format(TotCompra, Forma_2_2)
            TxtTot_06.Text = Format(TotIng, Forma_2_2)
            TxtTot_08.Text = Format(TotSal, Forma_2_2)

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
                TxtRuta.Text = Folder01.SelectedPath & "ReporteTransformaciones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\ReporteTransformaciones.XLS"
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
        Dim Fecha As String = "" : Dim Articulo As String = ""
        If Len(TxtCodArt.Text) > 0 Then
            Articulo = " - " & TxtArt.Text
        End If
        Titulo = "Reporte de Transformaciones Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text & Articulo & " - [VENTAS]"
        BtnMostrar_Click(Nothing, Nothing)

        FrmReportes.Close()
        FrmReportes.Reporte_TransformaVentas(Titulo)
    End Sub

    Private Sub BtnConTg_Click(sender As Object, e As EventArgs) Handles BtnConTg.Click
        FrmConTg.MdiParent = FrmMenu : FrmConTg.Show() : FrmConTg.TxtVar.Text = 10 : FrmConTg.Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
    End Sub

    Private Sub BtnConCd_Click(sender As Object, e As EventArgs) Handles BtnConCd.Click
        FrmConCd.MdiParent = FrmMenu : FrmConCd.Show() : FrmConCd.TxtVar.Text = 10 : FrmConCd.TxtCod_Tg.Text = TxtcodTg.Text
        FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtcodTg.Text & "' order by c_Desc_cd")
    End Sub

    Private Sub BtnConArt_Click(sender As Object, e As EventArgs) Handles BtnConArt.Click
        FrmConScd.MdiParent = FrmMenu : FrmConScd.Show() : FrmConScd.TxtVar.Text = 3 : FrmConScd.TxtCod_Tg.Text = TxtcodTg.Text
        FrmConScd.TxtCod_Cd.Text = TxtCodCd.Text
        FrmConScd.Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtcodTg.Text & "' and S.c_codi_cd='" & TxtCodCd.Text & "' order by c_desc_scd")
    End Sub

    Private Sub TxtcodTg_TextChanged(sender As Object, e As EventArgs) Handles TxtcodTg.TextChanged

    End Sub

    Private Sub TxtcodTg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtcodTg.KeyDown
        If Val(TxtcodTg.Text) = 0 Then
            TxtTg.Clear() : TxtCodCd.Clear() : TxtCd.Clear()
            TxtCodArt.Clear() : TxtArt.Clear()
        End If
    End Sub

    Private Sub TxtCodCd_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCd.TextChanged

    End Sub

    Private Sub TxtCodCd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodCd.KeyDown
        If Val(TxtCodCd.Text) = 0 Then
            TxtCd.Clear() : TxtCodCd.Clear() : TxtCodArt.Clear() : TxtArt.Clear()
        End If
    End Sub

    Private Sub TxtCodArt_TextChanged(sender As Object, e As EventArgs) Handles TxtCodArt.TextChanged

    End Sub

    Private Sub TxtCodArt_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodArt.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCodArt.Clear() : TxtArt.Clear()
        End If
    End Sub

    Private Sub FrmRptTransforCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        CboAlm.SelectedIndex = 0
    End Sub

    Private Sub FrmRptTransforCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CboAlm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAlm.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboAlm, TxtCod_Alm)
    End Sub
End Class