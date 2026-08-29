Public Class FrmFactCuota
    Private Sub FrmFactCuota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c_Neg_TpoMoneda.Get_Moneda_Cbo(" ", CboMon)
        c_Neg_TpoDoc.Get_TpoDoc_Cbo("", CboTpoDoc)
    End Sub

    Private Sub TxtCuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCuotas.KeyDown
        If e.KeyCode = Keys.Enter Then
            With Dgv01
                .Rows.Clear()
                If Val(TxtCuotas.Text) > 0 Then
                    For i = 1 To Val(TxtCuotas.Text)
                        .Rows.Add()
                        .Rows(i - 1).Cells("c_nro_correl").Value = ""
                        .Rows(i - 1).Cells("c_nro_cuota").Value = i
                        .Rows(i - 1).Cells("c_monto_cuota").Value = Format(Val(TxtTotDoc.Text) / Val(TxtCuotas.Text), Forma_1_2)
                        .Rows(i - 1).Cells("c_fecha_cuota").Value = FormatDateTime(Now.Date, DateFormat.ShortDate)
                    Next
                    ' Metodo para Calcular '
                    Call CalcularTotalCuotas()
                    Dim dif As Decimal = 0
                    dif = Val(TxtTotDoc.Text) - Val(TxtTotCuota.Text)
                    .Rows(.RowCount - 1).Cells("c_monto_cuota").Value = Format(Val(.Rows(.RowCount - 1).Cells("c_monto_cuota").Value) + dif, Forma_1_2)
                    Call CalcularTotalCuotas()
                End If
            End With
        End If
    End Sub
    Private Sub CalcularTotalCuotas()
        With Dgv01
            Dim tot As Decimal = 0
            For i = 0 To .RowCount - 1
                tot = tot + Val(.Rows(i).Cells("c_monto_cuota").Value)
            Next
            TxtTotCuota.Text = Format(tot, Forma_1_2)
        End With
    End Sub

    Private Sub TxtCuotas_TextChanged(sender As Object, e As EventArgs) Handles TxtCuotas.TextChanged

    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Call NuevoRegistro()

    End Sub
    Private Sub NuevoRegistro()
        With Dgv01
            If .RowCount > 0 Then
                .Size = New Size(410, 83)
                .Location = New Point(7, 106)
                Dgv01.Enabled = False
                Dim f As Integer = .CurrentCellAddress.Y
                If f > -1 Then
                    DtpFec_Emi.Text = .Rows(f).Cells("c_fecha_cuota").Value
                    TxtMonCuota2.Text = Format(Val(.Rows(f).Cells("c_monto_cuota").Value), Forma_1_2)
                    Pan01.Enabled = True
                    DtpFec_Emi.Focus()
                End If
            End If
        End With
    End Sub
    Private Sub CancelarRegistro()
        With Dgv01
            .Size = New Size(410, 117)
            .Location = New Point(7, 72)
            Pan01.Enabled = False : Dgv01.Enabled = True
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Call CancelarRegistro()
    End Sub

    Private Sub TxtMonCuota2_TextChanged(sender As Object, e As EventArgs) Handles TxtMonCuota2.TextChanged

    End Sub

    Private Sub TxtMonCuota2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMonCuota2.KeyDown
        If e.KeyCode = Keys.Enter Then
            With Dgv01
                If .RowCount > 0 Then
                    Dim f As Integer = .CurrentCellAddress.Y
                    If f > -1 Then
                        .Rows(f).Cells("c_monto_cuota").Value = Format(Val(TxtMonCuota2.Text), Forma_1_2)
                        .Rows(f).Cells("c_fecha_cuota").Value = FormatDateTime(DtpFec_Emi.Text, DateFormat.ShortDate)
                        Call CalcularTotalCuotas() : Call CancelarRegistro()
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As Object, e As EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtTotDoc_TextChanged(sender As Object, e As EventArgs) Handles TxtTotDoc.TextChanged

    End Sub

    Private Sub TxtTotDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTotDoc.KeyDown

    End Sub

    Private Sub TxtMonCuota2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMonCuota2.KeyPress

    End Sub

    Private Sub DtpFec_Emi_ValueChanged(sender As Object, e As EventArgs) Handles DtpFec_Emi.ValueChanged

    End Sub

    Private Sub DtpFec_Emi_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpFec_Emi.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMonCuota2.Focus()
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(sender As Object, e As EventArgs) Handles Dgv01.DoubleClick
        Call BtnEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmFactCuota_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub GrabarCuota(ByVal vOpt As String)
        For i = 0 To Dgv01.RowCount - 1
            With c_Ent_FactCuota
                .c_nro_correl = Val(Dgv01.Rows(i).Cells("c_nro_correl").Value)
                .c_nro_serie = TxtSerie.Text
                .c_nro_doc = TxtDoc.Text
                .c_fecha_cuota = Dgv01.Rows(i).Cells("c_fecha_cuota").Value
                .c_monto_cuota = Val(Dgv01.Rows(i).Cells("c_monto_cuota").Value)
                .c_usuario = FrmMenu.lblusuario.Text
                .copcion = vOpt
                c_Neg_FactCuota.set_FactCuota_Save(c_Ent_FactCuota)
            End With
        Next
    End Sub
    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim f As String = MsgBox("¿Desea grabar los registros?", vbYesNo + vbQuestion, Compañia)
            If f = vbYes Then
                Call GrabarCuota("ADD")
                MsgBox("Registro se grabo satisfactoriamente...", vbExclamation, Compañia)
                Me.Close()
            End If
        End If
    End Sub
    Private Function ValidarDatos() As Boolean
        If Dgv01.RowCount > 0 Then
            If Val(TxtCuotas.Text) > 0 Then
                If Val(TxtTotCuota.Text) = Val(TxtTotDoc.Text) Then
                    ValidarDatos = True
                Else
                    MsgBox("1. Importe de couta debe ser igual a importe del documento...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("2. El numero de cuota debe ser mayor a cero...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("3. Deben existir registros para grabar...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
End Class