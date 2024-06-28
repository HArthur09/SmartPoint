Imports System.IO
Public Class Fichier
    Public clas As New Class4
    Public pw As New Class4.T_POINTAGE

    Public Function voir() As String
        Try
            Dim sms As String
            Dim open As New OpenFileDialog
            Dim lien As String = ""
            open.Filter = "Fichier du pointage|*.SP"
            If open.ShowDialog() = 1 Then
                lien = open.FileName
                MsgBox(lien)

            Else
                MsgBox("Veuillez choisir un fichier texte")
            End If
            Dim a As New Class2
            Dim contenuId As String = ""
            Dim contenu As String
            Dim lecteur As New StreamReader(lien)
            Dim info() As String
            Dim i As Integer = 0

            While (Not lecteur.EndOfStream)
                If i = 0 Then
                    contenuId = lecteur.ReadLine
                    a.tab_pointage(0).iddisp = contenuId
                Else
                    contenu = lecteur.ReadLine
                    info = contenu.Split("$")

                    a.tab_pointage(i - 1).iddisp = contenuId
                    a.tab_pointage(i - 1).idEtPer = info(0)
                    a.tab_pointage(i - 1).DateEn = info(2)
                    a.tab_pointage(i - 1).heure = CDate(info(1))
                End If
                i += 1
            End While
            lecteur.Close()
            FileClose()
            Dim sa, md, jo As String
            Dim temps As Date
            Dim heur As TimeSpan
            sa = a.tab_pointage(0).DateEn.Split(".")(2)
            md = a.tab_pointage(0).DateEn.Split(".")(1)
            jo = a.tab_pointage(0).DateEn.Split(".")(0)
            temps = sa + "-" + md + "-" + jo
            pw.Dates = temps
            pw.IDD = a.tab_pointage(0).iddisp
            pw.Heures = a.tab_pointage(0).heure
            clas.ouverture_connection()
            clas.TD_CM(point:=pw)
            clas.fermeture_connection()
            For er = 0 To i - 2
                heur = TimeSpan.Parse(a.tab_pointage(er).heure)
                If heur >= clas.PROGRAMMES(0).Tranches_horaire_debut And heur <= clas.PROGRAMMES(0).Tranches_horaire_debut.Add(TimeSpan.Parse("00:15:00")) Then
                    Dim car As New ListViewItem
                    car.Text = (a.tab_pointage(er).iddisp)
                    car.SubItems.Add(a.tab_pointage(er).idEtPer)
                    car.SubItems.Add(a.tab_pointage(er).DateEn)
                    car.SubItems.Add(a.tab_pointage(er).heure)
                    Form3.ListView7.Items.Add(car)
                ElseIf heur <= clas.PROGRAMMES(0).Tranches_horaire_fin And heur >= clas.PROGRAMMES(0).Tranches_horaire_fin.Subtract(TimeSpan.Parse("00:15:00")) Then
                    Dim cam As New ListViewItem
                    cam.Text = (a.tab_pointage(er).iddisp)
                    cam.SubItems.Add(a.tab_pointage(er).idEtPer)
                    cam.SubItems.Add(a.tab_pointage(er).DateEn)
                    cam.SubItems.Add(a.tab_pointage(er).heure)
                    Form3.ListView2.Items.Add(cam)
                Else

                End If
            Next
            sms = "L'importation a été éffectuer avec succès!"

            Return sms

        Catch ex As Exception
            Dim sms As String
            sms = "L'importation n'a été effectuer car " + ex.Message
            MsgBox(sms)
            Return sms
        End Try



    End Function


End Class
