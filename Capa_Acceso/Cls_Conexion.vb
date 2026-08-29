Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Environment
Imports System.Net
Public Class Cls_Conexion
    Public Shared Sub GetLocalIp()
        Dim hostname As String = Dns.GetHostName()
        Dim ipaddress As String = CType(Dns.GetHostByName(hostname).AddressList.GetValue(0), IPAddress).ToString
        Console.WriteLine("Computer Name: " & hostname & " IP Address: " & ipaddress)
        'MsgBox(hostname)
    End Sub
    Private Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New System.Net.WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New System.Text.RegularExpressions.Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                     .Matches(ExternalIP)(0).ToString()
            Return ExternalIP
        Catch
            Return Nothing
        End Try
    End Function
    Public Function GetConexion_Sql() As String
        'Version Anterior - Conexion SQL'
        'Dim Conex As String = "Provider=sqloledb;Data Source=PC-PROGRAM;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"
        'Dim Conex As String = "Provider=sqloledb;Data Source=SRVBAHIA;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"
        'Dim Conex As String = "Provider=sqloledb;Data Source=192.168.173.50;Initial Catalog=DBFastDye;User Id=sa;Password=;"
        'Dim Conex As String = "Provider=sqloledb;Data Source=201.230.227.1,1434;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"
        'If Conex Is String.Empty Then
        'Return String.Empty
        'Else
        'Return Conex
        'End If
        'Nueva Conexion'
        'Call Main()
        'MsgBox(GetExternalIp)
        'Dim fic As String = "177.91.249.57"
        ' Dim hostname As String = Dns.GetHostName()
        'Dim ipaddress As String = CType(Dns.GetHostByName(hostname).AddressList.GetValue(0), IPAddress).ToString

        Dim lineaServer As Integer = 7
        'If GetExternalIp() <> "177.91.249.57" Then
        'lineaServer = 20
        'End If
        'If ipaddress = "192.168.173.108" Then
        'lineaServer = 20
        'End If
        'If My.Computer.Network.Ping("192.168.1.10") Then
        '   lineaServer = 7
        'Else
        'lineaServer = 20
        'End If


        Dim fic As String = My.Application.Info.DirectoryPath & "\config.ini"
        Dim texto As String = ""
        Dim objReader As New StreamReader(fic)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        'Leemos Archivos
        Dim Servidor, DbProcesos, Usuario, Password, Timeout, Provider As String
        Dim Provider_Reporte As String = ""
        'MsgBox("linea " & lineaServer)
        Servidor = Trim(Mid(arrText.Item(lineaServer).ToString, 10, 30))
        DbProcesos = Trim(Mid(arrText.Item(8).ToString, 12, 30))
        Usuario = Trim(Mid(arrText.Item(9).ToString, 9, 30))
        Password = Trim(Mid(arrText.Item(10).ToString, 10, 30))
        Timeout = Trim(Mid(arrText.Item(11).ToString, 9, 30))
        Provider = Trim(Mid(arrText.Item(12).ToString, 10, 30))

        Dim Conex As String = "Provider=" & Provider & ";Data Source=" & Servidor & ";Initial Catalog=" & DbProcesos & ";User Id=" & fEncripta_Key(Usuario, False).ToString & _
        ";Password=" & fEncripta_Key(Password, False).ToString & ";Connect Timeout =   " & Timeout

        If Conex Is String.Empty Then
            Return String.Empty
        Else
            Return Conex
        End If
    End Function
    Public Function fEncripta_Key(ByVal cKey As String, ByVal lKey As Boolean) As String
        Dim nLen As Integer
        Dim R As Integer
        Dim cOld, cNew, cPas As String
        nLen = Len(cKey)
        For R = 1 To Len(cKey)
            cNew = Chr(Asc(Mid(cKey, R, 1)) + IIf(lKey, nLen, nLen * -1))
            cPas = cPas + cNew
        Next R
        fEncripta_Key = cPas
    End Function
End Class
