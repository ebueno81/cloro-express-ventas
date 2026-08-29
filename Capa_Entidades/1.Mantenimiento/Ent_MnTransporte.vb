Public Class Ent_MnTransporte
    Private _c_placa_trp As String
    Private _c_codi_clie As String
    Private _c_direcc_trp As String
    Private _c_vehiculo_trp As String
    Private _c_color_trp As String
    Private _c_peso_trp As String
    Private _c_altura_trp As String
    Private _c_longitud_trp As String
    Private _c_ancho_trp As String
    Private _c_obs As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_placa_trp() As String
        Get
            Return _c_placa_trp
        End Get
        Set(ByVal value As String)
            _c_placa_trp = value
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
    Public Property c_direcc_trp() As String
        Get
            Return _c_direcc_trp
        End Get
        Set(ByVal value As String)
            _c_direcc_trp = value
        End Set
    End Property
    Public Property c_vehiculo_trp() As String
        Get
            Return _c_vehiculo_trp
        End Get
        Set(ByVal value As String)
            _c_vehiculo_trp = value
        End Set
    End Property
    Public Property c_color_trp() As String
        Get
            Return _c_color_trp
        End Get
        Set(ByVal value As String)
            _c_color_trp = value
        End Set
    End Property
    Public Property c_peso_trp() As String
        Get
            Return _c_peso_trp
        End Get
        Set(ByVal value As String)
            _c_peso_trp = value
        End Set
    End Property
    Public Property c_altura_trp() As String
        Get
            Return _c_altura_trp
        End Get
        Set(ByVal value As String)
            _c_altura_trp = value
        End Set
    End Property
    Public Property c_longitud_trp() As String
        Get
            Return _c_longitud_trp
        End Get
        Set(ByVal value As String)
            _c_longitud_trp = value
        End Set
    End Property
    Public Property c_ancho_trp() As String
        Get
            Return _c_ancho_trp
        End Get
        Set(ByVal value As String)
            _c_ancho_trp = value
        End Set
    End Property
    Private _c_nro_tarjeta As String
    Public Property c_nro_tarjeta() As String
        Get
            Return _c_nro_tarjeta
        End Get
        Set(ByVal value As String)
            _c_nro_tarjeta = value
        End Set
    End Property
    Public Property c_obs() As String
        Get
            Return _c_obs
        End Get
        Set(ByVal value As String)
            _c_obs = value
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
