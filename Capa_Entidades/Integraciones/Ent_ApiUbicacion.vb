Public Class Ent_ApiUbicacion

    Private _IdUbicacion As Integer
    Private _Descripcion As String
    Private _EsDefecto As Nullable(Of Integer)

    Public Property IdUbicacion() As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(ByVal value As Integer)
            _IdUbicacion = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property EsDefecto() As Nullable(Of Integer)
        Get
            Return _EsDefecto
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _EsDefecto = value
        End Set
    End Property

End Class