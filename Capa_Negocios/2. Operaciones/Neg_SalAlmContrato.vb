Imports Capa_Acceso
Imports Capa_Entidades

Public Class Neg_SalAlmContrato

    Private Datos As New Cls_SalAlmContrato


    Public Function set_SalAlmContrato_Save(ByVal Ent As Ent_SalAlmContrato) As Integer

        Return Datos.set_SalAlmContrato_Save(Ent)

    End Function


    Public Function get_SalAlmContrato_Datos(ByVal SerieOT As String, ByVal NroOT As String) As DataTable

        Return Datos.get_SalAlmContrato_Datos(SerieOT, NroOT)

    End Function

    Public Function set_SalAlmContrato_Facturar(ByVal ent As Ent_SalAlmContratoFactura) As Integer

        Return Datos.set_SalAlmContrato_Facturar(ent)

    End Function

End Class