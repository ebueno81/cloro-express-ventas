Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_ComisDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_ComisDet_SAVE(ByVal ent As Ent_ComisDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ComisDet"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_comis", OleDbType.VarChar, 7).Value = ent.c_nro_comis
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 10).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_imp_doc", OleDbType.Numeric, 10, 2).Value = ent.c_imp_doc
            cmd.Parameters.Add("@c_igv_doc", OleDbType.Numeric, 10, 2).Value = ent.c_igv_doc
            cmd.Parameters.Add("@c_tot_doc", OleDbType.Numeric, 10, 2).Value = ent.c_tot_doc
            cmd.Parameters.Add("@c_imp_comis", OleDbType.Numeric, 10, 2).Value = ent.c_imp_comis
            cmd.Parameters.Add("@c_imp_saldo", OleDbType.Numeric, 10, 2).Value = ent.c_imp_saldo
            cmd.Parameters.Add("@c_desc_estado", OleDbType.VarChar, 20).Value = ent.c_desc_estado
            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = ent.c_codi_vende
            cmd.Parameters.Add("@c_porc_comis", OleDbType.VarChar, 10, 3).Value = ent.c_porc_comis

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
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
    Public Function Sca_Comision_Modificar(ByVal ent As Ent_ComisDet) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ComisModifica"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 4).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_imp_comis", OleDbType.Numeric, 12, 2).Value = ent.c_imp_comis
            cmd.Parameters.Add("@c_porc_comis", OleDbType.Numeric, 10, 3).Value = ent.c_porc_comis
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

    Public Function Sca_ComisDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ComisDet"

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
