Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnClienteOfi
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_ClienteOfi_Save(ByVal ent As Ent_MnClienteOfi) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_ClienteOfi"

        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_oficina", OleDbType.VarChar, 10).Value = ent.c_codi_oficina
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_codi_ubigeo", OleDbType.VarChar, 6).Value = ent.c_codi_ubigeo
            cmd.Parameters.Add("@c_direc_clie", OleDbType.VarChar, 120).Value = ent.c_direc_clie
            cmd.Parameters.Add("@c_dist_clie", OleDbType.VarChar, 30).Value = ent.c_dist_clie
            cmd.Parameters.Add("@c_prov_clie", OleDbType.VarChar, 30).Value = ent.c_prov_clie
            cmd.Parameters.Add("@c_dpto_clie", OleDbType.VarChar, 30).Value = ent.c_dpto_clie
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 5)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_ClienteOfi_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ClienteOfi"

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
    'Cargar Datos al combo
    Public Function get_ClienteOfi_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_ClienteOfi_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_direc_clie"
        Combo1.ValueMember = "c_codi_oficina"
        Combo1.SelectedIndex = -1
    End Function
End Class
