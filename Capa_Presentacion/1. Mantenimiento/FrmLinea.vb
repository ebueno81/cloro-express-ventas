Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmLinea
    Dim c_Negocio As New Neg_Linea
    Dim e_Entidad As New Ent_Linea

 
    Private Sub Cargar_Grid()
        Dgv01.DataSource = c_Negocio.get_Linea_Dgv(" order by c_codi_linea ")
        With Dgv01
            .Columns("Codigo").Width = 80
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("Linea").Width = 280
            .Columns("Cta.Contable").Width = 120
            
            .Columns("c_anula_reg").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next

        End With
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If BtnGrabar.Text = "&Agregar" Then
            BtnGrabar.Text = "&Grabar"
            BtnCerrar.Text = "&Cancelar"
            BtnEdi.Enabled = False
            TxtDesc.Focus()
            Dgv01.Height = 183

        Else
            Call Grabar_TblLinea()
            Dgv01.Height = 306
            Dgv01.Focus()
            Call BtnCerrar_Click(Nothing, Nothing)
            MsgBox("Registro se Grabo correctamente...", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub Grabar_TblLinea()
        e_Entidad.c_codi_linea = TxtCod.Text
        e_Entidad.c_desc_linea = TxtDesc.Text
        e_Entidad.c_concar_cta = TxtCta.Text

        e_Entidad.c_usuario = "U001"
        e_Entidad.copcion = "ADD"
        c_Negocio.set_Linea_Save(e_Entidad)
        Call Cargar_Grid()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar"
            BtnGrabar.Text = "&Agregar"
            BtnEdi.Enabled = True
            Dgv01.Height = 306
            Dgv01.Enabled = True
            Dgv01.Focus()

            Call Limpiar_Texto(Pan01)
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub



    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        Call Editar_Registro()
    End Sub
    'Editamos Registro
    Private Sub Editar_Registro()
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    Dim Cadena As String = " And L.c_codi_linea ='" & .Rows(fila).Cells("Codigo").Value & "'"
                    With c_Negocio.get_Linea_Datos(Cadena)
                        If .Rows.Count > 0 Then
                            TxtCod.Text = .Rows(0)("c_codi_linea").ToString
                            TxtDesc.Text = .Rows(0)("c_desc_linea").ToString
                            TxtCta.Text = .Rows(0)("c_concar_cta").ToString
                            BtnGrabar.Text = "&Grabar"
                            BtnCerrar.Text = "&Cancelar"
                            BtnEdi.Enabled = False
                            Dgv01.Height = 182
                            Dgv01.Enabled = False
                            TxtDesc.Focus()
                        End If
                    End With
                    If BtnGrabar.Text = "&Nuevo" Then Call BtnGrabar_Click(Nothing, Nothing)
                End If
            End If
        End With
    End Sub
    Private Sub BtnFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFamilia.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    FrmMenu.Enabled = False
                    Me.Enabled = False
                    FrmFamilia.Show()
                    FrmFamilia.lblcod.Text = .Rows(fila).Cells("Codigo").Value
                    FrmFamilia.lbllinea.Text = .Rows(fila).Cells("Linea").Value
                    FrmFamilia.Cargar_Grid()
                End If
            End If
        End With

    End Sub

    Private Sub FrmLinea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmLinea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_Grid()
    End Sub

    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        If BtnGrabar.Text = "&Agregar" Then
            Call Editar_Registro()
            
        End If
    End Sub
End Class