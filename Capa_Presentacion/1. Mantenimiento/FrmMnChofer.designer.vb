<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnChofer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnChofer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tbc01 = New System.Windows.Forms.TabControl()
        Me.Tab01 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BtnCerrar2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnEstado = New System.Windows.Forms.Button()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Tab02 = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.CboEmpServ = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBrevete = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFecha_Modi = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Modi = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtFecha_Crea = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Crea = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtChofer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtApeChofer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tbc01.SuspendLayout()
        Me.Tab01.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab02.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tbc01
        '
        Me.Tbc01.Controls.Add(Me.Tab01)
        Me.Tbc01.Controls.Add(Me.Tab02)
        Me.Tbc01.Location = New System.Drawing.Point(1, 2)
        Me.Tbc01.Name = "Tbc01"
        Me.Tbc01.SelectedIndex = 0
        Me.Tbc01.Size = New System.Drawing.Size(543, 376)
        Me.Tbc01.TabIndex = 3
        '
        'Tab01
        '
        Me.Tab01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab01.Controls.Add(Me.Panel8)
        Me.Tab01.Controls.Add(Me.Panel10)
        Me.Tab01.Controls.Add(Me.Panel11)
        Me.Tab01.Controls.Add(Me.Panel2)
        Me.Tab01.Controls.Add(Me.Dgv01)
        Me.Tab01.Location = New System.Drawing.Point(4, 22)
        Me.Tab01.Name = "Tab01"
        Me.Tab01.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab01.Size = New System.Drawing.Size(535, 350)
        Me.Tab01.TabIndex = 0
        Me.Tab01.Text = "Listado"
        Me.Tab01.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnNuevo)
        Me.Panel8.Controls.Add(Me.BtnEditar)
        Me.Panel8.Controls.Add(Me.BtnEliminar)
        Me.Panel8.Location = New System.Drawing.Point(2, 317)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(243, 29)
        Me.Panel8.TabIndex = 199
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(78, 23)
        Me.BtnNuevo.TabIndex = 175
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(81, 2)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(79, 23)
        Me.BtnEditar.TabIndex = 177
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(161, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(78, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(251, 317)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(187, 29)
        Me.Panel10.TabIndex = 200
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(52, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(80, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(157, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(132, 2)
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
        Me.BtnAtr.Location = New System.Drawing.Point(27, 2)
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
        Me.BtnIni.Location = New System.Drawing.Point(2, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.BtnCerrar2)
        Me.Panel11.Location = New System.Drawing.Point(441, 317)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(91, 29)
        Me.Panel11.TabIndex = 201
        '
        'BtnCerrar2
        '
        Me.BtnCerrar2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar2.Image = CType(resources.GetObject("BtnCerrar2.Image"), System.Drawing.Image)
        Me.BtnCerrar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar2.Location = New System.Drawing.Point(3, 2)
        Me.BtnCerrar2.Name = "BtnCerrar2"
        Me.BtnCerrar2.Size = New System.Drawing.Size(83, 23)
        Me.BtnCerrar2.TabIndex = 176
        Me.BtnCerrar2.Text = "&Cerrar"
        Me.BtnCerrar2.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnEstado)
        Me.Panel2.Location = New System.Drawing.Point(2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(530, 25)
        Me.Panel2.TabIndex = 197
        '
        'BtnEstado
        '
        Me.BtnEstado.BackColor = System.Drawing.Color.CadetBlue
        Me.BtnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEstado.ForeColor = System.Drawing.Color.White
        Me.BtnEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEstado.Location = New System.Drawing.Point(1, 1)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(526, 21)
        Me.BtnEstado.TabIndex = 192
        Me.BtnEstado.Text = "Choferes"
        Me.BtnEstado.UseVisualStyleBackColor = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Dgv01.Location = New System.Drawing.Point(2, 27)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(529, 289)
        Me.Dgv01.TabIndex = 198
        '
        'Tab02
        '
        Me.Tab02.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Tab02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab02.Controls.Add(Me.Panel7)
        Me.Tab02.Controls.Add(Me.Pan01)
        Me.Tab02.Location = New System.Drawing.Point(4, 22)
        Me.Tab02.Name = "Tab02"
        Me.Tab02.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab02.Size = New System.Drawing.Size(535, 350)
        Me.Tab02.TabIndex = 1
        Me.Tab02.Text = "Actualizar"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnGrabar)
        Me.Panel7.Controls.Add(Me.BtnCancelar)
        Me.Panel7.Location = New System.Drawing.Point(350, 313)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(175, 29)
        Me.Panel7.TabIndex = 4
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 175
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(87, 2)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(84, 23)
        Me.BtnCancelar.TabIndex = 177
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtApeChofer)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.CboEmpServ)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.TxtDni)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Controls.Add(Me.TxtBrevete)
        Me.Pan01.Controls.Add(Me.Label6)
        Me.Pan01.Controls.Add(Me.TxtFecha_Modi)
        Me.Pan01.Controls.Add(Me.TxtUsua_Modi)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.TxtFecha_Crea)
        Me.Pan01.Controls.Add(Me.TxtUsua_Crea)
        Me.Pan01.Controls.Add(Me.Label7)
        Me.Pan01.Controls.Add(Me.TxtChofer)
        Me.Pan01.Controls.Add(Me.Label4)
        Me.Pan01.Location = New System.Drawing.Point(7, 18)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(518, 183)
        Me.Pan01.TabIndex = 1
        '
        'CboEmpServ
        '
        Me.CboEmpServ.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CboEmpServ.Enabled = False
        Me.CboEmpServ.FormattingEnabled = True
        Me.CboEmpServ.Location = New System.Drawing.Point(100, 37)
        Me.CboEmpServ.Name = "CboEmpServ"
        Me.CboEmpServ.Size = New System.Drawing.Size(401, 21)
        Me.CboEmpServ.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Empresa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDni
        '
        Me.TxtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDni.Enabled = False
        Me.TxtDni.Location = New System.Drawing.Point(100, 80)
        Me.TxtDni.MaxLength = 8
        Me.TxtDni.Name = "TxtDni"
        Me.TxtDni.Size = New System.Drawing.Size(84, 20)
        Me.TxtDni.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Dni"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBrevete
        '
        Me.TxtBrevete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBrevete.Enabled = False
        Me.TxtBrevete.Location = New System.Drawing.Point(100, 16)
        Me.TxtBrevete.MaxLength = 9
        Me.TxtBrevete.Name = "TxtBrevete"
        Me.TxtBrevete.Size = New System.Drawing.Size(84, 20)
        Me.TxtBrevete.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Brevete"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFecha_Modi
        '
        Me.TxtFecha_Modi.Enabled = False
        Me.TxtFecha_Modi.Location = New System.Drawing.Point(211, 123)
        Me.TxtFecha_Modi.Name = "TxtFecha_Modi"
        Me.TxtFecha_Modi.Size = New System.Drawing.Size(130, 20)
        Me.TxtFecha_Modi.TabIndex = 8
        '
        'TxtUsua_Modi
        '
        Me.TxtUsua_Modi.Enabled = False
        Me.TxtUsua_Modi.Location = New System.Drawing.Point(100, 123)
        Me.TxtUsua_Modi.Name = "TxtUsua_Modi"
        Me.TxtUsua_Modi.Size = New System.Drawing.Size(111, 20)
        Me.TxtUsua_Modi.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Usuario Modi."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFecha_Crea
        '
        Me.TxtFecha_Crea.Enabled = False
        Me.TxtFecha_Crea.Location = New System.Drawing.Point(211, 102)
        Me.TxtFecha_Crea.Name = "TxtFecha_Crea"
        Me.TxtFecha_Crea.Size = New System.Drawing.Size(130, 20)
        Me.TxtFecha_Crea.TabIndex = 6
        '
        'TxtUsua_Crea
        '
        Me.TxtUsua_Crea.Enabled = False
        Me.TxtUsua_Crea.Location = New System.Drawing.Point(100, 102)
        Me.TxtUsua_Crea.Name = "TxtUsua_Crea"
        Me.TxtUsua_Crea.Size = New System.Drawing.Size(111, 20)
        Me.TxtUsua_Crea.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Usuario Crea."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtChofer
        '
        Me.TxtChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtChofer.Enabled = False
        Me.TxtChofer.Location = New System.Drawing.Point(100, 59)
        Me.TxtChofer.Name = "TxtChofer"
        Me.TxtChofer.Size = New System.Drawing.Size(163, 20)
        Me.TxtChofer.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(13, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombres"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtApeChofer
        '
        Me.TxtApeChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApeChofer.Enabled = False
        Me.TxtApeChofer.Location = New System.Drawing.Point(333, 58)
        Me.TxtApeChofer.Name = "TxtApeChofer"
        Me.TxtApeChofer.Size = New System.Drawing.Size(168, 20)
        Me.TxtApeChofer.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(265, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 19)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Apellidos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMnChofer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 381)
        Me.Controls.Add(Me.Tbc01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnChofer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivo de Choferes"
        Me.Tbc01.ResumeLayout(False)
        Me.Tab01.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab02.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tbc01 As System.Windows.Forms.TabControl
    Friend WithEvents Tab01 As System.Windows.Forms.TabPage
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnEstado As System.Windows.Forms.Button
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Tab02 As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtBrevete As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha_Modi As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Modi As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha_Crea As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Crea As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboEmpServ As System.Windows.Forms.ComboBox
    Friend WithEvents TxtApeChofer As TextBox
    Friend WithEvents Label3 As Label
End Class
