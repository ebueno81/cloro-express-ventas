Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmUsuarios
    Dim Chk As Integer = 0
    Dim Copy As Integer = 0
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid(" and U.c_nom_usua like '%" & TxtBus.Text & "%'")
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_Usuario.get_Usuario_Datos(Cadena, "DGV")
            .Columns("Codigo").Width = 80
            .Columns("Usuario").Width = 260
            .Columns("Area").Width = 180
            .Columns("Fecha Modi.").Width = 140
            'Visibles
            .Columns("PC.").Visible = False
            .Columns("Clave").Visible = False
            .Columns("usua.crea.").Visible = False
            .Columns("usua.modi.").Visible = False
            .Columns("fecha crea.").Visible = False
            .Columns("c_anula_reg").Visible = False
            'Alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Area").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Modi.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Colorear cabecera
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            .Columns("Codigo").DefaultCellStyle.BackColor = Color.Cornsilk
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub

    Private Sub FrmUsuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing) 'Nuevo
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing) 'Editar
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing) 'Grabar
    End Sub
    'Mostramos usuarios...
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboBus.SelectedIndex = 0 : Call Cargar_Modulos()
        c_Neg_MnAreas.Get_Areas_Cbo(" and c_anula_reg=0 order by c_desc_area", CboArea)
        Call Validar_Permiso()
    End Sub
    Private Sub Validar_Permiso()
        With FrmMenu.Dgv01
            For i = 0 To .RowCount - 1
                If UCase(.Rows(i).Cells("c_nom_formu").Value.ToString) = "FRMUSUARIOS" Then
                    If Val(.Rows(i).Cells("c_add_obj").Value) = 0 Then BtnNuevo.Enabled = False
                    If Val(.Rows(i).Cells("c_edit_obj").Value) = 0 Then BtnEditar.Enabled = False
                    If Val(.Rows(i).Cells("c_del_obj").Value) = 0 Then BtnEliminar.Enabled = False
                    i = .RowCount
                End If
            Next
        End With
    End Sub
    Private Sub Cargar_Modulos()
        With c_Neg_Modulos.get_Modulos_Datos(" AND c_anula_reg=0 order by c_codi_modulo", "DAT")
            Dgv02.Rows.Clear()
            For i = 0 To .Rows.Count - 1
                Dgv02.Rows.Add()
                Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_modulo").ToString
                Dgv02.Rows(i).Cells("Nombre").Value = StrConv(.Rows(i)("c_nom_modulo").ToString, VbStrConv.ProperCase)
            Next
        End With
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        If Chk = 0 Then
            Call Seleccion(True)
            Chk = 1
        Else
            Call Seleccion(False)
            Chk = 0
        End If
    End Sub
    'Seleccionamos registro...
    Private Sub Seleccion(ByVal Valor As Boolean)
        With Dgv02
            For i = 0 To .RowCount - 1
                .Rows(i).Cells("Chk_Menu").Value = Valor
                .Rows(i).Cells("Agregar").Value = Valor
                .Rows(i).Cells("Editar").Value = Valor
                .Rows(i).Cells("Eliminar").Value = Valor
            Next
        End With
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then

        Else
            With Dgv01
                If .RowCount > 0 Then
                    Dim fila As Integer = .CurrentCellAddress.Y
                    If fila > -1 Then
                        CboArea.SelectedValue = ""
                        Call Mostrar_Usuario(.Rows(fila).Cells("Codigo").Value)
                        ' .ReadOnly = True ' : .Columns("Nombre").ReadOnly = True
                    End If
                End If
            End With
        End If
    End Sub
    ' Mostramos Datos de Usuario '
    Private Sub Mostrar_Usuario(ByVal codigo As String)
        With c_Neg_Usuario.get_Usuario_Datos(" and c_codi_usua='" & codigo & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan01)
                'Desactivamos los check...'
                For I = 0 To Dgv02.RowCount - 1
                    Dgv02.Rows(I).Cells("Chk_Menu").Value = False
                    Dgv02.Rows(I).Cells("Agregar").Value = False
                    Dgv02.Rows(I).Cells("Editar").Value = False
                    Dgv02.Rows(I).Cells("Eliminar").Value = False
                Next
                TxtUsuario.Text = .Rows(0)("c_codi_usua").ToString
                TxtClave.Text = .Rows(0)("c_clave_usua").ToString
                TxtEmp.Text = .Rows(0)("c_nom_usua").ToString
                TxtPc.Text = .Rows(0)("c_nom_pc").ToString
                TxtEmail.Text = .Rows(0)("c_email_usua").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtSer_Guia.Text = .Rows(0)("c_serie_guia").ToString
                TxtSerie_Bol.Text = .Rows(0)("c_serie_bol").ToString
                TxtSerie_Fact.Text = .Rows(0)("c_serie_fact").ToString
                TxtSerie_NC.Text = .Rows(0)("c_serie_nc").ToString
                TxtSerie_ND.Text = .Rows(0)("c_serie_nd").ToString
                ' usuario de administracion '
                If Val(.Rows(0)("c_usua_admin").ToString) = 1 Then
                    ChkOpcAdm.Checked = True
                Else
                    ChkOpcAdm.Checked = False
                End If
                ' usuario de precios '
                If Val(.Rows(0)("c_usua_precio").ToString) = 1 Then
                    ChkOpcPrecio.Checked = True
                Else
                    ChkOpcPrecio.Checked = False
                End If

                'Mostramos el area 
                CboArea.SelectedValue = .Rows(0)("c_codi_area").ToString
                'Activamos Modulos por Usuarios...
                With c_Neg_Usuario.get_UsuaPermiso_Datos(" and c_codi_usua='" & codigo & "' AND P.c_anula_reg=0 And M.c_anula_reg=0 order by P.c_codi_modulo", "DAT")
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dim Codi_Modulo As String = .Rows(i)("c_codi_modulo").ToString
                            For u = 0 To Dgv02.RowCount - 1
                                'buscamos uno por uno por el grid...
                                If Codi_Modulo = Dgv02.Rows(u).Cells("Codigo").Value Then
                                    If Val(.Rows(i)("c_find_obj").ToString) = 1 Then Dgv02.Rows(u).Cells("Chk_Menu").Value = True
                                    If Val(.Rows(i)("c_add_obj").ToString) = 1 Then Dgv02.Rows(u).Cells("Agregar").Value = True
                                    If Val(.Rows(i)("c_edit_obj").ToString) = 1 Then Dgv02.Rows(u).Cells("Editar").Value = True
                                    If Val(.Rows(i)("c_del_obj").ToString) = 1 Then Dgv02.Rows(u).Cells("Eliminar").Value = True
                                    u = Dgv02.RowCount
                                End If
                            Next
                        Next
                    End If
                End With
            End If
        End With
    End Sub
    'Cancelamos Registro...
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call Cancelar_Registro() : Call Validar_Permiso()
    End Sub
    Private Sub Nuevo_Registro()
        BtnSelect.Enabled = True : BtnGrabar.Enabled = True : TxtUsuario.Focus() : CboArea.Enabled = True : TxtUsuario.Enabled = False : Call Activar(Pan01)
        Dgv02.ReadOnly = False : Dgv02.Columns("Nombre").ReadOnly = True
        TxtSer_Guia.Enabled = True : TxtSerie_Bol.Enabled = True
        TxtSerie_NC.Enabled = True : TxtSerie_ND.Enabled = True : TxtSerie_Fact.Enabled = True
    End Sub
    Private Sub Cancelar_Registro()
        Call Desactivar(Pan01) : BtnSelect.Enabled = True : BtnGrabar.Enabled = False : BtnSelect.Enabled = False : Tbc01.SelectedTab = Tab01
        Dgv01.ReadOnly = True: TxtSer_Guia.Enabled = False : TxtSerie_Bol.Enabled = False
        TxtSerie_NC.Enabled = False : TxtSerie_ND.Enabled = False : TxtSerie_Fact.Enabled = False
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01) : Call Nuevo_Registro() : Call Seleccion(False) : TxtUsuario.Enabled = True
        TxtUsuario.Focus() : ChkOpcAdm.Checked = False : ChkOpcPrecio.Checked = False
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Habilitamos los colores activos e inactivos '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Mostramos los datos al dar doble click
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then 'Validamos si registro se encuentra activo o esta anulado
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing) : Call Nuevo_Registro() : TxtUsuario.Enabled = False : TxtClave.Focus()
                    Else
                        MsgBox(" Registro no puede ser editado, se encuentra modificado...  ", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Grabamos registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtClave.Text) > 0 Then
            If Len(TxtEmp.Text) > 0 Then
                Dim x As New TextBox
                If TxtUsuario.Enabled = True Then
                    Call Validar_Usuario(x)
                End If
                If Val(x.Text) = 0 Then
                    Dim f As String = MsgBox(" ¿Desea grabar el registro...? ", vbQuestion + vbYesNo, Compañia)
                    If f = vbYes Then
                        Call Grabar_Usuario("ADD")
                        With Dgv02
                            For I = 0 To .RowCount - 1
                                Call Grabar_Permisos(I, "ADD")
                            Next
                        End With
                        Call Cancelar_Registro()
                        Call Cargar_Grid(" order by c_codi_usua")
                        MsgBox("  Registro se grabo correctamente... ", vbExclamation, Compañia)
                    End If
                Else
                    MsgBox(" 1. Usuario ya fue registrado anteriormente... ", vbCritical, Compañia)
                End If
            Else
                MsgBox(" 2. Falta ingresar el nombre del empleado...  ", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            MsgBox(" 3. Falta ingresar la clave...  ", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub
    Private Sub Grabar_Usuario(ByVal cOpcion As String)
        With c_Ent_Usuarios
            Dim c_usua_admin As Integer = 0
            Dim c_usua_precio As Integer = 0
            .c_codi_usua = TxtUsuario.Text
            .c_clave_usua = TxtClave.Text
            .c_nom_usua = TxtEmp.Text
            .c_nom_pc = TxtPc.Text
            .c_codi_area = CboArea.SelectedValue
            .c_email_usua = TxtEmail.Text
            .c_serie_bol = TxtSerie_Bol.Text : .c_serie_fact = TxtSerie_Fact.Text
            .c_serie_guia = TxtSer_Guia.Text
            .c_serie_nc = TxtSerie_NC.Text : .c_serie_nd = TxtSerie_ND.Text
            .c_codi_alm = ""
            .c_codi_vende = ""
            '   Validamos si usuario puede cambiar la fecha de emision de la factura '
            .c_fecha_activa = 0
            If ChkOpcAdm.Checked = True Then c_usua_admin = 1
            If ChkOpcPrecio.Checked = True Then c_usua_precio = 1
            .c_usua_admin = c_usua_admin
            .c_usua_precio = c_usua_precio
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_Usuario.set_Usuario_Save(c_Ent_Usuarios)
        End With
    End Sub
    ' Metodo para grabar los permisos por los ususarios
    Private Sub Grabar_Permisos(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_UsuaPermiso
            Dim Add As Integer = 0 : Dim Edit As Integer = 0 : Dim Find As Integer = 0 : Dim Del As Integer = 0
            .c_codi_usua = TxtUsuario.Text
            .c_codi_modulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            If Dgv02.Rows(Fila).Cells("Chk_Menu").Value = True Then Find = 1
            If Dgv02.Rows(Fila).Cells("Agregar").Value = True Then Add = 1
            If Dgv02.Rows(Fila).Cells("Editar").Value = True Then Edit = 1
            If Dgv02.Rows(Fila).Cells("Eliminar").Value = True Then Del = 1
            .c_add_obj = Add
            .c_edit_obj = Edit
            .c_find_obj = Find
            .c_del_obj = Del
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_Usuario.set_UsuaPermiso_Save(c_Ent_UsuaPermiso)
        End With
    End Sub
    Private Sub Validar_Usuario(ByVal x As TextBox)
        With c_Neg_Usuario.get_Usuario_Datos(" and c_codi_usua='" & TxtUsuario.Text & "'", "DAT")
            x.Clear()
            If .Rows.Count > 0 Then
                x.Text = 1
            End If
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

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    'Cerramos formulario...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox(" ¿Confirma la eliminación del registro?  ", vbYesNo + vbQuestion, Compañia)
                        If f = vbYes Then
                            TxtUsuario.Text = .Rows(Fila).Cells("Codigo").Value
                            Mostrar_Usuario(TxtUsuario.Text)
                            Call Grabar_Usuario("DEL") : BtnMostrar_Click(Nothing, Nothing)
                        End If

                    Else
                        MsgBox("  Registro se encuentra anulado...  ", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub FrmUsuarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Mostrar_Usuario(.Rows(Fila).Cells("Codigo").Value)
                    MsgBox("Perfil de usuario copiado correctamente...", vbInformation, Compañia)
                    Copy = 1
                End If
            End If
        End With
    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Copy = 1 Then
                        Dim F As String = MsgBox("¿Desea copiar el perfil del usuario?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtUsuario.Text = .Rows(Fila).Cells("Codigo").Value
                            With Dgv02
                                For I = 0 To .RowCount - 1
                                    Call Grabar_Permisos(I, "ADD")
                                Next
                                MsgBox("Usuario se copio correctamente...", vbExclamation, Compañia)
                                Copy = 0
                            End With
                        End If
                    Else
                        MsgBox("Primero debe copiar el usuario para poder pegarlo...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv02_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub
    Private Sub Dgv02_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseDoubleClick
        With Dgv02
            If .RowCount > 0 Then
                Dim C As Integer = .CurrentCellAddress.X
                'visible
                If C = 0 Then
                    For i = 0 To .RowCount - 1
                        .Rows(i).Cells("Chk_Menu").Value = True
                    Next
                End If
                'add
                If C = 3 Then
                    For i = 0 To .RowCount - 1
                        .Rows(i).Cells("Agregar").Value = True
                    Next
                End If
                'edit
                If C = 4 Then
                    For i = 0 To .RowCount - 1
                        .Rows(i).Cells("Editar").Value = True
                    Next
                End If
                'del
                If C = 5 Then
                    For i = 0 To .RowCount - 1
                        .Rows(i).Cells("Eliminar").Value = True
                    Next
                End If
            End If
        End With
    End Sub
End Class