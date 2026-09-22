Module ModSesion

    '=========================================
    ' USUARIO
    '=========================================
    Public UsuarioActual As String = ""


    '=========================================
    ' MODO DE OPERACIÓN
    ' Nothing = todavía no seleccionado
    ' True    = MEDXPRESS
    ' False   = CLORO EXPRESS
    '=========================================
    Public ModoMedXpress As Boolean? = Nothing


    Public ReadOnly Property EsMedXpress As Boolean
        Get
            Return ModoMedXpress.GetValueOrDefault(False)
        End Get
    End Property


    '=========================================
    ' GIRO DE NEGOCIO
    '=========================================
    Public IdGiro As Integer = 0
    Public GiroActual As String = ""


    '=========================================
    ' LIMPIAR SESIÓN
    '=========================================
    Public Sub LimpiarSesion()

        UsuarioActual = ""

        ModoMedXpress = Nothing

        IdGiro = 0
        GiroActual = ""

    End Sub

End Module