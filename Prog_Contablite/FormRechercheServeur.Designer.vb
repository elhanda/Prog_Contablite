<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRechercheServeur
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
        Me.ComboBoxServeurs = New System.Windows.Forms.ComboBox()
        Me.ComboBoxBases = New System.Windows.Forms.ComboBox()
        Me.ButtonConnecter = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ComboBoxServeurs
        '
        Me.ComboBoxServeurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxServeurs.FormattingEnabled = True
        Me.ComboBoxServeurs.Location = New System.Drawing.Point(21, 75)
        Me.ComboBoxServeurs.Name = "ComboBoxServeurs"
        Me.ComboBoxServeurs.Size = New System.Drawing.Size(961, 32)
        Me.ComboBoxServeurs.TabIndex = 0
        '
        'ComboBoxBases
        '
        Me.ComboBoxBases.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBases.FormattingEnabled = True
        Me.ComboBoxBases.Location = New System.Drawing.Point(21, 125)
        Me.ComboBoxBases.Name = "ComboBoxBases"
        Me.ComboBoxBases.Size = New System.Drawing.Size(961, 32)
        Me.ComboBoxBases.TabIndex = 1
        '
        'ButtonConnecter
        '
        Me.ButtonConnecter.Location = New System.Drawing.Point(296, 243)
        Me.ButtonConnecter.Name = "ButtonConnecter"
        Me.ButtonConnecter.Size = New System.Drawing.Size(183, 59)
        Me.ButtonConnecter.TabIndex = 2
        Me.ButtonConnecter.Text = "Connecter"
        Me.ButtonConnecter.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(539, 243)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 59)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "quitter"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(205, 515)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(690, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "                                                                                 " &
    "                                "
        '
        'FormRechercheServeur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 659)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonConnecter)
        Me.Controls.Add(Me.ComboBoxBases)
        Me.Controls.Add(Me.ComboBoxServeurs)
        Me.Name = "FormRechercheServeur"
        Me.Text = "Recherche Serveurs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxServeurs As ComboBox
    Friend WithEvents ComboBoxBases As ComboBox
    Friend WithEvents ButtonConnecter As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
End Class
