Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewForm
    Private currentIndex As Integer = 0

    Private Sub ViewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.Text = "John Doe, Slidely Task 2 - View Submissions"
        Me.Size = New Size(400, 400)

        ' Name Field
        Dim lblName As New Label With {
            .Text = "Name",
            .Location = New Point(50, 30),
            .Size = New Size(100, 20)
        }
        Me.Controls.Add(lblName)

        Dim txtName As New TextBox With {
            .Name = "txtName",
            .Location = New Point(150, 30),
            .Size = New Size(200, 20),
            .ReadOnly = True
        }
        Me.Controls.Add(txtName)

        ' Email Field
        Dim lblEmail As New Label With {
            .Text = "Email",
            .Location = New Point(50, 70),
            .Size = New Size(100, 20)
        }
        Me.Controls.Add(lblEmail)

        Dim txtEmail As New TextBox With {
            .Name = "txtEmail",
            .Location = New Point(150, 70),
            .Size = New Size(200, 20),
            .ReadOnly = True
        }
        Me.Controls.Add(txtEmail)

        ' Phone Number Field
        Dim lblPhoneNum As New Label With {
            .Text = "Phone Num",
            .Location = New Point(50, 110),
            .Size = New Size(100, 20)
        }
        Me.Controls.Add(lblPhoneNum)

        Dim txtPhoneNum As New TextBox With {
            .Name = "txtPhoneNum",
            .Location = New Point(150, 110),
            .Size = New Size(200, 20),
            .ReadOnly = True
        }
        Me.Controls.Add(txtPhoneNum)

        ' GitHub Link Field
        Dim lblGithubLink As New Label With {
            .Text = "GitHub Link For Task 2",
            .Location = New Point(50, 150),
            .Size = New Size(100, 20)
        }
        Me.Controls.Add(lblGithubLink)

        Dim txtGithubLink As New TextBox With {
            .Name = "txtGithubLink",
            .Location = New Point(150, 150),
            .Size = New Size(200, 20),
            .ReadOnly = True
        }
        Me.Controls.Add(txtGithubLink)

        ' Stopwatch Time Display
        Dim lblStopwatchTime As New Label With {
            .Text = "Stopwatch time",
            .Location = New Point(50, 190),
            .Size = New Size(100, 20)
        }
        Me.Controls.Add(lblStopwatchTime)

        Dim txtStopwatchTime As New TextBox With {
            .Name = "txtStopwatchTime",
            .Location = New Point(150, 190),
            .Size = New Size(200, 20),
            .ReadOnly = True
        }
        Me.Controls.Add(txtStopwatchTime)

        ' Previous Button
        Dim btnPrevious As New Button With {
            .Text = "PREVIOUS (CTRL + P)",
            .Location = New Point(50, 230),
            .Size = New Size(150, 50),
            .BackColor = Color.Yellow
        }
        AddHandler btnPrevious.Click, AddressOf btnPrevious_Click
        Me.Controls.Add(btnPrevious)

        ' Next Button
        Dim btnNext As New Button With {
            .Text = "NEXT (CTRL + N)",
            .Location = New Point(200, 230),
            .Size = New Size(150, 50),
            .BackColor = Color.LightBlue
        }
        AddHandler btnNext.Click, AddressOf btnNext_Click
        Me.Controls.Add(btnNext)

        ' Keyboard Shortcuts
        Me.KeyPreview = True

        ' Load first submission
        LoadSubmission(0)
    End Sub

    Private Async Sub LoadSubmission(index As Integer)
        Using client As New HttpClient()
            Dim response = Await client.GetStringAsync($"http://localhost:3000/read?index={index}")
            Dim submission = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)

            CType(Me.Controls("txtName"), TextBox).Text = submission("name")
            CType(Me.Controls("txtEmail"), TextBox).Text = submission("email")
            CType(Me.Controls("txtPhoneNum"), TextBox).Text = submission("phone")
            CType(Me.Controls("txtGithubLink"), TextBox).Text = submission("github_link")
            CType(Me.Controls("txtStopwatchTime"), TextBox).Text = submission("stopwatch_time")
        End Using
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs)
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs)
        currentIndex += 1
        LoadSubmission(currentIndex)
    End Sub

    Private Sub ViewForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious_Click(Me, EventArgs.Empty)
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class
