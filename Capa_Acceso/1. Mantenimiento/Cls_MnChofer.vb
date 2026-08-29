Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnChofer
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_Chofer_Save(ByVal ent As Ent_MnChofer) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_Chofer"

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_brevete", OleDbType.VarChar, 9).Value = ent.c_nro_brevete
            cmd.Parameters.Add("@c_codi_empserv", OleDbType.VarChar, 2).Value = ent.c_codi_empserv
            cmd.Parameters.Add("@c_nom_chofer", OleDbType.VarChar, 50).Value = ent.c_nom_chofer
            cmd.Parameters.Add("@c_apechofer", OleDbType.VarChar, 50).Value = ent.c_ape_chofer

            cmd.Parameters.Add("@c_nro_dni", OleDbType.VarChar, 50).Value = ent.c_nro_dni
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

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
    Public Function Get_Chofer_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_Chofer"

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
    Public Function Get_Chofer_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Chofer_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_nom_chofer"
        Combo1.ValueMember = "c_nro_brevete"
        Combo1.SelectedIndex = -1
    End Function
End Class
