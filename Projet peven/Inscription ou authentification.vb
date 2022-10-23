Imports System.IO

Public Class Form2
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cin = TextBox1.Text
        Dim mdp = TextBox2.Text
        Dim fs1 As New FileStream("cin.txt", FileMode.Open, FileAccess.Read)
        Dim sr1 As New StreamReader(fs1)
        Dim test As Boolean = False
        Dim ch1 As String
        Dim pos As Integer = 0
        While (sr1.Peek() > -1) And (test = False)
            ch1 = sr1.ReadLine()
            pos = pos + 1
            If (ch1 = cin) Then
                test = True
            End If
        End While
        If (test = False) Then
            MsgBox("Le CIN n'est pas inscrit")
        Else
            Dim ch2 As String = ""
            Dim fs2 As New FileStream("mdp.txt", FileMode.Open, FileAccess.Read)
            Dim sr2 As New StreamReader(fs2)
            Dim pos2 As Integer = 0
            While (pos2 < pos)
                ch2 = sr2.ReadLine()
                pos2 = pos2 + 1
            End While
            If (ch2 <> mdp) Then
                MsgBox("Le Mot de Passe est Incorrecte")
            Else
                TextBox1.Clear()
                TextBox2.Clear()
                Form3.Show()
                Form3.Label13.Text = cin
                Me.Hide()
            End If
            sr2.Close()
            fs2.Close()
        End If
        sr1.Close()
        fs1.Close()
    End Sub
    Function isValid(ByVal str As String) As Boolean
        Dim i As Integer
        Dim c As Char
        For i = 0 To (str.Length) - 1
            c = str(i)
            If (str(0) = " ") Then
                Return False
            End If
            If (Not (c >= "A" And c <= "Z") And Not (c >= "a" And c < "z") And c <> " ") Then
                Return False
            End If
        Next
        Return True
    End Function
    Function Checknum(ByVal ch As String) As Boolean
        If (ch.Length = 8 And IsNumeric(ch) And ch.IndexOf(".") = -1) Then
            Return True
        End If
        Return False
    End Function
    Function existInCinFile(ByVal ch As String) As Boolean
        Dim fs As New FileStream("cin.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim exist As Boolean = False
        Dim chtest As String
        While (sr.Peek() > -1)
            chtest = sr.ReadLine()
            If (chtest = ch) Then
                exist = True
            End If
        End While
        sr.Close()
        fs.Close()
        Return exist
    End Function
    Function Checkcin(ByVal ch As String) As Boolean
        If (ch.Length = 8 And IsNumeric(ch) And ch.IndexOf(".") = -1 And (ch(0) = "0" Or ch(0) = "1")) Then
            Return True
        End If
        Return False
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nom = TextBox3.Text
        Dim pre = TextBox4.Text
        Dim cin = TextBox5.Text
        Dim mdp = TextBox6.Text
        Dim num = TextBox7.Text
        Dim per = TextBox8.Text
        If (nom = "" Or Not (isValid(nom))) Then
            MsgBox("Verifier le nom")
        ElseIf (pre = "" Or Not (isValid(pre))) Then
            MsgBox("Verifier le prenom")
        ElseIf (Not (Checkcin(cin))) Then
            MsgBox("Verifier le CIN")
        ElseIf (existInCinFile(cin)) Then
            MsgBox("CIN deja inscrit !")
        ElseIf (mdp.Length < 8) Then
            MsgBox("Le mot de passe doit contenir au moins 8 caractères")
        ElseIf (Not (Checknum(num))) Then
            MsgBox("Verifier le numero")
        ElseIf (Not (Checkcin(per))) Then
            MsgBox("Verifier le numero de Permis")
        Else
            Dim fs1 As New FileStream("nom.txt", FileMode.Append, FileAccess.Write)
            Dim fs2 As New FileStream("prenom.txt", FileMode.Append, FileAccess.Write)
            Dim fs3 As New FileStream("cin.txt", FileMode.Append, FileAccess.Write)
            Dim fs4 As New FileStream("mdp.txt", FileMode.Append, FileAccess.Write)
            Dim fs5 As New FileStream("numtel.txt", FileMode.Append, FileAccess.Write)
            Dim fs6 As New FileStream("permis.txt", FileMode.Append, FileAccess.Write)
            Dim sw1 As New StreamWriter(fs1)
            Dim sw2 As New StreamWriter(fs2)
            Dim sw3 As New StreamWriter(fs3)
            Dim sw4 As New StreamWriter(fs4)
            Dim sw5 As New StreamWriter(fs5)
            Dim sw6 As New StreamWriter(fs6)
            sw1.WriteLine(nom)
            sw1.Flush()
            sw2.WriteLine(pre)
            sw2.Flush()
            sw3.WriteLine(cin)
            sw3.Flush()
            sw4.WriteLine(mdp)
            sw4.Flush()
            sw5.WriteLine(num)
            sw5.Flush()
            sw6.WriteLine(per)
            sw6.Flush()
            sw1.Close()
            fs1.Close()
            sw2.Close()
            fs2.Close()
            sw3.Close()
            fs3.Close()
            sw4.Close()
            fs4.Close()
            sw5.Close()
            fs5.Close()
            sw6.Close()
            fs6.Close()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            MsgBox("Utilisateur Bien Inscrit")
            Form3.Show()
            Form3.Label13.Text = cin
            Me.Hide()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (TextBox2.PasswordChar = "*") Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class