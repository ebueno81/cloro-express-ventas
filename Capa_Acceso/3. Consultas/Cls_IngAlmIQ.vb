Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_IngAlmIQ
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_IngAlm_Datos(ByVal Cadena As String, ByVal Emp As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlm"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = Emp
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
    Public Function Get_IngAlmCOM_Datos(ByVal Cadena As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlmCOM"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = Cadena
            cmd.Parameters.Add("@c_codi_emp", OleDbType.VarChar, 2).Value = c_codi_emp

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_IngAlmCOM_Datos2(ByVal Cadena As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlmCOM2"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_IngAlmRpt_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String, ByVal c_codi_prov As String, _
                                       ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String, _
                                        ByVal c_nro_ing As String, ByVal c_serie_guia As String, ByVal c_nro_guia As String, _
                                         ByVal c_serie_doc As String, ByVal c_nro_doc As String, ByVal cOpcion As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Rpt_IngAlm"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = c_codi_prov
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = c_codi_scd
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = c_nro_ing
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 3).Value = c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = c_nro_doc
            cmd.Parameters.Add("@cOpcion", OleDbType.VarChar, 3).Value = cOpcion

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
