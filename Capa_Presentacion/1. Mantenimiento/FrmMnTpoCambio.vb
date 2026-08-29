Public Class FrmMnTpoCambio
    Dim var1 As Integer = 0 'variable que trabajara para grabar o editar 
    Private Sub FrmTpoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = 112 Then If BtnInternet.Enabled = True Then Call BtnInternet_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.N Then If BtnGrabar.Enabled = True And BtnGrabar.Text = "&Agregar" Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True And BtnGrabar.Text = "&Grabar" Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing) 'editamos registro...
    End Sub

    Private Sub FrmTpoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmTpoCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(50, 50)
        Call Cargar_Grid(" order by c_fecha_cbo desc")
        Call Validar_Permiso(Me.Name, BtnGrabar, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        dgv01.DataSource = c_Neg_TpoCambio.get_TpoCambio_Datos(Cadena, "DGV")
        With dgv01
            .Columns("Fecha").Width = 90
            .Columns("Compra Sunat").Width = 90
            .Columns("Venta Sunat").Width = 90
            'Alineacion de Columnas...
            .Columns("Fecha").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Compra Sunat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Venta Sunat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub Nuevo_Ingreso()
        With dgv01
            .Location = New Point(1, 57)
            .Size = New Size(323, 246)
            DtpFec_Emi.Focus()
            BtnCerrar.Text = "Cancelar"
        End With
    End Sub
    Private Sub Cancela_Ingreso()
        With dgv01
            .Location = New Point(1, 33)
            .Size = New Size(323, 270)
            BtnGrabar.Text = "&Agregar"
            BtnEditar.Enabled = True
            BtnGrabar.Enabled = True
            BtnCerrar.Text = "Cerrar"
        End With
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If BtnGrabar.Text = "&Grabar" Then
            Dim f As String = MsgBox("¿Desea Grabar el tipo de cambio?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
            If f = vbYes Then
                Call Grabar_TpoCambio()
                Call Cancela_Ingreso()
            End If
        Else
            Call Nuevo_Ingreso()
            BtnGrabar.Text = "&Grabar"
            BtnEditar.Enabled = False
        End If
    End Sub
    'Grabamos tipo de cambio
    Private Sub Grabar_TpoCambio()
        With c_Ent_TpoCambio
            .c_fecha_cbo = DtpFec_Emi.Text
            .c_compra_sunat = Format(Val(TxtTpo_Compra.Text), Forma_1_3)
            .c_venta_sunat = Format(Val(TxtTpo_Venta.Text), Forma_1_3)
        End With
        c_Neg_TpoCambio.set_TpoCambio_Save(c_Ent_TpoCambio) 'actualizammos el tipo de cambio...
        dgv01.DataSource = c_Neg_TpoCambio.get_TpoCambio_Datos(" order by c_fecha_cbo desc", "DGV")
    End Sub
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Call Nuevo_Ingreso()
        BtnGrabar.Enabled = True
        BtnGrabar.Text = "&Grabar"
        BtnEditar.Enabled = False
        var1 = 2
        With dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    DtpFec_Emi.Text = .Rows(fila).Cells("Fecha").Value
                    TxtTpo_Compra.Text = Format(Val(.Rows(fila).Cells("compra sunat").Value), Forma_1_3)
                    TxtTpo_Venta.Text = Format(Val(.Rows(fila).Cells("venta sunat").Value), Forma_1_3)
                End If
            End If
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            Call Cancela_Ingreso() : Call Validar_Permiso(Me.Name, BtnGrabar, BtnEditar, BtnEliminar)
        End If
    End Sub

    Private Sub BtnInternet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInternet.Click
        'consultamos ruc en la pagina de la sunat
        Dim proceso As New System.Diagnostics.Process
        With proceso
            .StartInfo.FileName = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias"
            .Start()
        End With
    End Sub
End Class