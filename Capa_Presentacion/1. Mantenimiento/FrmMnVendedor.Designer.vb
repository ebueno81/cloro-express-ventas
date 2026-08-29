<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnVendedor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tbc01 = New System.Windows.Forms.TabControl()
        Me.Tab01 = New System.Windows.Forms.TabPage()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BtnCerrar2 = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.TxtBus = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tab02 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Pan09 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.ChkAfecto = New System.Windows.Forms.CheckBox()
        Me.TxtDis = New System.Windows.Forms.TextBox()
        Me.TxtCod_Vende = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtVende = New System.Windows.Forms.TextBox()
        Me.TxtDir = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtFec_Mod = New System.Windows.Forms.TextBox()
        Me.TxtUsua_2 = New System.Windows.Forms.TextBox()
        Me.TxtFec_Crea = New System.Windows.Forms.TextBox()
        Me.TxtUsua_1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Pan04 = New System.Windows.Forms.Panel()
        Me.TxtMail = New System.Windows.Forms.TextBox()
        Me.TxtCel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtFono = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtDni = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPorc_Comis = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tbc01.SuspendLayout()
        Me.Tab01.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab02.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan09.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Pan04.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tbc01
        '
        Me.Tbc01.Controls.Add(Me.Tab01)
        Me.Tbc01.Controls.Add(Me.Tab02)
        Me.Tbc01.Location = New System.Drawing.Point(1, 2)
        Me.Tbc01.Name = "Tbc01"
        Me.Tbc01.SelectedIndex = 0
        Me.Tbc01.Size = New System.Drawing.Size(599, 330)
        Me.Tbc01.TabIndex = 177
        '
        'Tab01
        '
        Me.Tab01.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Tab01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab01.Controls.Add(Me.Panel11)
        Me.Tab01.Controls.Add(Me.Panel10)
        Me.Tab01.Controls.Add(Me.Panel8)
        Me.Tab01.Controls.Add(Me.Panel7)
        Me.Tab01.Controls.Add(Me.Panel6)
        Me.Tab01.Location = New System.Drawing.Point(4, 22)
        Me.Tab01.Name = "Tab01"
        Me.Tab01.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab01.Size = New System.Drawing.Size(591, 304)
        Me.Tab01.TabIndex = 0
        Me.Tab01.Text = "Listado"
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.BtnCerrar2)
        Me.Panel11.Location = New System.Drawing.Point(492, 269)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(91, 29)
        Me.Panel11.TabIndex = 184
        '
        'BtnCerrar2
        '
        Me.BtnCerrar2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar2.Image = CType(resources.GetObject("BtnCerrar2.Image"), System.Drawing.Image)
        Me.BtnCerrar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar2.Location = New System.Drawing.Point(5, 2)
        Me.BtnCerrar2.Name = "BtnCerrar2"
        Me.BtnCerrar2.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar2.TabIndex = 176
        Me.BtnCerrar2.Text = "&Cerrar"
        Me.BtnCerrar2.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(268, 269)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(222, 29)
        Me.Panel10.TabIndex = 183
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(57, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.Size = New System.Drawing.Size(105, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.Text = "1/100"
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(188, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(163, 2)
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
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnNuevo)
        Me.Panel8.Controls.Add(Me.BtnEditar)
        Me.Panel8.Controls.Add(Me.BtnEliminar)
        Me.Panel8.Location = New System.Drawing.Point(6, 269)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(260, 29)
        Me.Panel8.TabIndex = 181
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(84, 23)
        Me.BtnNuevo.TabIndex = 175
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(87, 2)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEditar.TabIndex = 177
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(172, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.BtnMostrar)
        Me.Panel7.Controls.Add(Me.Pcb01)
        Me.Panel7.Controls.Add(Me.TxtBus)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Location = New System.Drawing.Point(6, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(577, 67)
        Me.Panel7.TabIndex = 180
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(90, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 13)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "Aquí se crean los vendedores de la empresa..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(138, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 14)
        Me.Label9.TabIndex = 187
        Me.Label9.Text = "Buscar vendedor :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(490, 38)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(80, 23)
        Me.BtnMostrar.TabIndex = 186
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'Pcb01
        '
        Me.Pcb01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Pcb01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(9, 4)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(62, 55)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 181
        Me.Pcb01.TabStop = False
        '
        'TxtBus
        '
        Me.TxtBus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBus.Location = New System.Drawing.Point(247, 40)
        Me.TxtBus.Name = "TxtBus"
        Me.TxtBus.Size = New System.Drawing.Size(237, 21)
        Me.TxtBus.TabIndex = 177
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(74, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 14)
        Me.Label15.TabIndex = 178
        Me.Label15.Text = "Maestro de Vendedores"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Dgv01)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Location = New System.Drawing.Point(6, 73)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(577, 195)
        Me.Panel6.TabIndex = 173
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 24)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.Height = 19
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(571, 168)
        Me.Dgv01.TabIndex = 187
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(2, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(572, 21)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Mantenimiento de Vendedor"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tab02
        '
        Me.Tab02.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Tab02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab02.Controls.Add(Me.Panel2)
        Me.Tab02.Controls.Add(Me.Pan09)
        Me.Tab02.Controls.Add(Me.Pan03)
        Me.Tab02.Location = New System.Drawing.Point(4, 22)
        Me.Tab02.Name = "Tab02"
        Me.Tab02.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab02.Size = New System.Drawing.Size(591, 304)
        Me.Tab02.TabIndex = 1
        Me.Tab02.Text = "Actualizar"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(3, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 44)
        Me.Panel2.TabIndex = 181
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(72, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(156, 13)
        Me.Label10.TabIndex = 189
        Me.Label10.Text = "Actualización de Vendedores..."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 181
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(72, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 14)
        Me.Label11.TabIndex = 178
        Me.Label11.Text = "Registro de Vendedores..."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan09
        '
        Me.Pan09.BackColor = System.Drawing.Color.White
        Me.Pan09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan09.Controls.Add(Me.BtnGrabar)
        Me.Pan09.Controls.Add(Me.BtnCerrar)
        Me.Pan09.Location = New System.Drawing.Point(411, 270)
        Me.Pan09.Name = "Pan09"
        Me.Pan09.Size = New System.Drawing.Size(176, 29)
        Me.Pan09.TabIndex = 1
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(4, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(89, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cancelar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'Pan03
        '
        Me.Pan03.BackColor = System.Drawing.SystemColors.Control
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.Pan01)
        Me.Pan03.Controls.Add(Me.Pan02)
        Me.Pan03.Controls.Add(Me.Pan04)
        Me.Pan03.Location = New System.Drawing.Point(3, 53)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(582, 195)
        Me.Pan03.TabIndex = 0
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtPorc_Comis)
        Me.Pan01.Controls.Add(Me.Label12)
        Me.Pan01.Controls.Add(Me.ChkAfecto)
        Me.Pan01.Controls.Add(Me.TxtDis)
        Me.Pan01.Controls.Add(Me.TxtCod_Vende)
        Me.Pan01.Controls.Add(Me.Label20)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.TxtVende)
        Me.Pan01.Controls.Add(Me.TxtDir)
        Me.Pan01.Controls.Add(Me.Label5)
        Me.Pan01.Location = New System.Drawing.Point(1, 1)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(578, 101)
        Me.Pan01.TabIndex = 0
        '
        'ChkAfecto
        '
        Me.ChkAfecto.AutoSize = True
        Me.ChkAfecto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAfecto.ForeColor = System.Drawing.Color.Navy
        Me.ChkAfecto.Location = New System.Drawing.Point(390, 4)
        Me.ChkAfecto.Name = "ChkAfecto"
        Me.ChkAfecto.Size = New System.Drawing.Size(182, 18)
        Me.ChkAfecto.TabIndex = 1
        Me.ChkAfecto.Text = "Vendedor Afecto a Comisión"
        Me.ChkAfecto.UseVisualStyleBackColor = True
        '
        'TxtDis
        '
        Me.TxtDis.BackColor = System.Drawing.Color.White
        Me.TxtDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDis.Enabled = False
        Me.TxtDis.Location = New System.Drawing.Point(75, 70)
        Me.TxtDis.MaxLength = 40
        Me.TxtDis.Name = "TxtDis"
        Me.TxtDis.Size = New System.Drawing.Size(302, 21)
        Me.TxtDis.TabIndex = 4
        '
        'TxtCod_Vende
        '
        Me.TxtCod_Vende.BackColor = System.Drawing.Color.White
        Me.TxtCod_Vende.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Vende.Enabled = False
        Me.TxtCod_Vende.Location = New System.Drawing.Point(75, 4)
        Me.TxtCod_Vende.Name = "TxtCod_Vende"
        Me.TxtCod_Vende.Size = New System.Drawing.Size(56, 21)
        Me.TxtCod_Vende.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(6, 71)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 21)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Distrito"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 21)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Código"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 22)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Vendedor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtVende
        '
        Me.TxtVende.BackColor = System.Drawing.Color.White
        Me.TxtVende.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVende.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVende.Enabled = False
        Me.TxtVende.Location = New System.Drawing.Point(75, 26)
        Me.TxtVende.MaxLength = 80
        Me.TxtVende.Name = "TxtVende"
        Me.TxtVende.Size = New System.Drawing.Size(497, 21)
        Me.TxtVende.TabIndex = 2
        '
        'TxtDir
        '
        Me.TxtDir.BackColor = System.Drawing.Color.White
        Me.TxtDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDir.Enabled = False
        Me.TxtDir.Location = New System.Drawing.Point(75, 48)
        Me.TxtDir.MaxLength = 100
        Me.TxtDir.Name = "TxtDir"
        Me.TxtDir.Size = New System.Drawing.Size(497, 21)
        Me.TxtDir.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 21)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Dirección"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label8)
        Me.Pan02.Controls.Add(Me.TxtFec_Mod)
        Me.Pan02.Controls.Add(Me.TxtUsua_2)
        Me.Pan02.Controls.Add(Me.TxtFec_Crea)
        Me.Pan02.Controls.Add(Me.TxtUsua_1)
        Me.Pan02.Controls.Add(Me.Label7)
        Me.Pan02.Location = New System.Drawing.Point(1, 157)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(578, 31)
        Me.Pan02.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(309, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 21)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Actualiza"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFec_Mod
        '
        Me.TxtFec_Mod.BackColor = System.Drawing.Color.White
        Me.TxtFec_Mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFec_Mod.Enabled = False
        Me.TxtFec_Mod.Location = New System.Drawing.Point(456, 3)
        Me.TxtFec_Mod.Name = "TxtFec_Mod"
        Me.TxtFec_Mod.Size = New System.Drawing.Size(116, 21)
        Me.TxtFec_Mod.TabIndex = 5
        '
        'TxtUsua_2
        '
        Me.TxtUsua_2.BackColor = System.Drawing.Color.White
        Me.TxtUsua_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsua_2.Enabled = False
        Me.TxtUsua_2.Location = New System.Drawing.Point(379, 3)
        Me.TxtUsua_2.Name = "TxtUsua_2"
        Me.TxtUsua_2.Size = New System.Drawing.Size(77, 21)
        Me.TxtUsua_2.TabIndex = 4
        '
        'TxtFec_Crea
        '
        Me.TxtFec_Crea.BackColor = System.Drawing.Color.White
        Me.TxtFec_Crea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFec_Crea.Enabled = False
        Me.TxtFec_Crea.Location = New System.Drawing.Point(150, 3)
        Me.TxtFec_Crea.Name = "TxtFec_Crea"
        Me.TxtFec_Crea.Size = New System.Drawing.Size(155, 21)
        Me.TxtFec_Crea.TabIndex = 3
        '
        'TxtUsua_1
        '
        Me.TxtUsua_1.BackColor = System.Drawing.Color.White
        Me.TxtUsua_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsua_1.Enabled = False
        Me.TxtUsua_1.Location = New System.Drawing.Point(73, 3)
        Me.TxtUsua_1.Name = "TxtUsua_1"
        Me.TxtUsua_1.Size = New System.Drawing.Size(77, 21)
        Me.TxtUsua_1.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 21)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Grabado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan04
        '
        Me.Pan04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan04.Controls.Add(Me.TxtMail)
        Me.Pan04.Controls.Add(Me.TxtCel)
        Me.Pan04.Controls.Add(Me.Label6)
        Me.Pan04.Controls.Add(Me.Label17)
        Me.Pan04.Controls.Add(Me.TxtFono)
        Me.Pan04.Controls.Add(Me.Label16)
        Me.Pan04.Controls.Add(Me.TxtDni)
        Me.Pan04.Controls.Add(Me.Label4)
        Me.Pan04.Location = New System.Drawing.Point(1, 103)
        Me.Pan04.Name = "Pan04"
        Me.Pan04.Size = New System.Drawing.Size(578, 53)
        Me.Pan04.TabIndex = 1
        '
        'TxtMail
        '
        Me.TxtMail.BackColor = System.Drawing.Color.White
        Me.TxtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtMail.Enabled = False
        Me.TxtMail.Location = New System.Drawing.Point(75, 25)
        Me.TxtMail.MaxLength = 50
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(230, 21)
        Me.TxtMail.TabIndex = 2
        '
        'TxtCel
        '
        Me.TxtCel.BackColor = System.Drawing.Color.White
        Me.TxtCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCel.Enabled = False
        Me.TxtCel.Location = New System.Drawing.Point(377, 3)
        Me.TxtCel.MaxLength = 50
        Me.TxtCel.Name = "TxtCel"
        Me.TxtCel.Size = New System.Drawing.Size(195, 21)
        Me.TxtCel.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 21)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Mail"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(308, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 21)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Celular"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFono
        '
        Me.TxtFono.BackColor = System.Drawing.Color.White
        Me.TxtFono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFono.Enabled = False
        Me.TxtFono.Location = New System.Drawing.Point(75, 3)
        Me.TxtFono.MaxLength = 50
        Me.TxtFono.Name = "TxtFono"
        Me.TxtFono.Size = New System.Drawing.Size(230, 21)
        Me.TxtFono.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(6, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 21)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Teléfono"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDni
        '
        Me.TxtDni.BackColor = System.Drawing.Color.White
        Me.TxtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDni.Enabled = False
        Me.TxtDni.Location = New System.Drawing.Point(377, 25)
        Me.TxtDni.MaxLength = 11
        Me.TxtDni.Name = "TxtDni"
        Me.TxtDni.Size = New System.Drawing.Size(86, 21)
        Me.TxtDni.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(308, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 22)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "D.N.I."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPorc_Comis
        '
        Me.TxtPorc_Comis.BackColor = System.Drawing.Color.White
        Me.TxtPorc_Comis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPorc_Comis.Enabled = False
        Me.TxtPorc_Comis.Location = New System.Drawing.Point(486, 70)
        Me.TxtPorc_Comis.MaxLength = 11
        Me.TxtPorc_Comis.Name = "TxtPorc_Comis"
        Me.TxtPorc_Comis.Size = New System.Drawing.Size(86, 21)
        Me.TxtPorc_Comis.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(380, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 22)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "% Comisiones"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMnVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 332)
        Me.Controls.Add(Me.Tbc01)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabla de Vendedores"
        Me.Tbc01.ResumeLayout(False)
        Me.Tab01.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab02.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan09.ResumeLayout(False)
        Me.Pan03.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Pan04.ResumeLayout(False)
        Me.Pan04.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tbc01 As System.Windows.Forms.TabControl
    Friend WithEvents Tab01 As System.Windows.Forms.TabPage
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtBus As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Tab02 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Pan09 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtDis As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Vende As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtVende As System.Windows.Forms.TextBox
    Friend WithEvents TxtDir As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDni As System.Windows.Forms.TextBox
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtFec_Mod As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtFec_Crea As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Pan04 As System.Windows.Forms.Panel
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents TxtCel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtFono As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkAfecto As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPorc_Comis As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
