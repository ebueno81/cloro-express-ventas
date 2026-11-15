Imports Capa_Entidades
Imports Capa_Negocios

Public Class FrmRptFacturacionContrato

    Dim c_Neg_ApiMedXpress As New Neg_ApiMedXpress

    Dim c_Neg_SalAlmContrato As New Neg_SalAlmContrato

    Private Sub FrmRptFacturacionContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Configurar_Grid()
    End Sub

    Private Sub Configurar_Grid()

        With Dgv01

            .Columns.Clear()

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False

            .RowHeadersVisible = False
            .ReadOnly = True

            .SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

            '-------------------------------------------------------
            ' NOMBRE CLIENTE
            '-------------------------------------------------------
            .Columns.Add("NombreCliente", "Cliente")

            .Columns("NombreCliente").Width = 220


            '-------------------------------------------------------
            ' CONTRATO
            '-------------------------------------------------------
            .Columns.Add(
            "Contrato",
            "Contrato")

            .Columns("Contrato").Width = 110


            '-------------------------------------------------------
            ' PERIODO DESDE
            '-------------------------------------------------------
            .Columns.Add(
            "PeriodoDesde",
            "Desde")

            .Columns("PeriodoDesde").Width = 80


            '-------------------------------------------------------
            ' PERIODO HASTA
            '-------------------------------------------------------
            .Columns.Add(
            "PeriodoHasta",
            "Hasta")

            .Columns("PeriodoHasta").Width = 80


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            .Columns.Add(
            "Ubicaciones",
            "Ubicaciones")

            .Columns("Ubicaciones").Width = 180


            '-------------------------------------------------------
            ' ORDEN TRABAJO
            '-------------------------------------------------------
            .Columns.Add(
            "OrdenTrabajo",
            "O.T.")

            .Columns("OrdenTrabajo").Width = 100


            '-------------------------------------------------------
            ' ESTADO
            '-------------------------------------------------------
            .Columns.Add(
            "Estado",
            "Estado")

            .Columns("Estado").Width = 125


            '-------------------------------------------------------
            ' FACTURA
            '-------------------------------------------------------
            .Columns.Add(
            "Factura",
            "Factura")

            .Columns("Factura").Width = 105


            '-------------------------------------------------------
            ' FECHA FACTURA
            '-------------------------------------------------------
            .Columns.Add(
            "FechaFactura",
            "Fecha Fact.")

            .Columns("FechaFactura").Width = 85


            '-------------------------------------------------------
            ' MONEDA
            '-------------------------------------------------------
            .Columns.Add(
            "Moneda",
            "Mon.")

            .Columns("Moneda").Width = 55


            '-------------------------------------------------------
            ' MONTO
            '-------------------------------------------------------
            .Columns.Add(
            "Monto",
            "Monto")

            .Columns("Monto").Width = 90

            .Columns("Monto").
            DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight


            '-------------------------------------------------------
            ' CAMPOS OCULTOS
            '-------------------------------------------------------
            .Columns.Add(
            "IdContrato",
            "IdContrato")

            .Columns("IdContrato").Visible = False


            .Columns.Add(
            "SerieOT",
            "SerieOT")

            .Columns("SerieOT").Visible = False


            .Columns.Add(
            "NroOT",
            "NroOT")

            .Columns("NroOT").Visible = False


        End With

    End Sub

    Private Sub Cargar_Grid(ByVal Periodos As List(Of Ent_ReporteFacturacionContrato))

        Dgv01.Rows.Clear()


        For Each Item As Ent_ReporteFacturacionContrato In Periodos


            '-------------------------------------------------------
            ' APLICAR FILTRO DE ESTADO
            '-------------------------------------------------------
            If RdbFacturados.Checked = True AndAlso
           Item.Estado <> "FACTURADO" Then

                Continue For

            End If


            If RdbPendienteFacturar.Checked = True AndAlso
           Item.Estado <> "PENDIENTE FACTURAR" Then

                Continue For

            End If



            '-------------------------------------------------------
            ' AGREGAR FILA
            '-------------------------------------------------------
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
            ' PERIODO
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("PeriodoDesde").Value = Item.PeriodoDesde.ToString("dd/MM/yyyy")

            Dgv01.Rows(F).Cells("PeriodoHasta").Value = Item.PeriodoHasta.ToString("dd/MM/yyyy")


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            Dgv01.Rows(F).Cells("Ubicaciones").Value = Item.Ubicaciones


            '-------------------------------------------------------
            ' ORDEN TRABAJO
            '-------------------------------------------------------
            If Trim(Item.NroOT) <> "" Then

                Dgv01.Rows(F).Cells("OrdenTrabajo").Value = Item.SerieOT & "-" & Item.NroOT

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

                Dgv01.Rows(F).Cells("Factura").Value = Item.SerieFactura & "-" & Item.NumeroFactura

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


        LblRegistros.Text = "Registros: " & Dgv01.RowCount.ToString

    End Sub

    Private Function GenerarPeriodosContrato(ByVal Contrato As Ent_ApiContrato, ByVal FechaConsultaDesde As Date, ByVal FechaConsultaHasta As Date
) As List(Of Ent_ReporteFacturacionContrato)

        Dim Resultado As New List(Of Ent_ReporteFacturacionContrato)


        '-------------------------------------------------------
        ' VALIDAR FECHA INICIO
        '-------------------------------------------------------
        If Contrato.FechaInicio.HasValue = False Then
            Return Resultado
        End If


        Dim FechaInicioContrato As Date =
        Contrato.FechaInicio.Value.Date


        Dim FechaFinContrato As Date


        '-------------------------------------------------------
        ' DETERMINAR FECHA FIN
        '-------------------------------------------------------
        If Contrato.FechaFin.HasValue Then

            FechaFinContrato =
            Contrato.FechaFin.Value.Date

        Else

            FechaFinContrato =
            FechaConsultaHasta.Date

        End If


        Dim PeriodoDesde As Date =
        FechaInicioContrato


        '-------------------------------------------------------
        ' GENERAR PERIODOS
        '-------------------------------------------------------
        Do While PeriodoDesde <= FechaFinContrato


            Dim SiguientePeriodo As Date =
            PeriodoDesde.AddMonths(1)


            Dim PeriodoHasta As Date =
            SiguientePeriodo.AddDays(-1)


            '---------------------------------------------------
            ' NO SUPERAR FECHA FIN DEL CONTRATO
            '---------------------------------------------------
            If PeriodoHasta > FechaFinContrato Then

                PeriodoHasta =
                FechaFinContrato

            End If


            '---------------------------------------------------
            ' VALIDAR QUE EL PERIODO ESTE DENTRO
            ' DEL RANGO CONSULTADO
            '---------------------------------------------------
            If PeriodoDesde <= FechaConsultaHasta.Date AndAlso
           PeriodoHasta >= FechaConsultaDesde.Date Then


                Dim Item As New Ent_ReporteFacturacionContrato


                Item.IdContrato = Contrato.IdContrato

                Item.CodigoContrato = Contrato.CodigoContrato

                Item.CodigoCliente = Contrato.CodigoCliente

                Item.NombreCliente = Contrato.NombreCliente

                Item.PeriodoDesde = PeriodoDesde

                Item.PeriodoHasta = PeriodoHasta

                Item.Moneda = Contrato.Moneda


                If Contrato.MontoMensual.HasValue Then

                    Item.Monto =
                    Contrato.MontoMensual.Value

                Else

                    Item.Monto = 0

                End If


                '------------------------------------------------
                ' ESTADO INICIAL
                '------------------------------------------------
                Item.Estado = "PENDIENTE OT"


                '------------------------------------------------
                ' UBICACIONES
                '------------------------------------------------
                Item.Ubicaciones = ""

                If Contrato.Ubicaciones IsNot Nothing Then

                    For Each Ubicacion As Ent_ApiUbicacion In
                    Contrato.Ubicaciones

                        If Ubicacion.Descripcion IsNot Nothing AndAlso
                       Trim(Ubicacion.Descripcion) <> "" Then

                            If Item.Ubicaciones <> "" Then

                                Item.Ubicaciones &= ", "

                            End If

                            Item.Ubicaciones &=
                            Ubicacion.Descripcion.Trim()

                        End If

                    Next

                End If


                Resultado.Add(Item)

            End If


            PeriodoDesde = SiguientePeriodo

        Loop


        Return Resultado

    End Function

    Private Function GenerarPeriodosEsperados(ByVal Contratos As List(Of Ent_ApiContrato)) As List(Of Ent_ReporteFacturacionContrato)

        Dim Resultado As New List(Of Ent_ReporteFacturacionContrato)


        For Each Contrato As Ent_ApiContrato In Contratos


            Dim Periodos As List(Of Ent_ReporteFacturacionContrato)


            Periodos =
                GenerarPeriodosContrato(
                    Contrato,
                    DtpDesde.Value.Date,
                    DtpHasta.Value.Date)


            Resultado.AddRange(
                Periodos)


        Next


        Return Resultado

    End Function

    Private Function GenerarListaFacturacion(ByVal DtFacturacion As DataTable) As List(Of Ent_ReporteFacturacionContrato)

        Dim Resultado As New List(Of Ent_ReporteFacturacionContrato)


        For Each Fila As DataRow In DtFacturacion.Rows


            '-------------------------------------------------------
            ' NO MOSTRAR ORDENES ANULADAS
            '-------------------------------------------------------
            If Val(Fila("AnuladoOT").ToString) <> 0 Then
                Continue For
            End If


            Dim Item As New Ent_ReporteFacturacionContrato


            '-------------------------------------------------------
            ' CONTRATO
            '-------------------------------------------------------
            Item.IdContrato = Val(Fila("IdContratoExterno").ToString)

            Item.CodigoContrato = Fila("CodigoContrato").ToString

            Item.CodigoCliente = Fila("CodigoCliente").ToString


            '-------------------------------------------------------
            ' CLIENTE
            '-------------------------------------------------------
            If DtFacturacion.Columns.Contains("NombreCliente") Then

                Item.NombreCliente = Fila("NombreCliente").ToString

            End If


            '-------------------------------------------------------
            ' PERIODO FACTURADO
            '-------------------------------------------------------
            If Fila("PeriodoDesde") IsNot DBNull.Value Then

                Item.PeriodoDesde = CDate(Fila("PeriodoDesde")).Date

            End If


            If Fila("PeriodoHasta") IsNot DBNull.Value Then

                Item.PeriodoHasta = CDate(Fila("PeriodoHasta")).Date

            End If


            '-------------------------------------------------------
            ' UBICACIONES
            '-------------------------------------------------------
            Item.Ubicaciones = Fila("Ubicaciones").ToString


            '-------------------------------------------------------
            ' ORDEN DE TRABAJO
            '-------------------------------------------------------
            Item.SerieOT = Fila("SerieOT").ToString

            Item.NroOT = Fila("NroOT").ToString


            '-------------------------------------------------------
            ' MONEDA / MONTO
            '-------------------------------------------------------
            Item.Moneda = Fila("Moneda").ToString

            If Fila("MontoMensual") IsNot DBNull.Value Then

                Item.Monto = CDec(Fila("MontoMensual"))

            End If


            '-------------------------------------------------------
            ' ESTADO REAL DE LA OT
            '-------------------------------------------------------
            If Val(Fila("FacturadoOT").ToString) = 1 Then

                Item.Estado = "FACTURADO"

            Else

                Item.Estado = "PENDIENTE FACTURAR"

            End If


            '-------------------------------------------------------
            ' DATOS DE FACTURA
            '-------------------------------------------------------
            Item.SerieFactura = Fila("SerieFactura").ToString

            Item.NumeroFactura = Fila("NumeroFactura").ToString


            If Fila("FechaEmision") IsNot DBNull.Value Then

                Item.FechaEmision = CDate(Fila("FechaEmision")).Date

            End If


            '-------------------------------------------------------
            ' AGREGAR
            '-------------------------------------------------------
            Resultado.Add(Item)


        Next


        Return Resultado

    End Function

    Private Sub LimpiarTotales()

        TxtFacturadoMN.Text = "0.00"
        TxtFacturadoME.Text = "0.00"

        TxtPendienteMN.Text = "0.00"
        TxtPendienteME.Text = "0.00"

    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click

        Try

            If DtpDesde.Value.Date > DtpHasta.Value.Date Then

                MsgBox(
                "La fecha desde no puede ser mayor " &
                "que la fecha hasta.",
                vbExclamation,
                Compañia)

                Exit Sub

            End If

            Dgv01.Rows.Clear()

            LimpiarTotales()

            Cursor = Cursors.WaitCursor


            '=======================================================
            ' 1. CONSULTAR ORDENES DE TRABAJO DE CONTRATOS
            '=======================================================
            Dim DtFacturacion As DataTable

            DtFacturacion =
            c_Neg_SalAlmContrato.get_SalAlmContrato_Reporte(
                DtpDesde.Value.Date,
                DtpHasta.Value.Date,
                Trim(TxtCodCliente.Text),
                Trim(TxtContrato.Text))


            '=======================================================
            ' 2. GENERAR LISTA DE FACTURACION
            '=======================================================
            Dim Resultado As List(Of Ent_ReporteFacturacionContrato)

            Resultado = GenerarListaFacturacion(DtFacturacion)


            '=======================================================
            ' 3. MOSTRAR RESULTADO
            '=======================================================
            Call Cargar_Grid(Resultado)

            '=======================================================
            ' 4. TOTALIZAR FACTURACION
            '=======================================================

            Call TotalizarFacturacion(Resultado)

        Catch ex As Exception

            MsgBox(
            "Error al consultar la facturación " &
            "de contratos:" &
            vbCrLf &
            ex.Message,
            vbCritical,
            Compañia)

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub TotalizarFacturacion(ByVal Resultado As List(Of Ent_ReporteFacturacionContrato))

        Dim FacturadoMN As Decimal = 0
        Dim FacturadoME As Decimal = 0

        Dim PendienteMN As Decimal = 0
        Dim PendienteME As Decimal = 0


        '-------------------------------------------------------
        ' LIMPIAR TOTALES
        '-------------------------------------------------------
        Call LimpiarTotales()


        For Each Item As Ent_ReporteFacturacionContrato In Resultado


            '-------------------------------------------------------
            ' RESPETAR FILTRO SELECCIONADO
            '-------------------------------------------------------
            If RdbFacturados.Checked = True AndAlso
           Item.Estado <> "FACTURADO" Then

                Continue For

            End If


            If RdbPendienteFacturar.Checked = True AndAlso
           Item.Estado <> "PENDIENTE FACTURAR" Then

                Continue For

            End If


            '-------------------------------------------------------
            ' MONEDA NACIONAL
            '-------------------------------------------------------
            If UCase(Trim(Item.Moneda)) = "PEN" Then

                If Item.Estado = "FACTURADO" Then

                    FacturadoMN += Item.Monto

                ElseIf Item.Estado = "PENDIENTE FACTURAR" Then

                    PendienteMN += Item.Monto

                End If

            End If


            '-------------------------------------------------------
            ' MONEDA EXTRANJERA
            '-------------------------------------------------------
            If UCase(Trim(Item.Moneda)) = "USD" Then

                If Item.Estado = "FACTURADO" Then

                    FacturadoME += Item.Monto

                ElseIf Item.Estado = "PENDIENTE FACTURAR" Then

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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Call ExportarDataGridViewExcel(Dgv01, "CONTROL DE FACTURACIÓN DE CONTRATOS", "Facturacion Contratos", False, PgbExportar)
    End Sub

    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click
        FrmConClientes.Close()

        FrmConClientes.MdiParent = FrmMenu
        FrmConClientes.Show()

        FrmConClientes.TxtVar.Text = 17

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
End Class