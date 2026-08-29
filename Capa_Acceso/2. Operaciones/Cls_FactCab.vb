Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_FactCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Sca_FactCab_Save(ByVal Ent As Ent_FactCab, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Fa_upt_FactCab"
        cmd.CommandTimeout = 5000
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = Ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = Ent.c_nro_factura
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = Ent.c_codi_mon
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 2).Value = Ent.c_tpo_cambio
            cmd.Parameters.Add("@c_cant_igv", OleDbType.Numeric, 10, 2).Value = Ent.c_cant_igv
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = Ent.c_codi_clie
            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = Ent.c_codi_vende
            cmd.Parameters.Add("@c_codi_pago", OleDbType.VarChar, 2).Value = Ent.c_codi_pago
            cmd.Parameters.Add("@c_codi_status", OleDbType.VarChar, 2).Value = Ent.c_codi_status
            cmd.Parameters.Add("@c_codi_bco", OleDbType.VarChar, 2).Value = Ent.c_codi_bco

            cmd.Parameters.Add("@c_tpo_venta", OleDbType.VarChar, 20).Value = Ent.c_tpo_venta

            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = Ent.c_fecha_emi
            cmd.Parameters.Add("@c_fecha_venci", OleDbType.Date).Value = Ent.c_fecha_venci
            cmd.Parameters.Add("@c_motivo_anula", OleDbType.VarChar, 50).Value = Ent.c_motivo_anula
            cmd.Parameters.Add("@c_rollos_fact", OleDbType.Integer).Value = Ent.c_rollos_fact
            cmd.Parameters.Add("@c_peso_fact", OleDbType.Decimal).Value = Ent.c_peso_fact
            cmd.Parameters.Add("@c_venta_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_venta_fact
            cmd.Parameters.Add("@c_dscto_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_dscto_fact
            cmd.Parameters.Add("@c_import_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_import_fact
            cmd.Parameters.Add("@c_igv_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_igv_fact
            cmd.Parameters.Add("@c_total_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_total_fact
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = Ent.c_obs
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 25).Value = Ent.c_nro_oc
            cmd.Parameters.Add("@c_opc_detrac", OleDbType.Integer).Value = Ent.c_opc_detrac
            cmd.Parameters.Add("@c_opc_reten", OleDbType.Integer).Value = Ent.c_opc_reten

            cmd.Parameters.Add("@c_codi_detrac", OleDbType.VarChar, 3).Value = Ent.c_codi_detrac
            cmd.Parameters.Add("@c_detracc_fact", OleDbType.Numeric, 10, 2).Value = Ent.c_detracc_fact
            cmd.Parameters.Add("@c_detracc_por", OleDbType.Numeric, 10, 2).Value = Ent.c_detracc_por
            cmd.Parameters.Add("@c_letras_fact", OleDbType.VarChar, 300).Value = Ent.c_letras_fact
            cmd.Parameters.Add("@c_opc_inaf", OleDbType.Integer).Value = Ent.c_opc_inaf

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
    Public Function Get_FactCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_FactCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
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
    Public Function Set_FactElectronico_Save(ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String,
                                           ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_FactElectCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 7).Value = c_nro_doc
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc
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
    Public Function Sca_FactCabAsientos_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal Ccompro As String, ByVal Copcion As String)
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_FactCabAsiento"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = c_nro_serie
            cmd.Parameters.Add("@c_nro_factura", OleDbType.VarChar, 10).Value = c_nro_factura
            cmd.Parameters.Add("@Ccompro", OleDbType.VarChar, 10).Value = Ccompro
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Copcion

            'ejecutamos query
            cmd.ExecuteNonQuery()
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...

    End Function
    'Pagos de Facturas por documentos anexos...
    Public Function Get_FactDocAnexos_Dgv(ByVal Cadena As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Dgv_FactDocAnexos"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    'Listado de facturas
    Public Function Get_FactLista_Dgv(ByVal Cadena As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Dgv_FactLista"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena

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
