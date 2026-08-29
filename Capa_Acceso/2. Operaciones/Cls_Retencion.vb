Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Retencion
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_Retencion_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandTimeout = 60
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_Retencion"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt


            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_Retencion_Liberar(ByVal c_nro_correl As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandTimeout = 60
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_RetenLiberar"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_Correl", OleDbType.VarChar, 8).Value = c_nro_correl
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt


            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
End Class
