Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports Capa_Entidades

Public Class Cls_ApiMedXpress

    Private Configuracion As New Cls_Conexion


    Public Function ObtenerContratosCliente(
        ByVal CodigoCliente As String
    ) As List(Of Ent_ApiContrato)

        Dim Resultado As New List(Of Ent_ApiContrato)

        '-------------------------------------------------------
        ' 1. LEER CONFIGURACION DE LA API
        '-------------------------------------------------------
        Dim UrlBase As String =
            Configuracion.LeerConfiguracion(
                "ApiMedXpressUrl")

        Dim TimeoutTexto As String =
            Configuracion.LeerConfiguracion(
                "ApiMedXpressTimeout")


        '-------------------------------------------------------
        ' 2. VALIDAR URL
        '-------------------------------------------------------
        If UrlBase Is Nothing OrElse
           Trim(UrlBase) = "" Then

            Throw New Exception(
                "No se encontró el parámetro " &
                "ApiMedXpressUrl en el archivo config.ini.")

        End If


        UrlBase = UrlBase.Trim()


        'Eliminar "/" final si existe
        If UrlBase.EndsWith("/") Then

            UrlBase =
                UrlBase.Substring(
                    0,
                    UrlBase.Length - 1)

        End If


        '-------------------------------------------------------
        ' 3. OBTENER TIMEOUT
        '-------------------------------------------------------
        Dim Timeout As Integer = 15000

        If TimeoutTexto IsNot Nothing AndAlso
           Trim(TimeoutTexto) <> "" Then

            If Not Integer.TryParse(
                TimeoutTexto,
                Timeout) Then

                Timeout = 15000

            End If

        End If


        '-------------------------------------------------------
        ' 4. CONSTRUIR URL
        '-------------------------------------------------------
        Dim Url As String =
            UrlBase &
            "/api/clientes/" &
            CodigoCliente.Trim() &
            "/contratos"


        '-------------------------------------------------------
        ' 5. VALIDAR URL COMPLETA
        '-------------------------------------------------------
        Dim UriApi As Uri = Nothing

        If Not Uri.TryCreate(
            Url,
            UriKind.Absolute,
            UriApi) Then

            Throw New Exception(
                "La URL de la API de MedXpress " &
                "no es válida." &
                vbCrLf &
                "URL: " & Url)

        End If


        Dim Request As HttpWebRequest = Nothing
        Dim Response As HttpWebResponse = Nothing
        Dim Reader As StreamReader = Nothing


        Try

            '-------------------------------------------------------
            ' 6. CREAR REQUEST
            '-------------------------------------------------------
            Request =
                CType(
                    WebRequest.Create(UriApi),
                    HttpWebRequest)

            Request.Method = "GET"

            Request.Accept =
                "application/json"

            Request.Timeout =
                Timeout

            Request.ReadWriteTimeout =
                Timeout


            '-------------------------------------------------------
            ' 7. EJECUTAR LLAMADA
            '-------------------------------------------------------
            Response =
                CType(
                    Request.GetResponse(),
                    HttpWebResponse)


            '-------------------------------------------------------
            ' 8. LEER RESPUESTA
            '-------------------------------------------------------
            If Response.StatusCode =
               HttpStatusCode.OK Then

                Reader =
                    New StreamReader(
                        Response.GetResponseStream(),
                        Encoding.UTF8)

                Dim Json As String =
                    Reader.ReadToEnd()


                '---------------------------------------------------
                ' 9. DESERIALIZAR JSON
                '---------------------------------------------------
                Dim Serializer As New JavaScriptSerializer

                Resultado =
                    Serializer.Deserialize(
                        Of List(Of Ent_ApiContrato))(Json)

            End If


            If Resultado Is Nothing Then

                Resultado =
                    New List(Of Ent_ApiContrato)

            End If


            Return Resultado


        Catch Ex As WebException

            Return ProcesarErrorWeb(Ex)


        Catch Ex As Exception

            Throw New Exception(
                "Error al consultar la API de MedXpress: " &
                Ex.Message,
                Ex)


        Finally

            If Reader IsNot Nothing Then
                Reader.Close()
            End If

            If Response IsNot Nothing Then
                Response.Close()
            End If

        End Try

    End Function


    Private Function ProcesarErrorWeb(
        ByVal Ex As WebException
    ) As List(Of Ent_ApiContrato)

        If Ex.Response IsNot Nothing Then

            Dim Response As HttpWebResponse =
                CType(
                    Ex.Response,
                    HttpWebResponse)

            Try

                Select Case Response.StatusCode

                    Case HttpStatusCode.NotFound

                        'Cliente sin contratos activos
                        Return New List(Of Ent_ApiContrato)


                    Case HttpStatusCode.BadRequest

                        Throw New Exception(
                            "La solicitud enviada a MedXpress " &
                            "no es válida.")


                    Case HttpStatusCode.InternalServerError

                        Throw New Exception(
                            "El servicio de MedXpress presentó " &
                            "un error interno.")


                    Case Else

                        Throw New Exception(
                            "Error al consultar MedXpress. " &
                            "Código HTTP: " &
                            CInt(
                                Response.StatusCode
                            ).ToString())

                End Select

            Finally

                Response.Close()

            End Try

        End If


        '-------------------------------------------------------
        ' TIMEOUT
        '-------------------------------------------------------
        If Ex.Status =
           WebExceptionStatus.Timeout Then

            Throw New Exception(
                "Se agotó el tiempo de espera al consultar " &
                "el servicio de MedXpress.")

        End If


        '-------------------------------------------------------
        ' NO HAY CONEXION
        '-------------------------------------------------------
        If Ex.Status =
           WebExceptionStatus.ConnectFailure Then

            Throw New Exception(
                "No se pudo establecer conexión con " &
                "el servicio de MedXpress.")

        End If


        Throw New Exception(
            "No se pudo consultar el servicio de MedXpress: " &
            Ex.Message)

    End Function

End Class