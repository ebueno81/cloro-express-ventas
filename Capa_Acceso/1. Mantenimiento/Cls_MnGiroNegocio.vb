Imports System.Data.OleDb

Public Class Cls_MnGiroNegocio

    Private Conexion As New Cls_Conexion
    Private Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Private cmd As New OleDbCommand

    Public Function Get_GiroNegocio_Datos(ByVal soloActivos As Boolean) As DataTable

        Dim Tabla As New DataTable

        Try
            cmd.Connection = Conex
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Sp_Sca_GiroNegocio_Listar"

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@SoloActivos", OleDbType.Boolean).Value = soloActivos

            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            Using aD As New OleDbDataAdapter(cmd)
                aD.Fill(Tabla)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Conex.State = ConnectionState.Open Then
                Conex.Close()
            End If
        End Try

        Return Tabla

    End Function

End Class