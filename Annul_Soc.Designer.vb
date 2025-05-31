<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Annul_Soc = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Annul_Soc.SuspendLayout()
        Me.SuspendLayout()
        '
        'Annul_Soc
        '
        Me.Annul_Soc.BackColor = System.Drawing.SystemColors.Highlight
        Me.Annul_Soc.Controls.Add(Me.ComboBox2)
        Me.Annul_Soc.Controls.Add(Me.Button6)
        Me.Annul_Soc.Controls.Add(Me.Button7)
        Me.Annul_Soc.Controls.Add(Me.TextBox2)
        Me.Annul_Soc.Controls.Add(Me.Label5)
        Me.Annul_Soc.Controls.Add(Me.Label6)
        Me.Annul_Soc.Controls.Add(Me.Label7)
        Me.Annul_Soc.Location = New System.Drawing.Point(-1, 1)
        Me.Annul_Soc.Name = "Annul_Soc"
        Me.Annul_Soc.Size = New System.Drawing.Size(1080, 327)
        Me.Annul_Soc.TabIndex = 6
        Me.Annul_Soc.TabStop = False
        Me.Annul_Soc.Text = "Annulation Société"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Impact", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(139, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(855, 34)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Attention  :L'anulation D'une Socéte  supprime toutes les donnéé Compatible"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(168, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(354, 37)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Nom ou Raison Sociale :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(168, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 37)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Code Société :"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(531, 150)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(447, 45)
        Me.TextBox2.TabIndex = 15
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button7.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(547, 239)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(247, 60)
        Me.Button7.TabIndex = 17
        Me.Button7.Text = "Annuler"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(237, 239)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(247, 60)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "Valider"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(541, 95)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 45)
        Me.ComboBox2.TabIndex = 19
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 326)
        Me.Controls.Add(Me.Annul_Soc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form3"
        Me.Text = "Annulation de société"
        Me.Annul_Soc.ResumeLayout(False)
        Me.Annul_Soc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Annul_Soc As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
