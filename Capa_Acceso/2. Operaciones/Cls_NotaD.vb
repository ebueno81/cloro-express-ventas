Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_NotaD
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_NotaD_SAVE(ByVal ent As Ent_NotaD, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_NotaD"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_nd", OleDbType.VarChar, 10).Value = ent.c_nro_nd
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_cant_igv", OleDbType.Numeric, 10, 2).Value = ent.c_cant_igv
            cmd.Parameters.Add("@c_motivo_nd", OleDbType.VarChar, 3000).Value = ent.c_motivo_nd
            cmd.Parameters.Add("@c_imp_nd", OleDbType.Numeric, 10, 2).Value = ent.c_imp_nd
            cmd.Parameters.Add("@c_imp_igv", OleDbType.Numeric, 10, 2).Value = ent.c_imp_igv
            cmd.Parameters.Add("@c_imp_total", OleDbType.Numeric, 10, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_opc_detrac", OleDbType.Integer).Value = ent.c_opc_detrac
            cmd.Parameters.Add("@c_opc_reten", OleDbType.Integer).Value = ent.c_opc_reten
            cmd.Parameters.Add("@c_detracc_nd", OleDbType.Numeric, 10, 2).Value = ent.c_detracc_nd
            cmd.Parameters.Add("@c_detracc_porc", OleDbType.Numeric, 10, 2).Value = ent.c_detracc_por
            cmd.Parameters.Add("@c_letras_nd", OleDbType.VarChar, 400).Value = ent.c_letras_nd

            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 10).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_fecha_doc", OleDbType.Date).Value = ent.c_fecha_doc
            cmd.Parameters.Add("@c_opc_inaf", OleDbType.Integer).Value = ent.c_opc_inaf
            cmd.Parameters.Add("@c_opc_exporta", OleDbType.Integer).Value = ent.c_opc_exporta
            cmd.Parameters.Add("@c_tpo_motivo", OleDbType.VarChar, 50).Value = ent.c_tpo_motivo

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
            Codi_Auto = cmd.Parameters.Add("@c_codi_auto", OleDbType.VarChar, 7)
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
    Public Function Sca_NotaD_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_NotaD"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 2000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2000).Value = Emp

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
