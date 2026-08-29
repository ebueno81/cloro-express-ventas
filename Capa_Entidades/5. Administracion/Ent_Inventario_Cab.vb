Public Class Ent_Inventario_Cab
    Dim _c_nro_inventario As String
    Dim _c_fecha_emi As Date
    Dim _c_codi_alm As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_inventario() As String
        Get
            Return _c_nro_inventario
        End Get
        Set(ByVal value As String)
            _c_nro_inventario = value
        End Set
    End Property
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
        End Set
    End Property
    Public Property c_codi_alm() As String
        Get
            Return _c_codi_alm
        End Get
        Set(ByVal value As String)
            _c_codi_alm = value
        End Set
    End Property
    Public Property c_usuario() As String
        Get
            Return _c_usuario
        End Get
        Set(ByVal value As String)
            _c_usuario = value
        End Set
    End Property
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class
