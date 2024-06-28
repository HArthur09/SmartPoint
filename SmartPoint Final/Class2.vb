Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Class2
    Structure Dispositif

        Dim ID_Disp As String
        Dim Salle As String
        Dim Date_enregis As Date
        Dim Date_last_import As Date
        Dim Heure_last_impor As Integer
    End Structure

    Public Tab_disp(50) As Dispositif

    Structure Pointage
        Dim iddisp As String
        Dim idEtPer As String
        Dim DateEn As String
        Dim heure As DateTime

    End Structure
    Public tab_pointage(500) As Pointage

    Structure Etudiant
        Dim Nom As String
        Dim Date_de_Nais As Date
        Dim Niveau As String
        Dim Filiere As String
        Dim Sexe As String
        Dim Groupe_TD As String
        Dim Groupe_TP As String
        Dim Matricule As String
        Dim ID_Etud As String
        Dim Heures_absence As Integer
    End Structure
    Public tab_etud(500) As Etudiant

    Structure Etudiant_INS
        Dim Nom As String
        Dim Niveau As String
        Dim Filiere As String
        Dim Groupe_TD As String
        Dim Groupe_TP As String
        Dim Heures_absence As Integer
    End Structure
    Public tab_etud_INS(500) As Etudiant

    Structure Etudiant_ISN
        Dim Nom As String
        Dim Niveau As String
        Dim Filiere As String
        Dim Groupe_TD As String
        Dim Groupe_TP As String
        Dim Heures_absence As Integer
    End Structure
    Public tab_etud_ISN(500) As Etudiant

    Structure Etudiant_CDN
        Dim Nom As String
        Dim Niveau As String
        Dim Filiere As String
        Dim Groupe_TD As String
        Dim Groupe_TP As String
        Dim Heures_absence As Integer
    End Structure
    Public tab_etud_CDN(500) As Etudiant


    Structure Personnel
        Dim Nom As String
        Dim Matiere As String
        Dim Sexe As String
        Dim Statut As String
        Dim ID_pers As String
        Dim Heure_abse As String
    End Structure
    Public tab_pers(100) As Personnel

    Structure abs_INS
        Dim Tranche As String
        Dim nrbe_abs As Integer
    End Structure
    Public tab_abs_INS(5) As abs_INS

    Structure abs_ISN
        Dim Tranche As String
        Dim nrbe_abs As Integer
    End Structure
    Public tab_abs_ISN(5) As abs_INS

    Structure abs_CDN
        Dim Tranche As String
        Dim nrbe_abs As Integer
    End Structure
    Public tab_abs_CDN(5) As abs_INS

    Structure abs_total
        Dim Tranche As String
        Dim nrbe_abs As Integer
    End Structure
    Public tab_abs_total(5) As abs_INS

    Sub Stat()
        Dim i, n, c, s As Integer

        i = 0
        n = 0
        c = 0
        s = 0




        While tab_etud(i).Nom <> ""

            If tab_etud(i).Heures_absence < 11 Then
                tab_abs_total(0).Tranche = "Entre 0h et 10h"
                tab_abs_total(0).nrbe_abs += 1
            ElseIf tab_etud(i).Heures_absence > 10 And tab_etud(i).Heures_absence < 51 Then
                tab_abs_total(1).Tranche = "Entre 11h et 50h"
                tab_abs_total(1).nrbe_abs += 1
            ElseIf tab_etud(i).Heures_absence > 50 And tab_etud(i).Heures_absence < 101 Then
                tab_abs_total(2).Tranche = "Entre 51h et 100h"
                tab_abs_total(2).nrbe_abs += 1
            ElseIf tab_etud(i).Heures_absence > 100 Then
                tab_abs_total(3).Tranche = "Plus de 100h"
                tab_abs_total(3).nrbe_abs += 1
            End If

            If tab_etud(i).Filiere = "INS" Then

                tab_etud_INS(n).Nom = tab_etud(i).Nom
                tab_etud_INS(n).Niveau = tab_etud(i).Niveau
                tab_etud_INS(n).Filiere = tab_etud(i).Filiere
                tab_etud_INS(n).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_INS(n).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_INS(n).Heures_absence = tab_etud(i).Heures_absence
                n += 1

                If tab_etud(i).Heures_absence < 11 Then
                    tab_abs_INS(0).Tranche = "Entre 0h et 10h"
                    tab_abs_INS(0).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 10 And tab_etud(i).Heures_absence < 51 Then
                    tab_abs_INS(1).Tranche = "Entre 11h et 50h"
                    tab_abs_INS(1).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 50 And tab_etud(i).Heures_absence < 101 Then
                    tab_abs_INS(2).Tranche = "Entre 51h et 100h"
                    tab_abs_INS(2).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 100 Then
                    tab_abs_INS(3).Tranche = "Plus de 100h"
                    tab_abs_INS(3).nrbe_abs += 1
                End If
            End If

            If tab_etud(i).Filiere = "CDN" Then

                tab_etud_CDN(c).Nom = tab_etud(i).Nom
                tab_etud_CDN(c).Niveau = tab_etud(i).Niveau
                tab_etud_CDN(c).Filiere = tab_etud(i).Filiere
                tab_etud_CDN(c).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_CDN(c).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_CDN(c).Heures_absence = tab_etud(i).Heures_absence
                c += 1

                If tab_etud(i).Heures_absence < 11 Then
                    tab_abs_CDN(0).Tranche = "Entre 0h et 10h"
                    tab_abs_CDN(0).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 10 And tab_etud(i).Heures_absence < 51 Then
                    tab_abs_CDN(1).Tranche = "Entre 11h et 50h"
                    tab_abs_CDN(1).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 50 And tab_etud(i).Heures_absence < 101 Then
                    tab_abs_CDN(2).Tranche = "Entre 51h et 100h"
                    tab_abs_CDN(2).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 100 Then
                    tab_abs_CDN(3).Tranche = "Plus de 100h"
                    tab_abs_CDN(3).nrbe_abs += 1
                End If
            End If

            If tab_etud(i).Filiere = "ISN" Then

                tab_etud_ISN(s).Nom = tab_etud(i).Nom
                tab_etud_ISN(s).Niveau = tab_etud(i).Niveau
                tab_etud_ISN(s).Filiere = tab_etud(i).Filiere
                tab_etud_ISN(s).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_ISN(s).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_ISN(s).Heures_absence = tab_etud(i).Heures_absence
                s += 1

                If tab_etud(i).Heures_absence < 11 Then
                    tab_abs_ISN(0).Tranche = "Entre 0h et 10h"
                    tab_abs_ISN(0).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 10 And tab_etud(i).Heures_absence < 51 Then
                    tab_abs_ISN(1).Tranche = "Entre 11h et 50h"
                    tab_abs_ISN(1).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 50 And tab_etud(i).Heures_absence < 101 Then
                    tab_abs_ISN(2).Tranche = "Entre 51h et 100h"
                    tab_abs_ISN(2).nrbe_abs += 1
                ElseIf tab_etud(i).Heures_absence > 100 Then
                    tab_abs_ISN(3).Tranche = "Plus de 100h"
                    tab_abs_ISN(3).nrbe_abs += 1
                End If
            End If

            i += 1
        End While
    End Sub

    Function pdf_absences() As String
        Try
            Dim pdf_doc As New Document(PageSize.A4, 40, 40, 40, 20)
            Dim emplacement As New SaveFileDialog
            Dim choix As String = ""

            emplacement.Filter = "Absences|*.pdf"
            If emplacement.ShowDialog = 1 Then
                choix = emplacement.FileName

            End If

            Dim pdf_ecrir As PdfWriter = PdfWriter.GetInstance(pdf_doc, New FileStream(choix, FileMode.Create))
            Dim p As New Paragraph
            Dim cell As PdfPCell = New PdfPCell

            Dim Ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim f As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fa As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            pdf_doc.Open()

            Dim im As Image = Image.GetInstance("UIECC.JPG")
            im.ScalePercent(60.0F)
            im.Alignment = LeftRightAlignment.Right
            pdf_doc.Add(im)

            p = New Paragraph(vbNewLine & "Liste des absences" & vbNewLine & "", f)
            p.Alignment = Element.ALIGN_CENTER

            p.Font.Size = 14
            p.SpacingAfter = 10.0F
            pdf_doc.Add(p)
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            p = New Paragraph(vbNewLine & "CREATION ET DISIGN NUMERIQUE" & vbNewLine & "", f)
            p.Alignment = Element.ALIGN_LEFT

            p.Font.Size = 10
            p.SpacingAfter = 10.0F
            pdf_doc.Add(p)

            Dim table As New PdfPTable(4)
            table.TotalWidth = 550.0F
            table.LockedWidth = True
            table.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 4

            table.AddCell(New Phrase("Noms et prenoms", f))
            table.AddCell(New Phrase("Groupe de TD", f))
            table.AddCell(New Phrase("Groupe de TP", f))
            table.AddCell(New Phrase("Nombre d'heures d'absences", f))
            Dim count_cdn As Integer
            count_cdn = 0
            While tab_etud_CDN(count_cdn).Nom <> ""
                count_cdn += 1
            End While

            For i = 0 To count_cdn - 1
                table.AddCell(New Phrase(tab_etud_CDN(i).Nom, Ptable))
                table.AddCell(New Phrase(tab_etud_CDN(i).Groupe_TD, Ptable))
                table.AddCell(New Phrase(tab_etud_CDN(i).Groupe_TP, Ptable))
                table.AddCell(New Phrase(tab_etud_CDN(i).Heures_absence, Ptable))
            Next i
            pdf_doc.Add(table)
            ' pdf_doc.Add(p)


            ' Tableau 2

            p = New Paragraph(vbNewLine & "INGENIERIE DES SYSTEMES NUMERIQUES" & vbNewLine & "", f)
            p.Font.Size = 10
            p.SpacingAfter = 10.0F
            p.Alignment = Element.ALIGN_LEFT
            pdf_doc.Add(p)

            Dim table1 As New PdfPTable(4)
            table1.TotalWidth = 550.0F
            table1.LockedWidth = True
            table1.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 4


            table1.AddCell(New Phrase("Nom et prenoms", f))
            table1.AddCell(New Phrase("Groupe de TD", f))
            table1.AddCell(New Phrase("Groupe de TP", f))
            table1.AddCell(New Phrase("Nombre d'heures d'absences", f))
            Dim count_ISN As Integer
            count_ISN = 0
            While tab_etud_ISN(count_ISN).Nom <> ""
                count_ISN += 1
            End While
            For i = 0 To count_ISN - 1
                table1.AddCell(New Phrase(tab_etud_ISN(i).Nom, Ptable))
                table1.AddCell(New Phrase(tab_etud_ISN(i).Groupe_TD, Ptable))
                table1.AddCell(New Phrase(tab_etud_ISN(i).Groupe_TP, Ptable))
                table1.AddCell(New Phrase(tab_etud_ISN(i).Heures_absence, Ptable))
            Next i
            pdf_doc.Add(table1)

            '3eme tableau
            p = New Paragraph(vbNewLine & "INGENIERIE NUMERIQUE SOCIOTECHNIQUE" & vbNewLine & "", f)

            p.Font.Size = 10
            p.SpacingAfter = 10.0F
            p.Alignment = Element.ALIGN_LEFT


            pdf_doc.Add(p)

            Dim table2 As New PdfPTable(4)
            table2.TotalWidth = 550.0F
            table2.LockedWidth = True
            table2.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 4
            table2.TotalWidth = 550.0F

            cell.Colspan = 4

            Dim table4 As New PdfPTable(4)
            table4.TotalWidth = 550.0F
            table4.LockedWidth = True
            table4.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 4

            table2.AddCell(New Phrase("Nom et prenoms", f))
            table2.AddCell(New Phrase("Groupe TD", f))
            table2.AddCell(New Phrase("Groupe TP", f))
            table2.AddCell(New Phrase("Nombre d'heures d'absence", f))
            Dim count_ins As Integer
            count_ins = 0
            While tab_etud_INS(count_ins).Nom <> ""
                count_ins += 1
            End While
            For i = 0 To count_ins - 1
                table2.AddCell(New Phrase(tab_etud_INS(i).Nom, Ptable))
                table2.AddCell(New Phrase(tab_etud_INS(i).Groupe_TD, Ptable))
                table2.AddCell(New Phrase(tab_etud_INS(i).Groupe_TP, Ptable))
                table2.AddCell(New Phrase(tab_etud_INS(i).Heures_absence, Ptable))

            Next
            pdf_doc.Add(table2)

            pdf_doc.Close()

            Dim sms As String
            sms = ("Le fichier pdf a été enrégistré avec succès dans l'emplacement " & choix)
            MsgBox(sms, 1, "SmartPoint")
            Return sms
        Catch ex As Exception
            Dim sms As String
            sms = ("le fichier pdf n'a pas été enrégistré car " & ex.Message)
            MsgBox(sms, 1, "SmartPoint")
            Return sms
        End Try

    End Function

    Public Function identifiants() As String
        Try
            Dim pdf_doc As New Document(PageSize.A4, 40, 40, 40, 20)
            Dim emplacement As New SaveFileDialog
            Dim choix As String = ""

            emplacement.Filter = "Identifiants|*.pdf"
            If emplacement.ShowDialog = 1 Then
                choix = emplacement.FileName
            End If

            Dim pdf_ecrir As PdfWriter = PdfWriter.GetInstance(pdf_doc, New FileStream(choix, FileMode.Create))
            Dim p As New Paragraph
            Dim cell As PdfPCell = New PdfPCell

            Dim Ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim f As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fa As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            pdf_doc.Open()

            Dim im As Image = Image.GetInstance("UIECC.JPG")
            im.ScalePercent(60.0F)
            im.Alignment = LeftRightAlignment.Right
            pdf_doc.Add(im)


            p = New Paragraph(vbNewLine & "Liste des identifiants" & vbNewLine & "", fa)
            p.Alignment = Element.ALIGN_CENTER
            p.Font.Size = 14
            p.SpacingAfter = 10.0F
            pdf_doc.Add(p)
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            p = New Paragraph(vbNewLine & "CREATION ET DISIGN NUMERIQUE" & vbNewLine & "", f)
            p.Alignment = Element.ALIGN_LEFT

            p.Font.Size = 10
            p.SpacingAfter = 10.0F
            pdf_doc.Add(p)

            Dim table As New PdfPTable(2)
            table.TotalWidth = 550.0F
            table.LockedWidth = True
            table.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 2

            Dim count_CDN As Integer
            count_CDN = 0
            While tab_etud_CDN(count_CDN).Nom <> ""
                count_CDN += 1
            End While

            table.AddCell(New Phrase("Noms", f))
            table.AddCell(New Phrase("Identifiant", f))



            MsgBox(count_CDN)
            For i = 0 To count_CDN - 1

                table.AddCell(New Phrase(tab_etud_CDN(i).Nom, Ptable))
                table.AddCell(New Phrase(tab_etud_CDN(i).ID_Etud, Ptable))

            Next i
            pdf_doc.Add(table)

            ' Tableau 2

            p = New Paragraph(vbNewLine & "INGENIERIE DES SYSTEMES NUMERIQUES" & vbNewLine & "", f)
            p.Font.Size = 10
            p.Alignment = Element.ALIGN_MIDDLE
            p.SpacingAfter = 10.0F
            pdf_doc.Add(p)

            Dim table1 As New PdfPTable(2)
            table1.TotalWidth = 550.0F
            table1.LockedWidth = True
            table1.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 2

            Dim count_ISN As Integer
            count_ISN = 0
            While tab_etud_ISN(count_ISN).Nom <> ""
                count_ISN += 1
            End While

            table1.AddCell(New Phrase("Noms", f))
            table1.AddCell(New Phrase("Identifiant", f))

            For i = 0 To count_ISN - 1

                table1.AddCell(New Phrase(tab_etud_ISN(i).Nom, Ptable))
                table1.AddCell(New Phrase(tab_etud_ISN(i).ID_Etud, Ptable))

            Next i
            pdf_doc.Add(table1)
            '3eme tableau
            p = New Paragraph(vbNewLine & "INGENIERIE NUMERIQUE SOCIOTECHNIQUE" & vbNewLine & "", f)

            p.Font.Size = 10
            p.Alignment = Element.ALIGN_LEFT
            p.SpacingAfter = 10.0F

            pdf_doc.Add(p)


            Dim table2 As New PdfPTable(2)
            table2.TotalWidth = 550.0F
            table2.LockedWidth = True
            table2.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 2
            table2.TotalWidth = 550.0F

            cell.Colspan = 2

            Dim count_INS As Integer
            count_INS = 0
            While tab_etud_ISN(count_INS).Nom <> ""
                count_INS += 1
            End While

            table2.AddCell(New Phrase("Noms", f))
            table2.AddCell(New Phrase("Identifiant", f))

            For i = 0 To count_INS - 1
                table2.AddCell(New Phrase(tab_etud_INS(i).Nom, Ptable))
                table2.AddCell(New Phrase(tab_etud_INS(i).ID_Etud, Ptable))

            Next i
            pdf_doc.Add(table2)
            pdf_doc.Close()


            Dim sms As String
            sms = ("Le fichier pdf a été enrégistré avec succès dans l'emplacement " & choix)
            MsgBox(sms, 1, "Smart-Point")
            Return sms
        Catch ex As Exception
            Dim sms As String
            sms = ("le fichier pdf n'a pas été enrégistré car " & ex.Message)
            MsgBox(sms)
            Return sms
        End Try
    End Function

    Public Function Dispositifs() As String

        Try
            Dim pdf_doc As New Document(PageSize.A4, 40, 40, 40, 20)
            Dim emplacement As New SaveFileDialog
            Dim choix As String = ""

            emplacement.Filter = "Dispositifs|*.pdf"
            If emplacement.ShowDialog = 1 Then
                choix = emplacement.FileName
            End If

            Dim pdf_ecrir As PdfWriter = PdfWriter.GetInstance(pdf_doc, New FileStream(choix, FileMode.Create))
            Dim p As New Paragraph
            Dim cell As PdfPCell = New PdfPCell

            Dim Ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim f As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fa As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            pdf_doc.Open()

            Dim im As Image = Image.GetInstance("UIECC.JPG")
            im.ScalePercent(60.0F)
            im.Alignment = LeftRightAlignment.Right
            pdf_doc.Add(im)


            p = New Paragraph(vbNewLine & "Liste des dispositifs" & vbNewLine & "", fa)
            p.Alignment = Element.ALIGN_CENTER

            p.Font.Size = 14
            pdf_doc.Add(p)
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            p = New Paragraph(vbNewLine & "CREATION ET DISIGN NUMERIQUE" & vbNewLine & "", f)
            p.Alignment = Element.ALIGN_LEFT
            p.SpacingAfter = 10.0F
            p.Font.Size = 10

            pdf_doc.Add(p)

            Dim table As New PdfPTable(3)
            table.TotalWidth = 550.0F
            table.LockedWidth = True
            table.HorizontalAlignment = Element.ALIGN_CENTER

            table.AddCell(New Phrase("ID dispositif", f))
            table.AddCell(New Phrase("Salles", f))
            table.AddCell(New Phrase("Date d'enregistrement du dispositif", f))

            Dim count_id As Integer
            count_id = 0
            While Tab_disp(count_id).ID_Disp <> ""
                count_id += 1
            End While
            MsgBox(count_id)
            For i = 0 To count_id - 1
                MsgBox(Tab_disp(i).ID_Disp)
                table.AddCell(New Phrase(Tab_disp(i).ID_Disp, Ptable))
                table.AddCell(New Phrase(Tab_disp(i).Salle, Ptable))
                table.AddCell(New Phrase(Tab_disp(i).Date_enregis, Ptable))
            Next i
            pdf_doc.Add(table)
            pdf_doc.Close()
            Dim sms As String

            sms = ("Le fichier pdf a été enrégistré avec succès dans l'emplacement " & choix)
            MsgBox(sms)
            Return sms
        Catch ex As Exception
            Dim sms As String
            sms = ("le fichier pdf n'a pas été enrégistré car " & ex.Message)
            MsgBox(sms)
            Return sms
        End Try

    End Function

    Public Function Personne() As String

        Try
            Dim pdf_doc As New Document(PageSize.A4, 40, 40, 40, 20)
            Dim emplacement As New SaveFileDialog
            Dim choix As String = ""

            emplacement.Filter = "Personnel|*.pdf"
            If emplacement.ShowDialog = 1 Then
                choix = emplacement.FileName
            End If

            Dim pdf_ecrir As PdfWriter = PdfWriter.GetInstance(pdf_doc, New FileStream(choix, FileMode.Create))
            Dim p As New Paragraph
            Dim cell As PdfPCell = New PdfPCell

            Dim Ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim f As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fa As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            pdf_doc.Open()

            Dim im As Image = Image.GetInstance("UIECC.JPG")
            im.ScalePercent(60.0F)
            im.Alignment = LeftRightAlignment.Right
            pdf_doc.Add(im)


            p = New Paragraph(vbNewLine & "Liste du personnel" & vbNewLine & "", fa)
            p.Alignment = Element.ALIGN_CENTER

            p.Font.Size = 14
            pdf_doc.Add(p)
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            p = New Paragraph(vbNewLine & "CREATION ET DISIGN NUMERIQUE" & vbNewLine & "", f)
            p.Alignment = Element.ALIGN_LEFT
            p.SpacingAfter = 10.0F
            p.Font.Size = 10

            pdf_doc.Add(p)

            Dim table As New PdfPTable(2)
            table.TotalWidth = 550.0F
            table.LockedWidth = True
            table.HorizontalAlignment = Element.ALIGN_CENTER

            table.AddCell(New Phrase("Nom", f))
            table.AddCell(New Phrase("ID Personnel", f))


            Dim count_id As Integer
            count_id = 0
            While tab_pers(count_id).ID_pers <> ""
                count_id += 1
            End While
            For i = 0 To count_id - 1
                table.AddCell(New Phrase(tab_pers(i).Nom, Ptable))
                table.AddCell(New Phrase(tab_pers(i).ID_pers, Ptable))
            Next i
            pdf_doc.Add(table)
            pdf_doc.Close()
            Dim sms As String

            sms = ("Le fichier pdf a été enrégistré avec succès dans l'emplacement " & choix)
            MsgBox(sms)
            Return sms
        Catch ex As Exception
            Dim sms As String
            sms = ("le fichier pdf n'a pas été enrégistré car " & ex.Message)
            MsgBox(sms)
            Return sms
        End Try

    End Function
End Class
