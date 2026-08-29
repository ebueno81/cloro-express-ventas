Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class FrmFechas
    Public Título As String
    '
    'Private prtSettings As PrinterSettings
    Dim prtSettings As New Printing.PrinterSettings
    Private prtDoc As PrintDocument
    Private prtFont As System.Drawing.Font
    '
    Private lineaActual As Integer
    Dim tot_soles, tot_dolares, acuenta_sol, acuenta_dol, saldo_sol, saldo_dol As Double
    'Trabaja con comisiones de ventas...
    Dim tot_sol, tot_dol, comi_sol_vta, comi_dol_vta, comi_sol_ing, comi_dol_ing As Double
    'seleccionamos directorio
    Private Sub btnopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnopen.Click
        'txtruta.Clear()
        folder01.ShowDialog()
        'exportamos a excel
        If Len(folder01.SelectedPath) = 3 Then
            If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then txtruta.Text = folder01.SelectedPath & "Documentos_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then txtruta.Text = folder01.SelectedPath & "Cobros_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then txtruta.Text = folder01.SelectedPath & "Visitas_Diarias.xls"
            If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then txtruta.Text = folder01.SelectedPath & "Presupuestos_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COLABORADORES" Then txtruta.Text = folder01.SelectedPath & "Colaboradores.xls"
            If UCase(lbltipo.Text) = "EXPORTAR PRODUCTOS" Then txtruta.Text = folder01.SelectedPath & "Productos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COMISIONES" Then txtruta.Text = folder01.SelectedPath & "Comisiones.xls"
            If UCase(lbltipo.Text) = "EXPORTAR O.TRABAJO" Then txtruta.Text = folder01.SelectedPath & "O.Trabajo.xls"
            If UCase(lbltipo.Text) = "EXPORTAR INGRESOS" Then txtruta.Text = folder01.SelectedPath & "Reporte_Ingresos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR SALIDAS" Then txtruta.Text = folder01.SelectedPath & "Reporte_Salidas.xls"
            If UCase(lbltipo.Text) = "EXPORTAR DEVOLUCIONES" Then txtruta.Text = folder01.SelectedPath & "Reporte_Devoluciones.xls"
            If UCase(lbltipo.Text) = "EXPORTAR GUIAS" Then txtruta.Text = folder01.SelectedPath & "Guias_Emitidas.xls"
        Else
            If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then txtruta.Text = folder01.SelectedPath & "\Documentos_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then txtruta.Text = folder01.SelectedPath & "\Cobros_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then txtruta.Text = folder01.SelectedPath & "\Visitas_Diarias.xls"
            If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then txtruta.Text = folder01.SelectedPath & "\Presupuestos_Emitidos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COLABORADORES" Then txtruta.Text = folder01.SelectedPath & "\Colaboradores.xls"
            If UCase(lbltipo.Text) = "EXPORTAR COMISIONES" Then txtruta.Text = folder01.SelectedPath & "\Comisiones.xls"
            If UCase(lbltipo.Text) = "EXPORTAR O.TRABAJO" Then txtruta.Text = folder01.SelectedPath & "\O.Trabajo.xls"
            If UCase(lbltipo.Text) = "EXPORTAR INGRESOS" Then txtruta.Text = folder01.SelectedPath & "\Reporte_Ingresos.xls"
            If UCase(lbltipo.Text) = "EXPORTAR SALIDAS" Then txtruta.Text = folder01.SelectedPath & "\Reporte_Salidas.xls"
            If UCase(lbltipo.Text) = "EXPORTAR DEVOLUCIONES" Then txtruta.Text = folder01.SelectedPath & "\Reporte_Devoluciones.xls"
            If UCase(lbltipo.Text) = "EXPORTAR GUIAS" Then txtruta.Text = folder01.SelectedPath & "\Guias_Emitidas.xls"
        End If
    End Sub
    'grabamos registros
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        'VALIDAMOS SI ES EXPORTAR FACTURAS...
        If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then
            Call Exportar_Facturas()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then
            Call Exportar_Cobros()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then
            Call Exportar_Visitas()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then
            Call Exportar_Presupuestos()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COLABORADORES" Then
            Call Exportar_Colaboradores()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR PRODUCTOS" Then
            Call Exportar_Productos()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COMISIONES" Then
            Call Exportar_Comisiones()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR O.TRABAJO" Then
            Call Exportar_Trabajo()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR INGRESOS" Then
            Call Exportar_Ingresos()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR SALIDAS" Then
            Call Exportar_Salidas()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR DEVOLUCIONES" Then
            Call Exportar_Devol()
        End If
        If UCase(lbltipo.Text) = "EXPORTAR GUIAS" Then
            Call Exportar_Guias()
        End If

    End Sub
    'funcion que nos permite exportar los productos
    Function Exportar_Productos() As Boolean
        'variable que trabaja con el encabezado 
        Dim y As Integer = 0
        Dim cuenta As Integer
        'Creamos las variables
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If chkopcion.Checked = True Then
            If cbocriterio2.SelectedIndex = 0 Then
                If cbocriterio.SelectedIndex = 0 Then
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' order by concepto", conex)
                Else
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO'  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                End If
            Else
                If cbocriterio.SelectedIndex = 0 Then
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' and control=1 order by concepto", conex)
                Else
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' and control=1 and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                End If
            End If
        Else
            If cbocriterio2.SelectedIndex = 0 Then
                If cbocriterio.SelectedIndex = 0 Then
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca WHERE  estado='ACTIVO' order by concepto", conex)
                Else
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' and estado='ACTIVO' order by concepto", conex)
                End If
            Else
                If cbocriterio.SelectedIndex = 0 Then
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca WHERE  estado='ACTIVO' and control=1 order by concepto", conex)
                Else
                    data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                              "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where  control=1  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' and estado='ACTIVO' order by concepto", conex)
                End If
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "productos")

        'Validamos el si existen registros activos...
        With midataset.Tables("productos")
            lbltot.Text = "Total de Productos = " & .Rows.Count
            If .Rows.Count > 0 Then
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        '    exHoja.Cells(Fila + 1, Col + 1).Font.Bold = True
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    'exHoja.Cells.Select()
                    exHoja.Range("A1:M" & NRow + 1).Select()
                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:M1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False
                    'exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    '"\\servidor\programa\trabajo\" & Year(fecha1.Text) & "\Orden de Trabajo..." & Strings.Right(Str(txtid_trabajo.Text + 1000000), 6) & ".xls")
                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)
                    'exHoja.Cells.Font.Bold = True
                    'Aplicación visible
                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    'exHoja.Cells.Font.Bold = True
                    'Aplicación visible


                    'Aplicación visible



                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            Else
                MsgBox("No hay registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Function
    'funcion que nos permite exportar DATOS
    Function Exportar_Facturas() As Boolean
        'variable que trabaja con el encabezado 
        Dim y As Integer = 0
        Dim cuenta As Integer
        'Creamos las variables
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  order by Facturas_Ventas.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "DOCUMENTOS CANCELADOS" Then
            data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "' and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo<=0 order by Facturas_Ventas.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "DOCUMENTOS PENDIENTES" Then
            data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo>0 order by Facturas_Ventas.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "DOCUMENTOS ANULADOS" Then
            data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu>0 order by Facturas_Ventas.Fecha_2 ", conex)
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "facturas")
        'Validamos el si existen registros activos...
        With midataset.Tables("facturas")
            lbltot.Text = "Total de Facturas = " & .Rows.Count
            If .Rows.Count > 0 Then
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion
                    exHoja.Range("A1:S1").Font.Bold = True
                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        '    exHoja.Cells(Fila + 1, Col + 1).Font.Bold = True
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    'exHoja.Cells.Select()
                    exHoja.Range("A1:S" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False
                    'exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    '"\\servidor\programa\trabajo\" & Year(fecha1.Text) & "\Orden de Trabajo..." & Strings.Right(Str(txtid_trabajo.Text + 1000000), 6) & ".xls")
                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)
                    'exHoja.Cells.Font.Bold = True
                    'Aplicación visible
                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    'exHoja.Cells.Font.Bold = True
                    'Aplicación visible


                    'Aplicación visible



                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            Else
                MsgBox("No hay registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Function
    'funcion que nos permite exportar cobros realizados
    'funcion que nos permite exportar DATOS
    Function Exportar_Cobros() As Boolean
        'variable que trabaja con el encabezado 
        Dim y As Integer = 0
        Dim cuenta As Integer
        'Creamos las variables
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "(TODOS)" Then
            data = New SqlDataAdapter("SELECT D_cobros.N_Cobro,D_cobros.Fecha_2 as Fecha_Emision,D_cobros.Fecha_3 as Fecha_Deposito,D_cobros.F_Pago,Facturas.ID_Trabajo,Facturas.N_Presu, right(left(Facturas.N_Serie,4),3)  +'-'+ right(Facturas.N_Serie,6) AS Factura, Clientes.r_social as Cliente,D_cobros.T_Moneda as Moneda, " & _
                " D_cobros.Detraccion,D_cobros.Retencion,D_cobros.A_Cuenta FROM Clientes INNER JOIN Facturas ON Clientes.Id_clie = Facturas.Id_Clie INNER JOIN d_cobros ON d_cobros.N_Factura=Facturas.N_Factura " & _
                " where d_cobros.fecha_2 >='" & fecha1.Text & "' and d_cobros.fecha_2 <='" & fecha2.Text & "'  order by d_cobros.Fecha_2 ", conex)
        Else
            data = New SqlDataAdapter("SELECT D_cobros.N_Cobro,D_cobros.Fecha_2 as Fecha_Emision,D_cobros.Fecha_3 as Fecha_Deposito,D_cobros.F_Pago,Facturas.ID_Trabajo,Facturas.N_Presu, right(left(Facturas.N_Serie,4),3)  +'-'+ right(Facturas.N_Serie,6) AS Factura, Clientes.r_social as Cliente,D_cobros.T_Moneda as Moneda, " & _
                " D_cobros.Detraccion,D_cobros.Retencion,D_cobros.A_Cuenta FROM Clientes INNER JOIN Facturas ON Clientes.Id_clie = Facturas.Id_Clie INNER JOIN d_cobros ON d_cobros.N_Factura=Facturas.N_Factura " & _
                " where d_cobros.fecha_2 >='" & fecha1.Text & "' and d_cobros.fecha_2 <='" & fecha2.Text & "'  and d_cobros.f_Pago='" & Strings.Right(cbocriterio.Text, 4) & "' order by d_cobros.Fecha_2 ", conex)
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "d_cobros")
        'Validamos el si existen registros activos...
        With midataset.Tables("d_cobros")
            lbltot.Text = "Total de Cobros = " & .Rows.Count
            If .Rows.Count > 0 Then
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion
                    exHoja.Range("A1:L1").Font.Bold = True
                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:L" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            Else
                MsgBox("No hay registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Function
    'exportar archivo en excel
    Function Exportar_Visitas()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio2.Text) = "(TODOS)" Then
            If UCase(cbocriterio.Text) = "TODAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "REALIZADAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  and visitas.factu<>2 order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  and visitas.factu=2 order by visitas.Fecha_2 ", conex)
            End If
        Else 'Por ingenieros...
            If UCase(cbocriterio.Text) = "TODAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "' And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "' order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "REALIZADAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "' and visitas.factu<>2 order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "' and visitas.factu=2 order by visitas.Fecha_2 ", conex)
            End If
        End If
        
        'enviamos informacion al dataset
        data.Fill(midataset, "visitas")
        'Validamos el si existen registros activos...
        With midataset.Tables("visitas")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Visitas = " & .Rows.Count
            If .Rows.Count > 0 Then
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:L" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:L1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Presupuestos()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                      "Referencia,Ubicacion,presupuestos.Seguimiento  from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                      "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' order by presupuestos.fecha_2", conex)
        End If
        If UCase(cbocriterio.Text) = "APROBADOS" Then
            data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                      "Referencia,Ubicacion,presupuestos.Seguimiento  from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                      "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu>0 order by presupuestos.fecha_2", conex)
        End If
        If UCase(cbocriterio.Text) = "PENDIENTES" Then
            data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                      "Referencia,Ubicacion,presupuestos.Seguimiento  from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                      "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu=0  order by presupuestos.fecha_2", conex)
        End If

        'enviamos informacion al dataset
        data.Fill(midataset, "presupuestos")
        Dim tot_sol, tot_dol As Double
        'Validamos el si existen registros activos...
        With midataset.Tables("presupuestos")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Presupuestos = " & .Rows.Count
            If .Rows.Count > 0 Then
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:K" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:K1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Colaboradores()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(CboCriterio3.Text) = "(TODAS)" Then
            If UCase(cbocriterio.Text) = "TODOS" Then
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where id_traba<>'00052' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where Traba.Estado='" & cbocriterio2.Text & "' and  id_traba<>'00052' order by nombres,apellidos", conex)
                End If
            Else
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where Traba.estado='" & cbocriterio2.Text & "' and tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' order by nombres,apellidos", conex)
                End If
            End If
        Else 'En caso sea por empresa
            If UCase(cbocriterio.Text) = "TODOS" Then
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where id_traba<>'00052' and E.Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where Traba.estado='" & cbocriterio2.Text & "' and  id_traba<>'00052' and E.Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                End If
            Else
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' and E.Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select Dni,Nombres,Apellidos,Tipo,Area,Cargo,Telefono,Celular,Direccion,Referencia,Distrito,Provincia,Departamento,E.Empresa,Planilla from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " inner join Empresa as E on E.Id_Empresa=Traba.Id_Empresa where Traba.estado='" & cbocriterio2.Text & "' and tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' and E.Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                End If
            End If
        End If
        data.Fill(midataset, "traba")
        With midataset.Tables("traba")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Colaboradores = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            'Validamos que sea Dni que ponerle comilla si Tuviera cero a la Izquierda
                            If Col = 0 Then
                                exHoja.Cells.Item(Fila + 1, Col + 1) = "'" & .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            Else
                                exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            End If
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:O" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:N1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Comisiones()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet

        'validamos si la busqueda es por usuario...
        If cbocriterio2.SelectedIndex = 0 Then
            If cbocriterio.SelectedIndex = 0 Then
                data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                          "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Inge from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                          "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.obs_comision like '%" & txtobs.Text & "%'  and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
            Else
                If UCase(cbocriterio.Text) = "PENDIENTES VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_1=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_1>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If
                'busqueda por ingeniero...
                If UCase(cbocriterio.Text) = "PENDIENTES INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and  comision_2=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_2>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision_2 like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If

            End If
        Else 'buscar por usuario...
            If cbocriterio.SelectedIndex = 0 Then
                data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                          "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Inge from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                          "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.obs_comision like '%" & txtobs.Text & "%'  and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
            Else
                If UCase(cbocriterio.Text) = "PENDIENTES VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' and comision_1=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "'  and comision_1>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If
                'busqueda por ingeniero...
                If UCase(cbocriterio.Text) = "PENDIENTES INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' and comision_2=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "'  and comision_2>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision_2 like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If

            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "comisiones")

        'Validamos el si existen registros activos...
        With midataset.Tables("comisiones")
            lbltot.Text = "Total de Comisiones = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                        Next
                        pro01.Value = Col
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:L" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:L1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Trabajo()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                "  Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_2 >='" & fecha1.Text & "' and trabajo.fecha_2 <='" & fecha2.Text & "' and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "REALIZADOS" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                "  Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_3 >='" & fecha1.Text & "' and trabajo.fecha_3 <='" & fecha2.Text & "' and trabajo.fecha_3 is not null   and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "PENDIENTES" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                "  Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_2 >='" & fecha1.Text & "' and trabajo.fecha_2 <='" & fecha2.Text & "' and trabajo.fecha_3 is null  and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If

        'enviamos informacion al dataset
        data.Fill(midataset, "trabajo")

        'Validamos el si existen registros activos...
        With midataset.Tables("trabajo")
            lbltot.Text = "Total de Comisiones = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    Dim filas As Integer
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            If Col = 6 Then
                                If UCase(.Rows(Fila - 1)(Col).ToString) = "SOLES" Then
                                    tot_sol = tot_sol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                Else
                                    tot_dol = tot_dol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                End If
                            End If
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            filas = Fila
                        Next
                        pro01.Value = Col
                    Next
                    exHoja.Cells.Item(filas + 2, 7) = "Total US$ " & tot_dol
                    exHoja.Cells.Item(filas + 3, 7) = "Total S/. " & tot_sol

                    ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:H" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:F1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Ingresos()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODAS" Then
            data = New SqlDataAdapter("select ingresos.Item,ingresos.N_Orden,ingresos.Fecha_2,prove.proveedor,usuarios.tipo as Usuario,ingresos.Moneda,ingresos.Monto,ingresos.Obs from ingresos inner join usuarios on usuarios.id_usua=ingresos.usua_1 " & _
                                      "inner join prove on prove.id_prove=ingresos.id_prove where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by ingresos.Fecha_2 ", conex)
        End If
        
        'enviamos informacion al dataset
        data.Fill(midataset, "trabajo")

        'Validamos el si existen registros activos...
        With midataset.Tables("trabajo")
            lbltot.Text = "Total de Ingresos = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    Dim filas As Integer
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            If Col = 5 Then 'validamos el tipo de moneda...
                                If UCase(.Rows(Fila - 1)(Col).ToString) = "SOLES" Then
                                    tot_sol = tot_sol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                Else
                                    tot_dol = tot_dol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                End If
                            End If
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            filas = Fila
                        Next
                        pro01.Value = Col
                    Next
                    exHoja.Cells.Item(filas + 2, 7) = "Total US$ " & tot_dol
                    exHoja.Cells.Item(filas + 3, 7) = "Total S/. " & tot_sol

                    ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:H" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:H1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Salidas()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            If UCase(cbocriterio2.Text) = "FECHA DE SALIDA" Then
                data = New SqlDataAdapter("select salidas.N_Salida,N_Orden,n_presu_2 as N_Presu,Fecha_2 as Fecha,clientes.r_social as Cliente,usuarios.tipo as Usuario,N_guia,Docu,N_Docu,Salidas.Tipo,Salidas.Obs from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            Else
                data = New SqlDataAdapter("select salidas.N_Salida,N_Orden,n_presu_2 as N_Presu,Fecha_2 as Fecha,clientes.r_social as Cliente,usuarios.tipo as Usuario,N_guia,Docu,N_Docu,Salidas.Tipo,Salidas.Obs from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_1>='" & fecha1.Text & "' and fecha_1<='" & fecha2.Text & "' order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            End If
        Else
            If UCase(cbocriterio2.Text) = "FECHA DE SALIDA" Then
                data = New SqlDataAdapter("select salidas.N_Salida,N_Orden,n_presu_2 as N_Presu,Fecha_2 as Fecha,clientes.r_social as Cliente,usuarios.tipo as Usuario,N_guia,Docu,N_Docu,Salidas.Tipo,Salidas.Obs from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and salidas.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            Else
                data = New SqlDataAdapter("select salidas.N_Salida,N_Orden,n_presu_2 as N_Presu,Fecha_2 as Fecha,clientes.r_social as Cliente,usuarios.tipo as Usuario,N_guia,Docu,N_Docu,Salidas.Tipo,Salidas.Obs from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_1>='" & fecha1.Text & "' and fecha_1<='" & fecha2.Text & "' and salidas.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "'  order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            End If
        End If

        'enviamos informacion al dataset
        data.Fill(midataset, "salidas")

        'Validamos el si existen registros activos...
        With midataset.Tables("salidas")
            lbltot.Text = "Total de Salidas = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    Dim filas As Integer
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            If Col = 5 Then 'validamos el tipo de moneda...
                                If UCase(.Rows(Fila - 1)(Col).ToString) = "SOLES" Then
                                    tot_sol = tot_sol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                Else
                                    tot_dol = tot_dol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                End If
                            End If
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            filas = Fila
                        Next
                        pro01.Value = Col
                    Next
                    ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:K" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:K1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    Function Exportar_Devol()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            If UCase(cbocriterio2.Text) = "FECHA DE DEVOLUCION" Then
                data = New SqlDataAdapter("select Devol.N_Devol,Devol.Fecha_2 as Fecha,salidas.N_Orden,salidas.n_presu_2 as N_Presu,salidas.Tipo, clientes.r_social as Cliente,usuarios.tipo as Usuario,Devol.Obs from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            Else
                data = New SqlDataAdapter("select Devol.N_Devol,Devol.Fecha_2 as Fecha,salidas.N_Orden,salidas.n_presu_2 as N_Presu,salidas.Tipo, clientes.r_social as Cliente,usuarios.tipo as Usuario,Devol.Obs from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            End If
        Else
            If UCase(cbocriterio2.Text) = "FECHA DE DEVOLUCION" Then
                data = New SqlDataAdapter("select Devol.N_Devol,Devol.Fecha_2 as Fecha,salidas.N_Orden,salidas.n_presu_2 as N_Presu,salidas.Tipo, clientes.r_social as Cliente,usuarios.tipo as Usuario,Devol.Obs from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' and devol.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            Else
                data = New SqlDataAdapter("select Devol.N_Devol,Devol.Fecha_2 as Fecha,salidas.N_Orden,salidas.n_presu_2 as N_Presu,salidas.Tipo, clientes.r_social as Cliente,usuarios.tipo as Usuario,Devol.Obs from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' and devol.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "devol")

        'Validamos el si existen registros activos...
        With midataset.Tables("devol")
            lbltot.Text = "Total de Devoluciones = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    Dim filas As Integer
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            If Col = 5 Then 'validamos el tipo de moneda...
                                If UCase(.Rows(Fila - 1)(Col).ToString) = "SOLES" Then
                                    tot_sol = tot_sol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                Else
                                    tot_dol = tot_dol + Val(.Rows(Fila - 1)(Col + 1).ToString)
                                End If
                            End If
                            exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                            exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            filas = Fila
                        Next
                        pro01.Value = Col
                    Next
                    ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:H" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:H1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function
    'CERRAMOS FORMULARIO...
    Private Sub FrmFechas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMenu.Enabled = True
        If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then
            'If Consul_Facturas.Enabled = False Then Consul_Facturas.Enabled = True
            'If Comprobante__Pago.Enabled = False Then Comprobante__Pago.Enabled = True
        End If
        'If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then Detalles_Cobros.Enabled = True
        If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then FrmVisitas.Enabled = True
        If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then FrmPresupuestos.Enabled = True
        
        
    End Sub

    Private Sub FrmFechas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then Me.Close()
    End Sub

    'visualizamos reporte...
    Private Sub btnvis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvis.Click
        lineaActual = 0
        If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then
            Dim tipo, ingeniero As String

            If UCase(cbocriterio.Text) = "TODAS" Then tipo = " "
            If UCase(cbocriterio.Text) = "TECNICO" Then tipo = " And T.c_visita_tpo='TECNICO' "
            If UCase(cbocriterio.Text) = "ADMINISTRATIVO" Then tipo = " And T.c_visita_tpo='ADMINISTRATIVO' "
            'seleccionamos ingeniero...
            If UCase(cbocriterio2.Text) = "(TODOS)" Then
                ingeniero = " "
            Else
                ingeniero = " And T.id_traba='" & Strings.Right(cbocriterio2.Text, 5) & "' "
            End If

            Dim sql As String = "SELECT V.Id_Visita, V.Fecha_2, C.r_social, O.Direccion, Di.distrito, V.Hora_1," & _
                    "V.Hora_visita, V.Tipo, V.obs, Co.Contacto, Co.Telefono, V.Resultado, Co.celular as Procede, " & _
                    "U.Tipo AS Usuario, T.Nombres + ' ' + T.Apellidos + ' ' + T.Ape_Materno AS Empleado " & _
                    "FROM Oficinas as O INNER JOIN Distritos as Di ON O.cod_postal = Di.Item INNER JOIN Clientes as C INNER JOIN " & _
                    "Visitas as V ON C.Id_clie = V.Id_clie ON O.Id_Oficina = V.Id_Oficina INNER JOIN Usuarios as U ON V.Id_Usua = U.Id_usua INNER JOIN " & _
                    "Traba AS T ON V.Id_Traba = T.Id_Traba Inner join Contactos as Co on Co.id_conta=V.id_conta " & _
                    "where  V.anu=0 and V.fecha_2>='" & fecha1.Text & "' and V.fecha_2<='" & fecha2.Text & "'" & tipo & ingeniero & "order by V.fecha_2,T.Nombres,T.Apellidos,T.Ape_Materno"
            'FrmReportes.Reporte_Visitas(sql, "DESDE " & fecha1.Text & " AL " & fecha2.Text, "TIPO DE BUSQUEDA : " & UCase(cbocriterio.Text))
        End If
        If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COLABORADORES" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR PRODUCTOS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR COMISIONES" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR O.TRABAJO" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR INGRESOS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR SALIDAS" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR DEVOLUCIONES" Then
            Call imprimir(True)
        End If
        If UCase(lbltipo.Text) = "EXPORTAR GUIAS" Then
            Call imprimir(True)
        End If

    End Sub
    Private Sub imprimir(ByVal esPreview As Boolean)
        ' imprimir o mostrar el PrintPreview
        '
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If
        '
        'If chkSelAntes.Checked Then
        'If seleccionarImpresora() = True Then
        'If seleccionarImpresora() = False Then Return
        'End If
        's
        'seleccionamos impresora para poder imprimir...
        If chkimp.Checked Then
            Call seleccionarImpresora()
        End If
        'If Prd01.ShowDialog = Windows.Forms.DialogResult.OK Then


        If prtDoc Is Nothing Then
            'prtDoc = New PrintDocument
            prtDoc = New System.Drawing.Printing.PrintDocument

            If UCase(lbltipo.Text) = "EXPORTAR FACTURAS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR COBROS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_cobros 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Visitas 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR PRESUPUESTOS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Presupuestos 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR COLABORADORES" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Colaboradores 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR PRODUCTOS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Productos 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR COMISIONES" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Comisiones 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR O.TRABAJO" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Trabajo 'print_PrintPage 
            If UCase(lbltipo.Text) = "EXPORTAR INGRESOS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Ingresos 'exportar ingreos
            If UCase(lbltipo.Text) = "EXPORTAR SALIDAS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Salidas 'exportar ingreos
            If UCase(lbltipo.Text) = "EXPORTAR DEVOLUCIONES" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Devol 'exportar ingreos
            If UCase(lbltipo.Text) = "EXPORTAR GUIAS" Then AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage_Guias 'exportar ingreos
        End If
        '
        ' resetear la línea actual
        lineaActual = 0
        '
        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings
        'prtDoc.PrinterSettings = Prd01.PrinterSettings
        '

        If esPreview Then
            tot_dolares = 0
            tot_soles = 0
            Dim prtPrev As New PrintPreviewDialog
            prtPrev.Height = 1000
            prtPrev.Width = 1000

            prtPrev.PrintPreviewControl.Zoom = 1

            prtPrev.Document = prtDoc
            prtPrev.Text = "Previsualizar datos de " & Título
            prtPrev.ShowDialog()
        Else
            prtDoc.Print()
        End If
        'End If
    End Sub

    ' El evento usado mientras se imprime el documento
    Private Sub prt_PrintPage(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'validamos el tipo de moneda = Todas
        If cbocriterio2.SelectedIndex = 0 Then
            If UCase(cbocriterio.Text) = "TODOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.anu=0 and Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS CANCELADOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "' and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo<=0 order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS PENDIENTES" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo>0 order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS ANULADOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu>0 order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            'validamos moneda en soles o dolares
        Else
            If UCase(cbocriterio.Text) = "TODOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.anu=0 and Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and moneda='" & cbocriterio2.Text & "' order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS CANCELADOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "' and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo<=0   and moneda='" & cbocriterio2.Text & "' order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS PENDIENTES" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu=0 and Facturas_Ventas.saldo>0  and moneda='" & cbocriterio2.Text & "'  order by Facturas_Ventas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "DOCUMENTOS ANULADOS" Then
                data = New SqlDataAdapter("SELECT right(Facturas_Ventas.N_Factura+100000,5) as Item,Usuarios.Tipo AS Usuario, Facturas_Ventas.ID_Trabajo,Facturas_Ventas.N_Presu, Facturas_Ventas.Fecha_2 as Fecha,Facturas_Ventas.Fecha_3 as Fec_Cancel, right(left(Facturas_Ventas.N_Serie,4),3)  +'-'+ right(Facturas_Ventas.N_Serie,6) AS N_Factura, Clientes.r_social as Cliente, Facturas_Ventas.Moneda, " & _
                    " cast(Facturas_Ventas.Total as Decimal(16,2)) as Total,Cast(Facturas_Ventas.A_Cuenta as Decimal(16,2)) as A_Cuenta ,Cast(Facturas_Ventas.Saldo as decimal(16,2)) as Saldo, Facturas_Ventas.N_Orden,Facturas_Ventas.N_Guia, CASE Facturas_Ventas.Anu WHEN 0 THEN 'NO' ELSE 'SI' END AS Anulada,CASE Facturas_Ventas.Factu WHEN 2 THEN 'APROBADO' ELSE 'PENDIENTE' END AS Aprobado , Presupuestos.Referencia, Presupuestos.Obs_1, Facturas_Ventas.Acumula  " & _
                    " FROM Clientes INNER JOIN Facturas_Ventas ON Clientes.Id_clie = Facturas_Ventas.Id_Clie INNER JOIN Presupuestos ON Presupuestos.N_Presu_2=Facturas_Ventas.N_Presu INNER JOIN  Usuarios ON Usuarios.id_usua = Presupuestos.Usua_1 where Facturas_Ventas.fecha_2 >='" & fecha1.Text & "' and Facturas_Ventas.fecha_2 <='" & fecha2.Text & "'  and Facturas_Ventas.anu>0  and moneda='" & cbocriterio2.Text & "'  order by Facturas_Ventas.Fecha_2 ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "facturas")

        'Validamos el si existen registros activos...
        With midataset.Tables("facturas")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Facturas = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE FACTURAS EMITIDAS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)
                e.Graphics.DrawString("Tipo de Moneda : " & cbocriterio2.Text, prFont, Brushes.Black, 630, 80)

                yPos = 100
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("O.Trabajo", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Nro.Presu.", prFont3, Brushes.Black, 60, yPos)
                e.Graphics.DrawString("Fecha Emi.", prFont3, Brushes.Black, 120, yPos)
                e.Graphics.DrawString("Fecha Pago", prFont3, Brushes.Black, 180, yPos)
                e.Graphics.DrawString("Nro.Docu.", prFont3, Brushes.Black, 240, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 300, yPos)
                e.Graphics.DrawString("Anulada", prFont3, Brushes.Black, 530, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 590, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 650, yPos)
                e.Graphics.DrawString("ACta.", prFont3, Brushes.Black, 700, yPos)
                e.Graphics.DrawString("Saldo", prFont3, Brushes.Black, 750, yPos)
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)



                ' imprimir cada una de las líneas de esta página

                Do

                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("id_trabajo").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu").ToString, prFont2, Brushes.Black, 60, yPos)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 120, yPos)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    If Len(.Rows(lineaActual)("fec_cancel").ToString) > 0 Then
                        e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fec_cancel").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 180, yPos)
                    End If
                    e.Graphics.DrawString(.Rows(lineaActual)("n_factura").ToString, prFont2, Brushes.Black, 240, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("cliente").ToString, 37), prFont2, Brushes.Black, 300, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("anulada").ToString, prFont2, Brushes.Black, 530, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("moneda").ToString, prFont2, Brushes.Black, 590, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("total").ToString, prFont2, Brushes.Black, 650, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("a_cuenta").ToString, prFont2, Brushes.Black, 700, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("saldo").ToString, prFont2, Brushes.Black, 750, yPos)
                    'acumulamos totales en soles
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "SOLES" Then
                        tot_soles = tot_soles + Val(.Rows(lineaActual)("total").ToString)
                        acuenta_sol = acuenta_sol + Val(.Rows(lineaActual)("a_cuenta").ToString)
                        saldo_sol = saldo_sol + Val(.Rows(lineaActual)("saldo").ToString)
                    End If
                    'acumulamos totales en dolares
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "DOLARES" Then
                        tot_dolares = tot_dolares + Val(.Rows(lineaActual)("total").ToString)
                        acuenta_dol = acuenta_dol + Val(.Rows(lineaActual)("a_cuenta").ToString)
                        saldo_dol = saldo_dol + Val(.Rows(lineaActual)("saldo").ToString)
                    End If
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1


                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 10)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    yPos += 20
                    e.Graphics.DrawString("Total De Documentos = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos) 'TOTAL soles
                    e.Graphics.DrawString("Total Soles    = S/. ", prFont2, Brushes.Black, 420, yPos) 'TOTAL soles
                    e.Graphics.DrawString(Format(tot_soles, forma_3), prFont2, Brushes.Black, 510, yPos) 'TOTAL soles
                    e.Graphics.DrawString("A Cta.= S/. ", prFont2, Brushes.Black, 570, yPos) ' acuenta
                    e.Graphics.DrawString(Format(acuenta_sol, forma_3), prFont2, Brushes.Black, 620, yPos) 'TOTAL Cuenta Soles
                    e.Graphics.DrawString("Saldo= S/. ", prFont2, Brushes.Black, 680, yPos) ' saldo
                    e.Graphics.DrawString(Format(saldo_sol, forma_3), prFont2, Brushes.Black, 730, yPos) 'TOTAL saldo Soles
                    yPos = yPos + 10
                    e.Graphics.DrawString("Total Dolares = $. ", prFont2, Brushes.Black, 420, yPos) 'TOTAL dolares
                    e.Graphics.DrawString(Format(tot_dolares, forma_3), prFont2, Brushes.Black, 510, yPos) 'TOTAL dolares
                    e.Graphics.DrawString("A Cta.= $. ", prFont2, Brushes.Black, 570, yPos) ' acuenta
                    e.Graphics.DrawString(Format(acuenta_dol, forma_3), prFont2, Brushes.Black, 620, yPos) 'TOTAL Cuenta Soles
                    e.Graphics.DrawString("Saldo= $. ", prFont2, Brushes.Black, 680, yPos) ' saldo dolares
                    e.Graphics.DrawString(Format(saldo_dol, forma_3), prFont2, Brushes.Black, 730, yPos) 'TOTAL saldo dolares

                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    e.HasMorePages = False
                    lineaActual = 0
                    'dejamos en cero los totales
                    tot_dolares = 0
                    tot_soles = 0
                    acuenta_dol = 0
                    acuenta_sol = 0
                    saldo_dol = 0
                    saldo_sol = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    'seleccionamos impresora
    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog

        If prtSettings Is Nothing Then
            prtSettings = New Printing.PrinterSettings
        End If
        With prtDialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True
            .PrinterSettings = prtSettings
            If .ShowDialog() = DialogResult.OK Then
                prtSettings = .PrinterSettings
            Else
                Return False
            End If

        End With

        Return True
    End Function
    ' El evento usado mientras se imprime el documento (detalles de cobros)
    Private Sub prt_PrintPage_cobros(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "(TODOS)" Then
            data = New SqlDataAdapter("SELECT D_cobros.*,Facturas.ID_Trabajo,Facturas.N_Presu, right(left(Facturas.N_Serie,4),3)  +'-'+ right(Facturas.N_Serie,6) AS Factura, Clientes.r_social as Cliente " & _
                " FROM Clientes INNER JOIN Facturas ON Clientes.Id_clie = Facturas.Id_Clie INNER JOIN d_cobros ON d_cobros.N_Factura=Facturas.N_Factura " & _
                " where d_cobros.fecha_3 >='" & fecha1.Text & "' and d_cobros.fecha_3 <='" & fecha2.Text & "'  order by d_cobros.Fecha_3 ", conex)
        Else
            data = New SqlDataAdapter("SELECT D_cobros.*,Facturas.ID_Trabajo,Facturas.N_Presu, right(left(Facturas.N_Serie,4),3)  +'-'+ right(Facturas.N_Serie,6) AS Factura, Clientes.r_social as Cliente " & _
                " FROM Clientes INNER JOIN Facturas ON Clientes.Id_clie = Facturas.Id_Clie INNER JOIN d_cobros ON d_cobros.N_Factura=Facturas.N_Factura " & _
                " where d_cobros.fecha_3 >='" & fecha1.Text & "' and d_cobros.fecha_3 <='" & fecha2.Text & "' and d_cobros.F_Pago='" & Strings.Right(cbocriterio.Text, 4) & "' order by d_cobros.Fecha_3 ", conex)
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "cobros")

        'Validamos el si existen registros activos...
        With midataset.Tables("cobros")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Cobros = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE COBROS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("N.Presu", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("O.T.", prFont3, Brushes.Black, 60, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 90, yPos)
                e.Graphics.DrawString("Fecha Emi.", prFont3, Brushes.Black, 120, yPos)
                e.Graphics.DrawString("F.Deposito", prFont3, Brushes.Black, 180, yPos)
                e.Graphics.DrawString("Documento", prFont3, Brushes.Black, 240, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 300, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 580, yPos)
                e.Graphics.DrawString("Detraccion", prFont3, Brushes.Black, 630, yPos)
                e.Graphics.DrawString("Retencion", prFont3, Brushes.Black, 690, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 740, yPos)
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("id_trabajo").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu").ToString, prFont2, Brushes.Black, 60, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("f_pago").ToString, prFont2, Brushes.Black, 90, yPos)

                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 120, yPos)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    If Len(.Rows(lineaActual)("fecha_3").ToString) > 0 Then
                        e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_3").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 180, yPos)
                    End If
                    e.Graphics.DrawString(.Rows(lineaActual)("factura").ToString, prFont2, Brushes.Black, 240, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("cliente").ToString, 45), prFont2, Brushes.Black, 300, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("t_moneda").ToString, prFont2, Brushes.Black, 580, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Detraccion").ToString, prFont2, Brushes.Black, 640, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Retencion").ToString, prFont2, Brushes.Black, 700, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("a_cuenta").ToString, prFont2, Brushes.Black, 740, yPos)
                    If UCase(.Rows(lineaActual)("T_moneda").ToString) = "SOLES" Then tot_soles = tot_soles + Val(.Rows(lineaActual)("a_cuenta").ToString)
                    If UCase(.Rows(lineaActual)("T_moneda").ToString) = "DOLARES" Then tot_dolares = tot_dolares + Val(.Rows(lineaActual)("a_cuenta").ToString)

                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1

                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 10)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    yPos += 20
                    e.Graphics.DrawString("Total De Cobros = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos) 'TOTAL soles
                    'totales de cobros...
                    e.Graphics.DrawString("F001 = Cheque", prFont2, Brushes.Black, 150, yPos) 'cheque
                    e.Graphics.DrawString("F002 = Cheque Diferido", prFont2, Brushes.Black, 150, yPos + 10) 'cheque
                    e.Graphics.DrawString("F006 = Efectivo", prFont2, Brushes.Black, 300, yPos) 'cheque
                    e.Graphics.DrawString("F004 = Deposito", prFont2, Brushes.Black, 300, yPos + 10) 'cheque

                    e.Graphics.DrawString("Total De Cobros = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos) 'TOTAL soles

                    e.Graphics.DrawString("Total Soles    = S/. ", prFont2, Brushes.Black, 590, yPos) 'TOTAL soles
                    e.Graphics.DrawString(Format(tot_soles, forma_3), prFont2, Brushes.Black, 670, yPos) 'TOTAL soles
                    yPos = yPos + 10
                    e.Graphics.DrawString("Total Dolares = $. ", prFont2, Brushes.Black, 590, yPos) 'TOTAL soles
                    e.Graphics.DrawString(Format(tot_dolares, forma_3), prFont2, Brushes.Black, 670, yPos) 'TOTAL soles
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    e.HasMorePages = False
                    lineaActual = 0
                    tot_dolares = 0
                    tot_soles = 0

                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    'visualizar visitas del dia
    Private Sub prt_PrintPage_Visitas(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'Imprimimos por tecnico
        If UCase(cbocriterio2.Text) = "(TODOS)" Then
            If UCase(cbocriterio.Text) = "TODAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "REALIZADAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  and visitas.factu<>2 order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "'  and visitas.factu=2 order by visitas.Fecha_2 ", conex)
            End If
        Else
            If UCase(cbocriterio.Text) = "TODAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "' And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "' order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "REALIZADAS" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "' And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "'  and visitas.factu<>2 order by visitas.Fecha_2 ", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("SELECT visitas.id_visita,visitas.Fecha_2,visitas.resultado,visitas.hora_visita,contactos.telefono,contactos.celular,visitas.obs,usuarios.tipo as Usuario,contactos.contacto as Contacto_2,oficinas.direccion as Oficina, clientes.r_social,traba.nombres +' '+ traba.apellidos as Ingeniero,Distrito from visitas " & _
                    " INNER JOIN clientes ON Clientes.Id_clie = visitas.Id_Clie INNER JOIN traba ON traba.id_traba=visitas.id_traba INNER JOIN oficinas ON visitas.id_oficina=oficinas.id_oficina " & _
                    " INNER JOIN  distritos ON distritos.item = oficinas.cod_postal INNER JOIN contactos ON contactos.id_conta=visitas.id_conta inner join usuarios ON usuarios.id_usua=visitas.id_usua where visitas.fecha_2 >='" & fecha1.Text & "' and visitas.fecha_2 <='" & fecha2.Text & "' And Traba.Id_Traba='" & Strings.Right(cbocriterio2.Text, 5) & "' and visitas.factu=2 order by visitas.Fecha_2 ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "visitas")
        'Validamos el si existen registros activos...
        With midataset.Tables("visitas")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Visitas = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 35 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE VISITAS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Visita", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Fecha", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("Usuario", prFont3, Brushes.Black, 105, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 170, yPos)
                e.Graphics.DrawString("Ingeniero", prFont3, Brushes.Black, 410, yPos)
                e.Graphics.DrawString("Direccion", prFont3, Brushes.Black, 610, yPos)
                e.Graphics.DrawString("Distrito", prFont3, Brushes.Black, 940, yPos)
                e.Graphics.DrawString("Realizada", prFont3, Brushes.Black, 1040, yPos)
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)

                ' imprimir cada una de las líneas de esta página

                Do

                    yPos += lineHeight + 5
                    e.Graphics.DrawString(.Rows(lineaActual)("id_visita").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("Fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 50, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("Usuario").ToString, 10), prFont2, Brushes.Black, 105, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("r_social").ToString, 39), prFont2, Brushes.Black, 170, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("ingeniero").ToString, prFont2, Brushes.Black, 410, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("oficina").ToString, 55), prFont2, Brushes.Black, 610, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("distrito").ToString, 15), prFont2, Brushes.Black, 940, yPos)
                    e.Graphics.DrawString(UCase(.Rows(lineaActual)("Resultado").ToString), prFont2, Brushes.Black, 1040, yPos)
                    'segunda linea
                    'validamos si ha registrado la hora de visita
                    If Len(.Rows(lineaActual)("hora_visita").ToString) > 0 Then
                        e.Graphics.DrawString("Hora: " & FormatDateTime(.Rows(lineaActual)("hora_visita").ToString, DateFormat.ShortTime), prFont2, Brushes.Black, 50, yPos + 12)
                    Else
                        e.Graphics.DrawString("Hora: ", prFont2, Brushes.Black, 50, yPos + 12)
                    End If
                    e.Graphics.DrawString("Contacto: " & Strings.Left(.Rows(lineaActual)("Contacto_2").ToString, 26), prFont2, Brushes.Black, 170, yPos + 12)
                    e.Graphics.DrawString("Telf.: " & .Rows(lineaActual)("Telefono").ToString, prFont2, Brushes.Black, 410, yPos + 12)
                    e.Graphics.DrawString("Cel.: " & .Rows(lineaActual)("celular").ToString, prFont2, Brushes.Black, 610, yPos + 12)
                    e.Graphics.DrawString("Observaciones: " & .Rows(lineaActual)("Obs").ToString, prFont2, Brushes.Black, 170, yPos + 24)
                    e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 29)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1

                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 42)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 32)
                    yPos += 20
                    e.Graphics.DrawString("Total De Visitas = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 20) 'TOTAL de visitas
                    'e.Graphics.DrawString("Pag. " & lineaActual, prFont2, Brushes.Black, 800, yPos + 20) 'paginas

                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    Private Sub prt_PrintPage_Presupuestos(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'validamos si son todos los usuarios....
        If cbocriterio2.SelectedIndex = 0 Then
            If UCase(cbocriterio.Text) = "TODOS" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' order by presupuestos.fecha_2", conex)
            End If
            If UCase(cbocriterio.Text) = "APROBADOS" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu>0 order by presupuestos.fecha_2", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu=0  order by presupuestos.fecha_2", conex)
            End If
        Else
            If UCase(cbocriterio.Text) = "TODOS" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento  from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' order by presupuestos.fecha_2", conex)
            End If
            If UCase(cbocriterio.Text) = "APROBADOS" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento  from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu>0  and usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' order by presupuestos.fecha_2", conex)
            End If
            If UCase(cbocriterio.Text) = "PENDIENTES" Then
                data = New SqlDataAdapter("select N_Presu_2 as N_Presu,Fecha_2 as Fecha,Fec_Actu,Usuarios.tipo as Usuario,T_Presu as Tipo,Clientes.R_Social as Cliente,T_Moneda as Moneda,Total+Dscto as Monto,Dscto,Total," & _
                                          "Referencia,Ubicacion,presupuestos.Factu,presupuestos.Seguimiento from presupuestos inner join clientes on clientes.id_clie=presupuestos.id_clie inner join usuarios on usuarios.id_usua=presupuestos.usua_1 " & _
                                          "where presupuestos.fecha_2>='" & fecha1.Text & "' and presupuestos.fecha_2<='" & fecha2.Text & "' and Presupuestos.Factu=0   and usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' order by presupuestos.fecha_2", conex)
            End If
        End If
        'Enviamos informacion al dataset
        data.Fill(midataset, "presupuestos")
        Dim tot_sol, tot_dol As Double
        'Validamos el si existen registros activos...
        With midataset.Tables("presupuestos")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Presupuesto = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)
                Dim prfont5 As New Font("Arial", 8, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 15 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE PRESUPUESTOS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)
                'usuarios
                e.Graphics.DrawString("Usuario : " & cbocriterio2.Text, prFont, Brushes.Black, 630, 80)

                yPos = 95
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 105
                e.Graphics.DrawString("N.Presu.", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Fecha", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("Usuario", prFont3, Brushes.Black, 105, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 170, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 250, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 490, yPos)
                e.Graphics.DrawString("Aprobado", prFont3, Brushes.Black, 550, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 610, yPos)
                e.Graphics.DrawString("Dscto.", prFont3, Brushes.Black, 670, yPos)
                e.Graphics.DrawString("Total", prFont3, Brushes.Black, 740, yPos)
                yPos = 115
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 112
                ' imprimir cada una de las líneas de esta página

                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("N_PRESU").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("Fecha").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 50, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("Usuario").ToString, 10), prFont2, Brushes.Black, 105, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("Tipo").ToString, 10), prFont2, Brushes.Black, 170, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("cliente").ToString, 39), prFont2, Brushes.Black, 250, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("moneda").ToString, prFont2, Brushes.Black, 490, yPos)
                    'validamos estado del presupuesto
                    If Val(.Rows(lineaActual)("factu").ToString) = 0 Then
                        e.Graphics.DrawString("Pendiente", prFont2, Brushes.Black, 550, yPos)
                    Else
                        e.Graphics.DrawString("Aprobado", prFont2, Brushes.Black, 550, yPos)
                    End If
                    'llenamos los montos...
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("monto").ToString), forma_3), prFont2, Brushes.Black, 610, yPos)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("dscto").ToString), forma_3), prFont2, Brushes.Black, 670, yPos)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("total").ToString), forma_3), prFont2, Brushes.Black, 740, yPos)
                    'segunda linea
                    yPos += 12
                    e.Graphics.DrawString("Referencia: " & Strings.Left(.Rows(lineaActual)("Referencia").ToString, 65), prFont2, Brushes.Black, 50, yPos)

                    'e.Graphics.DrawString("Ubicacion: " & Strings.Left(.Rows(lineaActual)("Ubicacion").ToString, 100), prFont2, Brushes.Black, 410, yPos + 15)
                    If .Rows(lineaActual)("moneda").ToString = "SOLES" Then tot_soles = tot_soles + Val(.Rows(lineaActual)("total").ToString)
                    If .Rows(lineaActual)("moneda").ToString = "DOLARES" Then tot_dolares = tot_dolares + Val(.Rows(lineaActual)("total").ToString)
                    'validamos si se ha registrado el seguimiento
                    If Len(Trim(.Rows(lineaActual)("seguimiento").ToString)) > 0 Then
                        'yPos += 12
                        '========================================================
                        'e.Graphics.DrawString("(" & FormatDateTime(.Rows(lineaActual)("fec_actu").ToString, DateFormat.GeneralDate) & ") " & .Rows(lineaActual)("seguimiento").ToString, prFont2, Brushes.Red, 50, yPos)
                        Dim Texto() As String, ent As Integer
                        If Len(.Rows(lineaActual)("fec_actu").ToString) > 0 Then
                            Texto = Split(Trim(FormatDateTime(.Rows(lineaActual)("fec_actu").ToString, DateFormat.ShortDate) & " " & .Rows(lineaActual)("seguimiento").ToString), vbCrLf)
                        Else
                            Texto = Split(Trim(.Rows(lineaActual)("seguimiento").ToString), vbCrLf)
                        End If
                        'Validamos si seguimiento contiene enters seguido...
                        Dim filas As Integer
                        Dim x As Integer
                        Dim seguir As String = ""
                        For ent = 0 To UBound(Texto)
                            'validamos si es la primera fila para amarrar con la fecha de seguimiento
                            x = 0
                            filas = Len(Texto(ent)) / 110
                            For i = 0 To filas
                                If ent = 0 Then
                                    'validamos si se ha actualizado la fecha de seguimiento
                                    'If Len(.Rows(lineaActual)("fec_actu").ToString) > 0 Then
                                    'seguir = "(" & FormatDateTime(.Rows(lineaActual)("Fec_actu").ToString, DateFormat.ShortDate) & ")" & Strings.Mid(Texto(ent), (x * 110 + 1), 110)
                                    'Else
                                    seguir = Strings.Mid(Texto(ent), (x * 110 + 1), 110)
                                    'End If
                                Else
                                    seguir = Strings.Mid(Texto(ent), (x * 110 + 1), 110)
                                End If
                                yPos += 12
                                e.Graphics.DrawString(seguir, prFont2, Brushes.Red, 50, yPos)
                                x += 1
                            Next
                        Next ent
                        yPos += 5
                        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos)
                    Else
                        yPos += 8
                        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos)
                    End If
            lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    yPos += 5
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                    e.HasMorePages = True
                Else
                    yPos += 10
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                    yPos += 10
                    e.Graphics.DrawString("Total De Presupuestos = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos) 'TOTAL de visitas
                    e.Graphics.DrawString("Total Soles = S/." & Format(tot_soles, forma_3), prFont2, Brushes.Black, 490, yPos) 'TOTAL EN SOLES
                    e.Graphics.DrawString("Total Dolares = US$ " & Format(tot_dolares, forma_3), prFont2, Brushes.Black, 640, yPos) 'TOTAL EN dolares
                    yPos += 10
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If

        End With
    End Sub
    Private Sub prt_PrintPage_Colaboradores(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(CboCriterio3.Text) = "(TODAS)" Then
            If UCase(cbocriterio.Text) = "TODOS" Then
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " where id_traba<>'00052' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          "where estado='" & cbocriterio2.Text & "' and  id_traba<>'00052' order by nombres,apellidos", conex)
                End If
            Else
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " where tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          "where estado='" & cbocriterio2.Text & "' and tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052' order by nombres,apellidos", conex)
                End If
            End If
        Else 'Validamos cuando deseamos buscar por empresa
            If UCase(cbocriterio.Text) = "TODOS" Then
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " where id_traba<>'00052' and Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          "where estado='" & cbocriterio2.Text & "' and  id_traba<>'00052'  and Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                End If
            Else
                If UCase(cbocriterio2.Text) = "TODOS" Then
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          " where tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052'  and Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                Else
                    data = New SqlDataAdapter("Select traba.*,distrito,provincia,departamento from traba inner join distritos on traba.id_zona=distritos.item " & _
                                          "where estado='" & cbocriterio2.Text & "' and tipo='" & cbocriterio.Text & "'  and  id_traba<>'00052'  and Id_Empresa='" & Strings.Right(CboCriterio3.Text, 4) & "' order by nombres,apellidos", conex)
                End If
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "traba")
        'Validamos el si existen registros activos...
        With midataset.Tables("traba")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Colaboradores = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE COLABORADORES", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Estado : " & cbocriterio2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)
                e.Graphics.DrawString("Empresa : " & CboCriterio3.Text, prFont, Brushes.Black, 550, 80)

                yPos = 100
                e.Graphics.DrawString("============================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Dni", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Nombres", prFont3, Brushes.Black, 60, yPos)
                e.Graphics.DrawString("Apellidos", prFont3, Brushes.Black, 210, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 360, yPos)
                e.Graphics.DrawString("Cargo", prFont3, Brushes.Black, 450, yPos)
                e.Graphics.DrawString("Area", prFont3, Brushes.Black, 580, yPos)
                e.Graphics.DrawString("Distrito", prFont3, Brushes.Black, 670, yPos)

                e.Graphics.DrawString("============================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página

                Do

                    yPos += lineHeight + 7
                    e.Graphics.DrawString(.Rows(lineaActual)("dni").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("nombres").ToString, prFont2, Brushes.Black, 60, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("apellidos").ToString, prFont2, Brushes.Black, 210, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Tipo").ToString, prFont2, Brushes.Black, 360, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("cargo").ToString, prFont2, Brushes.Black, 450, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("area").ToString, prFont2, Brushes.Black, 580, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("distrito").ToString, prFont2, Brushes.Black, 670, yPos)

                    'segunda linea
                    e.Graphics.DrawString("Telefono: " & .Rows(lineaActual)("telefono").ToString & " " & .Rows(lineaActual)("Celular").ToString, prFont2, Brushes.Black, 60, yPos + 15)
                    e.Graphics.DrawString("Direccion: " & StrConv(.Rows(lineaActual)("direccion").ToString, VbStrConv.ProperCase) & " " & _
                     StrConv(.Rows(lineaActual)("provincia").ToString & " " & .Rows(lineaActual)("departamento").ToString, VbStrConv.ProperCase), prFont2, Brushes.Black, 360, yPos + 15)
                    e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 22)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1

                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("============================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 40)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("============================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 20
                    e.Graphics.DrawString("Total De Colaboradores = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 20) 'TOTAL de visitas
                    e.Graphics.DrawString("============================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If

        End With
    End Sub
    'visualizar productos...
    Private Sub prt_PrintPage_Productos(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'BUSCAMOS PRODUCTOS CON MOVIMIENTOS...
        If chkopcion.Checked = True Then
            'BUSCAMOS POR PRODUCTOS ESPECIALES... 
            If Chkopcion2.Checked = True Then
                'validamos si mostramos solo productos cuyo stock sea mayor a cero...
                If cbocriterio2.SelectedIndex = 0 Then
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO'  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                Else
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' and Especial=1 order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' and Especial=1 and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                End If
            Else 'mostramos productos solo con stock activo y todos
                If cbocriterio2.SelectedIndex = 0 Then
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO'  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                Else
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' and Especial=1 order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>-1 and estado='ACTIVO' and Especial=1 and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                End If
            End If
        Else
            If Chkopcion2.Checked = True Then
                'validamos si mostramos solo productos cuyo stock sea mayor a cero...
                If cbocriterio2.SelectedIndex = 0 Then
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO'  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                Else
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' and Especial=1 order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where stock_1>0 and estado='ACTIVO' and Especial=1 and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' order by concepto", conex)
                    End If
                End If
            Else
                'mostramos todos los productos activos e inactivos
                If cbocriterio2.SelectedIndex = 0 Then
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca WHERE  estado='ACTIVO' order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' and estado='ACTIVO' order by concepto", conex)
                    End If
                Else
                    If cbocriterio.SelectedIndex = 0 Then
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca WHERE  estado='ACTIVO' and Especial=1 order by concepto", conex)
                    Else
                        data = New SqlDataAdapter("SELECT id_Produ as Codigo,Id_Tipo as Tipo,Concepto,Tonelada as Capacidad,Modelo,Marcas.Marca,Nick,Stock_1 as Stock," & _
                                                  "Stock_2 as Existe,Nick_2 as M,Precio_1 as P_Costo,Precio_2 as P_Venta,Productos.Obs from productos inner join marcas on productos.id_marca=marcas.id_marca where  Especial=1  and id_tipo='" & Strings.Right(cbocriterio.Text, 4) & "' and estado='ACTIVO' order by concepto", conex)
                    End If
                End If
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "productos")

        'Validamos el si existen registros activos...
        With midataset.Tables("productos")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Productos = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 20 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE PRODUCTOS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                'e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Codigo", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("Concepto", prFont3, Brushes.Black, 80, yPos)
                e.Graphics.DrawString("Capacidad", prFont3, Brushes.Black, 300, yPos)
                e.Graphics.DrawString("Modelo", prFont3, Brushes.Black, 430, yPos)
                e.Graphics.DrawString("Marca", prFont3, Brushes.Black, 530, yPos)
                e.Graphics.DrawString("Medida", prFont3, Brushes.Black, 640, yPos)
                e.Graphics.DrawString("Stock", prFont3, Brushes.Black, 680, yPos)
                e.Graphics.DrawString("Existe", prFont3, Brushes.Black, 750, yPos)
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)

                ' imprimir cada una de las líneas de esta página

                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("codigo").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Tipo").ToString, prFont2, Brushes.Black, 50, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("concepto").ToString, 70), prFont2, Brushes.Black, 80, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("capacidad").ToString, 70), prFont2, Brushes.Black, 300, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("modelo").ToString, prFont2, Brushes.Black, 430, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("marca").ToString, prFont2, Brushes.Black, 530, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("nick").ToString, prFont2, Brushes.Black, 640, yPos)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("stock").ToString), forma), prFont2, Brushes.Black, 680, yPos)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("existe").ToString), forma), prFont2, Brushes.Black, 750, yPos)
                    'segunda linea
                    'validamos si existen comentarios que mostrar...
                    If Len(.Rows(lineaActual)("obs").ToString) > 0 Then
                        yPos += lineHeight - 2
                        e.Graphics.DrawString("Obs: " & StrConv(.Rows(lineaActual)("obs").ToString, VbStrConv.ProperCase), prFont2, Brushes.Black, 80, yPos)
                        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 10)
                    Else
                        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 10)
                    End If
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 40)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 20
                    e.Graphics.DrawString("Total De Productos = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 20) 'TOTAL de productos
                    'e.Graphics.DrawString("Pag. " & lineaActual, prFont2, Brushes.Black, 800, yPos + 20) 'paginas

                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    'visualizar productos...
    Private Sub prt_PrintPage_Comisiones(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet

        'validamos si la busqueda es por usuario...
        If cbocriterio2.SelectedIndex = 0 Then
            If cbocriterio.SelectedIndex = 0 Then
                data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                          "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Inge from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                          "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.obs_comision like '%" & txtobs.Text & "%'  and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
            Else
                If UCase(cbocriterio.Text) = "PENDIENTES VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_1=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_1>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If
                'busqueda por ingeniero...
                If UCase(cbocriterio.Text) = "PENDIENTES INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and  comision_2=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0  and comision_2>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision_2 like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If

            End If
        Else 'buscar por usuario...
            If cbocriterio.SelectedIndex = 0 Then
                data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                          "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Inge from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                          "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.obs_comision like '%" & txtobs.Text & "%'  and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
            Else
                If UCase(cbocriterio.Text) = "PENDIENTES VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' and comision_1=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS VENTAS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "'  and comision_1>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If
                'busqueda por ingeniero...
                If UCase(cbocriterio.Text) = "PENDIENTES INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "' and comision_2=0 and presupuestos.fecha_2>='01/01/2010' order by trabajo.fecha_2", conex)
                End If
                If UCase(cbocriterio.Text) = "CANCELADAS INGENIEROS" Then
                    data = New SqlDataAdapter("SELECT Presupuestos.N_Presu_2 as Presu,Id_Trabajo as Orden,Trabajo.Fecha_2 as Fecha_Orden,Usuarios.Tipo as Usuario,Clientes.R_Social,Traba.nombres+' '+Traba.Apellidos as Ingeniero,T_Moneda as Moneda,Total,Comision_1 as Comi_Venta," & _
                                              "Comision_2 as Comi_Ing,Obs_Comision as Mes_Pago_Venta,Obs_Comision_2 as Mes_Pago_Ing from Trabajo inner join Presupuestos on trabajo.n_presu=presupuestos.n_presu inner join clientes on clientes.id_clie=presupuestos.id_clie " & _
                                              "inner join traba on traba.id_traba=presupuestos.id_vende inner join usuarios on presupuestos.usua_1=usuarios.id_usua where saldo<=0 and presupuestos.usua_1='" & Strings.Right(cbocriterio2.Text, 4) & "'  and comision_2>0 and presupuestos.fecha_2>='01/01/2010' and obs_comision_2 like '%" & txtobs.Text & "%'  order by trabajo.fecha_2", conex)
                End If

            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "comisiones")

        'Validamos el si existen registros activos...
        With midataset.Tables("comisiones")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Comisiones = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE COMISIONES", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                'e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Usuario : " & cbocriterio2.Text, prFont, Brushes.Black, 10, 80)
                e.Graphics.DrawString("Mes de Pago : " & txtobs.Text, prFont, Brushes.Black, 630, 80)

                yPos = 100
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Presu", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Orden", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("Fec.Orden", prFont3, Brushes.Black, 75, yPos)
                e.Graphics.DrawString("Usuario", prFont3, Brushes.Black, 140, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 200, yPos)
                e.Graphics.DrawString("Ingeniero", prFont3, Brushes.Black, 380, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 540, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 590, yPos)
                e.Graphics.DrawString("Com.Vta.", prFont3, Brushes.Black, 640, yPos)
                e.Graphics.DrawString("Pagada", prFont3, Brushes.Black, 685, yPos)
                e.Graphics.DrawString("Com.Ing.", prFont3, Brushes.Black, 730, yPos)
                e.Graphics.DrawString("Pagada", prFont3, Brushes.Black, 780, yPos)
                e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)

                ' imprimir cada una de las líneas de esta página

                Do

                    yPos += lineHeight + 7
                    e.Graphics.DrawString(.Rows(lineaActual)("presu").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Orden").ToString, prFont2, Brushes.Black, 50, yPos)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_orden").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 80, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("Usuario").ToString, 70), prFont2, Brushes.Black, 140, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("r_social").ToString, 29), prFont2, Brushes.Black, 200, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("ingeniero").ToString, 25), prFont2, Brushes.Black, 380, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("moneda").ToString, prFont2, Brushes.Black, 540, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("Total").ToString, prFont2, Brushes.Black, 590, yPos)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("Comi_Venta").ToString), forma), prFont2, Brushes.Black, 650, yPos)
                    'comisiones de ventas
                    If Val(.Rows(lineaActual)("comi_venta").ToString) > 0 Then
                        e.Graphics.DrawString("SI", prFont2, Brushes.Black, 685, yPos)
                    Else
                        e.Graphics.DrawString("NO", prFont2, Brushes.Black, 685, yPos)
                    End If
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("comi_ing").ToString), forma), prFont2, Brushes.Black, 730, yPos)
                    'comisiones de ingenieros
                    If Val(.Rows(lineaActual)("comi_ing").ToString) > 0 Then
                        e.Graphics.DrawString("SI", prFont2, Brushes.Black, 780, yPos)
                    Else
                        e.Graphics.DrawString("NO", prFont2, Brushes.Black, 780, yPos)
                    End If
                    'segunda linea
                    e.Graphics.DrawString("Mes Pago Vta.: " & StrConv(.Rows(lineaActual)("mes_pago_venta").ToString, VbStrConv.ProperCase), prFont2, Brushes.Black, 200, yPos + 15)
                    e.Graphics.DrawString("Mes Pago Inge.: " & StrConv(.Rows(lineaActual)("mes_pago_ing").ToString, VbStrConv.ProperCase), prFont2, Brushes.Black, 380, yPos + 15)
                    'Acumulamos total de venta del presupuestos
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "SOLES" Then tot_sol = tot_sol + Val(.Rows(lineaActual)("total").ToString)
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "DOLARES" Then tot_dol = tot_dol + Val(.Rows(lineaActual)("total").ToString)
                    'Acumulamos total de comisiones de ventas...
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "SOLES" Then comi_sol_vta = comi_sol_vta + Val(.Rows(lineaActual)("comi_venta").ToString)
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "DOLARES" Then comi_dol_vta = comi_dol_vta + Val(.Rows(lineaActual)("comi_venta").ToString)
                    'Acumulamos total de comisiones de ingenieros...
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "SOLES" Then comi_sol_ing = comi_sol_ing + Val(.Rows(lineaActual)("comi_ing").ToString)
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "DOLARES" Then comi_dol_ing = comi_dol_ing + Val(.Rows(lineaActual)("comi_ing").ToString)

                    e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 22)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 40)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 20
                    e.Graphics.DrawString("Total De Comisiones = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 20) 'TOTAL de comisiones
                    e.Graphics.DrawString("Total Soles S/." & Format(tot_sol, forma_3), prFont2, Brushes.Black, 500, yPos + 20) 'TOTAL de soles
                    e.Graphics.DrawString("S/." & Format(comi_sol_vta, forma_3), prFont2, Brushes.Black, 650, yPos + 20) 'TOTAL de soles
                    e.Graphics.DrawString("S/." & Format(comi_sol_ing, forma_3), prFont2, Brushes.Black, 730, yPos + 20) 'TOTAL de soles
                    'dolares
                    e.Graphics.DrawString("Total Dolares $." & Format(tot_dol, forma_3), prFont2, Brushes.Black, 500, yPos + 30) 'TOTAL de dolares
                    e.Graphics.DrawString("$. " & Format(comi_dol_vta, forma_3), prFont2, Brushes.Black, 650, yPos + 30) 'TOTAL de dolares
                    e.Graphics.DrawString("$. " & Format(comi_dol_ing, forma_3), prFont2, Brushes.Black, 730, yPos + 30) 'TOTAL de dolares
                    e.Graphics.DrawString("============================================================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 40)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    ' El evento usado mientras se imprime el documento (detalles de cobros)
    Private Sub prt_PrintPage_Trabajo(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                " Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_2 >='" & fecha1.Text & "' and trabajo.fecha_2 <='" & fecha2.Text & "' and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "REALIZADOS" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                " Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_3 >='" & fecha1.Text & "' and trabajo.fecha_3 <='" & fecha2.Text & "' and trabajo.fecha_3 is not null   and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If
        If UCase(cbocriterio.Text) = "PENDIENTES" Then
            data = New SqlDataAdapter("SELECT Trabajo.Id_Trabajo,Trabajo.N_Presu_2,Trabajo.Fecha_2,Trabajo.Fecha_3,Clientes.r_social as Cliente,Traba.Nombres + '-' + Traba.Apellidos as Tecnico, " & _
                " Presupuestos.T_Moneda,Presupuestos.Total FROM Trabajo INNER JOIN Presupuestos ON Trabajo.n_presu = Presupuestos.n_presu INNER JOIN clientes ON clientes.id_clie=presupuestos.id_clie " & _
                " inner join traba on Traba.id_traba=trabajo.id_traba where trabajo.fecha_2 >='" & fecha1.Text & "' and trabajo.fecha_2 <='" & fecha2.Text & "' and trabajo.fecha_3 is null  and Trabajo.tipo not in ('REGULARIZACION','RECLAMO') order by trabajo.Fecha_2 ", conex)
        End If

        'enviamos informacion al dataset
        data.Fill(midataset, "trabajo")

        'Validamos el si existen registros activos...
        With midataset.Tables("trabajo")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Ordenes = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 20 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE O.TRABAJO", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("N.Presu", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("O.T.", prFont3, Brushes.Black, 60, yPos)
                e.Graphics.DrawString("Fec.Emision", prFont3, Brushes.Black, 100, yPos)
                e.Graphics.DrawString("Fec.Final.", prFont3, Brushes.Black, 160, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 220, yPos)
                e.Graphics.DrawString("Tecnico", prFont3, Brushes.Black, 430, yPos)
                e.Graphics.DrawString("Estado", prFont3, Brushes.Black, 630, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 690, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 735, yPos)
                e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu_2").ToString, prFont2, Brushes.Black, 10, yPos)
                    e.Graphics.DrawString(.Rows(lineaActual)("id_trabajo").ToString, prFont2, Brushes.Black, 60, yPos)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 100, yPos)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    If Len(.Rows(lineaActual)("fecha_3").ToString) > 0 Then
                        e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_3").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 160, yPos)
                        e.Graphics.DrawString("REALIZADO", prFont2, Brushes.Black, 630, yPos)
                    Else
                        e.Graphics.DrawString("PENDIENTE", prFont2, Brushes.Black, 630, yPos)
                    End If
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("cliente").ToString, 36), prFont2, Brushes.Black, 210, yPos)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("tecnico").ToString, 45), prFont2, Brushes.Black, 430, yPos)
                    If .Rows(lineaActual)("t_moneda").ToString = "SOLES" Then
                        e.Graphics.DrawString("MN", prFont2, Brushes.Black, 700, yPos)
                        tot_sol = tot_sol + Val(.Rows(lineaActual)("total").ToString)
                    Else
                        e.Graphics.DrawString("US", prFont2, Brushes.Black, 700, yPos)
                        tot_dol = tot_dol + Val(.Rows(lineaActual)("total").ToString)

                    End If

                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("Total").ToString, 45), prFont2, Brushes.Black, 735, yPos)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 10)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    yPos += 20
                    e.Graphics.DrawString("Total De O.Trabajo = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos)

                    e.Graphics.DrawString("Total Dolares US$= " & Format(tot_dol, forma_3), prFont2, Brushes.Black, 430, yPos)
                    e.Graphics.DrawString("Total Soles S/.= " & Format(tot_sol, forma_3), prFont2, Brushes.Black, 630, yPos)

                    'totales de cobros...
                    e.Graphics.DrawString("======================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                    e.HasMorePages = False
                    lineaActual = 0
                    tot_dol = 0
                    tot_sol = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    ' El evento usado mientras se imprime el documento (detalles de cobros)
    Private Sub prt_PrintPage_Ingresos(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODAS" Then
            data = New SqlDataAdapter("select ingresos.*,prove.proveedor,usuarios.tipo as Usuario from ingresos inner join usuarios on usuarios.id_usua=ingresos.usua_1 " & _
                                      "inner join prove on prove.id_prove=ingresos.id_prove where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by ingresos.Fecha_2 ", conex)

        Else

        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "ingresos")

        'Validamos el si existen registros activos...
        With midataset.Tables("ingresos")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Ingresos = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)

                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE INGRESOS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Ingreso", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("O.Compra", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("Fec.Ingreso", prFont3, Brushes.Black, 105, yPos)
                e.Graphics.DrawString("Proveedor", prFont3, Brushes.Black, 170, yPos)
                e.Graphics.DrawString("Moneda", prFont3, Brushes.Black, 390, yPos)
                e.Graphics.DrawString("Monto", prFont3, Brushes.Black, 440, yPos)
                e.Graphics.DrawString("Usua.Ingreso", prFont3, Brushes.Black, 480, yPos)
                e.Graphics.DrawString("Usua.Modific.", prFont3, Brushes.Black, 550, yPos)
                e.Graphics.DrawString("Nro.Guia", prFont3, Brushes.Black, 620, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 690, yPos)
                e.Graphics.DrawString("Nro.Documento", prFont3, Brushes.Black, 740, yPos)
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("item").ToString, prFont2, Brushes.Black, 10, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_orden").ToString, prFont2, Brushes.Black, 60, yPos - 5)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 100, yPos - 5)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("proveedor").ToString, 36), prFont2, Brushes.Black, 170, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("moneda").ToString, prFont2, Brushes.Black, 390, yPos - 5)
                    e.Graphics.DrawString(Format(Val(.Rows(lineaActual)("monto").ToString), forma_3), prFont2, Brushes.Black, 440, yPos - 5)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("usuario").ToString, 11), prFont2, Brushes.Black, 480, yPos - 5)
                    '==================================================================
                    'Validamos el tipo de moneda...                                   '
                    '==================================================================
                    If UCase(.Rows(lineaActual)("moneda").ToString) = "SOLES" Then
                        tot_sol = tot_sol + Val(.Rows(lineaActual)("monto").ToString)
                    Else
                        tot_dol = tot_dol + Val(.Rows(lineaActual)("monto").ToString)
                    End If
                    '==================================================================
                    '==========Buscamos al usuario de actualizacion=============='
                    data = New SqlDataAdapter("select*from usuarios where id_usua='" & .Rows(lineaActual)("usua_2").ToString & "'", conex)
                    Dim midataset2 As New DataSet
                    data.Fill(midataset2, "usuarios")
                    With midataset2.Tables("usuarios")
                        If .Rows.Count > 0 Then
                            e.Graphics.DrawString(Strings.Left(.Rows(0)("tipo").ToString, 11), prFont2, Brushes.Black, 550, yPos - 5)
                        End If
                    End With
                    '============================================================='
                    e.Graphics.DrawString(.Rows(lineaActual)("n_guia").ToString, prFont2, Brushes.Black, 620, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("docu").ToString, prFont2, Brushes.Black, 690, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_docu").ToString, prFont2, Brushes.Black, 740, yPos - 5)
                    'llenamos segunda linea
                    data = New SqlDataAdapter("select*from d_ingresos where n_ingreso='" & .Rows(lineaActual)("item").ToString & "'", conex)
                    Dim midataset3 As New DataSet
                    data.Fill(midataset3, "d_ingresos")
                    With midataset3.Tables("d_ingresos")
                        e.Graphics.DrawString("Total de Items= " & .Rows.Count, prFont3, Brushes.Black, 50, yPos + 10)
                    End With
                    e.Graphics.DrawString("Obs.:" & StrConv(.Rows(lineaActual)("obs").ToString, VbStrConv.ProperCase), prFont3, Brushes.Black, 170, yPos + 10)
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 15)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, e.MarginBounds.Bottom + 15)
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 35
                    e.Graphics.DrawString("Total Ingresos = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 5)
                    e.Graphics.DrawString("Total US$.= " & Format(tot_dol, forma_3), prFont2, Brushes.Black, 500, yPos + 5)
                    e.Graphics.DrawString("Total S/.= " & Format(tot_sol, forma_3), prFont2, Brushes.Black, 650, yPos + 5)
                    'totales de cobros...
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 15)
                    e.HasMorePages = False
                    lineaActual = 0
                    tot_dol = 0
                    tot_sol = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    ' El evento usado mientras se imprime el documento (detalles de cobros)
    Private Sub prt_PrintPage_Salidas(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            If UCase(cbocriterio2.Text) = "FECHA DE SALIDA" Then
                data = New SqlDataAdapter("select salidas.*,clientes.r_social,usuarios.tipo as Usuario from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            Else
                data = New SqlDataAdapter("select salidas.*,clientes.r_social,usuarios.tipo as Usuario from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_1>='" & fecha1.Text & "' and fecha_1<='" & fecha2.Text & "' order by Salidas.Tipo,Salidas.Fecha_1 ", conex)
            End If
        Else
            If UCase(cbocriterio2.Text) = "FECHA DE SALIDA" Then
                data = New SqlDataAdapter("select salidas.*,clientes.r_social,usuarios.tipo as Usuario from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and salidas.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Salidas.Tipo,Salidas.Fecha_2 ", conex)
            Else
                data = New SqlDataAdapter("select salidas.*,clientes.r_social,usuarios.tipo as Usuario from salidas inner join usuarios on usuarios.id_usua=Salidas.usua_1 " & _
                                      "inner join clientes on clientes.id_clie=Salidas.id_clie where fecha_1>='" & fecha1.Text & "' and fecha_1<='" & fecha2.Text & "' and salidas.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Salidas.Tipo,Salidas.Fecha_1 ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "salidas")

        'Validamos el si existen registros activos...
        With midataset.Tables("salidas")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Salidas = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)
                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE SALIDAS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Salida", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("O.Trabajo", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("N.Presu.", prFont3, Brushes.Black, 100, yPos)
                e.Graphics.DrawString("Fec.Salida", prFont3, Brushes.Black, 145, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 205, yPos)
                e.Graphics.DrawString("Usua.Ingreso", prFont3, Brushes.Black, 450, yPos)
                e.Graphics.DrawString("Usua.Modific.", prFont3, Brushes.Black, 520, yPos)
                e.Graphics.DrawString("Nro.Guia", prFont3, Brushes.Black, 590, yPos)
                e.Graphics.DrawString("Tipo", prFont3, Brushes.Black, 660, yPos)
                e.Graphics.DrawString("Nro.Documento", prFont3, Brushes.Black, 720, yPos)
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("n_salida").ToString, prFont2, Brushes.Black, 10, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_orden").ToString, prFont2, Brushes.Black, 50, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu_2").ToString, prFont2, Brushes.Black, 105, yPos - 5)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 145, yPos - 5)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("r_social").ToString, 36), prFont2, Brushes.Black, 205, yPos - 5)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("usuario").ToString, 11), prFont2, Brushes.Black, 450, yPos - 5)
                    '==========Buscamos al usuario de actualizacion=============='
                    data = New SqlDataAdapter("select*from usuarios where id_usua='" & .Rows(lineaActual)("usua_2").ToString & "'", conex)
                    Dim midataset2 As New DataSet
                    data.Fill(midataset2, "usuarios")
                    With midataset2.Tables("usuarios")
                        If .Rows.Count > 0 Then
                            e.Graphics.DrawString(Strings.Left(.Rows(0)("tipo").ToString, 11), prFont2, Brushes.Black, 520, yPos - 5)
                        End If
                    End With
                    '============================================================='
                    e.Graphics.DrawString(.Rows(lineaActual)("n_guia").ToString, prFont2, Brushes.Black, 590, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("docu").ToString, prFont2, Brushes.Black, 660, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_docu").ToString, prFont2, Brushes.Black, 720, yPos - 5)
                    'llenamos segunda linea
                    data = New SqlDataAdapter("select*from d_salidas where n_salida='" & .Rows(lineaActual)("n_salida").ToString & "'", conex)
                    Dim midataset3 As New DataSet
                    data.Fill(midataset3, "d_salidas")
                    With midataset3.Tables("d_salidas")
                        e.Graphics.DrawString("Total de Items= " & .Rows.Count, prFont3, Brushes.Black, 50, yPos + 10)
                    End With
                    e.Graphics.DrawString("Tipo:" & .Rows(lineaActual)("tipo").ToString, prFont3, Brushes.Black, 145, yPos + 10)
                    e.Graphics.DrawString("Obs.:" & StrConv(.Rows(lineaActual)("obs").ToString, VbStrConv.ProperCase), prFont3, Brushes.Black, 450, yPos + 10)
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 15)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 35
                    e.Graphics.DrawString("Total Salidas = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 5)
                    'totales de cobros...
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 15)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    ' El evento usado mientras se imprime el documento (detalles de cobros)
    Private Sub prt_PrintPage_Devol(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        If UCase(cbocriterio.Text) = "TODOS" Then
            If UCase(cbocriterio2.Text) = "FECHA DE DEVOLUCION" Then
                data = New SqlDataAdapter("select Devol.*,salidas.n_orden,salidas.n_presu_2,salidas.tipo, clientes.r_social,usuarios.tipo as Usuario from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            Else
                data = New SqlDataAdapter("select Devol.*,salidas.n_orden,salidas.n_presu_2,salidas.tipo, clientes.r_social,usuarios.tipo as Usuario from Devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            End If
        Else
            If UCase(cbocriterio2.Text) = "FECHA DE DEVOLUCION" Then
                data = New SqlDataAdapter("select Devol.*,salidas.n_orden,salidas.n_presu_2,salidas.tipo, clientes.r_social,usuarios.tipo as Usuario from devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' and devol.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            Else
                data = New SqlDataAdapter("select Devol.*,salidas.n_orden,salidas.n_presu_2,salidas.tipo, clientes.r_social,usuarios.tipo as Usuario from Devol inner join usuarios on usuarios.id_usua=devol.usua_1 " & _
                                      "inner join Salidas on devol.n_salida=salidas.n_salida inner join clientes on clientes.id_clie=Salidas.id_clie where devol.fecha_2>='" & fecha1.Text & "' and devol.fecha_2<='" & fecha2.Text & "' and devol.usua_1='" & Strings.Right(cbocriterio.Text, 4) & "' order by Devol.Fecha_2,Salidas.Tipo ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "devol")

        'Validamos el si existen registros activos...
        With midataset.Tables("devol")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Devoluciones = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)
                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE DEVOLUCIONES", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Devol.", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Salida", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("O.Trabajo", prFont3, Brushes.Black, 100, yPos)
                e.Graphics.DrawString("N.Presu.", prFont3, Brushes.Black, 150, yPos)
                e.Graphics.DrawString("Fec.Devol", prFont3, Brushes.Black, 190, yPos)
                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 250, yPos)
                e.Graphics.DrawString("Usua.Ingreso", prFont3, Brushes.Black, 500, yPos)
                e.Graphics.DrawString("Usua.Modific.", prFont3, Brushes.Black, 570, yPos)
                e.Graphics.DrawString("Tipo Salida", prFont3, Brushes.Black, 640, yPos)
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("n_devol").ToString, prFont2, Brushes.Black, 10, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_salida").ToString, prFont2, Brushes.Black, 50, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_orden").ToString, prFont2, Brushes.Black, 100, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu_2").ToString, prFont2, Brushes.Black, 150, yPos - 5)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 190, yPos - 5)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("r_social").ToString, 36), prFont2, Brushes.Black, 250, yPos - 5)
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("usuario").ToString, 11), prFont2, Brushes.Black, 500, yPos - 5)
                    '==========Buscamos al usuario de actualizacion=============='
                    data = New SqlDataAdapter("select*from usuarios where id_usua='" & .Rows(lineaActual)("usua_2").ToString & "'", conex)
                    Dim midataset2 As New DataSet
                    data.Fill(midataset2, "usuarios")
                    With midataset2.Tables("usuarios")
                        If .Rows.Count > 0 Then
                            e.Graphics.DrawString(Strings.Left(.Rows(0)("tipo").ToString, 11), prFont2, Brushes.Black, 570, yPos - 5)
                        End If
                    End With
                    '============================================================='
                    e.Graphics.DrawString(.Rows(lineaActual)("tipo").ToString, prFont2, Brushes.Black, 640, yPos - 5)
                    'llenamos segunda linea
                    data = New SqlDataAdapter("select*from d_devol where n_devol='" & .Rows(lineaActual)("n_devol").ToString & "'", conex)
                    Dim midataset3 As New DataSet
                    data.Fill(midataset3, "d_devol")
                    With midataset3.Tables("d_devol")
                        e.Graphics.DrawString("Total de Items= " & .Rows.Count, prFont3, Brushes.Black, 50, yPos + 10)
                    End With
                    e.Graphics.DrawString("Obs.:" & StrConv(.Rows(lineaActual)("obs").ToString, VbStrConv.ProperCase), prFont3, Brushes.Black, 150, yPos + 10)
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 15)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 35
                    e.Graphics.DrawString("Total Devoluciones = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 5)
                    'totales de cobros...
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 15)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    ' El evento usado mientras se imprime la guia de remision()
    Private Sub prt_PrintPage_Guias(ByVal sender As Object, _
                              ByVal e As PrintPageEventArgs)
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'validamos mostrar todas
        If UCase(cbocriterio.Text) = "(TODAS)" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar cerradas
        If UCase(cbocriterio.Text) = "CERRADAS" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.factu>1 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.factu>1 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar las guias pendientes por cerrar
        If UCase(cbocriterio.Text) = "PENDIENTES" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.factu<2 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.factu<2 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar las guias anuladas
        If UCase(cbocriterio.Text) = "ANULADAS" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.anu>0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.*,clientes.r_social,usuarios.tipo as Usuario from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.anu>0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If

        'enviamos informacion al dataset
        data.Fill(midataset, "guias")

        'Validamos el si existen registros activos...
        With midataset.Tables("guias")
            'total de facturas...
            'lineaActual = 0
            lbltot.Text = "Total de Guias = " & .Rows.Count
            If .Rows.Count > 0 Then
                ' Este evento se produce cada vez que se va a imprimir una página
                Dim lineHeight As Single
                Dim yPos As Single = e.MarginBounds.Top
                Dim leftMargin As Single = e.MarginBounds.Left
                Dim printFont As System.Drawing.Font
                prtFont = New System.Drawing.Font("Courier New", 8)
                Dim prFont As New Font("Arial", 8, FontStyle.Bold)
                Dim prFont2 As New Font("Arial", 7, FontStyle.Regular)
                Dim prFont3 As New Font("Arial", 7, FontStyle.Bold)
                Dim prFont4 As New Font("Arial", 12, FontStyle.Bold)
                ' Asignar el tipo de letra
                printFont = prtFont
                lineHeight = 30 ' printFont.GetHeight(e.Graphics)

                Dim fontTitulo As New Font("Arial", 20, FontStyle.Bold)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 10)
                ' imprimimos encabezado titulo + rango de fecha
                e.Graphics.DrawString("REPORTE DE GUIAS", prFont4, Brushes.Black, 10, 20)
                e.Graphics.DrawString("=====================================================", prFont3, Brushes.Black, 10, 40)
                e.Graphics.DrawString(StrConv(FormatDateTime(Today.Date, DateFormat.LongDate), VbStrConv.ProperCase), prFont, Brushes.Black, 630, 30)

                'rango de fecha
                e.Graphics.DrawString("Desde " & fecha1.Text & " Hasta " & fecha2.Text, prFont, Brushes.Black, 10, 60)
                e.Graphics.DrawString("Tipo Busqueda : " & cbocriterio.Text, prFont, Brushes.Black, 10, 80)

                yPos = 100
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos)
                yPos = 110
                e.Graphics.DrawString("Item", prFont3, Brushes.Black, 10, yPos)
                e.Graphics.DrawString("Nro.Guia", prFont3, Brushes.Black, 50, yPos)
                e.Graphics.DrawString("O.Trabajo", prFont3, Brushes.Black, 100, yPos)
                e.Graphics.DrawString("Nro.Presu.", prFont3, Brushes.Black, 155, yPos)
                e.Graphics.DrawString("Fec.Emision", prFont3, Brushes.Black, 200, yPos)

                e.Graphics.DrawString("Cliente", prFont3, Brushes.Black, 270, yPos)
                e.Graphics.DrawString("Usuario", prFont3, Brushes.Black, 520, yPos)
                e.Graphics.DrawString("Estado", prFont3, Brushes.Black, 590, yPos)
                e.Graphics.DrawString("Factura", prFont3, Brushes.Black, 650, yPos)
                e.Graphics.DrawString("================================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 10)
                ' imprimir cada una de las líneas de esta página
                Do
                    yPos += lineHeight
                    e.Graphics.DrawString(.Rows(lineaActual)("item").ToString, prFont2, Brushes.Black, 10, yPos - 5)
                    e.Graphics.DrawString(Strings.Mid(.Rows(lineaActual)("n_guia").ToString, 2, 3) & "-" & Strings.Right(.Rows(lineaActual)("n_guia").ToString, 6), prFont2, Brushes.Black, 50, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_orden").ToString, prFont2, Brushes.Black, 110, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_presu").ToString, prFont2, Brushes.Black, 155, yPos - 5)
                    e.Graphics.DrawString(FormatDateTime(.Rows(lineaActual)("fecha_2").ToString, DateFormat.ShortDate), prFont2, Brushes.Black, 200, yPos - 5)
                    'validamos si hay espacios nulos o vacios en fecha de cancelacion
                    e.Graphics.DrawString(Strings.Left(.Rows(lineaActual)("r_social").ToString, 40), prFont2, Brushes.Black, 260, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("usuario").ToString, prFont2, Brushes.Black, 520, yPos - 5)
                    e.Graphics.DrawString(.Rows(lineaActual)("n_factura").ToString, prFont2, Brushes.Black, 650, yPos - 5)
                    'validamos estamos estado de la factura...
                    If .Rows(lineaActual)("anu").ToString = 0 Then
                        If .Rows(lineaActual)("factu").ToString = 0 Then
                            e.Graphics.DrawString("PENDIENTE", prFont2, Brushes.Black, 590, yPos - 5)
                        Else
                            e.Graphics.DrawString("APROBADO", prFont2, Brushes.Black, 590, yPos - 5)
                        End If
                    Else
                        e.Graphics.DrawString("ANULADO", prFont2, Brushes.Black, 590, yPos - 5)
                    End If

                    e.Graphics.DrawString("Chofer: " & .Rows(lineaActual)("chofer").ToString, prFont3, Brushes.Black, 50, yPos + 10)
                    e.Graphics.DrawString("Vehiculo:" & .Rows(lineaActual)("carro").ToString, prFont3, Brushes.Black, 260, yPos + 10)
                    e.Graphics.DrawString("Placa:" & StrConv(.Rows(lineaActual)("id_carro").ToString, VbStrConv.Uppercase), prFont3, Brushes.Black, 520, yPos + 10)
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", prFont3, Brushes.Black, 10, yPos + 15)
                    lineaActual += 1
                Loop Until yPos >= e.MarginBounds.Bottom _
                           OrElse lineaActual > .Rows.Count - 1
                If lineaActual <= .Rows.Count - 1 Then
                    e.HasMorePages = True
                Else
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 30)
                    yPos += 35
                    e.Graphics.DrawString("Total Guias = " & .Rows.Count, prFont2, Brushes.Black, 10, yPos + 5)
                    'totales de cobros...
                    e.Graphics.DrawString("==========================================================================================================================================", prFont3, Brushes.Black, 10, yPos + 15)
                    e.HasMorePages = False
                    lineaActual = 0
                End If
            Else
                MsgBox("No Existen registros que mostrar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    Function Exportar_Guias()
        Dim conex As New SqlConnection(CN)
        Dim data As New SqlDataAdapter
        Dim midataset As New DataSet
        'validamos mostrar todas
        If UCase(cbocriterio.Text) = "(TODAS)" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar cerradas
        If UCase(cbocriterio.Text) = "CERRADAS" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.factu>1 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.factu>1 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar las guias pendientes por cerrar
        If UCase(cbocriterio.Text) = "PENDIENTES" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.factu<2 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.factu<2 and Guias.anu=0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'validamos mostrar las guias anuladas
        If UCase(cbocriterio.Text) = "ANULADAS" Then
            If UCase(cbocriterio2.Text) = "(TODAS)" Then
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and Guias.anu>0 order by guias.fecha_2,guias.n_guia ", conex)
            Else
                data = New SqlDataAdapter("select guias.Item,guias.N_guia,guias.N_orden,guias.N_Presu,clientes.r_social,usuarios.tipo as Usuario ,guias.N_Factura,guias.Carro,guias.id_carro as Placa,guias.Chofer,guias.factu as Estado,guias.anu as Anulado,guias.Fecha_2  from guias inner join usuarios on usuarios.id_usua=guias.id_usua " & _
                                      "inner join clientes on clientes.id_clie=guias.id_clie where fecha_2>='" & fecha1.Text & "' and fecha_2<='" & fecha2.Text & "' and guias.id_usua='" & Strings.Right(cbocriterio2.Text, 4) & "' and Guias.anu>0 order by guias.fecha_2,guias.n_guia ", conex)
            End If
        End If
        'enviamos informacion al dataset
        data.Fill(midataset, "guias")
        'Validamos el si existen registros activos...
        With midataset.Tables("guias")
            lbltot.Text = "Total de Guias = " & .Rows.Count
            If .Rows.Count > 0 Then

                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exapp As New Microsoft.Office.Interop.Excel.Application
                Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'exportarmos el encabezados de la programacion

                    For I = 0 To NCol - 1
                        exHoja.Cells.Item(1, I + 1) = .Columns(I).ColumnName ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    Next
                    pro01.Value = 0
                    pro01.Maximum = NCol - 1
                    Dim filas As Integer
                    For Col As Integer = 0 To NCol - 1
                        'exportamos detalles del listview...
                        For Fila As Integer = 1 To NRow
                            If Col = 11 Then 'validamos el tipo de moneda...
                                If Val(.Rows(Fila - 1)(Col).ToString) = 0 Then
                                    exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                                    exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                                    exHoja.Cells.Item(Fila + 1, Col + 1) = "NO" ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                                Else
                                    exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                                    exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                                    exHoja.Cells.Item(Fila + 1, Col + 1) = "SI" ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                                End If
                            Else
                                exHoja.Cells(Fila + 1, Col + 1).Font.Bold = False
                                exHoja.Cells(Fila + 1, Col + 1).Font.Colorindex = 1
                                exHoja.Cells.Item(Fila + 1, Col + 1) = .Rows(Fila - 1)(Col).ToString ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                            End If
                            filas = Fila
                        Next
                        pro01.Value = Col
                    Next
                    ' ElGrid.Items(Fila - 1).SubItems(Col).Text
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Range("A1:M" & NRow + 1).Select()

                    exHoja.Application.Selection.borders(1).linestyle = 1
                    exHoja.Application.Selection.borders(2).linestyle = 1
                    exHoja.Application.Selection.borders(3).linestyle = 1
                    exHoja.Application.Selection.borders(4).linestyle = 1


                    exHoja.Cells.Font.Size = 8
                    exHoja.Cells.Font.Bold = False
                    exHoja.Range("A1:M1").Font.Bold = True
                    'linea de division invisible
                    exHoja.Application.ActiveWindow.DisplayGridlines = False

                    exHoja.Application.ActiveWorkbook.SaveAs(Filename:= _
                    txtruta.Text)

                    exapp.Application.Visible = False
                    exHoja.Application.ActiveWindow.Close()

                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    MsgBox("Los registros se exportaron correctamente", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                End Try

                Return True
            End If
        End With
    End Function

    Private Sub cbocriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocriterio.SelectedIndexChanged
        If UCase(lbltipo.Text) = "EXPORTAR VISITAS" Then
            Dim tipo As String

            If UCase(cbocriterio.Text) = "(TODOS)" Then tipo = " "
            If UCase(cbocriterio.Text) = "TECNICO" Then tipo = " And T.c_visita_Tpo='TECNICO' "
            If UCase(cbocriterio.Text) = "ADMINISTRATIVO" Then tipo = " And T.c_visita_Tpo='ADMINISTRATIVO' "
            Dim sql As String = "select Id_traba, nombres + ' ' + apellidos + ' ' + ape_materno as empleado From Traba as T where T.Estado='ACTIVO' And Sexo='MASCULINO' And c_visita=1 " & _
            tipo & " order by nombres,apellidos,ape_materno "
            Dim midataset As New DataSet
            Call Conectarse_Tabla(sql, midataset, "Ingenieros")
            With midataset.Tables("Ingenieros")
                cbocriterio2.Items.Clear()
                cbocriterio2.Items.Add("(Todos)")
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        cbocriterio2.Items.Add(.Rows(i)("empleado").ToString & " / " & .Rows(i)("id_traba"))
                    Next
                    cbocriterio2.SelectedIndex = 0
                End If
            End With
        End If
    End Sub

    Private Sub FrmFechas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class