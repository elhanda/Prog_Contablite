<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Annul_Exercice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Annul_Soc = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.Annul_Soc.Controls.Add(Me.Label8)
        Me.Annul_Soc.Enabled = False
        Me.Annul_Soc.Location = New System.Drawing.Point(2, 2)
        Me.Annul_Soc.Name = "Annul_Soc"
        Me.Annul_Soc.Size = New System.Drawing.Size(879, 321)
        Me.Annul_Soc.TabIndex = 7
        Me.Annul_Soc.TabStop = False
        Me.Annul_Soc.Text = "Annulation Exercice"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(418, 69)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(201, 39)
        Me.ComboBox2.TabIndex = 11
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(108, 234)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(247, 60)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Valider"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button7.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(418, 234)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(247, 60)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "Annuler"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(417, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(447, 45)
        Me.TextBox2.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 37)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Code Société :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(54, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(354, 37)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Nom ou Raison Sociale :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Impact", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(855, 34)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Attention  :L'anulation D'une Socéte  supprime toutes les donnéé Compatible"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(54, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 37)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Exercice a anuller"
        '
        'Annul_Exercice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(896, 326)
        Me.Controls.Add(Me.Annul_Soc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Annul_Exercice"
        Me.Text = "Annuler Exercice"
        Me.Annul_Soc.ResumeLayout(False)
        Me.Annul_Soc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Annul_Soc As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents ComboBox2 As ComboBox
End Class
