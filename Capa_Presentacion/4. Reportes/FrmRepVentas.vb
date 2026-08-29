Imports Capa_Negocios
Public Class FrmRepVentas
    Dim c_Neg_MnTpoDoc As New Neg_MnTpoDoc
    'avanzamos al presionar la tecla enter <-'
    Private Sub FrmRepVentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmRepCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_TpoDoc()
        DtpFec_Ini.Text = "01/" & Strings.Right(Month(Now.Date) + 100, 2) & "/" & Year(Now.Date)
        CboMon.SelectedIndex = 0
    End Sub
    Private Sub Cargar_TpoDoc()
        'With 
        c_Neg_MnTpoDoc.Get_TpoDoc_Lsb(" and c_anula_reg=0 and c_opc_regvtas=1 order by c_codi_doc", 0, Lsb01)
        ' Lsb01.Items.Clear()
        For i = 0 To Lsb01.Items.Count - 1
            Lsb01.SetItemChecked(i, True)
        Next
        'End With
    End Sub

    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        If CboMon.Text = "$." Then
            TxtCod_Mon.Text = "02"
        Else
            TxtCod_Mon.Text = "01"
        End If
    End Sub

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim Moneda As String = "" : Dim TpoDoc As String = ""
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) = False Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            TpoDoc = " WHERE c_codi_doc IN " & TpoDoc & "')"
        Else
            TpoDoc = ""
        End If
        c_Neg_RptVtasTdas.get_RptVtasTdas_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, TxtCod_Mon.Text)
        If TxtCod_Mon.Text = "01" Then Moneda = "NUEVOS SOLES"
        If TxtCod_Mon.Text = "02" Then Moneda = "DOLARES AMERICANOS"
        ' Ordenado por fecha '
        If Rdb02.Checked = True Then
            FrmReportes.Reporte_RegistroVtas("REGISTRO DE VENTAS DEL : " & DtpFec_Ini.Text & " AL : " & DtpFec_Fin.Text, CboMon.Text, Moneda)
        End If
        ' Ordenado por tipo de documento y numero de documento y fechas  '
        If Rdb01.Checked = True Then
            FrmReportes.Reporte_RegistroVtas_Orden("REGISTRO DE VENTAS DEL : " & DtpFec_Ini.Text & " AL : " & DtpFec_Fin.Text, CboMon.Text, Moneda)
        End If
        ' Ordenado por clientes '
        If Rdb03.Checked = True Then
            FrmReportes.Reporte_RegistroVtas_Cliente("REGISTRO DE VENTAS DEL : " & DtpFec_Ini.Text & " AL : " & DtpFec_Fin.Text, CboMon.Text, Moneda)
        End If
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim c_codi_prov As String = ""
        ' If Len(CboProve.Text) > 0 Then c_codi_prov = TxtCod_Prove.Text
        Dim Moneda As String = "" : Dim TpoDoc As String = "" : Dim cadena As String = ""
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) = False Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            TpoDoc = " WHERE c_codi_doc IN " & TpoDoc & "')"
        Else
            TpoDoc = ""
        End If
        c_Neg_RptVtasTdas.get_RptVtasTdas_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, TxtCod_Mon.Text)
        ' Ordenamos por tipo documento y fecha'
        If Rdb01.Checked = True Then cadena = " order by c_codi_doc, c_Serie_doc, c_nro_doc, c_fecha_emi"
        ' Ordenamos por numero de documento '
        If Rdb02.Checked = True Then cadena = " order by c_codi_doc, c_fecha_emi, c_Serie_doc, c_nro_doc"
        ' Ordenamos por numero de documento '
        If Rdb03.Checked = True Then cadena = " order by c_desc_clie, c_fecha_emi, c_Serie_doc, c_nro_doc"
        Dgv01.DataSource = c_Neg_RptVtasTdas.get_RegVentas_Dat(cadena, "RPT")
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Registro_Ventas.XLSX"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Registro_Ventas.XLSX"
            End If
        End If
    End Sub
    'Mostramos registros de ventas general en un solo reporte...
    Private Sub Rdb03_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb03.CheckedChanged
        If Rdb03.Checked = True Then
            TxtVar.Clear()
        End If
    End Sub

    Private Sub BtnConClie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConClie.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
        FrmConClientes.TxtVar.Text = 10 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub

    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged

    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim c_codi_prov As String = ""
        ' If Len(CboProve.Text) > 0 Then c_codi_prov = TxtCod_Prove.Text
        Dim Moneda As String = "" : Dim TpoDoc As String = "" : Dim cadena As String = ""
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) = False Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            TpoDoc = " WHERE c_codi_doc IN " & TpoDoc & "')"
        Else
            TpoDoc = ""
        End If
        c_Neg_RptVtasTdas.get_RptVtasTdas_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, TxtCod_Mon.Text)
        ' Ordenamos por tipo documento y fecha'
        If Rdb01.Checked = True Then cadena = " order by c_codi_doc, c_Serie_doc, c_nro_doc, c_fecha_emi"
        ' Ordenamos por numero de documento '
        If Rdb02.Checked = True Then cadena = " order by c_codi_doc, c_fecha_emi, c_Serie_doc, c_nro_doc"
        ' Ordenamos por numero de documento '
        If Rdb03.Checked = True Then cadena = " order by c_desc_clie, c_fecha_emi, c_Serie_doc, c_nro_doc"
        Dgv01.DataSource = c_Neg_RptVtasTdas.get_RegVentas_Dat(cadena, "RPT")
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
End Class