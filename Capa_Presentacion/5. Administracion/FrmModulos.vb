Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmModulos
    Dim c_Neg_Modulos As New Neg_Modulos : Dim c_Ent_Modulos As New Ent_Modulos
    Dim Swicht As Integer = 0
    'Metodo que nos permite avanzar con la tecla enter...
    Private Sub FrmModulos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_Grid() : Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    'Cargamos a grid todos los modulos...
    Private Sub Cargar_Grid()
        With c_Neg_Modulos.get_Modulos_Datos(" order by c_codi_modulo", "DAT")
            Dgv01.Rows.Clear()
            If .Rows.Count > 0 Then
                Dgv01.Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
                Dgv01.Columns("Codigo").HeaderCell.Style.ForeColor = Color.Black
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_modulo").ToString
                    Dgv01.Rows(i).Cells("Titulo").Value = .Rows(i)("c_nom_modulo").ToString
                    Dgv01.Rows(i).Cells("nom_menu").Value = .Rows(i)("c_nom_menu").ToString
                    Dgv01.Rows(i).Cells("nom_formu").Value = .Rows(i)("c_nom_formu").ToString
                    Dgv01.Rows(i).Cells("nom_tool").Value = .Rows(i)("c_nom_tool").ToString
                    Dgv01.Rows(i).Cells("c_anula_reg").Value = .Rows(i)("c_anula_reg").ToString
                    'Validamos si registro se encuentra anulado...
                    If Val(.Rows(i)("c_anula_reg").ToString) = 1 Then
                        Dgv01.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next
            End If
            If Dgv01.RowCount > 0 Then TxtReg.Text = "1 / " & Dgv01.RowCount
        End With
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtCodigo.Enabled = True
        TxtCodigo.Focus()
    End Sub
    'Nuevo Registro...
    Private Sub Nuevo_Registro()
        With Dgv01
            .Size = New Size(797, 371) : .Location = New Point(0, 83) : Pan01.Enabled = True
            Call Limpiar_Texto(Pan01) : Pan02.Enabled = False : BtnCerrar.Text = "&Cancelar"
            Pan03.Enabled = False : Dgv01.Enabled = False
        End With
    End Sub
    'Nuevo Registro...
    Private Sub Cancela_Registro()
        With Dgv01
            .Size = New Size(797, 396) : .Location = New Point(0, 58) : Pan01.Enabled = False
            Call Limpiar_Texto(Pan01) : Pan02.Enabled = True : BtnCerrar.Text = "&Cerrar"
            Pan03.Enabled = True : Dgv01.Enabled = True : Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        End With
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro() : TxtCodigo.Enabled = False : TxtTit_Menu.Focus()
                        TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtTit_Menu.Text = .Rows(Fila).Cells("Titulo").Value
                        TxtNom_Menu.Text = .Rows(Fila).Cells("Nom_Menu").Value
                        TxtNom_Formu.Text = .Rows(Fila).Cells("Nom_Formu").Value
                        TxtNom_Tool.Text = .Rows(Fila).Cells("Nom_Tool").Value
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
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

    Private Sub TxtNom_Formu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNom_Formu.KeyDown
        
    End Sub
    'Metodo que nos permite grabar los modulos
    Private Sub Grabar_Modulo(ByVal cOpcion As String)
        With c_Ent_Modulos
            .c_codi_modulo = TxtCodigo.Text
            .c_nom_modulo = TxtTit_Menu.Text
            .c_nom_menu = TxtNom_Menu.Text
            .c_nom_formu = TxtNom_Formu.Text
            .c_nom_tool = TxtNom_Tool.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_usuario = cOpcion
            c_Neg_Modulos.set_Usuario_Save(c_Ent_Modulos)
            Call Cancela_Registro()
            ' MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
            Call Cargar_Grid()
        End With
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub
    'Eliminamos registro...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                    If Fila > -1 Then
                        TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
                        Dim F As String = MsgBox("¿Confirma la elimación del Registro?", vbYesNo + vbCritical, Compañia)
                        If F = vbYes Then Call Grabar_Modulo("DEL")
                        Call BtnFin_Click(Nothing, Nothing)
                    End If
                Else
                    MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Editamos registros...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancela_Registro() : BtnNuevo.Focus()
        End If
    End Sub

    Private Sub TxtNom_Tool_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNom_Tool.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCodigo.Text) > 0 Then
                If Len(TxtTit_Menu.Text) > 0 Then
                    Dim F As String = MsgBox("¿Desea grabar el módulo?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_Modulo("ADD") : Swicht = 1 : BtnNuevo.Focus()
                    End If
                Else
                    MsgBox("1. Falta ingresar Nombre de Módulo...", vbCritical, Compañia)
                End If
            Else
                MsgBox("2. Falta ingresar código del Módulo...", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub TxtNom_Tool_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNom_Tool.TextChanged

    End Sub
    ' Evitamos perder el enfoque '
    Private Sub BtnNuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.LostFocus
        If Swicht = 1 Then
            Swicht = 0 : BtnNuevo.Focus()
        End If
    End Sub
End Class