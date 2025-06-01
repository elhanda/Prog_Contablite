Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration


Module Module1

    '  Public con As SqlConnection
    Public table1 As New DataTable
    Public table2 As New DataTable
    Public table3 As New DataTable
    Public table4 As New DataTable
    Public nom_soc As String
    Public PathCryst As String
    Private ReadOnly ConfigurationManager As Object


    'Public Sub connecter()
    '    Try
    '        ' Configurateur / Chemin / Chaine de connexion
    '        Dim connectionString As String = "Server=DESKTOP-PAIF7LI;Database=base_compta_" & Access.n2 & ";Integrated Security=True;"
    '        con = New SqlConnection(connectionString)
    '        con.Open()
    '        'MessageBox.Show("Connecté à base_compta_" & Access.n2 & con.Database)
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur connexion base_compta_" & Access.n2 & ex.Message)
    '    End Try
    'End Sub
    'Public Sub connecter_soc()
    '    Try
    '        ' Configurateur / Chemin / Chaine de connexion
    '        Dim connectionString As String = "Server=DESKTOP-PAIF7LI;Database=base_compta_soc;Integrated Security=True;"
    '        con = New SqlConnection(connectionString)
    '        con.Open()
    '        'MessageBox.Show("Connecté à base_compta_soc : " & con.Database)
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur connexion base_compta_soc : " & ex.Message)
    '    End Try
    'End Sub

    Public con As SqlConnection

    Private Function GetConfigPath() As String
        Dim configPath As String = Path.Combine(Application.StartupPath, "connextionconfig\db_config.txt")

        If Not File.Exists(configPath) Then
            Throw New FileNotFoundException("Configuration file not found: " & configPath)
        End If

        Return configPath
    End Function

    Private Function GetConnectionString(databaseName As String) As String
        Dim configPath As String = GetConfigPath()

        If Not File.Exists(configPath) Then
            Throw New FileNotFoundException("Configuration file not found: " & configPath)
        End If

        Dim server As String = ""
        Dim integratedSecurity As Boolean = True
        Dim username As String = ""
        Dim password As String = ""

        For Each line In File.ReadAllLines(configPath)
            Dim parts = line.Split("="c)
            If parts.Length <> 2 Then Continue For

            Select Case parts(0).Trim().ToLower()
                Case "server"
                    server = parts(1).Trim()
                Case "integratedsecurity"
                    integratedSecurity = parts(1).Trim().ToLower() = "true"
                Case "username"
                    username = parts(1).Trim()
                Case "password"
                    password = parts(1).Trim()
            End Select
        Next

        If integratedSecurity Then
            Return $"Server={server};Database={databaseName};Integrated Security=True;"
        Else
            Return $"Server={server};Database={databaseName};User ID={username};Password={password};"
        End If
    End Function

    Public Sub connecter()
        Try
            Dim connectionString = GetConnectionString("base_compta_" & Access.n2)
            con = New SqlConnection(connectionString)
            con.Open()
        Catch ex As Exception
            MessageBox.Show("Erreur connexion base_compta_" & Access.n2 & ": " & ex.Message)
        End Try
    End Sub

    Public Sub connecter_soc()
        Try
            Dim connectionString = GetConnectionString("base_compta_soc")
            con = New SqlConnection(connectionString)
            con.Open()
        Catch ex As Exception
            MessageBox.Show("Erreur connexion base_compta_soc: " & ex.Message)
        End Try
    End Sub

    Public Sub ChargerExercices(combo As ComboBox, codeSociete As String)
        Try
            Module1.connecter()
            ' MessageBox.Show("📂 Base de données active : " & con.Database, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim req As String =
   "SELECT DISTINCT CAST(exercice AS VARCHAR(10)) AS exercice " &
        "FROM Periode_Soc " &
        "WHERE LTRIM(RTRIM(Code_Soc)) = @code " &
             "ORDER BY exercice"
            '"SELECT DISTINCT CAST(exercice AS VARCHAR(10)) AS exercice " &
            '"FROM Periode_Soc " &
            '"WHERE LTRIM(RTRIM(Code_Soc)) = @code " &
            '"AND ISNUMERIC(exercice) = 1 " &
            '"ORDER BY exercice"

            Dim cmd As New SqlCommand(req, con)
            cmd.Parameters.AddWithValue("@code", codeSociete.Trim())
            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            Dim currentYear As String = DateTime.Now.Year.ToString()

            ' ✅ Évite d’ajouter si déjà présent (même type)
            Dim alreadyExists As Boolean = dt.AsEnumerable().
        Any(Function(r) r.Field(Of String)("exercice") = currentYear)

            If Not alreadyExists Then
                Dim newRow As DataRow = dt.NewRow()
                newRow("exercice") = currentYear
                dt.Rows.Add(newRow)
            End If

            ' ✅ Bind propre
            combo.DataSource = dt
            combo.DisplayMember = "exercice"
            combo.ValueMember = "exercice"
            combo.SelectedIndex = 0

            ' MsgBox("Nombre d'exercices chargés : " & dt.Rows.Count)

            ' ✅ Libération explicite du SqlCommand
            cmd.Dispose()

        Catch ex As Exception
            MessageBox.Show("❌ Erreur dans ChargerExercices : " & ex.Message)
        End Try
    End Sub
    Public Sub AfficherBaseActive(form As Form)
        Try
            Module1.connecter()

            If con Is Nothing OrElse con.State <> ConnectionState.Open Then
                MessageBox.Show("Aucune connexion active.")
                Return
            End If
            '     MessageBox.Show("📂 Base de données active : " & con.Database, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim base As String = con.Database
            Dim serveur As String = con.DataSource
            MessageBox.Show($"🔍 Base active : {base}" & vbCrLf & $"🖥️ Serveur : {serveur}", "Connexion SQL", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Tu peux aussi l’afficher sur le form si tu veux en label temporaire
            Dim lbl As New Label()
            lbl.Text = $"Base : {base}"
            lbl.ForeColor = Color.White
            lbl.BackColor = Color.DarkGreen
            lbl.AutoSize = True
            lbl.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lbl.Location = New Point(form.Width - 160, 10)
            lbl.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            form.Controls.Add(lbl)

        Catch ex As Exception
            MessageBox.Show("❌ Impossible d'afficher la base active : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Calcule les totaux pour deux colonnes spécifiques dans un DataGridView.
    ''' </summary>
    ''' <param name="dgv">Le DataGridView à parcourir</param>
    ''' <param name="colIndex1">Index de la colonne pour total1 (zero-based)</param>
    ''' <param name="colIndex2">Index de la colonne pour total2 (zero-based)</param>
    ''' <returns>Tuple contenant (total1, total2)</returns>
    Public Function CalculerTotaux(dgv As DataGridView, colIndex1 As Integer, colIndex2 As Integer) As (Decimal, Decimal)
        Dim total1 As Decimal = 0
        Dim total2 As Decimal = 0

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                Dim val1 As Decimal = 0
                Dim val2 As Decimal = 0

                If Decimal.TryParse(row.Cells(colIndex1).Value?.ToString(), val1) Then
                    total1 += val1
                End If

                If Decimal.TryParse(row.Cells(colIndex2).Value?.ToString(), val2) Then
                    total2 += val2
                End If
            End If
        Next

        Return (total1, total2)
    End Function

End Module




