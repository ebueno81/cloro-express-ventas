Public Class Ent_ApiContrato

    Public Property IdContrato As Integer
    Public Property CodigoContrato As String
    Public Property CodigoCliente As String
    Public Property NombreCliente As String
    Public Property FechaInicio As Nullable(Of DateTime)
    Public Property FechaFin As Nullable(Of DateTime)
    Public Property Moneda As String
    Public Property MontoMensual As Nullable(Of Decimal)
    Public Property Estado As Nullable(Of Integer)
    Public Property Observacion As String
    Public Property Ubicaciones As List(Of Ent_ApiUbicacion)

    Public Sub New()
        Ubicaciones = New List(Of Ent_ApiUbicacion)
    End Sub

End Class