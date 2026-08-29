Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnTpoDoc
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_TpoDoc_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_TpoDoc"

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
    Public Function Get_Cargar_TpoDoc_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_TpoDoc_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_doc"
        Combo1.ValueMember = "c_codi_doc"
        Combo1.SelectedIndex = -1
    End Function
    'Cargar Lineas en el Combo
    Public Function Get_Cargar_TpoDoc_Lsb(ByVal Cadena As String, ByVal Tipo As Integer, ByVal Lsbox As ListBox)
        With Get_TpoDoc_Datos(Cadena, "DAT")
            Lsbox.Items.Clear()
            If .Rows.Count > 0 Then
                If Tipo = 1 Then Lsbox.Items.Add("(Todas)")
                For i = 0 To .Rows.Count - 1
                    Lsbox.Items.Add(.Rows(i)("c_desc_doc").ToString & " / " & .Rows(i)("c_codi_doc").ToString)
                Next
                Lsbox.SelectedIndex = 0
            End If
        End With
    End Function
End Class
