Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Module ModUtils

    Public Sub CargarComboMoneda(ByVal Combo As ComboBox)

        Dim Dt As New DataTable

        Dt.Columns.Add("Codigo", GetType(String))
        Dt.Columns.Add("Descripcion", GetType(String))

        Dt.Rows.Add("PEN", "Soles (PEN)")
        Dt.Rows.Add("USD", "Dólares (USD)")

        Combo.DataSource = Nothing
        Combo.DisplayMember = "Descripcion"
        Combo.ValueMember = "Codigo"
        Combo.DataSource = Dt

        Combo.SelectedIndex = -1

    End Sub

    Public Sub ExportarDataGridViewExcel(
    ByVal Dgv As DataGridView,
    Optional ByVal Titulo As String = "REPORTE",
    Optional ByVal NombreHoja As String = "Reporte",
    Optional ByVal ExportarColumnasOcultas As Boolean = False,
    Optional ByVal BarraProgreso As ProgressBar = Nothing)

        Dim ExcelApp As Excel.Application = Nothing
        Dim Libro As Excel.Workbook = Nothing
        Dim Hoja As Excel.Worksheet = Nothing

        Try

            '-------------------------------------------------------
            ' VALIDAR REGISTROS
            '-------------------------------------------------------
            If Dgv Is Nothing Then
                Exit Sub
            End If

            If Dgv.Rows.Count = 0 Then

                MsgBox(
                "No existen registros para exportar.",
                vbExclamation,
                "Exportar a Excel")

                Exit Sub

            End If


            Cursor.Current = Cursors.WaitCursor


            '-------------------------------------------------------
            ' INICIALIZAR PROGRESSBAR
            '-------------------------------------------------------
            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Minimum = 0
                BarraProgreso.Maximum = 100
                BarraProgreso.Value = 0
                BarraProgreso.Visible = True

                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' OBTENER COLUMNAS A EXPORTAR
            '-------------------------------------------------------
            Dim Columnas As New List(Of DataGridViewColumn)

            For Each Col As DataGridViewColumn In Dgv.Columns

                If ExportarColumnasOcultas = True OrElse
               Col.Visible = True Then

                    Columnas.Add(Col)

                End If

            Next


            If Columnas.Count = 0 Then
                Exit Sub
            End If


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 5
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' CONTAR FILAS REALES
            '-------------------------------------------------------
            Dim TotalFilas As Integer = 0

            For Each Fila As DataGridViewRow In Dgv.Rows

                If Fila.IsNewRow = False Then
                    TotalFilas += 1
                End If

            Next


            If TotalFilas = 0 Then

                MsgBox(
                "No existen registros para exportar.",
                vbExclamation,
                "Exportar a Excel")

                Exit Sub

            End If


            '-------------------------------------------------------
            ' CREAR ARRAY EN MEMORIA
            '
            ' FILA 0 = ENCABEZADOS
            ' RESTO  = INFORMACION
            '-------------------------------------------------------
            Dim Datos(TotalFilas, Columnas.Count - 1) As Object


            '-------------------------------------------------------
            ' ENCABEZADOS
            '-------------------------------------------------------
            For C As Integer = 0 To Columnas.Count - 1

                Datos(0, C) =
                Columnas(C).HeaderText

            Next


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 10
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' DATOS
            '-------------------------------------------------------
            Dim F As Integer = 1
            Dim FilasProcesadas As Integer = 0

            For Each Fila As DataGridViewRow In Dgv.Rows

                If Fila.IsNewRow = False Then

                    For C As Integer = 0 To Columnas.Count - 1

                        Dim Valor As Object =
                        Fila.Cells(Columnas(C).Index).Value

                        If Valor Is Nothing OrElse
                       Valor Is DBNull.Value Then

                            Datos(F, C) = ""

                        Else

                            Datos(F, C) = Valor

                        End If

                    Next


                    F += 1
                    FilasProcesadas += 1


                    '---------------------------------------------------
                    ' ACTUALIZAR PROGRESO 10% - 60%
                    '---------------------------------------------------
                    If BarraProgreso IsNot Nothing Then

                        Dim Porcentaje As Integer

                        Porcentaje =
                        10 +
                        CInt(
                            (FilasProcesadas / TotalFilas) *
                            50)

                        If Porcentaje > 60 Then
                            Porcentaje = 60
                        End If

                        BarraProgreso.Value = Porcentaje

                        'NO HACER DoEvents EN CADA FILA
                        If FilasProcesadas Mod 100 = 0 OrElse
                       FilasProcesadas = TotalFilas Then

                            Application.DoEvents()

                        End If

                    End If

                End If

            Next


            '-------------------------------------------------------
            ' ABRIR EXCEL
            '-------------------------------------------------------
            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 65
                Application.DoEvents()

            End If


            ExcelApp = New Excel.Application

            Libro = ExcelApp.Workbooks.Add()

            Hoja =
            CType(
                Libro.Worksheets(1),
                Excel.Worksheet)


            '-------------------------------------------------------
            ' NOMBRE DE HOJA
            '-------------------------------------------------------
            NombreHoja =
            NombreHoja.Replace("/", "").
                       Replace("\", "").
                       Replace("?", "").
                       Replace("*", "").
                       Replace("[", "").
                       Replace("]", "").
                       Replace(":", "")

            If NombreHoja.Length > 31 Then
                NombreHoja = NombreHoja.Substring(0, 31)
            End If

            If Trim(NombreHoja) = "" Then
                NombreHoja = "Reporte"
            End If

            Hoja.Name = NombreHoja


            '-------------------------------------------------------
            ' TITULO
            '-------------------------------------------------------
            Hoja.Cells(1, 1) = Titulo

            Dim RangoTitulo As Excel.Range

            RangoTitulo =
            Hoja.Range(
                Hoja.Cells(1, 1),
                Hoja.Cells(1, Columnas.Count))

            RangoTitulo.Merge()


            With RangoTitulo

                .Font.Bold = True
                .Font.Size = 16

                'COLOR AZUL
                .Font.Color =
                RGB(31, 78, 121)

                .HorizontalAlignment =
                Excel.XlHAlign.xlHAlignCenter

                .VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter

                .RowHeight = 28

            End With


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 70
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' PASAR TODO EL ARRAY A EXCEL DE UNA SOLA VEZ
            '-------------------------------------------------------
            Dim RangoDatos As Excel.Range

            RangoDatos =
            Hoja.Range(
                Hoja.Cells(3, 1),
                Hoja.Cells(
                    TotalFilas + 3,
                    Columnas.Count))


            RangoDatos.Value2 = Datos


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 80
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' FORMATO DE ENCABEZADOS
            '-------------------------------------------------------
            Dim RangoEncabezado As Excel.Range

            RangoEncabezado =
            Hoja.Range(
                Hoja.Cells(3, 1),
                Hoja.Cells(3, Columnas.Count))


            With RangoEncabezado

                .Font.Bold = True

                'FONDO AZUL
                .Interior.Color =
                RGB(31, 78, 121)

                'LETRA BLANCA
                .Font.Color =
                RGB(255, 255, 255)

                .HorizontalAlignment =
                Excel.XlHAlign.xlHAlignCenter

                .VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter

                .RowHeight = 22

            End With


            '-------------------------------------------------------
            ' FORMATO GENERAL DEL DETALLE
            '-------------------------------------------------------
            Dim RangoDetalle As Excel.Range

            RangoDetalle =
            Hoja.Range(
                Hoja.Cells(4, 1),
                Hoja.Cells(
                    TotalFilas + 3,
                    Columnas.Count))


            With RangoDetalle

                .VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter

                .RowHeight = 20

            End With


            '-------------------------------------------------------
            ' BORDES
            '-------------------------------------------------------
            With RangoDatos.Borders

                .LineStyle =
                Excel.XlLineStyle.xlContinuous

                .Color =
                RGB(200, 200, 200)

                .Weight =
                Excel.XlBorderWeight.xlThin

            End With


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 85
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' AUTO AJUSTAR COLUMNAS
            '-------------------------------------------------------
            RangoDatos.Columns.AutoFit()


            '-------------------------------------------------------
            ' EVITAR COLUMNAS DEMASIADO ANCHAS
            '-------------------------------------------------------
            Dim ColExcel As Excel.Range

            For C As Integer = 1 To Columnas.Count

                ColExcel =
                CType(
                    Hoja.Columns(C),
                    Excel.Range)

                If ColExcel.ColumnWidth > 40 Then
                    ColExcel.ColumnWidth = 40
                End If

            Next


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 90
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' FILTRO AUTOMATICO
            '-------------------------------------------------------
            Try

                Dim RangoFiltro As Excel.Range

                RangoFiltro =
        Hoja.Range(
            Hoja.Cells(3, 1),
            Hoja.Cells(
                TotalFilas + 3,
                Columnas.Count))

                RangoFiltro.AutoFilter()

            Catch

                '---------------------------------------------------
                ' SI EXCEL NO PERMITE EL AUTOFILTER
                ' CONTINUAR NORMALMENTE CON LA EXPORTACION
                '---------------------------------------------------

            End Try

            '-------------------------------------------------------
            ' CONGELAR ENCABEZADO
            '-------------------------------------------------------
            Hoja.Activate()

            ExcelApp.ActiveWindow.SplitRow = 3
            ExcelApp.ActiveWindow.FreezePanes = True


            '-------------------------------------------------------
            ' QUITAR LINEAS DE CUADRICULA
            '-------------------------------------------------------
            ExcelApp.ActiveWindow.DisplayGridlines = False


            '-------------------------------------------------------
            ' ZOOM
            '-------------------------------------------------------
            ExcelApp.ActiveWindow.Zoom = 90


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 95
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' MOSTRAR EXCEL
            '-------------------------------------------------------
            ExcelApp.Visible = True

            ExcelApp.UserControl = True


            '-------------------------------------------------------
            ' FINALIZAR PROGRESO
            '-------------------------------------------------------
            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 100
                Application.DoEvents()

            End If


            '-------------------------------------------------------
            ' EXCEL QUEDA ABIERTO PARA EL USUARIO
            '-------------------------------------------------------
            Hoja = Nothing
            Libro = Nothing
            ExcelApp = Nothing


        Catch ex As Exception

            If ExcelApp IsNot Nothing Then

                Try
                    ExcelApp.Visible = True
                Catch
                End Try

            End If


            MsgBox(
            "No se pudo exportar la información a Excel." &
            vbCrLf &
            vbCrLf &
            ex.Message,
            vbCritical,
            "Exportar a Excel")


        Finally

            Cursor.Current = Cursors.Default


            If BarraProgreso IsNot Nothing Then

                BarraProgreso.Value = 0
                BarraProgreso.Visible = False

            End If

        End Try

    End Sub
End Module