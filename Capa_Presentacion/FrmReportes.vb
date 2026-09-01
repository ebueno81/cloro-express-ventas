Imports System.IO
Imports Microsoft.Reporting.WinForms
Public Class FrmReportes

    Private Sub FrmReportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then Me.Rpt02.PrintDialog()
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    '--> Avanzamos presionando la tecla enter <--'
    Private Sub FrmReportes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Rpt02.RefreshReport()

    End Sub
    Public Sub Reporte_Comision(ByVal titulo As String, ByVal c_nro_comis As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptComision"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_comis", c_nro_comis, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    Public Sub Reporte_ComisionTotal(ByVal titulo As String, ByVal c_nro_comis As String, ByVal c_codi_doc As String,
                               ByVal c_codi_vende As String, ByVal c_desc_estado As String, ByVal c_codi_clie As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptComisionTot"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_comis", c_nro_comis, False))
        paramList.Add(New ReportParameter("c_codi_doc", c_codi_doc, False))
        paramList.Add(New ReportParameter("c_codi_vende", c_codi_vende, False))
        paramList.Add(New ReportParameter("c_desc_estado", c_desc_estado, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    Public Sub Reporte_ComisionArt(ByVal titulo As String, ByVal c_nro_comis As String,
                               ByVal c_codi_vende As String, ByVal c_desc_estado As String, ByVal c_codi_clie As String,
                                   ByVal c_total_mn As Decimal, ByVal c_total_us As Decimal, ByVal c_comis_mn As Decimal,
                                   ByVal c_comis_us As Decimal)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptComisionArt"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_comis", c_nro_comis, False))
        paramList.Add(New ReportParameter("c_desc_estado", c_desc_estado, False))
        paramList.Add(New ReportParameter("vOpt", "RPT", False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_codi_vende", c_codi_vende, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))

        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_total_mn", c_total_mn, False))
        paramList.Add(New ReportParameter("c_total_us", c_total_us, False))
        paramList.Add(New ReportParameter("c_comis_mn", c_comis_mn, False))
        paramList.Add(New ReportParameter("c_comis_us", c_comis_us, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)

        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    Public Sub Impresion_Factura(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_obs As String, ByVal PorDet As Integer)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpFact"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_factura", c_nro_factura, False))
        paramList.Add(New ReportParameter("Observacion", c_obs, False))
        Dim I As Integer = FrmFacturas.Dgv01.RowCount
        If FrmFacturas.Dgv01.RowCount > 0 Then
            For u = 0 To I - 1
                If FrmFacturas.Dgv01.Rows(u).Cells("chk").Value = True Then
                    Dim valor As String = ""
                    If FrmFacturas.Dgv01.Rows(u).Cells("c_nro_serie").Value = "000" Then
                        valor = ""
                    Else
                        valor = FrmFacturas.Dgv01.Rows(u).Cells("Guia").Value
                    End If
                    paramList.Add(New ReportParameter("Guia_" & u + 1, valor, False))
                End If
            Next
        End If
        I = I + 1
        For u = I To 20
            paramList.Add(New ReportParameter("Guia_" & u, "", False))
        Next

        paramList.Add(New ReportParameter("Cuenta", "Operación sujeta al sistema de pago de obligaciones tributarias con el gobierno central " &
                                          "detracción " & PorDet & "% cta. cte. " & FrmMenu.TxtCta_Nacion.Text, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Boletas '
    Public Sub Impresion_Boleta(ByVal c_nro_serie As String, ByVal c_nro_boleta As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpBolCab"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_boleta", c_nro_boleta, False))
        Dim I As Integer = FrmBoletas.Dgv01.RowCount
        If FrmBoletas.Dgv01.RowCount > 0 Then
            For u = 0 To I - 1
                If FrmBoletas.Dgv01.Rows(u).Cells("chk").Value = True Then
                    Dim valor As String = FrmBoletas.Dgv01.Rows(u).Cells("Guia").Value
                    paramList.Add(New ReportParameter("Guia_" & u + 1, Val(valor), False))
                End If
            Next
        End If
        I = I + 1
        For u = I To 6
            paramList.Add(New ReportParameter("Guia_" & u, "", False))
        Next

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Nota de Credito '
    Public Sub Impresion_NotaC(ByVal c_nro_serie As String, ByVal c_nro_nc As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpNotaC"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_Serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_nc", c_nro_nc, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Nota de Debito '
    Public Sub Impresion_NotaD(ByVal c_nro_serie As String, ByVal c_nro_nd As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpNotaD"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_nd", c_nro_nd, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Lista de Documentos '
    Public Sub Reporte_ListaDoc(ByVal Titulo As String, ByVal Tpo_Doc As String, ByVal Total_Us As String, ByVal Total_Mn As String,
                                ByVal Saldo_Us As String, ByVal Saldo_Mn As String, ByVal Acta_Us As String, ByVal Acta_Mn As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptListaDoc"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Tpo_Doc", Tpo_Doc, False))
        paramList.Add(New ReportParameter("Total_Us", Total_Us, False))
        paramList.Add(New ReportParameter("Total_Mn", Total_Mn, False))
        paramList.Add(New ReportParameter("Saldo_Us", Saldo_Us, False))
        paramList.Add(New ReportParameter("Saldo_Mn", Saldo_Mn, False))
        paramList.Add(New ReportParameter("Acta_Us", Acta_Us, False))
        paramList.Add(New ReportParameter("Acta_Mn", Acta_Mn, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub

    ' Impresion de Lista de Documentos '
    Public Sub ReporteEstadoCuenta(ByVal Titulo As String, ByVal TotalMn As String, ByVal TotalUs As String, ByVal ActaMn As String,
                                   ByVal ActaUs As String, ByVal SaldoMn As String, ByVal SaldoUs As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        '[Sp_Sca_Rpt_EstadoCuenta] RPT
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptEstadoCuenta"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("TotalMn", TotalMn, False))
        paramList.Add(New ReportParameter("TotalUs", TotalUs, False))
        paramList.Add(New ReportParameter("ActaUs", ActaUs, False))
        paramList.Add(New ReportParameter("ActaMn", ActaMn, False))
        paramList.Add(New ReportParameter("SaldoUs", SaldoUs, False))
        paramList.Add(New ReportParameter("SaldoMn", SaldoMn, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Retenciones '
    Public Sub Reporte_Retenciones(ByVal Titulo As String, ByVal c_codi_clie As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRetencion"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Retenciones Facturas'
    Public Sub Reporte_RetenFact(ByVal Titulo As String, ByVal c_codi_clie As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRetenFact"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Lista de Letras '
    Public Sub Reporte_ListaLetras(ByVal Titulo As String, ByVal Total_Us As String, ByVal Total_Mn As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptLetras"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Total_Us", Total_Us, False))
        paramList.Add(New ReportParameter("Total_Mn", Total_Mn, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Registro de Letras '
    Public Sub Reporte_RegistroLetras(ByVal Titulo As String, ByVal Total_Us As String, ByVal Total_Mn As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRegLetras"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Total_Us", Total_Us, False))
        paramList.Add(New ReportParameter("Total_Mn", Total_Mn, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Registro de Ventas '
    Public Sub Reporte_RegistroVtas(ByVal Titulo As String, ByVal c_nick_mon As String, ByVal Moneda As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRegVentas"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("M", c_nick_mon, False))
        paramList.Add(New ReportParameter("Moneda", Moneda, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Registro de Ventas Ordenado por numero de documento'
    Public Sub Reporte_RegistroVtas_Orden(ByVal Titulo As String, ByVal c_nick_mon As String, ByVal Moneda As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRegVentas_2"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("M", c_nick_mon, False))
        paramList.Add(New ReportParameter("Moneda", Moneda, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Registro de Ventas Ordenado por cliente'
    Public Sub Reporte_RegistroVtas_Cliente(ByVal Titulo As String, ByVal c_nick_mon As String, ByVal Moneda As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_RptRegVentas_3"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("M", c_nick_mon, False))
        paramList.Add(New ReportParameter("Moneda", Moneda, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Registro de Ventas '
    Public Sub Reporte_GuiasPendientes(ByVal Titulo As String, ByVal c_nro_salidaTA As String, ByVal c_nro_serie As String, ByVal c_nro_ingreso As String,
                                       ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String, ByVal c_anula_reg As String,
                                       ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptGuiasPend"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("c_nro_salidaTA", c_nro_salidaTA, False))
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_ingreso", c_nro_ingreso, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_anula_reg", c_anula_reg, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = 35
        Me.Show()
    End Sub
    ' Impresion de Registro de Ventas '
    Public Sub Impresion_IngValor(ByVal c_nro_valor As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpValorIng"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("Cadena", c_nro_valor, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = 35
        Me.Show()
    End Sub
    ' Impresion Guia Fatima Serie Normales '
    Public Sub Impresion_SalidaTA(ByVal c_nro_serie As String, ByVal c_nro_salidaTA As String)
        Try
            Rpt02.ProcessingMode = ProcessingMode.Remote
            Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
            Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "RptSalTA"

            Dim paramList As New Generic.List(Of ReportParameter)
            paramList.Add(New ReportParameter("c_nro_salidaTA", c_nro_salidaTA, False))
            paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))

            Rpt02.ServerReport.Refresh()
            Rpt02.ServerReport.SetParameters(paramList)

            Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
            Rpt02.ZoomMode = ZoomMode.Percent
            Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
            Me.Show()
        Catch ex As Exception
            MsgBox("Error al imprimir la guia de salida: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    ' Impresion Guia Fatima Serie Normales '
    Public Sub Impresion_SalidaTA_Prueba(ByVal c_nro_serie As String, ByVal c_nro_salidaTA As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "RptSalTA_000"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_salidaTA", c_nro_salidaTA, False))
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion ot'
    Public Sub Impresion_OT(c_nro_serie As String, c_nro_salidaTA As String, tipo As String)
        Try
            Rpt02.ProcessingMode = ProcessingMode.Remote
            Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
            Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpOT"

            Dim paramList As New Generic.List(Of ReportParameter)
            paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
            paramList.Add(New ReportParameter("c_nro_salidaTA", c_nro_salidaTA, False))
            paramList.Add(New ReportParameter("Tipo", tipo, False))

            Rpt02.ServerReport.Refresh()
            Rpt02.ServerReport.SetParameters(paramList)

            Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
            Rpt02.ZoomMode = ZoomMode.Percent
            Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Catch ex As Exception
            MsgBox("Error al imprimir la orden de trabajo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Me.Show()
    End Sub
    ' Impresion de Planilla d eletras '
    Public Sub Reporte_Planilla_Letras(ByVal Titulo As String, ByVal c_nro_liq As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_Liquidac"

        Dim paramList As New Generic.List(Of ReportParameter)
        Dim i As Integer = 0
        With c_Neg_LetCab.get_LetCab_Datos(" and L.c_nro_liq='" & c_nro_liq & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    paramList.Add(New ReportParameter("Letra_" & Strings.Right(101 + i, 2), .Rows(i)("c_nro_letra").ToString, False))
                    paramList.Add(New ReportParameter("Nick_" & Strings.Right(101 + i, 2), .Rows(i)("c_nick_mon").ToString, False))
                    paramList.Add(New ReportParameter("Total_" & Strings.Right(101 + i, 2), Format(Val(.Rows(i)("c_imp_letra").ToString), Forma_2_2), False))
                    paramList.Add(New ReportParameter("Vcto_" & Strings.Right(101 + i, 2), FormatDateTime(.Rows(i)("c_fecha_venci").ToString, DateFormat.ShortDate), False))
                Next
                i = .Rows.Count
            End If
        End With
        ' Validamos hasta que numero solo hay letras '
        For u = i To 9
            paramList.Add(New ReportParameter("Letra_" & Strings.Right(101 + u, 2), "", False))
            paramList.Add(New ReportParameter("Nick_" & Strings.Right(101 + u, 2), "", False))
            paramList.Add(New ReportParameter("Total_" & Strings.Right(101 + u, 2), "", False))
            paramList.Add(New ReportParameter("Vcto_" & Strings.Right(101 + u, 2), "", False))
        Next
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_nro_liq", c_nro_liq, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        paramList.Add(New ReportParameter("Fecha", "Huachipa, " & StrConv(Now.Date.ToString("dddd"), VbStrConv.ProperCase) & ", " & Now.Date.DayOfWeek & " de " & StrConv(MonthName(Month(Now.Date)), vbProperCase) & " de " & Year(Now.Date), False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Letras '
    Public Sub Impresion_Letras(ByVal c_nro_letra As String, ByVal c_renov_letra As Integer, ByVal mon As String, ByVal Direccion As String,
                                ByVal Letras As String, ByVal Fact_01 As String, ByVal Fact_02 As String, ByVal Fact_03 As String, ByVal Fact_04 As String,
                                ByVal Fact_05 As String, ByVal Fact_06 As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Sca_ImpLetras"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("Mon", mon, False))
        paramList.Add(New ReportParameter("Letras", Letras, False))
        paramList.Add(New ReportParameter("Direccion", StrConv(Direccion, VbStrConv.ProperCase), False))
        paramList.Add(New ReportParameter("c_nro_letra", c_nro_letra, False))
        paramList.Add(New ReportParameter("c_renov_letra", c_renov_letra, False))

        paramList.Add(New ReportParameter("Fact_01", Fact_01, False))
        paramList.Add(New ReportParameter("Fact_02", Fact_02, False))
        paramList.Add(New ReportParameter("Fact_03", Fact_03, False))
        paramList.Add(New ReportParameter("Fact_04", Fact_04, False))
        paramList.Add(New ReportParameter("Fact_05", Fact_05, False))
        paramList.Add(New ReportParameter("Fact_06", Fact_06, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Lista de Documentos '
    Public Sub Reporte_Envases(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_clie As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvases"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' reporte de envases agrupado por cliente y por articulos
    ' Impresion de Lista de Documentos '
    Public Sub Reporte_Envases_Clientes(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_clie As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvasesTot"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        'paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' envases por articulo '
    Public Sub Reporte_Envases_Articulos(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_clie As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvasesArt"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        'paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub

    ' envases por articulo '
    Public Sub Reporte_Envases_Estado(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvEstado"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' envases por ESTADO X DIAS'
    Public Sub Reporte_Envases_Estado_Diario(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvDiario"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Lista de Documentos '
    Public Sub Reporte_Envases_Clientes_Propiedad()
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptEnvasesClie"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        'paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de VENTA AGRUPADO POR CLIENTES '
    Public Sub Reporte_Articulos_Clientes(ByVal Titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptSalClie"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de VENTA pantallazo '
    Public Sub Reporte_Articulos_Pantallazo(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_clie As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String, ByVal Tot_Mn As String, ByVal Tot_Us As String, ByVal c_codi_mon As String,
                                            ByVal c_opc_noingsal As String, ByVal c_codi_alm As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        'Sp_Scal_Rpt_SalTADet
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptSalArtDet"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Tot_Mn", Tot_Mn, False))
        paramList.Add(New ReportParameter("Tot_Us", Tot_Us, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("c_opc_noingsal", c_codi_mon, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de VENTA pantallazo VALORIZADO'
    Public Sub Reporte_Articulos_Pantallazo_Valorizado(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_clie As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal vOpt As String, ByVal Tot_Mn As String, ByVal Tot_Us As String, ByVal c_codi_mon As String,
                                            ByVal c_opc_noingsal As String, ByVal c_codi_alm As String, ByVal c_opc_transforma As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        'Sp_Scal_Rpt_SalTADet
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptSalArtDetValor"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_clie", c_codi_clie, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_codi_linea", c_codi_linea, False))
        paramList.Add(New ReportParameter("c_codi_familia", c_codi_familia, False))
        paramList.Add(New ReportParameter("c_codi_sfamilia", c_codi_sfamilia, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Tot_Mn", Tot_Mn, False))
        paramList.Add(New ReportParameter("Tot_Us", Tot_Us, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("c_opc_noingsal", c_opc_noingsal, False))
        paramList.Add(New ReportParameter("c_opc_transforma", c_opc_transforma, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de total'
    Public Sub Reporte_Articulos_Total(ByVal Titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptSalVtaArt"

        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de VENTA AGRUPADO POR CLIENTES '
    Public Sub Reporte_Transformaciones(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date,
                                        ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_articulo As String,
                                        ByVal c_codi_alm As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_Transform"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub

    Public Sub Reporte_TransformaVentas(ByVal Titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptTransVenta"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()

    End Sub
End Class