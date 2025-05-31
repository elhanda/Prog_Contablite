'Imports System.Data.SqlClient
'Imports System.IO
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.Windows.Forms

'Public Module EtatModule

'    Public Sub AfficherEtatCrystalDepuisPathCryst(cheminComplet As String, Optional parametres As Dictionary(Of String, Object) = Nothing)
'        Try
'            ' 🔎 Affichage de debug pour tester ce qui est reçu
'            MessageBox.Show("📂 Chemin reçu : " & cheminComplet, "Debug")

'            If String.IsNullOrWhiteSpace(cheminComplet) Then
'                MessageBox.Show("❌ Le chemin du fichier .rpt est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If

'            If Not File.Exists(cheminComplet) Then
'                MessageBox.Show("❌ Le fichier Crystal Report est introuvable : " & cheminComplet, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If

'            Dim report As New ReportDocument()
'            report.Load(cheminComplet)

'            If parametres IsNot Nothing Then
'                For Each kvp In parametres
'                    report.SetParameterValue(kvp.Key, kvp.Value)
'                Next
'            End If

'            Dim viewerForm As New Form()
'            Dim viewer As New CrystalReportViewer() With {
'                .Dock = DockStyle.Fill,
'                .ReportSource = report
'            }

'            viewerForm.Controls.Add(viewer)
'            viewerForm.WindowState = FormWindowState.Maximized
'            viewerForm.ShowDialog()

'        Catch ex As Exception
'            MessageBox.Show("❌ Erreur Crystal Report : " & ex.Message)
'        End Try
'    End Sub

'End Module

Imports System.Data.SqlClient

Public Module EtatModule

    Public PathCryst As String = ""


    Public Sub AfficherEtatCrystalDepuisPathCryst(nomEtatRPT As String, Optional parametres As Dictionary(Of String, Object) = Nothing)
        Try
            'If String.IsNullOrWhiteSpace(PathCryst) Then
            '    MessageBox.Show("❌ Le chemin PathCryst est vide. Veuillez l'initialiser avec InitialiserPathCryst().")
            '    Exit Sub
            'End If
            ''PathCryst = "E:Gestion Commerciale\Prog_Contabilite\"
            'Dim cheminComplet As String = System.IO.Path.Combine(PathCryst, nomEtatRPT)

            'If Not System.IO.File.Exists(cheminComplet) Then
            '    MessageBox.Show("❌ Le fichier Crystal Report est introuvable : " & cheminComplet)
            '    Exit Sub
            'End If

            Dim report As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            '' report.Load(cheminComplet)
            report.Load(nomEtatRPT)
            If parametres IsNot Nothing Then
                For Each kvp In parametres
                    report.SetParameterValue(kvp.Key, kvp.Value)
                Next
            End If

            Dim viewerForm As New Form()
            Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer() With {
                .Dock = DockStyle.Fill,
                .ReportSource = report
            }

            viewerForm.Controls.Add(viewer)
            viewerForm.WindowState = FormWindowState.Maximized
            viewerForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("❌ Erreur Crystal Report : " & ex.Message)
        End Try
    End Sub

End Module
