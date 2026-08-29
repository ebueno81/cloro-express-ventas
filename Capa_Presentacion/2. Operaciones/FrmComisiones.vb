Public Class FrmComisiones

    Private Sub FrmComisiones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.P Then If BtnImp.Enabled = True Then Call BtnImp_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F4 Then
            If LnkPorc.Enabled = True Then

            End If
        End If
    End Sub

    Private Sub FrmComisiones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    ' Cargamos Registros '
    Private Sub FrmComisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With c_Neg_MnVendedor.get_Vendedor_Datos(" and c_anula_reg=0 order by c_nom_vende ", "DAT")
            CboVende.Items.Clear()
            CboVende.Items.Add("(Todos)")
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    CboVende.Items.Add(.Rows(i)("c_nom_vende").ToString & " / " & .Rows(i)("c_codi_vende").ToString)
                Next
            End If
            CboVende.SelectedIndex = 0
        End With
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    ' Nuevo Registro '
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : DtpFec_Inicio.Focus() : BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Color.Maroon
        Call Limpiar_Texto(Pan04) : DtpFec_Inicio.Enabled = True : DtpFec_Final.Enabled = True : Dgv01.Rows.Clear()
    End Sub
    ' Metodo para crear un nuevo registro '
    Private Sub Nuevo_Registro()
        BtnMostrar.Enabled = True : Pan01.Enabled = False
        Pan07.Enabled = False : BtnCerrar.Text = "Cancelar" : BtnGrabar.Enabled = True : LnkPorc.Enabled = True
    End Sub
    ' Metodo para Cancelar un nuevo registro '
    Private Sub Cancelar_Registro()
        DtpFec_Inicio.Enabled = False : DtpFec_Final.Enabled = False : BtnMostrar.Enabled = False : Pan01.Enabled = True
        Pan07.Enabled = True : BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False : Dgv01.ReadOnly = True : LnkPorc.Enabled = False
    End Sub
    ' Metodo para actualizar las facturas '
    Private Sub Actualizar_Factor()
        c_Neg_ComisCab.set_ComisFactor_Save(DtpFec_Inicio.Text, DtpFec_Final.Text)
    End Sub
    ' Configurar Grid '
    Public Sub Cargar_Grid(ByVal Cadena As String)
        '  InputBox("", "", Cadena)
        Call Actualizar_Factor() : Dgv01.Rows.Clear()
        With c_Neg_RptVtasTdas.get_Comision_Dat(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            Dim Tot As Integer = 0
            For I = 0 To .Rows.Count - 1
                Dgv01.Rows.Add() : Tot = Dgv01.RowCount - 1
                Dgv01.Rows(Tot).Cells("Chk").Value = True
                Dgv01.Rows(Tot).Cells("Tpo_Doc").Value = .Rows(I)("Tpo.Doc.").ToString
                Dgv01.Rows(Tot).Cells("Nro_Doc").Value = .Rows(I)("Nro.Doc.").ToString
                Dgv01.Rows(Tot).Cells("Fecha").Value = FormatDateTime(.Rows(I)("Fecha").ToString, DateFormat.ShortDate)
                Dgv01.Rows(Tot).Cells("Nick").Value = .Rows(I)(" ").ToString
                Dgv01.Rows(Tot).Cells("Cliente").Value = .Rows(I)("Cliente").ToString
                Dgv01.Rows(Tot).Cells("Tpo_cambio").Value = Format(Val(.Rows(I)("T.C.").ToString), Forma_1_3)
                Dgv01.Rows(Tot).Cells("Importe").Value = Format(Val(.Rows(I)("Importe").ToString), Forma_1_2)
                Dgv01.Rows(Tot).Cells("Igv").Value = Format(Val(.Rows(I)("I.G.V.").ToString), Forma_1_2)
                Dgv01.Rows(Tot).Cells("Total").Value = Format(Val(.Rows(I)("Total").ToString), Forma_1_2)
                Dgv01.Rows(Tot).Cells("Comision").Value = Format(Val(.Rows(I)("Comision").ToString), Forma_1_2)
                Dgv01.Rows(Tot).Cells("Saldo").Value = Format(Val(.Rows(I)("Saldo").ToString), Forma_1_2)
                Dgv01.Rows(Tot).Cells("Estado").Value = .Rows(I)("Estado").ToString
                Dgv01.Rows(Tot).Cells("Vendedor").Value = .Rows(I)("Vendedor").ToString
                ' Codigos '
                Dgv01.Rows(Tot).Cells("c_codi_clie").Value = .Rows(I)("c_codi_clie").ToString
                Dgv01.Rows(Tot).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                Dgv01.Rows(Tot).Cells("c_codi_doc").Value = .Rows(I)("c_codi_doc").ToString
                Dgv01.Rows(Tot).Cells("c_codi_vende").Value = .Rows(I)("c_codi_vende").ToString
                Dgv01.Rows(Tot).Cells("c_porc_comis").Value = Format(Val(.Rows(I)("c_porc_comis").ToString), Forma_1_3)
                Dgv01.Rows(Tot).Cells("Item").Value = ""
            Next
            Dgv01.ReadOnly = False
            Dgv01.Columns("Chk").ReadOnly = False
            Call Calcular_Totales()
        End With
    End Sub
    ' --> Mostramos Registros <--'
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Vende As String = ""
        If CboVende.SelectedIndex > 0 Then Vende = " and C.c_codi_vende='" & Strings.Right(CboVende.Text, 2) & "' "
        ' 2 = COMISIONES CANCELADAS
        Call Cargar_Grid(" and V.c_afecto_comi = 1 AND C.c_cancel_comis in (0,1) and C.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and C.c_fecha_emi<='" & DtpFec_Final.Text & "' " & Vende)
    End Sub
    ' Metodo para calcular los totales '
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("Nick").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_1 = Tot_1 + Val(.Rows(i).Cells("Importe").Value)
                    Tot_3 = Tot_3 + Val(.Rows(i).Cells("Total").Value)
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Comision").Value)
                    Tot_7 = Tot_7 + Val(.Rows(i).Cells("Saldo").Value)
                End If
                If .Rows(i).Cells("Nick").Value = "$." Then
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_2 = Tot_2 + Val(.Rows(i).Cells("Importe").Value)
                    Tot_4 = Tot_4 + Val(.Rows(i).Cells("Total").Value)
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Comision").Value)
                    Tot_8 = Tot_8 + Val(.Rows(i).Cells("Saldo").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_01.Text = Format(Val(Tot_1), Forma_2_2)
            TxtTot_02.Text = Format(Val(Tot_2), Forma_2_2)
            TxtTot_03.Text = Format(Val(Tot_3), Forma_2_2)
            TxtTot_04.Text = Format(Val(Tot_4), Forma_2_2)
            TxtTot_05.Text = Format(Val(Tot_5), Forma_2_2)
            TxtTot_06.Text = Format(Val(Tot_6), Forma_2_2)
            TxtTot_07.Text = Format(Val(Tot_7), Forma_2_2)
            TxtTot_08.Text = Format(Val(Tot_8), Forma_2_2)
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
            ' Validamos si existe numero de comision '
            If Len(TxtNro_Comis.Text) = 0 Then
                Call BtnFin_Click(Nothing, Nothing)
            Else
                TxtBus_Lote.Text = Strings.Right(Val(TxtBus_Lote.Text) + 10000000, 7)
                Call Mostrar_Comis(" and c_nro_comis='" & TxtBus_Lote.Text & "'")
            End If
        End If
    End Sub
    ' Grabamos Registros '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim F As String = MsgBox("¿Desea Grabar los Registros?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_ComisCab("ADD")
                With Dgv01
                    For i = 0 To .RowCount - 1
                        If .Rows(i).Cells("Chk").Value = True Then
                            Call Grabar_ComisDet(i, "ADD")
                        End If
                    Next
                End With
                Call BtnCerrar_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    ' Metodo para grabar cabecera de Comisiones 
    Private Sub Grabar_ComisCab(ByVal cOpcion As String)
        With c_Ent_ComisCab
            .c_nro_comis = TxtNro_Comis.Text
            .c_fecha_inicio = DtpFec_Inicio.Text
            .c_fecha_final = DtpFec_Final.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Val(TxtNro_Comis.Text) = 0 Then
                TxtNro_Comis.Text = c_Neg_ComisCab.set_ComisCab_Save(c_Ent_ComisCab)
            Else
                c_Neg_ComisCab.set_ComisCab_Save(c_Ent_ComisCab)
            End If
        End With
    End Sub
    ' Metodo para Grabar detalles de Comisiones '
    Private Sub Grabar_ComisDet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_ComisDet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
            .c_nro_comis = TxtNro_Comis.Text
            .c_codi_doc = Dgv01.Rows(Fila).Cells("c_codi_doc").Value
            .c_serie_doc = Strings.Left(Dgv01.Rows(Fila).Cells("Nro_doc").Value, 4)
            .c_nro_doc = Strings.Right(Dgv01.Rows(Fila).Cells("Nro_doc").Value, 7)
            .c_fecha_emi = Dgv01.Rows(Fila).Cells("Fecha").Value
            .c_codi_mon = Dgv01.Rows(Fila).Cells("c_codi_mon").Value
            .c_codi_clie = Dgv01.Rows(Fila).Cells("c_codi_clie").Value
            .c_tpo_cambio = Dgv01.Rows(Fila).Cells("Tpo_cambio").Value
            .c_imp_doc = Dgv01.Rows(Fila).Cells("Importe").Value
            .c_igv_doc = Dgv01.Rows(Fila).Cells("Igv").Value
            .c_tot_doc = Dgv01.Rows(Fila).Cells("Total").Value
            .c_imp_comis = Dgv01.Rows(Fila).Cells("Comision").Value
            .c_imp_saldo = Dgv01.Rows(Fila).Cells("Saldo").Value
            .c_desc_estado = Dgv01.Rows(Fila).Cells("Estado").Value
            .c_codi_vende = Dgv01.Rows(Fila).Cells("c_codi_vende").Value
            .c_porc_comis = Val(Dgv01.Rows(Fila).Cells("c_porc_comis").Value)
            .copcion = cOpcion
            If Val(Dgv01.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv01.Rows(Fila).Cells("Item").Value = c_Neg_ComisDet.set_ComisDet_Save(c_Ent_ComisDet)
            Else
                c_Neg_ComisDet.set_ComisDet_Save(c_Ent_ComisDet)
            End If
        End With
    End Sub
    ' Metodo para Actualizar las Comisiones '
    Private Sub Modificar_ComisDet(ByVal Fila As Integer, ByVal c_porc_comis As Decimal, ByVal cOpcion As String)
        With c_Ent_ComisDet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
            .c_codi_doc = Dgv01.Rows(Fila).Cells("c_codi_doc").Value
            .c_serie_doc = Strings.Left(Dgv01.Rows(Fila).Cells("Nro_doc").Value, 3)
            .c_nro_doc = Strings.Right(Dgv01.Rows(Fila).Cells("Nro_doc").Value, 7)
            .c_imp_comis = Dgv01.Rows(Fila).Cells("Comision").Value
            .c_porc_comis = c_porc_comis
            .copcion = cOpcion
            c_Neg_ComisDet.set_ComisModifica_Save(c_Ent_ComisDet)

        End With
    End Sub
    ' Private sub Validar datos del detalle '
    Private Function ValidarDatos() As Boolean
        Dim Valida As Integer = 0
        With Dgv01
            If Dgv01.RowCount > 0 Then
                ' Validamos si estan seleccionados algun item '
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells("Chk").Value = True Then
                        Valida = Valida + 1
                    End If
                Next
                If Valida > 0 Then
                    ValidarDatos = True
                Else
                    ValidarDatos = False
                    MsgBox("Debe seleccionar un Item por lo menos...", vbCritical, Compañia)
                End If
            Else
                MsgBox("Falta ingresar el detalle...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        End With
    End Function
    ' Final de Comisiones '
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Comis(" and c_nro_comis= (select max(c_nro_comis) from Sca_ComisCab)")
    End Sub
    ' Metodo para mostrar las comisiones '
    Private Sub Mostrar_Comis(ByVal Cadena As String)
        With c_Neg_ComisCab.get_ComisCab_Datos(Cadena, "DAT") : TxtBus_Lote.Clear()
            Call Limpiar_Texto(Pan05) : Call Limpiar_Texto(Pan04) : Dgv01.Rows.Clear()
            If .Rows.Count > 0 Then
                ' Validamos estado del registro '
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_opc_cancel").ToString) = 1 Then
                        BtnEstado.BackColor = Color.Blue : BtnEstado.Text = "CERRADO"
                    Else
                        BtnEstado.BackColor = Color.Maroon : BtnEstado.Text = "PENDIENTE"
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                End If
                TxtBus_Lote.Text = .Rows(0)("c_nro_Comis").ToString
                TxtNro_Comis.Text = .Rows(0)("c_nro_Comis").ToString
                DtpFec_Inicio.Text = .Rows(0)("c_fecha_inicio").ToString
                DtpFec_Final.Text = .Rows(0)("c_fecha_final").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                ' Cargamos detalles de Comisiones '
                With c_Neg_ComisDet.get_ComisDet_Datos(" and D.c_anula_Reg=0 and D.c_nro_comis='" & TxtNro_Comis.Text & "' order by c_nro_correl", "DAT")
                    Dgv01.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv01.Rows.Add()
                            Dgv01.Rows(i).Cells("Chk").Value = True
                            Dgv01.Rows(i).Cells("Vendedor").Value = .Rows(i)("c_nom_vende").ToString
                            Dgv01.Rows(i).Cells("Tpo_doc").Value = .Rows(i)("c_desc_doc").ToString
                            Dgv01.Rows(i).Cells("Nro_doc").Value = .Rows(i)("c_serie_doc").ToString & " " & .Rows(i)("c_nro_doc").ToString
                            Dgv01.Rows(i).Cells("Fecha").Value = FormatDateTime(.Rows(i)("c_Fecha_emi").ToString, DateFormat.ShortDate)
                            Dgv01.Rows(i).Cells("nick").Value = .Rows(i)("c_nick_mon").ToString
                            Dgv01.Rows(i).Cells("Cliente").Value = .Rows(i)("c_desc_clie").ToString
                            Dgv01.Rows(i).Cells("Tpo_Cambio").Value = Format(Val(.Rows(i)("c_tpo_cambio").ToString), Forma_1_3)
                            Dgv01.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_imp_doc").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Igv").Value = Format(Val(.Rows(i)("c_igv_doc").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Total").Value = Format(Val(.Rows(i)("c_tot_doc").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Comision").Value = Format(Val(.Rows(i)("c_imp_comis").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Saldo").Value = Format(Val(.Rows(i)("c_imp_saldo").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("c_porc_comis").Value = Format(Val(.Rows(i)("c_porc_comis").ToString), Forma_1_3)
                            Dgv01.Rows(i).Cells("Estado").Value = .Rows(i)("c_desc_estado").ToString
                            Dgv01.Rows(i).Cells("c_codi_vende").Value = .Rows(i)("c_codi_vende").ToString
                            Dgv01.Rows(i).Cells("c_codi_doc").Value = .Rows(i)("c_codi_doc").ToString
                            Dgv01.Rows(i).Cells("c_codi_clie").Value = .Rows(i)("c_codi_clie").ToString
                            Dgv01.Rows(i).Cells("c_codi_mon").Value = .Rows(i)("c_codi_mon").ToString
                            Dgv01.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                        Next
                    End If
                End With
            End If
            Call Calcular_Totales()
        End With
    End Sub
    ' Iniciamos Registro '
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Comis(" and c_nro_comis= (select min(c_nro_comis) from Sca_ComisCab)")
    End Sub
    ' Nos vamos hacia el registro anterior '
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_Lote.Text) > 1 Then
            TxtBus_Lote.Text = Strings.Right((Val(TxtBus_Lote.Text) - 1) + 10000000, 7)
            Call Mostrar_Comis(" and c_nro_comis='" & TxtBus_Lote.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_Lote.Text) > 0 Then
            TxtBus_Lote.Text = Strings.Right(Val(TxtBus_Lote.Text) + 100000001, 7)
            Call Mostrar_Comis(" and c_nro_comis='" & TxtBus_Lote.Text & "'")
        End If
    End Sub
    ' Buscamos al presionar la tecla enter '
    Private Sub TxtBus_Lote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Lote.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Lote.Text) > 0 Then
                TxtBus_Lote.Text = Strings.Right(Val(TxtBus_Lote.Text) + 10000000, 7)
                Call Mostrar_Comis(" and c_nro_comis='" & TxtBus_Lote.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_Lote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Lote.TextChanged

    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If BtnEstado.Text = "ANULADO" Then
            MsgBox(" Registro se encuentra Anulado, no podra realizar ninguna modificación...", vbCritical, Compañia)
        Else
            BtnMostrar.Enabled = True : Call Nuevo_Registro()
        End If
    End Sub
    ' Validamos si Registro se Encuetra Anulado... '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If UCase(BtnEstado.Text) = "PENDIENTE" Then
            Dim F As String = MsgBox("¿Confirma la Anulación del Registro?", vbExclamation + vbYesNo, Compañia)
            If F = vbYes Then
                Call Grabar_ComisCab("DEL")
                With Dgv01
                    For I = 0 To .RowCount - 1
                        Call Grabar_ComisDet(I, "DEL")
                    Next
                End With
                MsgBox("Registro se anulo correctamente...", vbExclamation, Compañia)
                BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
            End If
        Else
            MsgBox("Registro se encuentra Anulado o Cerrado no podra realizar ninguna modificación...", vbYesNo + vbCritical, Compañia)
        End If
    End Sub
    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            TxtRuta.Text = Folder01.SelectedPath
        End If
    End Sub
    ' Abrimos '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Registro_Comisiones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Registro_Comisiones.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan04, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Imprimimos Reportes '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        'FrmReportes.Reporte_Comision(" Reporte de Comisiones de Vendedores Del : " & DtpFec_Inicio.Text & " Al : " & DtpFec_Final.Text, TxtNro_Comis.Text)
        FrmComisReportes.Show() : FrmComisReportes.MdiParent = FrmMenu
        FrmComisReportes.TxtNro_Comision.Text = TxtNro_Comis.Text
        FrmComisReportes.TxtImp_Mn.Text = Val(TxtTot_01.Text)
        FrmComisReportes.TxtImp_Us.Text = Val(TxtTot_02.Text)
        FrmComisReportes.TxtComis_Mn.Text = Val(TxtTot_05.Text)
        FrmComisReportes.TxtComis_Us.Text = Val(TxtTot_06.Text)

    End Sub
    ' Imprimimos Comisiones '
    Private Sub LnkImprimir_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkImprimir.LinkClicked
        If BtnImp.Enabled = True Then Call BtnImp_Click(Nothing, Nothing)
    End Sub

    Private Sub LnkAnexar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAnexar.LinkClicked
        FrmComisAnexos.MdiParent = FrmMenu : FrmComisAnexos.Show() : FrmComisAnexos.TxtNro_Comis.Text = TxtNro_Comis.Text
        FrmComisAnexos.TxtMonto.Text = Strings.Replace(TxtTot_06.Text, ",", "")
    End Sub

    Private Sub LnkDocAnexos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDocAnexos.LinkClicked
        FrmConComisDocs.MdiParent = FrmMenu : FrmConComisDocs.Show()
        FrmConComisDocs.Cargar_Grid(" and C.c_nro_comis='" & TxtNro_Comis.Text & "' ", "DGV")
        FrmConComisDocs.TxtNro_Comis.Text = TxtNro_Comis.Text
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

    End Sub

    Private Sub LnkPorc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkPorc.LinkClicked
        Dim Porc As String = ""
        If LnkPorc.Enabled = True Then
            Porc = InputBox("Ingrese el porcentaje de la Comisión para este documento", "Modificación de Comisión...", "0.000")
            If IsNumeric(Porc) = True Then
                With Dgv01
                    If .RowCount > 0 Then
                        Dim Fila As Integer = .CurrentCellAddress.Y
                        If Fila > -1 Then
                            Dim F As String = MsgBox("¿Desea grabar la nueva comisión?", vbYesNo + vbQuestion, Compañia)
                            If F = vbYes Then
                                Dim Total_Comi As Decimal = 0
                                Total_Comi = Format(Val(.Rows(Fila).Cells("Importe").Value) * Val(Porc), Forma_1_2)
                                .Rows(Fila).Cells("Comision").Value = Total_Comi
                                .Rows(Fila).Cells("c_porc_comis").Value = Format(Val(Porc), Forma_1_3)
                                Call Modificar_ComisDet(Fila, Val(Porc), "ADD")
                                Call Calcular_Totales()
                                ' Grabamos Cabecera '
                                Call Grabar_ComisCab("ADD")
                            End If
                        End If
                    End If
                End With
            Else
                MsgBox("Deberá ingresar un porcentaje valido....", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class