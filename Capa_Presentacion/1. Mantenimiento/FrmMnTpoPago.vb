Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmMnTpoPago
    Dim c_Neg_MnTpoPago As New Neg_MnTpoPago
    Dim c_Ent_MnTpoPago As New Ent_MnTpoPago

    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan01)
        BtnGrabar.Text = "&Grabar"
        BtnEditar.Enabled = False
        BtnEliminar.Enabled = False
        BtnCerrar.Text = "&Cancelar"
        Dgv01.Size = New Size(349, 166)
    End Sub
    Private Sub Cancelar_Registro()
        BtnGrabar.Text = "&Agregar"
        BtnEditar.Enabled = True
        BtnEliminar.Enabled = True
        BtnCerrar.Text = "&Cerrar"
        Dgv01.Size = New Size(349, 250)
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If BtnGrabar.Text = "&Grabar" Then
            If Len(TxtCodigo.Text) > 0 Then
                If Len(TxtDesc.Text) > 0 Then
                    Call Grabar_TpoPago("ADD")
                    Call Cancelar_Registro()
                    Call Cargar_Grid(" order by c_desc_pago")
                    MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Exclamation, Compañia)
                Else
                    MsgBox("Falta ingresar la forma de pago...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("Falta ingresar el codigo...", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            TxtCodigo.Enabled = True
            TxtCodigo.Focus()
            Call Nuevo_Registro()
        End If
    End Sub
    'Grabamos nueva forma de pago...
    Private Sub Grabar_TpoPago(ByVal cOpcion As String)
        With c_Ent_MnTpoPago
            .c_codi_pago = TxtCodigo.Text
            .c_desc_pago = TxtDesc.Text
            .c_nro_dias = Val(TxtDias.Text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnTpoPago.set_TpoPago_Save(c_Ent_MnTpoPago)
        End With
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro()
                        TxtCodigo.Text = .Rows(fila).Cells("codigo").Value
                        TxtDesc.Text = .Rows(fila).Cells("Descripcion").Value
                        TxtDias.Text = .Rows(fila).Cells("Dias").Value
                        TxtCodigo.Enabled = False
                        TxtDesc.Focus()
                    Else
                        MsgBox("Registro se encuentra eliminado, no puede ser modificado...", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Cancelamos registro...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub

    Private Sub TxtCodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigo.LostFocus
        If Len(TxtCodigo.Text) > 0 Then
            With c_Neg_MnTpoPago.get_TpoPago_Datos(" and c_codi_pago='" & TxtCodigo.Text & "'", "DAT")
                If .Rows.Count > 0 Then
                    MsgBox("El codigo ya fue ingresado anteriormente...", MsgBoxStyle.Critical, Compañia)
                    TxtCodigo.Clear()
                End If
            End With
        End If
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub
    'manejo de teclas...
    Private Sub FrmMnFPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnFPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnFPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Call Validar_Permiso(Me.Name, BtnGrabar, BtnEditar, BtnEliminar)
    End Sub
    ' Cargamos Registros '
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnTpoPago.get_TpoPago_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 50
            .Columns("Descripcion").Width = 230
            .Columns("dias").Width = 40
            .Columns("c_anula_reg").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            TxtCodigo.Text = Dgv01.Rows(fila).Cells("codigo").Value
                            Call Grabar_TpoPago("DEL")
                            MsgBox("Registro se fue eliminado...", MsgBoxStyle.Exclamation, Compañia)
                            Call Cargar_Grid(" order by c_desc_pago")
                        End If
                    Else
                        MsgBox("Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class