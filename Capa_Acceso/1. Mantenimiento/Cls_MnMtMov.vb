Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnMtMov
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_MtMovSal(ByVal ent As Ent_MnMtMov) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_MtMovSal"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = ent.c_codi_mt
            cmd.Parameters.Add("@c_desc_mt", OleDbType.VarChar, 50).Value = ent.c_desc_mt
            cmd.Parameters.Add("@c_opc_prove", OleDbType.Integer).Value = ent.c_opc_prove
            cmd.Parameters.Add("@c_codi_sunat", OleDbType.VarChar, 2).Value = ent.c_codi_sunat
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 2)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_MtMov_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_MtMovSal"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@cadena", OleDbType.VarChar, 500).Value = Cadena
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

    ' Cargamos Registros al Combo '
    Public Function Get_Cargar_MtMov_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_MtMov_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_mt"
        Combo1.ValueMember = "c_codi_mt"
        Combo1.SelectedIndex = -1
    End Function
End Class
