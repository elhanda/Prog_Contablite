<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Annuler_Exercice
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Annul_Exercice = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Annul_Exercice.SuspendLayout()
        Me.SuspendLayout()
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
        'Annul_Exercice
        '
        Me.Annul_Exercice.BackColor = System.Drawing.SystemColors.Highlight
        Me.Annul_Exercice.Controls.Add(Me.ComboBox1)
        Me.Annul_Exercice.Controls.Add(Me.Label1)
        Me.Annul_Exercice.Controls.Add(Me.ComboBox2)
        Me.Annul_Exercice.Controls.Add(Me.Button6)
        Me.Annul_Exercice.Controls.Add(Me.Button7)
        Me.Annul_Exercice.Controls.Add(Me.TextBox2)
        Me.Annul_Exercice.Controls.Add(Me.Label5)
        Me.Annul_Exercice.Controls.Add(Me.Label6)
        Me.Annul_Exercice.Controls.Add(Me.Label7)
        Me.Annul_Exercice.Location = New System.Drawing.Point(60, 128)
        Me.Annul_Exercice.Name = "Annul_Exercice"
        Me.Annul_Exercice.Size = New System.Drawing.Size(1086, 415)
        Me.Annul_Exercice.TabIndex = 7
        Me.Annul_Exercice.TabStop = False
        Me.Annul_Exercice.Text = "Annulation Société"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(531, 214)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 45)
        Me.ComboBox1.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(214, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 37)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Année de l'exercice :"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(531, 95)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 45)
        Me.ComboBox2.TabIndex = 19
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button6.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(221, 324)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(247, 60)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "Valider"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button7.Font = New System.Drawing.Font("Cambria", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(531, 324)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(247, 60)
        Me.Button7.TabIndex = 17
        Me.Button7.Text = "Annuler"
        Me.Button7.UseVisualStyleBackColor = False
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
        'Annuler_Exercice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1206, 583)
        Me.Controls.Add(Me.Annul_Exercice)
        Me.Name = "Annuler_Exercice"
        Me.Text = " "
        Me.Annul_Exercice.ResumeLayout(False)
        Me.Annul_Exercice.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Annul_Exercice As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
End Class
