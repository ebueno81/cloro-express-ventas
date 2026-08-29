Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnEmpServ
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_EmpServ_Save(ByVal ent As Ent_MnEmpServ) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_EmpServ"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_empserv", OleDbType.VarChar, 2).Value = ent.c_codi_empserv
            cmd.Parameters.Add("@c_desc_empserv", OleDbType.VarChar, 120).Value = ent.c_desc_empserv
            cmd.Parameters.Add("@c_dist_empserv", OleDbType.VarChar, 30).Value = ent.c_dist_empserv
            cmd.Parameters.Add("@c_direcc_empserv", OleDbType.VarChar, 40).Value = ent.c_direcc_empserv
            cmd.Parameters.Add("@c_telf_empserv", OleDbType.VarChar, 50).Value = ent.c_telf_empserv
            cmd.Parameters.Add("@c_cel_empserv", OleDbType.VarChar, 50).Value = ent.c_cel_empserv
            cmd.Parameters.Add("@c_ruc_empserv", OleDbType.VarChar, 11).Value = ent.c_ruc_empserv
            cmd.Parameters.Add("@c_web_empserv", OleDbType.VarChar, 50).Value = ent.c_web_empserv
            cmd.Parameters.Add("@c_mail_empserv", OleDbType.VarChar, 30).Value = ent.c_mail_empserv
            cmd.Parameters.Add("@c_contac_empserv", OleDbType.VarChar, 50).Value = ent.c_contac_empserv
            cmd.Parameters.Add("@c_nro_tarjcircula", OleDbType.VarChar, 20).Value = ent.c_nro_tarjcircula

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
   
    'Datos del Area
    Public Function Get_EmpServ_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_EmpServ"

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
    Public Function Get_Cargar_EmpServ_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_EmpServ_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_empserv"
        Combo1.ValueMember = "c_codi_empserv"
        Combo1.SelectedIndex = -1
    End Function
End Class
