Public Class Ent_UsuaPermiso
    Dim _c_codi_usua As String
    Dim _c_codi_modulo As String
    Dim _c_add_obj As String
    Dim _c_edit_obj As String
    Dim _c_find_obj As String
    Dim _c_del_obj As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_usua() As String
        Get
            Return _c_codi_usua
        End Get
        Set(ByVal value As String)
            _c_codi_usua = value
        End Set
    End Property
    Public Property c_codi_modulo() As String
        Get
            Return _c_codi_modulo
        End Get
        Set(ByVal value As String)
            _c_codi_modulo = value
        End Set
    End Property
    Public Property c_add_obj() As String
        Get
            Return _c_add_obj
        End Get
        Set(ByVal value As String)
            _c_add_obj = value
        End Set
    End Property
    Public Property c_edit_obj() As String
        Get
            Return _c_edit_obj
        End Get
        Set(ByVal value As String)
            _c_edit_obj = value
        End Set
    End Property
    Public Property c_find_obj() As String
        Get
            Return _c_find_obj
        End Get
        Set(ByVal value As String)
            _c_find_obj = value
        End Set
    End Property
    Public Property c_del_obj() As String
        Get
            Return _c_del_obj
        End Get
        Set(ByVal value As String)
            _c_del_obj = value
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
