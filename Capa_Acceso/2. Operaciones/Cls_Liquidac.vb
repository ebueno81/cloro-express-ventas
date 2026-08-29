Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Liquidac
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_Liquidac_Save(ByVal Ent As Ent_Liquidac, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Sca_" & Emp & "_upt_Liquidac"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_liq", OleDbType.VarChar, 7).Value = Ent.c_nro_liq
            cmd.Parameters.Add("@c_año_liq", OleDbType.Integer).Value = Ent.c_año_liq
            cmd.Parameters.Add("@c_sist_bahia", OleDbType.Integer).Value = Ent.c_sist_bahia
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = Ent.c_codi_clie
            cmd.Parameters.Add("@c_reten_liq", OleDbType.Decimal, 10, 2).Value = Ent.c_reten_liq
            cmd.Parameters.Add("@c_cant_reten", OleDbType.Decimal, 10, 2).Value = Ent.c_cant_reten
            cmd.Parameters.Add("@c_total_liq", OleDbType.Decimal, 10, 2).Value = Ent.c_total_liq
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_motivo_anula", OleDbType.VarChar, 70).Value = Ent.c_motivo_anula
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = Ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion
            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 7)
            Codi_Auto.Direction = ParameterDirection.Output
            'ejecutamos query
            cmd.ExecuteNonQuery()
            'enviamos el nro de orden autogenerado...
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
        Return Codigo
    End Function
    Public Function Sca_Liquidac_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_Liquidac"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = Emp

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
