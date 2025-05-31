<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmServeurConfig
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
        Me.Labelrep = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblChaine = New System.Windows.Forms.Label()
        Me.BtnRecup = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.CmbBases = New System.Windows.Forms.ComboBox()
        Me.CmbServeurs = New System.Windows.Forms.ComboBox()
        Me.chkAuthSQL = New System.Windows.Forms.CheckBox()
        Me.BtnValider = New System.Windows.Forms.Button()
        Me.btnEditServeurs = New System.Windows.Forms.Button()
        Me.BtnVoirConnexion = New System.Windows.Forms.Button()
        Me.BtnTester = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Labelrep
        '
        Me.Labelrep.AutoSize = True
        Me.Labelrep.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Labelrep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelrep.Location = New System.Drawing.Point(333, 520)
        Me.Labelrep.Name = "Labelrep"
        Me.Labelrep.Size = New System.Drawing.Size(676, 24)
        Me.Labelrep.TabIndex = 29
        Me.Labelrep.Text = "                                                                                 " &
    "                              "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(878, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 53)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Recuperer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(453, 544)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(219, 24)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Chaine de Connection"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(186, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 24)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Mot de Passe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(226, 299)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Utilsateur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(122, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 24)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Bases des  données"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 24)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Connexions Existantes"
        '
        'LblChaine
        '
        Me.LblChaine.AllowDrop = True
        Me.LblChaine.AutoEllipsis = True
        Me.LblChaine.AutoSize = True
        Me.LblChaine.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LblChaine.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChaine.Location = New System.Drawing.Point(68, 593)
        Me.LblChaine.Name = "LblChaine"
        Me.LblChaine.Size = New System.Drawing.Size(992, 25)
        Me.LblChaine.TabIndex = 22
        Me.LblChaine.Text = "                                                                                 " &
    "                                                           "
        '
        'BtnRecup
        '
        Me.BtnRecup.Location = New System.Drawing.Point(666, 432)
        Me.BtnRecup.Name = "BtnRecup"
        Me.BtnRecup.Size = New System.Drawing.Size(182, 53)
        Me.BtnRecup.TabIndex = 21
        Me.BtnRecup.Text = "Recuperer"
        Me.BtnRecup.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(337, 336)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(354, 29)
        Me.txtPassword.TabIndex = 20
        '
        'txtLogin
        '
        Me.txtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.Location = New System.Drawing.Point(337, 299)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(354, 29)
        Me.txtLogin.TabIndex = 19
        '
        'CmbBases
        '
        Me.CmbBases.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBases.FormattingEnabled = True
        Me.CmbBases.Location = New System.Drawing.Point(337, 261)
        Me.CmbBases.Name = "CmbBases"
        Me.CmbBases.Size = New System.Drawing.Size(723, 32)
        Me.CmbBases.TabIndex = 18
        '
        'CmbServeurs
        '
        Me.CmbServeurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbServeurs.FormattingEnabled = True
        Me.CmbServeurs.Location = New System.Drawing.Point(337, 99)
        Me.CmbServeurs.Name = "CmbServeurs"
        Me.CmbServeurs.Size = New System.Drawing.Size(735, 32)
        Me.CmbServeurs.TabIndex = 17
        '
        'chkAuthSQL
        '
        Me.chkAuthSQL.AutoSize = True
        Me.chkAuthSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAuthSQL.Location = New System.Drawing.Point(150, 376)
        Me.chkAuthSQL.Name = "chkAuthSQL"
        Me.chkAuthSQL.Size = New System.Drawing.Size(172, 28)
        Me.chkAuthSQL.TabIndex = 16
        Me.chkAuthSQL.Text = "Authentification"
        Me.chkAuthSQL.UseVisualStyleBackColor = True
        '
        'BtnValider
        '
        Me.BtnValider.Location = New System.Drawing.Point(325, 428)
        Me.BtnValider.Name = "BtnValider"
        Me.BtnValider.Size = New System.Drawing.Size(284, 61)
        Me.BtnValider.TabIndex = 15
        Me.BtnValider.Text = "Valider"
        Me.BtnValider.UseVisualStyleBackColor = True
        '
        'btnEditServeurs
        '
        Me.btnEditServeurs.Location = New System.Drawing.Point(12, 410)
        Me.btnEditServeurs.Name = "btnEditServeurs"
        Me.btnEditServeurs.Size = New System.Drawing.Size(182, 53)
        Me.btnEditServeurs.TabIndex = 30
        Me.btnEditServeurs.Text = "bnteditserveurs"
        Me.btnEditServeurs.UseVisualStyleBackColor = True
        '
        'BtnVoirConnexion
        '
        Me.BtnVoirConnexion.Location = New System.Drawing.Point(12, 469)
        Me.BtnVoirConnexion.Name = "BtnVoirConnexion"
        Me.BtnVoirConnexion.Size = New System.Drawing.Size(182, 53)
        Me.BtnVoirConnexion.TabIndex = 31
        Me.BtnVoirConnexion.Text = "BntVoirConnexion"
        Me.BtnVoirConnexion.UseVisualStyleBackColor = True
        '
        'BtnTester
        '
        Me.BtnTester.Location = New System.Drawing.Point(12, 528)
        Me.BtnTester.Name = "BtnTester"
        Me.BtnTester.Size = New System.Drawing.Size(182, 53)
        Me.BtnTester.TabIndex = 32
        Me.BtnTester.Text = "BntTester"
        Me.BtnTester.UseVisualStyleBackColor = True
        '
        'FrmServeurConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 717)
        Me.Controls.Add(Me.BtnTester)
        Me.Controls.Add(Me.BtnVoirConnexion)
        Me.Controls.Add(Me.btnEditServeurs)
        Me.Controls.Add(Me.Labelrep)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblChaine)
        Me.Controls.Add(Me.BtnRecup)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.CmbBases)
        Me.Controls.Add(Me.CmbServeurs)
        Me.Controls.Add(Me.chkAuthSQL)
        Me.Controls.Add(Me.BtnValider)
        Me.Name = "FrmServeurConfig"
        Me.Text = "Form36"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Labelrep As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblChaine As Label
    Friend WithEvents BtnRecup As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents CmbBases As ComboBox
    Friend WithEvents CmbServeurs As ComboBox
    Friend WithEvents chkAuthSQL As CheckBox
    Friend WithEvents BtnValider As Button
    Friend WithEvents btnEditServeurs As Button
    Friend WithEvents BtnVoirConnexion As Button
    Friend WithEvents BtnTester As Button
End Class
