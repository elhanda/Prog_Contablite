<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Apercu_balance
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
        Me.Balance_Report_Final1 = New Prog_Contablite.Balance_Report_Final()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Balance_Report_Final3 = New Prog_Contablite.Balance_Report_Final()
        Me.Balance_Report_Final2 = New Prog_Contablite.Balance_Report_Final()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.Balance_Report_Final3
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1129, 768)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'Apercu_balance
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1129, 768)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Apercu_balance"
        Me.Text = " Balance"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Balance_Report_Final1 As Balance_Report_Final
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Balance_Report_Final2 As Balance_Report_Final
    Friend WithEvents Balance_Report_Final3 As Balance_Report_Final
End Class
