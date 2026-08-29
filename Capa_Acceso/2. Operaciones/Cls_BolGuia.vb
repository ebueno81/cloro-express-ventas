Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_BolGuia
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_BolGuia_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_BolGuia"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
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
    Public Function sca_BolGuia_Save(ByVal ent As Ent_BolGuia, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_BolGuia"
        'Definimos variable de salida
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 5).Value = ent.c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 10).Value = ent.c_nro_guia
            cmd.Parameters.Add("@c_serie_boleta", OleDbType.VarChar, 5).Value = ent.c_serie_boleta
            cmd.Parameters.Add("@c_nro_boleta", OleDbType.VarChar, 10).Value = ent.c_nro_boleta
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_total_guia", OleDbType.Decimal, 10, 2).Value = ent.c_total_guia

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
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
End Class
