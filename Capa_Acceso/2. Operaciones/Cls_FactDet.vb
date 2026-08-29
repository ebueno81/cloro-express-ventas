Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_FactDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_FactDet_Save(ByVal ent As Ent_FactDet, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_Sca_Fa_upt_FactDet"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = ent.c_nro_factura
            cmd.Parameters.Add("@c_nro_lote", OleDbType.VarChar, 10).Value = ent.c_nro_lote
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_cant_caja", OleDbType.Numeric, 9).Value = ent.c_cant_caja
            cmd.Parameters.Add("@c_nro_cant", OleDbType.Numeric, 15, 2).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_precio_venta", OleDbType.Numeric, 15, 7).Value = ent.c_prec_venta
            cmd.Parameters.Add("@c_total_fact", OleDbType.Numeric, 15, 2).Value = ent.c_total_fact
            cmd.Parameters.Add("@c_opc_afecto", OleDbType.Integer).Value = ent.c_opc_afecto
            cmd.Parameters.Add("@c_correl_guia", OleDbType.VarChar, 8).Value = ent.c_correl_guia
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
    Public Function Get_FactDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_FactDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 3).Value = Emp

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
