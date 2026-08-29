Public Class FrmRepEnvases

    Private Sub FrmRepEnvases_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Pan10.Visible = False
        End If
    End Sub

    Private Sub FrmRepEnvases_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_mnmtmov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMt)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboClie)
        CboMt.SelectedIndex = -1
    End Sub


    Private Sub BtnConLinea_Click(sender As System.Object, e As System.EventArgs) Handles BtnConLinea.Click
        With FrmConLineas
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 order by c_desc_linea") : .TxtVar.Text = 1
        End With
    End Sub

    Private Sub BtnConFamilia_Click(sender As System.Object, e As System.EventArgs) Handles BtnConFamilia.Click
        With FrmConFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text & "' order by c_desc_familia")
            .TxtVar.Text = 1
        End With
    End Sub

    Private Sub BtnConSFamilia_Click(sender As System.Object, e As System.EventArgs) Handles BtnConSFamilia.Click
        With FrmConSFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text & _
                "' and c_codi_familia='" & TxtCod_Familia.Text & "' order by c_desc_sfamilia")
            .TxtVar.Text = 1 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
        End With
    End Sub

    Private Sub BtnConArt_Click(sender As System.Object, e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArt
            .MdiParent = FrmMenu : .Show()
            .Cargar_Grid(" and A.c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text & _
               "' and c_codi_familia='" & TxtCod_Familia.Text & "' and c_codi_sfamilia='" & TxtCod_SFamilia.Text & "' order by c_desc_articulo")
            .Cargar_Grid("")
            .TxtVar.Text = 1 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
            .TxtCod_Sfamilia.Text = TxtCod_SFamilia.Text
        End With
    End Sub
    ' cargamos registros '
    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click
        If Len(CboMt.Text) > 0 Then
            Call Cargar_Grid("MOT")
        Else
            Call Cargar_Grid("CLI")
        End If
    End Sub
    ' METODO PARA CONFIGURAR GRID
    Public Sub Cargar_Grid(ByVal vOpt As String)
        With Dgv01
            .DataSource = c_Neg_AlmSalTADet.get_AlmSalEnvases_Datos(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Clie.Text, TxtCod_Mt.Text, TxtCod_Linea.Text, _
                                                                    TxtCod_Familia.Text, TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, vOpt)
            .Columns("Nro.Guia").Width = 75
            .Columns("Fecha").Width = 110
            .Columns("Cliente").Width = 180
            .Columns("Direccion").Width = 140
            .Columns("Articulo").Width = 180
            .Columns("Cantidad").Width = 50
            .Columns("Devol.").Width = 50
            .Columns("Saldo").Width = 50
            .Columns("Observaciones").Width = 100
            ' Alineacion
            .Columns("Nro.Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Devol.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' calcular totales
            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' metodo para calcular totales
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            For i = 0 To .RowCount - 1
                Tot_2 = Tot_2 + Val(.Rows(i).Cells("Cantidad").Value)
                Tot_4 = Tot_4 + Val(.Rows(i).Cells("Devol.").Value)
                Tot_8 = Tot_8 + Val(.Rows(i).Cells("Saldo").Value)
            Next
            TxtTot_06.Text = Format(Val(Tot_2), Forma_2_2)
            TxtTot_08.Text = Format(Val(Tot_4), Forma_2_2)
            TxtSaldo.Text = Format(Val(Tot_8), Forma_2_2)
        End With

    End Sub
    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
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
    ' Coloreamos si registro se encuentra anulado '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        ' Call Grid_Registros_anulados(Dgv01)
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
                TxtRuta.Text = Folder01.SelectedPath & "Salidas_Envases.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Salidas_Envases.XLS"
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

    Private Sub CboMt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboMt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(CboMt.Text) = 0 Then TxtCod_Mt.Clear()
        End If
    End Sub

    Private Sub CboMt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboMt.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboMt_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboMt.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboMt, TxtCod_Mt)
    End Sub

    Private Sub CboClie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboClie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(CboClie.Text) = 0 Then TxtCod_Clie.Clear()
        End If
    End Sub

    Private Sub CboClie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboClie.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboClie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboClie.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboClie, TxtCod_Clie)
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

    Private Sub BtnImp_Click(sender As System.Object, e As System.EventArgs) Handles BtnImp.Click
        Pan10.Visible = True
    End Sub

    Private Sub LnkImpAgrOfi_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpAgrOfi.LinkClicked
        Dim vOpt As String = ""
        If Len(CboMt.Text) > 0 Then
            vOpt = "MOT"
        Else
            vOpt = "CLI"
        End If
        FrmReportes.Reporte_Envases("Estado de Cuenta de Envases por Clientes Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text, _
                                    TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, vOpt)
    End Sub

    Private Sub LnkImpAgrClie_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpAgrClie.LinkClicked
        FrmReportes.Reporte_Envases_Clientes("Estado de Cuenta de Envases por Clientes Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text, _
                                    TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, "TOT")
    End Sub
    ' Reporte de envases por Artículos '
    Private Sub LnkImpAgrArt_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImpAgrArt.LinkClicked
        FrmReportes.Reporte_Envases_Articulos("Reporte de Envases por Artículos: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text, _
                                    TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, "ART")
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub TxtCod_Linea_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Linea.TextChanged

    End Sub

    Private Sub TxtCod_Linea_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Linea.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Linea.Text) = 0 Then
                TxtLinea.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Familia_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Familia.TextChanged

    End Sub

    Private Sub TxtCod_Familia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Familia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Familia.Text) = 0 Then
                TxtFamilia.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_SFamilia_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_SFamilia.TextChanged

    End Sub

    Private Sub TxtCod_SFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_SFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_SFamilia.Text) = 0 Then
                TxtSFamilia.Clear()
            End If
        End If
    End Sub
End Class