Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnClienteArt
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_ClienteArt_Save(ByVal ent As Ent_MnClienteArt) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ClienteArt"

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_precio_srv_us", OleDbType.Decimal, 15, 7).Value = ent.c_precio_srv_us
            cmd.Parameters.Add("@c_precio_srv_mn", OleDbType.Decimal, 15, 7).Value = ent.c_precio_srv_mn
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
    Public Function Get_ClienteArt_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ClienteArt"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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
