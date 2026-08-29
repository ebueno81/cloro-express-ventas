Public Class FrmComisAnexos

    'Funcion para validar datos para grabacion '
    Private Function ValidarDatos() As Boolean
        If CboVende.SelectedIndex > -1 Then
            If CboMon.SelectedIndex > -1 Then
                If Val(TxtSerie.Text) > 0 And Val(TxtDoc.Text) > 0 Then
                    If Val(TxtMonto.Text) > 0 Then
                        ValidarDatos = True
                    Else
                        MsgBox("1. Falta ingresar un monto valido...", vbCritical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("2. Falta ingresar un documento válido...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("3. Falta seleccionar el tipo de documento...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("4. Falta seleccionar el vendedor...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_ComisAnexos("ADD") : BtnGrabar.Enabled = False
                MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                FrmComisiones.BtnEstado.Text = "INGRESADO" : FrmComisiones.BtnEstado.BackColor = Color.Blue : Me.Close()
            End If
        End If
    End Sub
    ' metodo para grabar registro '
    Private Sub Grabar_ComisAnexos(ByVal cOpcion As String)
        With c_Ent_ComisDocs
            .c_nro_correl = TxtNro_Correl.Text
            .c_nro_comis = TxtNro_Comis.Text
            .c_codi_vende = CboVende.SelectedValue
            .c_codi_doc = CboTpoDoc.SelectedValue
            .c_serie_doc = TxtSerie.Text
            .c_nro_doc = TxtDoc.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_imp_doc = Val(TxtMonto.Text)
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtNro_Correl.Text) = 0 Then
                TxtNro_Correl.Text = c_Neg_ComisDocs.set_ComisDocs_Save(c_Ent_ComisDocs)
            Else
                c_Neg_ComisDocs.set_ComisDocs_Save(c_Ent_ComisDocs)
            End If
        End With
    End Sub

    Private Sub FrmComisAnexos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmComisAnexos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnVendedor.get_Vendedor_Combo(" and c_anula_reg=0 order by c_nom_vende", CboVende)
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboTpoDoc)
        c_Neg_MnMonedas.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_desc_mon", CboMon)
    End Sub

    Private Sub TxtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtSerie.Text) > 0 Then
                TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtDoc.Text) > 0 Then
                TxtDoc.Text = Strings.Right(Val(TxtDoc.Text) + 10000000, 7)
            End If
        End If
    End Sub

    Private Sub TxtDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDoc.TextChanged

    End Sub

    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class