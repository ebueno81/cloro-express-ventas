Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_AlmTransforDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_AlmTransforDet_Save(ByVal ent As Ent_AlmTransforDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_TranforDet"
        cmd.CommandTimeout = 5000
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_transforma", OleDbType.VarChar, 7).Value = ent.c_nro_transforma
            cmd.Parameters.Add("@c_tpo_mov", OleDbType.VarChar, 3).Value = ent.c_tpo_mov
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_nro_cant", OleDbType.Decimal, 10, 4).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_prec_unit", OleDbType.Decimal, 10, 2).Value = ent.c_prec_unit
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 10, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_opc_transespecial", OleDbType.VarChar, 1).Value = ent.c_opc_transespecial

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
    Public Function Get_AlmTransforDet_Datos(ByVal c_nro_transforma As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_TransforDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_transforma", OleDbType.VarChar, 7).Value = c_nro_transforma
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
    Public Function Get_AlmTransforDet_Rpt(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String,
                                           ByVal c_codi_cd As String, ByVal c_codi_Articulo As String,
                                            ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Rpt_TransforDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_Articulo
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
    Public Function set_AlmTransforDetCoeficiente_Save(ByVal c_codi_articulo As String, ByVal c_nro_coeficiente As Decimal) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_TranforDetCoeficiente"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@c_nro_coeficiente", OleDbType.Decimal, 16, 6).Value = c_nro_coeficiente

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
