Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LetCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_LetCab_Save(ByVal Ent As Ent_LetCab, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Sca_Fa_upt_LetCab"
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
            cmd.Parameters.Add("@c_nro_letra", OleDbType.VarChar, 6).Value = Ent.c_nro_letra
            cmd.Parameters.Add("@c_renov_letra", OleDbType.Integer).Value = Ent.c_renov_letra
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = Ent.c_codi_clie
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_stletra", OleDbType.VarChar, 2).Value = Ent.c_codi_stletra
            cmd.Parameters.Add("@c_valor_letra", OleDbType.VarChar, 30).Value = Ent.c_valor_letra
            cmd.Parameters.Add("@c_nro_dias", OleDbType.Integer).Value = Ent.c_nro_dias
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = Ent.c_tpo_cambio
            cmd.Parameters.Add("@c_fecha_giro", OleDbType.Date).Value = Ent.c_fecha_giro
            cmd.Parameters.Add("@c_fecha_Venci", OleDbType.Date).Value = Ent.c_fecha_venci
            cmd.Parameters.Add("@c_fecha_presenta", OleDbType.Date).Value = Ent.c_fecha_presenta

            cmd.Parameters.Add("@c_codi_bco", OleDbType.VarChar, 2).Value = Ent.c_codi_bco
            cmd.Parameters.Add("@c_motivo_anula", OleDbType.VarChar, 70).Value = Ent.c_motivo_anula
            cmd.Parameters.Add("@c_cancel_letra", OleDbType.Integer).Value = Ent.c_cancel_letra
            cmd.Parameters.Add("@c_imp_letra", OleDbType.Numeric, 10, 2).Value = Ent.c_imp_letra
            cmd.Parameters.Add("@c_fiador_letra", OleDbType.VarChar, 50).Value = Ent.c_fiador_letra
            cmd.Parameters.Add("@c_aval_letra", OleDbType.VarChar, 50).Value = Ent.c_aval_letra
            cmd.Parameters.Add("@c_direcc_letra", OleDbType.VarChar, 50).Value = Ent.c_direcc_letra
            cmd.Parameters.Add("@c_dni_letra", OleDbType.VarChar, 11).Value = Ent.c_dni_letra
            cmd.Parameters.Add("@c_telf_letra", OleDbType.VarChar, 50).Value = Ent.c_telf_letra
            cmd.Parameters.Add("@c_rep_letra", OleDbType.VarChar, 50).Value = Ent.c_rep_letra
            cmd.Parameters.Add("@c_num_unico", OleDbType.VarChar, 20).Value = Ent.c_num_unico
            cmd.Parameters.Add("@c_nro_cuenta", OleDbType.VarChar, 30).Value = Ent.c_nro_cuenta
            cmd.Parameters.Add("@c_sector_bco", OleDbType.VarChar, 50).Value = Ent.c_sector_bco
            cmd.Parameters.Add("@c_imp_pago", OleDbType.Decimal, 10, 2).Value = Ent.c_imp_pago
            cmd.Parameters.Add("@c_porc_pago", OleDbType.VarChar, 10, 2).Value = Ent.c_porc_pago
            cmd.Parameters.Add("@c_fecha_cancel", OleDbType.Date).Value = Ent.c_fecha_cancel
            cmd.Parameters.Add("@c_pagado_clie", OleDbType.Integer).Value = Ent.c_pagado_clie

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = Ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion
            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 6)
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
    Public Function Sca_LetCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_LetCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 1000).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 1000).Value = Emp

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
