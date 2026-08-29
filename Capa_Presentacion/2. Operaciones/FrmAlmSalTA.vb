Public Class FrmAlmSalTA
    Dim Focos As Integer = 0 : Dim Edit As Integer = 0

    Private Sub FrmAlmSalTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Pan11.Enabled = True Then
                Call BtnCancel_Click(Nothing, Nothing) : BtnAdd.Focus()
            End If
        End If
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmAlmSalTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmAlmSalTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie ", CboBusClie)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie ", CboCliente)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVende)
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnEmprServ.Get_EmpServ_Cbo(" and c_anula_reg=0 order by c_codi_empserv", CboEmpServ)
        c_Neg_mnmtmov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMot)
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboTpoDoc)
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboDocAnexo)
        ' Series de Documentos '
        With c_Neg_MnSeriesGuias.get_Series_Datos(" and c_anula_reg=0 order by c_nro_serie", "DAT", FrmMenu.TxtCod_Emp.Text)
            CboSerie.Items.Clear() : CboBusSerie.Items.Clear()
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    CboSerie.Items.Add(.Rows(i)("c_nro_serie").ToString)
                    CboBusSerie.Items.Add(.Rows(i)("c_nro_serie").ToString)
                Next
            End If
        End With
        Call Cancelar_Detalles()
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid()
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub TxtAbv_Clie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAbv_Clie.KeyDown
        If Len(TxtAbv_Clie.Text) > 0 Then
            If e.KeyCode = Keys.Enter Then
                With c_Neg_MnCliente.get_Cliente_Datos(" and c_abrev_clie='" & TxtAbv_Clie.Text & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                        CboCliente.SelectedValue = TxtCod_Clie.Text
                        Focos = 1 : TxtObs.Focus()

                    End If
                End With
            End If
        End If
    End Sub

    Private Sub TxtAbv_Clie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAbv_Clie.TextChanged

    End Sub

    Private Sub CboCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboCliente.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.F4 Then Call CboCliente_SelectedIndexChanged(Nothing, Nothing)
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : CboEmpServ.Focus()
        End If
    End Sub

    Private Sub CboCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCliente.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCliente.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboCliente, TxtCod_Clie)
        If Val(TxtOpc_Prove.Text) = 1 Then
            CboDireccion.DataSource = Nothing
            Pan22.Enabled = True
            With c_Neg_MnProve.get_Prove_Datos(" AND c_codi_prov='" & TxtCod_Clie.Text & "'", "DAT")
                If .Rows.Count > 0 Then
                    TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                    TxtUbigeo.Text = .Rows(0)("c_codi_ubigeo").ToString
                    CboDireccion.Text = StrConv(.Rows(0)("c_direc_prov").ToString, vbProperCase)
                    TxtDist.Text = StrConv(.Rows(0)("c_dist_prov").ToString, vbProperCase)
                    TxtProvincia.Text = StrConv(.Rows(0)("c_ciudad_prov").ToString, VbStrConv.ProperCase)
                    TxtDpto.Text = StrConv(.Rows(0)("c_ciudad_prov").ToString, VbStrConv.ProperCase)
                End If
            End With
        Else
            Pan22.Enabled = False
            Call Mostrar_Cliente_Abrev(TxtCod_Clie.Text, TxtAbv_Clie)
            ' Validamos si el cliente es prueba o formal '
            With c_Neg_MnCliente.get_Cliente_Datos(" AND c_codi_clie='" & TxtCod_Clie.Text & "'", "DAT")
                If .Rows.Count > 0 Then
                    CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                    TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                    TxtUbigeo.Text = .Rows(0)("c_codi_ubigeo").ToString
                    c_Neg_MnClienteOfi.get_ClienteOfi_Cbo(" and O.c_anula_Reg=0 and O.c_codi_clie='" & TxtCod_Clie.Text &
                                                          "' order by c_codi_oficina", CboDireccion)

                    If CboDireccion.Items.Count > 0 Then CboDireccion.SelectedIndex = 0

                    CboDireccion.Text = StrConv(.Rows(0)("c_direc_clie").ToString, vbProperCase)
                    TxtDist.Text = StrConv(.Rows(0)("c_dist_clie").ToString, vbProperCase)
                    TxtProvincia.Text = StrConv(.Rows(0)("c_prov_clie").ToString, VbStrConv.ProperCase)
                    TxtDpto.Text = StrConv(.Rows(0)("c_ciudad_clie").ToString, VbStrConv.ProperCase)
                End If
            End With
        End If

    End Sub
    Private Sub CboVende_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboVende.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboVende_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboVende_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboVende.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboVende_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboVende.LostFocus
        If Focos = 1 Then
            Focos = 0 : CboVende.Focus()
        End If
    End Sub

    Private Sub CboVende_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboVende.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboVende, TxtCod_Vende)
    End Sub
    Private Sub CboTurno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlm.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboTurno_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboTurno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboAlm.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlm.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboAlm, TxtCod_Almacen)
    End Sub

    Private Sub TxtPartida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    ' Metodo para Calcular detalle por precio '
    Private Sub Calcular_Precio_Color(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("c_total_guia").Value = Val(.Rows(Fila).Cells("c_prec_color").Value) + Val(.Rows(Fila).Cells("c_prec_serv1").Value) +
            Val(.Rows(Fila).Cells("c_prec_serv2").Value) + Val(.Rows(Fila).Cells("c_prec_serv3").Value) +
            Val(.Rows(Fila).Cells("c_prec_serv4").Value) + Val(.Rows(Fila).Cells("c_prec_serv5").Value) +
            Val(.Rows(Fila).Cells("c_prec_serv6").Value) + Val(.Rows(Fila).Cells("c_prec_serv7").Value) +
            Val(.Rows(Fila).Cells("c_prec_serv8").Value) + Val(.Rows(Fila).Cells("c_prec_serv9").Value)
            .Rows(Fila).Cells("c_total_guia").Value = Format(Val(.Rows(Fila).Cells("c_total_guia").Value) * Val(.Rows(Fila).Cells("Peso_Crudo").Value), Forma_1_2)
        End With
    End Sub
    '-- Metodo para Hallar el Precio Unitario--'
    Private Sub Hallar_PrecioServ(ByVal Cadena As String, ByVal x As TextBox)
        With c_Neg_MnClienteArt.get_ClienteArt_Datos(Cadena, "DAT")
            If .Rows.Count > 0 Then
                x.Text = Val(.Rows(0)("c_precio_srv_us").ToString)
            Else
                x.Text = 0
            End If
        End With
    End Sub
    ' Metodo que nos permite Calcular el Precio por Servicios '
    ' Metodo para un nuevo Detalles '
    Private Sub Nuevo_Detalles()
        With Dgv02
            .Size = New Size(942, 176) : .Location = New Point(1, 48)
            Call Limpiar_Texto(Pan04) : Pan04.Enabled = True : TxtCantidad.Focus()
            Pan11.Enabled = True : Pan10.Enabled = False : .Enabled = False
        End With
    End Sub
    ' Metodo para un cancelar Detalles '
    Private Sub Cancelar_Detalles()
        With Dgv02
            .Size = New Size(942, 202) : .Location = New Point(1, 22)
            Call Limpiar_Texto(Pan04) : Pan04.Enabled = False
            Pan11.Enabled = False : Pan10.Enabled = True : .Enabled = True : BtnConArt.Enabled = False
        End With
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub
    ' Metodo para Calcular Detalles '
    Private Sub Calcular_Totales()
        Dim Tot_Caja As Integer = 0 : Dim Tot_Importe As Decimal = 0 : Dim Tot_Peso As Decimal = 0 'Total importe de guia de remision
        With Dgv02
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("anula").Value) = 0 Then
                    Tot_Caja = Tot_Caja + Val(.Rows(i).Cells("Bultos").Value)
                    Tot_Peso = Tot_Peso + Val(.Rows(i).Cells("Cantidad").Value)
                    Tot_Importe = Tot_Importe + Val(.Rows(i).Cells("Importe").Value)
                End If
            Next
            TxtTotCajas.Text = Format(Tot_Caja, Forma_1_2)
            TxtTot_Peso.Text = Format(Tot_Peso, Forma_1_2)
            TxtTot_Importe.Text = Tot_Importe
        End With
    End Sub
    ' Agregamos Registro '
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Focos = 1
        Call Nuevo_Detalles() : TxtCantidad.Enabled = True : TxtBultos.Enabled = True : TxtObs2.Enabled = True
        TxtCantidad.Focus() : BtnConArt.Enabled = True
    End Sub
    Private Sub Mostrar_Detalles(ByVal Fila As Integer)
        With Dgv02
            Edit = 1
            Call Nuevo_Detalles()
            TxtCantidad.Text = .Rows(Fila).Cells("Cantidad").Value
            TxtUniMed.Text = .Rows(Fila).Cells("Unid").Value
            TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
            TxtDescripcion.Text = .Rows(Fila).Cells("Articulo").Value
            TxtBultos.Text = .Rows(Fila).Cells("Bultos").Value
            TxtObs2.Text = .Rows(Fila).Cells("c_obs").Value
            TxtItem.Text = .Rows(Fila).Cells("Item").Value
            TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
        End With
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Anula").Value) = 1 Then
                        MsgBox("Registro se encuentra anulado, no puede ser eliminado...", vbCritical, Compañia)
                    Else
                        'Validamos si registro se grabo correctamente anteriormente...
                        Dim F As String = MsgBox("¿Confirma la Eliminación del Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            If Val(.Rows(Fila).Cells("Item").Value) = 0 Then
                                Dgv02.Rows.RemoveAt(Fila)
                            Else
                                Dgv02.Rows(Fila).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
                                Dgv02.Rows(Fila).Cells("Anula").Value = 1
                            End If
                            Call Calcular_Totales()
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    ' Metodo para validar el detalle '
    Public Function ValidarDetalles() As Boolean
        If Len(TxtCodigo.Text) > 0 Then
            If Val(TxtCantidad.Text) > 0 Then
                If Val(TxtCantidad.Text) <= Val(TxtStock.Text) Then
                    ValidarDetalles = True
                Else
                    If TxtCod_Mt.Text = "05" Then
                        ValidarDetalles = True
                    Else
                        MsgBox("1. Falta Ingresar una Cantidad Valida...", vbCritical, Compañia)
                        ValidarDetalles = False
                    End If
                End If
            Else
                MsgBox("2. Falta Ingresar el seleccionar el Artículo...", vbCritical, Compañia)
                ValidarDetalles = False
            End If
        Else
            MsgBox("3. Stock Insuficiente no puede vender mas de: " & Format(Val(TxtStock.Text), Forma_1_2), vbCritical, Compañia)
            ValidarDetalles = False
        End If
    End Function
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv02
            If ValidarDetalles() = True Then
                If Edit = 0 Then
                    .Rows.Add()
                    Call Agregar_Registro(.RowCount - 1)
                Else
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    Call Agregar_Registro(Fila)
                End If
                Call Calcular_Totales() : Focos = 1 : BtnAdd.Focus() : Call Dgv02_SelectionChanged(Nothing, Nothing)
            End If
        End With
    End Sub
    Private Sub Agregar_Registro(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCantidad.Text), Forma_1_4)
            .Rows(Fila).Cells("c_cant_fraccion").Value = TxtCantidad.Text
            .Rows(Fila).Cells("Unid").Value = TxtUniMed.Text
            .Rows(Fila).Cells("c_codi_unimed").Value = TxtCod_UniMed.Text
            .Rows(Fila).Cells("Codigo").Value = TxtCodigo.Text
            .Rows(Fila).Cells("Articulo").Value = TxtDescripcion.Text
            .Rows(Fila).Cells("Bultos").Value = Val(TxtBultos.Text)
            .Rows(Fila).Cells("c_Obs").Value = TxtObs2.Text
            .Rows(Fila).Cells("Precio").Value = Val(TxtPrecio.Text)
            .Rows(Fila).Cells("Importe").Value = Format(Val(TxtCantidad.Text) * Val(TxtPrecio.Text), Forma_1_2)
            .Rows(Fila).Cells("c_codi_mon").Value = TxtCod_Mon.Text
            .Rows(Fila).Cells("Lote").Value = ""
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            Call Cancelar_Detalles() : Focos = 1 : BtnAdd.Focus() : Edit = 0
        End With
    End Sub


    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub

    Private Sub CboPlaca_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : CboChofer.Focus()
        End If
    End Sub

    Private Sub CboPlaca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPlaca.SelectedIndexChanged
        With c_Neg_MnTransporte.get_Transporte_Datos(" AND T.c_placa_trp='" & CboPlaca.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtVehiculo.Text = .Rows(0)("c_vehiculo_trp").ToString
                TxtTransp_Color.Text = .Rows(0)("c_color_trp").ToString
            End If
        End With
    End Sub

    Private Sub CboTransp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMot.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboMot, TxtCod_Mt)
        ' Validamos si trabajamos con clientes o proveedores
        With c_Neg_mnmtmov.get_MtMov_Datos(" and c_codi_mt='" & TxtCod_Mt.Text & "' ", "DAT")
            If .Rows.Count > 0 Then
                TxtOpc_Prove.Text = Val(.Rows(0)("c_opc_prove").ToString)
                Pan22.Enabled = True
            End If
        End With
        CboVende.SelectedValue = "00"
        If Val(TxtOpc_Prove.Text) = 1 Then ' Transformaciones '
            c_Neg_MnProve.get_MtProve_Cbo(" AND C_anula_reg=0 order by c_desc_prov", CboCliente)
            LblCliente.Text = "Proveedor"
            Pan22.Enabled = False
            CboDocAnexo.SelectedIndex = -1
            Call Limpiar_Texto(Pan22)
        Else
            Pan22.Enabled = True
            Call Limpiar_Texto(Pan22)
            c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboCliente)
            LblCliente.Text = "Cliente"
            ' Validamos si es envases '
            If TxtCod_Mt.Text = "03" Then
                Pan21.Enabled = True
            Else
                If TxtCod_Mt.Text = "09" Then
                    TxtNro_Ing.Enabled = True
                Else
                    Pan21.Enabled = False
                End If
            End If
        End If
        TxtCod_Clie.Clear()
    End Sub

    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        With c_Neg_MnSeriesGuias.get_Series_Datos(" AND c_nro_serie='" & CboSerie.Text & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                If Len(TxtNro_Guia.Text) = 0 Then
                    TxtNro_MosGuia.Text = Strings.Right(Val(.Rows(0)("c_nro_guia").ToString) + 10000001, 7)
                    CboCliente.Enabled = True : TxtAbv_Clie.Enabled = True
                    TxtCod_Clie.Clear() : TxtAbv_Clie.Clear() : CboCliente.Text = ""
                End If
            End If
        End With
    End Sub
    ' funcion para validar datos
    Private Function ValidarDatos() As Boolean
        If Len(TxtDist.Text) > 0 And Len(TxtProvincia.Text) > 0 And Len(TxtDpto.Text) > 0 Then
            If Len(CboDireccion.Text) > 0 Then
                If Len(TxtUbigeo.Text) >= 5 Then
                    If Len(CboPlaca.Text) >= 5 Then
                        If CboEmpServ.SelectedIndex > -1 Then
                            If CboMot.SelectedIndex > -1 Then
                                If CboSerie.SelectedIndex > -1 Then
                                    If Len(TxtCod_Clie.Text) > 0 Then
                                        If Len(TxtCod_Almacen.Text) > 0 Then
                                            ValidarDatos = True
                                        Else
                                            ValidarDatos = False
                                            MsgBox("1. Falta Seleccionar el Almacen...", vbCritical, Compañia)
                                        End If
                                    Else
                                        ValidarDatos = False
                                        MsgBox("2. Falta Seleccionar el Cliente...", vbCritical, Compañia)
                                    End If
                                Else
                                    ValidarDatos = False
                                    MsgBox("3. Falta Seleccionar la Serie de Guia Remisión...", vbCritical, Compañia)
                                End If
                            Else
                                ValidarDatos = False : CboMot.Focus()
                                MsgBox("4. Falta seleccionar el motivo de la salida...", vbCritical, Compañia)
                            End If
                        Else
                            ValidarDatos = False : CboEmpServ.Focus()
                            MsgBox("5. Falta seleccionar la empresa de servicio...", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False : CboPlaca.Focus()
                        MsgBox("6. Falta seleccionar el vehiculo...", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False : TxtUbigeo.Focus()
                    MsgBox("7. Falta ingresar el ubigeo...", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False : CboEmpServ.Focus()
                MsgBox("8. Falta ingresar la direccion de envio...", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False : TxtDist.Focus()
            MsgBox("9. Falta ingresar el distrito, provincia o departamento...", vbCritical, Compañia)
        End If


    End Function
    Private Function ValidarElectronica() As Boolean
        If ValidarGuiaElectronica(CboSerie.Text) = True Then
            If Len(TxtUbigeo.Text) >= 5 Then
                If Len(TxtLicencia.Text) >= 8 Then
                    If Len(TxtDni.Text) >= 8 Then
                        If Len(TxtApeChofer.Text) > 0 Then
                            If Len(CboChofer.Text) > 0 Then
                                If Len(CboChofer.Text) > 0 Then
                                    ValidarElectronica = True
                                Else
                                    MsgBox("1. Falta ingresar los datos del chofer...", vbCritical, Compañia)
                                    ValidarElectronica = False
                                End If
                            Else
                                MsgBox("1. Falta ingresar los datos del chofer...", vbCritical, Compañia)
                                ValidarElectronica = False
                            End If
                        Else
                            MsgBox("2. Falta ingresar los datos del chofer...", vbCritical, Compañia)
                            ValidarElectronica = False
                        End If
                    Else
                        MsgBox("1. Falta ingresar dni del chofer...", vbCritical, Compañia)
                        ValidarElectronica = False
                    End If
                Else
                    MsgBox("1. Falta ingresar brevete del chofer...", vbCritical, Compañia)
                    ValidarElectronica = False
                End If
            Else
                MsgBox("1. Falta ingresar ubigeo...", vbCritical, Compañia)
                ValidarElectronica = False
            End If
        Else
            ValidarElectronica = True
        End If
    End Function
    Private Function ValidarOficina() As Boolean
        If UCase(LblCliente.Text) = "CLIENTE" Then
            If Strings.Left(CboSerie.Text, 2) = "OT" Then
                If Len(TxtCodiOficina.Text) = 5 Then
                    ValidarOficina = True
                Else
                    MsgBox("Es necesario seleccionar la oficina de llegada...", vbCritical, Compañia)
                    ValidarOficina = False
                End If
            Else
                ValidarOficina = True
            End If
        Else
            ValidarOficina = True
        End If
    End Function
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            If ValidarOficina() = True Then
                If ValidarElectronica() Then
                    Dim F As String = MsgBox("¿Desea Grabar el Registro?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_SalidaTA("ADD")
                        ' Validamos que se haya grabado correctamente...
                        If Len(TxtNro_Guia.Text) > 0 Then
                            With Dgv02
                                For i = 0 To .RowCount - 1
                                    If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                                        Call Grabar_SalidaTADet(i, "ADD")
                                    Else
                                        Call Grabar_SalidaTADet(i, "DEL")
                                    End If
                                Next
                            End With

                            ' We validate if is provider '
                            If Val(TxtOpc_Prove.Text) = 1 Then
                                Call RellenarCeros()
                                Call GrabarDocAnexos("ADD")
                            End If
                            BtnGrabar.Enabled = False : Call BtnMostrar_Click(Nothing, Nothing)

                            MsgBox(" Registro se Grabo Correctamente... ", vbExclamation, Compañia)
                            ' imprimir guias de prueba
                            If ValidarGuiaElectronica(CboSerie.Text) = True Then
                                c_Neg_AlmSalTA.set_GuiaElectronica_Save(CboSerie.Text, TxtNro_Guia.Text, "", "ADD")
                                '   AbrirArchivoGuiaPDF(CboSerie.Text & "-0" & TxtNro_Guia.Text)
                            Else
                                If CboSerie.Text = "100" Then
                                    FrmReportes.Impresion_SalidaTA_Prueba(CboSerie.Text, TxtNro_Guia.Text)
                                Else
                                    FrmReportes.Impresion_SalidaTA(CboSerie.Text, TxtNro_Guia.Text)
                                End If
                            End If

                        Else
                            MsgBox("1. Hubo problemas al momento de grabar la Guía si el problema persiste comunicarse con el area de Sistemas...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    ' method for save documents anexos
    Private Sub GrabarDocAnexos(cOpcion As String)
        With c_Ent_AlmSalAnexo
            .C_nro_correl = 0
            .C_serie_guia = CboSerie.Text
            .C_nro_guia = TxtNro_Guia.Text
            .C_codi_doc = TxtDocAnexo.Text
            .C_nro_serie = TxtSerieDocAnexo.Text
            .C_nro_doc = TxtNroDocAnexo.Text
            c_Neg_AlmSalTAAnexo.set_Registro_Save(c_Ent_AlmSalAnexo, cOpcion)
        End With
    End Sub
    ' Grabamos Salida de TA '
    Private Sub Grabar_SalidaTA(ByVal cOpcion As String)
        With c_Ent_AlmSalTa
            .c_nro_serie = CboSerie.Text
            .c_nro_salidaTA = TxtNro_Guia.Text
            .c_nro_ing = TxtNro_Ing.Text
            ' Validamos si es proveedor o cliente '
            If Val(TxtOpc_Prove.Text) > 0 Then
                .c_codi_clie = ""
                .c_codi_prov = TxtCod_Clie.Text
            Else
                .c_codi_clie = TxtCod_Clie.Text
                .c_codi_prov = ""
            End If
            .c_fecha_sal = DateTime.Now
            .c_fecha_traslado = IIf(Len(DtpFecha_Traslado.Text) > 0, DtpFecha_Traslado.Text, Now.Date)
            .c_nro_os = TxtNroOS.Text
            .c_codi_alm = TxtCod_Almacen.Text
            .c_codi_mt = CboMot.SelectedValue
            .c_codi_placa = CboPlaca.Text

            .c_codi_ubigeo = TxtUbigeo.Text
            .c_codi_oficina = TxtCodiOficina.Text
            .c_direcc_trp = CboDireccion.Text
            .c_dist_trp = TxtDist.Text
            .c_prov_trp = TxtProvincia.Text
            .c_dpto_trp = TxtDpto.Text
            .c_chofer_trp = CboChofer.Text
            .c_ape_chofer = TxtApeChofer.Text

            .c_vehiculo_trp = TxtVehiculo.Text

            .c_color_trp = TxtTransp_Color.Text
            .c_abrevcte_trp = TxtCod_EmpServ.Text
            .c_desccte_trp = CboMot.Text
            .c_ruc_trp = TxtRuc.Text
            .c_nro_lic = TxtLicencia.Text

            .c_nro_dni = TxtDni.Text
            .c_peso_neto = Val(TxtTot_Peso.Text)
            .c_cajas_total = Val(TxtTotCajas.Text)
            .c_total_guia = Val(TxtTot_Importe.Text)
            .c_obs = TxtObs.Text

            .c_codi_doc = TxtCod_Doc.Text
            .c_serie_doc = TxtSerie.Text
            .c_nro_doc = TxtNro_Doc.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion

            If Len(TxtNro_Guia.Text) = 0 Then
                TxtNro_Guia.Text = c_Neg_AlmSalTA.set_AlmSalTa_Save(c_Ent_AlmSalTa, FrmMenu.TxtCod_Emp.Text)
                TxtNro_MosGuia.Text = TxtNro_Guia.Text
            Else
                c_Neg_AlmSalTA.set_AlmSalTa_Save(c_Ent_AlmSalTa, FrmMenu.TxtCod_Emp.Text)
            End If

        End With
    End Sub
    ' Grabamos Detalles de la Salida TA '
    Private Sub Grabar_SalidaTADet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_AlmSalTaDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_serie = CboSerie.Text
            .c_nro_salidaTA = TxtNro_Guia.Text
            .c_nro_lote = Dgv02.Rows(Fila).Cells("Lote").Value
            .c_opt_fraccion = Dgv02.Rows(Fila).Cells("c_opt_fraccion").Value
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed").Value
            .c_nro_cant = Val(Dgv02.Rows(Fila).Cells("Cantidad").Value)
            .c_cant_fraccion = Dgv02.Rows(Fila).Cells("c_cant_fraccion").Value
            .c_cant_caja = Val(Dgv02.Rows(Fila).Cells("Bultos").Value)
            .c_cant_fraccion = Dgv02.Rows(Fila).Cells("c_cant_fraccion").Value
            .c_prec_unit = Val(Dgv02.Rows(Fila).Cells("Precio").Value)
            .c_imp_total = Val(Dgv02.Rows(Fila).Cells("Importe").Value)
            .c_codi_mon = "02"
            If Len(Dgv02.Rows(Fila).Cells("c_correl_ing").Value) > 0 Then
                .c_correl_ing = Dgv02.Rows(Fila).Cells("c_correl_ing").Value
            Else
                .c_correl_ing = ""
            End If

            .c_obs = Dgv02.Rows(Fila).Cells("c_obs").Value
            .copcion = cOpcion
            c_Neg_AlmSalTADet.set_AlmSalTaDet_Save(c_Ent_AlmSalTaDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro() : BtnGrabar.Enabled = True : CboCliente.Focus()
        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
        TxtCod_Mt.Enabled = False : CboAlm.SelectedIndex = 0 : CboVende.SelectedIndex = 0
        CboSerie.SelectedIndex = 1 : DtpFecha_Traslado.Text = Now.Date : DtpFecha_Traslado.Enabled = True
        ' Validamos la serie de la guia '
        If Len(FrmMenu.TxtSerie_Guia.Text) > 0 Then
            For i = 0 To CboSerie.Items.Count - 1
                If CboSerie.Items(i).ToString = FrmMenu.TxtSerie_Guia.Text Then
                    CboSerie.SelectedIndex = i : i = CboSerie.Items.Count
                End If
            Next
        End If

        CboCliente.Focus()
        With c_Neg_mnmtmov.get_MtMov_Datos(" and c_opc_defecto='1' and c_anula_reg=0", "DAT")
            If .Rows.Count > 0 Then
                CboMot.SelectedValue = .Rows(0)("c_codi_mt").ToString
            Else
                CboMot.SelectedIndex = 9
            End If
        End With

    End Sub
    ' Nuevo Detalle '
    Private Sub Nuevo_Registro()
        Dgv02.Rows.Clear() : CboCliente.Enabled = True : TxtAbv_Clie.Enabled = True : TxtAbv_Clie.Focus() : TxtObs.Enabled = True
        Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan07) : Call Limpiar_Texto(Pan08) : Call Limpiar_Texto(Grb03) : Call Limpiar_Texto(Grb02)
        TxtNro_Guia.Clear() : TxtNro_MosGuia.Clear() : Pan10.Enabled = True : Pan11.Enabled = False : TxtObs.Clear()
        TxtAbv_Clie.Clear() : TxtCod_Clie.Clear() : CboCliente.SelectedIndex = -1 : CboCliente.Text = "" : CboAlm.Enabled = True
        CboVende.SelectedValue = "" : CboAlm.SelectedValue = "" : Call Limpiar_Texto(Pan09) : CboSerie.Enabled = True
        Call Activar(Grb02) : CboSerie.SelectedIndex = -1 : TxtCodiOficina.Enabled = False
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        Tbc01.SelectedTab = Tab01 : Call Cancela_Registro()
    End Sub
    ' Cancelar Registro '
    Private Sub Cancela_Registro()
        Dgv02.Rows.Clear() : CboCliente.Enabled = False : TxtAbv_Clie.Enabled = False : TxtObs.Enabled = False
        Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan07) : Call Limpiar_Texto(Pan08) : Call Limpiar_Texto(Grb03)
        TxtNro_Guia.Clear() : TxtNro_MosGuia.Clear() : BtnGrabar.Enabled = False : Call Cancelar_Detalles()
        DtpFecha_Traslado.Enabled = False
    End Sub

    Private Sub Dgv02_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        With Dgv01
            If e.RowIndex = -1 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then .Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
                Next
            End If
        End With
    End Sub

    Private Sub Dgv02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.DoubleClick
        'If Pan10.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub Dgv02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.SelectionChanged

    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If Len(CboBusClie.Text) > 0 Then
            Call Cargar_Grid(" and S.c_fecha_sal>='" & DtpFec_Inicio.Text & "' and S.c_fecha_sal<='" & DateAdd("d", 1, DtpFec_Final.Text) &
                         "' and Cl.c_desc_clie like '" & CboBusClie.Text & "%' ", "DGC")
        Else
            Call Cargar_Grid(" and S.c_fecha_sal>='" & DtpFec_Inicio.Text & "' and S.c_fecha_sal<='" & DateAdd("d", 1, DtpFec_Final.Text) &
                       "'  ", "DGV")
        End If

        TxtBus_Guia.Clear() : TxtBus_Partida.Clear()
    End Sub
    ' Metodo que nos permite cargar el Grid '
    Public Sub Cargar_Grid(ByVal Cadena As String, ByVal vOpt As String)
        With Dgv01
            .DataSource = c_Neg_AlmSalTA.get_AlmSalTa_Datos(Cadena, vOpt, FrmMenu.TxtCod_Emp.Text)
            .Columns("E").Width = 20
            .Columns("Nro.").Width = 45
            .Columns("Salida").Width = 60
            .Columns("Fecha Despacho").Width = 120
            .Columns("Cliente/Proveedor").Width = 240
            .Columns("Observaciones").Width = 185
            .Columns("Placa").Width = 80
            .Columns("Chofer").Width = 160
            .Columns("Licencia").Width = 90
            .Columns("Dni").Width = 90
            ' Visible '
            .Columns("c_anula_reg").Visible = False
            .Columns("c_opc_guia").Visible = False
            .Columns("c_fact_guia").Visible = False
            ' Alineacion '
            .Columns("Nro.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Despacho").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Placa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("E").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Coloreamos cabecera '
            .Columns("fecha despacho").HeaderCell.Style.BackColor = Drawing.Color.Yellow
            .Columns("fecha despacho").HeaderCell.Style.ForeColor = Drawing.Color.Black
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
                End If
            Next
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            Call colorearGuia()
        End With
    End Sub
    ' funcion para colorear rechazados
    Private Sub colorearGuia()
        With Dgv01
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("E").Value = "L" Then
                    .Rows(i).Cells("E").Style.BackColor = Drawing.Color.Yellow
                    .Rows(i).Cells("E").Style.ForeColor = Drawing.Color.Blue

                End If
                If .Rows(i).Cells("E").Value = "P" Then
                    .Rows(i).Cells("E").Style.BackColor = Drawing.Color.Blue
                    .Rows(i).Cells("E").Style.ForeColor = Drawing.Color.White
                End If
                If .Rows(i).Cells("E").Value = "R" Then
                    .Rows(i).Cells("E").Style.BackColor = Drawing.Color.Red
                    .Rows(i).Cells("E").Style.ForeColor = Drawing.Color.White
                End If
                If .Rows(i).Cells("E").Value = "E" Then
                    .Rows(i).Cells("E").Style.BackColor = Drawing.Color.Orange
                    .Rows(i).Cells("E").Style.ForeColor = Drawing.Color.White
                End If

            Next
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
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            Dim Fila As Integer = Dgv01.CurrentCellAddress.Y
            If Fila > -1 Then
                Call Mostrar_SalidaTA(Dgv01.Rows(Fila).Cells("Nro.").Value, Dgv01.Rows(Fila).Cells("Salida").Value)
                CboVende.Enabled = False : CboAlm.Enabled = False : CboCliente.Enabled = False : TxtAbv_Clie.Enabled = False
                TxtObs.Enabled = False : Pan10.Enabled = False : Pan11.Enabled = False : BtnGrabar.Enabled = False : Call Desactivar(Grb02)
                CboSerie.Enabled = False
            End If
        End If
        If Tbc01.SelectedIndex = 0 Then Call Cancela_Registro()
    End Sub
    Private Sub Mostrar_SalidaTA(ByVal c_nro_serie As String, ByVal c_nro_salida As String)
        With c_Neg_AlmSalTA.get_AlmSalTa_Datos(" And S.c_nro_serie='" & c_nro_serie & "' And S.c_nro_salidaTA='" & c_nro_salida & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Nuevo_Registro()
            If .Rows.Count > 0 Then
                For i = 0 To CboSerie.Items.Count - 1
                    If CboSerie.Items(i).ToString = c_nro_serie Then
                        CboSerie.SelectedIndex = i : i = CboSerie.Items.Count
                    End If
                Next
                DtpFecha_Traslado.Text = .Rows(0)("c_fecha_traslado").ToString
                TxtNroOS.Text = .Rows(0)("c_nro_os").ToString

                CboEmpServ.SelectedValue = .Rows(0)("c_abrevcte_trp").ToString
                TxtNro_Ing.Text = .Rows(0)("c_nro_ing").ToString
                TxtNro_Guia.Text = .Rows(0)("c_nro_salidaTA").ToString
                TxtNro_MosGuia.Text = .Rows(0)("c_nro_salidaTA").ToString
                TxtUbigeo.Text = .Rows(0)("c_codi_ubigeo").ToString
                CboMot.SelectedValue = .Rows(0)("c_codi_mt").ToString

                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtAbv_Clie.Text = .Rows(0)("c_abrev_clie").ToString
                CboCliente.Text = .Rows(0)("c_desc_clie").ToString
                CboPlaca.SelectedValue = .Rows(0)("c_codi_placa").ToString
                TxtVehiculo.Text = .Rows(0)("c_vehiculo_trp").ToString
                CboChofer.Text = .Rows(0)("c_chofer_trp").ToString
                TxtApeChofer.Text = .Rows(0)("c_ape_chofer").ToString

                CboDireccion.Text = .Rows(0)("c_direcc_trp").ToString
                TxtDist.Text = .Rows(0)("c_dist_trp").ToString
                TxtDpto.Text = .Rows(0)("c_dpto_trp").ToString
                TxtProvincia.Text = .Rows(0)("c_prov_trp").ToString
                TxtCodiOficina.Text = .Rows(0)("c_codi_oficina").ToString
                TxtLicencia.Text = .Rows(0)("c_nro_lic").ToString
                TxtDni.Text = .Rows(0)("c_nro_dni").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_trp").ToString

                CboAlm.SelectedValue = .Rows(0)("c_codi_alm").ToString
                CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString

                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                ' Totales '
                TxtTotCajas.Text = Format(Val(.Rows(0)("c_cajas_total").ToString), Forma_1_2)
                TxtTot_Peso.Text = Format(Val(.Rows(0)("c_peso_total").ToString), Forma_1_2)
                TxtTot_Importe.Text = Format(Val(.Rows(0)("c_total_guia").ToString), Forma_1_2)
                ' Tipo de Documentos '
                TxtSerie.Text = .Rows(0)("c_serie_fact").ToString
                TxtNro_Doc.Text = .Rows(0)("c_nro_fact").ToString
                CboTpoDoc.SelectedValue = .Rows(0)("c_codi_doc").ToString
                TxtCod_Doc.Text = .Rows(0)("c_codi_doc").ToString
                ' Validamos si esta anulado o pendiente '
                If Val(.Rows(0)("c_anula_Reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_fact_guia").ToString) = 0 Then
                        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
                    Else
                        BtnEstado.Text = "Facturado" : BtnEstado.BackColor = Color.Blue
                    End If
                Else
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                End If
                'Cargamos el Detalle...
                Dgv02.Rows.Clear()
                With c_Neg_AlmSalTADet.get_AlmSalTaDet_Datos(" And D.c_nro_serie='" & c_nro_serie & "'  And D.c_nro_salidaTA='" & c_nro_salida & "' order by D.c_nro_correl", "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Lote").Value = .Rows(i)("c_nro_lote").ToString
                            Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                            Dgv02.Rows(i).Cells("Articulo").Value = .Rows(i)("c_desc_articulo").ToString
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("Anula").Value = .Rows(i)("c_anula_reg").ToString
                            Dgv02.Rows(i).Cells("Bultos").Value = Format(Val(.Rows(i)("c_cant_caja").ToString), Forma_1_1)
                            Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                            Dgv02.Rows(i).Cells("c_cant_fraccion").Value = Format(Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("Devol").Value = Format(Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("c_obs").Value = .Rows(i)("c_obs").ToString
                            Dgv02.Rows(i).Cells("Devol").Value = Val(.Rows(i)("c_cant_devol").ToString)
                            Dgv02.Rows(i).Cells("c_codi_mon").Value = .Rows(i)("c_codi_mon").ToString
                            Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("c_correl_ing").Value = .Rows(i)("c_correl_ing").ToString
                            Dgv02.Rows(i).Cells("c_opt_fraccion").Value = Val(.Rows(i)("c_opt_fraccion").ToString)
                            ' Validamos el color de Fila '
                            If Val(.Rows(i)("c_anula_reg").ToString) = 1 Then
                                Dgv02.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
                            End If
                        Next

                    End If
                End With

            End If
        End With
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = Dgv01.CurrentCellAddress.Y
                If Fila > -1 Then
                    If ValidarFactu("GUIA", " and S.c_nro_serie='" & .Rows(Fila).Cells("Nro.").Value & "' and S.c_nro_salidaTA='" & .Rows(Fila).Cells("Salida").Value & "' ") = True Then
                        If Val(Dgv01.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                            If Val(.Rows(Fila).Cells("c_fact_guia").Value) = 0 Then
                                If ValidarCierre(.Rows(Fila).Cells("Fecha Despacho").Value) = True Then
                                    If ValidarGuiaTransferencia(.Rows(Fila).Cells("Nro.").Value, .Rows(Fila).Cells("Salida").Value) = True Then
                                        If Val(.Rows(Fila).Cells("c_opc_estado").Value) = 0 Then
                                            Tbc01.SelectedTab = Tab02
                                            Call Mostrar_SalidaTA(Dgv01.Rows(Fila).Cells("Nro.").Value, Dgv01.Rows(Fila).Cells("Salida").Value) : Pan10.Enabled = True
                                            Call Dgv02_SelectionChanged(Nothing, Nothing) : BtnGrabar.Enabled = True : TxtAbv_Clie.Enabled = False : CboCliente.Enabled = True
                                            CboSerie.Enabled = False : CboPlaca.Focus() : TxtCod_Mt.Enabled = False : TxtNro_Ing.Enabled = False
                                            DtpFecha_Traslado.Enabled = True
                                            If TxtCod_Mt.Text = "16" Then
                                                TxtCod_Mt.Enabled = False : CboMot.Enabled = False
                                            End If
                                        Else
                                            MsgBox(" La orden de trabajo ya fue Procesada...", vbExclamation, Compañia)
                                        End If
                                    End If
                                End If
                            Else
                                MsgBox(" Guía de Remisión ya fue Facturada...", vbExclamation, Compañia)
                            End If
                        Else
                            MsgBox("Registro se encuentra anulado, no podra realizar  ninguna modificación...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = Dgv01.CurrentCellAddress.Y
                If Fila > -1 Then
                    If ValidarFactu("GUIA", " and S.c_nro_serie='" & .Rows(Fila).Cells("Nro.").Value & "' and S.c_nro_salidaTA='" & .Rows(Fila).Cells("Salida").Value & "' ") = True Then
                        If Val(.Rows(Fila).Cells("c_fact_guia").Value) = 0 Then
                            If Val(Dgv01.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                                If ValidarCierre(.Rows(Fila).Cells("Fecha Despacho").Value) = True Then
                                    If ValidarGuiaTransferencia(.Rows(Fila).Cells("Nro.").Value, .Rows(Fila).Cells("Salida").Value) = True Then
                                        Dim F As String = MsgBox("¿Desea Eliminar el Registro?", vbYesNo + vbQuestion, Compañia)
                                        If F = vbYes Then
                                            TxtNro_Guia.Text = Dgv01.Rows(Fila).Cells("Salida").Value
                                            TxtNro_MosGuia.Text = Dgv01.Rows(Fila).Cells("Salida").Value
                                            For i = 0 To CboSerie.Items.Count - 1
                                                'MsgBox(CboSerie.Items(i).ToString)
                                                If CboSerie.Items(i).ToString = Dgv01.Rows(Fila).Cells("Nro.").Value Then
                                                    CboSerie.SelectedIndex = i : i = CboSerie.Items.Count
                                                End If
                                            Next
                                            Call Mostrar_SalidaTA(CboSerie.Text, TxtNro_Guia.Text)
                                            With Dgv02
                                                For i = 0 To .RowCount - 1
                                                    Call Grabar_SalidaTADet(i, "DEL")
                                                Next
                                            End With
                                            Call Grabar_SalidaTA("DEL") : Call BtnMostrar_Click(Nothing, Nothing)
                                        End If
                                    End If
                                End If
                            Else
                                MsgBox("Registro se encuentra anulado, no podra realizar ninguna modificación...", vbCritical, Compañia)
                            End If
                        Else
                            MsgBox(" Guía de Remisión no puede ser Anulada, ya fue facturada...", vbExclamation, Compañia)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        With Dgv01
            If e.RowIndex = -1 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then .Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
                Next
            End If
        End With
    End Sub

    Private Sub TxtDirec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Len(TxtNro_Guia.Text) = 0 Then
                Focos = 1 : Call BtnAdd_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub TxtDirec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    ' Evitamos que se pierda el enfoque '
    Private Sub TxtObs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObs.LostFocus
        If Focos = 1 Then
            Focos = 0 : TxtObs.Focus()
        End If
    End Sub

    Private Sub TxtObs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtObs.TextChanged

    End Sub
    ' Evitamos el enfoque '
    Private Sub BtnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnAdd.Focus()
        End If
    End Sub
    ' Peso Crudo '
    Private Sub TxtPeso_Crudo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CboBusClie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboBusClie.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Buscamos por Codigo de Cliente '
    Private Sub CboBusClie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBusClie.SelectedIndexChanged
        If Len(CboBusClie.Text) = 0 Then

        Else
            Call Combo_Jalar_Codigo(CboBusClie, TxtBus_CodClie)

        End If
    End Sub

    Private Sub TxtBus_Guia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Guia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtBus_Guia.Text) > 0 Then
                TxtBus_Guia.Text = Strings.Right(Val(TxtBus_Guia.Text) + 10000000, 7)
                Call Cargar_Grid(" and S.c_nro_salidaTA='" & TxtBus_Guia.Text & "' ", "DGV")
                TxtBus_Partida.Clear()
            End If
        End If
    End Sub
    ' Imprimir Guia de Remisión '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If ValidarGuiaElectronica(.Rows(Fila).Cells("Nro.").Value) = True Then
                        Call AbrirArchivoGuiaPDF(.Rows(Fila).Cells("Nro.").Value & "-0" & .Rows(Fila).Cells("Salida").Value)
                    Else
                        If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                            If Strings.Left(.Rows(Fila).Cells("Nro.").Value, 2) = "OT" Or Strings.Left(.Rows(Fila).Cells("Nro.").Value, 2) = "OS" Then
                                Dim tipo As String = "ORDEN DE TRABAJO"
                                If Strings.Left(.Rows(Fila).Cells("Nro.").Value, 2) = "OS" Then tipo = "ORDEN DE SERVICIO"
                                FrmReportes.Impresion_OT(.Rows(Fila).Cells("Nro.").Value, .Rows(Fila).Cells("Salida").Value, tipo)
                            Else
                                ' imprimir guias de prueba
                                If Val(.Rows(Fila).Cells("Nro.").Value) = "100" Then
                                    FrmReportes.Impresion_SalidaTA_Prueba(.Rows(Fila).Cells("Nro.").Value, .Rows(Fila).Cells("Salida").Value)
                                Else
                                    FrmReportes.Impresion_SalidaTA(.Rows(Fila).Cells("Nro.").Value, .Rows(Fila).Cells("Salida").Value)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    ' Registro de Despachos '
    Private Sub BtnRegDes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegDes.Click
        'FrmAlmSalTAPrev.MdiParent = FrmMenu : FrmAlmSalTAPrev.Show()
        MsgBox("Módulo Pendiente por Definir por el usuario", vbExclamation, Compañia)
    End Sub
    ' Cerramos ventana '
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub
    ' Consultamos Articulos '
    Private Sub BtnConArt_Click(sender As System.Object, e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArticulos
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 1 : .TxtCod_Alm.Text = TxtCod_Almacen.Text
            .Cargar_Grid(" and St.c_codi_alm='" & TxtCod_Almacen.Text & "' and st.c_anula_reg=0 and c_cant_stock>0 order by c_desc_articulo")
        End With
    End Sub
    ' Metodo para cargar Articulo '
    Public Sub Mostrar_Articulo(ByVal Codigo As String)
        With c_Neg_MnArticulo.get_Articulo_Datos(" And A.c_codi_articulo='" & TxtCodigo.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtCod_UniMed.Text = .Rows(0)("c_codi_unimed").ToString
                TxtUniMed.Text = .Rows(0)("c_desc_unimed").ToString
            End If
        End With
    End Sub

    Private Sub TxtObs2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtObs2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtObs2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtObs2.TextChanged

    End Sub
    ' Editamos registro '
    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Edit = 1 : Call Nuevo_Detalles()
                    TxtCantidad.Text = Format(Val(.Rows(Fila).Cells("Cantidad").Value), Forma_1_2)
                    TxtUniMed.Text = .Rows(Fila).Cells("unid").Value
                    TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
                    TxtDescripcion.Text = .Rows(Fila).Cells("Articulo").Value
                    TxtBultos.Text = .Rows(Fila).Cells("Bultos").Value
                    TxtPrecio.Text = Val(.Rows(Fila).Cells("Precio").Value)
                    TxtObs2.Text = .Rows(Fila).Cells("c_obs").Value
                    TxtCod_Mon.Text = .Rows(Fila).Cells("c_codi_mon").Value
                    TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
                    TxtItem.Text = .Rows(Fila).Cells("Item").Value
                    TxtCantidad.Enabled = True : TxtCantidad.Focus() : TxtBultos.Enabled = True : TxtObs2.Enabled = True : BtnEdit.Enabled = True
                    ' Validamos si hay stock '
                    With c_Neg_RptStockIQ.get_StockIQ_Datos(" and A.c_codi_articulo='" & TxtCodigo.Text & "' ", Year(Now.Date), Month(Now.Date), CboAlm.SelectedValue, "02", "GUI")
                        If .Rows.Count > 0 Then
                            If Val(Dgv02.Rows(Fila).Cells("Item").Value) > 0 Then
                                TxtStock.Text = Val(.Rows(0)("Cantidad").ToString) + Val(TxtCantidad.Text)
                            Else
                                TxtStock.Text = Val(.Rows(0)("Cantidad").ToString)
                            End If
                        Else
                            TxtStock.Text = Val(TxtStock.Text) + Val(TxtCantidad.Text)
                        End If
                    End With
                End If
            End If
        End With
    End Sub

    Private Sub TxtChofer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown

    End Sub
    ' Evitamos el enfoque '
    Private Sub TxtCantidad_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantidad.LostFocus
        If Focos = 1 Then
            Focos = 0 : TxtCantidad.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCantidad.TextChanged

    End Sub

    Private Sub CboDireccion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CboDireccion_LostFocus(sender As Object, e As System.EventArgs) Handles CboDireccion.LostFocus
        If Focos = 1 Then
            Focos = 0 : CboDireccion.Focus()
        End If
    End Sub

    Private Sub CboDireccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged

        'El combo todavía no tiene un valor seleccionado
        If CboDireccion.SelectedIndex = -1 Then Exit Sub

        If CboDireccion.SelectedValue Is Nothing Then Exit Sub

        If TypeOf CboDireccion.SelectedValue Is DataRowView Then Exit Sub


        If Val(TxtOpc_Prove.Text) = 0 Then

            Call Combo_Jalar_Codigo(
            CboDireccion,
            TxtCodiOficina
        )

            Dim codigoOficina As String =
            CboDireccion.SelectedValue.ToString()

            With c_Neg_MnClienteOfi.get_ClienteOfi_Datos(
            " and c_anula_Reg=0 and c_codi_oficina='" &
            codigoOficina &
            "' ",
            "DAT"
        )

                TxtDist.Clear()
                TxtProvincia.Clear()
                TxtDpto.Clear()
                TxtUbigeo.Clear()

                If .Rows.Count > 0 Then

                    TxtDist.Text =
                    .Rows(0)("c_dist_clie").ToString()

                    TxtProvincia.Text =
                    .Rows(0)("c_prov_clie").ToString()

                    TxtDpto.Text =
                    .Rows(0)("c_dpto_clie").ToString()

                    TxtUbigeo.Text =
                    .Rows(0)("c_codi_ubigeo").ToString()

                End If

            End With

        End If

    End Sub

    Private Sub TxtBus_Guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Guia.TextChanged

    End Sub

    Private Sub TxtBultos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBultos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtBultos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBultos.TextChanged

    End Sub

    Private Sub CboEmpServ_LostFocus(sender As Object, e As System.EventArgs) Handles CboEmpServ.LostFocus
        If Focos = 1 Then
            Focos = 0 : CboEmpServ.Focus()
        End If
    End Sub

    Private Sub CboEmpServ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpServ.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboEmpServ, TxtCod_EmpServ)
        If Len(CboEmpServ.Text) > 0 Then
            c_Neg_MnChofer.Get_Chofer_Cbo(" and ch.c_codi_empserv='" & TxtCod_EmpServ.Text & "'", CboChofer)
            c_Neg_MnTransporte.Get_Transporte_Cbo(" and T.c_codi_clie='" & TxtCod_EmpServ.Text & "'", CboPlaca)
            TxtLicencia.Clear() : TxtDni.Clear() : TxtVehiculo.Clear() : TxtTransp_Color.Clear()
        End If
    End Sub

    Private Sub CboChofer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboChofer.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : CboDireccion.Focus()
        End If
    End Sub

    Private Sub CboChofer_LostFocus(sender As Object, e As System.EventArgs) Handles CboChofer.LostFocus
        If Focos = 1 Then
            Focos = 0 : CboChofer.Focus()
        End If
    End Sub

    Private Sub CboChofer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboChofer.SelectedIndexChanged
        If Len(CboChofer.Text) > 0 Then
            With c_Neg_MnChofer.get_Chofer_Datos(" AND Ch.c_nro_brevete='" & CboChofer.SelectedValue & "' ", "DAT")
                If .Rows.Count > 0 Then
                    TxtLicencia.Text = .Rows(0)("c_nro_brevete").ToString
                    TxtDni.Text = .Rows(0)("c_nro_dni").ToString
                    TxtApeChofer.Text = .Rows(0)("c_ape_chofer").ToString
                End If
            End With
        End If
    End Sub
    ' Agregamos registro '
    Private Sub TxtDpto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDpto.KeyDown
        If e.KeyCode = Keys.Enter Then If Pan10.Enabled = True Then Call BtnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtDpto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDpto.TextChanged

    End Sub

    Private Sub CboBusSerie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboBusSerie.SelectedIndexChanged
        Call Cargar_Grid(" and S.c_fecha_sal>='" & DtpFec_Inicio.Text & "' and S.c_fecha_sal<='" & DateAdd("d", 1, DtpFec_Final.Text) &
                     "'  and S.c_nro_serie='" & CboBusSerie.Text & "' ", "DGV")
    End Sub

    Private Sub TxtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtNro_Doc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Doc.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtNro_Doc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub

    Private Sub CboTpoDoc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboTpoDoc.SelectedIndexChanged
        On Error Resume Next : Combo_Jalar_Codigo(CboTpoDoc, TxtCod_Doc)
    End Sub

    Private Sub TxtNro_Ing_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Ing.KeyDown
        If TxtCod_Mt.Text = "09" Then
            If e.KeyCode = Keys.Enter Then
                TxtNro_Ing.Text = Strings.Right(Val(TxtNro_Ing.Text) + 10000000, 7)
                With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_codi_ing='" & TxtNro_Ing.Text & "' AND I.c_codi_mt='05' and I.c_anula_reg=0 and I.c_estado_ing in (0,2)", "FA", "DAT")
                    If .Rows.Count > 0 Then
                        CboCliente.SelectedValue = .Rows(0)("c_codi_Clie").ToString
                        With c_Neg_IngAlmIQDet.get_IngAlmIQDet_Datos(" and D.c_codi_ing='" & TxtNro_Ing.Text & "' and D.c_anula_reg=0", "FA", "DAT")
                            Dgv02.Rows.Clear()
                            If .Rows.Count > 0 Then
                                For i = 0 To .Rows.Count - 1
                                    Dgv02.Rows.Add()
                                    Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString) - Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                                    Dgv02.Rows(i).Cells("c_cant_fraccion").Value = 0
                                    Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                    Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                                    Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                    Dgv02.Rows(i).Cells("Articulo").Value = .Rows(i)("c_desc_articulo").ToString
                                    Dgv02.Rows(i).Cells("Bultos").Value = Format(Val(.Rows(i)("c_nro_cant").ToString) - Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                                    Dgv02.Rows(i).Cells("c_Obs").Value = ""
                                    Dgv02.Rows(i).Cells("Precio").Value = 0
                                    Dgv02.Rows(i).Cells("Importe").Value = 0
                                    Dgv02.Rows(i).Cells("c_codi_mon").Value = "02"
                                    Dgv02.Rows(i).Cells("Lote").Value = ""
                                    Dgv02.Rows(i).Cells("Item").Value = ""
                                    Dgv02.Rows(i).Cells("c_correl_ing").Value = .Rows(i)("c_nro_correl").ToString
                                Next
                            End If
                        End With
                    Else
                        MsgBox("No existen registros activos que mostrar...", vbCritical, Compañia)
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub TxtNro_Ing_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNro_Ing.TextChanged

    End Sub

    Private Sub TxtSerieDocAnexo_TextChanged(sender As Object, e As EventArgs) Handles TxtSerieDocAnexo.TextChanged

    End Sub
    Private Sub RellenarCeros()
        If Len(TxtSerieDocAnexo.Text) > 0 Then
            If IsNumeric(TxtSerieDocAnexo.Text) = True Then
                TxtSerieDocAnexo.Text = Strings.Right(Val(TxtSerieDocAnexo.Text) + 10000, 4)
            End If
        End If

        If Val(TxtNroDocAnexo.Text) > 0 Then
            TxtNroDocAnexo.Text = Strings.Right(Val(TxtNroDocAnexo.Text) + 100000000, 8)
        End If
    End Sub

    Private Sub TxtSerieDocAnexo_LostFocus(sender As Object, e As EventArgs) Handles TxtSerieDocAnexo.LostFocus
        Call RellenarCeros()
    End Sub

    Private Sub TxtNroDocAnexo_TextChanged(sender As Object, e As EventArgs) Handles TxtNroDocAnexo.TextChanged

    End Sub

    Private Sub TxtNroDocAnexo_LostFocus(sender As Object, e As EventArgs) Handles TxtNroDocAnexo.LostFocus
        Call RellenarCeros()
    End Sub

    Private Sub CboDocAnexo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDocAnexo.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboDocAnexo, TxtDocAnexo)
    End Sub
End Class