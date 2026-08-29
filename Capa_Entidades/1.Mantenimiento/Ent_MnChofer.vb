Public Class Ent_MnChofer
    Private _c_nro_brevete As String
    Private _c_codi_empserv As String
    Private _c_nom_chofer As String
    Private _c_ape_chofer As String
    Private _c_nro_dni As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_nro_brevete() As String
        Get
            Return _c_nro_brevete
        End Get
        Set(ByVal value As String)
            _c_nro_brevete = value
        End Set
    End Property
    Public Property c_codi_empserv() As String
        Get
            Return _c_codi_empserv
        End Get
        Set(ByVal value As String)
            _c_codi_empserv = value
        End Set
    End Property
    Public Property c_nom_chofer() As String
        Get
            Return _c_nom_chofer
        End Get
        Set(ByVal value As String)
            _c_nom_chofer = value
        End Set
    End Property

    Public Property c_ape_chofer() As String
        Get
            Return _c_ape_chofer
        End Get
        Set(ByVal value As String)
            _c_ape_chofer = value
        End Set
    End Property
    Public Property c_nro_dni() As String
        Get
            Return _c_nro_dni
        End Get
        Set(ByVal value As String)
            _c_nro_dni = value
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
