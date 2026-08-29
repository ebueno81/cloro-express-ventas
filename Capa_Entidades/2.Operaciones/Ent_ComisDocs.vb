Public Class Ent_ComisDocs
    Dim _c_nro_correl As String
    Dim _c_nro_comis As String
    Dim _c_codi_vende As String
    Dim _c_codi_doc As String
    Dim _c_serie_doc As String
    Dim _c_nro_doc As String
    Dim _c_codi_mon As String
    Dim _c_imp_doc As Decimal
    Dim _c_obs As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_comis() As String
        Get
            Return _c_nro_comis
        End Get
        Set(ByVal value As String)
            _c_nro_comis = value
        End Set
    End Property
    Public Property c_codi_vende() As String
        Get
            Return _c_codi_vende
        End Get
        Set(ByVal value As String)
            _c_codi_vende = value
        End Set
    End Property
    Public Property c_codi_doc() As String
        Get
            Return _c_codi_doc
        End Get
        Set(ByVal value As String)
            _c_codi_doc = value
        End Set
    End Property
    Public Property c_serie_doc() As String
        Get
            Return _c_serie_doc
        End Get
        Set(ByVal value As String)
            _c_serie_doc = value
        End Set
    End Property
    Public Property c_nro_doc() As String
        Get
            Return _c_nro_doc
        End Get
        Set(ByVal value As String)
            _c_nro_doc = value
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
    Public Property c_imp_doc() As Decimal
        Get
            Return _c_imp_doc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_doc = value
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
