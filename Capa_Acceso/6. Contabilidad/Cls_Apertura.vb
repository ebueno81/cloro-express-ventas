Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Apertura
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_Apertura_SAVE(ByVal ent As Ent_Apertura) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_Apertura"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_apertura", OleDbType.VarChar, 7).Value = ent.c_nro_apertura
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_imp_doc", OleDbType.Numeric, 12, 2).Value = ent.c_imp_doc
            cmd.Parameters.Add("@c_codi_bco", OleDbType.VarChar, 2).Value = ent.c_codi_bco
            cmd.Parameters.Add("@c_codi_stletra", OleDbType.VarChar, 2).Value = ent.c_codi_stletra
            cmd.Parameters.Add("@c_pagado_clie", OleDbType.Integer).Value = ent.c_pagado_clie
            cmd.Parameters.Add("@c_opc_reten", OleDbType.Integer).Value = ent.c_opc_reten

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 7)
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
    Public Function Sca_Apertura_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_Apertura"

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
    ' Actualizamos Factor de comisiones 
    Public Function Sca_NotaDComis_Save(ByVal c_nro_serie As String, ByVal c_nro_nd As String, ByVal Copcion As String)
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_NotaDComis"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_nd", OleDbType.VarChar, 7).Value = c_nro_nd
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Copcion

            'ejecutamos query
            cmd.ExecuteNonQuery()
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...

    End Function
End Class
