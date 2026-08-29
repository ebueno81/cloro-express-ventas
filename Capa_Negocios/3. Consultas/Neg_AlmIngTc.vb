Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmIngTc
    Dim c_AlmIngTc As New Cls_AlmIngTc
    Public Function get_AlmIngTc_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_AlmIngTc.Get_AlmIngTc_Datos(Cadena, vOpt)
    End Function
End Class
