Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Asientos_Anexos
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function sca_Concar_Anexos_Save(ByVal ent As Ent_Asientos_Anexos) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_upt_Concar_Anexo"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@Avanexo", OleDbType.VarChar, 18).Value = ent.Avanexo
            cmd.Parameters.Add("@Acodane", OleDbType.VarChar, 20).Value = ent.Acodane
            cmd.Parameters.Add("@Adesane", OleDbType.VarChar, 40).Value = ent.Adesane
            cmd.Parameters.Add("@Aruc", OleDbType.VarChar, 18).Value = ent.Aruc
            cmd.Parameters.Add("@Aestado", OleDbType.VarChar, 1).Value = ent.Aestado
            cmd.Parameters.Add("@Arefane", OleDbType.VarChar, 50).Value = ent.Arefane
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 30).Value = ent.copcion
            'ejecutamos query
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
    Public Function get_Concar_Anexos_Datos(ByVal Cadena As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Sca_Datos_ConcarAnexos"

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
