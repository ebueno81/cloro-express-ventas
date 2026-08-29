Imports System.Data
Imports System.Data.OleDb
Public Class Cls_RptRegVentas
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_RptRegVentasas_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_mon As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Rpt_RegVentas"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_RptVtasTiendas_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_TmpVtasTiendas"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final

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
