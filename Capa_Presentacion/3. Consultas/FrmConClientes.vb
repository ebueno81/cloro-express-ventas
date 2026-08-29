Imports Capa_Negocios
Public Class FrmConClientes
    Dim c_Neg_Clientes As New Neg_MnCliente : Dim x As Integer = 0 'Trabaja con la movilizacion del grid
    Dim foco As Integer = 0 '

    Private Sub FrmConClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 2 Then
            FrmRetencion.TxtTc.Focus()
        End If
        If Val(TxtVar.Text) = 3 Then
            
        End If 'Facturas ventas mostrador
        If Val(TxtVar.Text) = 4 Then
            FrmFacturas.ChkRetencion.Focus()
        End If 'Boletas ventas mostrador
        If Val(TxtVar.Text) = 5 Then
            FrmBoletas.TxtObs.Focus()
        End If 'Nota de Credito
        If Val(TxtVar.Text) = 6 Then
            FrmIngNC.Enabled = True : FrmIngNC.DtpFec_Prd.Focus()
        End If
        If Val(TxtVar.Text) = 7 Then
            FrmIngND.Enabled = True : FrmIngND.CboMon.Focus()
        End If 'Generacion de Letras...
        If Val(TxtVar.Text) = 8 Then
            FrmLetras.Enabled = True : FrmLetras.CboMon.Focus()
        End If
        ' ASIENTO DE APERTURA 
        If Val(TxtVar.Text) = 9 Then
            FrmApertura.CboTpoDoc.Focus()
        End If
        ' reporte por cliente
        If Val(TxtVar.Text) = 10 Then
            FrmRepVentas.BtnVista.Focus()
        End If
        ' Listado de factura
        If Val(TxtVar.Text) = 11 Then
            FrmListaFact.BtnMostrar.Focus()
        End If
        ' Listado de Boleta
        If Val(TxtVar.Text) = 12 Then
            FrmListaBol.BtnMostrar.Focus()
        End If
    End Sub
    Private Sub FrmConClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_Clientes.get_Cliente_Datos(Cadena, "DG3")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Cliente").Width = 320
            .Columns("R.U.C.").Width = 90
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("R.U.C.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : On Error Resume Next
                    .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells("Art.").ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        With Dgv01
            If .RowCount > 0 Then
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : foco = 1 : x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    foco = 1 : e.Handled = True : x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    Call Dgv01_DoubleClick(Nothing, Nothing)
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_clie like '%" & TxtBuscar.Text & "%' order by c_desc_clie ")
    End Sub

    Private Sub Dgv01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.Click
        Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario Salidas...
                    If Val(TxtVar.Text) = 1 Then

                    End If
                    'ingreso de retencion...
                    If Val(TxtVar.Text) = 2 Then
                        FrmRetencion.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmRetencion.TxtDir.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & " " & .Rows(0)("c_prov_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString
                                FrmRetencion.TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                                FrmRetencion.CboClie.Text = .Rows(0)("c_desc_clie").ToString
                                FrmRetencion.Mostrar_Documentos()
                            End If
                        End With
                    End If
                    ' Generación de boletas...'
                    If Val(TxtVar.Text) = 3 Then

                    End If
                    ' Venta mostrador de Facturas...'
                    If Val(TxtVar.Text) = 4 Then
                        FrmFacturas.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmFacturas.TxtDir.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & " " & .Rows(0)("c_prov_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString
                                FrmFacturas.TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString : FrmFacturas.CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                                FrmFacturas.TxtAbrev.Text = .Rows(0)("c_abrev_clie").ToString : FrmFacturas.CboClie.SelectedValue = .Rows(0)("c_codi_clie").ToString
                                FrmFacturas.CboFPago.SelectedValue = .Rows(0)("c_codi_pago").ToString
                                ' Cliente retenedor
                                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                                    FrmFacturas.ChkRetencion.Checked = True
                                Else
                                    FrmFacturas.ChkRetencion.Checked = False
                                End If
                                FrmFacturas.Mostrar_GuiaR()
                            End If
                        End With
                    End If
                    'Venta mostrador de Boletas...
                    If Val(TxtVar.Text) = 5 Then
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmBoletas.TxtDir.Text = .Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_ciudad_clie").ToString & " " & .Rows(0)("c_prov_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString
                                FrmBoletas.TxtDni.Text = .Rows(0)("c_dni_clie").ToString : FrmBoletas.CboVende.SelectedValue = .Rows(0)("c_codi_vende").ToString
                                FrmBoletas.TxtAbrev.Text = .Rows(0)("c_abrev_clie").ToString : FrmBoletas.CboClie.SelectedValue = .Rows(0)("c_codi_clie").ToString
                                FrmBoletas.TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                                FrmBoletas.CboFPago.SelectedValue = .Rows(0)("c_codi_pago").ToString

                                FrmBoletas.Mostrar_GuiaR()
                            End If
                        End With
                    End If
                    'Nota de Crédito...
                    If Val(TxtVar.Text) = 6 Then
                        FrmIngNC.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmIngNC.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                        FrmIngNC.Mostrar_documentos()
                    End If
                    'Nota de Débito...
                    If Val(TxtVar.Text) = 7 Then
                        FrmIngND.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmIngND.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmIngND.TxtDir.Text = .Rows(0)("c_direc_clie").ToString
                                FrmIngND.TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                                ' Cliente retenedor
                                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                                    FrmIngND.ChkRetencion.Checked = True
                                Else
                                    FrmIngND.ChkRetencion.Checked = False
                                End If
                            End If
                        End With
                    End If
                    'Letras Generacion...
                    If Val(TxtVar.Text) = 8 Then
                        FrmLetras.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmLetras.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmLetras.TxtSist_Bahia.Text = .Rows(0)("c_tpo_clie").ToString
                            End If
                        End With
                        FrmLetras.Mostrar_documentos()
                    End If
                    'Asiento de Apertura...
                    If Val(TxtVar.Text) = 9 Then
                        FrmApertura.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmApertura.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    'Reporte de Clientes...
                    If Val(TxtVar.Text) = 10 Then
                        FrmRepVentas.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepVentas.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    'Reporte de Listado de Factura...
                    If Val(TxtVar.Text) = 11 Then
                        FrmListaFact.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmListaFact.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    'Reporte de Listado de Factura...
                    If Val(TxtVar.Text) = 12 Then
                        FrmListaBol.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmListaBol.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    'Reporte de Gerencia...
                    If Val(TxtVar.Text) = 13 Then
                        FrmRepVtasGerencial.TxtCodClie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepVtasGerencial.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    'Reporte de Estado de Cuentas...
                    If Val(TxtVar.Text) = 14 Then
                        FrmRepEstadoCuenta.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRepEstadoCuenta.TxtClie.Text = .Rows(fila).Cells("Cliente").Value
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'mostramos al dar doble clic
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class