Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_RetenDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_RetenDet_Save(ByVal Ent As Ent_RetenDet, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_RetenDet"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = Ent.c_nro_ing
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = Ent.c_nro_correl
            cmd.Parameters.Add("@c_fecha_doc", OleDbType.Date).Value = Ent.c_fecha_doc
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = Ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 5).Value = Ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 10).Value = Ent.c_nro_doc
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Decimal, 10, 3).Value = Ent.c_tpo_cambio

            cmd.Parameters.Add("@c_imp_doc", OleDbType.Decimal, 10, 2).Value = Ent.c_imp_doc
            cmd.Parameters.Add("@c_imp_reten", OleDbType.Decimal, 10, 2).Value = Ent.c_imp_reten
            cmd.Parameters.Add("@c_opc_apertura", OleDbType.Integer).Value = Ent.c_opc_apertura
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 8)
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
    Public Function Get_RetenDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_RetenDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = c_codi_emp

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
