Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmIngTcDet
    Dim c_AlmIngTcDet As New Cls_AlmIngTcDet
    Public Function get_AlmIngTcDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_AlmIngTcDet.Get_AlmIngTcDet_Datos(Cadena, vOpt)
    End Function
   

End Class
