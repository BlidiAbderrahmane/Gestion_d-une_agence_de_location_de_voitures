Imports System.IO
Public Class Form6
    Private Sub refreshList()
        Dim fs As New FileStream("reservations.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim ch As String
        Dim ch2, ch3 As String
        Dim cin As String = Label13.Text
        ListBox1.Items.Clear()
        While (sr.Peek() > -1)
            ch = sr.ReadLine()
            ch2 = ch.Substring(0, ch.IndexOf("*"))
            If (ch2 = cin) Then
                ch3 = ch.Remove(0, 9)
                ListBox1.Items.Add(ch3)
            End If
        End While
        sr.Close()
        fs.Close()
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshList()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pos = ListBox1.SelectedIndex
        If (pos < 0) Then
            MsgBox("Selectionner la reservation d'abord")
        Else
            Dim msg = "Etes-vous sur d'annuler cette reservation ? "
            Dim mb = MsgBox(msg, MessageBoxButtons.YesNo)
            If mb = vbYes Then
                Dim ch, ch2, ch3 As String
                Dim longueur As Integer
                Dim prix As String
                Dim res As String = Label13.Text & "*" & ListBox1.SelectedItem
                Dim index1 = res.IndexOf("*") + 1
                Dim index2 = res.IndexOf("*", index1 + 1) - 1
                Dim voiture = res.Substring(index1, index2 - index1 + 1)
                Dim maison = voiture.Substring(0, voiture.IndexOf(" "))
                Dim marque = voiture.Substring(voiture.IndexOf(" ") + 1)
                Dim fs1 As New FileStream("reservations.txt", FileMode.Open, FileAccess.Read)
                Dim sr1 As New StreamReader(fs1)
                Dim fs2 As New FileStream("auxi.txt", FileMode.Create, FileAccess.Write)
                Dim sw2 As New StreamWriter(fs2)
                Dim fs3 As New FileStream("voitures reserves.txt", FileMode.Open, FileAccess.Read)
                Dim sr3 As New StreamReader(fs3)
                Dim fs4 As New FileStream("auxi2.txt", FileMode.Create, FileAccess.Write)
                Dim sw4 As New StreamWriter(fs4)
                While (sr3.Peek() > -1)
                    ch = sr3.ReadLine
                    longueur = ch.IndexOf("/")
                    ch3 = ch.Substring(0, longueur)
                    If (ch3 <> voiture) Then
                        sw4.WriteLine(ch)
                    Else
                        prix = ch.Substring(ch.IndexOf("/") + 1)
                    End If
                End While
                sw4.Close()
                fs4.Close()
                sr3.Close()
                fs3.Close()
                My.Computer.FileSystem.DeleteFile("voitures reserves.txt")
                My.Computer.FileSystem.RenameFile("auxi2.txt", "voitures reserves.txt")
                Dim chmaison = maison & ".txt"
                Dim fs5 As New FileStream(chmaison, FileMode.Append, FileAccess.Write)
                Dim sw5 As New StreamWriter(fs5)
                sw5.WriteLine(marque & "/" & prix)
                sw5.Close()
                fs5.Close()
                While (sr1.Peek() > -1)
                    ch = sr1.ReadLine()
                    If (ch <> res) Then
                        sw2.WriteLine(ch)
                    End If
                End While
                sr1.Close()
                fs1.Close()
                sw2.Close()
                fs2.Close()
                My.Computer.FileSystem.DeleteFile("reservations.txt")
                My.Computer.FileSystem.RenameFile("auxi.txt", "reservations.txt")
                refreshList()
            End If
        End If
    End Sub
End Class