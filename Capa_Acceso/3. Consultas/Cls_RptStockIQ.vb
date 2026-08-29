Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_RptStockIQ
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_StockIQ_Datos(ByVal Cadena As String, ByVal c_año_stock As Integer, ByVal c_mes_stock As Integer, _
                                      ByVal c_codi_alm As String, ByVal c_codi_mon As String, ByVal vOpt As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 5000
        cmd.CommandText = "Sp_Scal_Datos_StockIQ"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try

            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@c_año_stock", OleDbType.Integer).Value = c_año_stock
            cmd.Parameters.Add("@c_mes_stock", OleDbType.Integer).Value = c_mes_stock
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
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
