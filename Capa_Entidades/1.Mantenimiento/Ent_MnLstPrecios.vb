Public Class Ent_MnLstPrecios
    Private _c_nro_partida As String
    Private _c_codi_tg As String
    Private _c_codi_cd As String
    Private _c_codi_scd As String
    Private _c_codi_color As String
    Private _c_costo_mn As Decimal
    Private _c_costo_us As Decimal
    Private _c_venta_mn As Decimal
    Private _c_venta_us As Decimal
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_nro_partida() As String
        Get
            Return _c_nro_partida
        End Get
        Set(ByVal value As String)
            _c_nro_partida = value
        End Set
    End Property
    Public Property c_codi_tg() As String
        Get
            Return _c_codi_tg
        End Get
        Set(ByVal value As String)
            _c_codi_tg = value
        End Set
    End Property
    Public Property c_codi_cd() As String
        Get
            Return _c_codi_cd
        End Get
        Set(ByVal value As String)
            _c_codi_cd = value
        End Set
    End Property
    Public Property c_codi_scd() As String
        Get
            Return _c_codi_scd
        End Get
        Set(ByVal value As String)
            _c_codi_scd = value
        End Set
    End Property

    Public Property c_codi_color() As String
        Get
            Return _c_codi_color
        End Get
        Set(ByVal value As String)
            _c_codi_color = value
        End Set
    End Property
    Public Property c_costo_mn() As Decimal
        Get
            Return _c_costo_mn
        End Get
        Set(ByVal value As Decimal)
            _c_costo_mn = value
        End Set
    End Property
    Public Property c_costo_us() As Decimal
        Get
            Return _c_costo_us
        End Get
        Set(ByVal value As Decimal)
            _c_costo_us = value
        End Set
    End Property
    Public Property c_venta_mn() As Decimal
        Get
            Return _c_venta_mn
        End Get
        Set(ByVal value As Decimal)
            _c_venta_mn = value
        End Set
    End Property
    Public Property c_venta_us() As Decimal
        Get
            Return _c_venta_us
        End Get
        Set(ByVal value As Decimal)
            _c_venta_us = value
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
