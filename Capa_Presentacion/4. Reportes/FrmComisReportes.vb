Public Class FrmComisReportes

    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmComisReportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close() ' Cerramos presionando la tecla escape '
    End Sub

    Private Sub FrmComisReportes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmComisReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_TpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboDoc)
        c_Neg_MnCliente.Get_Clientes_Cbo(" and c_anula_reg=0 order by c_desc_clie", CboCliente)
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVende)
        CboTipo.SelectedIndex = 0 : CboEstado.SelectedIndex = 0
    End Sub

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim c_codi_doc As String = "" : Dim c_codi_vende As String = "" : Dim c_desc_estado As String = "" : Dim c_c_codi_clie As String = ""
        If Len(CboCliente.Text) > 0 Then c_c_codi_clie = CboCliente.SelectedValue
        If Len(CboDoc.Text) > 0 Then c_codi_doc = CboDoc.SelectedValue
        If Len(CboVende.Text) > 0 Then c_codi_vende = CboVende.SelectedValue
        ' Validamos el tipo de estado '
        If UCase(CboEstado.Text) = "(TODOS)" Then
            c_desc_estado = ""
        Else
            c_desc_estado = CboEstado.Text
        End If
        ' Reporte comisiones por vendedores '
        If Val(Strings.Left(CboTipo.Text, 1)) = 2 Then
            FrmReportes.Reporte_Comision(" N° Planilla: " & TxtNro_Comision.Text & " Reporte de Comisiones de Vendedores Del : " & FrmComisiones.DtpFec_Inicio.Text & " Al : " & FrmComisiones.DtpFec_Final.Text, TxtNro_Comision.Text)
        End If
        ' Reporte comisiones por vendedores totalizado'
        If Val(Strings.Left(CboTipo.Text, 1)) = 1 Then
            FrmReportes.Reporte_ComisionTotal(" Reporte de Comisiones de Vendedores Del : " & FrmComisiones.DtpFec_Inicio.Text & " Al : " & FrmComisiones.DtpFec_Final.Text, TxtNro_Comision.Text, _
                                      c_codi_doc, c_codi_vende, c_desc_estado, c_c_codi_clie)
        End If
        ' Reporte comisiones por articulos'
        If Val(Strings.Left(CboTipo.Text, 1)) = 3 Then
            Call Calcular_Totales()
            FrmReportes.Reporte_ComisionArt(" Reporte de Comisiones de Vendedores Del : " & FrmComisiones.DtpFec_Inicio.Text & " Al : " & FrmComisiones.DtpFec_Final.Text, TxtNro_Comision.Text,
                                       c_codi_vende, c_desc_estado, c_c_codi_clie, Val(TxtImp_Mn.Text), Val(TxtImp_Us.Text), Val(TxtComis_Mn.Text), Val(TxtComis_Us.Text))
        End If
    End Sub
    ' Metodo para cargar segun estado '
    Private Sub Calcular_Totales()
        Dim c_desc_estado As String = ""
        If UCase(CboEstado.Text) = "(TODOS)" Then
            c_desc_estado = ""
        Else
            c_desc_estado = " and D.c_desc_estado='" & UCase(CboEstado.Text) & "' "
        End If


        With c_Neg_ComisDet.get_ComisDet_Datos(" and D.c_anula_reg=0 and D.c_nro_comis='" & TxtNro_Comision.Text & "' " &
                                               c_desc_estado, "TOT")
            If .Rows.Count > 0 Then
                TxtImp_Mn.Text = Format(Val(.Rows(0)("Importe_Mn").ToString), Forma_1_2)
                TxtImp_Us.Text = Format(Val(.Rows(0)("Importe_Us").ToString), Forma_1_2)
                TxtComis_Mn.Text = Format(Val(.Rows(0)("Comis_Mn").ToString), Forma_1_2)
                TxtComis_Us.Text = Format(Val(.Rows(0)("Comis_Us").ToString), Forma_1_2)
            Else
                TxtImp_Mn.Text = 0 : TxtImp_Us.Text = 0
                TxtComis_Mn.Text = 0 : TxtComis_Us.Text = 0
            End If
        End With
    End Sub
    Private Sub CboVende_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboVende.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboVende_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboVende.SelectedIndexChanged

    End Sub

    Private Sub CboCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCliente.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCliente.SelectedIndexChanged

    End Sub

    Private Sub CboDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboDoc.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDoc.SelectedIndexChanged

    End Sub
End Class