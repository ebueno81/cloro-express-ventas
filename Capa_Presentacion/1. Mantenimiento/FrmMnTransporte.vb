Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmMnTransporte
    Dim c_neg_MnTransporte As New Neg_MnTransporte : Dim c_Ent_MnTransporte As New Ent_MnTransporte
    Dim c_neg_mncliente As New Neg_MnCliente
    Private Sub FrmMnTransporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub
    'Avanzamos al presionar la tecla enter...
    Private Sub FrmMnTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        c_Neg_MnEmprServ.Get_EmpServ_Cbo(" and c_anula_reg=0 order by c_desc_empserv", CboEmpServ)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_neg_MnTransporte.get_Transporte_Datos(Cadena, "DGV")
            .Columns("Placa").Width = 70
            .Columns("Empresa").Width = 210
            .Columns("Direccion").Width = 180
            .Columns("R.U.C.").Width = 100
            .Columns("Vehiculo").Width = 120
            .Columns("Color").Width = 210
            .Columns("Observacion").Width = 210
            .Columns("c_anula_Reg").Visible = False
            .Columns("Direccion").Visible = False
            .Columns("R.U.C.").Visible = False
            Call Grid_Registros_anulados(Dgv01)
            'Alienacion
            .Columns("Placa").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Placa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.Click
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    Private Sub Mostrar_Transporte(ByVal Fila As Integer)
        With c_neg_MnTransporte.get_Transporte_Datos(" and c_placa_trp='" & Dgv01.Rows(Fila).Cells("Placa").Value & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan02)
                TxtPlaca.Text = .Rows(0)("c_placa_trp").ToString
                TxtCod_Emp.Text = .Rows(0)("c_codi_clie").ToString
                CboEmpServ.Text = .Rows(0)("c_desc_empserv").ToString
                TxtDireccion.Text = .Rows(0)("c_direcc_trp").ToString
                TxtVehiculo.Text = .Rows(0)("c_vehiculo_trp").ToString
                TxtColor.Text = .Rows(0)("c_color_trp").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_empserv").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtPeso.Text = .Rows(0)("c_peso_trp").ToString
                TxtAltura.Text = .Rows(0)("c_altura_trp").ToString
                TxtAncho.Text = .Rows(0)("c_ancho_trp").ToString
                TxtLongitud.Text = .Rows(0)("c_longitud_trp").ToString
                TxtNroTarjeta.Text = .Rows(0)("c_nro_tarjcircula").ToString

                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub
    'Grabamos Transporte
    Private Sub Grabar_Transporte(ByVal cOpcion As String)
        With c_Ent_MnTransporte
            .c_placa_trp = TxtPlaca.Text
            .c_codi_clie = TxtCod_Emp.Text
            .c_direcc_trp = TxtDireccion.Text
            .c_vehiculo_trp = TxtVehiculo.Text
            .c_color_trp = TxtColor.Text
            .c_peso_trp = TxtPeso.Text
            .c_altura_trp = TxtAltura.Text
            .c_longitud_trp = TxtLongitud.Text
            .c_ancho_trp = TxtAncho.Text
            .c_nro_tarjeta = TxtNroTarjeta.Text
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_neg_MnTransporte.set_Transporte_Save(c_Ent_MnTransporte)
        End With
        Call Cargar_Grid(" order by c_placa_trp")
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        BtnCancelar_Click(Nothing, Nothing) : BtnGrabar.Enabled = False
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : Pan02.Enabled = True : TxtPlaca.Enabled = True : TxtPlaca.Focus() : BtnGrabar.Enabled = True
        CboEmpServ.Text = "" : TxtCod_Emp.Text = ""
    End Sub
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01)
        CboEmpServ.Enabled = True : TxtDireccion.Enabled = True : TxtVehiculo.Enabled = True : TxtColor.Enabled = True
        TxtObs.Enabled = True : Call Limpiar_Texto(Pan02)
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro()
                        Call Tbc01_Click(Nothing, Nothing) : BtnGrabar.Enabled = True : Pan02.Enabled = True : CboEmpServ.Focus() : TxtPlaca.Enabled = False
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Eliminar Registros
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            TxtPlaca.Text = Dgv01.Rows(fila).Cells("Placa").Value
                            Call Grabar_Transporte("DEL") : Call Cargar_Grid("")
                        End If

                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtPlaca.Text) > 0 And Len(TxtCod_Emp.Text) > 0 Then
            Call Grabar_Transporte("ADD")
        Else
            MsgBox("Falta ingresar la placa o seleccionar la empresa...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False : Pan02.Enabled = False
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub
    'Cerramos formularios...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then
            Pan02.Enabled = False : BtnGrabar.Enabled = False
        Else
            With Dgv01
                Call Nuevo_Registro()
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_Transporte(Fila) : Pan02.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub

    'buscamos al presionar la tecla enter...
    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Cargar_Grid(" and C.c_desc_empserv like '%" & TxtBuscar.Text & "%' order by c_desc_empserv")
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    '---> Validamos los registros anulados <--- 
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub CboEmpServ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpServ.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboEmpServ, TxtCod_Emp)
        ' mostramos datos de empresa de servicio '
        If CboEmpServ.Enabled = True Then
            With c_Neg_MnEmprServ.get_EmpServ_Datos(" AND E.c_codi_empserv='" & TxtCod_Emp.Text & "' ", "DAT")
                If .Rows.Count > 0 Then
                    TxtRuc.Text = .Rows(0)("c_ruc_empserv").ToString
                    TxtDireccion.Text = .Rows(0)("c_direcc_empserv").ToString & " " & .Rows(0)("c_dist_empserv").ToString
                End If
            End With
        End If
    End Sub
End Class