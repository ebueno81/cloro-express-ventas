Public Class FrmRepGuiasxFact
    Dim vOpt As String = "" : Dim Titulo As String = ""

    Private Sub FrmRepGuiasxFact_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then Call BtnImp_Click(Nothing, Nothing) ' IMPRIMIR
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmRepGuiasxFact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRepGuiasxFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeriesGuias.get_Series_Cbo(" and c_anula_reg=0 order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboCliente)
        CboSerie.SelectedIndex = 0
    End Sub
    ' Buscamos por abreviatura de clientes '
    Private Sub TxtBus_Abrev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Abrev.KeyDown
        If Len(TxtBus_Abrev.Text) > 0 Then
            Call Mostrar_Cliente_Busca_Abrev(TxtBus_Abrev.Text, CboCliente, TxtCod_Clie)
        Else
            CboCliente.SelectedValue = "" : TxtCod_Clie.Clear()
        End If
    End Sub

    Private Sub TxtBus_Abrev_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Abrev.TextChanged

    End Sub
    '--> Cliente <--'
    Private Sub CboCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCliente.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    '--> Cliente <--'
    Private Sub CboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCliente.SelectedIndexChanged
        If Len(CboCliente.Text) > 0 Then
            Call Combo_Jalar_Codigo(CboCliente, TxtCod_Clie)
            Call Mostrar_Cliente_Abrev(TxtCod_Clie.Text, TxtBus_Abrev)
        End If
    End Sub

    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If Len(TxtFactura.Text) > 0 Then
            If e.KeyCode = Keys.Enter Then
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Dgv01.DataSource = c_Neg_AlmSalTA.get_AlmSalTa_Rpt(CboSerie.Text, TxtFactura.Text, "", DtpFec_Inicio.Text, DtpFec_Final.Text, _
                TxtCod_Clie.Text, 0, "GUI")
                Call Configurar_Grid() : TxtIngreso.Clear()
                vOpt = "GUI" : Titulo = "Listado de Guías de Remisión Pendientes por Facturar "
            End If
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub

    Private Sub TxtIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIngreso.KeyDown
        If Len(TxtIngreso.Text) > 0 Then
            If e.KeyCode = Keys.Enter Then
                TxtIngreso.Text = Strings.Right(Val(TxtIngreso.Text) + 10000000, 7)
                Dgv01.DataSource = c_Neg_AlmSalTA.get_AlmSalTa_Rpt(CboSerie.Text, TxtFactura.Text, TxtIngreso.Text, DtpFec_Inicio.Text, DtpFec_Final.Text, _
                TxtCod_Clie.Text, 0, "ING")
                Call Configurar_Grid() : TxtFactura.Clear()
                vOpt = "ING" : Titulo = "Listado de Guías de Remisión Pendientes por Facturar "
            End If
        End If
    End Sub

    Private Sub TxtIngreso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIngreso.TextChanged

    End Sub
    ' Metodo para configurar las columnas del grid '
    Private Sub Configurar_Grid()
        With Dgv01
            .Columns("Fecha Despacho").Width = 120
            .Columns("Guia").Width = 40
            .Columns("Remision").Width = 60
            .Columns("Estado").Width = 80
            .Columns("Cliente").Width = 280
            .Columns("Total($.)").Width = 60
            .Columns("Observaciones").Width = 240
            ' Visible '
            .Columns("c_anula_reg").Visible = False
            ' Alineacion '
            .Columns("Fecha Despacho").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Remision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total($.)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Call Grid_Registros_anulados(Dgv01)
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    ' Cerramos ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Mostrar Listado de Facturar '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim c_anula_Reg As String = ""
        If Rdb02.Checked Then c_anula_Reg = "0"
        If Len(TxtCod_Clie.Text) > 0 Then
            Titulo = "Listado de Guías de Remisión Pendientes por Facturar DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        Else
            Titulo = "Listado de Guías de Remisión Pendientes por Facturar DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        Dgv01.DataSource = c_Neg_AlmSalTA.get_AlmSalTa_Rpt(CboSerie.Text, TxtFactura.Text, TxtIngreso.Text, DtpFec_Inicio.Text, DateAdd("d", 1, DtpFec_Final.Text), _
        TxtCod_Clie.Text, c_anula_Reg, "FYC")

        Call Configurar_Grid() : TxtFactura.Clear() : TxtIngreso.Clear()
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
        Call Grid_Registros_anulados(Dgv01)
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
                TxtRuta.Text = Folder01.SelectedPath & "Listado_GuiasXFacturar.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_GuiasXFacturar.XLS"
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
    ' Imprimimos Reporte de Guías '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim c_anula_reg As String = ""
        If Rdb02.Checked = True Then
            c_anula_reg = 1
        End If
        FrmReportes.Reporte_GuiasPendientes(Titulo, TxtFactura.Text, CboSerie.Text, TxtIngreso.Text, DtpFec_Inicio.Text, _
                                            DtpFec_Final.Text, TxtCod_Clie.Text, c_anula_reg, "FYC")
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click

    End Sub
End Class