Imports Capa_Acceso

Public Class Neg_MnGiroNegocio

    Private Datos As New Cls_MnGiroNegocio

    Public Function Get_GiroNegocio_Datos(ByVal soloActivos As Boolean) As DataTable
        Return Datos.Get_GiroNegocio_Datos(soloActivos)
    End Function

End Class