Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnVendedor
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_Vendedor_Save(ByVal ent As Ent_MnVendedor) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_Vendedor"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_vende", OleDbType.VarChar, 2).Value = ent.c_codi_vende
            cmd.Parameters.Add("@c_nom_vende", OleDbType.VarChar, 50).Value = ent.c_nom_vende
            cmd.Parameters.Add("@c_dni_vende", OleDbType.VarChar, 8).Value = ent.c_dni_vende
            cmd.Parameters.Add("@c_direc_vende", OleDbType.VarChar, 50).Value = ent.c_direc_vende
            cmd.Parameters.Add("@c_dist_vende", OleDbType.VarChar, 50).Value = ent.c_dist_vende
            cmd.Parameters.Add("@c_telf_vende", OleDbType.VarChar, 50).Value = ent.c_telf_vende
            cmd.Parameters.Add("@c_cel_vende", OleDbType.VarChar, 50).Value = ent.c_cel_vende
            cmd.Parameters.Add("@c_mail_vende", OleDbType.VarChar, 30).Value = ent.c_mail_vende
            cmd.Parameters.Add("@c_afecto_comi", OleDbType.Integer).Value = ent.c_afecto_comi
            cmd.Parameters.Add("@c_porc_comi", OleDbType.Decimal, 10, 3).Value = ent.c_porc_comi

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
    Public Function Get_Vendedor_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_Vendedor"

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
    Public Function get_Vendedor_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Vendedor_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_nom_vende"
        Combo1.ValueMember = "c_codi_vende"
        Combo1.SelectedIndex = -1
    End Function
End Class


