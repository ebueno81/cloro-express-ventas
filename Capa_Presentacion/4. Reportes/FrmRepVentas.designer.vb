<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepVentas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DtpFec_Fin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFec_Ini = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.TxtCod_Mon = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnVista = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Lsb01 = New System.Windows.Forms.CheckedListBox()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Rdb01 = New System.Windows.Forms.RadioButton()
        Me.Rdb02 = New System.Windows.Forms.RadioButton()
        Me.Rdb03 = New System.Windows.Forms.RadioButton()
        Me.TxtVar = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnConClie = New System.Windows.Forms.Button()
        Me.TxtClie = New System.Windows.Forms.TextBox()
        Me.TxtCod_Clie = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Pan02.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DtpFec_Fin)
        Me.Panel1.Controls.Add(Me.DtpFec_Ini)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(254, 32)
        Me.Panel1.TabIndex = 0
        '
        'DtpFec_Fin
        '
        Me.DtpFec_Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Fin.Location = New System.Drawing.Point(155, 4)
        Me.DtpFec_Fin.Name = "DtpFec_Fin"
        Me.DtpFec_Fin.Size = New System.Drawing.Size(94, 22)
        Me.DtpFec_Fin.TabIndex = 3
        '
        'DtpFec_Ini
        '
        Me.DtpFec_Ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Ini.Location = New System.Drawing.Point(35, 4)
        Me.DtpFec_Ini.Name = "DtpFec_Ini"
        Me.DtpFec_Ini.Size = New System.Drawing.Size(94, 22)
        Me.DtpFec_Ini.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(132, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Del"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CboMon)
        Me.Panel2.Controls.Add(Me.TxtCod_Mon)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(256, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 32)
        Me.Panel2.TabIndex = 1
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Items.AddRange(New Object() {"S/.", "$."})
        Me.CboMon.Location = New System.Drawing.Point(152, 4)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(50, 22)
        Me.CboMon.TabIndex = 4
        '
        'TxtCod_Mon
        '
        Me.TxtCod_Mon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Mon.Enabled = False
        Me.TxtCod_Mon.Location = New System.Drawing.Point(120, 4)
        Me.TxtCod_Mon.Name = "TxtCod_Mon"
        Me.TxtCod_Mon.Size = New System.Drawing.Size(32, 22)
        Me.TxtCod_Mon.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(109, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(4, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tipo de Moneda"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnVista)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.BtnExcel)
        Me.Panel3.Controls.Add(Me.BtnExportar)
        Me.Panel3.Location = New System.Drawing.Point(1, 197)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(460, 34)
        Me.Panel3.TabIndex = 2
        '
        'BtnVista
        '
        Me.BtnVista.BackColor = System.Drawing.Color.Transparent
        Me.BtnVista.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnVista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVista.Image = CType(resources.GetObject("BtnVista.Image"), System.Drawing.Image)
        Me.BtnVista.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnVista.Location = New System.Drawing.Point(356, 1)
        Me.BtnVista.Name = "BtnVista"
        Me.BtnVista.Size = New System.Drawing.Size(101, 30)
        Me.BtnVista.TabIndex = 4
        Me.BtnVista.Text = "Vista Preliminar"
        Me.BtnVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVista.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnOpen)
        Me.Panel4.Controls.Add(Me.TxtRuta)
        Me.Panel4.Location = New System.Drawing.Point(69, 1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(286, 30)
        Me.Panel4.TabIndex = 3
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(252, 3)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(31, 22)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpen.UseVisualStyleBackColor = False
        '
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Location = New System.Drawing.Point(3, 3)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(249, 22)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\Registro_Ventas.XLSX"
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.Location = New System.Drawing.Point(33, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(34, 30)
        Me.BtnExcel.TabIndex = 2
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.Transparent
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExportar.Image = CType(resources.GetObject("BtnExportar.Image"), System.Drawing.Image)
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(1, 1)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(67, 30)
        Me.BtnExportar.TabIndex = 1
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'Lsb01
        '
        Me.Lsb01.CheckOnClick = True
        Me.Lsb01.FormattingEnabled = True
        Me.Lsb01.Location = New System.Drawing.Point(1, 58)
        Me.Lsb01.Name = "Lsb01"
        Me.Lsb01.Size = New System.Drawing.Size(460, 140)
        Me.Lsb01.TabIndex = 3
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Rdb01)
        Me.Panel10.Controls.Add(Me.Rdb02)
        Me.Panel10.Controls.Add(Me.Rdb03)
        Me.Panel10.Location = New System.Drawing.Point(1, 36)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(460, 21)
        Me.Panel10.TabIndex = 7
        '
        'Rdb01
        '
        Me.Rdb01.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb01.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rdb01.Location = New System.Drawing.Point(287, 1)
        Me.Rdb01.Name = "Rdb01"
        Me.Rdb01.Size = New System.Drawing.Size(170, 18)
        Me.Rdb01.TabIndex = 169
        Me.Rdb01.Text = "Ordenado por Documento"
        Me.Rdb01.UseVisualStyleBackColor = True
        '
        'Rdb02
        '
        Me.Rdb02.Checked = True
        Me.Rdb02.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb02.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rdb02.Location = New System.Drawing.Point(148, 1)
        Me.Rdb02.Name = "Rdb02"
        Me.Rdb02.Size = New System.Drawing.Size(145, 18)
        Me.Rdb02.TabIndex = 168
        Me.Rdb02.TabStop = True
        Me.Rdb02.Text = "Ordenado por Fecha"
        Me.Rdb02.UseVisualStyleBackColor = True
        '
        'Rdb03
        '
        Me.Rdb03.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb03.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rdb03.Location = New System.Drawing.Point(6, 1)
        Me.Rdb03.Name = "Rdb03"
        Me.Rdb03.Size = New System.Drawing.Size(143, 18)
        Me.Rdb03.TabIndex = 167
        Me.Rdb03.Text = "Ordenado por Cliente"
        Me.Rdb03.UseVisualStyleBackColor = True
        '
        'TxtVar
        '
        Me.TxtVar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVar.Enabled = False
        Me.TxtVar.Location = New System.Drawing.Point(409, 158)
        Me.TxtVar.Name = "TxtVar"
        Me.TxtVar.Size = New System.Drawing.Size(32, 22)
        Me.TxtVar.TabIndex = 8
        Me.TxtVar.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BtnConClie)
        Me.Panel5.Controls.Add(Me.TxtClie)
        Me.Panel5.Controls.Add(Me.TxtCod_Clie)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(1, 62)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(460, 26)
        Me.Panel5.TabIndex = 9
        Me.Panel5.Visible = False
        '
        'BtnConClie
        '
        Me.BtnConClie.BackColor = System.Drawing.Color.White
        Me.BtnConClie.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConClie.Image = CType(resources.GetObject("BtnConClie.Image"), System.Drawing.Image)
        Me.BtnConClie.Location = New System.Drawing.Point(425, 1)
        Me.BtnConClie.Name = "BtnConClie"
        Me.BtnConClie.Size = New System.Drawing.Size(32, 22)
        Me.BtnConClie.TabIndex = 6
        Me.BtnConClie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConClie.UseVisualStyleBackColor = False
        '
        'TxtClie
        '
        Me.TxtClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtClie.Enabled = False
        Me.TxtClie.Location = New System.Drawing.Point(130, 1)
        Me.TxtClie.Name = "TxtClie"
        Me.TxtClie.Size = New System.Drawing.Size(294, 22)
        Me.TxtClie.TabIndex = 5
        '
        'TxtCod_Clie
        '
        Me.TxtCod_Clie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Clie.Location = New System.Drawing.Point(59, 1)
        Me.TxtCod_Clie.Name = "TxtCod_Clie"
        Me.TxtCod_Clie.Size = New System.Drawing.Size(70, 22)
        Me.TxtCod_Clie.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(4, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Cliente"
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label6)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(35, 82)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(392, 68)
        Me.Pan02.TabIndex = 226
        Me.Pan02.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(74, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 14)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "Cargando el Archivo..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(6, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(376, 14)
        Me.Label6.TabIndex = 210
        Me.Label6.Text = "Espere unos Instantes mientras el Sistema Procesa la Información..."
        '
        'Prb01
        '
        Me.Prb01.Location = New System.Drawing.Point(69, 23)
        Me.Prb01.Name = "Prb01"
        Me.Prb01.Size = New System.Drawing.Size(252, 23)
        Me.Prb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Prb01.TabIndex = 209
        Me.Prb01.Visible = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(3, 130)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.Height = 18
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(452, 67)
        Me.Dgv01.TabIndex = 228
        Me.Dgv01.Visible = False
        '
        'FrmRepVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 232)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TxtVar)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lsb01)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRepVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Ventas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DtpFec_Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFec_Ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtCod_Mon As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Lsb01 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CboMon As System.Windows.Forms.ComboBox
    Friend WithEvents BtnVista As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Rdb03 As System.Windows.Forms.RadioButton
    Friend WithEvents TxtVar As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BtnConClie As System.Windows.Forms.Button
    Friend WithEvents TxtClie As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Clie As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Rdb01 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb02 As System.Windows.Forms.RadioButton
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
End Class
