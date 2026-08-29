Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnTransporte
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_Transporte_Save(ByVal ent As Ent_MnTransporte) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_Transporte"

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_placa_trp", OleDbType.VarChar, 8).Value = ent.c_placa_trp
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_direcc_trp", OleDbType.VarChar, 50).Value = ent.c_direcc_trp
            cmd.Parameters.Add("@c_vehiculo_trp", OleDbType.VarChar, 50).Value = ent.c_vehiculo_trp
            cmd.Parameters.Add("@c_color_trp", OleDbType.VarChar, 50).Value = ent.c_color_trp
            cmd.Parameters.Add("@c_peso_trp", OleDbType.VarChar, 10).Value = ent.c_peso_trp
            cmd.Parameters.Add("@c_altura_trp", OleDbType.VarChar, 10).Value = ent.c_altura_trp
            cmd.Parameters.Add("@c_longitud_trp", OleDbType.VarChar, 10).Value = ent.c_longitud_trp
            cmd.Parameters.Add("@c_ancho_trp", OleDbType.VarChar, 10).Value = ent.c_ancho_trp
            cmd.Parameters.Add("@c_nro_tarjeta", OleDbType.VarChar, 15).Value = ent.c_nro_tarjeta

            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'Ejecutamos query
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
    'Datos del Area
    Public Function Get_Transporte_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_Transporte"

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
    'Cargar Transporte al combo
    Public Function Get_Cargar_Transporte_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Transporte_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_placa_trp"
        Combo1.ValueMember = "c_placa_trp"
        Combo1.SelectedIndex = -1
    End Function

End Class
