Public Class Ent_Liquidac
    Dim _c_nro_liq As String
    Dim _c_año_liq As Integer
    Dim _c_sist_bahia As Integer
    Dim _c_codi_clie As String
    Dim _c_reten_liq As Decimal
    Dim _c_cant_reten As Decimal
    Dim _c_total_liq As Decimal
    Dim _c_codi_mon As String
    Dim _c_motivo_anula As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_liq() As String
        Get
            Return _c_nro_liq
        End Get
        Set(ByVal value As String)
            _c_nro_liq = value
        End Set
    End Property
    Public Property c_año_liq() As Integer
        Get
            Return _c_año_liq
        End Get
        Set(ByVal value As Integer)
            _c_año_liq = value
        End Set
    End Property
    Public Property c_sist_bahia() As Integer
        Get
            Return _c_sist_bahia
        End Get
        Set(ByVal value As Integer)
            _c_sist_bahia = value
        End Set
    End Property
    Public Property c_codi_clie() As String
        Get
            Return _c_codi_clie
        End Get
        Set(ByVal value As String)
            _c_codi_clie = value
        End Set
    End Property
    Public Property c_reten_liq() As Integer
        Get
            Return _c_reten_liq
        End Get
        Set(ByVal value As Integer)
            _c_reten_liq = value
        End Set
    End Property
    Public Property c_cant_reten() As Decimal
        Get
            Return _c_cant_reten
        End Get
        Set(ByVal value As Decimal)
            _c_cant_reten = value
        End Set
    End Property
    Public Property c_total_liq() As Decimal
        Get
            Return _c_total_liq
        End Get
        Set(ByVal value As Decimal)
            _c_total_liq = value
        End Set
    End Property
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_motivo_anula() As String
        Get
            Return _c_motivo_anula
        End Get
        Set(ByVal value As String)
            _c_motivo_anula = value
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
