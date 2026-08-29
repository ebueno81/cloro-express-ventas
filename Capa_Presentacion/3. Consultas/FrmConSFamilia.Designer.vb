<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConSFamilia
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Txtcod_Linea = New System.Windows.Forms.TextBox()
        Me.TxtVar = New System.Windows.Forms.TextBox()
        Me.TxtBus_Art = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtCod_Familia = New System.Windows.Forms.TextBox()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txtcod_Linea
        '
        Me.Txtcod_Linea.Enabled = False
        Me.Txtcod_Linea.Location = New System.Drawing.Point(358, 206)
        Me.Txtcod_Linea.Name = "Txtcod_Linea"
        Me.Txtcod_Linea.Size = New System.Drawing.Size(43, 20)
        Me.Txtcod_Linea.TabIndex = 210
        Me.Txtcod_Linea.Visible = False
        '
        'TxtVar
        '
        Me.TxtVar.Enabled = False
        Me.TxtVar.Location = New System.Drawing.Point(358, 180)
        Me.TxtVar.Name = "TxtVar"
        Me.TxtVar.Size = New System.Drawing.Size(43, 20)
        Me.TxtVar.TabIndex = 209
        Me.TxtVar.Visible = False
        '
        'TxtBus_Art
        '
        Me.TxtBus_Art.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBus_Art.Location = New System.Drawing.Point(77, 1)
        Me.TxtBus_Art.Name = "TxtBus_Art"
        Me.TxtBus_Art.Size = New System.Drawing.Size(380, 20)
        Me.TxtBus_Art.TabIndex = 206
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 22)
        Me.Label17.TabIndex = 208
        Me.Label17.Text = "Sub-Familia"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 22)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(458, 230)
        Me.Dgv01.TabIndex = 207
        '
        'TxtCod_Familia
        '
        Me.TxtCod_Familia.Enabled = False
        Me.TxtCod_Familia.Location = New System.Drawing.Point(208, 116)
        Me.TxtCod_Familia.Name = "TxtCod_Familia"
        Me.TxtCod_Familia.Size = New System.Drawing.Size(43, 20)
        Me.TxtCod_Familia.TabIndex = 211
        Me.TxtCod_Familia.Visible = False
        '
        'FrmConSFamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 252)
        Me.Controls.Add(Me.TxtCod_Familia)
        Me.Controls.Add(Me.Txtcod_Linea)
        Me.Controls.Add(Me.TxtVar)
        Me.Controls.Add(Me.TxtBus_Art)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Dgv01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConSFamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de SubFamilia"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtcod_Linea As System.Windows.Forms.TextBox
    Friend WithEvents TxtVar As System.Windows.Forms.TextBox
    Friend WithEvents TxtBus_Art As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCod_Familia As System.Windows.Forms.TextBox
End Class
