Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_FactAnexo
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_FactAnexo_SAVE(ByVal ent As Ent_FactAnexo) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_FactAnexo"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try

            If Conex.State = ConnectionState.Closed Then Conex.Open()

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.Integer).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = ent.c_nro_factura
            cmd.Parameters.Add("@c_total_factura", OleDbType.Decimal, 10, 2).Value = ent.c_total_factura
            cmd.Parameters.Add("@c_serie_anexo", OleDbType.VarChar, 5).Value = ent.c_serie_anexo
            cmd.Parameters.Add("@c_factura_anexo", OleDbType.VarChar, 10).Value = ent.c_factura_anexo
            cmd.Parameters.Add("@c_monto_anexo", OleDbType.Numeric, 12, 2).Value = ent.c_monto_anexo
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
    Public Function Sca_FactAnexo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_FactAnexo"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try

            If Conex.State = ConnectionState.Closed Then Conex.Open()

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
