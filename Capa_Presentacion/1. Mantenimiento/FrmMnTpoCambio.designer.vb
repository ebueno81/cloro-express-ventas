<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnTpoCambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnTpoCambio))
        Me.DtpFec_Emi = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv01 = New System.Windows.Forms.DataGridView()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.TxtTpo_Venta = New System.Windows.Forms.TextBox()
        Me.TxtTpo_Compra = New System.Windows.Forms.TextBox()
        Me.BtnInternet = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        CType(Me.dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan03.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtpFec_Emi
        '
        Me.DtpFec_Emi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Emi.Location = New System.Drawing.Point(20, 35)
        Me.DtpFec_Emi.Name = "DtpFec_Emi"
        Me.DtpFec_Emi.Size = New System.Drawing.Size(88, 21)
        Me.DtpFec_Emi.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 31)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "TIPO DE CAMBIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv01
        '
        Me.dgv01.AllowUserToAddRows = False
        Me.dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv01.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv01.EnableHeadersVisualStyles = False
        Me.dgv01.Location = New System.Drawing.Point(1, 33)
        Me.dgv01.Name = "dgv01"
        Me.dgv01.ReadOnly = True
        Me.dgv01.RowHeadersWidth = 18
        Me.dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv01.Size = New System.Drawing.Size(323, 270)
        Me.dgv01.TabIndex = 0
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.BtnEliminar)
        Me.Pan01.Controls.Add(Me.Pcb01)
        Me.Pan01.Controls.Add(Me.dgv01)
        Me.Pan01.Controls.Add(Me.DtpFec_Emi)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Controls.Add(Me.TxtTpo_Venta)
        Me.Pan01.Controls.Add(Me.TxtTpo_Compra)
        Me.Pan01.Controls.Add(Me.BtnInternet)
        Me.Pan01.Location = New System.Drawing.Point(2, 2)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(327, 306)
        Me.Pan01.TabIndex = 3
        '
        'Pcb01
        '
        Me.Pcb01.BackColor = System.Drawing.Color.White
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(1, 0)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(41, 32)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 164
        Me.Pcb01.TabStop = False
        '
        'TxtTpo_Venta
        '
        Me.TxtTpo_Venta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTpo_Venta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTpo_Venta.Location = New System.Drawing.Point(201, 35)
        Me.TxtTpo_Venta.Name = "TxtTpo_Venta"
        Me.TxtTpo_Venta.Size = New System.Drawing.Size(89, 21)
        Me.TxtTpo_Venta.TabIndex = 4
        Me.TxtTpo_Venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTpo_Compra
        '
        Me.TxtTpo_Compra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTpo_Compra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTpo_Compra.Location = New System.Drawing.Point(109, 35)
        Me.TxtTpo_Compra.Name = "TxtTpo_Compra"
        Me.TxtTpo_Compra.Size = New System.Drawing.Size(91, 21)
        Me.TxtTpo_Compra.TabIndex = 3
        Me.TxtTpo_Compra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnInternet
        '
        Me.BtnInternet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnInternet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInternet.Image = CType(resources.GetObject("BtnInternet.Image"), System.Drawing.Image)
        Me.BtnInternet.Location = New System.Drawing.Point(291, 35)
        Me.BtnInternet.Name = "BtnInternet"
        Me.BtnInternet.Size = New System.Drawing.Size(28, 21)
        Me.BtnInternet.TabIndex = 1
        Me.BtnInternet.UseVisualStyleBackColor = True
        '
        'BtnEditar
        '
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(99, 1)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(97, 26)
        Me.BtnEditar.TabIndex = 1
        Me.BtnEditar.Text = "&Editar"
        Me.BtnEditar.UseVisualStyleBackColor = True
        '
        'BtnGrabar
        '
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(97, 26)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "&Agregar"
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(1, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(101, 26)
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnGrabar)
        Me.Pan03.Controls.Add(Me.BtnEditar)
        Me.Pan03.Location = New System.Drawing.Point(1, 309)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(199, 30)
        Me.Pan03.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnCerrar)
        Me.Panel1.Location = New System.Drawing.Point(224, 309)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 30)
        Me.Panel1.TabIndex = 5
        '
        'BtnEliminar
        '
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(223, 274)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(97, 26)
        Me.BtnEliminar.TabIndex = 165
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        Me.BtnEliminar.Visible = False
        '
        'FrmMnTpoCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 340)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Pan01)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrmMnTpoCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Cambio"
        CType(Me.dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan03.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtpFec_Emi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtTpo_Venta As System.Windows.Forms.TextBox
    Friend WithEvents TxtTpo_Compra As System.Windows.Forms.TextBox
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnInternet As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
End Class
