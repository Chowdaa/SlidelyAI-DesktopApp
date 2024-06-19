<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnViewSubmissions = New System.Windows.Forms.Button()
        Me.btnCreateNewSubmission = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnViewSubmissions
        '
        Me.btnViewSubmissions.Location = New System.Drawing.Point(50, 50)
        Me.btnViewSubmissions.Name = "btnViewSubmissions"
        Me.btnViewSubmissions.Size = New System.Drawing.Size(200, 50)
        Me.btnViewSubmissions.TabIndex = 0
        Me.btnViewSubmissions.Text = "&View Submissions"
        Me.btnViewSubmissions.UseVisualStyleBackColor = True
        '
        'btnCreateNewSubmission
        '
        Me.btnCreateNewSubmission.Location = New System.Drawing.Point(50, 120)
        Me.btnCreateNewSubmission.Name = "btnCreateNewSubmission"
        Me.btnCreateNewSubmission.Size = New System.Drawing.Size(200, 50)
        Me.btnCreateNewSubmission.TabIndex = 1
        Me.btnCreateNewSubmission.Text = "&Create New Submission"
        Me.btnCreateNewSubmission.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 250)
        Me.Controls.Add(Me.btnViewSubmissions)
        Me.Controls.Add(Me.btnCreateNewSubmission)
        Me.Name = "Form1"
        Me.Text = "Slidely Form App"
        Me.ResumeLayout(False)

    End Sub

End Class
