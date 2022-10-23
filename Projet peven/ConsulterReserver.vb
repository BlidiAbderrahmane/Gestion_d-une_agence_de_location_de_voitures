Imports System.IO

Public Class Form4
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub addMarque(ByVal fs As FileStream, ByVal sr As StreamReader)
        Dim ch As String
        Dim marque As String
        Dim i As Integer
        ComboBox2.Items.Clear()
        While (sr.Peek() > -1)
            ch = sr.ReadLine
            i = 0
            marque = ""
            While (ch(i) <> "/")
                marque = marque + ch(i)
                i = i + 1
            End While
            ComboBox2.Items.Add(marque)
            ComboBox2.SelectedIndex = 0

        End While
    End Sub
    Private Sub prixMarque(ByVal fs As FileStream, ByVal sr As StreamReader, ByVal pos As Integer)
        Dim ch As String
        Dim ch2 As String
        Dim i As Integer
        Dim pos2 = 0
        While (pos2 < pos + 1)
            ch = sr.ReadLine
            pos2 = pos2 + 1
        End While
        i = ch.IndexOf("/")
        ch2 = ch.Substring(i + 1)
        Label7.Text = ch2
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim pos = ComboBox1.SelectedIndex
        Select Case pos
            Case 0
                Button6.PerformClick()
            Case 1
                Dim fs As New FileStream("citroen.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
            Case 2
                Dim fs As New FileStream("kia.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
            Case 3
                Dim fs As New FileStream("peugeot.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
            Case 4
                Dim fs As New FileStream("renault.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
            Case 5
                Dim fs As New FileStream("toyota.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
            Case 6
                Dim fs As New FileStream("volkswagen.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                addMarque(fs, sr)
                sr.Close()
                fs.Close()
        End Select
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim pos1 = ComboBox1.SelectedIndex
        Dim pos2 = ComboBox2.SelectedIndex
        Select Case pos1
            Case 1
                Dim fs As New FileStream("citroen.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()
            Case 2
                Dim fs As New FileStream("kia.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()
            Case 3
                Dim fs As New FileStream("peugeot.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()
            Case 4
                Dim fs As New FileStream("renault.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()
            Case 5
                Dim fs As New FileStream("toyota.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()

            Case 6
                Dim fs As New FileStream("volkswagen.txt", FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)
                prixMarque(fs, sr, pos2)
                sr.Close()
                fs.Close()
        End Select

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ComboBox1.SelectedIndex = 0
        ComboBox2.Items.Clear()
        Label7.Text = ""

    End Sub


    Function existInReserve(ByVal res As String, ByVal fs As FileStream, ByVal sr As StreamReader) As Boolean
        Dim ch As String
        While (sr.Peek() > -1)
            ch = sr.ReadLine
            If (ch = res) Then
                sr.Close()
                fs.Close()
                Return True
            End If
        End While
        sr.Close()
        fs.Close()
        Return False
    End Function
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds = MonthCalendar1.SelectionRange.Start.ToString("yyyy/MM/dd")
        Dim dr = MonthCalendar2.SelectionRange.Start.ToString("yyyy/MM/dd")
        Dim dt = Today.ToString("yyyy/MM/dd")
        Dim maison = ComboBox1.SelectedItem
        Dim marque = ComboBox2.SelectedItem

        If (ComboBox1.SelectedIndex <= 0) Then
            MsgBox("Selectionner la maison")
        ElseIf (ComboBox2.SelectedIndex < 0) Then
            MsgBox("Selectionner la marque")
        ElseIf (ds < dt) Then
            MsgBox("Vous ne pouvez pas choisir une date de sortie au passé")
        ElseIf (dr <= ds) Then
            MsgBox("La durée de location doit etre 1 jour au moins")
        Else
            Dim prixjour = Integer.Parse(Label7.Text)
            Dim duree = DateDiff("d", ds, dr)
            Dim prixres = duree * prixjour
            Dim res As String
            Dim fs As New FileStream("reservations.txt", FileMode.Open, FileAccess.Read)
            Dim sr As New StreamReader(fs)
            res = Label13.Text & "*" & maison & " " & marque & "*" & ds & "*" & dr & "*" & prixres
            If (existInReserve(res, fs, sr)) Then
                MsgBox("Reservation Deja Fait")
            Else
                Dim msg = "Etes-vous sur de passer cette reservation ? Le prix final va etre " & prixres.ToString & "DT"
                Dim mb = MsgBox(msg, MessageBoxButtons.YesNo)
                If mb = vbYes Then
                    Dim fs2 As New FileStream("reservations.txt", FileMode.Append, FileAccess.Write)
                    Dim sr2 As New StreamWriter(fs2)
                    sr2.WriteLine(res)
                    sr2.Close()
                    fs2.Close()
                    Dim fs5 As New FileStream("voitures reserves.txt", FileMode.Append, FileAccess.Write)
                    Dim sw5 As New StreamWriter(fs5)
                    sw5.WriteLine(maison & " " & marque & "/" & prixjour)
                    sw5.Close()
                    fs5.Close()
                    Dim chmaison = maison & ".txt"
                    Dim ch3, chmarque As String
                    Dim fs3 As New FileStream(chmaison, FileMode.Open, FileAccess.Read)
                    Dim sr3 As New StreamReader(fs3)
                    Dim fs4 As New FileStream("auxi.txt", FileMode.Create, FileAccess.Write)
                    Dim sw4 As New StreamWriter(fs4)
                    While (sr3.Peek() > -1)
                        ch3 = sr3.ReadLine
                        chmarque = marque & "/" & prixjour
                        If (ch3 <> chmarque) Then
                            sw4.WriteLine(ch3)
                        End If
                    End While
                    sr3.Close()
                    fs3.Close()
                    sw4.Close()
                    fs4.Close()
                    sw5.Close()
                    fs5.Close()
                    My.Computer.FileSystem.DeleteFile(chmaison)
                    My.Computer.FileSystem.RenameFile("auxi.txt", chmaison)
                    ComboBox2.Text = ""
                    Button6.PerformClick()
                    MsgBox("Résérvation fait avec success")
                End If
            End If
        End If
    End Sub

End Class