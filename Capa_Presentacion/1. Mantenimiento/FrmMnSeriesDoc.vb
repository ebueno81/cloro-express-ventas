Public Class FrmMnSeriesDoc
    
    Private Sub FrmMnSalSeries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmMnSalSeries_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnSalSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv01.DataSource = c_Neg_MnSeriesDoc.get_Series_Datos(" and c_anula_reg=0 order by c_nro_serie", "DGV", FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            .Columns("Doc").Width = 40
            .Columns("Serie").Width = 45
            .Columns("Documento").Width = 65
            .Columns("Descripcion").Width = 125
            .Columns("Medxpress").Width = 70
            .Columns("c_anula_reg").Visible = False
            'Alineacion
            .Columns("Doc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Color de cabecera...
            .Columns("Doc").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Doc").HeaderCell.Style.ForeColor = Color.Blue
        End With
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_Reg=0 order by c_desc_doc", CboDoc)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEditar)
    End Sub
    
    ' Grabar Registro '
    Private Sub Grabar_Serie(ByVal cOpcion As String)
        With c_Ent_SeriesDoc
            .c_codi_doc = CboDoc.SelectedValue
            .c_nro_serie = TxtSerie.Text
            .c_nro_doc = TxtGuia.Text
            .c_desc_serie = TxtDesc.Text
            .copcion = cOpcion
            .c_opc_medxpress = IIf(ChkEsMedxpress.Checked = True, 1, Nothing)
            c_Neg_MnSeriesDoc.set_Series_Save(c_Ent_SeriesDoc, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    'Cerramos ventna
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    Private Sub Cancelar_Registro()
        Dgv01.Size = New Size(387, 217) : BtnNuevo.Text = "&Agregar" : BtnEditar.Enabled = True
        BtnCerrar.Text = "&Cerrar" : BtnNuevo.Enabled = True ': Call Validar_Permisos()
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEditar) : BtnGrabar.Enabled = False
    End Sub
    Private Sub TxtGuia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGuia.LostFocus
        TxtGuia.Text = Strings.Right(Val(TxtGuia.Text) + 10000000, 7)
    End Sub

    Private Sub TxtGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGuia.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    TxtSerie.Text = .Rows(fila).Cells("Serie").Value
                    TxtGuia.Text = .Rows(fila).Cells("documento").Value.ToString
                    TxtDesc.Text = .Rows(fila).Cells("Descripcion").Value
                    CboDoc.SelectedValue = .Rows(fila).Cells("Doc").Value
                    ChkEsMedxpress = IIf(Val(.Rows(fila).Cells("MedXpress").Value) = 1, True, False)
                    Call nuevo_registro() : TxtSerie.Enabled = False
                    CboDoc.Enabled = False
                End If
            End If
        End With
    End Sub
    Private Sub nuevo_registro()
        Dgv01.Size = New Size(387, 123)
        BtnGrabar.Enabled = True
        BtnEditar.Enabled = False : BtnCerrar.Text = "Cancelar"
        ChkEsMedxpress.Checked = False
    End Sub
    ' Nuevo Registro '
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Limpiar_Texto(Pan01) : Call nuevo_registro()
        TxtSerie.Enabled = True : CboDoc.Enabled = True : CboDoc.Focus()
    End Sub
    ' Metodo para validar la grabacion del registro '
    Private Function ValidarDatos() As Boolean
        If CboDoc.SelectedIndex > -1 Then
            If Len(TxtSerie.Text) > 0 Then
                If Len(TxtDesc.Text) > 0 Then
                    If Len(TxtGuia.Text) > 0 Then
                        ValidarDatos = True
                    Else
                        MsgBox(" 1. Falta ingresar el Número de Documento...", vbCritical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox(" 2. Falta ingresar el Nombre del Documento...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox(" 3. Falta ingresar el Número de Serie...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox(" 4. Falta Seleccionar el documento...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Serie("ADD")
                MsgBox("Los datos se grabaron corectamente...", vbInformation, Compañia)
                Call Cancelar_Registro()
                Dgv01.DataSource = c_Neg_MnSeriesDoc.get_Series_Datos(" and c_anula_reg=0 order by c_nro_serie", "DGV", FrmMenu.TxtCod_Emp.Text)
            End If
        End If
    End Sub
    ' Grabamos Registro '
    Private Sub TxtDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesc.TextChanged

    End Sub
End Class