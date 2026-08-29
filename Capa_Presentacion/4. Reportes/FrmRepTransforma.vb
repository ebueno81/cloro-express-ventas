Public Class FrmRepTransforma
    Dim c_codi_articulo As String = "" : Dim x As Integer = 0
    Private Sub FrmRepTransforma_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If ValidarCierre(DtpFec_Inicio.Text) = True Then
                If CboMon.SelectedValue = "02" Then
                    Call Actualizar_Precios()
                    Call Actualizar_Masivo()
                    Call Calcular_Totales()
                    With Dgv01
                        Dim f As String = MsgBox("¿Desea grabar registro?", vbYesNo + vbQuestion, Compañia)
                        If f = vbYes Then
                            For i = 0 To .RowCount - 1
                                Call Grabar_Transforma_DetSal(i, "ADD")
                            Next
                            MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                        End If
                    End With
                Else
                    MsgBox("Para realizar esta operaccion debe seleccionar la moneda Dolares $.", vbCritical, Compañia)
                End If
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            Dim f As String = MsgBox("¿Desea registrar el agua...?", vbYesNo + vbQuestion, Compañia)
            If f = vbYes Then
                ' desabilitamos hasta que haya pozo '
                ' Call Insertar_Agua()
                MsgBox("Registro se grabo correctamente....")
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            '  Dim f As String = MsgBox("¿Desea actualizar el coeficiente de las transformaciones...?", vbYesNo + vbQuestion, Compañia)
            ' If f = vbYes Then
            'Call ActualizarCantidadCoeficiente()
            'End If
        End If
    End Sub
    Private Sub ActualizarCantidadCoeficiente()
        With Dgv01
            Dim Transforma As String = "" : Dim x As Integer = 0
            Dim TotUs As Decimal = 0
            If .RowCount > 0 Then
                Dim y As String = InputBox("Actualizacion de Coeficiente", "Ingrese el coeficiente para realizar la actualizacion")
                If Val(y) > 0 Then
                    For i = 0 To .RowCount - 1
                        Transforma = .Rows(i).Cells("Nro.Transforma").Value
                        If Val(.Rows(i).Cells("Ingreso").Value.ToString) > 0 Then
                            c_Neg_AlmTransforDet.set_AlmTransforDetCoeficiente_Save(Transforma, Val(y))
                        End If
                    Next
                    MsgBox("Se actualizo las salidas por coeficiente...", vbExclamation, Compañia)
                End If
            End If
        End With
    End Sub

    Private Sub Insertar_Agua()
        With Dgv01
            Dim Transforma As String = ""
            For i = 0 To .RowCount - 1
                'Transforma = .Rows(i).Cells("Nro.Transforma").Value
                If Val(.Rows(i).Cells("Ingreso").Value.ToString) > 0 Then
                    Call Grabar_Transforma_IngresoAgua(i, "ADD")
                End If
            Next
        End With
    End Sub
    Private Sub Actualizar_Precios()
        With Dgv01
            Dim Transforma As String = ""
            For i = 0 To .RowCount - 1
                'Transforma = .Rows(i).Cells("Nro.Transforma").Value
                If Val(.Rows(i).Cells("Ingreso").Value.ToString) > 0 Then

                Else
                    With c_Neg_MnArticulo.get_Articulo_Datos(" And K.c_anula_reg=0 AND K.c_codi_articulo='" & .Rows(i).Cells("Codigo").Value &
                                                         "' and K.c_fecha_kdx<='" & .Rows(i).Cells("Fecha").Value & "' order by c_fecha_kdx desc", "ULT")
                        If .Rows.Count > 0 Then
                            ' Validate if agua
                            If Val(.Rows(0)("c_opc_agua").ToString) = 1 Then
                                If .Rows(0)("c_codi_mon") = "02" Then
                                    Dgv01.Rows(i).Cells("Precio").Value = Format(Val(.Rows(0)("c_precio_art").ToString), Forma_1_6)
                                Else
                                    Dim TpoCambio As Decimal = 0
                                    With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo<='" & Dgv01.Rows(i).Cells("Fecha").Value & "' order by c_fecha_cbo desc", "ACT")
                                        If .Rows.Count > 0 Then
                                            TpoCambio = Val(.Rows(0)("c_venta_sunat").ToString)
                                        End If
                                    End With
                                    Dgv01.Rows(i).Cells("Precio").Value = Format(Val(.Rows(0)("c_precio_art").ToString) / TpoCambio, Forma_1_6)
                                End If
                            Else
                                Dgv01.Rows(i).Cells("Precio").Value = Format(Val(.Rows(0)("c_prec_prom").ToString), Forma_1_6)
                            End If
                            Dgv01.Rows(i).Cells("Total").Value = Format(Val(Dgv01.Rows(i).Cells("Precio").Value.ToString) * Val(Dgv01.Rows(i).Cells("Salida").Value.ToString), Forma_1_2)
                        Else
                            Dgv01.Rows(i).Cells("Precio").Value = "0.00"
                            Dgv01.Rows(i).Cells("Total").Value = "0.00"
                        End If
                    End With
                End If
            Next
        End With
    End Sub
    Private Sub Actualizar_Masivo()
        With Dgv01
            Dim Transforma As String = "" : Dim x As Integer = 0
            Dim TotUs As Decimal = 0
            For i = 0 To .RowCount - 1
                Transforma = .Rows(i).Cells("Nro.Transforma").Value
                If Val(.Rows(i).Cells("Ingreso").Value.ToString) > 0 Then
                    If i > 0 Then
                        If Transforma = .Rows(i - 1).Cells("Nro.Transforma").Value Then
                            .Rows(i).Cells("Total").Value = Format(TotUs, Forma_1_2)
                            .Rows(i).Cells("Precio").Value = Format(TotUs / Val(.Rows(i).Cells("Ingreso").Value), Forma_1_6)
                            TotUs = 0
                        End If
                    End If
                Else
                    If i = 0 Then
                        TotUs = Val(.Rows(i).Cells("Total").Value)
                    Else
                        If Transforma = .Rows(i - 1).Cells("Nro.Transforma").Value Then
                            TotUs = TotUs + Val(.Rows(i).Cells("Total").Value)
                        Else
                            TotUs = Val(.Rows(i).Cells("Total").Value)
                        End If
                    End If
                End If
            Next
        End With
    End Sub
    ' Grabamos Detalles de Salida por Transformación '
    Private Sub Grabar_Transforma_DetSal(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_AlmTransforDet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("c_nro_correl").Value
            .c_nro_transforma = Dgv01.Rows(Fila).Cells("Nro.Transforma").Value
            If Val(Dgv01.Rows(Fila).Cells("Ingreso").Value.ToString) > 0 Then
                .c_tpo_mov = "ING"
            Else
                .c_tpo_mov = "SAL"
            End If
            .c_codi_articulo = Dgv01.Rows(Fila).Cells("Codigo").Value
            .c_codi_mon = Dgv01.Rows(Fila).Cells("M").Value
            .c_codi_unimed = "001"
            If Val(Dgv01.Rows(Fila).Cells("Ingreso").Value.ToString) > 0 Then
                .c_nro_cant = Val(Dgv01.Rows(Fila).Cells("Ingreso").Value)
            Else
                .c_nro_cant = Val(Dgv01.Rows(Fila).Cells("Salida").Value.ToString)
            End If
            .c_prec_unit = Val(Dgv01.Rows(Fila).Cells("Precio").Value)
            .c_imp_total = Val(Dgv01.Rows(Fila).Cells("Total").Value)
            .c_opc_transespecial = 0
            .copcion = cOpcion
            c_Neg_AlmTransforDet.set_AlmTransforDet_Save(c_Ent_AlmTransforDet)
        End With
    End Sub
    ' Grabamos Detalles de ingreso de agua por Transformación '
    Private Sub Grabar_Transforma_IngresoAgua(ByVal Fila As Integer, ByVal cOpcion As String)
        ' Validamos cuanto es la diferencia para ingresar el agua '
        Dim diferencia As Decimal = 0
        With c_Neg_AlmTransforDet.get_AlmTransforDet_Datos(Dgv01.Rows(Fila).Cells("Nro.Transforma").Value, "DIF")
            If .Rows.Count > 0 Then
                diferencia = Val(.Rows(0)("Diferencia").ToString)
            End If
        End With
        If diferencia > 0 Then
            With c_Ent_AlmTransforDet
                .c_nro_correl = ""
                .c_nro_transforma = Dgv01.Rows(Fila).Cells("Nro.Transforma").Value
                .c_tpo_mov = "SAL"
                .c_codi_articulo = "12000001"
                .c_codi_mon = "02"
                .c_codi_unimed = "001"
                .c_nro_cant = diferencia
                .c_prec_unit = 0.002482
                .c_imp_total = 0.002482 * diferencia
                .copcion = cOpcion
                c_Neg_AlmTransforDet.set_AlmTransforDet_Save(c_Ent_AlmTransforDet)
            End With
        End If
    End Sub

    Private Sub FrmRepTransforma_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRepTransforma_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnMonedas.Get_Moneda_Cbo(" and c_anula_reg=0 ", CboMon)
        CboAlm.SelectedIndex = 0 : CboMon.SelectedIndex = 0
        TxtCod_Tg.Text = "01"
        TxtTg.Text = "MERCADERIAS"
        TxtCod_Cd.Text = "01"
        TxtCd.Text = "INSUMOS QUIMICOS"
    End Sub

    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click

        If CboMon.SelectedValue = "01" Then
            Call Cargar_Grid("DGS")
        Else
            Call Cargar_Grid("DGV")
        End If
    End Sub
    ' METODO PARA CONFIGURAR GRID
    Public Sub Cargar_Grid(ByVal vOpt As String)
        With Dgv01
            'Sp_Scal_Rpt_TransforDet
            .DataSource = c_Neg_AlmTransforDet.get_AlmTransforDet_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Tg.Text, TxtCod_Cd.Text, Txtcod_Articulo.Text, TxtCod_Alm.Text, vOpt)
            .Columns("Nro.Transforma").Width = 85
            .Columns("Fecha").Width = 70
            .Columns("Tc").Width = 45
            .Columns("Codigo").Width = 60
            .Columns("Articulo").Width = 220
            .Columns("Unid.").Width = 40
            .Columns("Ingreso").Width = 70
            .Columns("Salida").Width = 70
            .Columns("M").Width = 35
            .Columns("Precio").Width = 70
            .Columns("Total").Width = 60

            .Columns("Observacion").Visible = False
            .Columns("c_nro_correl").Visible = False

            ' Alineacion
            .Columns("Nro.Transforma").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Unid.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("M").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' visible 
            If FrmMenu.ChkUsuaPrecio.Checked = False Then
                .Columns("Precio").Visible = False
                .Columns("Total").Visible = False
            End If
            ' calcular totales
            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' metodo para calcular totales
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            For i = 0 To .RowCount - 1
                Tot_2 = Tot_2 + Val(.Rows(i).Cells("Salida").Value.ToString)
                Tot_4 = Tot_4 + Val(.Rows(i).Cells("Ingreso").Value.ToString)
                Tot_6 = Tot_6 + Val(.Rows(i).Cells("Total").Value.ToString)
            Next
            TxtTot_Ing.Text = Format(Val(Tot_4), Forma_2_2)
            TxtTot_Sal.Text = Format(Val(Tot_2), Forma_2_2)
            TxtTotal.Text = Format(Val(Tot_6), Forma_2_2)
            txtnick.text = CboMon.Text
            TxtConta_2.Text = .RowCount
        End With

    End Sub
    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
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
    ' Coloreamos si registro se encuentra anulado '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        'Call Grid_Registros_anulados(Dgv01)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Abrimos ruta de archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Transformaciones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Transformaciones.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros de Boletas '
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
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub CboBusArticulo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboAlm_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboAlm.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboAlm_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboAlm.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboAlm, TxtCod_Alm)
    End Sub

    Private Sub BtnImp_Click(sender As System.Object, e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = "Reporte de Salidas por Transformación DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        FrmReportes.Reporte_Transformaciones(Titulo, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Tg.Text, TxtCod_Cd.Text,
                                             Txtcod_Articulo.Text, TxtCod_Alm.Text, "DGV")
    End Sub

    ' Buscamos por tabla general '
    Private Sub BtnConTg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConTg.Click
        FrmConTg.MdiParent = FrmMenu : FrmConTg.Show() : FrmConTg.TxtVar.Text = 1 : FrmConTg.Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
    End Sub
    ' Buscamos por Caidas '
    Private Sub BtnConCd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConCd.Click
        FrmConCd.MdiParent = FrmMenu : FrmConCd.Show() : FrmConCd.TxtVar.Text = 1 : FrmConCd.TxtCod_Tg.Text = TxtCod_Tg.Text
        FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_Desc_cd")
    End Sub

    Private Sub BtnConScd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConScd.Click
        FrmConScd.MdiParent = FrmMenu : FrmConScd.Show() : FrmConScd.TxtVar.Text = 1 : FrmConScd.TxtCod_Tg.Text = TxtCod_Tg.Text
        FrmConScd.TxtCod_Cd.Text = TxtCod_Cd.Text
        FrmConScd.Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
    End Sub

    Private Sub TxtCod_Tg_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Tg.TextChanged

    End Sub

    Private Sub TxtCod_Tg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Tg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Tg.Text) > 0 Then
                TxtCod_Tg.Text = Strings.Right(Val(TxtCod_Tg.Text) + 100, 2)
                With c_Neg_MnTblGral.get_TblGral_Datos(" and c_Anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                        x = 1 : TxtCod_Cd.Focus()
                    Else
                        TxtTg.Clear()
                    End If
                End With
            Else
                TxtTg.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Cd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Cd.TextChanged

    End Sub

    Private Sub TxtCod_Cd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Cd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Cd.Text) > 0 Then
                TxtCod_Cd.Text = Strings.Right(Val(TxtCod_Cd.Text) + 100, 2)
                With c_Neg_MnCaidas.get_Caidas_Datos(" and C.c_Anula_reg=0 and C.c_codi_tg='" & TxtCod_Tg.Text & "' and C.c_codi_cd='" & TxtCod_Cd.Text & "' ", "DAT")
                    If .Rows.Count > 0 Then
                        TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                        x = 1 : TxtCod_Scd.Focus()
                    Else
                        TxtCd.Clear()
                    End If
                End With
            Else
                TxtCd.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Scd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Scd.TextChanged

    End Sub

    Private Sub TxtCod_Scd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Scd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Scd.Text) > 0 Then
                TxtCod_Scd.Text = Strings.Right(Val(TxtCod_Scd.Text) + 10000, 4)
                With c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_Anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_codi_scd='" & TxtCod_Scd.Text & "' ", "DAT")
                    If .Rows.Count > 0 Then
                        TxtScd.Text = .Rows(0)("c_desc_scd").ToString
                        x = 1 : BtnMostrar.Focus()
                    Else
                        TxtScd.Clear()
                    End If
                End With
            Else
                TxtScd.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Cd_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_Cd.LostFocus
        If x = 1 Then
            x = 0 : TxtCod_Cd.Focus()
        End If
    End Sub

    Private Sub TxtCod_Scd_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_Scd.LostFocus
        If x = 1 Then
            x = 0 : TxtCod_Scd.Focus()
        End If
    End Sub

    Private Sub BtnMostrar_LostFocus(sender As Object, e As EventArgs) Handles BtnMostrar.LostFocus
        If x = 1 Then
            x = 0 : BtnMostrar.Focus()
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class