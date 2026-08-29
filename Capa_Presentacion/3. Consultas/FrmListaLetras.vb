Public Class FrmListaLetras

    Private Sub FrmConLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnBcos.Get_Bcos_Cbo(" and c_anula_reg=0 order by c_desc_bco", CboBanco)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboCliente)
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_desc_stletra", CboEstado)
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        ' " and L.c_nro_liq='" & c_nro_liq & "' order by L.c_nro_liq"
        Dim Fecha As String = "" : Dim Bancos As String = "" : Dim Estado As String = "" : Dim Cliente As String = ""
        Dim Cancel As String = "" : Dim Cancel2 As String = "" : Dim Fecha2 As String = ""
        If Rdb03.Checked = True Then
            Fecha = " And L.c_fecha_giro>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_giro<='" & DtpFec_Final.Text & "' "
            Fecha2 = " And L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        Else
            Fecha = " And L.c_fecha_venci>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_venci<='" & DtpFec_Final.Text & "' "
            Fecha2 = " And L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        End If
        ' Validamos si letras estan pendientes o canceladas '
        If Rdb06.Checked = True Then ' Pendientes
            Cancel = " and L.c_cancel_letra IN (0,2) " : Cancel2 = " and L.c_opc_cancel in (0,2) "
        Else ' Canceladas
            Cancel = " and L.c_cancel_letra=1 " : Cancel2 = " and L.c_opc_cancel=1 "
        End If
        ' Criterio de busqueda para clientes '
        If Len(CboCliente.Text) > 0 Then Cliente = " And Cl.c_codi_clie='" & CboCliente.SelectedValue & "' "
        ' Criterio de busqueda estado de letra '
        If Len(CboEstado.Text) > 0 Then Estado = " And L.c_codi_stletra='" & CboEstado.SelectedValue & "' "
        ' Criterio  de busqueda por banco '
        If Len(CboBanco.Text) > 0 Then Bancos = " And L.c_codi_bco='" & CboBanco.SelectedValue & "' "
        InputBox("", "", " And L.c_anula_reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel & " ")
        Call cargar_Grid(" And L.c_anula_reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel & " ", " And L.c_anula_reg=0 " & Fecha2 & Cliente & Estado & Bancos & Cancel2 & " ")
    End Sub
    Private Sub cargar_Grid(ByVal Cadena As String, ByVal Cadena2 As String)
        With Dgv01
            .DataSource = c_Neg_LetCab.get_LetCab_Datos(Cadena, "LIS", Cadena2)
            .Columns("Letra").Width = 60
            .Columns("Cliente").Width = 150
            .Columns("F.Giro").Width = 90
            .Columns("Dias").Width = 40
            .Columns("F.Venci.").Width = 100
            .Columns("Estado").Width = 110
            .Columns("Banco").Width = 140
            .Columns("Bco.").Width = 30
            .Columns("Cte.").Width = 30
            .Columns(" ").Width = 30
            .Columns("Importe").Width = 55
            .Columns("Amortizado").Width = 65
            .Columns("Saldo").Width = 55

            ' Alineacion '
            .Columns("Bco.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cte.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("F.Giro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("F.Venci.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Amortizado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Mostramos documentos amarrados a la letra '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            Call calcular_totales()
        End With
    End Sub
    Private Sub calcular_totales()
        With Dgv01
            TxtTot_Mn.Clear() : TxtTot_Us.Clear()
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(" ").Value = "S/" Then
                    TxtTot_Mn.Text = Val(TxtTot_Mn.Text) + Val(.Rows(i).Cells("Saldo").Value)
                Else
                    TxtTot_Us.Text = Val(TxtTot_Us.Text) + Val(.Rows(i).Cells("Saldo").Value)
                End If
            Next
            TxtTot_Mn.Text = Format(Val(TxtTot_Mn.Text), Forma_2_2)
            TxtTot_Us.Text = Format(Val(TxtTot_Us.Text), Forma_2_2)
        End With
    End Sub
    Private Sub TxtLetra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLetra.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtLetra.Text) > 0 Then
                Call cargar_Grid(" And L.c_nro_letra='" & TxtLetra.Text & "' and L.c_anula_reg=0 ", " And L.c_nro_letra='" & TxtLetra.Text & "' ")
            End If
        End If
    End Sub

    Private Sub TxtLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLetra.TextChanged

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
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Convertimos en Cliente '
    Private Sub CboCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCliente.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCliente.SelectedIndexChanged

    End Sub
    ' Convertimos en Estado '
    Private Sub CboEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstado.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstado.SelectedIndexChanged

    End Sub
    ' Convertimos en mayusculas '
    Private Sub CboBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboBanco.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBanco.SelectedIndexChanged

    End Sub
    ' Exportamos Datos a Excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a una carpeta '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Abrimos ARchivo donde se graba registros o listrado '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Letras.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Letras.XLS"
            End If
        End If
    End Sub
    ' Impresion de Letras '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = ""
        Dim Fecha As String = "" : Dim Bancos As String = "" : Dim Estado As String = "" : Dim Cliente As String = ""
        Dim Cancel As String = "" : Dim Cancel2 As String = "" : Dim Fecha2 As String = ""
        If Rdb03.Checked = True Then
            Fecha = " And L.c_fecha_giro>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_giro<='" & DtpFec_Final.Text & "' "
            Fecha2 = " And L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        Else
            Fecha = " And L.c_fecha_venci>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_venci<='" & DtpFec_Final.Text & "' "
            Fecha2 = " And L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' AND L.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        End If
        ' Validamos si letras estan pendientes o canceladas '
        If Rdb06.Checked = True Then ' Pendientes
            Cancel = " and L.c_cancel_letra IN(0,2) " : Cancel2 = " and L.c_opc_cancel IN(0,2) "
            Titulo = "Listado de Letras Pendientes : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        Else ' Canceladas
            Cancel = " and L.c_cancel_letra=1 " : Cancel2 = " and L.c_opc_cancel=1 "
            Titulo = "Listado de Letras Canceladas DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        End If
        ' Criterio de busqueda para clientes '
        If Len(CboCliente.Text) > 0 Then Cliente = " And Cl.c_codi_clie='" & CboCliente.SelectedValue & "' "
        ' Criterio de busqueda estado de letra '
        If Len(CboEstado.Text) > 0 Then Estado = " And L.c_codi_stletra='" & CboEstado.SelectedValue & "' "
        ' Criterio  de busqueda por banco '
        If Len(CboBanco.Text) > 0 Then Bancos = " And L.c_codi_bco='" & CboBanco.SelectedValue & "' "
        Call cargar_Grid(" And L.c_anula_reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel, " And L.c_anula_reg=0 " & Fecha2 & Cliente & Estado & Bancos & Cancel2)
        c_Neg_LetCab.get_LetCab_Datos(" And L.c_anula_reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel & "  ", "RPT", " And L.c_anula_reg=0 " & Fecha2 & Cliente & Estado & Bancos & Cancel2 & " ")
        FrmReportes.Reporte_ListaLetras(Titulo, TxtTot_Us.Text, TxtTot_Mn.Text)
    End Sub
End Class