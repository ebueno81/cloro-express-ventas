Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Usuarios
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_Usuario_Save(ByVal ent As Ent_Usuario) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_Usuario"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_usua", OleDbType.VarChar, 10).Value = ent.c_codi_usua
            cmd.Parameters.Add("@c_clave_usua", OleDbType.VarChar, 10).Value = ent.c_clave_usua
            cmd.Parameters.Add("@c_nom_usua", OleDbType.VarChar, 50).Value = ent.c_nom_usua
            cmd.Parameters.Add("@c_nom_pc", OleDbType.VarChar, 30).Value = ent.c_nom_pc
            cmd.Parameters.Add("@c_codi_area", OleDbType.VarChar, 2).Value = ent.c_codi_area
            cmd.Parameters.Add("@c_email_usua", OleDbType.VarChar, 50).Value = ent.c_email_usua
            cmd.Parameters.Add("@c_serie_bol", OleDbType.VarChar, 5).Value = ent.c_serie_bol
            cmd.Parameters.Add("@c_serie_fact", OleDbType.VarChar, 5).Value = ent.c_serie_fact
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 5).Value = ent.c_serie_guia
            cmd.Parameters.Add("@c_serie_nc", OleDbType.VarChar, 5).Value = ent.c_serie_nc
            cmd.Parameters.Add("@c_serie_nd", OleDbType.VarChar, 5).Value = ent.c_serie_nd
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = ent.c_codi_alm
            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = ent.c_codi_vende
            cmd.Parameters.Add("@c_fecha_activa", OleDbType.Integer).Value = ent.c_fecha_activa
            cmd.Parameters.Add("@c_usua_admin", OleDbType.Integer).Value = ent.c_usua_admin
            cmd.Parameters.Add("@c_usua_precio", OleDbType.Integer).Value = ent.c_usua_precio

            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
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
    Public Function Get_Usuarios_Acceso(ByVal Cadena As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_UsuaAcceso"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function sca_UsuaPermiso_Save(ByVal ent As Ent_UsuaPermiso) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_UsuaPermiso"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_usua", OleDbType.VarChar, 10).Value = ent.c_codi_usua
            cmd.Parameters.Add("@c_codi_modulo", OleDbType.VarChar, 5).Value = ent.c_codi_modulo
            cmd.Parameters.Add("@c_add_obj", OleDbType.VarChar, 50).Value = ent.c_add_obj
            cmd.Parameters.Add("@c_edit_obj", OleDbType.VarChar, 50).Value = ent.c_edit_obj
            cmd.Parameters.Add("@c_find_obj", OleDbType.VarChar, 50).Value = ent.c_find_obj
            cmd.Parameters.Add("@c_del_obj", OleDbType.VarChar, 50).Value = ent.c_del_obj

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

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

    Public Function Get_Usuario_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_Usuario"

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

    Public Function Get_UsuaPermiso_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_UsuaPermiso"

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

End Class
