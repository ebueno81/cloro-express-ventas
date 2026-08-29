Imports Capa_Acceso
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Neg_MnEmpServ
    Dim c_EmpServ As New Cls_MnEmpServ
    Public Function set_EmpServ_Save(ByVal c_Entidades As Ent_MnEmpServ)
        Return c_EmpServ.set_EmpServ_Save(c_Entidades)
    End Function
    Public Function get_EmpServ_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_EmpServ.Get_EmpServ_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_EmpServ_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_EmpServ.Get_Cargar_EmpServ_Cbo(Cadena, Combo)
    End Function
End Class
