Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_AlmSalTaAnexo
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_Registro_Save(ent As Ent_AlmSalTaAnexo, vOpt As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_GuiaAnexo"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.Integer).Value = ent.C_nro_correl
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.C_serie_guia
            cmd.Parameters.Add("@c_nro_salidaTA", OleDbType.VarChar, 8).Value = ent.C_nro_guia

            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.C_codi_doc
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.C_nro_serie

            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 10).Value = ent.C_nro_doc



            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = vOpt

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 7)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    'Datos
    Public Function Get_Registro_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_GuiaDoc"

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
