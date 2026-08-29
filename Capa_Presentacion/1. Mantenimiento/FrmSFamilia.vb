Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmSFamilia
    Dim c_Negocio As New Neg_SFamilia
    Dim e_Entidad As New Ent_SFamilia

    Private Sub FrmSFamilia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmFamilia.Enabled = True
    End Sub

    Private Sub FrmSFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmSFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmSubCaidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Negocio.get_sFamilia_Dgv(" and S.c_codi_linea='" & lblcod.Text & "' and S.c_codi_familia='" & lblcod2.Text & "' order by c_codi_subfamilia ")
        With Dgv01
            .Columns("Codigo").Width = 80
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("SubFamilia").Width = 380
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
            Dgv01.Height = 246
        Else
            Call Grabar_sFamilia()
            Dgv01.Height = 336
            Dgv01.Focus()
            Call BtnCerrar_Click(Nothing, Nothing)
            MsgBox("Registro se Grabo correctamente...", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Grabar_sFamilia()
        e_Entidad.c_codi_linea = lblcod.Text
        e_Entidad.c_codi_familia = lblcod2.Text
        e_Entidad.c_codi_subfamilia = TxtCod.Text
        e_Entidad.c_desc_subfamilia = TxtDesc.Text
        e_Entidad.c_usuario = "U001"
        e_Entidad.copcion = "ADD"

        c_Negocio.set_sFamilia_Save(e_Entidad)
        Call Cargar_Grid()
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar"
            BtnGrabar.Text = "&Agregar"
            BtnEdi.Enabled = True
            Dgv01.Height = 335
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
    Private Sub Editar_Registro()
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    Dim Cadena As String = " And S.c_codi_linea='" & lblcod.Text & "' And S.c_codi_familia='" & lblcod2.Text & "' And S.c_codi_subfamilia ='" & .Rows(fila).Cells("Codigo").Value & "'"
                    With c_Negocio.get_sfamilia_Datos(Cadena)
                        If .Rows.Count > 0 Then
                            TxtCod.Text = .Rows(0)("c_codi_subfamilia").ToString
                            TxtDesc.Text = .Rows(0)("c_desc_subfamilia").ToString

                            Dgv01.Enabled = False
                        End If
                    End With
                    If BtnGrabar.Text = "&Agregar" Then Call BtnGrabar_Click(Nothing, Nothing)
                End If
            End If
        End With
    End Sub

    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        Call Editar_Registro()
    End Sub
End Class