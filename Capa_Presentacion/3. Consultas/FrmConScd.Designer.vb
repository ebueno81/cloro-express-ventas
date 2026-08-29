<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConScd
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtCod_Cd = New System.Windows.Forms.TextBox()
        Me.TxtCod_Tg = New System.Windows.Forms.TextBox()
        Me.TxtVar = New System.Windows.Forms.TextBox()
        Me.TxtBus_Art = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCod_Cd
        '
        Me.TxtCod_Cd.Location = New System.Drawing.Point(384, 194)
        Me.TxtCod_Cd.Name = "TxtCod_Cd"
        Me.TxtCod_Cd.Size = New System.Drawing.Size(43, 20)
        Me.TxtCod_Cd.TabIndex = 216
        Me.TxtCod_Cd.Visible = False
        '
        'TxtCod_Tg
        '
        Me.TxtCod_Tg.Location = New System.Drawing.Point(384, 173)
        Me.TxtCod_Tg.Name = "TxtCod_Tg"
        Me.TxtCod_Tg.Size = New System.Drawing.Size(43, 20)
        Me.TxtCod_Tg.TabIndex = 215
        Me.TxtCod_Tg.Visible = False
        '
        'TxtVar
        '
        Me.TxtVar.Enabled = False
        Me.TxtVar.Location = New System.Drawing.Point(384, 211)
        Me.TxtVar.Name = "TxtVar"
        Me.TxtVar.Size = New System.Drawing.Size(43, 20)
        Me.TxtVar.TabIndex = 214
        Me.TxtVar.Visible = False
        '
        'TxtBus_Art
        '
        Me.TxtBus_Art.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBus_Art.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBus_Art.Location = New System.Drawing.Point(71, 0)
        Me.TxtBus_Art.Name = "TxtBus_Art"
        Me.TxtBus_Art.Size = New System.Drawing.Size(531, 20)
        Me.TxtBus_Art.TabIndex = 211
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Maroon
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, -1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 22)
        Me.Label17.TabIndex = 213
        Me.Label17.Text = "Sub Caidas"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
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
        Me.Dgv01.Location = New System.Drawing.Point(1, 21)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(601, 236)
        Me.Dgv01.TabIndex = 212
        '
        'FrmConScd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 257)
        Me.Controls.Add(Me.TxtCod_Cd)
        Me.Controls.Add(Me.TxtCod_Tg)
        Me.Controls.Add(Me.TxtVar)
        Me.Controls.Add(Me.TxtBus_Art)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Dgv01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmConScd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de SubCaídas"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtCod_Cd As TextBox
    Friend WithEvents TxtCod_Tg As TextBox
    Friend WithEvents TxtVar As TextBox
    Friend WithEvents TxtBus_Art As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Dgv01 As DataGridView
End Class
