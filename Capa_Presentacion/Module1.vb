Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Capa_Negocios
Module Module1
    Public Compañia As String = "Sistema Administrativo - SysVenTA 3.0"
    Public Forma_1_1 As String = "##0.0"
    Public Forma_1_2 As String = "##0.00"
    Public Forma_1_3 As String = "##0.000"
    Public Forma_1_4 As String = "##0.0000"
    Public Forma_1_5 As String = "##0.00000"
    Public Forma_1_6 As String = "##0.000000"
    Public Forma_1_7 As String = "##0.0000000"

    Public Forma_2_0 As String = "#,##0"
    Public Forma_2_1 As String = "#,##0.0"
    Public Forma_2_2 As String = "#,##0.00"
    Public Forma_2_3 As String = "#,##0.000"
    Public Forma_2_4 As String = "#,##0.0000"

    Dim c_Neg_MnIGV As New Neg_MnIgv
    Dim c_Neg_TpoCambio As New Neg_MnTpoCambio
    Public Sub Limpiar_Texto(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.text = ""
            If TypeOf control Is ComboBox Then control.text = ""
            If TypeOf control Is ComboBox Then control.SelectedIndex = -1
        Next
    End Sub
    'metodo que nos permite avanzar al dar enter
    Public Sub Avanzar_Enter(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    
    'Metodo que nos permite activar las cajas de textos
    Public Sub Activar(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.enabled = True
            If TypeOf control Is ComboBox Then control.enabled = True
            ' If TypeOf control Is ComboBox Then control.selectindex = -1
        Next
    End Sub
    'Metodo que nos permite desactivar las cajas de textos
    Public Sub Desactivar(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.enabled = False
            If TypeOf control Is ComboBox Then control.enabled = False
        Next
    End Sub
    Public Sub solonumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789,-,." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    'mostramos igv...
    Public Sub Mostrar_IGV(ByVal Fecha As Date, ByVal Caja As TextBox)
        With c_Neg_MnIGV.get_Igv_Datos(" and c_fecha_emi<='" & Fecha & "' order by c_fecha_emi desc", "DAT")
            Caja.Clear()
            If .Rows.Count > 0 Then Caja.Text = Val(.Rows(0)("c_por_igv").ToString)
        End With
    End Sub
    'mostramos tipo de cambio...
    Public Sub Mostrar_TpoCambio(ByVal Fecha As Date, ByVal Caja As TextBox)
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo='" & Fecha & "'", "DAT")
            Caja.Clear()
            If .Rows.Count > 0 Then Caja.Text = .Rows(0)("c_venta_sunat").ToString
        End With
    End Sub
    Public Function num2text(ByVal value As Double) As String
        Select Case value
            Case 0 : num2text = "CERO"
            Case 1 : num2text = "UN"
            Case 2 : num2text = "DOS"
            Case 3 : num2text = "TRES"
            Case 4 : num2text = "CUATRO"
            Case 5 : num2text = "CINCO"
            Case 6 : num2text = "SEIS"
            Case 7 : num2text = "SIETE"
            Case 8 : num2text = "OCHO"
            Case 9 : num2text = "NUEVE"
            Case 10 : num2text = "DIEZ"
            Case 11 : num2text = "ONCE"
            Case 12 : num2text = "DOCE"
            Case 13 : num2text = "TRECE"
            Case 14 : num2text = "CATORCE"
            Case 15 : num2text = "QUINCE"
            Case Is < 20 : num2text = "DIECI" & num2text(value - 10)
            Case 20 : num2text = "VEINTE"
            Case Is < 30 : num2text = "VEINTI" & num2text(value - 20)
            Case 30 : num2text = "TREINTA"
            Case 40 : num2text = "CUARENTA"
            Case 50 : num2text = "CINCUENTA"
            Case 60 : num2text = "SESENTA"
            Case 70 : num2text = "SETENTA"
            Case 80 : num2text = "OCHENTA"
            Case 90 : num2text = "NOVENTA"
            Case Is < 100 : num2text = num2text(Int(value \ 10) * 10) & " Y " & num2text(value Mod 10)
            Case 100 : num2text = "CIEN"
            Case Is < 200 : num2text = "CIENTO " & num2text(value - 100)
            Case 200, 300, 400, 600, 800 : num2text = num2text(Int(value \ 100)) & "CIENTOS"
            Case 500 : num2text = "QUINIENTOS"
            Case 700 : num2text = "SETECIENTOS"
            Case 900 : num2text = "NOVECIENTOS"
            Case Is < 1000 : num2text = num2text(Int(value \ 100) * 100) & " " & num2text(value Mod 100)
            Case 1000 : num2text = "MIL"
            Case Is < 2000 : num2text = "MIL " & num2text(value Mod 1000)
            Case Is < 1000000 : num2text = num2text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then num2text = num2text & " " & num2text(value Mod 1000)
            Case 1000000 : num2text = "UN MILLON"
            Case Is < 2000000 : num2text = "UN MILLON " & num2text(value Mod 1000000)
            Case Is < 1000000000000.0# : num2text = num2text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then num2text = num2text & " " & num2text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : num2text = "UN BILLON"
            Case Is < 2000000000000.0# : num2text = "UN BILLON " & num2text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : num2text = num2text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then num2text = num2text & " " & num2text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function
    'Metodo que nos permite movilizarnos en un datagrid desde una caja de texto por medio de las teclas direccionales...
    Public Sub Movilizar_Grid(ByVal Dgv As DataGridView, ByVal x As Integer, ByVal Tipo_Avance As String)
        With Dgv
            On Error Resume Next
            If Tipo_Avance = "ABAJO" Then
                If Not .CurrentCell.RowIndex + 1 = .NewRowIndex Then
                    .Rows(x).Selected = True
                    .CurrentCell = Dgv(.CurrentCell.ColumnIndex, x)
                End If
            End If
            If Tipo_Avance = "ARRIBA" Then
                If Not .CurrentCell.RowIndex - 1 = -1 Then
                    .Rows(x).Selected = True
                    .CurrentCell = Dgv(.CurrentCell.ColumnIndex, x)
                End If
            End If
        End With
    End Sub
    Public Sub Movilizar_Registros(ByVal Dgv As DataGridView, ByVal TxtReg As TextBox, ByVal TxtTpo As Integer)
        With Dgv
            Dim Fila As Integer = 0
            If .RowCount > 0 Then
                If TxtTpo = 1 Then
                    Fila = 0
                End If 'Atras
                If TxtTpo = 2 Then
                    Fila = .CurrentCellAddress.Y
                    If Fila > 0 Then Fila = Fila - 1
                End If 'Avanza
                If TxtTpo = 3 Then
                    Fila = .CurrentCellAddress.Y
                    If Fila < .RowCount - 1 Then Fila = Fila + 1
                End If 'Final
                If TxtTpo = 4 Then
                    Fila = .RowCount - 1
                End If
                For i = 0 To .RowCount - 1
                    .Rows(i).Selected = False
                Next 'Inicio
                .Rows(Fila).Selected = True : .CurrentCell = Dgv(.CurrentCell.ColumnIndex, Fila)
                TxtReg.Text = Fila + 1 & " / " & .RowCount
            End If
        End With
    End Sub
    'Metodo que nos permite validar la numeracion de comprobantes de pago...
    Public Sub Concar_Numeracion(ByVal Tabla As String, ByVal Dsubdia As String, ByVal Fecha As String, ByVal Ruta_concar As String, ByVal TxtCorrel As TextBox)
        Dim x As Integer = 0
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Ruta_concar & " Extended Properties=dBASE IV;")
        Dim sql As String = ""
        conn.Open()
        Dim Sdata As New OleDbDataAdapter("select*from Cnu" & Tabla & " Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'", conn)
        Dim Dts As New DataSet
        Sdata.Fill(Dts, "Existe_Num")

        With Dts.Tables("Existe_Num")
            If .Rows.Count > 0 Then
                sql = "update Cnu" & Tabla & " set Ctnumer=Ctnumer+1 Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'"
            Else
                sql = "insert into Cnu" & Tabla & "(Ctsubdia,Ctano,Ctmes,Ctnumer,Ctfeccre,Ctfecact) values('" & Dsubdia & "','" & Strings.Left(Fecha, 2) & "','" & _
                Strings.Mid(Fecha, 3, 2) & "',1,'" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "')"
            End If
        End With
        Dim cmd As New OleDbCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Dim data As New OleDbDataAdapter("select*from Cnu" & Tabla & " Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'", conn)
        data.Fill(Dts, "Correl")
        With Dts.Tables("Correl")
            TxtCorrel.Clear()
            If .Rows.Count > 0 Then TxtCorrel.Text = Mid(Fecha, 3, 2) & Strings.Right(Val(.Rows(0)("Ctnumer").ToString) + 10000, 4)

        End With
        conn.Dispose()
        cmd.Dispose()
        Sdata.Dispose()
        data.Dispose()
    End Sub
    'Metodo que nos Permite Buscar si un archivo esta registrado...
    Public Sub Buscar_Valor_Tablas_Concar(ByVal sql As String, ByVal x As TextBox, ByVal ruta_concar As String)
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ruta_concar & " Extended Properties=dBASE IV;")
        'Dim sql As String = "SELECT * FROM CCC0210.dbf"
        Dim Adt As New OleDb.OleDbDataAdapter(sql, conn)
        Dim dts As New DataSet
        Adt.Fill(dts, "Tabla")
        With dts.Tables("Tabla")
            'Validamos si existe el valor ingresado
            x.Clear()
            If .Rows.Count > 0 Then 'si existe
                x.Text = 1
            Else 'No existe  
                x.Text = 0
            End If
        End With 'eliminamos variables...
        conn.Dispose() : Adt.Dispose() : dts.Dispose()
    End Sub
    'Metodo que nos permite grabar en las tablas sql
    Public Sub Grabar_Tablas_sql(ByVal sql As String, ByVal ruta_base As String)
        ruta_base = FrmMenu.TxtRuta_Concar.Text
        Dim conex As New OleDbConnection(ruta_base)
        conex.Open()
        Dim cmd As New OleDbCommand(sql, conex)
        cmd.ExecuteNonQuery()
        conex.Dispose()
        cmd.Dispose()
    End Sub
    'Metodo que nos permite jalar el codigo de un combo que se encuentre amarrado al combo
    Public Sub Combo_Jalar_Codigo(ByVal combo As ComboBox, ByVal Caja As TextBox)
        If combo.SelectedIndex > -1 Then
            On Error Resume Next : Caja.Text = combo.SelectedValue
        End If
    End Sub
    ' Metodo para exportar a excel '
    Function GridAExcel_Valor(ByVal elgrid As DataGridView, ByVal Exportar As Integer, ByVal Pan As Panel, _
                            ByVal Prb01 As ProgressBar, ByVal Ruta_Archivo As String) As Boolean
        Dim Preguntar As String = ""
        If Exportar = 0 Then 'enviar a excel
            Preguntar = "¿Desea Enviar los Datos a Excel?"
        Else 'exportar a excel
            Preguntar = "¿Desea Exportar los Datos a Excel?"
        End If
        Dim F As String = MsgBox(" " & Preguntar & " ", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            Dim y As Integer = 0

            Dim exapp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            With elgrid
                Try
                    Pan.Visible = True
                    Prb01.Visible = True : Prb01.Value = 0
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'aplicamos tamaño y negrita

                    For I = 1 To NCol
                        'ponemos lineas para el titulo
                        exHoja.Cells(1, I).Borders(8).LineStyle = 1 'BOTTOM
                        exHoja.Cells(1, I).Borders(9).LineStyle = 1 'TOP

                        'ponemos lineas para las cabeceras
                        exHoja.Cells(1, I).Borders(8).LineStyle = 1 'BOTTOM
                        exHoja.Cells(1, I).Borders(9).LineStyle = 1 'TOP
                        exHoja.Cells.Item(1, I) = .Columns(I - 1).HeaderText
                        exHoja.Cells.Item(1, I).Font.Bold = True
                    Next
                    'APLICAMOS EL VALOR MAXIMO
                    Prb01.Maximum = NRow
                    .ClearSelection()
                    For Fila As Integer = 0 To NRow - 1
                        'exportamos detalles del listview...
                        For Col = 1 To NCol
                            exHoja.Cells(Fila + 1, Col).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col).Font.Colorindex = 1
                            'validamos el campo fecha para mostrarlo en formato corto
                            exHoja.Cells.Item(Fila + 2, Col) = .Rows(Fila).Cells(Col - 1).Value
                        Next
                        'ponemos en negrita
                        'For I = 7 To 11
                        'exHoja.Cells.Item(fila + 5, I).Font.Bold = True

                        'Next
                        .CurrentCell = .Rows(Fila).Cells(0)
                        Prb01.Value = Fila
                        'exHoja.Cells(Fila + 2, NCol).Borders(8).LineStyle = 1 'BOTTOM
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Cells.Select()
                    exHoja.Range("A1:Z1").Font.Bold = True

                    If Exportar = 0 Then
                        exapp.Application.Visible = True
                        MsgBox("Los datos se enviaron a Excel correctamente", MsgBoxStyle.Information)
                    Else
                        exapp.Application.Visible = False
                        exLibro.SaveAs(Ruta_Archivo)
                        exLibro.Close() : exapp.Quit()
                        MsgBox("Archivo se exporto correctamente...", vbExclamation, Compañia)
                    End If
                    .ClearSelection()
                    .CurrentCell = .Rows(0).Cells(0)
                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    Prb01.Visible = False : Pan.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                    Prb01.Visible = False
                End Try

                Return True
            End With
        End If
    End Function
    Public Function fEncripta_Key(ByVal cKey As String, ByVal lKey As Boolean) As String
        Dim nLen As Integer
        Dim R As Integer
        Dim cOld, cNew, cPas As String
        nLen = Len(cKey)
        For R = 1 To Len(cKey)
            cNew = Chr(Asc(Mid(cKey, R, 1)) + IIf(lKey, nLen, nLen * -1))
            cPas = cPas + cNew
        Next R
        fEncripta_Key = cPas
    End Function
    'Metodo que muestra los datos del cliente
    Public Sub Mostrar_Cliente_Abrev(ByVal Codigo As String, ByVal TxtCaja As TextBox)
        With c_Neg_MnCliente.get_Cliente_Datos(" and c_codi_Clie='" & Codigo & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtCaja.Text = .Rows(0)("c_abrev_clie").ToString
            End If
        End With
    End Sub
    'Metodo que BUSCA por la abreviatura del cliente 
    Public Sub Mostrar_Cliente_Busca_Abrev(ByVal Codigo As String, ByVal CboClie As ComboBox, ByVal TxtCod_clie As TextBox)
        With c_Neg_MnCliente.get_Cliente_Datos(" and c_anula_reg=0 and c_abrev_clie='" & Codigo & "'", "DAT")
            CboClie.Text = "" : TxtCod_clie.Clear()
            If .Rows.Count > 0 Then
                CboClie.Text = .Rows(0)("c_desc_clie").ToString
                TxtCod_clie.Text = .Rows(0)("c_codi_clie").ToString
            End If
        End With
    End Sub
    'Metodo que nos permite validar los permisos por usuarios...
    Public Sub Validar_Permiso(ByVal Name_Form As String, ByVal BtnNuevo As Button, ByVal BtnEditar As Button, ByVal BtnEliminar As Button)
        With FrmMenu.Dgv01
            For i = 0 To .RowCount - 1
                If UCase(.Rows(i).Cells("c_nom_formu").Value.ToString) = UCase(Name_Form) Then
                    If Val(.Rows(i).Cells("c_add_obj").Value) = 0 Then BtnNuevo.Enabled = False
                    If Val(.Rows(i).Cells("c_edit_obj").Value) = 0 Then BtnEditar.Enabled = False
                    If Val(.Rows(i).Cells("c_del_obj").Value) = 0 Then BtnEliminar.Enabled = False
                    i = .RowCount
                End If
            Next
        End With
    End Sub
    ' Cargamos datos de la base de datos
    Public Sub Cargar_Datos_BD()
        Dim fic As String = My.Application.Info.DirectoryPath & "\config.ini"
        Dim texto As String = ""
        Dim objReader As New StreamReader(fic)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        'Leemos Archivos
        Dim x As Integer = 0 : Dim Servidor, DbProcesos, Usuario, Password, Timeout, Provider As String

        For Each sLine In arrText
            If x = 7 Then Servidor = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            If x = 8 Then DbProcesos = Trim(Mid(arrText.Item(x).ToString, 12, 30))
            If x = 9 Then Usuario = Trim(Mid(arrText.Item(x).ToString, 9, 30))
            If x = 10 Then Password = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            If x = 11 Then Timeout = Trim(Mid(arrText.Item(x).ToString, 9, 30))
            If x = 12 Then Provider = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            x = x + 1
        Next
        FrmMenu.Text = "Sistema Administrativo de Ventas 3.0 - [\\" & Servidor & "\" & DbProcesos & "]"
    End Sub
    ' Metodo que nos permite cambiar de color a los registros anulados '
    Public Sub Grid_Registros_anulados(ByVal Dgv01 As DataGridView)
        With Dgv01
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub
    ' metodo para validar las cuentas '
    Public Function Validar_Cuentas(ByVal dgv01 As DataGridView) As Boolean
        With c_Neg_Asientos_Det.get_AsientosDet_Datos(" And Len(Isnull(Dcuenta,''))=0 order by N_Factura")
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    For u = 0 To dgv01.RowCount - 1
                        If dgv01.Rows(u).Cells("N_Factura").Value = .Rows(0)("N_Factura").ToString Then
                            dgv01.Rows(u).Selected = True : dgv01.CurrentCell = dgv01(0, u)
                            'MsgBox("Falta ingresar una cuenta Valida para el Voucher: " & Strings.Left(dgv01.Rows(u).Cells("N_Factura").Value, 3) & "-" & Strings.Right(dgv01.Rows(u).Cells("N_Factura").Value, 7), vbCritical, Compañia)
                            u = dgv01.RowCount + 1 : i = .Rows.Count : Validar_Cuentas = False
                        End If
                    Next
                Next
                Validar_Cuentas = True
            Else
                Validar_Cuentas = True
            End If
        End With
    End Function
    ' metodo para validar que cuadre el Debe con el Haber
    Public Function Validar_Montos(ByVal dgv01 As DataGridView) As Boolean
        Dim N_Factura As String = "" : Dim Dcodmon As String = "" : Dim Dif As Decimal = 0 : Dim DifTot As Decimal = 0
        With dgv01
            For i = 0 To .RowCount - 1
                N_Factura = .Rows(i).Cells("N_Factura").Value
                Dcodmon = .Rows(i).Cells("Ccodmon").Value
                With c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, 0, "DET")
                    If .Rows.Count > 0 Then
                        Dim Tot_01, Tot_Us_01, Tot_Mn_01, Tot_02, Tot_Us_02, Tot_Mn_02 As Decimal
                        Tot_01 = Val(.Rows(0)("Dimport").ToString)
                        Tot_Us_01 = Val(.Rows(0)("Dusimpor").ToString)
                        Tot_Mn_01 = Val(.Rows(0)("Dmnimpor").ToString)
                        Tot_02 = Val(.Rows(1)("Dimport").ToString)
                        Tot_Us_02 = Val(.Rows(1)("Dusimpor").ToString)
                        Tot_Mn_02 = Val(.Rows(1)("Dmnimpor").ToString)
                        If (Tot_01 - Tot_02) = 0 And (Tot_Mn_01 - Tot_Mn_02) = 0 And (Tot_Us_01 - Tot_Us_02) = 0 Then
                            Validar_Montos = True
                        Else
                            If Dcodmon = "US" Then
                                Dif = Tot_Mn_01 - Tot_Mn_02
                                If Dif < 1 Then
                                    c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(Dif), "AMN")
                                End If
                            Else
                                Dif = Tot_Us_01 - Tot_Us_02
                                If Dif < 1 Then
                                    c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(Dif), "AUS")
                                End If
                            End If
                            ' Importe '
                            DifTot = Tot_01 - Tot_02
                            If DifTot < 1 Then
                                c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(DifTot), "DIF")
                            End If
                            Validar_Montos = True
                        End If
                    Else
                        'MsgBox("Montos del Detalle no conciden...", vbCritical, Compañia)
                        Validar_Montos = True : i = dgv01.RowCount
                    End If
                End With
            Next
        End With
    End Function
    ' Metodo para abrir pdf
    Public Sub Abrir_Pdf(ByVal nombre_pdf As String)
        '  InputBox("", "", FrmMenu.TxtRuta_Pdf.Text & nombre_pdf)
        Dim loPSI As New ProcessStartInfo
        Dim loProceso As New Process
        loPSI.FileName = FrmMenu.TxtRuta_Pdf.Text & nombre_pdf

        Try
            loProceso = Process.Start(loPSI)
        Catch Exp As Exception
            MessageBox.Show(Exp.Message, "Archivo no puede ser abierto...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Function Abrir_PDf_2(ByVal serieDocumento As String, ByVal c_codi_doc_sunat As String, ByVal FechaEmi As Date) As Boolean
        Dim nomFile As String = "" : Dim nomFileLocal As String = ""
        Dim FechaDoc As String = Year(FechaEmi) & Strings.Right(Month(FechaEmi) + 100, 2) & Strings.Right(Strings.Left(FechaEmi, 2) + 100, 2)
        nomFile = FrmMenu.TxtRuta_Pdf.Text & "6-" & FrmMenu.TxtRuc.Text & "\" & c_codi_doc_sunat & "-" & serieDocumento & "\" & FrmMenu.TxtRuc.Text & "-" & c_codi_doc_sunat & "-" & serieDocumento & ".pdf"
        nomFileLocal = FrmMenu.TxtRuta_Pdf.Text & "6-" & FrmMenu.TxtRuc.Text & "\" & c_codi_doc_sunat & "-" & serieDocumento & "\PDFLOCAL-" & FrmMenu.TxtRuc.Text & "-" & c_codi_doc_sunat & "-" & serieDocumento & ".pdf"
        ' InputBox("", "", nomFile)
        'InputBox("", "", nomFileLocal)
        If File.Exists(nomFile) = True Then
            Abrir_PDf_2 = True
            Dim loPSI As New ProcessStartInfo
            Dim loProceso As New Process
            loPSI.FileName = nomFile
            Try
                loProceso = Process.Start(loPSI)
            Catch Exp As Exception
                MessageBox.Show(Exp.Message, "Archivo no puede ser abierto...", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            If File.Exists(nomFileLocal) = True Then
                Abrir_PDf_2 = True
                Dim loPSI As New ProcessStartInfo
                Dim loProceso As New Process
                loPSI.FileName = nomFileLocal
                Try
                    loProceso = Process.Start(loPSI)
                Catch Exp As Exception
                    MessageBox.Show(Exp.Message, "Archivo no puede ser abierto...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Else
                Abrir_PDf_2 = False
            End If
        End If
    End Function

    ' Modulo para validar codigo SUNAT '
    Public Function ValidarCodigoSUNAT(ByVal dgv As DataGridView) As Boolean
        With dgv
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    With c_Neg_MnArticulo.get_Articulo_Datos(" and A.c_codi_articulo='" & dgv.Rows(i).Cells("Codigo").Value & "' ", "DAT")
                        If .Rows.Count > 0 Then
                            If Len(.Rows(0)("c_codi_artsunat").ToString) = 8 Then
                                ValidarCodigoSUNAT = True
                            Else
                                ValidarCodigoSUNAT = False
                                MsgBox("1. Codigo de articulo no tiene el codigo SUNAT, revisar el maestro de Articulos e ingresar su codigo...", vbCritical, Compañia)
                            End If
                        Else
                            ValidarCodigoSUNAT = False
                            MsgBox("2. Codigo de articulo no existe, Comunicarse con Sistemas...", vbCritical, Compañia)
                        End If
                    End With
                Next
            Else
                ValidarCodigoSUNAT = False
                MsgBox("3. No existen Registros por Validar, Revisar documentos...", vbCritical, Compañia)
            End If
        End With
    End Function
    ' Validar Envio de Facturas '
    Public Function ValidarEnvio(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_codi_doc As String, ByVal Reenvio As Integer) As Boolean
        With c_Neg_FactElectCab.get_FactElectronico_Datos(c_nro_serie, c_nro_factura, c_codi_doc, "CAB")
            If .Rows.Count > 0 Then
                If .Rows(0)("bl_estadoRegistro").ToString = "E" Then
                    If Reenvio = 0 Then
                        MsgBox("1. Hubo un error, se debera volver a generar el Archivo presionando la tecla F8, Si el problema persiste comunicarse con Sistemas...", vbCritical, Compañia)
                    Else
                        MsgBox("2. Comunicarse con el Area de Sistemas, hay un problema de comunicacion con la SUNAT...", vbCritical, Compañia)
                    End If
                    ValidarEnvio = False
                Else
                    ValidarEnvio = True
                End If
            Else
                If Reenvio = 0 Then
                    MsgBox("3. Hubo un error en SUNAT, debera volver a generar el Archivo presionando la tecla F8, Si el problema persiste comunicarse con Sistemas...", vbCritical, Compañia)
                Else
                    MsgBox("4. Comunicarse con el Area de Sistemas, hay un problema de comunicacion con la SUNAT...", vbCritical, Compañia)
                End If
                ValidarEnvio = False
            End If
        End With
    End Function
    ' Metodo para activar el timer'
    Public Sub Activar_Timer(ByVal Pan As Panel, ByVal Timer1 As Timer)
        Pan.Visible = True : Timer1.Start()
    End Sub
    ' Metodo para validar fecha de cierre '
    Public Function ValidarCierre(ByVal Fecha As Date) As Boolean
        ' MsgBox("Fecha Actual " & Fecha & " Fecha de Cierre: " & FrmMenu.TxtFecha_Cierre.Text)
        Dim FechaCierre As Date
        With c_Neg_MnEmpresa.get_Empresa_Datos(" ", "CIE")
            If .Rows.Count > 0 Then
                FechaCierre = .Rows(0)("c_fecha_cierre").ToString
            End If
        End With
        If Fecha > FechaCierre Then
            ValidarCierre = True
        Else
            ValidarCierre = False
            MsgBox("No puede realizar ningún tipo de operacion con esta Fecha, esta dentro de la fecha de Cierre: " & FechaCierre, vbCritical, Compañia)
        End If
    End Function
    Public Function ValidarFactu(ByVal Modulo As String, ByVal Cadena As String) As Boolean
        '1. Guia de Remision
        If UCase(Modulo) = "GUIA" Then
            ' InputBox("", "", Cadena) '
            With c_Neg_AlmSalTA.get_AlmSalTa_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Val(.Rows(0)("c_fact_guia").ToString) = 0 Then
                            ValidarFactu = True
                        Else
                            MsgBox("1.1 Registro se encuentra Facturado no podra realizar ninguna Modificación...", vbCritical, "Validacion...")
                            ValidarFactu = False
                        End If
                    Else
                        MsgBox("2.1 Registro se encuentra Anulado...", vbCritical, "Validacion...")
                        ValidarFactu = False
                    End If
                Else
                    MsgBox("3.1 No existen Registros que mostrar...", vbCritical, "Validacion...")
                    ValidarFactu = False
                End If
            End With
        End If
        '2. Facturas
        If UCase(Modulo) = "FACTURA" Then
            With c_Neg_FactCab.get_FactCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Strings.Left(.Rows(0)("c_tpo_venta").ToString, 5) = "VENTA" Then
                            If Val(.Rows(0)("c_cancel_fact").ToString) = 0 Then
                                ValidarFactu = True
                            Else
                                MsgBox("1.1 Registro se encuentra Cerrado no podra realizar ninguna Modificación...", vbCritical, "Validacion...")
                                ValidarFactu = False
                            End If
                        Else
                            ValidarFactu = True
                        End If
                    Else
                        MsgBox("2.1 Registro se encuentra Anulado...", vbCritical, "Validacion...")
                        ValidarFactu = False
                    End If
                Else
                    MsgBox("3.1 No existen Registros que mostrar...", vbCritical, "Validacion...")
                    ValidarFactu = False
                End If
            End With
        End If
        '3. Boletas  
        If UCase(Modulo) = "BOLETA" Then
            With c_Neg_BolCab.get_BolCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Strings.Left(.Rows(0)("c_tpo_venta").ToString, 5) = "VENTA" Then
                            If Val(.Rows(0)("c_cancel_bol").ToString) = 0 Then
                                ValidarFactu = True
                            Else
                                MsgBox("1.1 Registro se encuentra Cerrado no podra realizar ninguna Modificación...", vbCritical, "Validacion...")
                                ValidarFactu = False
                            End If
                        Else
                            ValidarFactu = True
                        End If
                    Else
                        MsgBox("2.1 Registro se encuentra Anulado...", vbCritical, "Validacion...")
                        ValidarFactu = False
                    End If
                Else
                    MsgBox("3.1 No existen Registros que mostrar...", vbCritical, "Validacion...")
                    ValidarFactu = False
                End If
            End With
        End If
        '4. Nro.Debito
        If UCase(Modulo) = "DEBITO" Then
            With c_Neg_NotaD.get_NotaD_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Val(.Rows(0)("c_cancel_nd").ToString) = 0 Then
                            ValidarFactu = True
                        Else
                            MsgBox("1.1 Registro se encuentra Cerrado no podra realizar ninguna Modificación...", vbCritical, "Validacion...")
                            ValidarFactu = False
                        End If
                    Else
                        MsgBox("2.1 Registro se encuentra Anulado...", vbCritical, "Validacion...")
                        ValidarFactu = False
                    End If
                Else
                    MsgBox("3.1 No existen Registros que mostrar...", vbCritical, "Validacion...")
                    ValidarFactu = False
                End If
            End With
        End If
        '5. Letra
        If UCase(Modulo) = "LETRA" Then
            With c_Neg_LetCab.get_LetCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Val(.Rows(0)("c_cancel_letra").ToString) = 0 Then
                            ValidarFactu = True
                        Else
                            MsgBox("1.1 Registro se encuentra Cerrado no podra realizar ninguna Modificación...", vbCritical, "Validacion...")
                            ValidarFactu = False
                        End If
                    Else
                        MsgBox("2.1 Registro se encuentra Anulado...", vbCritical, "Validacion...")
                        ValidarFactu = False
                    End If
                Else
                    MsgBox("3.1 No existen Registros que mostrar...", vbCritical, "Validacion...")
                    ValidarFactu = False
                End If
            End With
        End If
    End Function
    ' method for save cuotas
    Public Sub RegistrarCoutas(ByVal c_codi_doc As String, ByVal c_nro_serie As String, ByVal c_nro_doc As String,
                                 ByVal c_monto_doc As Decimal, ByVal c_codi_mon As String)
        FrmFactCuota.Close() : FrmFactCuota.MdiParent = FrmMenu : FrmFactCuota.Show()
        With FrmFactCuota
            .TxtCuotas.Text = ""
            .CboTpoDoc.SelectedValue = c_codi_doc
            .TxtSerie.Text = c_nro_serie
            .TxtDoc.Text = c_nro_doc
            .TxtTotDoc.Text = c_monto_doc
            .CboMon.SelectedValue = c_codi_mon
            .TxtCuotas.Focus()
        End With
    End Sub
    ' Validar si se aplica la cuota '
    Public Function ValidarCouta(ByVal c_codi_doc As String, ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal alerta As Integer) As Boolean
        If c_codi_doc = "01" Then
            With c_Neg_FactCab.get_FactCab_Datos("  and F.c_nro_serie='" & c_nro_serie & "' and F.c_nro_factura='" & c_nro_doc & "'", "DAT", "")
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If .Rows(0)("c_codi_pago").ToString = "CD" Then
                            ValidarCouta = False
                            If alerta = 1 Then MsgBox("1. Este documento es al Contado y no se puede aplicarse cuotas...", vbCritical, Compañia)
                        Else
                            If Val(.Rows(0)("c_cancel_cuota").ToString) = 0 Then
                                If Strings.Left(.Rows(0)("c_tpo_venta").ToString, 5) = "VENTA" Then
                                    ValidarCouta = True
                                Else
                                    ValidarCouta = False
                                    If alerta = 1 Then MsgBox("2. Este tipo de venta no puede ser aplicadas en cuotas...", vbCritical, Compañia)
                                End If
                            Else
                                ValidarCouta = False
                                If alerta = 1 Then MsgBox("3. Las cuotas ya fueron aplicadas...", vbCritical, Compañia)
                            End If
                        End If
                    Else
                        ValidarCouta = False
                        If alerta = 1 Then MsgBox("4. Documento se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End With
        End If
    End Function
    ' validar un ingreso por transferencia '
    Public Function ValidarGuiaTransferencia(ByVal nroSerie As String, ByVal nroGuia As String) As Boolean
        With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_anula_reg=0 and I.c_codi_mt='12' and I.c_serie_guia='" & nroSerie & "' and I.c_nro_guia='" & nroGuia & "'", "", "DAT")
            If .Rows.Count > 0 Then
                ValidarGuiaTransferencia = False
                MsgBox("1. Guia de transferencia no puede ser anulada o editada, Guia ya fue ingresada al almacen, debera anularse el ingreso para poder usar esta guia", vbCritical, Compañia)
            Else
                ValidarGuiaTransferencia = True
            End If
        End With
    End Function
    Public Function ValidarDocAdelantos(ByVal c_codi_clie As String, ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String,
                                       ByVal TxtTotalDoc As TextBox) As Boolean
        If c_codi_doc = "01" Then
            With c_Neg_FactCab.get_FactCab_Datos(" and F.c_codi_clie ='" & c_codi_clie & "' and F.c_nro_serie='" & c_nro_serie & "' and F.c_nro_factura='" & c_nro_doc & "' ", "DAT", "")
                If .Rows.Count > 0 Then
                    TxtTotalDoc.Text = Format(Val(.Rows(0)("c_total_fact").ToString), Forma_1_2)
                    Return True
                Else
                    MsgBox("1. Documento no existe, revisar...", vbCritical, Compañia)
                    Return False
                End If
            End With
        End If
        If c_codi_doc = "02" Then
            With c_Neg_BolCab.get_BolCab_Datos(" and B.c_codi_clie ='" & c_codi_clie & "' and B.c_nro_serie='" & c_nro_serie & "' and B.c_nro_boleta='" & c_nro_doc & "' ", "DAT", "")
                If .Rows.Count > 0 Then
                    TxtTotalDoc.Text = Format(Val(.Rows(0)("c_total_bol").ToString), Forma_1_2)
                    Return True
                Else
                    MsgBox("1. Documento no existe, revisar...", vbCritical, Compañia)
                    Return False
                End If
            End With
        End If
    End Function

    Public Function AbrirArchivoGuiaPDF(numeroGuia As String) As Boolean
        Dim url As String = ""

        With c_Neg_AlmSalTA.get_GuiaElectronica_Datos(" AND R.serieNumeroGuia='" & numeroGuia & "' and R.NumeroDocumentoRemision='" & FrmMenu.TxtRuc.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                If Len(.Rows(0)("bl_url_pdf").ToString) > 0 Then
                    url = .Rows(0)("bl_url_pdf").ToString


                    'Process.Start()


                    Dim startexternal As New Process()

                    'startexternal.StartInfo.FileName = "www.google.co.uk"
                    startexternal.StartInfo.FileName = url
                    startexternal.StartInfo.UseShellExecute = True

                    startexternal.Start()
                    AbrirArchivoGuiaPDF = True
                Else
                    AbrirArchivoGuiaPDF = False
                    MsgBox("Guia electronica aun no ha sido procesada, revisar con sistemas...", vbCritical, Compañia)
                End If
            Else
                MsgBox("Guia electronica no existe...", vbCritical, Compañia)
                AbrirArchivoGuiaPDF = False
            End If
        End With

    End Function
    Public Function ValidarGuiaElectronica(c_nro_serie As String)
        With c_Neg_MnSeriesGuias.get_Series_Datos(" and c_anula_reg=0 AND c_nro_serie='" & c_nro_serie & "' ", "DAT", "")
            If .Rows.Count > 0 Then
                If Val(.Rows(0)("c_opc_electronico").ToString) = 1 Then
                    ValidarGuiaElectronica = True
                Else
                    ValidarGuiaElectronica = False
                End If
            Else
                ValidarGuiaElectronica = False
            End If
        End With
    End Function

    Public Function ValidarGuiaInterna(c_nro_serie As String) As Boolean
        Dim dataTable As DataTable = c_Neg_MnSeriesGuias.get_Series_Datos(" and c_anula_reg=0 AND c_nro_serie='" & c_nro_serie & "' ", "DAT", "")
        With dataTable
            If .Rows.Count > 0 Then
                If Val(.Rows(0)("c_guia_interna").ToString) = 1 Then
                    ValidarGuiaInterna = True
                Else
                    ValidarGuiaInterna = False
                End If
            Else
                ValidarGuiaInterna = False
            End If
        End With
    End Function

    Public Function obtenerPorcentajeDetraccion(codigoDetraccion As String, txtCodigDetraccion As TextBox) As Boolean
        Dim _negocio As New Neg_MnTblDetraccion
        Dim dataTable As DataTable = _negocio.get_MntblDetraccion_Datos(" and c_anula_reg=0 AND c_codi_detracc='" & codigoDetraccion & "' ", "DAT")
        With dataTable
            If .Rows.Count > 0 Then
                txtCodigDetraccion.Text = Format(Val(.Rows(0)("c_porc_detracc").ToString), Forma_1_2)
                obtenerPorcentajeDetraccion = True
            Else
                txtCodigDetraccion.Text = "0.00"
                obtenerPorcentajeDetraccion = False
                MsgBox("Codigo de detracción no existe")
            End If
        End With
    End Function

    Public Function validarSiEsDetraccionValida(codigoDetraccion As String) As Boolean
        Dim _negocio As New Neg_MnTblDetraccion
        Dim dataTable As DataTable = _negocio.get_MntblDetraccion_Datos(" and c_anula_reg=0 AND c_codi_detracc='" & codigoDetraccion & "' ", "DAT")
        With dataTable
            If .Rows.Count > 0 Then
                validarSiEsDetraccionValida = True
            Else
                validarSiEsDetraccionValida = False
                MsgBox("Codigo de detracción es invalido no existe, revisar", vbCritical, Compañia)
            End If
        End With
    End Function
End Module
