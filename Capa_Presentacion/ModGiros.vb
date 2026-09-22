Imports Capa_Negocios

Module ModGiros

    Public Sub CargarGiros(ByVal Cbo As ComboBox)

        Try

            Cbo.Items.Clear()

            Dim NegConexion As New Neg_Conexion
            Dim i As Integer

            For i = 1 To 4

                Dim valor As String =
                    NegConexion.LeerConfiguracion(
                        "Giro" & i.ToString())

                If valor IsNot Nothing AndAlso
                   Trim(valor) <> "" Then

                    Dim datos() As String =
                        valor.Split("|"c)

                    If datos.Length = 3 Then

                        Dim item As New ItemGiro

                        item.IdGiro = CInt(datos(0))
                        item.Descripcion = Trim(datos(1))
                        item.Modo = UCase(Trim(datos(2)))

                        Cbo.Items.Add(item)

                    End If

                End If

            Next

            Cbo.SelectedIndex = -1

        Catch ex As Exception

            MsgBox(
                "Error al cargar los giros: " &
                ex.Message,
                vbCritical,
                Compañia)

        End Try

    End Sub


    Public Sub SeleccionarGiro(
        ByVal Cbo As ComboBox,
        ByVal IdGiro As Integer)

        Dim i As Integer

        For i = 0 To Cbo.Items.Count - 1

            Dim item As ItemGiro =
                TryCast(Cbo.Items(i), ItemGiro)

            If item IsNot Nothing Then

                If item.IdGiro = IdGiro Then

                    Cbo.SelectedIndex = i
                    Exit For

                End If

            End If

        Next

    End Sub


    Public Function ObtenerIdGiro(
        ByVal Cbo As ComboBox) As Integer

        Dim item As ItemGiro =
            TryCast(Cbo.SelectedItem, ItemGiro)

        If item Is Nothing Then
            Return 0
        End If

        Return item.IdGiro

    End Function

    Public Sub ConfigurarGiroSesion(
    ByVal Cbo As ComboBox)

        If ModSesion.EsMedXpress Then

            SeleccionarGiro(
                Cbo,
                ModSesion.IdGiro)

            Cbo.Enabled = False

        Else

            Cbo.SelectedIndex = -1
            Cbo.Enabled = True

        End If

    End Sub
End Module