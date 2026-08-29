Public Class FrmRepEnvasesEstado
    Dim x As Integer = 0
    Private Sub BtnConLinea_Click(sender As System.Object, e As System.EventArgs) Handles BtnConLinea.Click
        With FrmConLineas
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 order by c_desc_linea") : .TxtVar.Text = 3
        End With
    End Sub

    Private Sub BtnConFamilia_Click(sender As System.Object, e As System.EventArgs) Handles BtnConFamilia.Click
        With FrmConFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text & "' order by c_desc_familia")
            .TxtVar.Text = 3
        End With
    End Sub

    Private Sub BtnConSFamilia_Click(sender As System.Object, e As System.EventArgs) Handles BtnConSFamilia.Click
        With FrmConSFamilia
            .MdiParent = FrmMenu : .Show() : .Cargar_Grid(" and c_anula_reg=0 and c_codi_linea='" & TxtCod_Linea.Text &
                "' and c_codi_familia='" & TxtCod_Familia.Text & "' order by c_desc_sfamilia")
            .TxtVar.Text = 3 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
        End With
    End Sub

    Private Sub BtnConArt_Click(sender As System.Object, e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArt
            .MdiParent = FrmMenu : .Show()
            .Cargar_Grid(" and A.c_anula_reg=0 and c_codi_linea like '%" & TxtCod_Linea.Text &
               "%' and c_codi_familia like '%" & TxtCod_Familia.Text & "%' and c_codi_sfamilia like '%" & TxtCod_SFamilia.Text & "%' order by c_desc_articulo")
            ' .Cargar_Grid("")
            .TxtVar.Text = 3 : .Txtcod_Linea.Text = TxtCod_Linea.Text : .TxtCod_Familia.Text = TxtCod_Familia.Text
            .TxtCod_Sfamilia.Text = TxtCod_SFamilia.Text
        End With
    End Sub
    ' cargamos registros '
    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid("REL") : Pan10.Visible = False
    End Sub
    ' METODO PARA CONFIGURAR GRID
    Public Sub Cargar_Grid(ByVal vOpt As String)
        With Dgv01
            .DataSource = c_Neg_AlmSalTADet.get_AlmSalEnvases_Datos(DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCod_Clie.Text, "", TxtCod_Linea.Text,
                                                                    TxtCod_Familia.Text, TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, vOpt)
            .Columns("Nro.Guia").Width = 75
            .Columns("Fecha").Width = 110
            .Columns("Cliente").Width = 180
            .Columns("Direccion").Width = 140
            .Columns("Articulo").Width = 180
            .Columns("Cantidad").Width = 50
            .Columns("Devol.").Width = 50
            .Columns("Saldo").Width = 50
            '   .Columns("Observaciones").Width = 100
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

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' mostramos registros '
    Private Sub Mostrar_Devolucion()
        If Dgv01.RowCount > 0 Then
            Dim F As Integer = Dgv01.CurrentCellAddress.Y
            If F > -1 Then
                Dgv02.DataSource = c_Neg_AlmSalTADet.get_AlmSalTaDet_Datos(" and D.c_correl_sal='" & Dgv01.Rows(F).Cells("c_nro_correl").Value & "'", "DEV", "")
                With Dgv02
                    .Columns("Ingreso").Width = 60
                    .Columns("Guia-Devol.").Width = 90
                    .Columns("Fecha").Width = 80
                    .Columns("Cliente").Width = 220
                    .Columns("Articulo").Width = 200
                    .Columns("Devol.").Width = 80
                    .Columns("Observaciones").Width = 210
                    ' Alineacion '
                    .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Guia-Devol.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Devol.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End If
        End If
    End Sub
    Private Sub Dgv01_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
            Call Mostrar_Devolucion()
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

    Private Sub FrmRepEnvasesEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboClie)
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

    Private Sub FrmRepEnvasesEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub TxtCod_Linea_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Linea.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Linea.Text) = 0 Then
                x = 1 : TxtCod_Familia.Focus()
                TxtLinea.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Familia_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Familia.TextChanged

    End Sub

    Private Sub TxtCod_Familia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Familia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Familia.Text) = 0 Then
                x = 1 : TxtCod_SFamilia.Focus()
                TxtFamilia.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_SFamilia_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_SFamilia.TextChanged

    End Sub

    Private Sub TxtCod_SFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_SFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_SFamilia.Text) = 0 Then
                x = 1 : BtnMostrar.Focus()
                TxtSFamilia.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Familia_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_Familia.LostFocus
        If x = 1 Then
            x = 0
            TxtCod_Familia.Focus()
        End If
    End Sub

    Private Sub TxtCod_SFamilia_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_SFamilia.LostFocus
        If x = 1 Then
            x = 0
            TxtCod_SFamilia.Focus()
        End If
    End Sub

    Private Sub BtnMostrar_LostFocus(sender As Object, e As EventArgs) Handles BtnMostrar.LostFocus
        If x = 1 Then
            x = 0
            BtnMostrar.Focus()
        End If
    End Sub

    Private Sub BtnImp_Click(sender As Object, e As EventArgs) Handles BtnImp.Click
        Pan10.Visible = True : LnkImpAgrArt.Focus()
    End Sub

    Private Sub LnkImpAgrArt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkImpAgrArt.LinkClicked
        FrmReportes.Close()
        FrmReportes.Reporte_Envases_Estado("Reporte de Envases Detallado: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text, DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text,
                                        TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, "DET")
        Pan10.Visible = False
    End Sub

    Private Sub TxtGuia_TextChanged(sender As Object, e As EventArgs) Handles TxtGuia.TextChanged

    End Sub

    Private Sub LnkImpAgrClie_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkImpAgrClie.LinkClicked
        FrmReportes.Close()
        FrmReportes.Reporte_Envases_Estado_Diario("Reporte de Envases Diario: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text, DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), TxtCod_Clie.Text, TxtCod_Linea.Text, TxtCod_Familia.Text,
                                        TxtCod_SFamilia.Text, Txtcod_Articulo.Text, TxtSerie_Guia.Text, TxtGuia.Text, "DET")
        Pan10.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Call LnkImpAgrArt_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Call LnkImpAgrClie_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub FrmRepEnvasesEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Pan10.Visible = False
    End Sub
End Class