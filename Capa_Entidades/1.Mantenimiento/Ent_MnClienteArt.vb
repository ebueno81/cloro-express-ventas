Public Class Ent_MnClienteArt
    Private _c_codi_clie As String
    Private _c_codi_articulo As String
    Private _c_precio_srv_mn As Decimal
    Private _c_precio_srv_us As Decimal
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_clie() As String
        Get
            Return _c_codi_clie
        End Get
        Set(ByVal value As String)
            _c_codi_clie = value
        End Set
    End Property
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
        End Set
    End Property
    Public Property c_precio_srv_mn() As Decimal
        Get
            Return _c_precio_srv_mn
        End Get
        Set(ByVal value As Decimal)
            _c_precio_srv_mn = value
        End Set
    End Property
    Public Property c_precio_srv_us() As Decimal
        Get
            Return _c_precio_srv_us
        End Get
        Set(ByVal value As Decimal)
            _c_precio_srv_us = value
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
