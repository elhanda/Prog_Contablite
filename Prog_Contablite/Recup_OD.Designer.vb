<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Recup_OD
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_An_Actuel = New System.Windows.Forms.Label()
        Me.Label_an_precedent = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label_Lib_Od = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Année en cours :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Année précédente :"
        '
        'Label_An_Actuel
        '
        Me.Label_An_Actuel.AutoSize = True
        Me.Label_An_Actuel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label_An_Actuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_An_Actuel.Font = New System.Drawing.Font("Arial Narrow", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_An_Actuel.Location = New System.Drawing.Point(234, 27)
        Me.Label_An_Actuel.Name = "Label_An_Actuel"
        Me.Label_An_Actuel.Size = New System.Drawing.Size(194, 39)
        Me.Label_An_Actuel.TabIndex = 6
        Me.Label_An_Actuel.Text = "                         "
        '
        'Label_an_precedent
        '
        Me.Label_an_precedent.AutoSize = True
        Me.Label_an_precedent.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label_an_precedent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_an_precedent.Font = New System.Drawing.Font("Arial Narrow", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_an_precedent.Location = New System.Drawing.Point(234, 80)
        Me.Label_an_precedent.Name = "Label_an_precedent"
        Me.Label_an_precedent.Size = New System.Drawing.Size(194, 39)
        Me.Label_an_precedent.TabIndex = 7
        Me.Label_an_precedent.Text = "                         "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(462, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 31)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Journal OD :"
        '
        'Label_Lib_Od
        '
        Me.Label_Lib_Od.AutoSize = True
        Me.Label_Lib_Od.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label_Lib_Od.Font = New System.Drawing.Font("Arial Narrow", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Lib_Od.Location = New System.Drawing.Point(615, 29)
        Me.Label_Lib_Od.Name = "Label_Lib_Od"
        Me.Label_Lib_Od.Size = New System.Drawing.Size(353, 37)
        Me.Label_Lib_Od.TabIndex = 10
        Me.Label_Lib_Od.Text = "                                                "
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 132)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1215, 528)
        Me.DataGridView1.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1088, 25)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(133, 38)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Valider"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1088, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 38)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Retour"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(497, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 39)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "                         "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(723, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(194, 39)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "                         "
        '
        'Recup_OD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(1226, 669)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label_Lib_Od)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label_an_precedent)
        Me.Controls.Add(Me.Label_An_Actuel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Recup_OD"
        Me.Text = "Récupération des Opérations Diverses"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Protected WithEvents Label_An_Actuel As Label
    Protected WithEvents Label_an_precedent As Label
    Friend WithEvents Label4 As Label
    Public WithEvents Label_Lib_Od As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Protected WithEvents Label3 As Label
    Protected WithEvents Label5 As Label
End Class
