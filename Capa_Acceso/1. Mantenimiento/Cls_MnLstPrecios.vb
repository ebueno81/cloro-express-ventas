Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_MnLstPrecios
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_ColorVta_Save(ByVal ent As Ent_MnLstPrecios) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ColorVta"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_partida", OleDbType.VarChar, 10).Value = ent.c_nro_partida
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 10).Value = ent.c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 10).Value = ent.c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 10).Value = ent.c_codi_scd
            cmd.Parameters.Add("@c_codi_color", OleDbType.VarChar, 10).Value = ent.c_codi_color
            cmd.Parameters.Add("@c_costo_mn", OleDbType.Numeric, 10, 2).Value = ent.c_costo_mn
            cmd.Parameters.Add("@c_costo_us", OleDbType.Numeric, 10, 2).Value = ent.c_costo_us
            cmd.Parameters.Add("@c_venta_mn", OleDbType.Numeric, 10, 2).Value = ent.c_venta_mn
            cmd.Parameters.Add("@c_venta_us", OleDbType.Numeric, 10, 2).Value = ent.c_venta_us
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
    Public Function Get_ColoresVta_Grid(ByVal Cadena As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Dgv_ColorVta"

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
    Public Function Get_ColoresVta_Datos(ByVal Cadena As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ColorVta"

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
End Class
