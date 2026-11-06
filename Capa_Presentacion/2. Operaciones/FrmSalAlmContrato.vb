Imports Capa_Entidades
Imports Capa_Negocios

Public Class FrmSalAlmContrato

    Public Property SerieOT As String
    Public Property NroOT As String
    Public Property CodigoCliente As String
    Public Property Cliente As String

    Public Property OpcContrato As Integer
    Public Property OpcFacturado As Integer

    Private ListaContratos As New List(Of Ent_ApiContrato)
    Private IdContratoExterno As Integer = 0
    Private CargandoContratos As Boolean = False

    Private IdOrdenContrato As Integer = 0

    '===============================================================
    ' LOAD
    '===============================================================
    Private Sub FrmSalAlmContrato_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        TxtSerieOT.Text = SerieOT
        TxtNroOT.Text = NroOT
        TxtCliente.Text = Cliente

        'Cargar monedas
        ModUtils.CargarComboMoneda(CboMoneda)

        ConfigurarFormulario()


        '=========================================================
        ' LA OT YA TIENE CONTRATO
        '=========================================================
        If OpcContrato = 1 Then

            'No consultar API.
            'Leer el contrato que quedó grabado en Facturación.
            MostrarContratoOT()

            '-----------------------------------------------------
            ' YA ESTÁ FACTURADO
            '-----------------------------------------------------
            If OpcFacturado = 1 Then

                ConfigurarSoloLectura()

            Else

                '-------------------------------------------------
                ' TODAVÍA NO ESTÁ FACTURADO
                '-------------------------------------------------
                ConfigurarEdicion()

            End If


        Else

            '=====================================================
            ' LA OT TODAVÍA NO TIENE CONTRATO
            '=====================================================
            ConfigurarNuevo()

            'Consultar contratos disponibles en MedXpress
            ConsultarContratosCliente()

        End If

    End Sub


    '===============================================================
    ' CONFIGURAR FORMULARIO
    '===============================================================
    Private Sub ConfigurarFormulario()

        '-----------------------------------------------------------
        ' Datos provenientes del contrato
        ' No deben ser modificados por Facturación
        '-----------------------------------------------------------
        DtpFechaInicioContrato.Enabled = False
        DtpFechaFinContrato.Enabled = False

        TxtMontoMensual.ReadOnly = True
        TxtUbicaciones.ReadOnly = True

        CboMoneda.Enabled = False

        '-----------------------------------------------------------
        ' Combo de contratos
        '-----------------------------------------------------------
        CboContrato.DropDownStyle =
            ComboBoxStyle.DropDownList

    End Sub


    '===============================================================
    ' CONSULTAR CONTRATOS DEL CLIENTE
    '===============================================================
    Private Sub ConsultarContratosCliente()

        Try

            If Trim(CodigoCliente) = "" Then

                MsgBox(
                    "No se ha indicado el código del cliente.",
                    vbExclamation,
                    Compañia)

                Exit Sub

            End If


            Dim NegApi As New Neg_ApiMedXpress


            ListaContratos =
                NegApi.ObtenerContratosCliente(
                    CodigoCliente)


            CargandoContratos = True

            CboContrato.Items.Clear()


            '-------------------------------------------------------
            ' NO TIENE CONTRATOS
            '-------------------------------------------------------
            If ListaContratos Is Nothing OrElse
               ListaContratos.Count = 0 Then

                CargandoContratos = False

                MsgBox(
                    "El cliente no tiene contratos activos.",
                    vbInformation,
                    Compañia)

                Exit Sub

            End If


            '-------------------------------------------------------
            ' CARGAR COMBO
            '-------------------------------------------------------
            For Each Contrato As Ent_ApiContrato _
                In ListaContratos

                CboContrato.Items.Add(
                    Contrato.CodigoContrato)

            Next


            '-------------------------------------------------------
            ' UN SOLO CONTRATO
            '-------------------------------------------------------
            If ListaContratos.Count = 1 Then

                CboContrato.SelectedIndex = 0

                CargandoContratos = False

                CargarContrato(
                    ListaContratos(0))

            Else

                '---------------------------------------------------
                ' VARIOS CONTRATOS
                '---------------------------------------------------
                'No seleccionar ninguno automáticamente.
                CboContrato.SelectedIndex = -1

                CargandoContratos = False

                LimpiarDatosContrato()

            End If


        Catch ex As Exception

            CargandoContratos = False

            MsgBox(
                ex.Message,
                vbCritical,
                Compañia)

        End Try

    End Sub


    '===============================================================
    ' SELECCIONAR CONTRATO
    '===============================================================
    Private Sub CboContrato_SelectedIndexChanged(
        ByVal sender As System.Object,
        ByVal e As System.EventArgs
    ) Handles CboContrato.SelectedIndexChanged

        'Evitar ejecutar mientras estamos cargando el combo
        If CargandoContratos Then
            Exit Sub
        End If


        If CboContrato.SelectedIndex < 0 Then
            Exit Sub
        End If


        If ListaContratos Is Nothing Then
            Exit Sub
        End If


        If CboContrato.SelectedIndex >=
           ListaContratos.Count Then

            Exit Sub

        End If


        Dim Contrato As Ent_ApiContrato =
            ListaContratos(
                CboContrato.SelectedIndex)


        CargarContrato(Contrato)

    End Sub


    '===============================================================
    ' CARGAR DATOS DEL CONTRATO
    '===============================================================
    Private Sub CargarContrato(
        ByVal Contrato As Ent_ApiContrato)

        '-----------------------------------------------------------
        ' ID EXTERNO
        '-----------------------------------------------------------
        IdContratoExterno =
            Contrato.IdContrato


        '-----------------------------------------------------------
        ' FECHA INICIO
        '-----------------------------------------------------------
        If Contrato.FechaInicio.HasValue Then

            DtpFechaInicioContrato.Value =
                Contrato.FechaInicio.Value

        End If


        '-----------------------------------------------------------
        ' FECHA FIN
        '-----------------------------------------------------------
        If Contrato.FechaFin.HasValue Then

            DtpFechaFinContrato.Value =
                Contrato.FechaFin.Value

        End If


        '-----------------------------------------------------------
        ' MONTO MENSUAL
        '-----------------------------------------------------------
        If Contrato.MontoMensual.HasValue Then

            TxtMontoMensual.Text =
                Contrato.MontoMensual.Value.ToString("N2")

        Else

            TxtMontoMensual.Text = "0.00"

        End If


        '-----------------------------------------------------------
        ' MONEDA
        '-----------------------------------------------------------
        CboMoneda.SelectedIndex = -1

        If Contrato.Moneda IsNot Nothing AndAlso Trim(Contrato.Moneda) <> "" Then

            CboMoneda.SelectedValue = Contrato.Moneda.Trim().ToUpper()

        End If


        '-----------------------------------------------------------
        ' UBICACIONES
        '-----------------------------------------------------------
        TxtUbicaciones.Text =
            ObtenerUbicacionesTexto(
                Contrato.Ubicaciones)


        '-----------------------------------------------------------
        ' OBSERVACION
        '-----------------------------------------------------------
        If Contrato.Observacion IsNot Nothing Then

            TxtObservacion.Text =
                Contrato.Observacion

        Else

            TxtObservacion.Text = ""

        End If


        '-----------------------------------------------------------
        ' CONFIGURAR PERIODO
        '-----------------------------------------------------------
        ConfigurarPeriodoContrato(Contrato)

    End Sub


    '===============================================================
    ' CONFIGURAR PERIODO INICIAL
    '===============================================================
    Private Sub ConfigurarPeriodoContrato(
        ByVal Contrato As Ent_ApiContrato)

        Dim FechaActual As Date =
            Date.Today


        '-----------------------------------------------------------
        ' DESDE
        '-----------------------------------------------------------
        If Contrato.FechaInicio.HasValue Then

            If FechaActual <
               Contrato.FechaInicio.Value.Date Then

                DtpPeriodoDesde.Value =
                    Contrato.FechaInicio.Value.Date

            ElseIf Contrato.FechaFin.HasValue AndAlso
                   FechaActual >
                   Contrato.FechaFin.Value.Date Then

                DtpPeriodoDesde.Value =
                    Contrato.FechaFin.Value.Date

            Else

                DtpPeriodoDesde.Value =
                    FechaActual

            End If

        End If


        '-----------------------------------------------------------
        ' HASTA
        '-----------------------------------------------------------
        DtpPeriodoHasta.Value =
            DtpPeriodoDesde.Value

    End Sub


    '===============================================================
    ' LIMPIAR DATOS DEL CONTRATO
    '===============================================================
    Private Sub LimpiarDatosContrato()

        IdContratoExterno = 0

        TxtMontoMensual.Text = ""
        CboMoneda.SelectedIndex = -1
        TxtUbicaciones.Text = ""
        TxtObservacion.Text = ""

    End Sub


    '===============================================================
    ' OBTENER UBICACIONES COMO TEXTO
    '===============================================================
    Private Function ObtenerUbicacionesTexto(
        ByVal Ubicaciones As List(Of Ent_ApiUbicacion)
    ) As String

        If Ubicaciones Is Nothing OrElse
           Ubicaciones.Count = 0 Then

            Return ""

        End If


        Dim Resultado As String = ""


        For Each Ubicacion As Ent_ApiUbicacion _
            In Ubicaciones

            If Ubicacion.Descripcion IsNot Nothing AndAlso
               Trim(Ubicacion.Descripcion) <> "" Then

                If Resultado <> "" Then
                    Resultado &= ", "
                End If

                Resultado &=
                    Ubicacion.Descripcion.Trim()

            End If

        Next


        Return Resultado

    End Function


    '===============================================================
    ' VALIDAR PERIODO
    '===============================================================
    Private Function ValidarPeriodoContrato() As Boolean

        If IdContratoExterno = 0 Then

            MsgBox(
                "Debe seleccionar un contrato.",
                vbExclamation,
                Compañia)

            Return False

        End If


        Dim FechaInicioContrato As Date =
            DtpFechaInicioContrato.Value.Date

        Dim FechaFinContrato As Date =
            DtpFechaFinContrato.Value.Date

        Dim PeriodoDesde As Date =
            DtpPeriodoDesde.Value.Date

        Dim PeriodoHasta As Date =
            DtpPeriodoHasta.Value.Date


        '-----------------------------------------------------------
        ' DESDE NO PUEDE SER MAYOR QUE HASTA
        '-----------------------------------------------------------
        If PeriodoDesde > PeriodoHasta Then

            MsgBox(
                "La fecha inicial del período no puede " &
                "ser mayor que la fecha final.",
                vbExclamation,
                Compañia)

            Return False

        End If


        '-----------------------------------------------------------
        ' VALIDAR VIGENCIA
        '-----------------------------------------------------------
        If PeriodoDesde < FechaInicioContrato OrElse
           PeriodoHasta > FechaFinContrato Then

            MsgBox(
                "El período a facturar debe encontrarse " &
                "dentro de la vigencia del contrato." &
                vbCrLf & vbCrLf &
                "Vigencia: " &
                FechaInicioContrato.ToString("dd/MM/yyyy") &
                " al " &
                FechaFinContrato.ToString("dd/MM/yyyy"),
                vbExclamation,
                Compañia)

            Return False

        End If


        Return True

    End Function


    '===============================================================
    ' GUARDAR
    '===============================================================
    Private Sub BtnGuardar_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs
) Handles BtnGuardar.Click

        Try

            '===========================================================
            ' SEGURIDAD - OT FACTURADA
            '===========================================================
            If OpcFacturado = 1 Then

                MsgBox(
                "La Orden de Trabajo ya se encuentra facturada." &
                vbCrLf &
                "No se puede modificar el contrato.",
                vbExclamation,
                Compañia)

                Exit Sub

            End If


            '===========================================================
            ' VALIDAR CONTRATO
            '===========================================================
            If IdContratoExterno = 0 Then

                MsgBox(
                "Debe seleccionar un contrato.",
                vbExclamation,
                Compañia)

                Exit Sub

            End If


            '===========================================================
            ' VALIDAR PERIODO
            '===========================================================
            If Not ValidarPeriodoContrato() Then
                Exit Sub
            End If


            '===========================================================
            ' NUEVO / MODIFICAR
            '===========================================================
            If OpcContrato = 0 Then

                GuardarNuevoContrato()

            Else

                ModificarContrato()

            End If


        Catch ex As Exception

            MsgBox(
            ex.Message,
            vbCritical,
            Compañia)

        End Try

    End Sub

    Private Sub GuardarNuevoContrato()

        '===========================================================
        ' OBTENER CONTRATO SELECCIONADO
        '===========================================================
        If CboContrato.SelectedIndex < 0 Then

            MsgBox(
            "Debe seleccionar un contrato.",
            vbExclamation,
            Compañia)

            Exit Sub

        End If


        Dim Contrato As Ent_ApiContrato =
        ListaContratos(
            CboContrato.SelectedIndex)


        '===========================================================
        ' CONFIRMACION
        '===========================================================
        If MsgBox(
        "¿Está seguro de registrar el contrato " &
        Contrato.CodigoContrato &
        " para la Orden de Trabajo?" &
        vbCrLf & vbCrLf &
        "Período: " &
        DtpPeriodoDesde.Value.ToString("dd/MM/yyyy") &
        " al " &
        DtpPeriodoHasta.Value.ToString("dd/MM/yyyy"),
        vbQuestion + vbYesNo,
        Compañia) <> vbYes Then

            Exit Sub

        End If


        '===========================================================
        ' ENTIDAD
        '===========================================================
        Dim Entidad As New Ent_SalAlmContrato

        Entidad.vOpt = "ADD"

        Entidad.SerieOT =
        TxtSerieOT.Text.Trim()

        Entidad.NroOT =
        TxtNroOT.Text.Trim()

        Entidad.IdContratoExterno =
        Contrato.IdContrato

        Entidad.CodigoContrato =
        Contrato.CodigoContrato

        Entidad.FechaInicioContrato =
        Contrato.FechaInicio.Value.Date

        Entidad.FechaFinContrato =
        Contrato.FechaFin.Value.Date

        Entidad.MontoMensual =
        Contrato.MontoMensual.Value

        Entidad.Moneda =
        Contrato.Moneda.Trim()

        Entidad.PeriodoDesde =
        DtpPeriodoDesde.Value.Date

        Entidad.PeriodoHasta =
        DtpPeriodoHasta.Value.Date

        Entidad.Ubicaciones =
        ObtenerUbicacionesTexto(
            Contrato.Ubicaciones)

        Entidad.Observacion =
        TxtObservacion.Text.Trim()


        '===========================================================
        ' GUARDAR
        '===========================================================
        Dim Negocio As New Neg_SalAlmContrato

        Dim IdOrdenContrato As Integer =
        Negocio.set_SalAlmContrato_Save(
            Entidad)


        If IdOrdenContrato > 0 Then

            MsgBox(
            "El contrato fue registrado correctamente." &
            vbCrLf & vbCrLf &
            "Contrato: " &
            Contrato.CodigoContrato,
            vbInformation,
            Compañia)

            Me.DialogResult =
            Windows.Forms.DialogResult.OK

            Me.Close()

        Else

            MsgBox(
            "No se pudo registrar el contrato.",
            vbExclamation,
            Compañia)

        End If

    End Sub

    Private Sub ModificarContrato()

        If MsgBox(
        "¿Está seguro de actualizar los datos del contrato?" &
        vbCrLf & vbCrLf &
        "Período: " &
        DtpPeriodoDesde.Value.ToString("dd/MM/yyyy") &
        " al " &
        DtpPeriodoHasta.Value.ToString("dd/MM/yyyy"),
        vbQuestion + vbYesNo,
        Compañia) <> vbYes Then

            Exit Sub

        End If


        Dim Entidad As New Ent_SalAlmContrato

        Entidad.vOpt = "UPD"

        Entidad.IdOrdenContrato = IdOrdenContrato

        Entidad.SerieOT = TxtSerieOT.Text.Trim()

        Entidad.NroOT = TxtNroOT.Text.Trim()

        Entidad.IdContratoExterno = IdContratoExterno

        Entidad.PeriodoDesde = DtpPeriodoDesde.Value.Date

        Entidad.PeriodoHasta = DtpPeriodoHasta.Value.Date

        Entidad.Observacion = TxtObservacion.Text.Trim()

        Dim Negocio As New Neg_SalAlmContrato

        Dim Resultado As Integer = Negocio.set_SalAlmContrato_Save(Entidad)

        If Resultado > 0 Then

            MsgBox(
            "Los datos del contrato fueron actualizados correctamente.",
            vbInformation,
            Compañia)

            Me.DialogResult =
            Windows.Forms.DialogResult.OK

            Me.Close()

        Else

            MsgBox(
            "No se pudo actualizar el contrato.",
            vbExclamation,
            Compañia)

        End If

    End Sub
    Private Sub ConfigurarNuevo()

        CboContrato.Enabled = True

        DtpFechaInicioContrato.Enabled = False
        DtpFechaFinContrato.Enabled = False

        TxtMontoMensual.ReadOnly = True
        CboMoneda.Enabled = False
        TxtUbicaciones.ReadOnly = True

        DtpPeriodoDesde.Enabled = True
        DtpPeriodoHasta.Enabled = True
        TxtObservacion.ReadOnly = False

        BtnGuardar.Enabled = True

    End Sub


    Private Sub ConfigurarEdicion()

        'El contrato ya está asociado a la OT.
        'No se puede cambiar por otro.
        CboContrato.Enabled = False

        DtpFechaInicioContrato.Enabled = False
        DtpFechaFinContrato.Enabled = False

        TxtMontoMensual.ReadOnly = True
        CboMoneda.Enabled = False
        TxtUbicaciones.ReadOnly = True

        'Solamente estos datos son editables
        DtpPeriodoDesde.Enabled = True
        DtpPeriodoHasta.Enabled = True
        TxtObservacion.ReadOnly = False

        BtnGuardar.Enabled = True

    End Sub


    Private Sub ConfigurarSoloLectura()

        CboContrato.Enabled = False

        DtpFechaInicioContrato.Enabled = False
        DtpFechaFinContrato.Enabled = False

        TxtMontoMensual.ReadOnly = True
        CboMoneda.Enabled = False
        TxtUbicaciones.ReadOnly = True

        DtpPeriodoDesde.Enabled = False
        DtpPeriodoHasta.Enabled = False
        TxtObservacion.ReadOnly = True

        'Ya está facturado
        BtnGuardar.Enabled = False

    End Sub

    Private Sub MostrarContratoOT()

        Try

            '===========================================================
            ' CONSULTAR CONTRATO GUARDADO EN FACTURACION
            '===========================================================
            Dim Negocio As New Neg_SalAlmContrato

            Dim DtContrato As DataTable = Negocio.get_SalAlmContrato_Datos(SerieOT, NroOT)


            '===========================================================
            ' VALIDAR RESULTADO
            '===========================================================
            If DtContrato Is Nothing OrElse DtContrato.Rows.Count = 0 Then

                MsgBox("No se encontró el contrato asociado a la Orden de Trabajo.", vbExclamation, Compañia)

                Exit Sub

            End If


            Dim Fila As DataRow = DtContrato.Rows(0)

            '===========================================================
            ' ID CONTRATO EXTERNO
            '===========================================================
            If Not IsDBNull(Fila("IdContratoExterno")) Then

                IdContratoExterno = CInt(Fila("IdContratoExterno"))

            Else

                IdContratoExterno = 0

            End If

            If Not IsDBNull(Fila("IdOrdenContrato")) Then

                IdOrdenContrato = CInt(Fila("IdOrdenContrato"))

            Else

                IdOrdenContrato = 0

            End If

            '===========================================================
            ' CODIGO CONTRATO
            '===========================================================
            CargandoContratos = True

            CboContrato.Items.Clear()

            If Not IsDBNull(Fila("CodigoContrato")) Then

                CboContrato.Items.Add(
                Fila("CodigoContrato").ToString().Trim())

                CboContrato.SelectedIndex = 0

            Else

                CboContrato.SelectedIndex = -1

            End If

            CargandoContratos = False


            '===========================================================
            ' FECHA INICIO CONTRATO
            '===========================================================
            If Not IsDBNull(Fila("FechaInicioContrato")) Then

                DtpFechaInicioContrato.Value =
                CDate(Fila("FechaInicioContrato"))

            End If


            '===========================================================
            ' FECHA FIN CONTRATO
            '===========================================================
            If Not IsDBNull(Fila("FechaFinContrato")) Then

                DtpFechaFinContrato.Value =
                CDate(Fila("FechaFinContrato"))

            End If


            '===========================================================
            ' MONTO MENSUAL
            '===========================================================
            If Not IsDBNull(Fila("MontoMensual")) Then

                TxtMontoMensual.Text =
                CDec(Fila("MontoMensual")).ToString("N2")

            Else

                TxtMontoMensual.Text = "0.00"

            End If


            '===========================================================
            ' MONEDA
            '===========================================================
            CboMoneda.SelectedIndex = -1

            If Not IsDBNull(Fila("Moneda")) Then

                Dim CodigoMoneda As String =
                Fila("Moneda").ToString().Trim().ToUpper()

                CboMoneda.SelectedValue =
                CodigoMoneda

            End If


            '===========================================================
            ' PERIODO DESDE
            '===========================================================
            If Not IsDBNull(Fila("PeriodoDesde")) Then

                DtpPeriodoDesde.Value =
                CDate(Fila("PeriodoDesde"))

            End If


            '===========================================================
            ' PERIODO HASTA
            '===========================================================
            If Not IsDBNull(Fila("PeriodoHasta")) Then

                DtpPeriodoHasta.Value =
                CDate(Fila("PeriodoHasta"))

            End If


            '===========================================================
            ' UBICACIONES
            '===========================================================
            If Not IsDBNull(Fila("Ubicaciones")) Then

                TxtUbicaciones.Text =
                Fila("Ubicaciones").ToString().Trim()

            Else

                TxtUbicaciones.Text = ""

            End If

            '===========================================================
            ' OBSERVACION
            '===========================================================
            If Not IsDBNull(Fila("Observacion")) Then

                TxtObservacion.Text =
                Fila("Observacion").ToString().Trim()

            Else

                TxtObservacion.Text = ""

            End If


        Catch ex As Exception

            CargandoContratos = False

            MsgBox(
            "Error al consultar el contrato de la Orden de Trabajo." &
            vbCrLf & vbCrLf &
            ex.Message,
            vbCritical,
            Compañia)

        End Try

    End Sub

    Private Sub FrmSalAlmContrato_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class