Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnAlmacen
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_Almacen_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_Almacen"

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
    Public Function Get_Cargar_Almacen_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Almacen_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_alm"
        Combo1.ValueMember = "c_codi_alm"
        Combo1.SelectedIndex = -1
    End Function
End Class
