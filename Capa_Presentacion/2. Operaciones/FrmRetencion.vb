Public Class FrmRetencion
    Dim Anula As Integer = 0
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro() : Call BtnFin_Click(Nothing, Nothing) : Call Cancelar_Detalles()
            Pan13.Enabled = False : BtnAceptar.Enabled = False
        End If
    End Sub
    ' Metodo para Cancelar registro '
    Private Sub Cancelar_Registro()
        Call Limpiar_Texto(Pan05) : BtnCon1.Enabled = True : Pan01.Enabled = True : BtnGrabar.Enabled = False
        BtnCerrar.Text = "Cerrar" : BtnCon1.Enabled = False : Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : Pan12.Enabled = True
        TxtSerie.Enabled = False : BtnMostrar.Enabled = False : DtpFec_Prd.Enabled = False : TxtObs.Enabled = False
        DtpFec_Emi.Enabled = False
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        With FrmConClientes
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 2 : .Cargar_Grid(" order by c_desc_clie")
        End With
    End Sub
  
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : BtnCon1_Click(Nothing, Nothing) : Anula = 0 : Pan13.Enabled = True
        TxtRetencion.Enabled = True : TxtSerie.Enabled = True : BtnEstado.BackColor = Color.Maroon : BtnEstado.Text = "PENDIENTE"
        DtpFec_Emi.Text = Now.Date : TxtTc.Enabled = True : TxtSerie.Clear() : TxtRetencion.Clear()
        LblTot_Doc.Text = "" : LblTot_Reten.Text = "" : LblTotal.Text = "" : DtpFec_Prd.Text = Now.Date : DtpFec_Emi.Enabled = True
        TxtObs.Enabled = True : DtpFec_Emi.Enabled = True
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTc)
    End Sub
    ' Metodo para un nuevo registro '
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan05) : BtnCon1.Enabled = True : Pan01.Enabled = False : BtnGrabar.Enabled = True
        BtnCerrar.Text = "Cancelar" : LblTot_Doc.Text = "" : LblTot_Reten.Text = "" : LblTotal.Text = ""
        Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : TxtSerie.Enabled = True : Pan12.Enabled = False : BtnMostrar.Enabled = True
        TxtSerie.Enabled = True : TxtRetencion.Enabled = True : DtpFec_Prd.Enabled = True
    End Sub

    Private Sub FrmRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If BtnGrabar.Enabled = True Then If e.Control And e.KeyCode = Keys.G Then Call BtnGrabar_Click(Nothing, Nothing)
        If Pan01.Enabled = True Then If e.Control And e.KeyCode = Keys.N Then Call BtnNuevo_Click(Nothing, Nothing)
        If BtnImprimir.Enabled = True Then If e.Control And e.KeyCode = Keys.P Then Call BtnImprimir_Click(Nothing, Nothing)
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmRetencion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRetencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call BtnFin_Click(Nothing, Nothing)
    End Sub
    ' metodo para mostrar facturas
    Public Sub Mostrar_Documentos()
        With c_Neg_FactCab.get_FactCab_Datos(TxtCod_Clie.Text, "RET", TxtCod_Clie.Text)
            Dgv01.Rows.Clear()
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    If .Rows(i)("c_codi_doc").ToString = "01" Then
                        Dgv01.Rows(i).Cells("Tipo_Doc").Value = "Factura"
                    Else
                        Dgv01.Rows(i).Cells("Tipo_Doc").Value = "Nota Debito"
                    End If
                    Dgv01.Rows(i).Cells("Documento").Value = .Rows(i)("Nro.Factura").ToString
                    Dgv01.Rows(i).Cells("Nick").Value = .Rows(i)("_").ToString
                    Dgv01.Rows(i).Cells("Total").Value = Format(Val(.Rows(i)("Total").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("c_fecha_emi").Value = FormatDateTime(.Rows(i)("Fecha Emision").ToString, DateFormat.ShortDate)
                    Dgv01.Rows(i).Cells("c_opc_apertura").Value = Val(.Rows(i)("c_opc_apertura").ToString)
                    Dgv01.Rows(i).Cells("c_codi_doc2").Value = .Rows(i)("c_codi_doc").ToString
                Next
            End If
        End With
    End Sub
    ' Metodo para mostrar las retenciones '
    Public Sub Mostrar_Retenciones(ByVal Cadena As String)
        With c_Neg_RetenCab.get_RetenCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Cancelar_Registro()
            If .Rows.Count > 0 Then
                TxtBus.Text = .Rows(0)("c_nro_ing").ToString
                TxtNro_Ing.Text = .Rows(0)("c_nro_ing").ToString
                TxtSerie.Text = .Rows(0)("c_nro_serie").ToString
                TxtRetencion.Text = .Rows(0)("c_nro_reten").ToString
                CboClie.Text = .Rows(0)("c_Desc_clie").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                TxtCod_Clie.Text = .Rows(0)("c_Codi_clie").ToString
                TxtDir.Text = .Rows(0)("c_direc_reten").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Prd.Text = .Rows(0)("c_fecha_prd").ToString
                '''--> Anulamos registros <--'''
                If Val(.Rows(0)("c_anula_Reg").ToString) = 1 Then
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                Else
                    BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Color.Maroon
                End If
                ' Cargamos Detalles '
                With c_Neg_RetenDet.get_RetenDet_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        TxtTc.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                        For I = 0 To .Rows.Count - 1
                            ' Llenamos para las dos grid
                            ' Grid # 1 '
                            Dgv01.Rows.Add()
                            Dgv01.Rows(I).Cells("Tipo_doc").Value = .Rows(I)("c_desc_doc").ToString
                            Dgv01.Rows(I).Cells("Documento").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                            If .Rows(I)("c_codi_mon").ToString = "01" Then Dgv01.Rows(I).Cells("Nick").Value = "S/."
                            If .Rows(I)("c_codi_mon").ToString = "02" Then Dgv01.Rows(I).Cells("Nick").Value = "$."

                            Dgv01.Rows(I).Cells("Total").Value = .Rows(I)("c_imp_doc").ToString
                            Dgv01.Rows(I).Cells("c_opc_apertura").Value = Val(.Rows(I)("c_opc_apertura").ToString)
                            Dgv01.Rows(I).Cells("Chk").Value = True
                            Dgv01.Rows(I).Cells("c_fecha_emi").Value = FormatDateTime(.Rows(I)("c_fecha_doc").ToString, DateFormat.ShortDate)
                            ' Grid # 2 '
                            Dgv02.Rows.Add()
                            Dgv02.Rows(I).Cells("Tipo").Value = .Rows(I)("c_desc_doc").ToString
                            Dgv02.Rows(I).Cells("Factura").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                            Dgv02.Rows(I).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_doc").ToString, DateFormat.ShortDate)

                            Dgv02.Rows(I).Cells("Total_Doc").Value = .Rows(I)("c_imp_doc").ToString
                            Dgv02.Rows(I).Cells("Total_Reten").Value = .Rows(I)("c_imp_reten").ToString
                            Dgv02.Rows(I).Cells("Item").Value = .Rows(I)("c_nro_correl").ToString
                            Dgv02.Rows(I).Cells("c_nro_ing").Value = .Rows(I)("c_nro_ing").ToString
                            Dgv02.Rows(I).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                            Dgv02.Rows(I).Cells("c_codi_doc").Value = .Rows(I)("c_codi_doc").ToString
                            Dgv02.Rows(I).Cells("c_opc_apertura_2").Value = Val(.Rows(I)("c_opc_apertura").ToString)
                        Next
                    End If
                End With
                LblTot_Reten.Text = Format(Val(.Rows(0)("c_total_reten").ToString), Forma_2_2)
                LblTot_Doc.Text = Format(Val(.Rows(0)("c_total_doc").ToString), Forma_2_2)
                LblLetras.Text = .Rows(0)("c_letras_Reten").ToString
                ' Total de Documentos '
                LblTotal.Text = Dgv02.RowCount
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Cargamos Registro '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        With Dgv01
            If Val(TxtTc.Text) > 0 Then
                Dgv02.Rows.Clear()
                Dgv02.ReadOnly = False
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells("Chk").Value = True Then
                        Call Cargar_Detalles(Strings.Left(.Rows(i).Cells("Documento").Value, 4), Strings.Right(.Rows(i).Cells("Documento").Value, 7),
                        .Rows(i).Cells("c_codi_doc2").Value)
                    End If
                Next
                For i = 0 To 3
                    Dgv02.Columns(i).ReadOnly = True
                Next
                Call Calcular_Totales()
            Else
                MsgBox("Debe ingresar el tipo de cambio...", vbCritical, Compañia)
            End If
        End With
    End Sub
    ' Metodo para Cargar Registros '
    Private Sub Cargar_Detalles(ByVal c_serie_doc As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String)
        If c_codi_doc = "01" Then
            With c_Neg_FactCab.get_FactCab_Datos(" and F.c_nro_serie='" & c_serie_doc & "' and F.c_nro_factura='" & c_nro_doc & "' ", "DET",
                                                 " and F.c_nro_serie='" & c_serie_doc & "' and F.c_nro_doc='" & c_nro_doc & "' ")
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgv02.Rows.Add()
                        Dim Fila As Integer = Dgv02.RowCount - 1
                        Dgv02.Rows(Fila).Cells("Tipo").Value = "FACTURA"
                        Dgv02.Rows(Fila).Cells("Factura").Value = .Rows(I)("c_nro_serie").ToString & " " & .Rows(I)("c_nro_factura").ToString
                        Dgv02.Rows(Fila).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)
                        ' validamos el tipo de moneda '
                        If .Rows(I)("c_codi_mon").ToString = "02" Then
                            Dgv02.Rows(Fila).Cells("Total_Doc").Value = Format(Val(.Rows(I)("c_total_fact").ToString) * Val(TxtTc.Text), Forma_1_2)
                        Else
                            Dgv02.Rows(Fila).Cells("Total_Doc").Value = Format(Val(.Rows(I)("c_total_fact").ToString), Forma_1_2)
                        End If
                        Dgv02.Rows(Fila).Cells("Total_Reten").Value = Format(Val(Dgv02.Rows(Fila).Cells("Total_Doc").Value) * 0.03, Forma_1_2)
                        Dgv02.Rows(Fila).Cells("Item").Value = ""
                        Dgv02.Rows(Fila).Cells("c_opc_apertura_2").Value = Val(.Rows(I)("c_opc_apertura").ToString)
                        Dgv02.Rows(Fila).Cells("c_codi_doc").Value = "01"
                        Dgv02.Rows(Fila).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                    Next
                Else
                    MsgBox("1. No existen registros disponibles, revisar...", vbCritical, Compañia)
                End If
            End With
        End If
        ' Nota Debito '
        If c_codi_doc = "04" Then
            With c_Neg_NotaD.get_NotaD_Datos(" and N.c_nro_serie='" & c_serie_doc & "' and N.c_nro_nd='" & c_nro_doc & "' ", "DAT", " ")
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgv02.Rows.Add()
                        Dim Fila As Integer = Dgv02.RowCount - 1
                        Dgv02.Rows(Fila).Cells("Tipo").Value = "NOTA DEBITO"
                        Dgv02.Rows(Fila).Cells("Factura").Value = .Rows(I)("c_nro_serie").ToString & " " & .Rows(I)("c_nro_ND").ToString
                        Dgv02.Rows(Fila).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)
                        ' validamos el tipo de moneda '
                        If .Rows(I)("c_codi_mon").ToString = "02" Then
                            Dgv02.Rows(Fila).Cells("Total_Doc").Value = Format(Val(.Rows(I)("c_imp_total").ToString) * Val(TxtTc.Text), Forma_1_2)
                        Else
                            Dgv02.Rows(Fila).Cells("Total_Doc").Value = Format(Val(.Rows(I)("c_imp_total").ToString), Forma_1_2)
                        End If
                        Dgv02.Rows(Fila).Cells("Total_Reten").Value = Format(Val(Dgv02.Rows(Fila).Cells("Total_Doc").Value) * 0.03, Forma_1_2)
                        Dgv02.Rows(Fila).Cells("Item").Value = ""
                        Dgv02.Rows(Fila).Cells("c_opc_apertura_2").Value = 0
                        Dgv02.Rows(Fila).Cells("c_codi_doc").Value = "04"
                        Dgv02.Rows(Fila).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                    Next
                Else
                    MsgBox("2. No existen registros disponibles, revisar...", vbCritical, Compañia)
                End If
            End With
        End If
    End Sub
    ' Metodo para calcular los totales '
    Private Sub Calcular_Totales()
        With Dgv02
            Dim Tot_Reten As Decimal = 0 : Dim Tot_Doc As Decimal = 0
            For I = 0 To .RowCount - 1
                Tot_Reten = Tot_Reten + Val(.Rows(I).Cells("Total_Reten").Value)
                Tot_Doc = Tot_Doc + Val(.Rows(I).Cells("Total_doc").Value)
            Next
            '--> Totales de Retenciones <--'
            LblTotal.Text = Dgv02.RowCount
            LblTot_Doc.Text = Format(Tot_Doc, Forma_2_2)
            LblTot_Reten.Text = Format(Tot_Reten, Forma_1_2)

            LblLetras.Text = StrConv(num2text(Mid(LblTot_Reten.Text, 1, Len(LblTot_Reten.Text) - 3)) & " Y " & Strings.Right(LblTot_Reten.Text, 2) & "/100 NUEVOS SOLES", VbStrConv.Uppercase)
        End With
    End Sub
    Private Function ValidarDatos() As Boolean
        If Len(TxtCod_Clie.Text) > 0 Then
            If Len(TxtSerie.Text) > 0 And Len(TxtRetencion.Text) > 0 Then
                ValidarDatos = True
            Else
                ValidarDatos = False
                MsgBox(" 1. Falta ingresar el número de retención...", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox(" 2. Falta Seleccionar el Proveedor...", vbCritical, Compañia)
        End If
    End Function
    ' Grabar Retencion '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Call Calcular_Totales()
        If ValidarDatos() = True Then
            Dim x As Integer = 0
            If Dgv02.RowCount = 0 Then
                Dim S As String = MsgBox("¿ No existen registros desea grabar ?", vbYesNo + vbCritical, Compañia)
                If S = vbNo Then x = 1
            End If
            If x = 0 Then
                Dim F As String = MsgBox("¿  Desea Grabar la Retención  ?", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    Call Grabar_Retencion("ADD")
                    With Dgv02
                        For I = 0 To .RowCount - 1
                            Call Grabar_Retencion_Det(I, "ADD")
                        Next
                    End With
                    MsgBox(" Registro se Grabo Correctamente... ", vbExclamation, Compañia)
                    Pan13.Enabled = False : BtnAceptar.Enabled = False
                    If Len(TxtNro_Ing.Text) > 0 Then
                        Call Mostrar_Retenciones(" and R.c_nro_ing='" & TxtNro_Ing.Text & "'")
                                            Else
                        BtnFin_Click(Nothing, Nothing)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_Retencion(ByVal cOpcion As String)
        With c_Ent_RetenCab
            .c_nro_ing = TxtNro_Ing.Text
            .c_nro_serie = TxtSerie.Text
            .c_nro_reten = TxtRetencion.Text
            .c_direc_reten = TxtDir.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_prd = DtpFec_Prd.Text
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_mon = "01"
            .c_total_doc = Val(Replace(LblTot_Doc.Text, ",", ""))
            .c_total_reten = Val(Replace(LblTot_Reten.Text, ",", ""))
            .c_letras_reten = LblLetras.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtNro_Ing.Text) = 0 Then
                TxtNro_Ing.Text = c_Neg_RetenCab.set_RetenCab_Save(c_Ent_RetenCab, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_RetenCab.set_RetenCab_Save(c_Ent_RetenCab, FrmMenu.TxtCod_Emp.Text)
            End If

        End With
    End Sub
    ' Metodo para Grabar el Detalle de la Retencion '
    Private Sub Grabar_Retencion_Det(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_RetenDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_ing = TxtNro_Ing.Text
            .c_fecha_doc = Dgv02.Rows(Fila).Cells("Fecha").Value
            .c_codi_doc = Dgv02.Rows(Fila).Cells("c_Codi_doc").Value
            .c_serie_doc = Strings.Left(Dgv02.Rows(Fila).Cells("Factura").Value, 4)
            .c_nro_doc = Strings.Right(Dgv02.Rows(Fila).Cells("Factura").Value, 7)
            .c_codi_mon = Dgv02.Rows(Fila).Cells("c_codi_mon").Value
            .c_tpo_cambio = Val(TxtTc.Text)
            .c_imp_doc = Val(Dgv02.Rows(Fila).Cells("Total_Doc").Value)
            .c_imp_reten = Val(Dgv02.Rows(Fila).Cells("Total_Reten").Value)
            .c_opc_apertura = Val(Dgv02.Rows(Fila).Cells("c_opc_apertura_2").Value)
            .copcion = cOpcion
            Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_RetenDet.set_RetenDet_Save(c_Ent_RetenDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        If BtnEstado.Text = "ANULADO" Then
            MsgBox("Registro se encuentra Anulado, no puede ser eliminado...", vbCritical, Compañia)
        Else
            Dim F As String = MsgBox("  ¿  Confirma la eliminación de la Retención  ?  ", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Anula = 1
                Call Grabar_Retencion("DEL")
                With Dgv02
                    For i = 0 To .RowCount - 1
                        Call Grabar_Retencion_Det(i, "DEL")
                    Next
                End With
                MsgBox(" Registro se Elimino Correctamente... ", vbCritical, Compañia)
                Call Cancelar_Registro()
                Call Mostrar_Retenciones(" and c_nro_ing='" & TxtBus.Text & "' ")
                Anula = 0
            End If
        End If
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnAva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
    ' Listado de Retenciones '
    Private Sub LnkConFact_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkConFact.LinkClicked
        FrmRetenConsul.MdiParent = FrmMenu : FrmRetenConsul.Show() : FrmRetenConsul.Mostrar_Retenciones()
    End Sub

    Private Sub TxtDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDir.TextChanged

    End Sub
    ' Imprimir Retencion '
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        'FrmReportes.Imprimir_Retencion(" And D.c_nro_serie='" & CboSerie.Text & "' and D.c_nro_reten='" & TxtRetencion.Text & "' ", CboSerie.Text, TxtRetencion.Text, LblTot_Doc.Text, LblTot_Reten.Text)
    End Sub
    Private Sub Dgv02_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick
        Call Calcular_Totales()
    End Sub

    Private Sub Dgv02_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles Dgv02.CurrentCellDirtyStateChanged
        If Dgv01.IsCurrentCellDirty Then
            Dgv01.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Dgv02_SelectionChanged(sender As Object, e As System.EventArgs) Handles Dgv02.SelectionChanged
        Call Calcular_Totales()
    End Sub
    ' Final de Comisiones '
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Retenciones(" and R.c_nro_ing= (select max(c_nro_ing) from Sca_FA_RetenCab)")
    End Sub

    Private Sub BtnIni_Click(sender As System.Object, e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Retenciones(" and R.c_nro_ing= (select min(c_nro_ing) from Sca_Fa_RetenCab)")
    End Sub
    ' Hacia atras '
    Private Sub BtnAtr_Click(sender As System.Object, e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 1 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 10000000, 7)
            Call Mostrar_Retenciones(" and R.c_nro_ing='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(sender As System.Object, e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 100000001, 7)
            Call Mostrar_Retenciones(" and R.c_nro_ing='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub TxtBus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 10000000, 7)
                Call Mostrar_Retenciones(" and R.c_nro_ing='" & TxtBus.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub

    Private Sub TxtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles TxtSerie.LostFocus
        If Val(TxtSerie.Text) > 0 Then
            TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtRetencion_LostFocus(sender As Object, e As System.EventArgs) Handles TxtRetencion.LostFocus
        If Val(TxtRetencion.Text) > 0 Then
            TxtRetencion.Text = Strings.Right(Val(TxtRetencion.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtRetencion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtRetencion.TextChanged

    End Sub
    ' Editamos registro '
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        If UCase(BtnEstado.Text) = "ANULADO" Then
            MsgBox("Retención se encuentra anulada no podra realizar ninguna modificación...", vbCritical, Compañia)
        Else
            Anula = 0
            TxtRetencion.Enabled = True : TxtSerie.Enabled = True : BtnEstado.BackColor = Color.Maroon : BtnEstado.Text = "PENDIENTE"
            DtpFec_Emi.Enabled = False : TxtTc.Enabled = False : Pan01.Enabled = False : BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True
            DtpFec_Prd.Enabled = True : Pan13.Enabled = True
            For i = 0 To 3
                Dgv02.Columns(i).ReadOnly = True
            Next
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Call Nuevo_Detalles()
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    TxtTpo_Doc.Text = .Rows(Fila).Cells("Tipo").Value
                    TxtNro_Docu.Text = .Rows(Fila).Cells("Factura").Value
                    TxtFecha_Emi.Text = .Rows(Fila).Cells("Fecha").Value
                    TxtTotal.Text = Format(Val(.Rows(Fila).Cells("Total_Doc").Value), Forma_1_2)
                    TxtTot_Reten.Text = Format(Val(.Rows(Fila).Cells("Total_Reten").Value), Forma_1_2)
                End If
            End If
        End With
    End Sub
    ' Metodo para nuevo detalles '
    Private Sub Nuevo_Detalles()
        With Dgv02
            .Location = New Point(338, 48) : .Size = New Size(559, 152)
            Call Limpiar_Texto(Pan07) : TxtTotal.Enabled = True : TxtTot_Reten.Enabled = True
            TxtTotal.Focus() : .Enabled = False : BtnAceptar.Enabled = True
        End With
    End Sub
    ' Metodo para cancelar detalles '
    Private Sub Cancelar_Detalles()
        With Dgv02
            .Location = New Point(338, 22) : .Size = New Size(559, 178)
            Call Limpiar_Texto(Pan07) : Call Desactivar(Pan07) : .Enabled = True
        End With
    End Sub

    Private Sub TxtTot_Reten_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTot_Reten.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtTot_Reten_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTot_Reten.TextChanged

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    .Rows(Fila).Cells("Total_Doc").Value = Format(Val(TxtTotal.Text), Forma_1_2)
                    .Rows(Fila).Cells("Total_Reten").Value = Format(Val(TxtTot_Reten.Text), Forma_1_2)
                    Call Cancelar_Detalles() : Call Calcular_Totales()
                End If
            End If
        End With
    End Sub

    Private Sub BtnCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel2.Click
        Call Cancelar_Detalles()
    End Sub

    Private Sub LnkHistoAnexos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistoAnexos.LinkClicked

    End Sub

    Private Sub DtpFec_Emi_ValueChanged(sender As Object, e As EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTc)
    End Sub
End Class
