Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_ConPrecCosto
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_PrecCosto_Datos(ByVal ent As Ent_ConPrecCosto) As Decimal
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_PrecioCosto"
        Dim Codi_Auto As OleDbParameter
        Dim PrecCosto As Decimal = 0
        'Dim Tabla As New DataTable
        'Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = ent.c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = ent.c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 8).Value = ent.c_codi_scd
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = ent.c_codi_alm
            cmd.Parameters.Add("@c_nro_partida", OleDbType.VarChar, 10).Value = ent.c_nro_partida
            cmd.Parameters.Add("@c_fecha_kdx", OleDbType.Date).Value = ent.c_fecha_kdx

            Codi_Auto = cmd.Parameters.Add("@PrecCosto", OleDbType.VarChar, 15)
            Codi_Auto.Direction = ParameterDirection.Output
            'aD = New OleDbDataAdapter(cmd)
            'Tabla = New DataTable
            'aD.Fill(Tabla)
            cmd.ExecuteNonQuery()
            PrecCosto = Codi_Auto.Value
            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return PrecCosto

    End Function
End Class
