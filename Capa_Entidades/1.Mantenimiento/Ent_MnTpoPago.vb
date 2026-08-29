Public Class Ent_MnTpoPago
    Dim _c_codi_pago As String
    Dim _c_desc_pago As String
    Dim _c_nro_dias As Integer
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_pago() As String
        Get
            Return _c_codi_pago
        End Get
        Set(ByVal value As String)
            _c_codi_pago = value
        End Set
    End Property
    Public Property c_desc_pago() As String
        Get
            Return _c_desc_pago
        End Get
        Set(ByVal value As String)
            _c_desc_pago = value
        End Set
    End Property
    Public Property c_nro_dias() As Integer
        Get
            Return _c_nro_dias
        End Get
        Set(ByVal value As Integer)
            _c_nro_dias = value
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
