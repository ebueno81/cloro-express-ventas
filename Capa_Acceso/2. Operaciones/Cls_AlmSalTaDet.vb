Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_AlmSalTaDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_AlmSalTaDet_Save(ByVal ent As Ent_AlmSalTaDet, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Fa_upt_SalAlmDet"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_salidaTA", OleDbType.VarChar, 10).Value = ent.c_nro_salidaTA
            cmd.Parameters.Add("@c_nro_lote", OleDbType.VarChar, 10).Value = ent.c_nro_lote
            cmd.Parameters.Add("@c_opt_fraccion", OleDbType.Integer).Value = ent.c_opt_fraccion
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_nro_cant", OleDbType.Decimal, 12, 4).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_cant_caja", OleDbType.Integer).Value = ent.c_cant_caja
            cmd.Parameters.Add("@c_cant_fraccion", OleDbType.VarChar, 12).Value = ent.c_cant_fraccion
            cmd.Parameters.Add("@c_prec_unit", OleDbType.Decimal, 30, 6).Value = ent.c_prec_unit
            cmd.Parameters.Add("@c_imp_total", OleDbType.VarChar, 16, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_correl_ing", OleDbType.VarChar, 8).Value = ent.c_correl_ing
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            
            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
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
    Public Function Get_AlmSalTaDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Datos_SalAlmDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 3000).Value = Cadena
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
    ' Reporte de Salidas de envase
    Public Function Get_AlmSalEnvases_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String, _
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, _
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalAlmEnvases"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
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
    ' Reporte de Salidas por cliente
    Public Function Get_AlmSalArt_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                        ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalTADet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
            cmd.Parameters.Add("@c_opc_noingsal", OleDbType.VarChar, 1).Value = c_opc_noingsal
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm
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
    ' Reporte de Salidas por cliente
    Public Function Get_AlmSalArtValor_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                             ByVal c_opc_transforma As String, ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalTADetValor"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 4).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
            cmd.Parameters.Add("@c_opc_noingsal", OleDbType.VarChar, 1).Value = c_opc_noingsal
            cmd.Parameters.Add("@c_opc_transforma", OleDbType.VarChar, 1).Value = c_opc_transforma
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm

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
    ' Reporte de Salidas por cliente
    Public Function Get_AlmSalArtGerencial_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                            ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                            ByVal c_codi_scd As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Sca_Rpt_VtasDetV1"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = c_codi_scd
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

    ' Reporte de Salidas por totalizado
    Public Function Get_AlmSalArtTotal_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String, _
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, _
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalArt"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
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
    ' Reporte de Salidas por cliente
    ' Reporte de Salidas por cliente
    Public Function Get_AlmSalClie_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                         ByVal c_opc_transforma As String, ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scal_Rpt_SalTADetClie"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
            cmd.Parameters.Add("@c_opc_noingsal", OleDbType.VarChar, 1).Value = c_opc_noingsal
            cmd.Parameters.Add("@c_opc_transforma", OleDbType.VarChar, 1).Value = c_opc_transforma
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm

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
