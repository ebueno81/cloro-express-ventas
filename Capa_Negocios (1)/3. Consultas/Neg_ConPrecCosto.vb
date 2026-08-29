Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_ConPrecCosto
    Dim c_PrecCosto As New Cls_ConPrecCosto
    Public Function get_PrecCosto_Datos(ByVal Entidad As Ent_ConPrecCosto)
        Return c_PrecCosto.Get_PrecCosto_Datos(Entidad)
    End Function
End Class
