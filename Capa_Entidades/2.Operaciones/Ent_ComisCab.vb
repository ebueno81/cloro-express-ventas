Public Class Ent_ComisCab
    Dim _c_nro_comis As String
    Dim _c_fecha_inicio As Date
    Dim _c_fecha_final As Date
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_comis() As String
        Get
            Return _c_nro_comis
        End Get
        Set(ByVal value As String)
            _c_nro_comis = value
        End Set
    End Property
    Public Property c_fecha_inicio() As Date
        Get
            Return _c_fecha_inicio
        End Get
        Set(ByVal value As Date)
            _c_fecha_inicio = value
        End Set
    End Property
    Public Property c_fecha_final() As Date
        Get
            Return _c_fecha_final
        End Get
        Set(ByVal value As Date)
            _c_fecha_final = value
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
