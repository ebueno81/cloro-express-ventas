Public Class FrmMnSeriesGuia
    'Nuevo registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtSerie.Enabled = True : TxtSerie.Focus()
    End Sub
    'Nuevo Registro...
    Private Sub Nuevo_Registro()
        With Dgv01
            .Location = New Point(2, 29)
            .Size = New Size(585, 207)
        End With
        Pan02.Enabled = False : BtnGrabar.Enabled = True : BtnCerrar.Text = "&Cancelar"
        Call Limpiar_Texto(Pan01) : Dgv01.Enabled = False
        ChkInterno.Checked = False
        ChkElectronico.Checked = False
        ChkEsMedxpress.Checked = False
    End Sub
    'Cancelar Registro...
    Private Sub Cancelar_Registro()
        With Dgv01
            .Location = New Point(2, 2)
            .Size = New Size(585, 231)
        End With
        Pan02.Enabled = True : BtnGrabar.Enabled = False : BtnCerrar.Text = "&Cerrar"
        Call Limpiar_Texto(Pan01) : Dgv01.Enabled = True
    End Sub
    'Cancelamos o cerrarmos...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro() : TxtSerie.Enabled = False : TxtDescripcion.Focus()
                        TxtSerie.Text = .Rows(Fila).Cells("Nro.").Value
                        TxtNro_Doc.Text = .Rows(Fila).Cells("Guia").Value
                        TxtDescripcion.Text = .Rows(Fila).Cells("Descripcion").Value
                        ChkElectronico.Checked = IIf(.Rows(Fila).Cells("Electronico").Value = "SI", True, False)
                        ChkInterno.Checked = IIf(.Rows(Fila).Cells("Interno").Value = "SI", True, False)
                        ChkEsMedxpress.Checked = IIf(.Rows(Fila).Cells("MedXpress").Value = "SI", True, False)
                    Else
                        MsgBox("Registro se encuentra anulado", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtSerie.Text) > 0 And Len(TxtNro_Doc.Text) > 0 Then
            Call Grabar_Series("ADD")
        Else
            MsgBox("Falta ingresar el nombre del Hilo...", vbCritical, Compañia)
        End If
    End Sub
    'Grabamos 
    Private Sub Grabar_Series(ByVal cOpcion As String)
        With c_Ent_MnSeriesGuia
            .c_nro_serie = TxtSerie.Text
            .c_nro_guia = TxtNro_Doc.Text
            .c_desc_serie = TxtDescripcion.Text
            .c_opc_electronico = IIf(ChkElectronico.Checked = True, 1, 0)
            .c_guia_interna = IIf(ChkInterno.Checked = True, 1, 0)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            .c_opc_medxpress = IIf(ChkEsMedxpress.Checked = True, 1, Nothing)
            c_Neg_MnSeriesGuias.set_Series_Save(c_Ent_MnSeriesGuia, FrmMenu.TxtCod_Emp.Text)
        End With
        Call Cargar_Grid(" order by c_nro_Serie")
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        Call Cancelar_Registro()
    End Sub

    Private Sub FrmMnSeries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnSeries_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        Call Cancelar_Registro()
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_MnSeriesGuias.get_Series_Datos(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            .Columns("Nro.").Width = 60
            .Columns("Guia").Width = 80
            .Columns("Descripcion").Width = 200
            .Columns("Electronico").Width = 65
            .Columns("Interno").Width = 65
            .Columns("MedXpress").Width = 80
            .Columns("c_anula_Reg").Visible = False
            Call Grid_Registros_anulados(Dgv01)
            'Alienacion
            .Columns("Nro.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Electronico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Interno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Eliminamos series de guia de remisión' 
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim F As String = MsgBox(" ¿Desea Eliminar la serie de Guía de Remisión? ", vbQuestion + vbYesNo, Compañia)
                        If F = vbYes Then
                            TxtSerie.Text = .Rows(fila).Cells("Nro.").Value
                            Call Grabar_Series("DEL")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtNro_Doc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Doc.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtNro_Doc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub

    Private Sub TxtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtSerie.Text) = True Then
                TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub
End Class