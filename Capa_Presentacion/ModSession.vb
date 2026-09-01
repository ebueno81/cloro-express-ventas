Module ModSesion

    Public ModoMedXpress As Boolean? = Nothing
    Public UsuarioActual As String = ""

    Public ReadOnly Property EsMedXpress As Boolean
        Get
            Return ModoMedXpress.GetValueOrDefault(False)
        End Get
    End Property

End Module