<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModulos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModulos))
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Menu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Formu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Tool = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_anula_reg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtNom_Tool = New System.Windows.Forms.TextBox()
        Me.TxtNom_Formu = New System.Windows.Forms.TextBox()
        Me.TxtNom_Menu = New System.Windows.Forms.TextBox()
        Me.TxtTit_Menu = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Titulo, Me.Nom_Menu, Me.Nom_Formu, Me.Nom_Tool, Me.c_anula_reg})
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(0, 58)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(797, 396)
        Me.Dgv01.TabIndex = 4
        '
        'Codigo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'Titulo
        '
        Me.Titulo.HeaderText = "Nombre del Módulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        Me.Titulo.Width = 180
        '
        'Nom_Menu
        '
        Me.Nom_Menu.HeaderText = "Nombre Menu"
        Me.Nom_Menu.Name = "Nom_Menu"
        Me.Nom_Menu.ReadOnly = True
        Me.Nom_Menu.Width = 180
        '
        'Nom_Formu
        '
        Me.Nom_Formu.HeaderText = "Nombre Formulario"
        Me.Nom_Formu.Name = "Nom_Formu"
        Me.Nom_Formu.ReadOnly = True
        Me.Nom_Formu.Width = 180
        '
        'Nom_Tool
        '
        Me.Nom_Tool.HeaderText = "Nombre Tool"
        Me.Nom_Tool.Name = "Nom_Tool"
        Me.Nom_Tool.ReadOnly = True
        Me.Nom_Tool.Width = 140
        '
        'c_anula_reg
        '
        Me.c_anula_reg.HeaderText = "c_anula_reg"
        Me.c_anula_reg.Name = "c_anula_reg"
        Me.c_anula_reg.ReadOnly = True
        Me.c_anula_reg.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Location = New System.Drawing.Point(0, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(797, 56)
        Me.Panel3.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(107, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Aquí se crean los módulos para el sistema de ventas..."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(66, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 14)
        Me.Label6.TabIndex = 190
        Me.Label6.Text = "Archivo de Módulos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(54, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 182
        Me.PictureBox2.TabStop = False
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtNom_Tool)
        Me.Pan01.Controls.Add(Me.TxtNom_Formu)
        Me.Pan01.Controls.Add(Me.TxtNom_Menu)
        Me.Pan01.Controls.Add(Me.TxtTit_Menu)
        Me.Pan01.Controls.Add(Me.TxtCodigo)
        Me.Pan01.Location = New System.Drawing.Point(0, 58)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(797, 24)
        Me.Pan01.TabIndex = 0
        '
        'TxtNom_Tool
        '
        Me.TxtNom_Tool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNom_Tool.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNom_Tool.Location = New System.Drawing.Point(635, 1)
        Me.TxtNom_Tool.Name = "TxtNom_Tool"
        Me.TxtNom_Tool.Size = New System.Drawing.Size(145, 20)
        Me.TxtNom_Tool.TabIndex = 4
        '
        'TxtNom_Formu
        '
        Me.TxtNom_Formu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNom_Formu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNom_Formu.Location = New System.Drawing.Point(455, 1)
        Me.TxtNom_Formu.Name = "TxtNom_Formu"
        Me.TxtNom_Formu.Size = New System.Drawing.Size(180, 20)
        Me.TxtNom_Formu.TabIndex = 3
        '
        'TxtNom_Menu
        '
        Me.TxtNom_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNom_Menu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNom_Menu.Location = New System.Drawing.Point(275, 1)
        Me.TxtNom_Menu.Name = "TxtNom_Menu"
        Me.TxtNom_Menu.Size = New System.Drawing.Size(180, 20)
        Me.TxtNom_Menu.TabIndex = 2
        '
        'TxtTit_Menu
        '
        Me.TxtTit_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTit_Menu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTit_Menu.Location = New System.Drawing.Point(96, 1)
        Me.TxtTit_Menu.Name = "TxtTit_Menu"
        Me.TxtTit_Menu.Size = New System.Drawing.Size(179, 20)
        Me.TxtTit_Menu.TabIndex = 1
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigo.Location = New System.Drawing.Point(12, 1)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(84, 20)
        Me.TxtCodigo.TabIndex = 0
        Me.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.TxtReg)
        Me.Pan03.Controls.Add(Me.BtnFin)
        Me.Pan03.Controls.Add(Me.BtnAva)
        Me.Pan03.Controls.Add(Me.BtnAtr)
        Me.Pan03.Controls.Add(Me.BtnIni)
        Me.Pan03.Location = New System.Drawing.Point(390, 456)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(223, 29)
        Me.Pan03.TabIndex = 2
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(54, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(112, 23)
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
        Me.BtnFin.Location = New System.Drawing.Point(191, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(166, 2)
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
        Me.BtnAtr.Location = New System.Drawing.Point(28, 2)
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
        Me.BtnIni.Location = New System.Drawing.Point(3, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnNuevo)
        Me.Pan02.Controls.Add(Me.BtnEditar)
        Me.Pan02.Controls.Add(Me.BtnEliminar)
        Me.Pan02.Location = New System.Drawing.Point(0, 456)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(260, 29)
        Me.Pan02.TabIndex = 1
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
        Me.BtnNuevo.Size = New System.Drawing.Size(84, 23)
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
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(172, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.BtnCerrar)
        Me.Panel11.Location = New System.Drawing.Point(709, 456)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(88, 29)
        Me.Panel11.TabIndex = 3
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(2, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(82, 23)
        Me.BtnCerrar.TabIndex = 176
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'FrmModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(798, 488)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmModulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Módulos"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Pan03.ResumeLayout(False)
        Me.Pan03.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents TxtNom_Formu As System.Windows.Forms.TextBox
    Friend WithEvents TxtNom_Menu As System.Windows.Forms.TextBox
    Friend WithEvents TxtTit_Menu As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom_Menu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom_Formu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom_Tool As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_anula_reg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtNom_Tool As System.Windows.Forms.TextBox
End Class
