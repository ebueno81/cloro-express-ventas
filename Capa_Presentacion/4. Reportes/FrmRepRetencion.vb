Public Class FrmRepRetencion

    Private Sub FrmRepRetencion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRepRetencion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_Reg=0 order by c_desc_clie", CboBusClie)
        DtpFec_Inicio.Text = "01/01/2015"
    End Sub

    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click
        Dim vOpt As String = "" : Dim vrPT As Integer = 0
        ' PENDIENTES DE RECOGER (VENCIDAS)
        If Rdb01.Checked = True Then
            vOpt = "PEN" : vrPT = 0
        End If
        ' facturas EN FECHAS
        If Rdb02.Checked = True Then
            vOpt = "FEC" : vrPT = 0
        End If
        ' RETENCIONES DECLARADAS
        If Rdb03.Checked = True Then
            vOpt = "DEC" : vrPT = 1
        End If
        ' PENDIENTE POR DECLARAR
        If Rdb04.Checked = True Then
            vOpt = "PEN" : vrPT = 1
        End If
        Call Cargar_Grid(vOpt, vrPT)
    End Sub
    ' metodo para cargar grid
    Private Sub Cargar_Grid(ByVal vOpt As String, ByVal vRpt As Integer)
        With Dgv01
            Dim c_codi_clie As String = Txtcod_Clie.Text
            If Len(CboBusClie.Text) = 0 Then c_codi_clie = ""
            ' facturas pendietes de detracciones
            If vRpt = 0 Then
                .DataSource = c_Neg_RetenCab.get_RetenFact_Rpt(c_codi_clie, vOpt)
            End If
            If vRpt = 1 Then
                .DataSource = c_Neg_RetenCab.get_RetenCab_Rpt(c_codi_clie, vOpt, DtpFec_Inicio.Text)
            End If
            .Columns("Tipo").Width = 100
            .Columns("Nro.").Width = 50
            .Columns("Documento").Width = 70

            If vRpt = 1 Then
                .Columns("Cliente").Width = 390
                .Columns("Concar").Width = 60
            Else
                .Columns("Cliente").Width = 450
            End If

            .Columns("Fecha").Width = 80
            .Columns("_").Width = 40
            .Columns("Retencion").Width = 70
            ' visible
            .Columns("c_anula_Reg").Visible = False
            ' alineacion 
            .Columns("Nro.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("_").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Retencion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' metodo para calcular totales
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_1, Tot_2 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
                If .Rows(i).Cells("_").Value = "S/." Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_1 = Tot_1 + Val(.Rows(i).Cells("Retencion").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_2 = Tot_2 + Val(.Rows(i).Cells("Retencion").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_Mn.Text = Format(Val(Tot_1), Forma_2_2)
            TxtTot_Us.Text = Format(Val(Tot_2), Forma_2_2)
        End With
    End Sub
    Private Sub CboBusClie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboBusClie.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboBusClie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboBusClie.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboBusClie, Txtcod_Clie)
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
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Retenciones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Retenciones.XLS"
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

    Private Sub BtnImp_Click(sender As System.Object, e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = "" : Dim c_codi_clie As String = "" : Dim vOpt As String = ""
        Dim vRpt As Integer = 0
        If Len(CboBusClie.Text) > 0 Then c_codi_clie = Txtcod_Clie.Text
        ' RETENCIONES DECLARADAS
        If Rdb03.Checked = True Then
            vOpt = "DEC" : Titulo = "Retenciones Declaras : " & CboBusClie.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If
        ' PENDIENTE POR DECLARAR
        If Rdb04.Checked = True Then
            vOpt = "PEN" : Titulo = "Retenciones Pendientes de Declarar : " & CboBusClie.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If

        ' facturas EN FECHAS
        If Rdb02.Checked = True Then
            vOpt = "FEC" : vRpt = 1
            Titulo = "Retenciones en Fechas : " & CboBusClie.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If
        ' PENDIENTES DE RECOGER
        If Rdb01.Checked = True Then
            vOpt = "PEN" : vRpt = 1
            Titulo = "Retenciones Vencidas : " & CboBusClie.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If

        If vRpt = 0 Then
            FrmReportes.Reporte_Retenciones(Titulo, c_codi_clie, vOpt)
        Else
            FrmReportes.Reporte_RetenFact(Titulo, c_codi_clie, vOpt)
        End If

    End Sub

    Private Sub Rdb01_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb01.CheckedChanged

    End Sub

    Private Sub Rdb01_Click(sender As Object, e As System.EventArgs) Handles Rdb01.Click
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub Rdb02_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb02.CheckedChanged

    End Sub

    Private Sub Rdb02_Click(sender As Object, e As System.EventArgs) Handles Rdb02.Click
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub Rdb03_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb03.CheckedChanged

    End Sub

    Private Sub Rdb03_Click(sender As Object, e As System.EventArgs) Handles Rdb03.Click
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub Rdb04_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb04.CheckedChanged

    End Sub

    Private Sub Rdb04_Click(sender As Object, e As System.EventArgs) Handles Rdb04.Click
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
End Class