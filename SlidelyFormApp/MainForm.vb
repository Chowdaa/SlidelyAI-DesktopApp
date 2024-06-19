Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.Text = "John Doe, Slidely Task 2 - Slidely Form App"
        Me.Size = New Size(400, 200)

        ' View Submissions Button
        Dim btnViewSubmissions As New Button With {
            .Text = "VIEW SUBMISSIONS (CTRL + V)",
            .Location = New Point(50, 50),
            .Size = New Size(300, 50),
            .BackColor = Color.Yellow
        }
        AddHandler btnViewSubmissions.Click, AddressOf btnViewSubmissions_Click
        Me.Controls.Add(btnViewSubmissions)

        ' Create New Submission Button
        Dim btnCreateNewSubmission As New Button With {
            .Text = "CREATE NEW SUBMISSION (CTRL + N)",
            .Location = New Point(50, 110),
            .Size = New Size(300, 50),
            .BackColor = Color.LightBlue
        }
        AddHandler btnCreateNewSubmission.Click, AddressOf btnCreateNewSubmission_Click
        Me.Controls.Add(btnCreateNewSubmission)

        ' Keyboard Shortcuts
        Me.KeyPreview = True
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs)
        Dim viewForm As New ViewForm()
        viewForm.Show()
    End Sub

    Private Sub btnCreateNewSubmission_Click(sender As Object, e As EventArgs)
        Dim createForm As New CreateForm()
        createForm.Show()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions_Click(Me, EventArgs.Empty)
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateNewSubmission_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class
