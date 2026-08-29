Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LetDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_LetDet_Save(ByVal Ent As Ent_LetDet, ByVal Emp As String) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Sca_Fa_upt_LetDet"
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
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 9).Value = Ent.c_nro_doc
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = Ent.c_codi_doc
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = Ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = Ent.c_nro_factura
            cmd.Parameters.Add("@c_nro_boleta", OleDbType.VarChar, 10).Value = Ent.c_nro_boleta
            cmd.Parameters.Add("@c_nro_nd", OleDbType.VarChar, 10).Value = Ent.c_nro_nd
            cmd.Parameters.Add("@c_imp_doc", OleDbType.Decimal, 10, 2).Value = Ent.c_imp_doc
            cmd.Parameters.Add("@c_cant_detracc", OleDbType.Decimal, 10, 2).Value = Ent.c_cant_detracc
            cmd.Parameters.Add("@c_nro_letra", OleDbType.VarChar, 9).Value = Ent.c_nro_letra
            cmd.Parameters.Add("@c_renov_letra", OleDbType.Integer).Value = Ent.c_renov_letra
            cmd.Parameters.Add("@c_opc_apertura", OleDbType.Integer).Value = Ent.c_opc_apertura
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion

            'Ejecutamos query
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
    Public Function Sca_LetDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_LetDet"

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
End Class
