Imports System.Windows.Forms

Public Class FrmMenu

    Private Sub FrmMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    ' --> Mantenimiento  de clientes <-- '
    Private Sub MnuMnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnCliente.Click
        With FrmMnClientes
            .MdiParent = Me : .Show() : .Cargar_Grid(" order by c_codi_clie")
        End With
    End Sub
    ' --> Mantenimiento de Vendedores <-- '
    Private Sub MnuMnVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnVendedor.Click
        FrmMnVendedor.MdiParent = Me : FrmMnVendedor.Show() : FrmMnVendedor.Cargar_Grid("")
    End Sub
    'Generacion de Facturas...
    Private Sub MnuOpeFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeFact.Click
        FrmFacturas.MdiParent = Me : FrmFacturas.Show()
    End Sub
    ' Nota de Credito '
    Private Sub MnuOpeNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeNC.Click
        With FrmIngNC
            .MdiParent = Me : .Show()
        End With
    End Sub

    Private Sub Tool_Calcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Calcu.Click
        Dim Proceso As New Process() : Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = "" : Proceso.Start()
    End Sub
    'Clientes...
    Private Sub Tool_Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Clientes.Click
        If MnuMnCliente.Enabled = True Then
            Call MnuMnCliente_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    ' Tool Tipo de cambio '
    Private Sub Tool_TpoCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_TpoCambio.Click
        If MnuMnTpoCambio.Enabled = True Then
            Call MnuMnTpoCambio_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub Tool_Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Cerrar.Click
        End
    End Sub

    Private Sub MnuMnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnSalir.Click
        End
    End Sub
    'Facturas...
    Private Sub Tool_Facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Facturas.Click
        If MnuOpeFact.Enabled = True Then
            Call MnuOpeFact_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    'Boletas Tool
    Private Sub Tool_Boletas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Boletas.Click
        If MnuOpeBol.Enabled = True Then
            MnuOpeBol_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    'Boletas...
    Private Sub MnuOpeBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeBol.Click
        FrmBoletas.MdiParent = Me : FrmBoletas.Show()
    End Sub

    Private Sub MnuMnTpoCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnTpoCambio.Click
        FrmMnTpoCambio.MdiParent = Me : FrmMnTpoCambio.Show()
    End Sub
    'Registro de Ventas...
    Private Sub MnuRptRegVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRptRegVentas.Click
        FrmRepVentas.MdiParent = Me : FrmRepVentas.Show()
    End Sub
    'Notas de Credito...
    Private Sub Tool_NC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_NC.Click
        If MnuOpeNC.Enabled = True Then
            Call MnuOpeNC_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub MnuOpeND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeND.Click
        FrmIngND.MdiParent = Me : FrmIngND.Show()
    End Sub
    'Tool Nota de Débito...
    Private Sub Tool_ND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_ND.Click
        If MnuOpeND.Enabled = True Then
            Call MnuOpeND_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub MnuOpeLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeLetras.Click
        FrmLetras.MdiParent = Me : FrmLetras.Show()
    End Sub
    'Generación de Letras...
    Private Sub Tool_Letras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Letras.Click
        If MnuOpeLetras.Enabled = True Then
            Call MnuOpeLetras_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    'Administración de Usuarios
    Private Sub MnuAdmUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdmUsuarios.Click
        FrmUsuarios.MdiParent = Me : FrmUsuarios.Show() : FrmUsuarios.Cargar_Grid("")
    End Sub
    'Mantenimiento de igv...
    Private Sub MnuMnIgv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnIgv.Click
        FrmMnIGV.MdiParent = Me : FrmMnIGV.Show() : FrmMnIGV.cargar_grid()
    End Sub
    ' series de documentos '
    Private Sub MnuMnSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnSeries.Click
        FrmMnSeriesDoc.MdiParent = Me : FrmMnSeriesDoc.Show()
    End Sub
    'Asientos automaticos...
    Private Sub MnuContaAsientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContaAsientos.Click
        FrmAsientos.MdiParent = Me : FrmAsientos.Show()
    End Sub

    Private Sub FrmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\Logo.jpg")
    End Sub
    Public Sub Validar_Menu()
        Dim Dt_NombreMenu As String = ""
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    Dt_NombreMenu = .Rows(i).Cells("c_nom_menu").Value
                    If Val(.Rows(i).Cells("c_find_obj").Value) = 0 Then
                        For Each Dt_Menu In MenuStrip.Items ' ---> Items del MenuStrip
                            For Each item In Dt_Menu.DropDownItems ' ---> Items del ToolStripItem
                                If UCase(item.Name) = UCase(Dt_NombreMenu) Then ' ---> Si el item pertenece al usuario
                                    CType(item, ToolStripMenuItem).Enabled = False ' ----> lo muestra
                                End If
                            Next
                        Next
                    End If
                    ' Validamos si el Tool esta Activo '
                    On Error Resume Next
                    If .Rows(i).Cells("c_find_obj").Value = 0 Then
                        For u = 0 To Tool_01.Items.Count - 1
                            If Tool_01.Items(u).Name = .Rows(i).Cells("c_nom_tool").Value Then
                                Tool_01.Items(u).Enabled = False : u = Tool_01.Items.Count
                            End If
                        Next
                    End If
                Next
            End If
        End With
    End Sub
    'Modulos de Ventas...
    Private Sub MnuAdmModulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdmModulos.Click
        FrmModulos.MdiParent = Me : FrmModulos.Show()
    End Sub
    'Cargar usuarios...
    Private Sub Tool_Usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Usuario.Click
        If MnuAdmUsuarios.Enabled = True Then
            Call MnuAdmUsuarios_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    'Listado de facturas...
    Private Sub MnuConFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConFact.Click
        FrmListaFact.MdiParent = Me : FrmListaFact.Show()
    End Sub
    'Listado de boletas
    Private Sub MnuConBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConBol.Click
        FrmListaBol.MdiParent = Me : FrmListaBol.Show()
    End Sub
    'Listado de notas de debito...
    Private Sub MnuConND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConND.Click
        FrmListaNotaD.MdiParent = Me : FrmListaNotaD.Show()
    End Sub
    'Listado de nota de credito...
    Private Sub MnuConNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConNC.Click
        FrmListaNotaC.MdiParent = Me : FrmListaNotaC.Show()
    End Sub
    ' Archivo de Liquidaciones '
    Private Sub MnuOpeLiquidac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeLiquidac.Click
        FrmLiquidac.MdiParent = Me : FrmLiquidac.Show()
        FrmLiquidac.Cargar_Grid(" and L.c_fecha_crea>='" & Now.Date & _
            "' and L.c_fecha_crea<='" & DateAdd("d", 1, Now.Date) & "' order by c_nro_liq")
    End Sub
    ' Mantenimiento de letras '
    Private Sub MnuOpeLetrasMn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeLetrasMn.Click
        FrmLetrasMn.MdiParent = Me : FrmLetrasMn.Show()
    End Sub
    ' Listado de letras '
    Private Sub MnuConLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConLetras.Click
        FrmListaLetras.MdiParent = Me : FrmListaLetras.Show()
    End Sub

    Private Sub Tool_RegVtas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_RegVtas.Click
        If MnuRptRegVentas.Enabled = True Then
            Call MnuRptRegVentas_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub Tool_RegLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_RegLetras.Click
        If MnuRptRegLetras.Enabled = True Then
            Call MnuRptRegLetras_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub Tool_Asientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Asientos.Click
        If MnuContaAsientos.Enabled = True Then
            MnuContaAsientos_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    ' Mantenimiento de Vendedores '
    Private Sub Tool_Vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Vendedor.Click
        If MnuMnVendedor.Enabled = True Then
            Call MnuMnVendedor_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    ' Mantenimiento de IGV '
    Private Sub Tool_IGV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_IGV.Click
        If MnuMnIgv.Enabled = True Then
            Call MnuMnIgv_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    ' Generación de Comisiones '
    Private Sub MnuOpeGenComis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeGenComis.Click
        FrmComisiones.MdiParent = Me : FrmComisiones.Show()
    End Sub
    ' Reporte de Guias de Remision pendientes por facturar '
    Private Sub MnuRptSalTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRptSalTA.Click
        FrmRepGuiasxFact.MdiParent = Me : FrmRepGuiasxFact.Show()
    End Sub
    ' Registro de Letras '
    Private Sub MnuRptRegLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRptRegLetras.Click
        FrmRepLetras.MdiParent = Me : FrmRepLetras.Show()
    End Sub
    ' Reporte de Facturas por emitir guia de remision '
    Private Sub Tool_GuiaXFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_GuiaXFact.Click
        If MnuRptSalTA.Enabled = True Then
            Call MnuRptSalTA_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los privilegios de usuario para realizar esta operacion...", vbCritical, Compañia)
        End If
    End Sub
    ' Empresa de Servicios '
    Private Sub MnuMnEmpServ_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnEmpServ.Click
        FrmMnEmpServ.MdiParent = Me : FrmMnEmpServ.Show() : FrmMnEmpServ.Cargar_Grid(" ")
    End Sub
    ' Empresa de Transportes '
    Private Sub MnuMnEmpTransporte_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnEmpTransporte.Click
        FrmMnTransporte.MdiParent = Me : FrmMnTransporte.Show() : FrmMnTransporte.Cargar_Grid(" order by c_placa_trp")
    End Sub
    ' Salida de Tela Acabada '
    Private Sub MnuOpeGuiaR_Click(sender As System.Object, e As System.EventArgs) Handles MnuOpeGuiaR.Click
        FrmAlmSalTA.MdiParent = Me : FrmAlmSalTA.Show() : FrmAlmSalTA.Cargar_Grid()
    End Sub
    ' Mantenimiento de Guía de Remisión '
    Private Sub MnuMnSeriesGR_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnSeriesGR.Click
        FrmMnSeriesGuia.MdiParent = Me : FrmMnSeriesGuia.Show() : FrmMnSeriesGuia.Cargar_Grid(" order by c_nro_serie")
    End Sub
    ' Motivo de movimientos '
    Private Sub MnuMnTpoMov_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnTpoMov.Click
        FrmMnMotivos.MdiParent = Me : FrmMnMotivos.Show() : FrmMnMotivos.Cargar_Grid()
    End Sub
    ' ingreso de retenciones '
    Private Sub MnuOpeRetencion_Click(sender As System.Object, e As System.EventArgs) Handles MnuOpeRetencion.Click
        FrmRetencion.MdiParent = Me : FrmRetencion.Show()
    End Sub

    Private Sub MnuMnChoferes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnChoferes.Click
        FrmMnChofer.MdiParent = Me : FrmMnChofer.Show() : FrmMnChofer.Cargar_Grid(" order by c_nom_chofer")
    End Sub
    ' Asiento de apertura
    Private Sub MnuContaApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContaApertura.Click
        FrmApertura.MdiParent = Me : FrmApertura.Show()
    End Sub
    ' Reporte de Envases '
    Private Sub MnuRepEnvases_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepEnvases.Click
        FrmRepEnvases.MdiParent = Me : FrmRepEnvases.Show()
    End Sub
    ' reporte de envases propiedad del cliente '
    Private Sub MnuRepEnvasesClie_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepEnvasesClie.Click
        FrmReportes.Reporte_Envases_Clientes_Propiedad()
    End Sub
    ' reteneciones emitidas
    Private Sub MnuRptRegRetenciones_Click(sender As System.Object, e As System.EventArgs) Handles MnuRptRegRetenciones.Click
        FrmRepRetencion.MdiParent = Me : FrmRepRetencion.Show()
    End Sub
    ' Reporte de salidas por ventas precios de VENTAS'
    Private Sub MnuRepSalVtas_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepSalVtas.Click
        FrmRptSalAlm.MdiParent = Me : FrmRptSalAlm.Show()
    End Sub
    ' reporte de transformaciones '
    Private Sub MnuRepSalTransforma_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepSalTransforma.Click
        FrmRepTransforma.MdiParent = Me : FrmRepTransforma.Show()
    End Sub
    ' formas de pago
    Private Sub MnuMnFpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnFpago.Click
        FrmMnTpoPago.MdiParent = Me : FrmMnTpoPago.Show() : FrmMnTpoPago.Cargar_Grid(" ")
    End Sub
    ' Guias Facturadas
    Private Sub MnuRptGuiasFactu_Click(sender As Object, e As EventArgs) Handles MnuRptGuiasFactu.Click
        FrmRepGuiasFactu.MdiParent = Me : FrmRepGuiasFactu.Show()
    End Sub

    Private Sub MnuRepEnvasesEstado_Click(sender As Object, e As EventArgs) Handles MnuRepEnvasesEstado.Click
        FrmRepEnvasesEstado.MdiParent = Me : FrmRepEnvasesEstado.Show()
    End Sub
    ' Reporte de salidas de ventas del kardex valorizado '
    Private Sub MnuRepSalVtasValor_Click(sender As Object, e As EventArgs) Handles MnuRepSalVtasValor.Click
        FrmRptSalAlmValor.MdiParent = Me : FrmRptSalAlmValor.Show()
    End Sub
    ' Cierres mensuales '
    Private Sub MnuAdmCierres_Click(sender As Object, e As EventArgs) Handles MnuAdmCierres.Click
        FrmCierres.Show() : FrmCierres.MdiParent = Me
    End Sub

    Private Sub MnuRepVtasGerencial_Click(sender As Object, e As EventArgs) Handles MnuRepVtasGerencial.Click
        FrmRepVtasGerencial.MdiParent = Me : FrmRepVtasGerencial.Show()
    End Sub
    ' Reporte de Estado de cuentas
    Private Sub MnuRptEstadoCuenta_Click(sender As Object, e As EventArgs) Handles MnuRptEstadoCuenta.Click
        FrmRepEstadoCuenta.MdiParent = Me : FrmRepEstadoCuenta.Show()
        FrmRepEstadoCuenta.DtpFec_Inicio.Text = "01/01/2020"
        FrmRepEstadoCuenta.CargarGrid()
    End Sub

    Private Sub MnuRptTransformaVentas_Click(sender As Object, e As EventArgs) Handles MnuRptTransformaVentas.Click
        FrmRptTransforVentas.MdiParent = Me
        FrmRptTransforVentas.Show()
        FrmRptTransforVentas.TxtcodTg.Text = "01"
        FrmRptTransforVentas.TxtTg.Text = "MERCADERIA"
        FrmRptTransforVentas.TxtCodCd.Text = "01"
        FrmRptTransforVentas.TxtCd.Text = "INSUMOS QUIMICOS"
        FrmRptTransforVentas.CargarGrid()
    End Sub

    Private Sub MnuConListaDocAnticipo_Click(sender As Object, e As EventArgs) Handles MnuConListaDocAnticipo.Click
        FrmListaAnticipo.Close()
        FrmListaAnticipo.MdiParent = Me : FrmListaAnticipo.Show()
    End Sub
End Class
