Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnCliente
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_Cliente_Save(ByVal ent As Ent_MnCliente) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_Cliente"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_abrev_clie", OleDbType.VarChar, 2).Value = ent.c_abrev_clie
            cmd.Parameters.Add("@c_desc_clie", OleDbType.VarChar, 80).Value = ent.c_desc_clie
            cmd.Parameters.Add("@c_pais_clie", OleDbType.VarChar, 30).Value = ent.c_pais_clie
            cmd.Parameters.Add("@c_ciudad_clie", OleDbType.VarChar, 30).Value = ent.c_ciudad_clie
            cmd.Parameters.Add("@c_prov_clie", OleDbType.VarChar, 30).Value = ent.c_prov_clie
            cmd.Parameters.Add("@c_dist_clie", OleDbType.VarChar, 30).Value = ent.c_dist_clie
            cmd.Parameters.Add("@c_direc_clie", OleDbType.VarChar, 150).Value = ent.c_direc_clie
            cmd.Parameters.Add("@c_ruc_clie", OleDbType.VarChar, 11).Value = ent.c_ruc_clie
            cmd.Parameters.Add("@c_dni_clie", OleDbType.VarChar, 8).Value = ent.c_dni_clie
            cmd.Parameters.Add("@c_telf_clie", OleDbType.VarChar, 50).Value = ent.c_telf_clie
            cmd.Parameters.Add("@c_cel_clie", OleDbType.VarChar, 50).Value = ent.c_cel_clie
            cmd.Parameters.Add("@c_contac_clie", OleDbType.VarChar, 50).Value = ent.c_contac_clie
            cmd.Parameters.Add("@c_mail_clie", OleDbType.VarChar, 50).Value = ent.c_mail_clie
            cmd.Parameters.Add("@c_web_clie", OleDbType.VarChar, 50).Value = ent.c_web_clie
            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = ent.c_codi_vende
            cmd.Parameters.Add("@c_tpo_clie", OleDbType.Integer).Value = ent.c_tpo_clie
            cmd.Parameters.Add("@c_opc_reten", OleDbType.Integer).Value = ent.c_opc_reten
            cmd.Parameters.Add("@c_codi_pago", OleDbType.VarChar, 2).Value = ent.c_codi_pago
            cmd.Parameters.Add("@c_codi_ubigeo", OleDbType.VarChar, 6).Value = ent.c_codi_ubigeo

            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 6)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_Cliente_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_Cliente"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
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
    'Cargar Lineas en el Combo
    Public Function Get_Cargar_Clientes_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Cliente_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_clie"
        Combo1.ValueMember = "c_codi_clie"
        Combo1.SelectedIndex = -1
    End Function
End Class
