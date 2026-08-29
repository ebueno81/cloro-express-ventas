Public Class Ent_MnMtMov
    Private _c_codi_mt As String
    Private _c_desc_mt As String
    Private _c_opc_prove As String
    Private _c_codi_sunat As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_mt() As String
        Get
            Return _c_codi_mt
        End Get
        Set(ByVal value As String)
            _c_codi_mt = value
        End Set
    End Property
    Public Property c_desc_mt() As String
        Get
            Return _c_desc_mt
        End Get
        Set(ByVal value As String)
            _c_desc_mt = value
        End Set
    End Property
    Public Property c_opc_prove() As Integer
        Get
            Return _c_opc_prove
        End Get
        Set(ByVal value As Integer)
            _c_opc_prove = value
        End Set
    End Property
    Public Property c_codi_sunat() As String
        Get
            Return _c_codi_sunat
        End Get
        Set(ByVal value As String)
            _c_codi_sunat = value
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
