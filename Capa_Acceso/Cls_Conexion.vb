Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Sockets
Imports System.Windows.Forms

Public Class Cls_Conexion

    '===============================================================
    ' LEER VALOR DEL CONFIG.INI
    '===============================================================
    Public Function LeerConfiguracion(ByVal clave As String) As String

        Dim archivo As String =
            Path.Combine(My.Application.Info.DirectoryPath, "config.ini")

        If Not File.Exists(archivo) Then
            Throw New Exception("No se encontró el archivo config.ini.")
        End If

        Dim lineas() As String = File.ReadAllLines(archivo)

        For Each lineaOriginal As String In lineas

            Dim linea As String = lineaOriginal.Trim()

            'Ignorar líneas vacías
            If linea = String.Empty Then
                Continue For
            End If

            'Ignorar comentarios
            If linea.StartsWith("'") OrElse linea.StartsWith(";") Then
                Continue For
            End If

            'Ignorar secciones como [CONEXION]
            If linea.StartsWith("[") Then
                Continue For
            End If

            'Separar solamente por el primer =
            Dim partes() As String =
                linea.Split(New Char() {"="c}, 2)

            If partes.Length = 2 Then

                Dim nombreParametro As String = partes(0).Trim()
                Dim valorParametro As String = partes(1).Trim()

                If nombreParametro.Equals(
                    clave,
                    StringComparison.OrdinalIgnoreCase) Then

                    Return valorParametro

                End If

            End If

        Next

        Return String.Empty

    End Function


    '===============================================================
    ' OBTENER CADENA DE CONEXIÓN SQL
    '===============================================================
    Public Function GetConexion_Sql() As String

        Try

            Dim TipoConexion As String =
                LeerConfiguracion("TipoConexion").ToUpper()

            Dim Servidor As String = String.Empty

            Select Case TipoConexion

                Case "LOCAL"
                    Servidor = LeerConfiguracion("ServidorLocal")

                Case "REMOTO"
                    Servidor = LeerConfiguracion("ServidorRemoto")

                Case Else
                    Throw New Exception(
                        "El TipoConexion configurado no es válido." &
                        vbCrLf &
                        "Los valores permitidos son LOCAL o REMOTO.")

            End Select


            Dim DbProcesos As String =
                LeerConfiguracion("DbProcesos")

            Dim Usuario As String =
                LeerConfiguracion("Usuario")

            Dim Password As String =
                LeerConfiguracion("Password")

            Dim Timeout As String =
                LeerConfiguracion("TimeOut")

            Dim Provider As String =
                LeerConfiguracion("Provider")


            'Validaciones
            If Servidor = String.Empty Then
                Throw New Exception(
                    "No se ha configurado el servidor.")
            End If

            If DbProcesos = String.Empty Then
                Throw New Exception(
                    "No se ha configurado la base de datos.")
            End If

            If Usuario = String.Empty Then
                Throw New Exception(
                    "No se ha configurado el usuario.")
            End If

            If Password = String.Empty Then
                Throw New Exception(
                    "No se ha configurado la contraseña.")
            End If

            If Provider = String.Empty Then
                Throw New Exception(
                    "No se ha configurado el proveedor.")
            End If


            'Construir cadena de conexión
            Dim Conex As String =
                "Provider=" & Provider &
                ";Data Source=" & Servidor &
                ";Initial Catalog=" & DbProcesos &
                ";User Id=" & fEncripta_Key(Usuario, False) &
                ";Password=" & fEncripta_Key(Password, False) &
                ";Connect Timeout=" & Timeout

            Return Conex

        Catch ex As Exception

            MessageBox.Show("Error al obtener la configuración de conexión." &
                vbCrLf & vbCrLf &
                ex.Message,
                "Configuración de conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Return String.Empty

        End Try

    End Function


    '===============================================================
    ' OBTENER TIPO DE CONEXIÓN ACTUAL
    '===============================================================
    Public Function GetTipoConexion() As String

        Return LeerConfiguracion("TipoConexion").ToUpper()

    End Function

    '===============================================================
    ' OBTENER SERVIDOR SQL ACTUAL
    '===============================================================
    Public Function GetServidorActual() As String

        Dim TipoConexion As String = GetTipoConexion()

        Dim Servidor As String = ""

        Select Case TipoConexion

            Case "LOCAL"
                Servidor = LeerConfiguracion("ServidorLocal")

            Case "REMOTO"
                Servidor = LeerConfiguracion("ServidorRemoto")

            Case Else
                Throw New Exception("TipoConexion no válido: [" & TipoConexion & "]")

        End Select

        Return Servidor

    End Function

    '===============================================================
    ' OBTENER SERVIDOR DE REPORTES ACTUAL
    '===============================================================
    Public Function GetServidorReportes() As String

        Dim TipoConexion As String = GetTipoConexion()

        Select Case TipoConexion

            Case "LOCAL"
                Return LeerConfiguracion("ReportesLocal")

            Case "REMOTO"
                Return LeerConfiguracion("ReportesRemoto")

            Case Else
                Throw New Exception(
                "El TipoConexion configurado no es válido. " &
                "Los valores permitidos son LOCAL o REMOTO.")

        End Select

    End Function

    '===============================================================
    ' GUARDAR TIPO DE CONEXIÓN
    '===============================================================
    Public Sub GuardarTipoConexion(ByVal tipo As String)

        tipo = tipo.Trim().ToUpper()

        If tipo <> "LOCAL" AndAlso tipo <> "REMOTO" Then
            Throw New Exception(
                "Tipo de conexión no válido.")
        End If


        Dim archivo As String =
            Path.Combine(My.Application.Info.DirectoryPath, "config.ini")

        If Not File.Exists(archivo) Then
            Throw New Exception(
                "No se encontró el archivo config.ini.")
        End If


        'ReadAllLines devuelve directamente String()
        Dim lineas() As String =
            File.ReadAllLines(archivo)

        Dim encontrado As Boolean = False


        For i As Integer = 0 To lineas.Length - 1

            If lineas(i).Trim().StartsWith(
                "TipoConexion=",
                StringComparison.OrdinalIgnoreCase) Then

                lineas(i) = "TipoConexion=" & tipo

                encontrado = True
                Exit For

            End If

        Next

        If Not encontrado Then
            Throw New Exception(
                "No se encontró el parámetro TipoConexion en config.ini.")
        End If

        File.WriteAllLines(archivo, lineas)

    End Sub


    '===============================================================
    ' ENCRIPTACIÓN ACTUAL DEL ERP
    '===============================================================
    Public Function fEncripta_Key(
        ByVal cKey As String,
        ByVal lKey As Boolean) As String

        Dim nLen As Integer
        Dim R As Integer
        Dim cNew As String
        Dim cPas As String = String.Empty

        nLen = Len(cKey)

        For R = 1 To Len(cKey)

            cNew =
                Chr(
                    Asc(Mid(cKey, R, 1)) +
                    IIf(lKey, nLen, nLen * -1))

            cPas = cPas + cNew

        Next

        Return cPas

    End Function

    Public Function ProbarConexion(ByRef mensaje As String) As Boolean

        Try

            '-------------------------------------------------------
            '1. Obtener servidor actual
            '-------------------------------------------------------
            Dim servidorCompleto As String =
            GetServidorActual()

            If servidorCompleto Is Nothing OrElse Trim(servidorCompleto) = "" Then
                mensaje = "No se ha configurado el servidor."
                Return False
            End If

            '-------------------------------------------------------
            '2. Separar IP/Nombre y puerto
            '   Ejemplo: 177.91.249.57,1436
            '-------------------------------------------------------
            Dim partes() As String =
            servidorCompleto.Split(","c)

            Dim servidor As String =
            partes(0).Trim()

            Dim puerto As Integer = 1433

            If partes.Length > 1 Then

                If Not Integer.TryParse(
                partes(1).Trim(),
                puerto) Then

                    mensaje = "El puerto SQL configurado no es válido."
                    Return False

                End If

            End If

            '-------------------------------------------------------
            '3. Prueba TCP rápida - máximo 3 segundos
            '-------------------------------------------------------
            Using cliente As New TcpClient()

                Dim resultado As IAsyncResult = cliente.BeginConnect(servidor, puerto, Nothing, Nothing)

                Dim conectado As Boolean =
                resultado.AsyncWaitHandle.WaitOne(
                    TimeSpan.FromSeconds(3))

                If Not conectado Then

                    mensaje = "El servidor " & servidor & ":" & puerto.ToString() & " no responde."
                    Return False

                End If

                cliente.EndConnect(resultado)

            End Using

            '-------------------------------------------------------
            '4. Si el puerto responde, probamos SQL Server
            '-------------------------------------------------------
            Dim cadena As String =
            GetConexion_Sql()

            Dim builder As New OleDbConnectionStringBuilder(cadena)

            builder("Connect Timeout") = 5

            Using cn As New OleDbConnection(
            builder.ConnectionString)

                cn.Open()

                If cn.State = ConnectionState.Open Then

                    mensaje = "OK"
                    Return True

                End If

            End Using

            mensaje = "No fue posible establecer conexión con SQL Server."

            Return False

        Catch ex As Exception

            mensaje = ex.Message
            Return False

        End Try

    End Function

End Class