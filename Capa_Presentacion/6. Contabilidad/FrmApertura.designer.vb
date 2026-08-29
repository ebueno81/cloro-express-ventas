<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmApertura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmApertura))
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LnkListado = New System.Windows.Forms.LinkLabel()
        Me.LnkHistorial = New System.Windows.Forms.LinkLabel()
        Me.BtnEstado = New System.Windows.Forms.Button()
        Me.Pan06 = New System.Windows.Forms.Panel()
        Me.TxtBus_Lote = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Grb01 = New System.Windows.Forms.GroupBox()
        Me.ChkStatus = New System.Windows.Forms.CheckBox()
        Me.CboBco = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.CboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtCod_Clie = New System.Windows.Forms.TextBox()
        Me.BtnCon1 = New System.Windows.Forms.Button()
        Me.TxtClie = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Pan07 = New System.Windows.Forms.Panel()
        Me.TxtUsua_2 = New System.Windows.Forms.TextBox()
        Me.TxtFecha_Modi = New System.Windows.Forms.TextBox()
        Me.TxtFecha_Crea = New System.Windows.Forms.TextBox()
        Me.TxtUsua_1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtImp_Doc = New System.Windows.Forms.TextBox()
        Me.DtpFec_Emi = New System.Windows.Forms.DateTimePicker()
        Me.TxtNro_Doc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.TxtNro_Serie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CboTpoDoc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNro_Apertura = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Pan04 = New System.Windows.Forms.Panel()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan05 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.ChkRetencion = New System.Windows.Forms.CheckBox()
        Me.Pan01.SuspendLayout()
        Me.Pan06.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Grb01.SuspendLayout()
        Me.Pan07.SuspendLayout()
        Me.Pan04.SuspendLayout()
        Me.Pan05.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.LinkLabel1)
        Me.Pan01.Controls.Add(Me.LnkListado)
        Me.Pan01.Controls.Add(Me.LnkHistorial)
        Me.Pan01.Controls.Add(Me.BtnEstado)
        Me.Pan01.Controls.Add(Me.Pan06)
        Me.Pan01.Controls.Add(Me.Label5)
        Me.Pan01.Location = New System.Drawing.Point(2, 1)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(591, 57)
        Me.Pan01.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(44, 39)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(120, 14)
        Me.LinkLabel1.TabIndex = 197
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Documentos Anexos"
        '
        'LnkListado
        '
        Me.LnkListado.AutoSize = True
        Me.LnkListado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkListado.Location = New System.Drawing.Point(20, 21)
        Me.LnkListado.Name = "LnkListado"
        Me.LnkListado.Size = New System.Drawing.Size(136, 14)
        Me.LnkListado.TabIndex = 196
        Me.LnkListado.TabStop = True
        Me.LnkListado.Text = "Listado de Documentos"
        '
        'LnkHistorial
        '
        Me.LnkHistorial.AutoSize = True
        Me.LnkHistorial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkHistorial.Location = New System.Drawing.Point(449, 27)
        Me.LnkHistorial.Name = "LnkHistorial"
        Me.LnkHistorial.Size = New System.Drawing.Size(133, 14)
        Me.LnkHistorial.TabIndex = 195
        Me.LnkHistorial.TabStop = True
        Me.LnkHistorial.Text = "Historial de Cancelación"
        '
        'BtnEstado
        '
        Me.BtnEstado.BackColor = System.Drawing.Color.Red
        Me.BtnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEstado.ForeColor = System.Drawing.Color.Transparent
        Me.BtnEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEstado.Location = New System.Drawing.Point(452, 2)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(133, 22)
        Me.BtnEstado.TabIndex = 194
        Me.BtnEstado.Text = "ANULADO"
        Me.BtnEstado.UseVisualStyleBackColor = False
        '
        'Pan06
        '
        Me.Pan06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan06.Controls.Add(Me.TxtBus_Lote)
        Me.Pan06.Controls.Add(Me.BtnFin)
        Me.Pan06.Controls.Add(Me.BtnAva)
        Me.Pan06.Controls.Add(Me.BtnAtr)
        Me.Pan06.Controls.Add(Me.BtnIni)
        Me.Pan06.Location = New System.Drawing.Point(208, 7)
        Me.Pan06.Name = "Pan06"
        Me.Pan06.Size = New System.Drawing.Size(194, 33)
        Me.Pan06.TabIndex = 191
        '
        'TxtBus_Lote
        '
        Me.TxtBus_Lote.BackColor = System.Drawing.Color.White
        Me.TxtBus_Lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBus_Lote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBus_Lote.Location = New System.Drawing.Point(57, 4)
        Me.TxtBus_Lote.Name = "TxtBus_Lote"
        Me.TxtBus_Lote.Size = New System.Drawing.Size(79, 23)
        Me.TxtBus_Lote.TabIndex = 176
        Me.TxtBus_Lote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(162, 4)
        Me.BtnFin.Name = "BtnFin"
        Me.BtnFin.Size = New System.Drawing.Size(25, 23)
        Me.BtnFin.TabIndex = 175
        Me.BtnFin.UseVisualStyleBackColor = False
        '
        'BtnAva
        '
        Me.BtnAva.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAva.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAva.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAva.Image = CType(resources.GetObject("BtnAva.Image"), System.Drawing.Image)
        Me.BtnAva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAva.Location = New System.Drawing.Point(137, 4)
        Me.BtnAva.Name = "BtnAva"
        Me.BtnAva.Size = New System.Drawing.Size(25, 23)
        Me.BtnAva.TabIndex = 174
        Me.BtnAva.UseVisualStyleBackColor = False
        '
        'BtnAtr
        '
        Me.BtnAtr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAtr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAtr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtr.Image = CType(resources.GetObject("BtnAtr.Image"), System.Drawing.Image)
        Me.BtnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAtr.Location = New System.Drawing.Point(31, 4)
        Me.BtnAtr.Name = "BtnAtr"
        Me.BtnAtr.Size = New System.Drawing.Size(25, 23)
        Me.BtnAtr.TabIndex = 173
        Me.BtnAtr.UseVisualStyleBackColor = False
        '
        'BtnIni
        '
        Me.BtnIni.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIni.Image = CType(resources.GetObject("BtnIni.Image"), System.Drawing.Image)
        Me.BtnIni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIni.Location = New System.Drawing.Point(6, 4)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 14)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "Asiento de Apertura"
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.ChkRetencion)
        Me.Pan02.Controls.Add(Me.Grb01)
        Me.Pan02.Controls.Add(Me.TxtCod_Clie)
        Me.Pan02.Controls.Add(Me.BtnCon1)
        Me.Pan02.Controls.Add(Me.TxtClie)
        Me.Pan02.Controls.Add(Me.Label7)
        Me.Pan02.Controls.Add(Me.Label1)
        Me.Pan02.Controls.Add(Me.Label3)
        Me.Pan02.Controls.Add(Me.Pan07)
        Me.Pan02.Controls.Add(Me.TxtImp_Doc)
        Me.Pan02.Controls.Add(Me.DtpFec_Emi)
        Me.Pan02.Controls.Add(Me.TxtNro_Doc)
        Me.Pan02.Controls.Add(Me.Label10)
        Me.Pan02.Controls.Add(Me.CboMon)
        Me.Pan02.Controls.Add(Me.TxtNro_Serie)
        Me.Pan02.Controls.Add(Me.Label4)
        Me.Pan02.Controls.Add(Me.CboTpoDoc)
        Me.Pan02.Controls.Add(Me.Label2)
        Me.Pan02.Controls.Add(Me.TxtNro_Apertura)
        Me.Pan02.Controls.Add(Me.Label11)
        Me.Pan02.Location = New System.Drawing.Point(2, 61)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(591, 260)
        Me.Pan02.TabIndex = 2
        '
        'Grb01
        '
        Me.Grb01.Controls.Add(Me.ChkStatus)
        Me.Grb01.Controls.Add(Me.CboBco)
        Me.Grb01.Controls.Add(Me.Label40)
        Me.Grb01.Controls.Add(Me.CboStatus)
        Me.Grb01.Controls.Add(Me.Label8)
        Me.Grb01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grb01.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grb01.Location = New System.Drawing.Point(49, 130)
        Me.Grb01.Name = "Grb01"
        Me.Grb01.Size = New System.Drawing.Size(482, 74)
        Me.Grb01.TabIndex = 10
        Me.Grb01.TabStop = False
        Me.Grb01.Text = "Mantenimiento de Letras"
        '
        'ChkStatus
        '
        Me.ChkStatus.AutoSize = True
        Me.ChkStatus.Location = New System.Drawing.Point(259, 44)
        Me.ChkStatus.Name = "ChkStatus"
        Me.ChkStatus.Size = New System.Drawing.Size(161, 17)
        Me.ChkStatus.TabIndex = 209
        Me.ChkStatus.Text = "Cancelada por el Cliente"
        Me.ChkStatus.UseVisualStyleBackColor = True
        '
        'CboBco
        '
        Me.CboBco.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboBco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboBco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboBco.FormattingEnabled = True
        Me.CboBco.Location = New System.Drawing.Point(115, 16)
        Me.CboBco.Name = "CboBco"
        Me.CboBco.Size = New System.Drawing.Size(337, 21)
        Me.CboBco.TabIndex = 208
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(10, 17)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 22)
        Me.Label40.TabIndex = 206
        Me.Label40.Text = "Banco"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboStatus
        '
        Me.CboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboStatus.FormattingEnabled = True
        Me.CboStatus.Location = New System.Drawing.Point(115, 40)
        Me.CboStatus.Name = "CboStatus"
        Me.CboStatus.Size = New System.Drawing.Size(134, 21)
        Me.CboStatus.TabIndex = 198
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 22)
        Me.Label8.TabIndex = 197
        Me.Label8.Text = "Status de Letra"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Clie
        '
        Me.TxtCod_Clie.BackColor = System.Drawing.Color.White
        Me.TxtCod_Clie.Enabled = False
        Me.TxtCod_Clie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Clie.Location = New System.Drawing.Point(135, 29)
        Me.TxtCod_Clie.Name = "TxtCod_Clie"
        Me.TxtCod_Clie.Size = New System.Drawing.Size(49, 22)
        Me.TxtCod_Clie.TabIndex = 1
        '
        'BtnCon1
        '
        Me.BtnCon1.Enabled = False
        Me.BtnCon1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon1.Image = CType(resources.GetObject("BtnCon1.Image"), System.Drawing.Image)
        Me.BtnCon1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.Location = New System.Drawing.Point(525, 28)
        Me.BtnCon1.Name = "BtnCon1"
        Me.BtnCon1.Size = New System.Drawing.Size(26, 23)
        Me.BtnCon1.TabIndex = 3
        Me.BtnCon1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.UseVisualStyleBackColor = True
        '
        'TxtClie
        '
        Me.TxtClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClie.Enabled = False
        Me.TxtClie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClie.Location = New System.Drawing.Point(185, 29)
        Me.TxtClie.Name = "TxtClie"
        Me.TxtClie.Size = New System.Drawing.Size(339, 22)
        Me.TxtClie.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(29, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 22)
        Me.Label7.TabIndex = 225
        Me.Label7.Text = "Cliente"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(312, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 22)
        Me.Label1.TabIndex = 224
        Me.Label1.Text = "Fecha Emisión"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(312, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 22)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Moneda"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pan07
        '
        Me.Pan07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan07.Controls.Add(Me.TxtUsua_2)
        Me.Pan07.Controls.Add(Me.TxtFecha_Modi)
        Me.Pan07.Controls.Add(Me.TxtFecha_Crea)
        Me.Pan07.Controls.Add(Me.TxtUsua_1)
        Me.Pan07.Controls.Add(Me.Label13)
        Me.Pan07.Controls.Add(Me.Label14)
        Me.Pan07.Location = New System.Drawing.Point(49, 216)
        Me.Pan07.Name = "Pan07"
        Me.Pan07.Size = New System.Drawing.Size(482, 31)
        Me.Pan07.TabIndex = 10
        '
        'TxtUsua_2
        '
        Me.TxtUsua_2.BackColor = System.Drawing.Color.White
        Me.TxtUsua_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsua_2.Enabled = False
        Me.TxtUsua_2.Location = New System.Drawing.Point(308, 5)
        Me.TxtUsua_2.Name = "TxtUsua_2"
        Me.TxtUsua_2.Size = New System.Drawing.Size(70, 20)
        Me.TxtUsua_2.TabIndex = 43
        '
        'TxtFecha_Modi
        '
        Me.TxtFecha_Modi.BackColor = System.Drawing.Color.White
        Me.TxtFecha_Modi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFecha_Modi.Enabled = False
        Me.TxtFecha_Modi.Location = New System.Drawing.Point(378, 5)
        Me.TxtFecha_Modi.Name = "TxtFecha_Modi"
        Me.TxtFecha_Modi.Size = New System.Drawing.Size(95, 20)
        Me.TxtFecha_Modi.TabIndex = 42
        '
        'TxtFecha_Crea
        '
        Me.TxtFecha_Crea.BackColor = System.Drawing.Color.White
        Me.TxtFecha_Crea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFecha_Crea.Enabled = False
        Me.TxtFecha_Crea.Location = New System.Drawing.Point(142, 4)
        Me.TxtFecha_Crea.Name = "TxtFecha_Crea"
        Me.TxtFecha_Crea.Size = New System.Drawing.Size(95, 20)
        Me.TxtFecha_Crea.TabIndex = 41
        '
        'TxtUsua_1
        '
        Me.TxtUsua_1.BackColor = System.Drawing.Color.White
        Me.TxtUsua_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsua_1.Enabled = False
        Me.TxtUsua_1.Location = New System.Drawing.Point(72, 4)
        Me.TxtUsua_1.Name = "TxtUsua_1"
        Me.TxtUsua_1.Size = New System.Drawing.Size(70, 20)
        Me.TxtUsua_1.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(241, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 20)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Modificado"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(5, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 20)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Grabado"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtImp_Doc
        '
        Me.TxtImp_Doc.BackColor = System.Drawing.Color.White
        Me.TxtImp_Doc.Enabled = False
        Me.TxtImp_Doc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImp_Doc.Location = New System.Drawing.Point(135, 103)
        Me.TxtImp_Doc.Multiline = True
        Me.TxtImp_Doc.Name = "TxtImp_Doc"
        Me.TxtImp_Doc.Size = New System.Drawing.Size(89, 22)
        Me.TxtImp_Doc.TabIndex = 9
        Me.TxtImp_Doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DtpFec_Emi
        '
        Me.DtpFec_Emi.Enabled = False
        Me.DtpFec_Emi.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Emi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Emi.Location = New System.Drawing.Point(416, 78)
        Me.DtpFec_Emi.Name = "DtpFec_Emi"
        Me.DtpFec_Emi.Size = New System.Drawing.Size(135, 23)
        Me.DtpFec_Emi.TabIndex = 8
        '
        'TxtNro_Doc
        '
        Me.TxtNro_Doc.BackColor = System.Drawing.Color.White
        Me.TxtNro_Doc.Enabled = False
        Me.TxtNro_Doc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Doc.Location = New System.Drawing.Point(189, 77)
        Me.TxtNro_Doc.MaxLength = 7
        Me.TxtNro_Doc.Multiline = True
        Me.TxtNro_Doc.Name = "TxtNro_Doc"
        Me.TxtNro_Doc.Size = New System.Drawing.Size(119, 22)
        Me.TxtNro_Doc.TabIndex = 7
        Me.TxtNro_Doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(29, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 22)
        Me.Label10.TabIndex = 217
        Me.Label10.Text = "Importe"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(416, 53)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(44, 21)
        Me.CboMon.TabIndex = 5
        '
        'TxtNro_Serie
        '
        Me.TxtNro_Serie.BackColor = System.Drawing.Color.White
        Me.TxtNro_Serie.Enabled = False
        Me.TxtNro_Serie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Serie.Location = New System.Drawing.Point(135, 77)
        Me.TxtNro_Serie.MaxLength = 3
        Me.TxtNro_Serie.Multiline = True
        Me.TxtNro_Serie.Name = "TxtNro_Serie"
        Me.TxtNro_Serie.Size = New System.Drawing.Size(53, 22)
        Me.TxtNro_Serie.TabIndex = 6
        Me.TxtNro_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(29, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 22)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Nro. Documento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboTpoDoc
        '
        Me.CboTpoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CboTpoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTpoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboTpoDoc.FormattingEnabled = True
        Me.CboTpoDoc.Location = New System.Drawing.Point(135, 53)
        Me.CboTpoDoc.Name = "CboTpoDoc"
        Me.CboTpoDoc.Size = New System.Drawing.Size(173, 21)
        Me.CboTpoDoc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(29, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 22)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "Tpo. Documento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNro_Apertura
        '
        Me.TxtNro_Apertura.BackColor = System.Drawing.Color.White
        Me.TxtNro_Apertura.Enabled = False
        Me.TxtNro_Apertura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Apertura.Location = New System.Drawing.Point(135, 6)
        Me.TxtNro_Apertura.Multiline = True
        Me.TxtNro_Apertura.Name = "TxtNro_Apertura"
        Me.TxtNro_Apertura.Size = New System.Drawing.Size(89, 22)
        Me.TxtNro_Apertura.TabIndex = 0
        Me.TxtNro_Apertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(29, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 22)
        Me.Label11.TabIndex = 203
        Me.Label11.Text = "Nro. Asiento"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pan04
        '
        Me.Pan04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan04.Controls.Add(Me.BtnEditar)
        Me.Pan04.Controls.Add(Me.BtnImprimir)
        Me.Pan04.Controls.Add(Me.BtnNuevo)
        Me.Pan04.Controls.Add(Me.BtnEliminar)
        Me.Pan04.Location = New System.Drawing.Point(2, 326)
        Me.Pan04.Name = "Pan04"
        Me.Pan04.Size = New System.Drawing.Size(267, 49)
        Me.Pan04.TabIndex = 216
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEditar.Location = New System.Drawing.Point(67, 1)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(65, 45)
        Me.BtnEditar.TabIndex = 17
        Me.BtnEditar.Text = "&Editar"
        Me.BtnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImprimir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnImprimir.Location = New System.Drawing.Point(133, 1)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(65, 45)
        Me.BtnImprimir.TabIndex = 2
        Me.BtnImprimir.Text = "&Listado"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.Control
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(1, 1)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(65, 45)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEliminar.Location = New System.Drawing.Point(199, 1)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(65, 45)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Anular"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Pan05
        '
        Me.Pan05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan05.Controls.Add(Me.BtnCerrar)
        Me.Pan05.Controls.Add(Me.BtnGrabar)
        Me.Pan05.Location = New System.Drawing.Point(458, 326)
        Me.Pan05.Name = "Pan05"
        Me.Pan05.Size = New System.Drawing.Size(135, 49)
        Me.Pan05.TabIndex = 280
        '
        'BtnCerrar
        '
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCerrar.Location = New System.Drawing.Point(67, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(65, 45)
        Me.BtnCerrar.TabIndex = 9
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'BtnGrabar
        '
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(65, 45)
        Me.BtnGrabar.TabIndex = 8
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'ChkRetencion
        '
        Me.ChkRetencion.AutoSize = True
        Me.ChkRetencion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRetencion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChkRetencion.Location = New System.Drawing.Point(312, 107)
        Me.ChkRetencion.Name = "ChkRetencion"
        Me.ChkRetencion.Size = New System.Drawing.Size(179, 17)
        Me.ChkRetencion.TabIndex = 210
        Me.ChkRetencion.Text = "Factura Afecto a Retención"
        Me.ChkRetencion.UseVisualStyleBackColor = True
        '
        'FrmApertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 376)
        Me.Controls.Add(Me.Pan05)
        Me.Controls.Add(Me.Pan04)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmApertura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Asiento de Apertura - [Mantenimiento]"
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Pan06.ResumeLayout(False)
        Me.Pan06.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Grb01.ResumeLayout(False)
        Me.Grb01.PerformLayout()
        Me.Pan07.ResumeLayout(False)
        Me.Pan07.PerformLayout()
        Me.Pan04.ResumeLayout(False)
        Me.Pan05.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Pan04 As System.Windows.Forms.Panel
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents TxtNro_Doc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboMon As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNro_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CboTpoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNro_Apertura As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Pan07 As System.Windows.Forms.Panel
    Friend WithEvents TxtImp_Doc As System.Windows.Forms.TextBox
    Friend WithEvents DtpFec_Emi As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtFecha_Modi As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha_Crea As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtUsua_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Pan06 As System.Windows.Forms.Panel
    Friend WithEvents TxtBus_Lote As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents BtnEstado As System.Windows.Forms.Button
    Friend WithEvents Pan05 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnCon1 As System.Windows.Forms.Button
    Friend WithEvents TxtClie As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Clie As System.Windows.Forms.TextBox
    Friend WithEvents LnkHistorial As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkListado As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Grb01 As System.Windows.Forms.GroupBox
    Friend WithEvents CboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents CboBco As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ChkRetencion As System.Windows.Forms.CheckBox
End Class
