Public Class Ent_Inventario_Det
    Dim _c_nro_inventario As String
    Dim _c_nro_columna As String
    Dim _c_nro_etiqueta As String
    Dim _copcion As String
    Public Property c_nro_inventario() As String
        Get
            Return _c_nro_inventario
        End Get
        Set(ByVal value As String)
            _c_nro_inventario = value
        End Set
    End Property
    Public Property c_nro_columna() As String
        Get
            Return _c_nro_columna
        End Get
        Set(ByVal value As String)
            _c_nro_columna = value
        End Set
    End Property
    Public Property c_nro_etiqueta() As String
        Get
            Return _c_nro_etiqueta
        End Get
        Set(ByVal value As String)
            _c_nro_etiqueta = value
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
