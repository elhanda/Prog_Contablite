<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transfert
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
        Me.btnImporter = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnImporter
        '
        Me.btnImporter.Location = New System.Drawing.Point(473, 139)
        Me.btnImporter.Name = "btnImporter"
        Me.btnImporter.Size = New System.Drawing.Size(195, 64)
        Me.btnImporter.TabIndex = 0
        Me.btnImporter.Text = "btnImporter"
        Me.btnImporter.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(473, 255)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(195, 64)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Retour"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'transfert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1296, 600)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnImporter)
        Me.Name = "transfert"
        Me.Text = "Form33"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnImporter As Button
    Friend WithEvents Button2 As Button
End Class
