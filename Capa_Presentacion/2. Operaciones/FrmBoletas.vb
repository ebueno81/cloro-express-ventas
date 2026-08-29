Public Class FrmBoletas
    Dim focos As Integer = 0 : Dim Grabar As Integer = 0
    Private Sub FrmBoletas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        'If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.P Then If BtnImprimir.Enabled = True Then Call BtnImprimir_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then DtpFec_Emi_ValueChanged(Nothing, Nothing)
        ' Volver a Generar la facturacion electronica '
        If e.KeyCode = Keys.F8 And BtnGrabar.Enabled = False Then
            Dim F As String = MsgBox("¿Desea volver a generar la Facturacion electronica?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtBoleta.Text, "02", "ADD")
                If ValidarEnvio(CboSerie.Text, TxtBoleta.Text, "02", 1) = True Then
                    MsgBox("1. Documento subio correctamente...", vbExclamation, Compañia)
                End If
            End If
        End If
        ' realizar pruebas
        If e.Control And e.KeyCode = Keys.Q Then
            Call ValidarCodigoSUNAT(Dgv02)
        End If
    End Sub

    Private Sub FrmBoletas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmBoletas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" ", CboMon) : CboMon.SelectedIndex = -1
        Call DtpFec_Emi_ValueChanged(Nothing, Nothing)
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='02' AND C_anula_reg=0 order by c_nro_serie", CboBus_Serie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnSeriesDoc.get_Series_Cbo(" And c_codi_doc='02' AND C_anula_reg=0 order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnCliente.Get_Clientes_Cbo(" And c_anula_reg=0 order by c_desc_clie", CboClie)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende ", CboVende)
        c_Neg_MnTpoPago.Get_Fpago_Cbo(" and c_anula_reg=0 order by c_desc_pago", CboFPago)
        CboBus_Serie.SelectedIndex = 0 : CboBus_Serie.SelectedValue = FrmMenu.TxtSerie_Bol.Text
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        ' Servicios '
    End Sub
    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_IGV(DtpFec_Emi.Text, TxtCant_IGV)
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
        DtpFec_Vcto.Text = DtpFec_Emi.Text
    End Sub
    ' Afecto a Detraccion '
    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged
        If Rdb01.Checked = True Then
            TxtDetrac.Enabled = True : TxtDetrac.Clear() : TxtDetrac.Focus() : TxtDetrac.Text = 12
        End If
    End Sub

    Private Sub Rdb02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb02.CheckedChanged
        If Rdb02.Checked = True Then
            TxtDetrac.Enabled = False : TxtDetrac.Clear()
        End If
    End Sub
    ' Consultar Clientes '
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        If Dgv02.RowCount = 0 Then
            FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show()
            FrmConClientes.TxtVar.Text = 5 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
        Else
            MsgBox(" ¡Elimine las Guías Seleccionadas, para cambiar el Cliente...!", vbExclamation, Compañia)
        End If
    End Sub
    ' Mostramos Guias no Facturadas '
    Public Sub Mostrar_GuiaR()
        With c_Neg_AlmSalTA.get_AlmSalTa_Datos(" And S.c_nro_Serie not in ('100') And S.c_fact_guia=0 And S.c_codi_clie='" & TxtCod_Clie.Text & "' and S.c_anula_reg=0 ", "DAT", FrmMenu.TxtCod_Emp.Text)
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
        With c_Neg_Series.get_Series_Datos(" and c_anula_reg=0 and c_nro_serie='" & CboSerie.Text & "' and c_codi_doc='02' ", "DAT", FrmMenu.TxtCod_Emp.Text)
            TxtBoleta.Clear()
            If .Rows.Count > 0 Then
                TxtBoleta.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
            Else
                TxtBoleta.Text = "0000000"
            End If
        End With
    End Sub
    'Calcular Totales...
    Private Sub Calcular_Totales()
        With Dgv02
            Dim Tot_Precio As Decimal = 0 : Dim Prec_Unit As Decimal = 0
            Dim Total As Decimal = 0 : Dim Peso_Total As Decimal = 0 : Dim Nro_Rollos As Integer : Call Limpiar_Texto(Pan11)
            For i = 0 To .RowCount - 1
                Total = Total + Val(.Rows(i).Cells("Importe").Value)
                ' Precio Totales
                Peso_Total = Peso_Total + Val(.Rows(i).Cells("Cantidad").Value)
                Nro_Rollos = Nro_Rollos + Val(.Rows(i).Cells("Bultos").Value)
            Next
            LblRollos.Text = Format(Nro_Rollos, Forma_1_2)
            LblPeso.Text = Format(Peso_Total, Forma_1_2)
            LblSub_Total.Text = Format(Total, Forma_1_2)
            LblTotales.Text = Format(Val(LblSub_Total.Text) - Val(LblDsctos.Text), Forma_1_2)
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
        CboMon.SelectedIndex = -1 : Grabar = 1
        CboSerie.SelectedIndex = 0 : CboSerie.Enabled = True
        Call Limpiar_Texto(Pan11) : LblLetras.Text = "" : BtnMostrar.Enabled = True
        Call Mostrar_IGV(DtpFec_Emi.Text, TxtCant_IGV) : Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
        BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon
        'Vta mostrador
        TxtBoleta.Enabled = False : TxtObs.Enabled = False : BtnCon1.Enabled = True
        Call CboSerie_SelectedIndexChanged(Nothing, Nothing) : CboSerie.Enabled = False
        DtpFec_Vcto.Enabled = True : Rdb01.Checked = True : TxtObs.Enabled = True
        Rdb02.Checked = True : CboMon.Focus() : CboFPago.SelectedIndex = -1 : CboFPago.Enabled = True
        TxtObs.Clear() : CboTpo.SelectedIndex = 0 : ChkInaf.Checked = False : CboTpo.Enabled = True
        CboSerie.Enabled = True : CboSerie.SelectedValue = FrmMenu.TxtSerie_Bol.Text
        CboBus_Serie.SelectedValue = FrmMenu.TxtSerie_Bol.Text
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
        LblRollos.Text = "0.00" : LblPeso.Text = "0.00"
        LblSub_Total.Text = "0.00" : LblDsctos.Text = "0.00" : LblTotales.Text = "0.00"
    End Sub
    'Metodo que nos permite Cancelar un ingreso
    Private Sub Cancelar_Registro()
        BtnNuevo.Enabled = True : BtnGrabar.Enabled = False
        BtnImprimir.Enabled = True : BtnEliminar.Enabled = True
        BtnCerrar.Text = "Cerrar" : Pan12.Enabled = True
        Pan10.Enabled = False
        Call Desactivar(Pan01) : CboSerie.Enabled = False
        Call Desactivar(Pan05) : Call Desactivar(Pan06) : DtpFec_Emi.Enabled = False : DtpFec_Vcto.Enabled = False
        Pan03.Enabled = False : CboMon.Enabled = False : CboVende.Enabled = False
        BtnCon1.Enabled = False : Dgv02.Enabled = True : Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        CboFPago.Enabled = False : CboTpo.Enabled = False
    End Sub
    'Cancelar Registro...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            '    Call Mostrar_Facturas(" and c_nro_serie='" & CboSerie.Text & "' and c_nro_boleta='" & TxtFactura.Text & "'")
            Call BtnFin_Click(Nothing, Nothing)
            Call Cancelar_Registro()
        End If
    End Sub
    ' Funcion para validar la grabacion de un registro
    Private Function ValidarDatos() As Boolean
        If CboTpo.SelectedIndex > -1 Then
            If CboFPago.SelectedIndex > -1 Then
                If CboMon.SelectedIndex > -1 Then
                    If Val(TxtCant_IGV.Text) > 0 Then
                        If Val(TxtTC.Text) > 0 Then
                            If Len(TxtCod_Clie.Text) > 0 Then
                                If Len(TxtBoleta.Text) > 0 Then 'Confirmamos si grabamos registro despues de validar el ingreso correctamente...
                                    If Dgv02.RowCount = 0 Then MsgBox("La factura no tiene detalles...", MsgBoxStyle.Critical, Compañia)
                                    ValidarDatos = True
                                Else
                                    MsgBox("1. No existe Número de factura...", MsgBoxStyle.Critical, Compañia)
                                    ValidarDatos = False
                                End If
                            Else
                                MsgBox("3. Falta seleccionar el cliente...", MsgBoxStyle.Critical, Compañia)
                                ValidarDatos = False
                            End If
                        Else
                            MsgBox("4. Falta ingresar el tipo de cambio...", MsgBoxStyle.Critical, Compañia)
                            ValidarDatos = False
                        End If
                    Else
                        MsgBox("5. Falta ingresar el porcentaje del I.G.V.", MsgBoxStyle.Critical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("6. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("7. Falta seleccionar la forma de pago...", MsgBoxStyle.Critical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("8. Falta seleccionar el tipo de venta...", vbCritical, Compañia)
        End If
    End Function
    Private Function ValidarCodigoArtSunat() As Boolean
        With Dgv02
            For i = 0 To .RowCount - 1
                If ValidarCodigoSUNAT(.Rows(i).Cells("codigo").Value) = False Then
                    ValidarCodigoArtSunat = False
                    i = .RowCount + 1
                Else
                    ValidarCodigoArtSunat = True
                End If
            Next
        End With
    End Function
    'Grabamos registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarCodigoSUNAT(Dgv02) = True Then
                If ValidarDatos() = True Then
                    Dim f As String = MsgBox("¿Desea grabar el registro...?", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        TxtBoleta.Clear()
                        Call Grabar_Boleta("ADD")
                        '  If Grabar = 1 Then TxtBoleta.Clear()
                        If Len(TxtBoleta.Text) > 0 Then
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
                                            Call Grabar_BolGuia(i, "ADD")
                                        End If
                                    End If
                                Next
                            End With
                            Call Cancelar_Registro()
                            MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                            ' Validamos si esta activa la facturacion electronica '
                            If FrmMenu.ChkElectronico.Checked = True Then
                                ' Validamos si enviamos a facturacion electronica solo si no es numeric la serie'
                                If IsNumeric(Strings.Left(CboSerie.Text, 1)) = False Then
                                    If CboTpo.Text <> "ANTICIPO" Then
                                        c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtBoleta.Text, "02", "ADD")
                                        Call Activar_Timer(Pan16, Timer1)
                                    End If
                                End If
                            Else
                                ' Call BtnImprimir_Click(Nothing, Nothing)
                            End If
                            Call BtnImprimir_Click(Nothing, Nothing)
                        Else
                            MsgBox("1. Hubieron problemas al momento de grabar...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    ' Metodo para Grabar la Cabecera de La Factura '
    Private Sub Grabar_Boleta(ByVal cOpcion As String)
        With c_Ent_BolCab
            Dim Detraccion As Decimal = 0
            Dim c_opc_detrac As Integer = 0
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
            .c_nro_boleta = TxtBoleta.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_cant_igv = Val(TxtCant_IGV.Text)
            .c_codi_clie = TxtCod_Clie.Text
            .c_codi_vende = CboVende.SelectedValue
            .c_codi_pago = CboFPago.SelectedValue
            .c_tpo_venta = CboTpo.Text

            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_venci = DtpFec_Vcto.Text
            .c_motivo_anula = ""
            .c_rollos_bol = Val(Replace(LblRollos.Text, ",", ""))
            .c_peso_bol = Val(Replace(LblPeso.Text, ",", ""))
            .c_venta_bol = Val(Replace(LblSub_Total.Text, ",", ""))
            .c_dscto_bol = Val(LblDsctos.Text)
            .c_total_bol = Val(Replace(LblTotales.Text, ",", ""))
            .c_obs = TxtObs.Text
            .c_opc_detrac = c_opc_detrac
            .c_detracc_bol = Detraccion
            .c_detracc_por = Val(TxtDetrac.Text)
            .c_letras_bol = LblLetras.Text
            ' We validate if the invoice is affected'
            If ChkInaf.Checked = True Then
                .c_opc_inaf = 1
            Else
                .c_opc_inaf = 0
            End If
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            ' Validamos si se graba o se anula '
            If cOpcion = "ADD" Then
                TxtBoleta.Text = c_Neg_BolCab.set_BolCab_Save(c_Ent_BolCab, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_BolCab.set_BolCab_Save(c_Ent_BolCab, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    ' Metodo para Grabar el Detalles de La Factura '
    Private Sub Grabar_Detalles(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_BolDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_serie = CboSerie.Text
            .c_nro_boleta = TxtBoleta.Text
            .c_nro_lote = Dgv02.Rows(Fila).Cells("Lote").Value
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed").Value
            .c_cant_caja = Val(Dgv02.Rows(Fila).Cells("Bultos").Value)
            .c_nro_cant = Dgv02.Rows(Fila).Cells("Cantidad").Value
            .c_prec_venta = Val(Dgv02.Rows(Fila).Cells("Precio").Value)
            .c_total_bol = Val(Dgv02.Rows(Fila).Cells("Importe").Value)
            .c_opc_afecto = Val(Dgv02.Rows(Fila).Cells("c_opc_afecto").Value)
            .c_correl_guia = Dgv02.Rows(Fila).Cells("c_correl_guia").Value
            .copcion = cOpcion
            'Validamos estado de Detalle...
            If Val(Dgv02.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_BolDet.set_BolDet_Save(c_Ent_BolDet, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_BolDet.set_BolDet_Save(c_Ent_BolDet, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    ' Metodo para Grabar La Factura con la Guia de Remision '
    Private Sub Grabar_BolGuia(ByVal fila As Integer, ByVal cOpcion As String)
        With c_Ent_BolGuia
            .c_nro_correl = Dgv01.Rows(fila).Cells("c_nro_correl").Value
            .c_serie_guia = Dgv01.Rows(fila).Cells("c_nro_serie").Value
            .c_nro_guia = Dgv01.Rows(fila).Cells("Guia").Value
            .c_serie_boleta = CboSerie.Text
            .c_nro_boleta = TxtBoleta.Text
            .c_fecha_emi = Dgv01.Rows(fila).Cells("Fecha").Value
            .c_total_guia = Val(Dgv01.Rows(fila).Cells("Total").Value)
            .copcion = cOpcion
            Dgv01.Rows(fila).Cells("c_nro_correl").Value = c_Neg_BolGuia.set_BolGuia_Save(c_Ent_BolGuia, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    'Hallamos el ultimo numero de la factura
    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        If CboSerie.Enabled = True Then
            With c_Neg_Series.get_Series_Datos(" and c_anula_reg=0 and c_codi_doc='02' and c_nro_serie='" & CboSerie.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                TxtBoleta.Clear()
                If .Rows.Count > 0 Then TxtBoleta.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
                TxtBus.Text = TxtBoleta.Text
            End With
        End If
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Boletas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_boleta= (select min(c_nro_boleta) from sca_Fa_BolCab where c_nro_serie='" & CboBus_Serie.Text & "')")
    End Sub
    ' Mostramos Facturas '
    Public Sub Mostrar_Boletas(ByVal Cadena As String)
        With c_Neg_BolCab.get_BolCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : Call Limpiar_Texto(Pan05) : TxtBoleta.Clear() : Call Limpiar_Texto(Pan11)
            TxtObs.Enabled = False : DtpFec_Vcto.Enabled = False : Dgv01.ReadOnly = True : Dgv02.ReadOnly = True : CboMon.Enabled = False
            TxtDetrac.Enabled = False : TxtTC.Enabled = False : Pan12.Enabled = True : BtnMostrar.Enabled = False
            Rdb01.Enabled = False : Rdb02.Enabled = False : TxtDetrac.Enabled = False
            If .Rows.Count > 0 Then
                CboSerie.Enabled = False
                LblFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                ' Validamos si esta afecto a Detracion '
                If Val(.Rows(0)("c_opc_detrac").ToString) = 1 Then
                    Rdb01.Checked = True
                Else
                    Rdb02.Checked = True
                End If
                ' We validate if the invoice is affected '
                If Val(.Rows(0)("c_opc_inaf").ToString) = 1 Then
                    ChkInaf.Checked = True
                Else
                    ChkInaf.Checked = False
                End If
                If .Rows(0)("c_codi_mon").ToString = "01" Then CboMon.SelectedIndex = 0
                If .Rows(0)("c_Codi_mon").ToString = "02" Then CboMon.SelectedIndex = 1
                CboFPago.SelectedValue = .Rows(0)("c_codi_pago").ToString
                TxtCant_IGV.Text = Val(.Rows(0)("c_cant_igv").ToString)
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString
                TxtCod_Clie.Text = .Rows(0)("c_Codi_clie").ToString
                CboClie.SelectedValue = .Rows(0)("c_codi_clie").ToString
                CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                CboSerie.SelectedValue = .Rows(0)("c_nro_Serie").ToString
                TxtDir.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & " " & .Rows(0)("c_prov_clie").ToString _
                    & " " & .Rows(0)("c_dist_clie").ToString
                TxtDni.Text = .Rows(0)("c_dni_clie").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtBus.Text = .Rows(0)("c_nro_boleta").ToString
                TxtBoleta.Text = .Rows(0)("c_nro_boleta").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Vcto.Text = .Rows(0)("c_fecha_venci").ToString
                TxtAbrev.Text = .Rows(0)("c_abrev_clie").ToString
                ' Validamos el tipo de documento '
                For i = 0 To CboTpo.Items.Count - 1
                    If CboTpo.Items(i).ToString = .Rows(0)("c_tpo_venta").ToString Then
                        CboTpo.SelectedIndex = i : i = CboTpo.Items.Count
                    End If
                Next
                'Validamos si factura se encuentra anulada...
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then 'Validamos si factura esta cancelado
                    If Val(.Rows(0)("c_cancel_bol").ToString) = 1 Then
                        BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Drawing.Color.RoyalBlue
                    Else 'Validamos si factura se encuentra amortizado...
                        If Val(.Rows(0)("c_cancel_bol").ToString) = 2 Then
                            BtnEstado.Text = "AMORTIZADO" : BtnEstado.BackColor = Drawing.Color.SteelBlue
                        Else
                            BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon
                        End If
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                End If
                ''''''''''''''''''''Agregamos el Detalle''''''''''''''''''''''
                With c_Neg_BolGuia.get_BolGuia_Datos(" and B.c_serie_boleta='" & CboSerie.Text & "' and B.c_nro_boleta='" & TxtBoleta.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
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
                With c_Neg_BolDet.get_BolDet_Datos(" And D.c_nro_serie='" & CboSerie.Text & "' and D.c_nro_boleta='" & TxtBoleta.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                    Dgv02.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("Lote").Value = .Rows(i)("c_nro_lote").ToString
                            Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                            Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("Bultos").Value = .Rows(i)("c_cant_caja").ToString
                            Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), "##0")
                            Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_precio_venta").ToString), Forma_1_7)
                            Dgv02.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_total_bol").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("c_opc_afecto").Value = .Rows(i)("c_opc_afecto").ToString
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("c_correl_guia").Value = .Rows(i)("c_correl_guia").ToString
                        Next
                    End If
                End With
                ' Pesos '
                LblRollos.Text = Format(Val(.Rows(0)("c_bultos_bol").ToString), Forma_1_2)
                LblPeso.Text = Format(Val(.Rows(0)("c_peso_bol").ToString), Forma_2_2)
                ' Totales '
                LblDsctos.Text = Format(Val(.Rows(0)("c_dscto_bol").ToString), Forma_2_2)
                LblSub_Total.Text = Format(Val(.Rows(0)("c_venta_bol").ToString), Forma_2_2)
                LblTotales.Text = Format(Val(.Rows(0)("c_total_bol").ToString), Forma_2_2)
                ' Letras '
                LblLetras.Text = .Rows(0)("c_letras_bol").ToString
            Else
                Dgv02.Rows.Clear() : Dgv01.Rows.Clear()
            End If
        End With
    End Sub
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Boletas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_boleta= (select max(c_nro_boleta) from sca_" & FrmMenu.TxtCod_Emp.Text & "_bolcab where c_nro_serie='" & CboBus_Serie.Text & "')")
    End Sub
    'Retrocedemos registro...
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 1 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 10000000, 7)
            Call Mostrar_Boletas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_boleta='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 100000001, 7)
            Call Mostrar_Boletas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_boleta='" & TxtBus.Text & "'")
            '  TxtBus.Text = TxtFactura.Text
        End If
    End Sub

    Private Sub TxtBus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 10000000, 7)
                Call Mostrar_Boletas(" and c_nro_serie='" & CboBus_Serie.Text & "' and c_nro_boleta='" & TxtBus.Text & "'")
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
            If ValidarFactu("BOLETA", " and c_nro_serie='" & CboSerie.Text & "' and c_nro_boleta='" & TxtBoleta.Text & "' ") = True Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    Dim f As String = MsgBox("Confirma la eliminación del Registro...", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        Call Grabar_Boleta("DEL")
                        ' Grabamos Guias con Facturas '
                        With Dgv01
                            For i = 0 To .RowCount - 1
                                If .Rows(i).Cells("chk").Value = True Then
                                    Call Grabar_BolGuia(i, "DEL")
                                End If
                            Next
                        End With
                        BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                        MsgBox(" Registro se Anulo Correctamente... ", vbExclamation, Compañia)
                        ' Validamos si esta activa la facturacion electronica '
                        If FrmMenu.ChkElectronico.Checked = True Then
                            c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtBoleta.Text, "02", "DEL")
                        End If
                    End If
                Else
                    If UCase(BtnEstado.Text) = "ANULADO" Then
                        MsgBox("1. Registro se Encuentra anulado... ", vbCritical, Compañia)
                    Else
                        If Strings.Left(CboTpo.Text, 5) <> "VENTA" Then
                            Dim f As String = MsgBox("Confirma la eliminación del Registro...", vbYesNo + MsgBoxStyle.Question, Compañia)
                            If f = vbYes Then
                                Call Grabar_Boleta("DEL")
                                ' Grabamos Guias con Facturas '
                                With Dgv01
                                    For i = 0 To .RowCount - 1
                                        If .Rows(i).Cells("chk").Value = True Then
                                            Call Grabar_BolGuia(i, "DEL")
                                        End If
                                    Next
                                End With
                                BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Drawing.Color.Red
                                MsgBox(" Registro se Anulo Correctamente... ", vbExclamation, Compañia)
                                ' Validamos si esta activa la facturacion electronica '
                                If FrmMenu.ChkElectronico.Checked = True Then
                                    c_Neg_FactElectCab.set_FactElectCab_Save(CboSerie.Text, TxtBoleta.Text, "02", "DEL")
                                End If
                            End If
                        Else
                            MsgBox("2. Registro se encuentra cancelado...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'Imprimir Boleta...
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If IsNumeric(Strings.Left(CboSerie.Text, 1)) = True Then
            FrmReportes.Impresion_Boleta(CboSerie.Text, TxtBoleta.Text)
        Else
            If ValidarEnvio(CboSerie.Text, TxtBoleta.Text, "02", 0) = True Then
                '  Call Abrir_Pdf("6-" & FrmMenu.TxtRuc.Text &
                '            "\PDFLOCAL-" & FrmMenu.TxtRuc.Text & "-03-" & CboSerie.Text & "-0" & TxtBoleta.Text & ".pdf")
                Abrir_PDf_2(CboSerie.Text & "-0" & TxtBoleta.Text, "03", DtpFec_Emi.Text)
            End If
        End If
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
  
    'Historial de Documentos...
    Private Sub LnkHistorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and P.c_Serie_doc='" & CboSerie.Text & "' and P.c_nro_boleta='" & TxtBoleta.Text & "' ", "BOL")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub LnkHistoAnexos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistoAnexos.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoDocAnexos.MdiParent = FrmMenu : FrmConHistoDocAnexos.Show()
            FrmConHistoDocAnexos.Cargar_Grid(" and P.c_Serie_doc='" & CboSerie.Text & "' and P.c_nro_boleta='" & TxtBoleta.Text & "' ", "", "BOL")
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
            focos = 1 : BtnCon1.Focus()
        End If
    End Sub
    ' Cambiamos tipo de Moneda'
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        If Dgv02.RowCount > 0 Then
            MsgBox(" ¡Elimine las Guías seleccionadas para, para cambiar el tipo de Moneda...! ")
        Else
            LblImporte.Text = "Importe " & CboMon.Text
            LblDscto.Text = "Dscto. " & CboMon.Text
            LblTotal.Text = "Total " & CboMon.Text
        End If
    End Sub

    Private Sub CboClie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboClie.SelectedIndexChanged

    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Detalles() : Call Calcular_Totales()
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
                                Dgv02.Rows(F).Cells("Unid").Value = .Rows(u)("c_desc_unimed").ToString
                                Dgv02.Rows(F).Cells("c_codi_unimed").Value = .Rows(u)("c_codi_unimed").ToString
                                Dgv02.Rows(F).Cells("Bultos").Value = .Rows(u)("c_cant_caja").ToString
                                ' Calculamos el precio '
                                Dim x As New TextBox
                                Call Hallar_PrecioServ(" and S.c_codi_clie='" & TxtCod_Clie.Text & "' and S.c_codi_articulo='" & .Rows(u)("c_codi_articulo").ToString & _
                                                       "' and S.c_anula_Reg=0 ", x)
                                Dgv02.Rows(F).Cells("Precio").Value = Format(Val(x.Text) + (Val(x.Text) * (Val(TxtCant_IGV.Text) / 100)), Forma_1_4)
                                Dgv02.Rows(F).Cells("Cantidad").Value = Format(Val(.Rows(u)("c_nro_cant").ToString), Forma_1_2)
                                Dgv02.Rows(F).Cells("Importe").Value = Format(Val(Dgv02.Rows(F).Cells("Precio").Value) * Val(.Rows(u)("c_nro_cant").ToString), Forma_1_2)
                                Dgv02.Rows(F).Cells("c_opc_afecto").Value = 1
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

    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BtnCon1_LostFocus(sender As Object, e As System.EventArgs) Handles BtnCon1.LostFocus
        If focos = 1 Then
            focos = 0 : BtnCon1.Focus()
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

    Private Sub LnkComision_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkComision.LinkClicked
        FrmConComisDet.MdiParent = FrmMenu : FrmConComisDet.Show()
        FrmConComisDet.Cargar_Grid(" and D.c_Codi_doc='02' and D.c_serie_Doc='" & CboSerie.Text & "' and D.c_nro_doc='" &
                                                                                                TxtBoleta.Text & "' order by C.c_fecha_crea ")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Pan16.Visible = True Then
            If Prb01.Value = 100 Then
                Timer1.Stop()
                Pan16.Visible = False : Prb01.Value = 0
                Call BtnImprimir_Click(Nothing, Nothing)
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
            FrmBolAnexo.Cargar_Grid(" and (C.c_nro_serie + C.c_nro_boleta ='" & CboSerie.Text & TxtBoleta.Text &
                                "' or A.c_serie_anexo + A.c_boleta_anexo='" & CboSerie.Text & TxtBoleta.Text & "') order by C.c_fecha_emi ", "02")
            FrmBolAnexo.TxtVar.Text = 1 : FrmBolAnexo.txtCodClie.Text = TxtCod_Clie.Text
            FrmBolAnexo.TxtSerieDoc2.Text = CboSerie.Text
            FrmBolAnexo.TxtNroDoc2.Text = TxtBoleta.Text
        End If
    End Sub
End Class