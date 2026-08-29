Public Class Ent_Modulos
    Dim _c_codi_modulo As String
    Dim _c_nom_modulo As String
    Dim _c_nom_menu As String
    Dim _c_nom_formu As String
    Dim _c_nom_tool As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_modulo() As String
        Get
            Return _c_codi_modulo
        End Get
        Set(ByVal value As String)
            _c_codi_modulo = value
        End Set
    End Property
    Public Property c_nom_modulo() As String
        Get
            Return _c_nom_modulo
        End Get
        Set(ByVal value As String)
            _c_nom_modulo = value
        End Set
    End Property
    Public Property c_nom_menu() As String
        Get
            Return _c_nom_menu
        End Get
        Set(ByVal value As String)
            _c_nom_menu = value
        End Set
    End Property
    Public Property c_nom_formu() As String
        Get
            Return _c_nom_formu
        End Get
        Set(ByVal value As String)
            _c_nom_formu = value
        End Set
    End Property
    Public Property c_nom_tool() As String
        Get
            Return _c_nom_tool
        End Get
        Set(ByVal value As String)
            _c_nom_tool = value
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
