Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnArticulos
    Dim c_Articulo As New Cls_MnArticulo
    Public Function get_Articulo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Articulo.Get_Articulo_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al combo...
    Public Function Get_Articulo_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        c_Articulo.get_Articulo_Cbo(Cadena, Combo1)
    End Function
End Class
