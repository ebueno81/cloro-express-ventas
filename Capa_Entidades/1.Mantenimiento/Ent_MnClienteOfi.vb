Public Class Ent_MnClienteOfi
    Private _c_codi_oficina As String
    Private _c_codi_clie As String
    Private _c_codi_ubigeo As String
    Private _c_direc_clie As String
    Private _c_dist_clie As String
    Private _c_prov_clie As String
    Private _c_dpto_clie As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_oficina() As String
        Get
            Return _c_codi_oficina
        End Get
        Set(ByVal value As String)
            _c_codi_oficina = value
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

    Public Property c_codi_ubigeo() As String
        Get
            Return _c_codi_ubigeo
        End Get
        Set(ByVal value As String)
            _c_codi_ubigeo = value
        End Set
    End Property
    Public Property c_direc_clie() As String
        Get
            Return _c_direc_clie
        End Get
        Set(ByVal value As String)
            _c_direc_clie = value
        End Set
    End Property
    Public Property c_dist_clie() As String
        Get
            Return _c_dist_clie
        End Get
        Set(ByVal value As String)
            _c_dist_clie = value
        End Set
    End Property
    Public Property c_prov_clie() As String
        Get
            Return _c_prov_clie
        End Get
        Set(ByVal value As String)
            _c_prov_clie = value
        End Set
    End Property
    Public Property c_dpto_clie() As String
        Get
            Return _c_dpto_clie
        End Get
        Set(ByVal value As String)
            _c_dpto_clie = value
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
