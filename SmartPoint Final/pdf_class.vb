Imports Microsoft.VisualBasic
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class pdf
    Dim habsence As New Class2
    Shared aer As New Form3

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


            habsence.tab_etud_CDN(0).Nom = "arthur"
            habsence.tab_etud_CDN(0).Groupe_TD = "Ins"
            habsence.tab_etud_CDN(0).Groupe_TP = "Ins3"
            habsence.tab_etud_CDN(0).Heures_absence = 10
            habsence.tab_etud_CDN(1).Nom = "hardy"
            habsence.tab_etud_CDN(1).Groupe_TD = "Ins"
            habsence.tab_etud_CDN(1).Groupe_TP = "Ins3"
            habsence.tab_etud_CDN(1).Heures_absence = 5
            habsence.tab_etud_CDN(2).Nom = "andy"
            habsence.tab_etud_CDN(2).Groupe_TD = "Ins"
            habsence.tab_etud_CDN(2).Groupe_TP = "Ins1"
            habsence.tab_etud_CDN(2).Heures_absence = 300
            cell.Colspan = 4

            table.AddCell(New Phrase("Noms et prenoms", f))
            table.AddCell(New Phrase("Groupe de TD", f))
            table.AddCell(New Phrase("Groupe de TP", f))
            table.AddCell(New Phrase("Nombre d'heures d'absences", f))
            Dim count_cdn As Integer
            count_cdn = 0
            While habsence.tab_etud_CDN(count_cdn).Nom <> ""
                count_cdn += 1
            End While

            For i = 0 To count_cdn - 1
                table.AddCell(New Phrase(habsence.tab_etud_CDN(i).Nom, Ptable))
                table.AddCell(New Phrase(habsence.tab_etud_CDN(i).Groupe_TD, Ptable))
                table.AddCell(New Phrase(habsence.tab_etud_CDN(i).Groupe_TP, Ptable))
                table.AddCell(New Phrase(habsence.tab_etud_CDN(i).Heures_absence, Ptable))
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

            habsence.tab_etud_ISN(0).Nom = "arthur"
            habsence.tab_etud_ISN(0).Groupe_TD = "Ins"
            habsence.tab_etud_ISN(0).Groupe_TP = "Ins3"
            habsence.tab_etud_ISN(0).Heures_absence = 40
            habsence.tab_etud_ISN(1).Nom = "hardy"
            habsence.tab_etud_ISN(1).Groupe_TD = "Ins"
            habsence.tab_etud_ISN(1).Groupe_TP = "Ins3"
            habsence.tab_etud_ISN(1).Heures_absence = 60
            habsence.tab_etud_ISN(2).Nom = "andy"
            habsence.tab_etud_ISN(2).Groupe_TD = "Ins"
            habsence.tab_etud_ISN(2).Groupe_TP = "Ins1"
            habsence.tab_etud_ISN(2).Heures_absence = 100


            table1.AddCell(New Phrase("Nom et prenoms", f))
            table1.AddCell(New Phrase("Groupe de TD", f))
            table1.AddCell(New Phrase("Groupe de TP", f))
            table1.AddCell(New Phrase("Nombre d'heures d'absences", f))
            Dim count_ISN As Integer
            count_ISN = 0
            While habsence.tab_etud_ISN(count_ISN).Nom <> ""
                count_ISN += 1
            End While
            For i = 0 To count_ISN - 1
                table1.AddCell(New Phrase(habsence.tab_etud_ISN(i).Nom, Ptable))
                table1.AddCell(New Phrase(habsence.tab_etud_ISN(i).Groupe_TD, Ptable))
                table1.AddCell(New Phrase(habsence.tab_etud_ISN(i).Groupe_TP, Ptable))
                table1.AddCell(New Phrase(habsence.tab_etud_ISN(i).Heures_absence, Ptable))
            Next i
            pdf_doc.Add(table1)

            '3eme tableau
            p = New Paragraph(vbNewLine & "INGENIERIE NUMERIQUE SOCIOTECHNIQUE" & vbNewLine & "", f)

            p.Font.Size = 10
            p.SpacingAfter = 10.0F
            p.Alignment = Element.ALIGN_LEFT


            pdf_doc.Add(p)

            't.ouvertureBDD()
            't.SelectionEtudiant()
            't.SelectionUtilisateur()
            't.fermetureBDD()

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

            habsence.tab_etud_INS(0).Nom = "arthur"
            habsence.tab_etud_INS(0).Groupe_TD = "Ins"
            habsence.tab_etud_INS(0).Groupe_TP = "Ins3"
            habsence.tab_etud_INS(0).Heures_absence = 4
            habsence.tab_etud_INS(1).Nom = "hardy"
            habsence.tab_etud_INS(1).Groupe_TD = "Ins"
            habsence.tab_etud_INS(1).Groupe_TP = "Ins3"
            habsence.tab_etud_INS(1).Heures_absence = 10
            habsence.tab_etud_INS(2).Nom = "andy"
            habsence.tab_etud_INS(2).Groupe_TD = "Ins"
            habsence.tab_etud_INS(2).Groupe_TP = "Ins1"
            habsence.tab_etud_INS(2).Heures_absence = 40

            cell.Colspan = 4

            table4.AddCell(New Phrase("Nom et prenoms", f))
            table4.AddCell(New Phrase("Groupe TD", f))
            table4.AddCell(New Phrase("Groupe TP", f))
            table4.AddCell(New Phrase("Nombre d'heures d'absence", f))
            Dim count_ins As Integer
            count_ins = 0
            While habsence.tab_etud_INS(count_ins).Nom <> ""
                count_ins += 1
            End While
            For i = 0 To count_ins - 1
                table2.AddCell(New Phrase(habsence.tab_etud_INS(i).Nom, Ptable))
                table2.AddCell(New Phrase(habsence.tab_etud_INS(i).Groupe_TD, Ptable))
                table2.AddCell(New Phrase(habsence.tab_etud_INS(i).Groupe_TP, Ptable))
                table2.AddCell(New Phrase(habsence.tab_etud_INS(i).Heures_absence, Ptable))

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

            Module1.tab_etud_CDN(0).Nom = "arthur"
            Module1.tab_etud_CDN(1).Nom = "hardy"
            Module1.tab_etud_CDN(2).Nom = "andy"
            Module1.tab_etud_CDN(0).Niveau = "id289"
            Module1.tab_etud_CDN(1).Niveau = "id239"
            Module1.tab_etud_CDN(2).Niveau = "id269"

            Dim count_CDN As Integer
            count_CDN = 0
            While Module1.tab_etud_CDN(count_CDN).Nom <> ""
                count_CDN += 1
            End While

            table.AddCell(New Phrase("Noms", f))
            table.AddCell(New Phrase("Identifiant", f))



            MsgBox(count_CDN)
            For i = 0 To count_CDN - 1

                table.AddCell(New Phrase(Module1.tab_etud_CDN(i).Nom, Ptable))
                table.AddCell(New Phrase(Module1.tab_etud_CDN(i).Niveau, Ptable))

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
            Module1.tab_etud_ISN(0).Nom = "arthur"
            Module1.tab_etud_ISN(1).Nom = "hardy"
            Module1.tab_etud_ISN(2).Nom = "andy"
            Module1.tab_etud_ISN(0).Niveau = "id289"
            Module1.tab_etud_ISN(1).Niveau = "id239"
            Module1.tab_etud_ISN(2).Niveau = "id269"

            Dim count_ISN As Integer
            count_ISN = 0
            While Module1.tab_etud_ISN(count_ISN).Nom <> ""
                count_ISN += 1
            End While

            table1.AddCell(New Phrase("Noms", f))
            table1.AddCell(New Phrase("Identifiant", f))




            For i = 0 To count_ISN - 1

                table1.AddCell(New Phrase(Module1.tab_etud_ISN(i).Nom, Ptable))
                table1.AddCell(New Phrase(Module1.tab_etud_ISN(i).Niveau, Ptable))

            Next i
            pdf_doc.Add(table1)
            '3eme tableau
            p = New Paragraph(vbNewLine & "INGENIERIE NUMERIQUE SOCIOTECHNIQUE" & vbNewLine & "", f)

            p.Font.Size = 10
            p.Alignment = Element.ALIGN_LEFT
            p.SpacingAfter = 10.0F

            pdf_doc.Add(p)

            't.ouvertureBDD()
            't.SelectionEtudiant()
            't.SelectionUtilisateur()
            't.fermetureBDD()

            Dim table2 As New PdfPTable(2)
            table2.TotalWidth = 550.0F
            table2.LockedWidth = True
            table2.HorizontalAlignment = Element.ALIGN_CENTER

            cell.Colspan = 2
            table2.TotalWidth = 550.0F

            cell.Colspan = 2
            Module1.tab_etud_INS(0).Nom = "arthur"
            Module1.tab_etud_INS(1).Nom = "hardy"
            Module1.tab_etud_INS(2).Nom = "andy"
            Module1.tab_etud_INS(0).Niveau = "id289"
            Module1.tab_etud_INS(1).Niveau = "id239"
            Module1.tab_etud_INS(2).Niveau = "id269"


            Dim count_INS As Integer
            count_INS = 0
            While Module1.tab_etud_ISN(count_INS).Nom <> ""
                count_INS += 1
            End While

            table2.AddCell(New Phrase("Noms", f))
            table2.AddCell(New Phrase("Identifiant", f))




            For i = 0 To count_INS - 1
                table2.AddCell(New Phrase(Module1.tab_etud_INS(i).Nom, Ptable))
                table2.AddCell(New Phrase(Module1.tab_etud_INS(i).Niveau, Ptable))

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

            Dim id As New Class2

            cell.Colspan = 3


            table.AddCell(New Phrase("ID dispositif", f))
            table.AddCell(New Phrase("Salles", f))
            table.AddCell(New Phrase("Date d'enregistrement du dispositif", f))

            Dim count_id As Integer
            count_id = 0
            While Tab_disp(count_id).ID_Disp <> ""
                count_id += 1
            End While
            For i = 0 To count_id - 1
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

End Class
