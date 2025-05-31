'10-18-2006 KLEINMA
'www.vbforums.com


Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdGenerate As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents CRViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdGenerate = New System.Windows.Forms.Button()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CRViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGenerate
        '
        Me.cmdGenerate.Location = New System.Drawing.Point(8, 8)
        Me.cmdGenerate.Name = "cmdGenerate"
        Me.cmdGenerate.Size = New System.Drawing.Size(160, 23)
        Me.cmdGenerate.TabIndex = 0
        Me.cmdGenerate.Text = "Generate Listview"
        '
        'cmdReport
        '
        Me.cmdReport.Enabled = False
        Me.cmdReport.Location = New System.Drawing.Point(8, 40)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(160, 23)
        Me.cmdReport.TabIndex = 1
        Me.cmdReport.Text = "View Report"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(176, 8)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(336, 248)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Field 1"
        Me.ColumnHeader1.Width = 71
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Field 2"
        Me.ColumnHeader2.Width = 89
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Field 3"
        Me.ColumnHeader3.Width = 109
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "kleinma (www.vbforums.com)"
        '
        'CRViewer
        '
        Me.CRViewer.ActiveViewIndex = -1
        Me.CRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CRViewer.Location = New System.Drawing.Point(0, 270)
        Me.CRViewer.Name = "CRViewer"
        Me.CRViewer.Size = New System.Drawing.Size(520, 368)
        Me.CRViewer.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Create XSD File"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 638)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CRViewer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdGenerate)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'THIS ROUTINE SIMPLY GENERATES THE LISTVIEW WITH SOME DUMMY DATA SO WE HAVE DATA FOR THE REPORT
    Private Sub cmdGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerate.Click
        Dim LVI As ListViewItem = Nothing
        For i As Integer = 1 To 50
            LVI = New ListViewItem("Item " & i.ToString)
            LVI.SubItems.Add(DateTime.Now.Millisecond.ToString)
            LVI.SubItems.Add(DateTime.Now.AddDays(i).ToString("MM/dd/yyyy"))
            ListView1.Items.Add(LVI)
        Next
        cmdReport.Enabled = True
    End Sub

    'THIS ROUTINE CREATES THE DATASET THAT WILL BE USED AS THE REPORTS DATA SOURCE.
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        'REPORT OBJECT
        Dim MyRpt As New CrystalReport1

        'DATASET, AND DATAROW OBJECTS NEEDED TO MAKE THE DATA SOURCE
        Dim row As DataRow = Nothing
        Dim DS As New DataSet

        'ADD A TABLE TO THE DATASET
        DS.Tables.Add("ListViewData")
        'ADD THE COLUMNS TO THE TABLE
        With DS.Tables(0).Columns
            .Add("Field1", Type.GetType("System.String"))
            .Add("Field2", Type.GetType("System.String"))
            .Add("Field3", Type.GetType("System.String"))
        End With

        'LOOP THE LISTVIEW AND ADD A ROW TO THE TABLE FOR EACH LISTVIEWITEM
        For Each LVI As ListViewItem In ListView1.Items
            row = DS.Tables(0).NewRow
            row(0) = LVI.SubItems(0).Text
            row(1) = LVI.SubItems(1).Text
            row(2) = LVI.SubItems(2).Text
            DS.Tables(0).Rows.Add(row)
        Next

        'SET THE REPORT SOURCE TO THE DATABASE
        MyRpt.SetDataSource(DS.Tables("ListViewData"))

        'ASSIGN THE REPORT TO THE CRVIEWER CONTROL
        CRViewer.ReportSource = MyRpt

        'DISPOSE OF THE DATASET
        DS.Dispose()
        DS = Nothing
    End Sub

    'OK HERE IS THE ROUTINE THAT MAKES THIS ALL WORK. YOU ONLY NEED TO RUN THIS ONCE (UNLESS YOU CHANGE YOUR TABLE'S SCHEMA (ADD A COLUMN, ETC...)
    'WHAT THIS DOES, IS TAKES THE SCHEMA OF YOUR TABLE, AND WRITES IT TO AN XSD FILE. CR CAN USE AN XSD FILE AS A DB SCHEMA, SO YOU CAN LAYOUT YOUR REPORT AT DESIGN TIME
    'BASICALLY WHEN YOU DO IS, RUN THIS ROUTINE. THEN ADD A CR REPORT TO YOUR APP, AND WHEN YOU HOOK UP THE DATA SOURCE TO IT, SELECT
    '"MORE DATA SOURCES" -> "ADO.NET (XML)" AND THEN SELECT YOUR XSD FILE YOU CREATED (IT WILL BE IN THE BIN FOLDER OF THIS PROJECT)
    'THIS WILL ALLOW YOU TO LAYOUT YOUR REPORT USING THE EXACT FIELDS YOU WILL SEND OVER WHEN CREATING THE REPORT DYNAMICALLY.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DA As DataTable = Nothing
        Dim row As DataRow = Nothing
        Dim DS As New DataSet

        DS.Tables.Add("ListViewData")
        With DS.Tables(0).Columns
            .Add("Field1", Type.GetType("System.String"))
            .Add("Field2", Type.GetType("System.String"))
            .Add("Field3", Type.GetType("System.String"))
        End With

        'THIS LINE IS IMPORTANT.
        DS.WriteXmlSchema(Application.StartupPath & "\ReportSchema.xsd")
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
