Public Class FrmFacturas
    Dim Grabar As Integer = 0 ' Validamos si grabamos o editamos '
    Dim Focos As Integer = 0
    Private Sub FrmFactVtaMos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        'If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.P Then If BtnImprimir.Enabled = True Then Call BtnImprimir_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then
            Call Mostrar_IGV(DtpFec_Emi.Text, TxtCant_IGV)
            Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
        End If
        ' Volver a Generar la facturacion electronica '
        If e.KeyCode = Keys.F8 And BtnGrabar.Enabled = False Then
            Dim F As String = MsgBox("¿Desea volver a generar la Facturacion electronica?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtFactura.Text, "01", "ADD")
                If ValidarEnvio(CboSerie.Text, TxtFactura.Text, "01", 1) = True Then
                    MsgBox("Registro se subio correctamente revisarlo...", vbExclamation, Compañia)
                End If
            End If
        End If
        ' Registramos las cuotas de la factura '
        If e.KeyCode = Keys.F2 Then
            If BtnGrabar.Enabled = False Then
                If ValidarCouta("01", CboSerie.Text, TxtFactura.Text, 1) = True Then
                    Call RegistrarCoutas("01", CboSerie.Text, TxtFactura.Text, Val(LblTotales.Text), CboMon.SelectedValue)
                End If
            End If
        End If
    End Sub 'Variable que nos permite validar si se graba o modifica registro...

    'Avanzamos al presionar la tecla enter...
    Private Sub FrmFactVtaMos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmFactVtaMos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" ", CboMon) : CboMon.SelectedIndex = -1
        Call DtpFec_Emi_ValueChanged(Nothing, Nothing)
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='01' AND C_anula_reg=0 order by c_nro_serie", CboBus_Serie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='01' AND C_anula_reg=0 order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnCliente.Get_Clientes_Cbo(" And c_anula_reg=0 order by c_desc_clie", CboClie)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende ", CboVende)
        c_Neg_MnTpoPago.Get_Fpago_Cbo(" and c_anula_reg=0 order by c_desc_pago", CboFPago)
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_desc_stletra", CboStatus)
        c_Neg_MnBcos.Get_Bcos_Cbo(" and c_anula_reg=0 order by c_desc_bco ", CboBco)
        If CboBus_Serie.Items.Count > 0 Then CboBus_Serie.SelectedIndex = 0 : CboBus_Serie.SelectedValue = FrmMenu.TxtSerie_Fact.Text
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        If DtpFec_Emi.Enabled = True Then
            Call Mostrar_IGV(DtpFec_Emi.Text, TxtCant_IGV)
            Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
            DtpFec_Vcto.Text = DtpFec_Emi.Text
        End If
    End Sub
    ' Afecto a Detraccion '
    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged
        If Rdb01.Checked = True And BtnGrabar.Enabled = True Then
            txtCodigoDetraccion.Clear()
            txtCodigoDetraccion.Enabled = True
            txtCodigoDetraccion.Focus()
        End If
    End Sub

    Private Sub Rdb02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb02.CheckedChanged
        If Rdb02.Checked = True Then
            TxtDetrac.Enabled = False : TxtDetrac.Clear() : txtCodigoDetraccion.Clear()
        End If
    End Sub
    ' Consultar Clientes '
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        If Dgv02.RowCount = 0 Then
            FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
            FrmConClientes.TxtVar.Text = 4 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
        Else
            MsgBox(" ¡Elimine las Guías Seleccionadas, para cambiar el Cliente...!", vbExclamation, Compañia)
        End If
    End Sub
    ' Mostramos Guias no Facturadas '
    Public Sub Mostrar_GuiaR()
        With c_Neg_AlmSalTA.get_AlmSalTa_Datos(" AND S.c_codi_mt not in('16') And S.c_nro_serie not in ('100') And S.c_fact_guia=0 And S.c_codi_clie='" & TxtCod_Clie.Text & "' and S.c_anula_reg=0 ", "DAT", FrmMenu.TxtCod_Emp.Text)
            Dgv01.Rows.Clear() : Dgv01.ReadOnly = False
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(i).Cells("Guia").ReadOnly = True
                    Dgv01.Rows(i).Cells("total").ReadOnly = True
                    Dgv01.Rows(i).Cells("fecha").ReadOnly = True

                    Dgv01.Rows(i).Cells("c_nro_correl").Value = ""
                    Dgv01.Rows(i).Cells("c_nro_serie").Value = .Rows(i)("c_nro_serie").ToString
                    Dgv01.Rows(i).Cells("Guia").Value = .Rows(i)("c_nro_salidaTa").ToString
                    Dgv01.Rows(i).Cells("Total").Value = Format(Val(.Rows(i)("c_total_guia").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Fecha").Value = .Rows(i)("c_fecha_sal").ToString
                Next
            End If
        End With
    End Sub
    Private Sub CboBus_Serie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBus_Serie.SelectedIndexChanged
        Call Mostrar_Numero_Factura()
    End Sub
    Private Sub Mostrar_Numero_Factura()
        With c_Neg_Series.get_Series_Datos(" and c_anula_reg=0 and c_nro_serie='" & CboSerie.Text & "' and c_codi_doc='01' ", "DAT", FrmMenu.TxtCod_Emp.Text)
            TxtFactura.Clear()
            If .Rows.Count > 0 Then
                TxtFactura.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
            Else
                TxtFactura.Text = "0000000"
            End If
        End With
    End Sub
    'Calcular Totales...
    Private Sub Calcular_Totales()
        With Dgv02
            Dim Tot_Precio As Decimal = 0 : Dim Prec_Unit As Decimal = 0
            Dim Total As Decimal = 0 : Dim Peso_Total As Decimal = 0 : Dim Nro_Rollos As Integer ': Call Limpiar_Texto(Pan11)
            For i = 0 To .RowCount - 1
                ' Total Precio Colroes
                Prec_Unit = Prec_Unit + Val(.Rows(i).Cells("Precio").Value)
                ' Precio Totales
                Peso_Total = Peso_Total + Val(.Rows(i).Cells("Cantidad").Value)
                Nro_Rollos = Nro_Rollos + Val(.Rows(i).Cells("Bultos").Value)
                Total = Total + Val(.Rows(i).Cells("Importe").Value)
            Next

            LblRollos.Text = Format(Nro_Rollos, Forma_1_2)
            LblPeso.Text = Format(Peso_Total, Forma_1_2)
            LblImporte_3.Text = Format(Total, Forma_1_2)
            LblSub_Total.Text = Format(Total - Val(TxtDsctos.Text), Forma_1_2)
            ' We validate if the invoice is affected
            If ChkInaf.Checked = True Then
                LblTot_Igv.Text = "0.00"
            Else
                If UCase(CboTpo.Text) = "VENTAS EXTERIOR" Then
                    LblTot_Igv.Text = "0.00"
                Else
                    LblTot_Igv.Text = Format((Val(TxtCant_IGV.Text) / 100) * (Val(LblSub_Total.Text)), Forma_1_2)
                End If
            End If

            If CboTpo.Text = "ANTICIPO" Then
                If Val(TxtDsctos.Text) = 0 Then
                    LblTotales.Text = Format(Val(LblImporte_3.Text) + (Val(LblImporte_3.Text) * (Val(TxtCant_IGV.Text) / 100)), Forma_1_2)
                End If
                LblSub_Total.Text = Format(Val(LblTotales.Text) / (Val(TxtCant_IGV.Text) / 100 + 1), Forma_1_2)
                LblTot_Igv.Text = Format(Val(LblTotales.Text) - Val(LblSub_Total.Text), Forma_1_2)
            Else
                LblTotales.Text = Format(Val(LblTot_Igv.Text) + Val(LblSub_Total.Text), Forma_1_2)
            End If

            'Validamos para la conversion de numeros a letras...
            If Val(LblTotales.Text) > 0 Then
                If CboMon.Text = "$." Then
                    LblLetras.Text = StrConv(num2text(Mid(LblTotales.Text, 1, Len(LblTotales.Text) - 3)) & " Y " & Strings.Right(LblTotales.Text, 2) & "/100 DOLARES AMERICANOS", VbStrConv.Uppercase)
                Else
                    LblLetras.Text = StrConv(num2text(Mid(LblTotales.Text, 1, Len(LblTotales.Text) - 3)) & " Y " & Strings.Right(LblTotales.Text, 2) & "/100 SOLES", VbStrConv.Uppercase)
                End If
            Else
                LblLetras.Text = ""
            End If
        End With
    End Sub

    Private Sub TxtDscto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call solonumeros(e)
    End Sub
    'Ingresamos nueva factura...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02)
        Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04)
        Call Limpiar_Texto(Pan05) : Call Limpiar_Texto(Pan06)
        Call Limpiar_Texto(Pan11) : Call Nuevo_Registro() : LblGuia.Text = "0 Guías Seleccionadas"
        DtpFec_Emi.Text = Now.Date : CboVende.SelectedValue = "" : CboVende.Enabled = False
        Rdb01.Enabled = True : Rdb02.Enabled = True
        CboMon.SelectedIndex = 1 : CboTpo.SelectedIndex = 0
        CboSerie.SelectedIndex = 0 : CboSerie.Enabled = True
        Grabar = 1 : Call Limpiar_Texto(Pan11) : LblLetras.Text = ""
        Call Mostrar_IGV(DtpFec_Emi.Text, TxtCant_IGV) : Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
        BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon
        'Vta mostrador
        TxtFactura.Enabled = False : TxtObs.Enabled = False : BtnCon1.Enabled = True
        Call CboSerie_SelectedIndexChanged(Nothing, Nothing) : CboSerie.Enabled = False
        DtpFec_Vcto.Enabled = True : Rdb01.Checked = False : BtnCon1.Focus() : TxtObs.Enabled = True
        DtpFec_Vcto.Text = Now.Date : BtnMostrar.Enabled = True : Rdb02.Checked = True : CboMon.SelectedIndex = -1
        CboMon.Focus() : ChkRetencion.Enabled = True : ChkRetencion.Checked = False : BtnEditar.Enabled = False
        CboFPago.SelectedIndex = -1 : CboFPago.Enabled = True : TxtObs.Clear() : CboTpo.Enabled = True : CboTpo.SelectedIndex = 0
        ChkInaf.Checked = False : ChkInaf.Enabled = True : CboSerie.Enabled = True
        CboSerie.SelectedValue = FrmMenu.TxtSerie_Fact.Text : CboBus_Serie.SelectedValue = FrmMenu.TxtSerie_Fact.Text
        CboStatus.SelectedValue = "00" : CboBco.SelectedValue = "00"
        CboBco.Enabled = True
    End Sub

    'Metodo que nos permite limpiar y activar los controles
    Private Sub Nuevo_Registro()
        'Activamos los controles
        Call Activar(Pan01) : Call Activar(Pan06)
        CboMon.Enabled = True : CboClie.SelectedValue = ""
        CboVende.Enabled = True : CboSerie.Enabled = False
        Pan12.Enabled = False : TxtCod_Clie.Enabled = False
        BtnNuevo.Enabled = False : BtnGrabar.Enabled = True
        BtnImprimir.Enabled = False : BtnEliminar.Enabled = False : BtnCerrar.Text = "&Cancelar"
        Pan10.Enabled = True : Pan03.Enabled = True : CboMon.Enabled = True : CboVende.Enabled = True
        BtnCon1.Enabled = True : TxtDir.Enabled = False
        LblTot_Igv.Text = "0.00" : LblRollos.Text = "0.00" : LblPeso.Text = "0.00"
        LblSub_Total.Text = "0.00" : TxtDsctos.Text = "0.00" : LblTot_Igv.Text = "0.00" : LblTotales.Text = "0.00"
        TxtDsctos.Enabled = True : CboStatus.Enabled = True : CboBco.Enabled = True
    End Sub
    'Metodo que nos permite Cancelar un ingreso
    Private Sub Cancelar_Registro()
        BtnNuevo.Enabled = True : BtnGrabar.Enabled = False : CboBco.Enabled = False
        BtnImprimir.Enabled = True : BtnEliminar.Enabled = True
        BtnCerrar.Text = "Cerrar" : Pan12.Enabled = True : Grabar = 0
        Pan10.Enabled = False : Pan20.Enabled = True : BtnGrabar.Enabled = False : Pan20.Enabled = True
        Call Desactivar(Pan01) : CboSerie.Enabled = False : BtnEditar.Enabled = True
        Call Desactivar(Pan05) : Call Desactivar(Pan06) : DtpFec_Emi.Enabled = False : DtpFec_Vcto.Enabled = False
        Pan03.Enabled = False : CboMon.Enabled = False : CboVende.Enabled = False : BtnEditar.Enabled = True
        BtnCon1.Enabled = False : Dgv02.Enabled = True : Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        CboFPago.Enabled = False : CboTpo.Enabled = False : TxtDsctos.Enabled = False
        ChkInaf.Enabled = False : CboTpo.Enabled = False : CboStatus.Enabled = False
    End Sub
    'Cancelar Registro...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            If Grabar = 2 Then
                Call Mostrar_Facturas(" and c_nro_serie='" & CboSerie.Text & "' and c_nro_factura='" & TxtFactura.Text & "'")
            Else
                Call BtnFin_Click(Nothing, Nothing)
            End If
            Call Cancelar_Registro()
        End If
    End Sub
    ' Funcion para validar datos'
    Private Function ValidarDatos() As Boolean
        If CboSerie.SelectedIndex > -1 Then
            If CboTpo.SelectedIndex > -1 Then
                If CboFPago.SelectedIndex > -1 Then
                    If CboMon.SelectedIndex > -1 Then
                        If Val(TxtCant_IGV.Text) > 0 Then
                            If Val(TxtTC.Text) > 0 Then
                                If Len(TxtCod_Clie.Text) > 0 Then
                                    If Len(TxtRuc.Text) = 11 Then
                                        ValidarDatos = True
                                    Else
                                        If CboTpo.Text = "VENTAS EXTERIOR" Or CboTpo.Text = "MUESTRA EXTERIOR" Then
                                            ValidarDatos = True
                                        Else
                                            ValidarDatos = False
                                            MsgBox("2. R.U.C. ingresado no valido...", MsgBoxStyle.Critical, Compañia)
                                        End If
                                    End If
                                Else
                                    ValidarDatos = False
                                    MsgBox("3. Falta seleccionar el cliente...", MsgBoxStyle.Critical, Compañia)
                                End If
                            Else
                                ValidarDatos = False
                                MsgBox("4. Falta ingresar el tipo de cambio...", MsgBoxStyle.Critical, Compañia)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("5. Falta ingresar el porcentaje del I.G.V.", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("6. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("7. Falta seleccionar la forma de pago", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("8. Falta seleccionar el tipo de venta", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("9. Falta seleccionar la serie de venta", vbCritical, Compañia)
        End If
    End Function
    Private Function validarDetraccion() As Boolean
        If Rdb01.Checked = True Then
            If validarSiEsDetraccionValida(txtCodigoDetraccion.Text) = True Then
                If Val(TxtDetrac.Text) > 0 Then
                    validarDetraccion = True
                Else
                    MsgBox("1. La detracción no tiene el porcentaje...", vbCritical, Compañia)
                    validarDetraccion = False
                End If
            End If
        Else
            validarDetraccion = True
        End If
    End Function
    'Grabamos registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If validarDetraccion() = True Then
            If ValidarCierre(DtpFec_Emi.Text) = True Then
                If ValidarCodigoSUNAT(Dgv02) = True Then
                    If ValidarDatos() = True Then
                        If Dgv02.RowCount = 0 Then MsgBox("La factura no tiene detalles...", MsgBoxStyle.Critical, Compañia)
                        Dim f As String = MsgBox("¿Desea grabar el registro...?", vbYesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            If Grabar = 1 Then TxtFactura.Clear()
                            Call Grabar_Factura("ADD")
                            If Len(TxtFactura.Text) > 0 Then
                                ' Grabamos Detalles '
                                With Dgv02
                                    For i = 0 To .RowCount - 1
                                        Call Grabar_Detalles(i, "ADD")
                                    Next
                                End With
                                ' Grabamos Guias con Facturas '
                                With Dgv01
                                    For i = 0 To .RowCount - 1
                                        If .Rows(i).Cells("chk").Value = True Then
                                            If Val(.Rows(i).Cells("c_nro_correl").Value) = 0 Then
                                                Call Grabar_FactGuia(i, "ADD")
                                            End If
                                        End If
                                    Next
                                End With
                                Call Cancelar_Registro() : Call BtnFin_Click(Nothing, Nothing)
                                MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Exclamation, Compañia)
                                If FrmMenu.ChkElectronico.Checked = True Then
                                    ' Validamos si enviamos a facturacion electronica solo si no es numeric la serie'
                                    If IsNumeric(Strings.Left(CboSerie.Text, 1)) = False Then
                                        ' Solo para grabar no para editar grabar=2 '
                                        If Grabar = 1 Then
                                            If CboTpo.Text <> "ANTICIPO" Then
                                                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtFactura.Text, "01", "ADD")
                                                Call Activar_Timer(Pan16, Timer1)
                                            End If
                                        End If
                                    End If
                                Else
                                    'Call BtnImprimir_Click(Nothing, Nothing)
                                End If
                                Call BtnImprimir_Click(Nothing, Nothing)
                            Else
                                MsgBox("1. Hubieron problemas al momento de grabar la factura, revisar...", vbCritical, Compañia)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    ' Metodo para Grabar la Cabecera de La Factura '
    Private Sub Grabar_Factura(ByVal cOpcion As String)
        With c_Ent_FactCab
            Dim Detraccion As Decimal = 0
            Dim c_opc_detrac As Integer = 0 : Dim c_opc_reten As Integer = 0
            ' validamos si esta afecto a retencion '
            If ChkRetencion.Checked = True Then
                c_opc_reten = 1
            End If
            'Validamos si factura esta afecta a detracciones...
            If Val(TxtDetrac.Text) > 0 Then
                Detraccion = Format((Val(TxtDetrac.Text) / 100) * Val(LblTotales.Text), Forma_1_2)
            End If
            If Rdb01.Checked = True Then
                c_opc_detrac = 1
            Else
                c_opc_detrac = 0
            End If
            .c_nro_serie = CboSerie.Text
            .c_nro_factura = TxtFactura.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_cant_igv = Val(TxtCant_IGV.Text)
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_vende = CboVende.SelectedValue
            .c_codi_pago = CboFPago.SelectedValue
            .c_codi_status = CboStatus.SelectedValue
            .c_codi_bco = CboBco.SelectedValue
            .c_tpo_venta = CboTpo.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_venci = DtpFec_Vcto.Text
            .c_motivo_anula = ""
            .c_rollos_fact = Val(Replace(LblRollos.Text, ",", ""))
            .c_peso_fact = Val(Replace(LblPeso.Text, ",", ""))
            .c_venta_fact = Val(Replace(LblImporte_3.Text, ",", ""))
            .c_dscto_fact = Val(TxtDsctos.Text)
            .c_import_fact = Val(Replace(LblSub_Total.Text, ",", ""))
            .c_igv_fact = Val(Replace(LblTot_Igv.Text, ",", ""))
            .c_total_fact = Val(Replace(LblTotales.Text, ",", ""))
            .c_obs = TxtObs.Text
            .c_nro_oc = TxtOc.Text
            .c_opc_detrac = c_opc_detrac
            .c_opc_reten = c_opc_reten
            .c_codi_detrac = txtCodigoDetraccion.Text
            .c_detracc_fact = Detraccion
            .c_detracc_por = Val(TxtDetrac.Text)
            .c_letras_fact = LblLetras.Text
            If ChkInaf.Checked = True Then
                .c_opc_inaf = 1
            Else
                .c_opc_inaf = 0
            End If
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            ' Validamos si se graba o se anula '
            If Grabar = 1 Then
                TxtFactura.Text = c_Neg_FactCab.set_FactCab_Save(c_Ent_FactCab, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_FactCab.set_FactCab_Save(c_Ent_FactCab, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
        Grabar = 0
    End Sub
    ' Metodo para Grabar el Detalles de La Factura '
    Private Sub Grabar_Detalles(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_FactDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_serie = CboSerie.Text
            .c_nro_factura = TxtFactura.Text
            .c_nro_lote = Dgv02.Rows(Fila).Cells("Lote").Value
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed").Value
            .c_cant_caja = Val(Dgv02.Rows(Fila).Cells("Bultos").Value)
            .c_nro_cant = Val(Dgv02.Rows(Fila).Cells("Cantidad").Value)
            .c_prec_venta = Format(Val(Dgv02.Rows(Fila).Cells("Precio").Value), Forma_1_7)
            .c_total_fact = Val(Dgv02.Rows(Fila).Cells("Importe").Value)
            .c_opc_afecto = Val(Dgv02.Rows(Fila).Cells("c_opc_afecto").Value)
            .c_correl_guia = Dgv02.Rows(Fila).Cells("c_correl_guia").Value
            .copcion = cOpcion
            'Validamos estado de Detalle...
            If Val(Dgv02.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_FactDet.set_FactDet_Save(c_Ent_FactDet, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_FactDet.set_FactDet_Save(c_Ent_FactDet, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    ' Metodo para Grabar La Factura con la Guia de Remision '
    Private Sub Grabar_FactGuia(ByVal fila As Integer, ByVal cOpcion As String)
        With c_Ent_FactGuia
            .c_nro_correl = Dgv01.Rows(fila).Cells("c_nro_correl").Value
            .c_serie_guia = Dgv01.Rows(fila).Cells("c_nro_serie").Value
            .c_nro_guia = Dgv01.Rows(fila).Cells("Guia").Value
            .c_serie_factura = CboSerie.Text
            .c_nro_factura = TxtFactura.Text
            .c_fecha_emi = Dgv01.Rows(fila).Cells("Fecha").Value
            .c_total_guia = Val(Dgv01.Rows(fila).Cells("Total").Value)
            .copcion = cOpcion
            ' Validamos si grabamos por primera vez'
            If Len(Dgv01.Rows(fila).Cells("c_nro_correl").Value) = 0 Then
                Dgv01.Rows(fila).Cells("c_nro_correl").Value = c_Neg_FactGuia.set_FactGuia_Save(c_Ent_FactGuia, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_FactGuia.set_FactGuia_Save(c_Ent_FactGuia, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    Private Sub TxtTg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'Hallamos el ultimo numero de la factura
    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        If CboSerie.Enabled = True Then
            With c_Neg_Series.get_Series_Datos(" and c_anula_reg=0 and c_codi_doc='01' and c_nro_serie='" & CboSerie.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                TxtFactura.Clear()
                If .Rows.Count > 0 Then TxtFactura.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
                TxtBus.Text = TxtFactura.Text
            End With
        End If
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Facturas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_factura= (select min(c_nro_factura) from sca_" & FrmMenu.TxtCod_Emp.Text & "_factcab where c_nro_serie='" & CboBus_Serie.Text & "')")
    End Sub
    ' Mostramos Facturas '
    Public Sub Mostrar_Facturas(ByVal Cadena As String)
        Dim dataTable As DataTable = c_Neg_FactCab.get_FactCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
        With dataTable
            Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : Call Limpiar_Texto(Pan05) : TxtFactura.Clear() : Call Limpiar_Texto(Pan11)
            TxtObs.Enabled = False : DtpFec_Vcto.Enabled = False : Dgv01.ReadOnly = True : Dgv02.ReadOnly = True : CboMon.Enabled = False
            TxtDetrac.Enabled = False : TxtTC.Enabled = False : Pan12.Enabled = True : BtnMostrar.Enabled = False
            If .Rows.Count > 0 Then
                CboSerie.Enabled = False
                '--- Validamos si esta afecto a Detraccion ---'
                If Val(.Rows(0)("c_opc_detrac").ToString) = 1 Then
                    Rdb01.Checked = True
                Else
                    Rdb02.Checked = True
                End If
                txtCodigoDetraccion.Text = .Rows(0)("c_codi_detrac").ToString
                TxtDetrac.Text = Format(Val(.Rows(0)("c_detracc_porc").ToString), Forma_1_2)
                '-- Validamos si esta a afecto a retencion --'
                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                    ChkRetencion.Checked = True
                Else
                    ChkRetencion.Checked = False
                End If
                '-- Validamos si factura es afecta detraccion --'
                If Val(.Rows(0)("c_opc_inaf").ToString) = 1 Then
                    ChkInaf.Checked = True
                Else
                    ChkInaf.Checked = False
                End If
                ' Mostramos el tipo de venta '
                CboTpo.SelectedIndex = -1
                For I = 0 To CboTpo.Items.Count - 1
                    If CboTpo.Items(I).ToString = .Rows(0)("c_tpo_venta").ToString Then
                        CboTpo.SelectedIndex = I : I = CboTpo.Items.Count + 1
                    End If
                Next
                CboFPago.SelectedValue = .Rows(0)("c_codi_pago").ToString
                LblFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                TxtCant_IGV.Text = Val(.Rows(0)("c_cant_igv").ToString)
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString
                TxtCod_Clie.Text = .Rows(0)("c_Codi_clie").ToString
                CboClie.SelectedValue = .Rows(0)("c_codi_clie").ToString
                CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                CboSerie.SelectedValue = .Rows(0)("c_nro_Serie").ToString
                TxtDir.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & " " & .Rows(0)("c_prov_clie").ToString _
                    & " " & .Rows(0)("c_dist_clie").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtBus.Text = .Rows(0)("c_nro_factura").ToString
                TxtFactura.Text = .Rows(0)("c_nro_factura").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Vcto.Text = .Rows(0)("c_fecha_venci").ToString
                TxtAbrev.Text = .Rows(0)("c_abrev_clie").ToString
                TxtOc.Text = .Rows(0)("c_nro_oc").ToString
                CboStatus.SelectedValue = .Rows(0)("c_codi_status").ToString
                CboBco.SelectedValue = .Rows(0)("c_codi_bco").ToString
                'Validamos si factura se encuentra anulada...
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then 'Validamos si factura esta cancelado
                    If Val(.Rows(0)("c_cancel_fact").ToString) = 1 Then
                        BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Drawing.Color.RoyalBlue
                    Else 'Validamos si factura se encuentra amortizado...
                        If Val(.Rows(0)("c_cancel_fact").ToString) = 2 Or Val(.Rows(0)("c_cancel_fact").ToString) = 3 Then
                            BtnEstado.Text = "AMORTIZADO" : BtnEstado.BackColor = Drawing.Color.SteelBlue
                        Else
                            If Val(.Rows(0)("c_opc_dscto").ToString) = 1 Then
                                BtnEstado.Text = "FACTORY"
                            Else
                                BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon
                            End If
                        End If
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                End If
                ''''''''''''''''''''Agregamos el Detalle''''''''''''''''''''''
                Dim dataTable2 As DataTable = c_Neg_FactGuia.get_FactGuia_Datos(" and F.c_serie_factura='" & CboSerie.Text & "' and F.c_nro_factura='" & TxtFactura.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                With dataTable2
                    Dgv01.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv01.Rows.Add()
                            Dgv01.Rows(i).Cells("Chk").Value = True
                            Dgv01.Rows(i).Cells("c_nro_serie").Value = .Rows(i)("c_serie_guia").ToString
                            Dgv01.Rows(i).Cells("Guia").Value = .Rows(i)("c_nro_guia").ToString
                            Dgv01.Rows(i).Cells("Total").Value = Format(Val(.Rows(i)("c_total_guia").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Fecha").Value = .Rows(i)("c_fecha_emi").ToString
                            Dgv01.Rows(i).Cells("c_nro_correl").Value = .Rows(i)("c_nro_correl").ToString
                            '' paul simon la sra. robinson ''
                        Next
                    End If
                End With
                'Llenamos el detalle de la factura...
                Dim dataTable3 As DataTable = c_Neg_FactDet.get_FactDet_Datos(" And D.c_nro_serie='" & CboSerie.Text & "' and D.c_nro_factura='" & TxtFactura.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                With dataTable3
                    Dgv02.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("Lote").Value = .Rows(i)("c_nro_lote").ToString
                            Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                            Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("Bultos").Value = Format(Val(.Rows(i)("c_cant_caja").ToString), Forma_1_1)
                            Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_precio_venta").ToString), Forma_1_7)
                            Dgv02.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_total_fact").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("c_opc_afecto").Value = Val(.Rows(i)("c_opc_afecto").ToString)
                            Dgv02.Rows(i).Cells("c_correl_guia").Value = .Rows(i)("c_correl_guia").ToString
                        Next
                    End If
                End With
                ' Pesos '
                LblRollos.Text = Format(Val(.Rows(0)("c_rollos_fact").ToString), Forma_1_2)
                LblPeso.Text = Format(Val(.Rows(0)("c_peso_fact").ToString), Forma_2_2)
                ' Totales '
                LblImporte_3.Text = Format(Val(.Rows(0)("c_venta_fact").ToString), Forma_2_2)
                TxtDsctos.Text = Format(Val(.Rows(0)("c_dscto_fact").ToString), Forma_2_2)
                LblSub_Total.Text = Format(Val(.Rows(0)("c_import_fact").ToString), Forma_2_2)
                LblTot_Igv.Text = Format(Val(.Rows(0)("c_igv_fact").ToString), Forma_2_2)
                LblTotales.Text = Format(Val(.Rows(0)("c_total_fact").ToString), Forma_2_2)
                ' Letras '
                LblLetras.Text = .Rows(0)("c_letras_fact").ToString

            Else
                Dgv02.Rows.Clear() : Dgv01.Rows.Clear()
            End If
        End With
    End Sub
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Facturas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_factura= (select max(c_nro_factura) from sca_" & FrmMenu.TxtCod_Emp.Text & "_factcab where c_nro_serie='" & CboBus_Serie.Text & "')")
    End Sub
    'Retrocedemos registro...
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 1 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 10000000, 7)
            Call Mostrar_Facturas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_factura='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 100000001, 7)
            Call Mostrar_Facturas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_factura='" & TxtBus.Text & "'")
            '  TxtBus.Text = TxtFactura.Text
        End If
    End Sub

    Private Sub TxtBus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 10000000, 7)
                Call Mostrar_Facturas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_factura='" & TxtBus.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBus.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub
    'Eliminar registro...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarFactu("FACTURA", " and c_nro_serie='" & CboSerie.Text & "' and c_nro_factura='" & TxtFactura.Text & "' ") = True Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    Dim f As String = MsgBox("Confirma la eliminación del Registro...", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        Call Grabar_Factura("DEL")
                        ' Grabamos Guias con Facturas '
                        With Dgv01
                            For i = 0 To .RowCount - 1
                                If .Rows(i).Cells("chk").Value = True Then
                                    Call Grabar_FactGuia(i, "DEL")
                                End If
                            Next
                        End With
                        BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                        MsgBox(" 1. Registro se ANULO Correctamente... ", vbExclamation, Compañia)
                        If FrmMenu.ChkElectronico.Checked = True Then
                            c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtFactura.Text, "01", "DEL")
                        End If
                    End If
                Else
                    If UCase(BtnEstado.Text) = "ANULADO" Then
                        MsgBox(" 2. Documento no puede ser Anulado...", vbCritical, Compañia)
                    Else
                        If Strings.Left(CboTpo.Text, 5) <> "VENTA" Then
                            Dim f As String = MsgBox("Confirma la eliminación del Registro...", vbYesNo + MsgBoxStyle.Question, Compañia)
                            If f = vbYes Then
                                Call Grabar_Factura("DEL")
                                ' Grabamos Guias con Facturas '
                                With Dgv01
                                    For i = 0 To .RowCount - 1
                                        If .Rows(i).Cells("chk").Value = True Then
                                            Call Grabar_FactGuia(i, "DEL")
                                        End If
                                    Next
                                End With
                                BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                                MsgBox(" 3. Registro se ANULO Correctamente... ", vbExclamation, Compañia)
                                If FrmMenu.ChkElectronico.Checked = True Then
                                    c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtFactura.Text, "01", "DEL")
                                End If
                            End If
                        Else
                            MsgBox(" 4. Documento no puede ser Anulado...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'Imprimir Factura...
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If IsNumeric(Strings.Left(CboSerie.Text, 1)) = True Then
            FrmReportes.Impresion_Factura(CboSerie.Text, TxtFactura.Text, TxtObs.Text, Val(TxtDetrac.Text))
        Else

            If ValidarEnvio(CboSerie.Text, TxtFactura.Text, "01", 0) = True Then
                '   Call Abrir_Pdf("6-" & FrmMenu.TxtRuc.Text &
                '            "\" & "01-" & CboSerie.Text & "-0" & TxtFactura.Text & "\PDFLOCAL-" & FrmMenu.TxtRuc.Text & "-01-" & CboSerie.Text & "-0" & TxtFactura.Text & ".pdf")
                Abrir_PDf_2(CboSerie.Text & "-0" & TxtFactura.Text, "01", DtpFec_Emi.Text)
            End If
        End If
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    'Historial de Documentos...
    Private Sub LnkHistorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and P.c_Serie_doc='" & CboSerie.Text & "' and P.c_nro_factura='" & TxtFactura.Text & "' ", "FACT")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub LnkHistoAnexos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistoAnexos.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoDocAnexos.MdiParent = FrmMenu : FrmConHistoDocAnexos.Show()
            FrmConHistoDocAnexos.Cargar_Grid(" AND C.c_nro_serie='" & CboSerie.Text & "' and C.c_nro_factura='" & TxtFactura.Text & "'  ", " and C.c_nro_serie='" & CboSerie.Text & "' and C.c_nro_doc='" & TxtFactura.Text & "'  ", "FACT")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub
    'Consultamos facturas...
    Private Sub LnkConFact_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkConFact.LinkClicked
        FrmConFact.MdiParent = FrmMenu : FrmConFact.Show()
    End Sub

    Private Sub CboMon_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboMon.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : BtnCon1.Focus()
        End If
    End Sub
    ' Cambiamos tipo de Moneda'
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        If Dgv02.RowCount > 0 Then
            MsgBox(" ¡Elimine las Guías seleccionadas para, para cambiar el tipo de Moneda...! ")
        Else
            LblImporte.Text = "Importe " & CboMon.Text
            LblDscto.Text = "Dscto. " & CboMon.Text : LblIgv.Text = "I.G.V. " & CboMon.Text
            LblTotal.Text = "Total " & CboMon.Text
        End If
    End Sub

    Private Sub CboClie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboClie.SelectedIndexChanged

    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click

        If CboMon.SelectedIndex > -1 Then
            Call Cargar_Detalles()
            Call Calcular_Totales()
        Else
            MsgBox("Es importante seleccionar la moneda de ventas...", vbCritical, Compañia)
        End If
    End Sub
    ' Cargar Detalles de Guia de Remision... '
    Private Sub Cargar_Detalles()
        With Dgv01
            Dgv02.Rows.Clear()
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("Chk").Value = True Then
                    With c_Neg_AlmSalTADet.get_AlmSalTaDet_Datos(" And D.c_nro_serie='" & Dgv01.Rows(i).Cells("c_nro_serie").Value & _
                                                                 "' And D.c_nro_salidaTA='" & Dgv01.Rows(i).Cells("Guia").Value & _
                                                                 "' And C.c_codi_clie='" & TxtCod_Clie.Text & "' And D.c_anula_reg=0 order by D.c_nro_correl", "DAT", FrmMenu.TxtCod_Emp.Text)
                        If .Rows.Count > 0 Then
                            For u = 0 To .Rows.Count - 1
                                Dgv02.Rows.Add()
                                Dim F As Integer = Dgv02.RowCount - 1
                                Dgv02.Rows(F).Cells("Lote").Value = .Rows(u)("c_nro_lote").ToString
                                Dgv02.Rows(F).Cells("Descripcion").Value = .Rows(u)("c_desc_articulo").ToString
                                Dgv02.Rows(F).Cells("Codigo").Value = .Rows(u)("c_codi_articulo").ToString
                                Dgv02.Rows(F).Cells("Bultos").Value = .Rows(u)("c_cant_caja").ToString
                                Dim x As New TextBox
                                Call Hallar_PrecioServ(" and S.c_codi_clie='" & TxtCod_Clie.Text & "' and S.c_codi_articulo='" & .Rows(u)("c_codi_articulo").ToString & _
                                                       "' and S.c_anula_Reg=0 ", x)
                                'MsgBox(x.Text)

                                Dgv02.Rows(F).Cells("Precio").Value = Format(Val(x.Text), Forma_1_7)
                                Dgv02.Rows(F).Cells("Cantidad").Value = .Rows(u)("c_nro_cant").ToString
                                Dgv02.Rows(F).Cells("Importe").Value = Format(Val(Dgv02.Rows(F).Cells("Cantidad").Value) * Val(x.Text), Forma_1_2)
                                ' Opciones por tipo de Color '
                                Dgv02.Rows(F).Cells("c_opc_afecto").Value = 1
                                Dgv02.Rows(F).Cells("Unid").Value = .Rows(u)("c_desc_unimed").ToString
                                Dgv02.Rows(F).Cells("c_codi_unimed").Value = .Rows(u)("c_codi_unimed").ToString
                                Dgv02.Rows(F).Cells("Item").Value = ""
                                Dgv02.Rows(F).Cells("c_correl_guia").Value = .Rows(u)("c_nro_correl").ToString

                            Next
                        End If
                    End With
                End If
            Next
        End With
    End Sub
    '-- Metodo para Hallar el Precio Unitario--'
    Private Sub Hallar_PrecioServ(ByVal Cadena As String, ByVal x As TextBox)
        With c_Neg_MnClienteArt.get_ClienteArt_Datos(Cadena, "DAT")
            If .Rows.Count > 0 Then
                If CboMon.Text = "$." Then
                    x.Text = Val(.Rows(0)("c_precio_srv_us").ToString)
                Else
                    x.Text = Val(.Rows(0)("c_precio_srv_mn").ToString)
                End If
            Else
                x.Text = 0
            End If
        End With
    End Sub

    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoDocAnexos.MdiParent = FrmMenu : FrmConHistoDocAnexos.Show()
            FrmConHistoDocAnexos.Cargar_Grid(" and P.c_nro_factura='" & TxtFactura.Text & "' and P.c_tpo_cyb='R' ", "", "FACR")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub BtnCon1_LostFocus(sender As Object, e As System.EventArgs) Handles BtnCon1.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnCon1.Focus()
        End If
    End Sub
    ' Editamos registro '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarFactu("FACTURA", " and c_nro_serie='" & CboSerie.Text & "' and c_nro_factura='" & TxtFactura.Text & "' ") = True Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    DtpFec_Vcto.Enabled = True : ChkRetencion.Enabled = True : TxtObs.Enabled = True : Grabar = 2 : Pan20.Enabled = False
                    CboTpo.Enabled = True : CboStatus.Enabled = True : CboVende.Enabled = True : CboBco.Enabled = True
                    BtnGrabar.Enabled = True : CboFPago.Enabled = True : BtnCerrar.Text = "&Cancelar"
                Else
                    MsgBox("Registro no puede ser modificado, ya fue cancelado o anulado...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    Private Sub CboFPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFPago.SelectedIndexChanged
        If CboFPago.Enabled = True Then
            With c_Neg_MnTpoPago.get_TpoPago_Datos(" and c_codi_pago='" & CboFPago.SelectedValue & "' ", "DAT")
                If .Rows.Count > 0 Then
                    DtpFec_Vcto.Text = DateAdd("d", Val(.Rows(0)("c_nro_dias").ToString), DtpFec_Emi.Text)
                End If
            End With
        End If
    End Sub

    Private Sub TxtDsctos_TextChanged(sender As Object, e As EventArgs) Handles TxtDsctos.TextChanged
        If TxtDsctos.Enabled = True Then
            If CboTpo.Text = "ANTICIPO" Then
                Dim TotVenta As Decimal = Format(Val(LblImporte_3.Text) + (Val(LblImporte_3.Text) * (Val(TxtCant_IGV.Text) / 100)), Forma_1_2)
                LblTotales.Text = Format(TotVenta - Val(TxtDsctos.Text), Forma_1_2)
            Else
                LblSub_Total.Text = Format(Val(LblImporte_3.Text) - Val(TxtDsctos.Text), Forma_1_2)
            End If
            Call Calcular_Totales()
        End If
    End Sub

    Private Sub Dgv02_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv02.SelectionChanged

    End Sub

    Private Sub LnkComision_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkComision.LinkClicked
        FrmConComisDet.MdiParent = FrmMenu : FrmConComisDet.Show() : FrmConComisDet.Cargar_Grid(" and D.c_Codi_doc='01' and D.c_serie_Doc='" & CboSerie.Text & "' and D.c_nro_doc='" &
                                                                                                TxtFactura.Text & "' order by C.c_fecha_crea ")
    End Sub

    Private Sub ChkInaf_CheckedChanged(sender As Object, e As EventArgs) Handles ChkInaf.CheckedChanged
        If ChkInaf.Enabled = True Then
            Call Calcular_Totales()
        End If
    End Sub

    Private Sub CboTpo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTpo.SelectedIndexChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Pan16.Visible = True Then
            If Prb01.Value = 100 Then
                Timer1.Stop()
                Pan16.Visible = False : Prb01.Value = 0
                BtnImprimir_Click(Nothing, Nothing)
            Else
                Prb01.Value = Prb01.Value + 1
                LblEnvio.Text = "Enviando Información a la SUNAT " & Prb01.Value & "%"
            End If
        End If
    End Sub

    Private Sub BtnAnexar_Click(sender As Object, e As EventArgs) Handles BtnAnexar.Click
        If CboTpo.Text = "ANTICIPO" Then
            FrmBolAnexo.Close()
            FrmBolAnexo.MdiParent = FrmMenu : FrmBolAnexo.Show()
            FrmBolAnexo.Cargar_Grid(" and (C.c_nro_serie + C.c_nro_factura ='" & CboSerie.Text & TxtFactura.Text &
                                    "' or A.c_serie_anexo + A.c_factura_anexo='" & CboSerie.Text & TxtFactura.Text & "') order by C.c_fecha_emi ", "01")
            FrmBolAnexo.TxtVar.Text = 2 : FrmBolAnexo.txtCodClie.Text = TxtCod_Clie.Text
            FrmBolAnexo.TxtSerieDoc2.Text = CboSerie.Text
            FrmBolAnexo.TxtNroDoc2.Text = TxtFactura.Text
        Else
            MsgBox("Solo se puede anexar a las facturas por anticipo...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub txtCodigoDetraccion_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoDetraccion.TextChanged

    End Sub

    Private Sub txtCodigoDetraccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoDetraccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(txtCodigoDetraccion.Text) = 3 Then
                obtenerPorcentajeDetraccion(txtCodigoDetraccion.Text, TxtDetrac)
            End If
        End If
    End Sub
End Class