Imports Capa_Entidades
Imports Capa_Negocios

Public Class FrmRepEstadoCuentaContrato

    Dim c_Neg_ApiMedXpress As New Neg_ApiMedXpress

    Dim c_Neg_SalAlmContrato As New Neg_SalAlmContrato

    Private ListaEstadoCuenta As New List(Of Ent_EstadoCuentaContrato)

    Private Sub FrmRepEstadoCuentaContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Configurar_Grid()

        Call LimpiarTotales()

    End Sub

    Private Sub Configurar_Grid()

        With Dgv01

            .Columns.Clear()

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False

            .ReadOnly = True
            .MultiSelect = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False

            .AutoGenerateColumns = False


            '-------------------------------------------------------
            ' CLIENTE
            '-------------------------------------------------------
            .Columns.Add("NombreCliente", "Cliente")

            .Columns("NombreCliente").Width = 200


            '-------------------------------------------------------
            ' CONTRATO
            '-------------------------------------------------------
            .Columns.Add("Contrato", "Contrato")

            .Columns("Contrato").Width = 100


            '-------------------------------------------------------
            ' INICIO CONTRATO
            '-------------------------------------------------------
            .Columns.Add("InicioContrato", "Inicio")

            .Columns("InicioContrato").Width = 80


            '-------------------------------------------------------
            ' FIN CONTRATO
            '-------------------------------------------------------
            .Columns.Add("FinContrato", "Fin")

            .Columns("FinContrato").Width = 80


            '-------------------------------------------------------
            ' CUOTA
            '-------------------------------------------------------
            .Columns.Add("Cuota", "Cuota")

            .Columns("Cuota").Width = 55

            .Columns("Cuota").DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter


            '-------------------------------------------------------
            ' PERIODO
            '-------------------------------------------------------
            .Columns.Add("PeriodoDesde", "Desde")

            .Columns("PeriodoDesde").Width = 80


            .Columns.Add("PeriodoHasta", "Hasta")

            .Columns("PeriodoHasta").Width = 80


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            .Columns.Add("Ubicaciones", "Ubicaciones")

            .Columns("Ubicaciones").Width = 180


            '-------------------------------------------------------
            ' ORDEN DE TRABAJO
            '-------------------------------------------------------
            .Columns.Add("OrdenTrabajo", "O.T.")

            .Columns("OrdenTrabajo").Width = 100


            '-------------------------------------------------------
            ' ESTADO
            '-------------------------------------------------------
            .Columns.Add("Estado", "Estado")

            .Columns("Estado").Width = 125


            '-------------------------------------------------------
            ' FACTURA
            '-------------------------------------------------------
            .Columns.Add("Factura", "Factura")

            .Columns("Factura").Width = 105


            '-------------------------------------------------------
            ' FECHA FACTURA
            '-------------------------------------------------------
            .Columns.Add("FechaFactura", "Fecha Fact.")

            .Columns("FechaFactura").Width = 85


            '-------------------------------------------------------
            ' MONEDA
            '-------------------------------------------------------
            .Columns.Add("Moneda", "Mon.")

            .Columns("Moneda").Width = 55


            '-------------------------------------------------------
            ' MONTO
            '-------------------------------------------------------
            .Columns.Add("Monto", "Monto")

            .Columns("Monto").Width = 90

            .Columns("Monto").DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight


            '-------------------------------------------------------
            ' CAMPOS OCULTOS
            '-------------------------------------------------------
            .Columns.Add("IdContrato", "IdContrato")

            .Columns("IdContrato").Visible = False


            .Columns.Add("SerieOT", "SerieOT")

            .Columns("SerieOT").Visible = False


            .Columns.Add("NroOT", "NroOT")

            .Columns("NroOT").Visible = False


            '-------------------------------------------------------
            ' ESTILO DE LAS FILAS
            '-------------------------------------------------------
            .DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)

            .DefaultCellStyle.ForeColor = Color.Black

            .DefaultCellStyle.BackColor = Color.White

            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215)

            .DefaultCellStyle.SelectionForeColor = Color.White

            .EnableHeadersVisualStyles = False

        End With

    End Sub

    Private Function GenerarCuotasContrato(ByVal Contrato As Ent_ApiContrato) As List(Of Ent_EstadoCuentaContrato)

        Dim Resultado As New List(Of Ent_EstadoCuentaContrato)


        If Contrato.FechaInicio.HasValue = False Then
            Return Resultado
        End If


        If Contrato.FechaFin.HasValue = False Then
            Return Resultado
        End If


        Dim FechaInicioContrato As Date = Contrato.FechaInicio.Value.Date

        Dim FechaFinContrato As Date = Contrato.FechaFin.Value.Date


        Dim PeriodoDesde As Date = FechaInicioContrato

        Dim NroCuota As Integer = 1


        Do While PeriodoDesde <= FechaFinContrato


            '-------------------------------------------------------
            ' CALCULAR SIGUIENTE PERIODO
            '-------------------------------------------------------
            Dim SiguientePeriodo As Date =
                PeriodoDesde.AddMonths(1)


            Dim PeriodoHasta As Date =
                SiguientePeriodo.AddDays(-1)


            '-------------------------------------------------------
            ' NO SUPERAR FECHA FIN DEL CONTRATO
            '-------------------------------------------------------
            If PeriodoHasta > FechaFinContrato Then

                PeriodoHasta = FechaFinContrato

            End If


            '-------------------------------------------------------
            ' CREAR CUOTA
            '-------------------------------------------------------
            Dim Item As New Ent_EstadoCuentaContrato


            Item.IdContrato = Contrato.IdContrato

            Item.CodigoContrato = Contrato.CodigoContrato

            Item.CodigoCliente = Contrato.CodigoCliente

            Item.NombreCliente = Contrato.NombreCliente


            Item.FechaInicioContrato = FechaInicioContrato

            Item.FechaFinContrato = FechaFinContrato


            Item.NroCuota = NroCuota


            Item.PeriodoDesde = PeriodoDesde

            Item.PeriodoHasta = PeriodoHasta


            Item.Moneda = Contrato.Moneda


            If Contrato.MontoMensual.HasValue Then

                Item.Monto = Contrato.MontoMensual.Value

            Else

                Item.Monto = 0

            End If


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            If Contrato.Ubicaciones IsNot Nothing Then

                Dim Ubicaciones As String = ""

                For Each Ubi As Ent_ApiUbicacion In Contrato.Ubicaciones

                    If Trim(Ubicaciones) <> "" Then
                        Ubicaciones &= ", "
                    End If

                    Ubicaciones &=
                        Ubi.Descripcion

                Next

                Item.Ubicaciones =
                    Ubicaciones

            End If


            '-------------------------------------------------------
            ' ESTADO INICIAL
            '-------------------------------------------------------
            Item.Estado = "PENDIENTE OT"


            Resultado.Add(Item)


            '-------------------------------------------------------
            ' SIGUIENTE CUOTA
            '-------------------------------------------------------
            PeriodoDesde = SiguientePeriodo

            NroCuota += 1


        Loop


        Return Resultado

    End Function

    Private Function GenerarEstadoCuenta(ByVal Contratos As List(Of Ent_ApiContrato)) As List(Of Ent_EstadoCuentaContrato)

        Dim Resultado As New List(Of Ent_EstadoCuentaContrato)


        For Each Contrato As Ent_ApiContrato In Contratos

            Dim Cuotas As List(Of Ent_EstadoCuentaContrato)

            Cuotas = GenerarCuotasContrato(Contrato)

            Resultado.AddRange(Cuotas)

        Next


        Return Resultado

    End Function

    Private Sub CruzarEstadoCuenta(ByVal Cuotas As List(Of Ent_EstadoCuentaContrato), ByVal DtFacturacion As DataTable)


        For Each Item As Ent_EstadoCuentaContrato In Cuotas


            For Each Fila As DataRow In DtFacturacion.Rows


                '---------------------------------------------------
                ' MISMO CONTRATO
                '---------------------------------------------------
                If Val(Fila("IdContratoExterno").ToString) <>
                   Item.IdContrato Then

                    Continue For

                End If


                If Fila("PeriodoDesde") Is DBNull.Value OrElse
                   Fila("PeriodoHasta") Is DBNull.Value Then

                    Continue For

                End If


                Dim PeriodoDesdeERP As Date = CDate(Fila("PeriodoDesde")).Date

                Dim PeriodoHastaERP As Date = CDate(Fila("PeriodoHasta")).Date


                '---------------------------------------------------
                ' MISMA CUOTA
                '---------------------------------------------------
                If PeriodoDesdeERP = Item.PeriodoDesde.Date AndAlso
                   PeriodoHastaERP = Item.PeriodoHasta.Date Then


                    Item.SerieOT = Fila("SerieOT").ToString

                    Item.NroOT = Fila("NroOT").ToString


                    Item.SerieFactura = Fila("SerieFactura").ToString

                    Item.NumeroFactura = Fila("NumeroFactura").ToString


                    If Fila("FechaEmision") IsNot DBNull.Value Then

                        Item.FechaEmision = CDate(Fila("FechaEmision")).Date

                    End If


                    '-----------------------------------------------
                    ' ESTADO
                    '-----------------------------------------------
                    If Val(Fila("AnuladoOT").ToString) <> 0 Then

                        'OT ANULADA:
                        'SEGUIR BUSCANDO OTRA OT PARA LA CUOTA
                        Continue For

                    End If


                    If Val(Fila("FacturadoOT").ToString) = 1 Then

                        Item.Estado = "FACTURADO"

                    Else

                        Item.Estado = "PENDIENTE FACTURAR"

                    End If


                    Exit For

                End If

            Next

        Next

    End Sub

    Private Sub Cargar_Grid(ByVal Cuotas As List(Of Ent_EstadoCuentaContrato))

        Dgv01.Rows.Clear()


        For Each Item As Ent_EstadoCuentaContrato In Cuotas


            Dgv01.Rows.Add()

            Dim F As Integer = Dgv01.RowCount - 1


            '-------------------------------------------------------
            ' CLIENTE
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("NombreCliente").Value = Item.NombreCliente


            '-------------------------------------------------------
            ' CONTRATO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Contrato").Value = Item.CodigoContrato


            '-------------------------------------------------------
            ' VIGENCIA CONTRATO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("InicioContrato").Value = Item.FechaInicioContrato.ToString("dd/MM/yyyy")

            Dgv01.Rows(F).Cells("FinContrato").Value = Item.FechaFinContrato.ToString("dd/MM/yyyy")


            '-------------------------------------------------------
            ' CUOTA
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Cuota").Value = Item.NroCuota


            '-------------------------------------------------------
            ' PERIODO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("PeriodoDesde").Value = Item.PeriodoDesde.ToString("dd/MM/yyyy")

            Dgv01.Rows(F).Cells("PeriodoHasta").Value = Item.PeriodoHasta.ToString("dd/MM/yyyy")


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Ubicaciones").Value = Item.Ubicaciones


            '-------------------------------------------------------
            ' OT
            '-------------------------------------------------------
            If Trim(Item.NroOT) <> "" Then

                Dgv01.Rows(F).Cells("OrdenTrabajo").Value =
                    Item.SerieOT &
                    "-" &
                    Item.NroOT

            Else

                Dgv01.Rows(F).Cells("OrdenTrabajo").Value = ""

            End If


            '-------------------------------------------------------
            ' ESTADO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Estado").Value = Item.Estado


            '-------------------------------------------------------
            ' FACTURA
            '-------------------------------------------------------
            If Trim(Item.NumeroFactura) <> "" Then

                Dgv01.Rows(F).Cells("Factura").Value =
                    Item.SerieFactura &
                    "-" &
                    Item.NumeroFactura

            Else

                Dgv01.Rows(F).Cells("Factura").Value = ""

            End If


            '-------------------------------------------------------
            ' FECHA FACTURA
            '-------------------------------------------------------
            If Item.FechaEmision.HasValue Then

                Dgv01.Rows(F).Cells("FechaFactura").Value = Item.FechaEmision.Value.ToString("dd/MM/yyyy")

            Else

                Dgv01.Rows(F).Cells("FechaFactura").Value = ""

            End If


            '-------------------------------------------------------
            ' MONEDA
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Moneda").Value = Item.Moneda


            '-------------------------------------------------------
            ' MONTO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Monto").Value = Format(Item.Monto, "N2")


            '-------------------------------------------------------
            ' CAMPOS OCULTOS
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("IdContrato").Value = Item.IdContrato

            Dgv01.Rows(F).Cells("SerieOT").Value = Item.SerieOT

            Dgv01.Rows(F).Cells("NroOT").Value = Item.NroOT


        Next


        LblRegistros.Text =
            "Registros: " &
            Dgv01.RowCount.ToString

    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click

        Try

            If DtpDesde.Value.Date > DtpHasta.Value.Date Then

                MsgBox("La fecha desde no puede ser mayor " & "que la fecha hasta.", vbExclamation, Compañia)

                Exit Sub

            End If


            Dgv01.Rows.Clear()

            Call LimpiarTotales()

            ListaEstadoCuenta.Clear()


            Cursor = Cursors.WaitCursor


            '=======================================================
            ' 1. CONSULTAR CONTRATOS EN API
            '=======================================================
            Dim ContratosApi As List(Of Ent_ApiContrato)

            ContratosApi = c_Neg_ApiMedXpress.ObtenerContratosPorFiltro(
            DtpDesde.Value.Date,
            DtpHasta.Value.Date,
            Trim(TxtCodCliente.Text),
            Trim(TxtContrato.Text))


            '=======================================================
            ' 2. FILTRAR CONTRATOS POR FECHA DE INICIO
            '=======================================================
            Dim Contratos As New List(Of Ent_ApiContrato)


            For Each Contrato As Ent_ApiContrato In ContratosApi

                If Contrato.FechaInicio.HasValue Then

                    If Contrato.FechaInicio.Value.Date >=
                   DtpDesde.Value.Date AndAlso
                   Contrato.FechaInicio.Value.Date <=
                   DtpHasta.Value.Date Then

                        Contratos.Add(Contrato)

                    End If

                End If

            Next


            '=======================================================
            ' 3. CONSULTAR OT / FACTURAS EN ERP
            '=======================================================
            Dim DtFacturacion As DataTable

            DtFacturacion = c_Neg_SalAlmContrato.get_SalAlmContrato_EstadoCuenta(Trim(TxtCodCliente.Text),
            Trim(TxtContrato.Text))


            '=======================================================
            ' 4. GENERAR TODAS LAS CUOTAS
            '=======================================================
            ListaEstadoCuenta = GenerarEstadoCuenta(Contratos)


            '=======================================================
            ' 5. CRUZAR CUOTAS CON OT / FACTURAS
            '=======================================================
            Call CruzarEstadoCuenta(ListaEstadoCuenta, DtFacturacion)


            '=======================================================
            ' 6. CARGAR GRID
            '=======================================================
            Call Cargar_Grid(ListaEstadoCuenta)


            '=======================================================
            ' 7. TOTALIZAR
            '=======================================================
            Call TotalizarEstadoCuenta(ListaEstadoCuenta)


        Catch ex As Exception

            ListaEstadoCuenta.Clear()

            MsgBox(
        "Error al consultar el estado de cuenta " &
        "de contratos:" &
        vbCrLf &
        ex.Message,
        vbCritical,
        Compañia)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LimpiarTotales()

        TxtFacturadoMN.Text = "0.00"
        TxtFacturadoME.Text = "0.00"

        TxtPendienteMN.Text = "0.00"
        TxtPendienteME.Text = "0.00"

    End Sub

    Private Sub TotalizarEstadoCuenta(ByVal Cuotas As List(Of Ent_EstadoCuentaContrato))

        Dim FacturadoMN As Decimal = 0
        Dim FacturadoME As Decimal = 0

        Dim PendienteMN As Decimal = 0
        Dim PendienteME As Decimal = 0


        '-------------------------------------------------------
        ' LIMPIAR
        '-------------------------------------------------------
        Call LimpiarTotales()


        '-------------------------------------------------------
        ' RECORRER CUOTAS
        '-------------------------------------------------------
        For Each Item As Ent_EstadoCuentaContrato In Cuotas


            '---------------------------------------------------
            ' MONEDA NACIONAL
            '---------------------------------------------------
            If UCase(Trim(Item.Moneda)) = "PEN" Then

                If Item.Estado = "FACTURADO" Then

                    FacturadoMN += Item.Monto

                ElseIf Item.Estado = "PENDIENTE FACTURAR" OrElse
                       Item.Estado = "PENDIENTE OT" Then

                    PendienteMN += Item.Monto

                End If

            End If


            '---------------------------------------------------
            ' MONEDA EXTRANJERA
            '---------------------------------------------------
            If UCase(Trim(Item.Moneda)) = "USD" Then

                If Item.Estado = "FACTURADO" Then

                    FacturadoME += Item.Monto

                ElseIf Item.Estado = "PENDIENTE FACTURAR" OrElse
                       Item.Estado = "PENDIENTE OT" Then

                    PendienteME += Item.Monto

                End If

            End If


        Next


        '-------------------------------------------------------
        ' MOSTRAR TOTALES
        '-------------------------------------------------------
        TxtFacturadoMN.Text = Format(FacturadoMN, "N2")

        TxtFacturadoME.Text = Format(FacturadoME, "N2")

        TxtPendienteMN.Text = Format(PendienteMN, "N2")

        TxtPendienteME.Text = Format(PendienteME, "N2")

    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        FrmConClientes.Close()

        FrmConClientes.MdiParent = FrmMenu
        FrmConClientes.Show()

        FrmConClientes.TxtVar.Text = 16

        FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub

    Private Sub TxtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCliente.TextChanged

    End Sub

    Private Sub TxtCodCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCliente.Clear()
            BtnMostrar.Focus()
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click

        Try

            '=======================================================
            ' 1. VALIDAR INFORMACION
            '=======================================================
            If ListaEstadoCuenta Is Nothing OrElse
           ListaEstadoCuenta.Count = 0 Then

                MsgBox(
                "No existen datos para imprimir." &
                vbCrLf &
                "Primero debe realizar una consulta.",
                vbExclamation,
                Compañia)

                Exit Sub

            End If


            Cursor = Cursors.WaitCursor


            '=======================================================
            ' 2. GENERAR DATATABLE PARA EL REPORTE
            '=======================================================
            Dim DtReporte As DsContratos.DtEstadoCuentaContratoDataTable

            DtReporte = GenerarDataTableReporte()


            '=======================================================
            ' 3. ABRIR VISOR DEL REPORTE
            '=======================================================
            Dim Frm As New FrmVisorReporte


            '=======================================================
            ' 4. LIMPIAR ORIGENES ANTERIORES
            '=======================================================
            Frm.RptVisor.LocalReport.DataSources.Clear()


            '=======================================================
            ' 5. CONFIGURAR REPORTE EMBEBIDO
            '=======================================================
            Frm.RptVisor.LocalReport.ReportEmbeddedResource = "WindowsApplication1.RptEstadoCuentaContrato.rdlc"

            '=======================================================
            ' 6. ASIGNAR DATOS
            '=======================================================
            Dim Fuente As New Microsoft.Reporting.WinForms.ReportDataSource

            Fuente.Name = "DtEstadoCuentaContrato"
            Fuente.Value = DtReporte

            Frm.RptVisor.LocalReport.DataSources.Add(Fuente)


            '=======================================================
            ' 7. REFRESCAR REPORTE
            '=======================================================
            Frm.RptVisor.RefreshReport()


            '=======================================================
            ' 7. REFRESCAR REPORTE
            '=======================================================
            Frm.RptVisor.RefreshReport()


            '=======================================================
            ' 8. CONFIGURAR VISTA PREVIA
            '=======================================================
            Frm.RptVisor.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Frm.RptVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent

            Frm.RptVisor.ZoomPercent = 100


            '=======================================================
            ' 9. MOSTRAR VISOR
            '=======================================================
            Frm.WindowState = FormWindowState.Maximized

            Frm.ShowDialog()


        Catch ex As Exception

            MsgBox(
            "Error al generar el reporte de estado de cuenta:" &
            vbCrLf &
            ex.Message,
            vbCritical,
            Compañia)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GenerarDataTableReporte() As DsContratos.DtEstadoCuentaContratoDataTable

        Dim Dt As New DsContratos.DtEstadoCuentaContratoDataTable

        For Each Item As Ent_EstadoCuentaContrato In ListaEstadoCuenta

            Dim Fila As DsContratos.DtEstadoCuentaContratoRow

            Fila = Dt.NewDtEstadoCuentaContratoRow()


            '=======================================================
            ' CONTRATO / CLIENTE
            '=======================================================
            Fila.IdContrato = Item.IdContrato
            Fila.CodigoContrato = Item.CodigoContrato
            Fila.CodigoCliente = Item.CodigoCliente
            Fila.NombreCliente = Item.NombreCliente

            Fila.FechaInicioContrato = Item.FechaInicioContrato
            Fila.FechaFinContrato = Item.FechaFinContrato


            '=======================================================
            ' CUOTA
            '=======================================================
            Fila.NroCuota = Item.NroCuota
            Fila.PeriodoDesde = Item.PeriodoDesde
            Fila.PeriodoHasta = Item.PeriodoHasta


            '=======================================================
            ' UBICACIONES
            '=======================================================
            If Item.Ubicaciones Is Nothing OrElse
               Trim(Item.Ubicaciones) = "" Then

                Fila.SetUbicacionesNull()

            Else

                Fila.Ubicaciones = Item.Ubicaciones

            End If


            '=======================================================
            ' ORDEN DE TRABAJO
            '=======================================================
            If Item.SerieOT Is Nothing OrElse
               Trim(Item.SerieOT) = "" Then

                Fila.SetSerieOTNull()

            Else

                Fila.SerieOT = Item.SerieOT

            End If


            If Item.NroOT Is Nothing OrElse
               Trim(Item.NroOT) = "" Then

                Fila.SetNroOTNull()

            Else

                Fila.NroOT = Item.NroOT

            End If


            '=======================================================
            ' ESTADO
            '=======================================================
            Fila.Estado = Item.Estado


            '=======================================================
            ' FACTURA
            '=======================================================
            If Item.SerieFactura Is Nothing OrElse
               Trim(Item.SerieFactura) = "" Then

                Fila.SetSerieFacturaNull()

            Else

                Fila.SerieFactura = Item.SerieFactura

            End If


            If Item.NumeroFactura Is Nothing OrElse
               Trim(Item.NumeroFactura) = "" Then

                Fila.SetNumeroFacturaNull()

            Else

                Fila.NumeroFactura = Item.NumeroFactura

            End If


            If Item.FechaEmision.HasValue Then

                Fila.FechaEmision = Item.FechaEmision.Value

            Else

                Fila.SetFechaEmisionNull()

            End If


            '=======================================================
            ' IMPORTE
            '=======================================================
            Fila.Moneda = Item.Moneda
            Fila.Monto = Item.Monto


            Dt.AddDtEstadoCuentaContratoRow(Fila)

        Next


        Return Dt

    End Function

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Call ExportarDataGridViewExcel(Dgv01, "CONTROL DE CUOTAS DE CONTRATOS", "Cuotas de Contratos", False, PgbExportar)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub TxtContrato_TextChanged(sender As Object, e As EventArgs) Handles TxtContrato.TextChanged

    End Sub

    Private Sub TxtContrato_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtContrato.KeyDown
        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            Call BuscarContratoDirecto()

        End If
    End Sub

    Private Sub BuscarContratoDirecto()

        Try

            If Trim(TxtContrato.Text) = "" Then

                MsgBox(
                    "Ingrese el código del contrato.",
                    vbExclamation,
                    Compañia)

                TxtContrato.Focus()

                Exit Sub

            End If


            Cursor = Cursors.WaitCursor

            Dgv01.Rows.Clear()

            LimpiarTotales()

            ListaEstadoCuenta.Clear()


            '=======================================================
            ' 1. CONSULTAR CONTRATO EN MEDXPRESS
            '    NO SE CONSIDERA EL RANGO DEL FORMULARIO
            '=======================================================
            Dim ContratosApi As List(Of Ent_ApiContrato)

            ContratosApi =
                c_Neg_ApiMedXpress.ObtenerContratosPorFiltro(
                    New Date(2000, 1, 1),
                    New Date(2100, 12, 31),
                    "",
                    Trim(TxtContrato.Text))


            '=======================================================
            ' 2. VALIDAR CONTRATO
            '=======================================================
            If ContratosApi Is Nothing OrElse
               ContratosApi.Count = 0 Then

                MsgBox(
                    "No se encontró el contrato " &
                    Trim(TxtContrato.Text) & ".",
                    vbExclamation,
                    Compañia)

                Exit Sub

            End If


            '=======================================================
            ' 3. GENERAR ESTADO DE CUENTA COMPLETO
            '=======================================================
            ListaEstadoCuenta =
                GenerarEstadoCuenta(ContratosApi)


            '=======================================================
            ' 4. CONSULTAR LAS OT / FACTURAS DEL ERP
            '=======================================================
            Dim DtFacturacion As DataTable

            DtFacturacion =
                c_Neg_SalAlmContrato.get_SalAlmContrato_EstadoCuenta(
                    "",
                    Trim(TxtContrato.Text))


            '=======================================================
            ' 5. CRUZAR CONTRATO VS OT / FACTURAS
            '=======================================================
            Call CruzarEstadoCuenta(
                ListaEstadoCuenta,
                DtFacturacion)


            '=======================================================
            ' 6. MOSTRAR RESULTADO
            '=======================================================
            Call Cargar_Grid(ListaEstadoCuenta)


            '=======================================================
            ' 7. TOTALIZAR
            '=======================================================
            Call TotalizarEstadoCuenta(ListaEstadoCuenta)


        Catch ex As Exception

            ListaEstadoCuenta.Clear()

            MsgBox(
                "Error al consultar el contrato:" &
                vbCrLf &
                ex.Message,
                vbCritical,
                Compañia)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub
End Class