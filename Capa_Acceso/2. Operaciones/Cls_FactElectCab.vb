Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_FactElectCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_FactElectCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_FactElectCab"
        cmd.CommandTimeout = 6000
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
    Public Function sca_FactElectCab_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_codi_doc As String,
                                          ByVal vOpt As String) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_FactElectCab"
        cmd.CommandTimeout = 6000
        'Definimos variable de salida
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = c_nro_factura
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = vOpt
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
    End Function
    Public Function Get_FactElectronico_Datos(ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String,
                                          ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_FactElectCab"
        cmd.CommandTimeout = 6000
        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 7).Value = c_nro_doc
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc
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
