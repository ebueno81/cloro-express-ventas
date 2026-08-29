Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnEmpresa
    Dim c_Neg_MnEmpresa As New Cls_MnEmpresa
    Public Function get_Empresa_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Neg_MnEmpresa.Get_Empresa_Datos(Cadena, vOpt)
    End Function
    Public Function set_Cierre_Save(ByVal c_fecha_cierre As String, ByVal vOpt As String) As DataTable
        Return c_Neg_MnEmpresa.Set_Cierre_Save(c_fecha_cierre, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Empresa_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Neg_MnEmpresa.Get_Cargar_Empresa_Cbo(Cadena, Combo)
    End Function
End Class
