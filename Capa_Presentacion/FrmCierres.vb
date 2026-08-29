Public Class FrmCierres
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Dim F As String = MsgBox("¿Desea grabar la fecha de cierre?", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            Call Grabar_Cierre()
            MsgBox("Registro se grabo correctamente", vbExclamation, Compañia)
        End If
    End Sub
    Private Sub Grabar_Cierre()
        c_Neg_MnEmpresa.set_Cierre_Save(DtpFec_Inicio.Text, "ADD")
    End Sub

    Private Sub FrmCierres_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With c_Neg_MnEmpresa.get_Empresa_Datos(" ", "CIE")
            If .Rows.Count > 0 Then
                DtpFec_Inicio.Text = .Rows(0)("c_fecha_cierre").ToString
            Else
                DtpFec_Inicio.Text = Now.Date
            End If
        End With
    End Sub

    Private Sub FrmCierres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
End Class