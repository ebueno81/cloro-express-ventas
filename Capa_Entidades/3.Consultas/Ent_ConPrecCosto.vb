Public Class Ent_ConPrecCosto
    Dim _c_codi_tg As String
    Dim _c_codi_cd As String
    Dim _c_codi_scd As String
    Dim _c_codi_alm As String
    Dim _c_nro_partida As String
    Dim _c_fecha_kdx As String
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
    Public Property c_codi_alm() As String
        Get
            Return _c_codi_alm
        End Get
        Set(ByVal value As String)
            _c_codi_alm = value
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
    Public Property c_fecha_kdx() As Date
        Get
            Return _c_fecha_kdx
        End Get
        Set(ByVal value As Date)
            _c_fecha_kdx = value
        End Set
    End Property
End Class
