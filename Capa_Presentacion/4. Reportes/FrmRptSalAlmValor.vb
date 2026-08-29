Public Class FrmRptSalAlmValor
    Private Sub FrmRptSalAlmValor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Pan10.Visible = False
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmRptSalAlmValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptSalAlmValor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_mnmtmov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMt)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboClie)
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        CboAlm.SelectedIndex = 0 : CboMt.SelectedIndex = -1 : CboMon.SelectedIndex = 0
    End Sub

    Private Sub CboMt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Obtenempos el codigo '
    Private Sub CboMt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CboMt.SelectedIndex = -1 Then
            TxtCod_Mt.Clear()
        Else
            TxtCod_Mt.Text = Strings.Right(CboMt.Text, 2)
        End If
    End Sub

    Private Sub CboProve_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub
    ' Abrimos ruta de archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "MovSalidas_Almacen.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\MovSalidas_Almacen.XLS"
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
    ' Cerramos la ventana...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Metodo para ajustar el tamaño del grid '
    Private Sub Cargar_Grid(ByVal vOpt As String)
        With Dgv01
            Dim c_opc_noingsal As String = "" : Dim c_opc_transforma As String = ""
            If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0" ' no incluir producto hipoclorito 01000052
            If ChkOpcTransforma.Checked = True Then c_opc_transforma = "1" ' solo productos de transformacion
            'Sp_Scal_Rpt_SalTADetValor
            .DataSource = c_Neg_AlmSalTADet.get_AlmSalArtValor_Datos(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, TxtCod_Mt.Text, TxtCod_Linea.Text,
                                                                    TxtCod_Familia.Text, TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                                                     CboMon.SelectedValue, c_opc_noingsal, c_opc_transforma, CboAlm.SelectedValue, vOpt)
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
            If FrmMenu.ChkUsuaPrecio.Checked = False Then
                .Columns("Precio").Visible = False
                .Columns("Total").Visible = False
            End If
            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
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
    ' Reporte Detallado '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Pan10.Visible = True
    End Sub
    ' Agrupado por mes '
    Private Sub LnkImpAgrMes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpDetalle.LinkClicked
        Dim Titulo As String = "Reporte de Salidas de Almacén General DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        Dim c_opc_noingsal As String = ""
        Dim c_opc_transforma = ""
        If ChkOpcTransforma.Checked = True Then c_opc_transforma = "1"
        If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
        FrmReportes.Reporte_Articulos_Pantallazo_Valorizado(Titulo, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text,
                                    TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, "VAL", TxtTot_07.Text, TxtTot_08.Text,
                                                 CboMon.SelectedValue, c_opc_noingsal, CboAlm.SelectedValue, c_opc_transforma)
        Pan10.Visible = False
    End Sub
    ' Agrupado por CLIENTE '
    Private Sub LnkImpAgrDia_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpAgrClie.LinkClicked
        With Dgv01
            Dim vOpt As String = "VAL"
            Dim c_opc_noingsal As String = ""
            Dim c_opc_transforma = ""
            If ChkOpcTransforma.Checked = True Then c_opc_transforma = "1"
            If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
            c_Neg_AlmSalTADet.get_AlmSalClie_Datos(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, TxtCod_Mt.Text, TxtCod_Linea.Text,
                                                                    TxtCod_Familia.Text, TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                                   CboMon.SelectedValue, c_opc_noingsal, c_opc_transforma, CboAlm.SelectedValue, vOpt)
            FrmReportes.Reporte_Articulos_Clientes("Venta de Totalizada por Artículos...Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text)
            Pan10.Visible = False
        End With
    End Sub
    ' Reporte de Salida Detallada '
    Private Sub LnkImpTodo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpAgrArt.LinkClicked
        With Dgv01
            Dim vOpt As String = "VAL"
            Dim c_opc_noingsal As String = "" : Dim c_opc_transforma = ""
            If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
            If ChkOpcTransforma.Checked = True Then c_opc_transforma = "1"
            c_Neg_AlmSalTADet.get_AlmSalClie_Datos(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, TxtCod_Mt.Text, TxtCod_Linea.Text,
                                                                    TxtCod_Familia.Text, TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                                   CboMon.SelectedValue, c_opc_noingsal, c_opc_transforma, CboAlm.SelectedValue, vOpt)
            FrmReportes.Reporte_Articulos_Total("Venta de Totalizada por Artículos...Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text)
            Pan10.Visible = False
        End With
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid("VAL")
    End Sub

    Private Sub BtnConArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArt
            .MdiParent = FrmMenu : .Show()
            .TxtVar.Text = 4 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
            .TxtCod_Sfamilia.Text = TxtCod_SFamilia.Text
            .Cargar_Grid(" and A.c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text &
               "' and c_codi_familia='" & TxtCod_Familia.Text & "' and c_codi_sfamilia='" & TxtCod_SFamilia.Text & "' order by c_desc_articulo")

        End With
    End Sub

    Private Sub BtnConTg_Click(sender As System.Object, e As System.EventArgs) Handles BtnConLinea.Click
        With FrmConLineas
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 order by c_desc_linea")
            .TxtVar.Text = 4
        End With
    End Sub

    Private Sub BtnConCd_Click(sender As System.Object, e As System.EventArgs) Handles BtnConFamilia.Click
        With FrmConFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text & "' order by c_desc_familia")
            .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtVar.Text = 4
        End With
    End Sub

    Private Sub BtnConScd_Click(sender As System.Object, e As System.EventArgs) Handles BtnConSFamilia.Click
        With FrmConSFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text &
                "' and c_codi_familia='" & TxtCod_Familia.Text & "' order by c_desc_sfamilia")
            .TxtVar.Text = 4 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
        End With
    End Sub

    Private Sub TxtSerie_Doc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie_Doc.TextChanged

    End Sub

    Private Sub TxtSerie_Guia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie_Guia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtSerie_Guia.Text) > 0 Then
                TxtSerie_Guia.Text = Strings.Right(Val(TxtSerie_Guia.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_Guia_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie_Guia.TextChanged

    End Sub

    Private Sub TxtGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtGuia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtGuia.Text) > 0 Then
                TxtGuia.Text = Strings.Right(Val(TxtGuia.Text) + 10000000, 7)
                Call Cargar_Grid("GUI")
            End If
        End If
    End Sub

    Private Sub TxtGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtGuia.TextChanged

    End Sub
    ' CAMBIAMOS A MAYUSCULAS '
    Private Sub CboClie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboClie.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboClie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboClie.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboClie, TxtCod_Clie)
    End Sub

    Private Sub CboMt_KeyPress1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboMt.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboMt_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles CboMt.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboMt, TxtCod_Mt)
    End Sub

    Private Sub TxtCod_Linea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Linea.KeyDown
        If e.KeyCode = Keys.Enter Then If Len(TxtCod_Linea.Text) = 0 Then TxtLinea.Clear()
    End Sub

    Private Sub TxtCod_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_Linea.TextChanged

    End Sub

    Private Sub TxtCod_Familia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Familia.KeyDown
        If e.KeyCode = Keys.Enter Then If Len(TxtCod_Familia.Text) = 0 Then TxtFamilia.Clear()
    End Sub

    Private Sub TxtCod_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_Familia.TextChanged

    End Sub

    Private Sub TxtCod_SFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_SFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then If Len(TxtCod_SFamilia.Text) = 0 Then TxtSFamilia.Clear()
    End Sub

    Private Sub TxtCod_SFamilia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_SFamilia.TextChanged

    End Sub

    Private Sub Txtcod_Articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtcod_Articulo.KeyDown
        If e.KeyCode = Keys.Enter Then If Len(Txtcod_Articulo.Text) = 0 Then TxtArticulo.Clear()
    End Sub

    Private Sub ChkOpcTransforma_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOpcTransforma.CheckedChanged

    End Sub
End Class