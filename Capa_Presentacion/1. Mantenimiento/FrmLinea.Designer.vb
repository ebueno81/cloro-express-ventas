<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLinea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLinea))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnFamilia = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtCta = New System.Windows.Forms.TextBox()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.TxtCod = New System.Windows.Forms.TextBox()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtBus = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.BtnEdi = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnFamilia
        '
        Me.BtnFamilia.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFamilia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFamilia.Image = CType(resources.GetObject("BtnFamilia.Image"), System.Drawing.Image)
        Me.BtnFamilia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFamilia.Location = New System.Drawing.Point(502, 22)
        Me.BtnFamilia.Name = "BtnFamilia"
        Me.BtnFamilia.Size = New System.Drawing.Size(89, 23)
        Me.BtnFamilia.TabIndex = 160
        Me.BtnFamilia.Text = "Familias"
        Me.BtnFamilia.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(424, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(86, 23)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(92, 23)
        Me.BtnGrabar.TabIndex = 2
        Me.BtnGrabar.Text = "&Agregar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Blue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(1, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(597, 21)
        Me.Label22.TabIndex = 165
        Me.Label22.Text = "Mantenimiento Tabla General"
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
        Me.Dgv01.Location = New System.Drawing.Point(1, 72)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(597, 306)
        Me.Dgv01.TabIndex = 0
        '
        'TxtCta
        '
        Me.TxtCta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCta.Location = New System.Drawing.Point(114, 73)
        Me.TxtCta.Name = "TxtCta"
        Me.TxtCta.Size = New System.Drawing.Size(99, 21)
        Me.TxtCta.TabIndex = 2
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(511, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(82, 23)
        Me.BtnCerrar.TabIndex = 5
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'TxtCod
        '
        Me.TxtCod.Enabled = False
        Me.TxtCod.Location = New System.Drawing.Point(114, 21)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.Size = New System.Drawing.Size(44, 21)
        Me.TxtCod.TabIndex = 0
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtCta)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.TxtCod)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.TxtObs)
        Me.Pan01.Controls.Add(Me.TxtDesc)
        Me.Pan01.Controls.Add(Me.Label8)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Location = New System.Drawing.Point(1, 257)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(596, 121)
        Me.Pan01.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cta. Contable"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(32, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 21)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Codigo Linea"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtObs
        '
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Location = New System.Drawing.Point(107, 137)
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(369, 21)
        Me.TxtObs.TabIndex = 7
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(114, 47)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(438, 21)
        Me.TxtDesc.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 137)
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
        Me.Label1.Location = New System.Drawing.Point(32, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Linea"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtBus)
        Me.Panel1.Controls.Add(Me.BtnFin)
        Me.Panel1.Controls.Add(Me.BtnAva)
        Me.Panel1.Controls.Add(Me.BtnAtr)
        Me.Panel1.Controls.Add(Me.BtnIni)
        Me.Panel1.Controls.Add(Me.BtnEdi)
        Me.Panel1.Controls.Add(Me.BtnCerrar)
        Me.Panel1.Controls.Add(Me.BtnEliminar)
        Me.Panel1.Controls.Add(Me.BtnGrabar)
        Me.Panel1.Location = New System.Drawing.Point(1, 379)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 30)
        Me.Panel1.TabIndex = 2
        '
        'TxtBus
        '
        Me.TxtBus.BackColor = System.Drawing.SystemColors.Menu
        Me.TxtBus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBus.Location = New System.Drawing.Point(279, 2)
        Me.TxtBus.Name = "TxtBus"
        Me.TxtBus.Size = New System.Drawing.Size(56, 23)
        Me.TxtBus.TabIndex = 8
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(361, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(336, 2)
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
        Me.BtnAtr.Location = New System.Drawing.Point(253, 2)
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
        Me.BtnIni.Location = New System.Drawing.Point(228, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 6
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'BtnEdi
        '
        Me.BtnEdi.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdi.Image = CType(resources.GetObject("BtnEdi.Image"), System.Drawing.Image)
        Me.BtnEdi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdi.Location = New System.Drawing.Point(94, 2)
        Me.BtnEdi.Name = "BtnEdi"
        Me.BtnEdi.Size = New System.Drawing.Size(88, 23)
        Me.BtnEdi.TabIndex = 3
        Me.BtnEdi.Text = "Editar"
        Me.BtnEdi.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.BtnFamilia)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(598, 51)
        Me.Panel2.TabIndex = 167
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(97, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Selecciona el tipo de Línea y verifica su Familia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Linea de Artículos"
        '
        'FrmLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(600, 410)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan01)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLinea"
        Me.Text = "Lineas"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnFamilia As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCta As System.Windows.Forms.TextBox
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnEdi As System.Windows.Forms.Button
    Friend WithEvents TxtBus As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
End Class
