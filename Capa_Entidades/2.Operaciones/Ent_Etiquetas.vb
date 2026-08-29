Public Class Ent_Etiquetas
    Dim _c_nro_etiqueta As String
    Dim _c_nro_partida As String
    Dim _c_codi_tg As String
    Dim _c_codi_cd As String
    Dim _c_codi_scd As String
    Dim _c_codi_color As String
    Dim _c_nro_cant As Decimal
    Dim _c_codi_unimed As String
    Dim _c_nro_rollos As Decimal
    Dim _c_codi_unimed2 As String   
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_etiqueta() As String
        Get
            Return _c_nro_etiqueta
        End Get
        Set(ByVal value As String)
            _c_nro_etiqueta = value
        End Set
    End Property
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
    Public Property c_nro_cant() As Decimal
        Get
            Return _c_nro_cant
        End Get
        Set(ByVal value As Decimal)
            _c_nro_cant = value
        End Set
    End Property
    Public Property c_codi_unimed() As String
        Get
            Return _c_codi_unimed
        End Get
        Set(ByVal value As String)
            _c_codi_unimed = value
        End Set
    End Property
    Public Property c_nro_rollos() As Decimal
        Get
            Return _c_nro_rollos
        End Get
        Set(ByVal value As Decimal)
            _c_nro_rollos = value
        End Set
    End Property
    Public Property c_codi_unimed2() As Decimal
        Get
            Return _c_codi_unimed2
        End Get
        Set(ByVal value As Decimal)
            _c_codi_unimed2 = value
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
