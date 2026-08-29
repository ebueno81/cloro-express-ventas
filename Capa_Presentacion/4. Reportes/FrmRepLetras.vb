Public Class FrmRepLetras
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
                TxtRuta.Text = Folder01.SelectedPath & "Registro_Letras.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Registro_Letras.XLS"
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
    ' Cargamos Grid
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call cargar_Grid(" and L.c_fecha_giro>='" & DtpFec_Inicio.Text & "' and L.c_fecha_giro<='" & DtpFec_Final.Text & "' ", _
                         " and L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and L.c_fecha_emi<='" & DtpFec_Final.Text & "' ")
    End Sub
    Private Sub cargar_Grid(ByVal Cadena As String, ByVal Cadena2 As String)
        With Dgv01
            .DataSource = c_Neg_LetCab.get_LetCab_Datos(Cadena, "REG", Cadena2)
            .Columns("Letra").Width = 60
            .Columns("Cliente").Width = 180
            .Columns("Fecha Giro").Width = 110
            .Columns("Dias").Width = 40
            .Columns("Fecha Venci.").Width = 110
            .Columns("Status").Width = 110
            .Columns("_").Width = 30
            .Columns("Importe").Width = 50
            .Columns("Estado").Width = 95
            .Columns("Banco").Width = 95

            ' Alineacion '
            .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Giro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Venci.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Visible '
            .Columns("c_anula_reg").Visible = False
            ' Mostramos documentos amarrados a la letra '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            Call calcular_totales()
        End With
    End Sub
    ' Calculamos Totales '
    Private Sub calcular_totales()
        With Dgv01
            TxtTot_Mn.Clear() : TxtTot_Us.Clear()
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("_").Value = "S/" Then
                    TxtTot_Mn.Text = Val(TxtTot_Mn.Text) + Val(.Rows(i).Cells("Importe").Value)
                    TxtConta_1.Text = Val(TxtConta_1.Text) + 1
                Else
                    TxtTot_Us.Text = Val(TxtTot_Us.Text) + Val(.Rows(i).Cells("Importe").Value)
                    TxtConta_2.Text = Val(TxtConta_2.Text) + 1
                End If
            Next
            TxtTot_Mn.Text = Format(Val(TxtTot_Mn.Text), Forma_2_2)
            TxtTot_Us.Text = Format(Val(TxtTot_Us.Text), Forma_2_2)
        End With
    End Sub

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = " Registro de Letras DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        c_Neg_LetCab.get_LetCab_Datos(" and L.c_fecha_giro>='" & DtpFec_Inicio.Text & "' and L.c_fecha_giro<='" & DtpFec_Final.Text & "' ", "RE2", _
                                      " and L.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and L.c_fecha_emi<='" & DtpFec_Final.Text & "' ")
        FrmReportes.Reporte_RegistroLetras(Titulo, TxtTot_Us.Text, TxtTot_Mn.Text)
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmRepLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRepLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class