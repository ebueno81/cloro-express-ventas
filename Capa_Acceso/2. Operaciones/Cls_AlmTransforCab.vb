Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_AlmTransforCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand

    ' Datos '
    Public Function Get_AlmTransformaCab_Datos(ByVal c_nro_transforma As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_TransforCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_transforma", OleDbType.VarChar, 7).Value = c_nro_transforma
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
    Public Function Get_RptTransformaVenta_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String,
                                                   ByVal c_codi_cd As String, ByVal c_codi_articulo As String, ByVal c_codi_alm As String,
                                                 ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Rpt_TransVenta"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm
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
