Imports Capa_Acceso
Imports Capa_Entidades

Public Class Neg_ApiMedXpress

    Private Datos As New Cls_ApiMedXpress

    Public Function ObtenerContratosCliente(
        ByVal CodigoCliente As String
    ) As List(Of Ent_ApiContrato)

        If Trim(CodigoCliente) = "" Then
            Throw New Exception(
                "Debe indicar el código del cliente.")
        End If

        Return Datos.ObtenerContratosCliente(
            Trim(CodigoCliente))

    End Function

End Class