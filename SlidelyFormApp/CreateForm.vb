Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class CreateForm
    Private stopwatch As New Stopwatch()

    Private Sub CreateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.Text = "John Doe, Slidely Task 2 - Create Submission"
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
            .Size = New Size(200, 20)
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
            .Size = New Size(200, 20)
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
            .Size = New Size(200, 20)
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
            .Size = New Size(200, 20)
        }
        Me.Controls.Add(txtGithubLink)

        ' Toggle Stopwatch Button
        Dim btnToggleStopwatch As New Button With {
            .Text = "TOGGLE STOPWATCH (CTRL + T)",
            .Location = New Point(50, 190),
            .Size = New Size(200, 50),
            .BackColor = Color.Yellow
        }
        AddHandler btnToggleStopwatch.Click, AddressOf btnToggleStopwatch_Click
        Me.Controls.Add(btnToggleStopwatch)

        ' Stopwatch Time Display
        Dim lblStopwatchTime As New Label With {
            .Name = "lblStopwatchTime",
            .Text = "00:00:00",
            .Location = New Point(260, 190),
            .Size = New Size(100, 50),
            .BorderStyle = BorderStyle.Fixed3D,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(lblStopwatchTime)

        ' Submit Button
        Dim btnSubmit As New Button With {
            .Text = "SUBMIT (CTRL + S)",
            .Location = New Point(50, 250),
            .Size = New Size(200, 50),
            .BackColor = Color.LightBlue
        }
        AddHandler btnSubmit.Click, AddressOf btnSubmit_Click
        Me.Controls.Add(btnSubmit)

        ' Keyboard Shortcuts
        Me.KeyPreview = True
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs)
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
        Dim lblStopwatchTime = Me.Controls("lblStopwatchTime")
        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim name = CType(Me.Controls("txtName"), TextBox).Text
        Dim email = CType(Me.Controls("txtEmail"), TextBox).Text
        Dim phone = CType(Me.Controls("txtPhoneNum"), TextBox).Text
        Dim githubLink = CType(Me.Controls("txtGithubLink"), TextBox).Text
        Dim stopwatchTime = CType(Me.Controls("lblStopwatchTime"), Label).Text

        Dim data As New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        }

        Dim jsonData = JsonConvert.SerializeObject(data)
        Dim content = New StringContent(jsonData, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim response = Await client.PostAsync("http://localhost:3000/submit", content)
            Dim responseString = Await response.Content.ReadAsStringAsync()
            MessageBox.Show(responseString)
        End Using
    End Sub

    Private Sub CreateForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch_Click(Me, EventArgs.Empty)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class
