Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_AlmSalTa
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_AlmSalTa_Save(ByVal ent As Ent_AlmSalTa, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_upt_SalAlm"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_salidaTA", OleDbType.VarChar, 8).Value = ent.c_nro_salidaTA
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov

            cmd.Parameters.Add("@c_fecha_sal", OleDbType.Date).Value = ent.c_fecha_sal
            cmd.Parameters.Add("@c_fecha_traslado", OleDbType.Date).Value = ent.c_fecha_traslado
            cmd.Parameters.Add("@c_nro_os", OleDbType.VarChar, 15).Value = ent.c_nro_os

            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = ent.c_codi_alm
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = ent.c_codi_mt
            cmd.Parameters.Add("@c_codi_placa", OleDbType.VarChar, 8).Value = ent.c_codi_placa

            cmd.Parameters.Add("@c_codi_ubigeo", OleDbType.VarChar, 6).Value = ent.c_codi_ubigeo
            cmd.Parameters.Add("@c_codi_oficina", OleDbType.VarChar, 5).Value = ent.c_codi_oficina
            cmd.Parameters.Add("@c_direcc_trp", OleDbType.VarChar, 120).Value = ent.c_direcc_trp
            cmd.Parameters.Add("@c_dist_trp", OleDbType.VarChar, 30).Value = ent.c_dist_trp
            cmd.Parameters.Add("@c_prov_trp", OleDbType.VarChar, 30).Value = ent.c_prov_trp

            cmd.Parameters.Add("@c_dpto_trp", OleDbType.VarChar, 30).Value = ent.c_dpto_trp
            cmd.Parameters.Add("@c_chofer_trp", OleDbType.VarChar, 50).Value = ent.c_chofer_trp
            cmd.Parameters.Add("@c_ape_chofer", OleDbType.VarChar, 50).Value = ent.c_ape_chofer
            cmd.Parameters.Add("@c_vehiculo_trp", OleDbType.VarChar, 50).Value = ent.c_vehiculo_trp

            cmd.Parameters.Add("@c_color_trp", OleDbType.VarChar, 50).Value = ent.c_color_trp
            cmd.Parameters.Add("@c_abrevcte_trp", OleDbType.VarChar, 2).Value = ent.c_abrevcte_trp
            cmd.Parameters.Add("@c_desccte_trp", OleDbType.VarChar, 30).Value = ent.c_desccte_trp
            cmd.Parameters.Add("@c_ruc_trp", OleDbType.VarChar, 11).Value = ent.c_ruc_trp
            cmd.Parameters.Add("@c_nro_lic", OleDbType.VarChar, 9).Value = ent.c_nro_lic

            cmd.Parameters.Add("@c_nro_dni", OleDbType.VarChar, 8).Value = ent.c_nro_dni
            cmd.Parameters.Add("@c_peso_neto", OleDbType.Decimal, 16, 2).Value = ent.c_peso_neto
            cmd.Parameters.Add("@c_cajas_total", OleDbType.Integer).Value = ent.c_cajas_total
            cmd.Parameters.Add("@c_total_guia", OleDbType.Decimal, 16, 2).Value = ent.c_total_guia
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs

            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_fact", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_fact", OleDbType.VarChar, 10).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 7)
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
    Public Function Get_AlmSalTa_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Datos_SalAlm"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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
    Public Function Get_GuiaElectronica_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Dgo_Datos_GuiasElectronica"

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
    Public Function set_GuiaElectronica_Save(c_nro_serie As String, c_nro_guia As String, coptabla As String, vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_upt_GuiaElectCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 8).Value = c_nro_guia
            cmd.Parameters.Add("@coptabla", OleDbType.VarChar, 3).Value = coptabla

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
    'Reporte de salida por facturar
    Public Function Get_AlmSalTa_Rpt(ByVal c_nro_serie As String, ByVal c_nro_salidaTa As String, ByVal c_nro_ingreso As String, ByVal c_fecha_inicio As Date, _
                                      ByVal c_fecha_final As Date, ByVal c_codi_clie As String, ByVal c_anula_reg As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalTA"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_salidaTA", OleDbType.VarChar, 7).Value = c_nro_salidaTa
            cmd.Parameters.Add("@c_nro_ingreso", OleDbType.VarChar, 7).Value = c_nro_ingreso
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_anula_reg", OleDbType.VarChar, 1).Value = c_anula_reg
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
