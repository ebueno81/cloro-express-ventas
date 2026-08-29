Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_ComisDocs
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_ComisDocs_SAVE(ByVal ent As Ent_ComisDocs) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ComisDocs"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 7).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_comis", OleDbType.VarChar, 7).Value = ent.c_nro_comis
            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = ent.c_codi_vende
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 3).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_imp_doc", OleDbType.Numeric, 12, 2).Value = ent.c_imp_doc
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
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
    Public Function Sca_ComisDocs_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ComisDocs"

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
