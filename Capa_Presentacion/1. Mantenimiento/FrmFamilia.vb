Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmFamilia
    Dim c_Negocio As New Neg_Familia
    Dim e_Entidad As New Ent_Familia

   
    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Negocio.get_Familia_Dgv(" and F.c_codi_linea='" & lblcod.Text & "' order by c_codi_familia ")
        With Dgv01
            .Columns("Codigo").Width = 70
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("Familia").Width = 400
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
            Dgv01.Height = 213
            Dgv01.Enabled = False
        Else
            Call Grabar_Familia()
            Dgv01.Height = 306
            Dgv01.Focus()
            Call BtnCerrar_Click(Nothing, Nothing)
            MsgBox("Registro se Grabo correctamente...", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Grabar_Familia()
        e_Entidad.c_codi_linea = lblcod.Text
        e_Entidad.c_codi_familia = TxtCod.Text
        e_Entidad.c_desc_familia = TxtDesc.Text
        e_Entidad.c_usuario = "U001"
        e_Entidad.copcion = "ADD"
        c_Negocio.set_Familia_Save(e_Entidad)
        Call Cargar_Grid()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar"
            BtnGrabar.Text = "&Agregar"
            BtnEdi.Text = "Editar"
            Dgv01.Enabled = True
            BtnEdi.Enabled = True
            Dgv01.Enabled = True
            Dgv01.Height = 334
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
                    Dim Cadena As String = " And F.c_codi_linea='" & lblcod.Text & "' And F.c_codi_Familia ='" & .Rows(fila).Cells("Codigo").Value & "'"
                    With c_Negocio.get_Familia_Datos(Cadena)
                        If .Rows.Count > 0 Then
                            TxtCod.Text = .Rows(0)("c_codi_familia").ToString
                            TxtDesc.Text = .Rows(0)("c_desc_familia").ToString
                            Dgv01.Enabled = False
                        End If
                    End With
                    If BtnGrabar.Text = "&Agregar" Then Call BtnGrabar_Click(Nothing, Nothing)
                End If
            End If
        End With
    End Sub

    Private Sub FrmFamilia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMenu.Enabled = True
        FrmLinea.Enabled = True
    End Sub



    Private Sub FrmFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        If BtnGrabar.Text = "&Agregar" Then
            Call Editar_Registro()
        End If
    End Sub

    Private Sub BtnSFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSFamilia.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    Me.Enabled = False
                    FrmSFamilia.Show()
                    FrmSFamilia.lblcod.Text = lblcod.Text
                    FrmSFamilia.lbllinea.Text = lbllinea.Text

                    FrmSFamilia.lblcod2.Text = .Rows(fila).Cells("Codigo").Value
                    FrmSFamilia.lblfamilia.Text = .Rows(fila).Cells("familia").Value
                    FrmSFamilia.Cargar_Grid()
                End If
            End If
        End With
    End Sub
End Class