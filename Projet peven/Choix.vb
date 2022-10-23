Public Class Form3


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form4 As New Form4
        form4.Label13.Text = Label13.Text
        form4.Show()
        Me.Hide()
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form6 As New Form6
        form6.Label13.Text = Label13.Text
        form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
        Form2.CheckBox1.CheckState = CheckState.Unchecked
    End Sub
End Class