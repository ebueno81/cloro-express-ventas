Public Class Ent_MnSeriesGuia
    Private _c_nro_serie As String
    Private _c_nro_guia As String
    Private _c_desc_serie As String
    Private _c_opc_electronico As Integer
    Private _c_guia_interna As Integer
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_guia() As String
        Get
            Return _c_nro_guia
        End Get
        Set(ByVal value As String)
            _c_nro_guia = value
        End Set
    End Property
    Public Property c_desc_serie() As String
        Get
            Return _c_desc_serie
        End Get
        Set(ByVal value As String)
            _c_desc_serie = value
        End Set
    End Property

    Public Property c_opc_electronico() As Integer
        Get
            Return _c_opc_electronico
        End Get
        Set(ByVal value As Integer)
            _c_opc_electronico = value
        End Set
    End Property

    Public Property c_guia_interna() As Integer
        Get
            Return _c_guia_interna
        End Get
        Set(ByVal value As Integer)
            _c_guia_interna = value
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
