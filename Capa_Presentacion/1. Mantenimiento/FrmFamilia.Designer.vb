<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFamilia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFamilia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnSFamilia = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.lblcod = New System.Windows.Forms.Label()
        Me.lbllinea = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnEdi = New System.Windows.Forms.Button()
        Me.TxtBus = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtCod = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Pan01.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSFamilia
        '
        Me.BtnSFamilia.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSFamilia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSFamilia.Image = CType(resources.GetObject("BtnSFamilia.Image"), System.Drawing.Image)
        Me.BtnSFamilia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSFamilia.Location = New System.Drawing.Point(524, 48)
        Me.BtnSFamilia.Name = "BtnSFamilia"
        Me.BtnSFamilia.Size = New System.Drawing.Size(94, 23)
        Me.BtnSFamilia.TabIndex = 0
        Me.BtnSFamilia.Text = "Sub Familias"
        Me.BtnSFamilia.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Pcb01)
        Me.Panel2.Controls.Add(Me.lblcod)
        Me.Panel2.Controls.Add(Me.lbllinea)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.BtnSFamilia)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(624, 78)
        Me.Panel2.TabIndex = 11
        '
        'Pcb01
        '
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(7, 5)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(66, 59)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 161
        Me.Pcb01.TabStop = False
        '
        'lblcod
        '
        Me.lblcod.AutoSize = True
        Me.lblcod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcod.ForeColor = System.Drawing.Color.Red
        Me.lblcod.Location = New System.Drawing.Point(415, 27)
        Me.lblcod.Name = "lblcod"
        Me.lblcod.Size = New System.Drawing.Size(50, 14)
        Me.lblcod.TabIndex = 4
        Me.lblcod.Text = "Codigo"
        '
        'lbllinea
        '
        Me.lbllinea.AutoSize = True
        Me.lbllinea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllinea.ForeColor = System.Drawing.Color.Red
        Me.lbllinea.Location = New System.Drawing.Point(185, 49)
        Me.lbllinea.Name = "lbllinea"
        Me.lbllinea.Size = New System.Drawing.Size(105, 14)
        Me.lbllinea.TabIndex = 3
        Me.lbllinea.Text = "Y su Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(86, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 14)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Y su Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(86, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(283, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aqui se crean las Familias para el codigo de la Linea"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tabla Familias"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEdi)
        Me.Panel1.Controls.Add(Me.TxtBus)
        Me.Panel1.Controls.Add(Me.BtnFin)
        Me.Panel1.Controls.Add(Me.BtnAva)
        Me.Panel1.Controls.Add(Me.BtnAtr)
        Me.Panel1.Controls.Add(Me.BtnIni)
        Me.Panel1.Controls.Add(Me.BtnCerrar)
        Me.Panel1.Controls.Add(Me.BtnGrabar)
        Me.Panel1.Controls.Add(Me.BtnEliminar)
        Me.Panel1.Location = New System.Drawing.Point(2, 440)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 30)
        Me.Panel1.TabIndex = 170
        '
        'BtnEdi
        '
        Me.BtnEdi.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdi.Image = CType(resources.GetObject("BtnEdi.Image"), System.Drawing.Image)
        Me.BtnEdi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdi.Location = New System.Drawing.Point(89, 3)
        Me.BtnEdi.Name = "BtnEdi"
        Me.BtnEdi.Size = New System.Drawing.Size(88, 23)
        Me.BtnEdi.TabIndex = 3
        Me.BtnEdi.Text = "Editar"
        Me.BtnEdi.UseVisualStyleBackColor = False
        '
        'TxtBus
        '
        Me.TxtBus.BackColor = System.Drawing.SystemColors.Menu
        Me.TxtBus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBus.Location = New System.Drawing.Point(290, 2)
        Me.TxtBus.Name = "TxtBus"
        Me.TxtBus.Size = New System.Drawing.Size(56, 23)
        Me.TxtBus.TabIndex = 8
        Me.TxtBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(372, 2)
        Me.BtnFin.Name = "BtnFin"
        Me.BtnFin.Size = New System.Drawing.Size(25, 23)
        Me.BtnFin.TabIndex = 10
        Me.BtnFin.UseVisualStyleBackColor = False
        '
        'BtnAva
        '
        Me.BtnAva.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAva.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAva.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAva.Image = CType(resources.GetObject("BtnAva.Image"), System.Drawing.Image)
        Me.BtnAva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAva.Location = New System.Drawing.Point(347, 2)
        Me.BtnAva.Name = "BtnAva"
        Me.BtnAva.Size = New System.Drawing.Size(25, 23)
        Me.BtnAva.TabIndex = 9
        Me.BtnAva.UseVisualStyleBackColor = False
        '
        'BtnAtr
        '
        Me.BtnAtr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAtr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAtr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtr.Image = CType(resources.GetObject("BtnAtr.Image"), System.Drawing.Image)
        Me.BtnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAtr.Location = New System.Drawing.Point(264, 2)
        Me.BtnAtr.Name = "BtnAtr"
        Me.BtnAtr.Size = New System.Drawing.Size(25, 23)
        Me.BtnAtr.TabIndex = 7
        Me.BtnAtr.UseVisualStyleBackColor = False
        '
        'BtnIni
        '
        Me.BtnIni.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIni.Image = CType(resources.GetObject("BtnIni.Image"), System.Drawing.Image)
        Me.BtnIni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIni.Location = New System.Drawing.Point(239, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 6
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(536, 3)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 5
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 3)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(87, 23)
        Me.BtnGrabar.TabIndex = 2
        Me.BtnGrabar.Text = "&Agregar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(451, 3)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "Anular"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtCod)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.TxtObs)
        Me.Pan01.Controls.Add(Me.TxtDesc)
        Me.Pan01.Controls.Add(Me.Label8)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Location = New System.Drawing.Point(2, 318)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(622, 121)
        Me.Pan01.TabIndex = 1
        '
        'TxtCod
        '
        Me.TxtCod.Enabled = False
        Me.TxtCod.Location = New System.Drawing.Point(113, 33)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.Size = New System.Drawing.Size(44, 20)
        Me.TxtCod.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(31, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 21)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Codigo Familia"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtObs
        '
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Location = New System.Drawing.Point(106, 137)
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(369, 20)
        Me.TxtObs.TabIndex = 7
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(113, 59)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(443, 20)
        Me.TxtDesc.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 21)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Observaciones"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Familia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Blue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(2, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(623, 21)
        Me.Label22.TabIndex = 171
        Me.Label22.Text = "Mantenimiento de Caidas"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 103)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(622, 336)
        Me.Dgv01.TabIndex = 0
        '
        'FrmFamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 472)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Label22)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Familias"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSFamilia As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents lblcod As System.Windows.Forms.Label
    Friend WithEvents lbllinea As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtBus As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEdi As System.Windows.Forms.Button
End Class
