<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaNotaC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaNotaC))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lsb01 = New System.Windows.Forms.ListBox()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TxtTitulo_2 = New System.Windows.Forms.TextBox()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.CboSerie = New System.Windows.Forms.ComboBox()
        Me.TxtTot_03 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTot_04 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFec_Final = New System.Windows.Forms.DateTimePicker()
        Me.TxtTitulo_1 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grb01 = New System.Windows.Forms.GroupBox()
        Me.CboVendedor = New System.Windows.Forms.ComboBox()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Rdb06 = New System.Windows.Forms.RadioButton()
        Me.Rdb05 = New System.Windows.Forms.RadioButton()
        Me.TxtClie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFec_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtConta_1 = New System.Windows.Forms.TextBox()
        Me.TxtConta_2 = New System.Windows.Forms.TextBox()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Grb01.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 22)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lsb01
        '
        Me.Lsb01.FormattingEnabled = True
        Me.Lsb01.ItemHeight = 14
        Me.Lsb01.Items.AddRange(New Object() {"CLIENTE", "FECHA EMISION", "FECHA VCTO.", "MONEDA"})
        Me.Lsb01.Location = New System.Drawing.Point(2, 25)
        Me.Lsb01.Name = "Lsb01"
        Me.Lsb01.Size = New System.Drawing.Size(128, 60)
        Me.Lsb01.TabIndex = 197
        '
        'TxtTitulo_2
        '
        Me.TxtTitulo_2.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_2.Location = New System.Drawing.Point(97, 455)
        Me.TxtTitulo_2.Name = "TxtTitulo_2"
        Me.TxtTitulo_2.ReadOnly = True
        Me.TxtTitulo_2.Size = New System.Drawing.Size(621, 21)
        Me.TxtTitulo_2.TabIndex = 244
        Me.TxtTitulo_2.Text = "TOTAL EN DOLARES AMERICANOS ( $. )"
        Me.TxtTitulo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtFactura
        '
        Me.TxtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactura.Location = New System.Drawing.Point(158, 9)
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(66, 21)
        Me.TxtFactura.TabIndex = 1
        Me.TxtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboSerie
        '
        Me.CboSerie.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSerie.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboSerie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerie.FormattingEnabled = True
        Me.CboSerie.Location = New System.Drawing.Point(100, 8)
        Me.CboSerie.Name = "CboSerie"
        Me.CboSerie.Size = New System.Drawing.Size(57, 22)
        Me.CboSerie.TabIndex = 0
        '
        'TxtTot_03
        '
        Me.TxtTot_03.BackColor = System.Drawing.Color.White
        Me.TxtTot_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_03.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_03.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_03.Location = New System.Drawing.Point(719, 435)
        Me.TxtTot_03.Name = "TxtTot_03"
        Me.TxtTot_03.ReadOnly = True
        Me.TxtTot_03.Size = New System.Drawing.Size(81, 21)
        Me.TxtTot_03.TabIndex = 245
        Me.TxtTot_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(2, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 23)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Agrupar Por"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTot_04
        '
        Me.TxtTot_04.BackColor = System.Drawing.Color.White
        Me.TxtTot_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_04.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_04.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_04.Location = New System.Drawing.Point(719, 455)
        Me.TxtTot_04.Name = "TxtTot_04"
        Me.TxtTot_04.ReadOnly = True
        Me.TxtTot_04.Size = New System.Drawing.Size(81, 21)
        Me.TxtTot_04.TabIndex = 246
        Me.TxtTot_04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Lsb01)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(658, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(134, 88)
        Me.Panel3.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 23)
        Me.Label3.TabIndex = 195
        Me.Label3.Text = "Nota Crédito"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Final
        '
        Me.DtpFec_Final.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Final.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Final.Location = New System.Drawing.Point(382, 9)
        Me.DtpFec_Final.Name = "DtpFec_Final"
        Me.DtpFec_Final.Size = New System.Drawing.Size(98, 22)
        Me.DtpFec_Final.TabIndex = 3
        '
        'TxtTitulo_1
        '
        Me.TxtTitulo_1.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_1.Location = New System.Drawing.Point(97, 435)
        Me.TxtTitulo_1.Name = "TxtTitulo_1"
        Me.TxtTitulo_1.ReadOnly = True
        Me.TxtTitulo_1.Size = New System.Drawing.Size(621, 21)
        Me.TxtTitulo_1.TabIndex = 243
        Me.TxtTitulo_1.Text = "TOTAL EN NUEVOS SOLES ( S/. )"
        Me.TxtTitulo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnCerrar)
        Me.Panel7.Controls.Add(Me.BtnImp)
        Me.Panel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(645, 479)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(159, 29)
        Me.Panel7.TabIndex = 254
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(81, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(74, 22)
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnImp
        '
        Me.BtnImp.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnImp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImp.Location = New System.Drawing.Point(2, 2)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(77, 22)
        Me.BtnImp.TabIndex = 2
        Me.BtnImp.Text = "&Imprimir"
        Me.BtnImp.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Grb01)
        Me.Panel1.Controls.Add(Me.BtnMostrar)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.TxtClie)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtFactura)
        Me.Panel1.Controls.Add(Me.CboSerie)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DtpFec_Final)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpFec_Inicio)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(8, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(647, 88)
        Me.Panel1.TabIndex = 0
        '
        'Grb01
        '
        Me.Grb01.Controls.Add(Me.CboVendedor)
        Me.Grb01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grb01.ForeColor = System.Drawing.Color.Navy
        Me.Grb01.Location = New System.Drawing.Point(486, 1)
        Me.Grb01.Name = "Grb01"
        Me.Grb01.Size = New System.Drawing.Size(156, 54)
        Me.Grb01.TabIndex = 203
        Me.Grb01.TabStop = False
        Me.Grb01.Text = "Vendedor"
        '
        'CboVendedor
        '
        Me.CboVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboVendedor.FormattingEnabled = True
        Me.CboVendedor.Location = New System.Drawing.Point(5, 19)
        Me.CboVendedor.Name = "CboVendedor"
        Me.CboVendedor.Size = New System.Drawing.Size(147, 22)
        Me.CboVendedor.TabIndex = 1
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(567, 57)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(75, 24)
        Me.BtnMostrar.TabIndex = 8
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Rdb06)
        Me.Panel4.Controls.Add(Me.Rdb05)
        Me.Panel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(20, 57)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(206, 23)
        Me.Panel4.TabIndex = 6
        '
        'Rdb06
        '
        Me.Rdb06.AutoSize = True
        Me.Rdb06.ForeColor = System.Drawing.Color.Blue
        Me.Rdb06.Location = New System.Drawing.Point(113, 2)
        Me.Rdb06.Name = "Rdb06"
        Me.Rdb06.Size = New System.Drawing.Size(83, 18)
        Me.Rdb06.TabIndex = 2
        Me.Rdb06.Text = "ANULADAS"
        Me.Rdb06.UseVisualStyleBackColor = True
        '
        'Rdb05
        '
        Me.Rdb05.AutoSize = True
        Me.Rdb05.Checked = True
        Me.Rdb05.ForeColor = System.Drawing.Color.Blue
        Me.Rdb05.Location = New System.Drawing.Point(5, 2)
        Me.Rdb05.Name = "Rdb05"
        Me.Rdb05.Size = New System.Drawing.Size(100, 18)
        Me.Rdb05.TabIndex = 1
        Me.Rdb05.TabStop = True
        Me.Rdb05.Text = "NO ANULADAS"
        Me.Rdb05.UseVisualStyleBackColor = True
        '
        'TxtClie
        '
        Me.TxtClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClie.Location = New System.Drawing.Point(77, 32)
        Me.TxtClie.Name = "TxtClie"
        Me.TxtClie.Size = New System.Drawing.Size(403, 21)
        Me.TxtClie.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(355, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 22)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Al"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Inicio
        '
        Me.DtpFec_Inicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Inicio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Inicio.Location = New System.Drawing.Point(258, 9)
        Me.DtpFec_Inicio.Name = "DtpFec_Inicio"
        Me.DtpFec_Inicio.Size = New System.Drawing.Size(96, 22)
        Me.DtpFec_Inicio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(225, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 22)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Del"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 100)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(804, 334)
        Me.Dgv01.TabIndex = 240
        '
        'TxtConta_1
        '
        Me.TxtConta_1.BackColor = System.Drawing.Color.White
        Me.TxtConta_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_1.Location = New System.Drawing.Point(1, 435)
        Me.TxtConta_1.Name = "TxtConta_1"
        Me.TxtConta_1.ReadOnly = True
        Me.TxtConta_1.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_1.TabIndex = 241
        Me.TxtConta_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_2
        '
        Me.TxtConta_2.BackColor = System.Drawing.Color.White
        Me.TxtConta_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_2.Location = New System.Drawing.Point(1, 455)
        Me.TxtConta_2.Name = "TxtConta_2"
        Me.TxtConta_2.ReadOnly = True
        Me.TxtConta_2.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_2.TabIndex = 242
        Me.TxtConta_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(57, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(86, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.Text = "1/100"
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(429, 479)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(204, 29)
        Me.Panel10.TabIndex = 253
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(169, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(144, 2)
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
        Me.BtnAtr.Location = New System.Drawing.Point(32, 2)
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
        Me.BtnIni.Location = New System.Drawing.Point(7, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.Panel3)
        Me.Pan01.Controls.Add(Me.Panel1)
        Me.Pan01.Location = New System.Drawing.Point(1, 1)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(805, 99)
        Me.Pan01.TabIndex = 239
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BtnExcel)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.BtnExportar)
        Me.Panel5.Location = New System.Drawing.Point(1, 478)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 31)
        Me.Panel5.TabIndex = 255
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.Location = New System.Drawing.Point(321, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(34, 27)
        Me.BtnExcel.TabIndex = 5
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnOpen)
        Me.Panel8.Controls.Add(Me.TxtRuta)
        Me.Panel8.Location = New System.Drawing.Point(1, 1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(286, 27)
        Me.Panel8.TabIndex = 4
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(252, 2)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(31, 22)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpen.UseVisualStyleBackColor = False
        '
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Location = New System.Drawing.Point(3, 2)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(249, 20)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\Listado_NotaCredito.XLS"
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.White
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExportar.Image = CType(resources.GetObject("BtnExportar.Image"), System.Drawing.Image)
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(288, 1)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(68, 27)
        Me.BtnExportar.TabIndex = 6
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label12)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(231, 220)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 256
        Me.Pan02.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(51, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "Cargando el Archivo..."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(6, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(325, 13)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Espere unos Instantes mientras el Sistema Procesa la Información..."
        '
        'Prb01
        '
        Me.Prb01.Location = New System.Drawing.Point(46, 23)
        Me.Prb01.Name = "Prb01"
        Me.Prb01.Size = New System.Drawing.Size(252, 23)
        Me.Prb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Prb01.TabIndex = 209
        Me.Prb01.Visible = False
        '
        'FrmListaNotaC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 509)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TxtTitulo_2)
        Me.Controls.Add(Me.TxtTot_03)
        Me.Controls.Add(Me.TxtTot_04)
        Me.Controls.Add(Me.TxtTitulo_1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.TxtConta_1)
        Me.Controls.Add(Me.TxtConta_2)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Pan01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmListaNotaC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de las Notas de Crédito"
        Me.Panel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Grb01.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Pan01.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lsb01 As System.Windows.Forms.ListBox
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtTitulo_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents CboSerie As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTot_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTot_04 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpFec_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtTitulo_1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Rdb06 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb05 As System.Windows.Forms.RadioButton
    Friend WithEvents TxtClie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFec_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtConta_1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents Grb01 As System.Windows.Forms.GroupBox
    Friend WithEvents CboVendedor As System.Windows.Forms.ComboBox
End Class
