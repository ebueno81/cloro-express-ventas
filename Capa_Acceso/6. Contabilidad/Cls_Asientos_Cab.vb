Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_Asientos_Cab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function get_AsientosCab_Datos(ByVal c_codi_doc As String, ByVal c_Fecha_Inicio As Date, ByVal c_Fecha_Final As Date) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = Val(Strings.Right(Conexion.GetConexion_Sql, 5))
        cmd.CommandText = "Sp_Sca_Datos_ConcarCab"
        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_Fecha_Final
            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
        Return Tabla
    End Function
    Public Function Sca_AsientosCab_Save(ByVal c_nro_Serie As String, ByVal c_nro_factura As String, ByVal c_nro_concar As String, _
                                          ByVal c_codi_doc As String, ByVal cOpcion As String)
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_FactCabAsiento"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 4).Value = c_nro_Serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 7).Value = c_nro_factura
            cmd.Parameters.Add("@c_nro_concar", OleDbType.VarChar, 10).Value = c_nro_concar
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc
            cmd.Parameters.Add("@cOpcion", OleDbType.VarChar, 3).Value = cOpcion

            'ejecutamos query
            cmd.ExecuteNonQuery()
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...

    End Function
End Class
