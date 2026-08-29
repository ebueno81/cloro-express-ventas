Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_RetenCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_RetenCab_Save(ByVal Ent As Ent_RetenCab, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_RetenCab"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = Ent.c_nro_ing
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 4).Value = Ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_reten", OleDbType.VarChar, 7).Value = Ent.c_nro_reten
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = Ent.c_fecha_emi
            cmd.Parameters.Add("@c_fecha_prd", OleDbType.Date).Value = Ent.c_fecha_prd
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = Ent.c_codi_clie
            cmd.Parameters.Add("@c_direc_reten", OleDbType.VarChar, 100).Value = Ent.c_direc_reten
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_total_doc", OleDbType.Decimal, 10, 2).Value = Ent.c_total_doc
            cmd.Parameters.Add("@c_total_reten", OleDbType.Decimal, 10, 2).Value = Ent.c_total_reten
            cmd.Parameters.Add("@c_letras_reten", OleDbType.VarChar, 150).Value = Ent.c_letras_reten
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = Ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 7)
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
    Public Function Get_RetenCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_RetenCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 3).Value = c_codi_emp

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_RetenCab_Rpt(ByVal c_codi_clie As String, ByVal vOpt As String, ByVal c_fecha_inicio As Date) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Rpt_Retencion"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_RetenFact_Rpt(ByVal c_codi_clie As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Rpt_RetenFact"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = c_codi_clie
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
