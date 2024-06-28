Imports System.Windows.Forms.DataVisualization.Charting
Imports excel = Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
'Imports System.Net.Mail

Imports System.Data.SqlClient
Imports System.Net.Mail
Imports MySql.Data.MySqlClient




Public Class Form3

    Dim ps As New Class4
    Dim pu As Class4.T_UTILISATEUR
    Dim pe As New Class4.T_ETUDIANT
    Dim pp As New Class4.T_PERSONNEL
    Dim pd As New Class4.T_DISPOSITIF
    Dim ppr As New Class4.T_PROGRAMMES
    Dim po As New Class4.T_POINTAGE
    Dim app As excel.Application
    Dim book As excel.Workbook
    Dim sheet As excel.Worksheet
    Dim Module1 As New Class2





    Private Sub DispositifButton_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub GunaButton17_Click(sender As Object, e As EventArgs) Handles GunaButton17.Click
        Dim a As String
        Dim b As String
        Dim c As String
        Dim i As Integer = 0

        a = JourCombo.Text
        b = MoisCombo.Text
        c = AnnéeCombo.Text
        TextBox1.Text = c + "-" + b + "-" + a


        While tab_etud(i).Nom <> ""
            i += 1
        End While

        ps.ETUDIANT(0).Nom = NomEtuTextbox.Text
        NomEtuTextbox.Text = ""
        ps.ETUDIANT(0).Date_de_naissance = TextBox1.Text
        TextBox1.Text = ""
        ps.ETUDIANT(0).Niveau = NiveauCombobox.Text
        NiveauCombobox.Text = ""
        ps.ETUDIANT(0).Filiere = FilièreCombobox.Text
        FilièreCombobox.Text = ""

        If GunaRadioButton1.Checked = True Then
            ps.ETUDIANT(0).Sexe = "M"
        Else
            ps.ETUDIANT(0).Sexe = "F"
        End If

        GunaRadioButton1.Checked = False
        GunaRadioButton2.Checked = False

        ps.ETUDIANT(0).Groupe_TD = TDCombobox.Text
        TDCombobox.Text = ""
        ps.ETUDIANT(0).Groupe_TP = TPCombobox.Text
        TPCombobox.Text = ""
        ps.ETUDIANT(0).Matricule = MatTextbox.Text
        MatTextbox.Text = ""
        Dim tab_count = 0
        tab_count = EtudiantListview.Items.Count()

        If tab_count = 0 Then
            ps.ouverture_connection()
            ps.ETUDIANT(0).IDE = ps.genererIdEtudiant()
            ps.fermeture_connection()
            ps.ETUDIANT(0).Heures_absence = 0
        Else
            If EtudiantListview.Items(0).SubItems(8).Text = "2021A001" Then
                pe.Nom = EtudiantListview.Items(i).SubItems(0).Text
                pe.Date_de_naissance = CDate(EtudiantListview.Items(i).SubItems(1).Text)
                pe.Sexe = EtudiantListview.Items(i).SubItems(2).Text
                pe.Niveau = CInt(EtudiantListview.Items(i).SubItems(3).Text)
                pe.Filiere = EtudiantListview.Items(i).SubItems(4).Text
                pe.Groupe_TD = EtudiantListview.Items(i).SubItems(5).Text
                pe.Groupe_TP = EtudiantListview.Items(i).SubItems(6).Text
                pe.Matricule = EtudiantListview.Items(i).SubItems(7).Text
                pe.Heures_absence = 0
                pe.IDE = EtudiantListview.Items(i).SubItems(8).Text
                ps.ouverture_connection()
                ps.AjouterEtudiant(ETUDIANT:=pe)
                ps.fermeture_connection()
                For r = 0 To EtudiantListview.Items.Count() - 1
                    EtudiantListview.Items.Remove(EtudiantListview.Items(0))
                Next
            End If
            ps.ouverture_connection()
            ps.ETUDIANT(0).IDE = ps.genererIdEtudiant()
            ps.fermeture_connection()
            ps.ETUDIANT(0).Heures_absence = 0
        End If


            'EtudiantListview.Items.Clear()

            ' Ajouter des éléments à la listview

            Dim car As New ListViewItem
        car.Text = (ps.ETUDIANT(0).Nom)
        car.SubItems.Add(ps.ETUDIANT(0).Date_de_naissance)
        car.SubItems.Add(ps.ETUDIANT(0).Sexe)
        car.SubItems.Add(ps.ETUDIANT(0).Niveau)
        car.SubItems.Add(ps.ETUDIANT(0).Filiere)
        car.SubItems.Add(ps.ETUDIANT(0).Groupe_TD)
        car.SubItems.Add(ps.ETUDIANT(0).Groupe_TP)
        car.SubItems.Add(ps.ETUDIANT(0).Matricule)
        car.SubItems.Add(ps.ETUDIANT(0).IDE)
        car.SubItems.Add(ps.ETUDIANT(0).Heures_absence)

        EtudiantListview.Items.Add(car)

    End Sub

    Private Sub GunaComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs)
        If FilièreCombobox.SelectedIndex = 0 Then
            TDCombobox.Items.Clear()
            TDCombobox.Items.Add("CDN1")
            TDCombobox.Items.Add("CDN2")
        End If
        If FilièreCombobox.SelectedIndex = 1 Then
            TDCombobox.Items.Clear()
            TDCombobox.Items.Add("INS1")
            TDCombobox.Items.Add("INS2")
            TDCombobox.Items.Add("INS3")
            TDCombobox.Items.Add("INS4")
        End If
        If FilièreCombobox.SelectedIndex = 2 Then
            TDCombobox.Items.Clear()
            TDCombobox.Items.Add("ISN1")
            TDCombobox.Items.Add("ISN2")
            TDCombobox.Items.Add("ISN3")
            TDCombobox.Items.Add("ISN4")
        End If
        'Remplissage de la listview
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton12_Click(sender As Object, e As EventArgs) Handles GunaButton12.Click
        EtPanel.Visible = True
        PersPanel.Visible = False
        EtudiantListview.Visible = True
        PersonnelListview.Visible = False
    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        EtPanel.Visible = False
        PersPanel.Visible = True
        EtudiantListview.Visible = False
        PersonnelListview.Visible = True
    End Sub

    Private Sub GunaButton11_Click(sender As Object, e As EventArgs) Handles GunaButton11.Click
        Dim ID As String
        Dim bool As Boolean = False
        Dim present As Boolean = False
        Dim absence As Integer = 0
        Dim heureBDD As Integer = 0
        Dim a, m, jo As String
        Dim temps As Date

        For f = 0 To ListView7.Items.Count() - 1
            For r = 0 To ListView2.Items.Count() - 1
                If ListView7.Items(f).SubItems(1).Text = ListView2.Items(r).SubItems(1).Text Then
                    Dim car As New ListViewItem

                    po.IDD = ListView7.Items(f).SubItems(0).Text
                    car.Text = po.IDD
                    ID = ListView7.Items(f).SubItems(1).Text.Chars(4)

                    If ID = "B" Then
                        po.IDP = ListView7.Items(f).SubItems(1).Text
                        po.IDE = ""
                        car.SubItems.Add(po.IDP)
                    Else
                        po.IDE = ListView7.Items(f).SubItems(1).Text
                        po.IDP = ""
                        car.SubItems.Add(po.IDE)
                    End If

                    a = ListView7.Items(f).SubItems(2).Text.Split(".")(2)
                    m = ListView7.Items(f).SubItems(2).Text.Split(".")(1)
                    jo = ListView7.Items(f).SubItems(2).Text.Split(".")(0)
                    temps = a + "-" + m + "-" + jo
                    po.Dates = temps
                    car.SubItems.Add(po.Dates)
                    po.Heures = ListView7.Items(f).SubItems(3).Text
                    car.SubItems.Add(po.Heures)
                    ps.ouverture_connection()
                    ps.Ajouterpointage(POINTAGE:=po)
                    ps.fermeture_connection()
                    ListView6.Items.Add(car)
                End If
            Next
        Next
        If ps.n = True Then
            MsgBox("LES POINTAGE A ÉTÉ ÉFFECTUÉ", MsgBoxStyle.Information)
        Else
            MsgBox("LE POINTAGE N'A PAS PU ETRE ÉFFECTUÉ", MsgBoxStyle.Critical)
        End If

        'Pour savoir si L'enseignant donant cours est belle et bien programmé
        For i = 0 To ListView6.Items.Count() - 1
            ID = ListView6.Items(i).SubItems(0).Text.Chars(4)
            If ID = "B" Then
                bool = True
                po.IDD = ListView6.Items(i).SubItems(0).Text
                pp.IDP = ListView6.Items(i).SubItems(1).Text
            End If
        Next
        ' Savoir si c'est un cours magistrale ou un td pour pouvoir generer les heures d'absences
        po.Dates = ListView6.Items(0).SubItems(2).Text
        po.Heures = ListView6.Items(0).SubItems(3).Text
        If bool = True Then
            ps.ouverture_connection()
            ps.TD_CM(point:=po)
            ps.fermeture_connection()
            If ps.PERSONNEL(ps.p - 1).Statut = "Enseignant principal" Then
                absence = 4
            Else
                absence = 2
            End If
            If ps.PERSONNEL(ps.p - 1).IDP = pp.IDP Then
                heureBDD = ps.PERSONNEL(ps.p - 1).heures
                pp.heures = heureBDD + absence
                ps.ouverture_connection()
                ps.ModifHeures_presence(personne:=pp)
                ps.fermeture_connection()
            End If
        Else
            ps.ouverture_connection()
            ps.TD_CM(point:=po)
            ps.fermeture_connection()
            If ps.PERSONNEL(ps.p).Statut = "Enseignant principal" Then
                absence = 4
            Else
                absence = 2
            End If
        End If

        For i = 0 To ps.p - 1
            If ps.PROGRAMMES(i).Groupe.Length <= 3 Then
                'Controle des etudiants présent (c'est dans le cas d'une filiere entiere)
                po.IDD = ListView6.Items(0).SubItems(0).Text
                po.Heures = (ListView6.Items(0).SubItems(3).Text)

                po.Dates = ListView6.Items(0).SubItems(2).Text
                ps.ouverture_connection()
                'Liste des etudiants censé etre présent
                ps.liste_etudiant_toutefiliere(point:=po)
                ps.fermeture_connection()

                For l = 0 To ps.f - 1
                    present = False
                    'Comparaison avec les etudiants dans la listview pour avoir des correspondances
                    For j = 0 To ListView6.Items.Count() - 1
                        If ps.ETUDIANT(l).IDE = ListView7.Items(j).SubItems(1).Text Then
                            present = True
                        End If
                    Next
                    'Si il n'y a aucune correspondance on increment alors ses heures d'absences
                    If present = False Then
                        heureBDD = ps.ETUDIANT(l).Heures_absence
                        pe.Heures_absence = heureBDD + absence
                        'MsgBox(pe.Heures_absence)
                        pe.IDE = ps.ETUDIANT(l).IDE
                        ps.ouverture_connection()
                        ps.ModifHeures_absences(ETUDIANT:=pe)
                        ps.fermeture_connection()
                    End If
                Next
            Else
                'Controle des etudiants présent (c'est dans le cas d'une groupe de td)
                po.IDD = ListView6.Items(0).SubItems(0).Text
                po.Heures = (ListView6.Items(0).SubItems(3).Text)
                po.Dates = ListView6.Items(0).SubItems(2).Text
                ps.ouverture_connection()
                'Liste des etudiants censé etre présent
                ps.liste_etudiant_grouptp(point:=po)
                ps.fermeture_connection()

                For w = 0 To ps.b - 1
                    present = False
                    'Comparaison avec les etudiants dans la listview pour avoir des correspondances
                    For j = 0 To ListView6.Items.Count() - 1
                        If ps.ETUDIANT(w).IDE = ListView6.Items(j).SubItems(1).Text Then
                            present = True
                        End If
                    Next
                    'Si il n'y a aucune correspondance on increment alors ses heures d'absences
                    If present = False Then
                        heureBDD = ps.ETUDIANT(w).Heures_absence
                        pe.Heures_absence = heureBDD + absence
                        'MsgBox(pe.Heures_absence)
                        pe.IDE = ps.ETUDIANT(w).IDE
                        ps.ouverture_connection()
                        ps.ModifHeures_absences(ETUDIANT:=pe)
                        ps.fermeture_connection()
                    End If
                Next
            End If
        Next


        If ps.n = True Then
            MsgBox("LES HEURES ONT ÉTÉ GÉNÉRÉ", MsgBoxStyle.Information)
            pd.IDD = ListView6.Items(0).SubItems(0).Text
            ps.ouverture_connection()
            ps.ModifDispositif(DISPOSITIF:=pd)
            ps.fermeture_connection()
            For r = 0 To ListView6.Items.Count() - 1
                ListView6.Items.Remove(ListView6.Items(0))
            Next
            For r = 0 To ListView7.Items.Count() - 1
                ListView7.Items.Remove(ListView7.Items(0))
            Next
            For r = 0 To ListView2.Items.Count() - 1
                ListView2.Items.Remove(ListView2.Items(0))
            Next
        Else
            MsgBox("LES HEURES N'ONT PAS ÉTÉ GÉNÉRÉ", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub GunaButton19_Click(sender As Object, e As EventArgs) Handles GunaButton19.Click
        Dim i As Integer = 0
        PersonnelListview.Refresh()
        ps.ni = PersonnelListview.Items.Count()
        ps.ni = ps.ni + 1
        While tab_pers(i).Nom <> ""
            i += 1
        End While

        ps.PERSONNEL(0).Nom = GunaTextBox3.Text
        GunaTextBox3.Text = ""
        ps.PERSONNEL(0).Matiere = GunaTextBox4.Text
        GunaTextBox4.Text = ""

        If GunaRadioButton4.Checked = True Then
            ps.PERSONNEL(0).Sexe = "M"
        Else
            ps.PERSONNEL(0).Sexe = "F"
        End If
        GunaRadioButton4.Checked = False
        GunaRadioButton3.Checked = False

        ps.PERSONNEL(0).Statut = GunaComboBox10.Text
        ps.PERSONNEL(0).salaire_par_heure = GunaTextBox1.Text
        GunaTextBox1.Text = ""
        ps.ouverture_connection()
        ps.PERSONNEL(0).IDP = ps.genererIdPersonnel()
        ps.fermeture_connection()
        ps.PERSONNEL(0).heures = 0

        'PersonnelListview.Items.Clear()
        'Ajout dans la listview

        Dim car As New ListViewItem
        car.Text = (ps.PERSONNEL(0).Nom)
        car.SubItems.Add(ps.PERSONNEL(0).Matiere)
        car.SubItems.Add(ps.PERSONNEL(0).Sexe)
        car.SubItems.Add(ps.PERSONNEL(0).Statut)
        car.SubItems.Add(ps.PERSONNEL(0).salaire_par_heure)
        car.SubItems.Add(ps.PERSONNEL(0).IDP)

        PersonnelListview.Items.Add(car)
    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click


        ' Verification

        Dim valider As Boolean = False
        'Validation pour l'identifiant
        If GunaLineTextBox22.Text.Length < 3 Or GunaLineTextBox22.Text.Length > 10 Then
            GunaLineTextBox22.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox22, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox22.Text = "" Then
            GunaLineTextBox22.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = False
        Else
            GunaLineTextBox22.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If

        'Validation pour le mot de passe
        If GunaLineTextBox21.Text = "" Then
            GunaLineTextBox21.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox21, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox21.Text.Length < 6 Then
            GunaLineTextBox21.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox21, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox21.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If
        If valider = True Then
            pu.IDU = ""
            pu.IDU = GunaLineTextBox22.Text
            pu.MDP = GunaLineTextBox21.Text
            ps.idu = pu.IDU
            ps.ouverture_connection()
            ps.authentification_admin(util:=pu)
            ps.fermeture_connection()
            If ps.n = True Then
                VerificationPanel.Visible = False
                ProfilPanel.Visible = True
                GunaLabel36.Text = ps.Utilisateur(ps.p - 1).Nom
                GunaLabel35.Text = ps.Utilisateur(ps.p - 1).IDU
            Else
                MsgBox("Veuillez verifier vos informations", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        ProfilPanel.Visible = False
        ModComAdmin.Visible = True
        GunaTileButton1.SendToBack()


    End Sub

    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        VerificationPanel.Visible = True
        GunaTileButton1.SendToBack()

    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click


        'Modifier un compte

        Dim valider As Boolean = False
        'Validation pour le nom
        If GunaLineTextBox15.Text = "" Then
            GunaLineTextBox15.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox15, "Veuillez entrer votre nom")
            valider = False
        ElseIf GunaLineTextBox15.Text.Length <= 2 Then
            GunaLineTextBox15.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox15, "Votre nom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox15.LineColor = Color.LightSkyBlue
            ErrorProvider1.Dispose()
            valider = True
        End If

        'Validation pour le prenom
        If GunaLineTextBox13.Text = "" Then
            GunaLineTextBox13.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox13, "Veuillez entrer votre prénom ")
            valider = False
        ElseIf GunaLineTextBox13.Text.Length <= 2 Then
            GunaLineTextBox13.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox13, "Votre prénom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox13.LineColor = Color.LightSkyBlue
            ErrorProvider2.Dispose()
            valider = True
        End If

        'Validation pour l'identifiant
        If GunaLineTextBox16.Text.Length < 3 Or GunaLineTextBox16.Text.Length > 10 Then
            GunaLineTextBox16.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox16, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox16.Text = "" Then
            GunaLineTextBox16.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = False
        Else
            GunaLineTextBox16.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If

        'Validation pour le mot de passe
        If GunaLineTextBox12.Text = "" Then
            GunaLineTextBox12.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox12, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox12.Text.Length < 6 Then
            GunaLineTextBox12.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox12, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox12.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        'Validation pour la confirmation
        If GunaLineTextBox14.Text = "" Then
            GunaLineTextBox14.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox14, "Veuillez confirmer votre mot de passe")
            valider = False

        ElseIf GunaLineTextBox14.Text <> GunaLineTextBox12.Text Then
            GunaLineTextBox14.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox14, "Les mots de passe ne correspondent pas")
            valider = False

        Else
            GunaLineTextBox14.LineColor = Color.LightSkyBlue
            ErrorProvider5.Dispose()
            valider = True
        End If
        If valider = True Then
            pu.Nom = GunaLineTextBox15.Text
            pu.Prenoms = GunaLineTextBox13.Text
            pu.IDU = GunaLineTextBox16.Text
            pu.MDP = GunaLineTextBox12.Text
            pu.Statut = "Administrateur"
            ps.ouverture_connection()
            ps.ModifUtilisateur(UTILISATEUR:=pu)
            ps.fermeture_connection()
            If ps.n = True Then
                MsgBox("ok")
                ModComAdmin.Visible = False
            Else
                MsgBox("not ok")
            End If
        End If
    End Sub

    Private Sub GunaTileButton2_Click(sender As Object, e As EventArgs) Handles GunaTileButton2.Click
        ChoixPanel.Visible = True
        GunaTileButton2.SendToBack()

    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click
        ChangMDPPanel.Visible = True
        ChoixPanel.Visible = False
    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        AdminPanel.Visible = True
        ChoixPanel.Visible = False
    End Sub

    Private Sub GunaButton14_Click(sender As Object, e As EventArgs) Handles GunaButton14.Click


        ' Administrateur

        Dim valider As Boolean = False

        'Validation pour le mot de passe
        If GunaLineTextBox18.Text = "" Then
            GunaLineTextBox18.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox18, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox18.Text.Length < 6 Then
            GunaLineTextBox18.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox18, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox18.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        ' ID
        'Validation pour l'identifiant
        If GunaLineTextBox24.Text.Length < 3 Or GunaLineTextBox24.Text.Length > 10 Then
            GunaLineTextBox24.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox24, "Votre ID doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox24.Text = "" Then
            GunaLineTextBox24.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = False
        Else
            GunaLineTextBox24.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If
        If valider = True Then
            pu.IDU = ""
            pu.IDU = GunaLineTextBox24.Text
            pu.MDP = GunaLineTextBox18.Text
            ps.idu = pu.IDU
            ps.ouverture_connection()
            ps.authentification(util:=pu)
            ps.fermeture_connection()
            If ps.n = True Then
                AdminPanel.Visible = False
                CReatePanel.Visible = True
            Else
                MsgBox("Veuillez verifier vos informations", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub GunaButton15_Click(sender As Object, e As EventArgs) Handles GunaButton15.Click
        ChoixPanel.Visible = False
        CReatePanel.Visible = False

        'Créer un compte

        Dim valider As Boolean = False

        'Validation pour le nom
        If GunaLineTextBox29.Text = "" Then
            GunaLineTextBox29.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox29, "Veuillez entrer votre nom")
            valider = False
        ElseIf GunaLineTextBox29.Text.Length <= 2 Then
            GunaLineTextBox29.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox29, "Votre nom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox29.LineColor = Color.LightSkyBlue
            ErrorProvider1.Dispose()
            valider = True
        End If

        'Validation pour le prenom
        If GunaLineTextBox27.Text = "" Then
            GunaLineTextBox27.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox27, "Veuillez entrer votre prénom ")
            valider = False
        ElseIf GunaLineTextBox27.Text.Length <= 2 Then
            GunaLineTextBox27.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox27, "Votre prénom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox27.LineColor = Color.LightSkyBlue
            ErrorProvider2.Dispose()
            valider = True
        End If

        'Validation pour l'identifiant
        If GunaLineTextBox25.Text.Length < 3 Or GunaLineTextBox25.Text.Length > 10 Then
            GunaLineTextBox25.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox25, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox25.Text = "" Then
            GunaLineTextBox25.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = False
        Else
            GunaLineTextBox25.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If

        If GunaComboBox3.Text = "" Then
            GunaComboBox3.BackColor = Color.Red
            ErrorProvider4.SetError(GunaComboBox3, "veillez choisir votre statut")
        End If
        'Validation pour le mot de passe
        If GunaLineTextBox26.Text = "" Then
            GunaLineTextBox26.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox26, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox26.Text.Length < 6 Then
            GunaLineTextBox26.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox26, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox26.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        'Validation pour la confirmation
        If GunaLineTextBox28.Text = "" Then
            GunaLineTextBox28.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox28, "Veuillez confirmer votre mot de passe")
            valider = False

        ElseIf GunaLineTextBox28.Text <> GunaLineTextBox26.Text Then
            GunaLineTextBox28.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox28, "Les mots de passe ne correspondent pas")
            valider = False

        Else
            GunaLineTextBox28.LineColor = Color.LightSkyBlue
            ErrorProvider5.Dispose()
            valider = True
        End If
        If valider = True Then
            pu.Nom = GunaLineTextBox29.Text
            pu.Prenoms = GunaLineTextBox27.Text
            pu.IDU = GunaLineTextBox25.Text
            pu.Statut = GunaComboBox3.SelectedItem.ToString
            pu.MDP = GunaLineTextBox26.Text
            ps.ouverture_connection()
            ps.AjoutUtilisateur(UTILISATEUR:=pu)
            ps.fermeture_connection()
            If ps.n = True Then
                MsgBox("ok")
            Else
                MsgBox("not ok")
            End If
        End If

    End Sub

    Private Sub GunaButton10_Click(sender As Object, e As EventArgs) Handles GunaButton10.Click
        ChangMDPPanel.Visible = False

        'Changer le mot de passe

        Dim valider As Boolean = False
        'Validation pour l'identifiant
        If GunaLineTextBox23.Text.Length < 3 Or GunaLineTextBox23.Text.Length > 10 Then
            GunaLineTextBox23.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox23, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox23.Text = "" Then
            GunaLineTextBox23.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = False
        Else
            GunaLineTextBox23.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If

        ' Validation de l'ancien mot de passe
        If GunaLineTextBox19.Text = "" Then
            GunaLineTextBox19.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox19, "Veillez entrer votre ancien mot de passe")
            valider = False
        Else
            GunaLineTextBox19.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        'Validation pour le mot de passe
        If GunaLineTextBox17.Text = "" Then
            GunaLineTextBox17.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox17, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox17.Text.Length < 6 Then
            GunaLineTextBox17.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox17, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox17.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        'Validation pour la confirmation
        If GunaLineTextBox20.Text = "" Then
            GunaLineTextBox20.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox20, "Veuillez confirmer votre mot de passe")
            valider = False

        ElseIf GunaLineTextBox20.Text <> GunaLineTextBox17.Text Then
            GunaLineTextBox20.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox20, "Les mots de passe ne correspondent pas")
            valider = False

        Else
            GunaLineTextBox20.LineColor = Color.LightSkyBlue
            ErrorProvider5.Dispose()
            valider = True
        End If

        If valider = True Then
            pu.IDU = GunaLineTextBox23.Text
            ps.idu = pu.IDU
            pu.MDP = GunaLineTextBox19.Text
            ps.ouverture_connection()
            ps.authentification(util:=pu)
            ps.fermeture_connection()
            If ps.n = True Then
                pu.MDP = GunaLineTextBox17.Text
                ps.ouverture_connection()
                ps.ModifMot_de_passe(UTILISATEUR:=pu)
                ps.fermeture_connection()
                If ps.n = True Then
                    MsgBox("ok")
                Else
                    MsgBox("non")
                End If
            Else
                MsgBox("verifier votre mot de  passe")
            End If
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Dim j As Integer
        j = 0
        While tab_etud_INS(j).Nom <> ""
            j += 1
        End While


        Menu.BringToFront()
        DispositifPanel.Visible = False
        ps.ouverture_connection()
        ps.SelectionEtudiant()
        't.SelectionDispositif()
        't.SelectionPersonnel()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            tab_etud(i).Nom = ps.ETUDIANT(i).Nom
            tab_etud(i).Date_de_Nais = ps.ETUDIANT(i).Date_de_naissance
            tab_etud(i).Niveau = ps.ETUDIANT(i).Niveau
            tab_etud(i).Filiere = ps.ETUDIANT(i).Filiere
            tab_etud(i).Sexe = ps.ETUDIANT(i).Sexe
            tab_etud(i).Groupe_TD = ps.ETUDIANT(i).Groupe_TD
            tab_etud(i).Groupe_TP = ps.ETUDIANT(i).Groupe_TP
            tab_etud(i).Matricule = ps.ETUDIANT(i).Matricule
            tab_etud(i).ID_Etud = ps.ETUDIANT(i).IDE
            tab_etud(i).Heures_absence = ps.ETUDIANT(i).Heures_absence
        Next

        For i = 0 To ps.p - 1
            If tab_etud(i).Filiere = "ins" Or tab_etud(i).Filiere = "INS" Or tab_etud(i).Filiere = "Ins" Then
                tab_etud_INS(i).Nom = tab_etud(i).Nom
                tab_etud_INS(i).Niveau = tab_etud(i).Niveau
                tab_etud_INS(i).Filiere = tab_etud(i).Filiere
                tab_etud_INS(i).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_INS(i).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_INS(i).Heures_absence = tab_etud(i).Heures_absence

            ElseIf tab_etud(i).Filiere = "CDN" Or tab_etud(i).Filiere = "Cdn" Or tab_etud(i).Filiere = "cdn" Then
                tab_etud_CDN(i).Nom = tab_etud(i).Nom
                tab_etud_CDN(i).Niveau = tab_etud(i).Niveau
                tab_etud_CDN(i).Filiere = tab_etud(i).Filiere
                tab_etud_CDN(i).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_CDN(i).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_CDN(i).Heures_absence = tab_etud(i).Heures_absence
            Else
                tab_etud_ISN(i).Nom = tab_etud(i).Nom
                tab_etud_ISN(i).Niveau = tab_etud(i).Niveau
                tab_etud_ISN(i).Filiere = tab_etud(i).Filiere
                tab_etud_ISN(i).Groupe_TD = tab_etud(i).Groupe_TD
                tab_etud_ISN(i).Groupe_TP = tab_etud(i).Groupe_TP
                tab_etud_ISN(i).Heures_absence = tab_etud(i).Heures_absence
            End If
        Next

        'For i = 0 To t.p - 1
        'Tab_disp(i).ID_Disp = t.DISPOSITIFS(i).IDD
        ' Tab_disp(i).Salle = t.DISPOSITIFS(i).Salle
        '  Tab_disp(i).Date_enregis = t.DISPOSITIFS(i).Dates
        ' Tab_disp(i).Date_last_import = t.DISPOSITIFS(i).Date_import
        'Tab_disp(i).Heure_last_impor = t.DISPOSITIFS(i).Heures
        ' Next
    End Sub

    Private Sub GunaGradientTileButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton1.Click
        If DispositifButton2.Checked = False Then
            DispositifButton2.Checked = True
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If

        ' Remplissage Combo date de naissance etudiant
        JourCombo.Items.Clear()
        AnnéeCombo.Items.Clear()
        For i = 1 To 31
            JourCombo.Items.Add(i)
        Next
        For i = 1950 To 2050
            AnnéeCombo.Items.Add(i)
        Next
        Menu.Visible = False
        ProgrPanel.Visible = False
        DispositifPanel.Visible = True
        Panel1.Visible = True
        TabControl1.SelectedIndex = 0

        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()

        ListView1.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.DISPOSITIFS(i).IDD)
            car.SubItems.Add(ps.DISPOSITIFS(i).Salle)
            car.SubItems.Add(ps.DISPOSITIFS(i).Dates)
            car.SubItems.Add(ps.DISPOSITIFS(i).Date_import)
            car.SubItems.Add(ps.DISPOSITIFS(i).Heures)
            ListView1.Items.Add(car)
        Next
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False
    End Sub

    Private Sub GunaGradientTileButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton2.Click
        If PersButton2.Checked = False Then
            PersButton2.Checked = True
            DispositifButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
            PersonnelPoan.BringToFront()
            PersonnelPoan.Visible = True
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        ' Remplissage Combo date de naissance etudiant
        JourCombo.Items.Clear()
        AnnéeCombo.Items.Clear()
        For i = 1 To 31
            JourCombo.Items.Add(i)
        Next
        For i = 1950 To 2050
            AnnéeCombo.Items.Add(i)
        Next
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True
        TabControl1.SelectedIndex = 1

        ListView3.Items.Clear()
        ListView4.Items.Clear()
        GunaElipsePanel6.BringToFront()
        ps.ouverture_connection()
        ps.SelectionEtudiant()

        Try
            For i = 0 To ps.p - 1
                ListView4.Items.Add(New ListViewItem({ps.ETUDIANT(i).Nom, ps.ETUDIANT(i).Date_de_naissance, ps.ETUDIANT(i).Sexe, ps.ETUDIANT(i).Niveau, ps.ETUDIANT(i).Filiere, ps.ETUDIANT(i).Groupe_TD, ps.ETUDIANT(i).Groupe_TP, ps.ETUDIANT(i).Matricule, ps.ETUDIANT(i).IDE, ps.ETUDIANT(i).Heures_absence}))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ps.SelectionPersonnel()
        Try
            For i = 0 To ps.p - 1
                ListView3.Items.Add(New ListViewItem({ps.PERSONNEL(i).Nom, ps.PERSONNEL(i).Matiere, ps.PERSONNEL(i).Sexe, ps.PERSONNEL(i).Statut, ps.PERSONNEL(i).IDP, ps.PERSONNEL(i).salaire_par_heure, ps.PERSONNEL(i).heures}))
            Next
        Catch ex As Exception

        End Try
        ps.fermeture_connection()
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False

    End Sub

    Private Sub GunaGradientTileButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton4.Click
        If GunaAdvenceButton1.Checked = False Then
            GunaAdvenceButton1.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        ProgrPanel.BringToFront()
        ProgrPanel.Visible = True
        Panel1.Visible = True

        'affichage
        UersPanel.Visible = True
        Menu.Visible = False
        TabControl1.SelectedIndex = 2

        GunaComboBox2.Items.Clear()
        ps.ouverture_connection()
        ps.SelectionPersonnel()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            GunaComboBox2.Items.Add(ps.PERSONNEL(i).Nom)
        Next
        GunaComboBox1.Items.Clear()
        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            GunaComboBox1.Items.Add(ps.DISPOSITIFS(i).Salle)
        Next
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False

    End Sub

    Private Sub GunaGradientTileButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton3.Click
        If GunaAdvenceButton2.Checked = False Then
            GunaAdvenceButton2.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True
        TabControl1.SelectedIndex = 3
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False

    End Sub

    Private Sub GunaGradientTileButton8_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton8.Click
        If GunaAdvenceButton4.Checked = False Then
            GunaAdvenceButton4.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("CDN")
        ps.fermeture_connection()

        ListViewCDN.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewCDN.Items.Add(car)
        Next

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("INS")
        ps.fermeture_connection()

        ListViewINS.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewINS.Items.Add(car)
        Next
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("ISN")
        ps.fermeture_connection()

        ListViewISN.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewISN.Items.Add(car)
        Next
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True
        TabControl1.SelectedIndex = 4

        tab_abs_INS(0).Tranche = "Entre 0h et 10h"
        tab_abs_INS(1).Tranche = "Entre 11h et 50h"
        tab_abs_INS(2).Tranche = "Entre 51h et 100h"
        tab_abs_INS(3).Tranche = "Plus de 100h"

        tab_abs_CDN(0).Tranche = "Entre 0h et 10h"
        tab_abs_CDN(1).Tranche = "Entre 11h et 50h"
        tab_abs_CDN(2).Tranche = "Entre 51h et 100h"
        tab_abs_CDN(3).Tranche = "Plus de 100h"

        tab_abs_ISN(0).Tranche = "Entre 0h et 10h"
        tab_abs_ISN(1).Tranche = "Entre 11h et 50h"
        tab_abs_ISN(2).Tranche = "Entre 51h et 100h"
        tab_abs_ISN(3).Tranche = "Plus de 100h"

        tab_abs_total(0).Tranche = "Entre 0h et 10h"
        tab_abs_total(1).Tranche = "Entre 11h et 50h"
        tab_abs_total(2).Tranche = "Entre 51h et 100h"
        tab_abs_total(3).Tranche = "Plus de 100h"


        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("INS")
        ps.fermeture_connection()
        Dim absence_ins_0_10 As Integer = 0
        Dim absence_ins_11_50 As Integer = 0
        Dim absence_ins_51_100 As Integer = 0
        Dim absence_ins_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 & ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_ins_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 & ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_ins_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 & ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_ins_51_100 += 1
            Else
                absence_ins_100 += 1
            End If
        Next
        tab_abs_INS(0).nrbe_abs = absence_ins_0_10
        tab_abs_INS(1).nrbe_abs = absence_ins_11_50
        tab_abs_INS(2).nrbe_abs = absence_ins_51_100
        tab_abs_INS(3).nrbe_abs = absence_ins_100

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("ISN")
        ps.fermeture_connection()
        Dim absence_isn_0_10 As Integer = 0
        Dim absence_isn_11_50 As Integer = 0
        Dim absence_isn_51_100 As Integer = 0
        Dim absence_isn_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 & ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_isn_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 & ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_isn_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 & ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_isn_51_100 += 1
            Else
                absence_isn_100 += 1
            End If
        Next

        tab_abs_ISN(0).nrbe_abs = absence_isn_0_10
        tab_abs_ISN(1).nrbe_abs = absence_isn_11_50
        tab_abs_ISN(2).nrbe_abs = absence_isn_51_100
        tab_abs_ISN(3).nrbe_abs = absence_isn_100

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("CDN")
        ps.fermeture_connection()
        Dim absence_cdn_0_10 As Integer = 0
        Dim absence_cdn_11_50 As Integer = 0
        Dim absence_cdn_51_100 As Integer = 0
        Dim absence_cdn_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 & ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_cdn_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 & ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_cdn_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 & ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_cdn_51_100 += 1
            Else
                absence_cdn_100 += 1
            End If
        Next

        tab_abs_CDN(0).nrbe_abs = absence_cdn_0_10
        tab_abs_CDN(1).nrbe_abs = absence_cdn_11_50
        tab_abs_CDN(2).nrbe_abs = absence_cdn_51_100
        tab_abs_CDN(3).nrbe_abs = absence_cdn_100

        tab_abs_total(0).nrbe_abs = tab_abs_INS(0).nrbe_abs + tab_abs_ISN(0).nrbe_abs + tab_abs_CDN(0).nrbe_abs
        tab_abs_total(1).nrbe_abs = tab_abs_INS(1).nrbe_abs + tab_abs_ISN(1).nrbe_abs + tab_abs_CDN(1).nrbe_abs
        tab_abs_total(2).nrbe_abs = tab_abs_INS(2).nrbe_abs + tab_abs_ISN(2).nrbe_abs + tab_abs_CDN(2).nrbe_abs
        tab_abs_total(3).nrbe_abs = tab_abs_INS(3).nrbe_abs + tab_abs_ISN(3).nrbe_abs + tab_abs_CDN(3).nrbe_abs

        With Chart1
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart2
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart3
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart4
            .Series.Clear()
            .Series.Add("Series1")

        End With


        Dim series As Series = Chart1.Series("Series1")

        series.ChartType = SeriesChartType.Pie


        With Chart1
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_INS(0).Tranche, tab_abs_INS(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(1).Tranche, tab_abs_INS(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(2).Tranche, tab_abs_INS(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(3).Tranche, tab_abs_INS(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series1 As Series = Chart2.Series("Series1")

        series1.ChartType = SeriesChartType.Pie


        With Chart2
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_ISN(0).Tranche, tab_abs_ISN(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(1).Tranche, tab_abs_ISN(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(2).Tranche, tab_abs_ISN(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(3).Tranche, tab_abs_ISN(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series2 As Series = Chart3.Series("Series1")

        series2.ChartType = SeriesChartType.Pie


        With Chart3
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_CDN(0).Tranche, tab_abs_CDN(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(1).Tranche, tab_abs_CDN(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(2).Tranche, tab_abs_CDN(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(3).Tranche, tab_abs_CDN(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series3 As Series = Chart4.Series("Series1")

        series3.ChartType = SeriesChartType.Pie


        With Chart4
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_total(0).Tranche, tab_abs_total(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(1).Tranche, tab_abs_total(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(2).Tranche, tab_abs_total(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(3).Tranche, tab_abs_total(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False

    End Sub

    Private Sub GunaGradientTileButton7_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton7.Click
        If GunaAdvenceButton3.Checked = False Then
            GunaAdvenceButton3.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        UersPanel.BringToFront()
        UersPanel.Visible = True
        GunaTileButton1.Visible = True
        GunaTileButton1.BringToFront()
        GunaTileButton2.Visible = True
        GunaTileButton2.BringToFront()

        'Rendre les pannels invisibles
        ProfilPanel.Visible = False
        VerificationPanel.Visible = False
        ModComAdmin.Visible = False
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True
        TabControl1.SelectedIndex = 5
        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False

    End Sub

    Private Sub GunaGradientTileButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton6.Click
        If GunaAdvenceButton5.Checked = False Then
            GunaAdvenceButton5.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True

        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False
        TabControl1.SelectedIndex = 7

    End Sub

    Private Sub GunaGradientTileButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientTileButton5.Click
        If GunaAdvenceButton6.Checked = False Then
            GunaAdvenceButton6.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False

        End If

        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True

        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False
        TabControl1.SelectedIndex = 6

    End Sub

    Private Sub GunaButton21_Click(sender As Object, e As EventArgs) Handles GunaButton21.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButton20_Click(sender As Object, e As EventArgs) Handles GunaButton20.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub GunaButton16_Click(sender As Object, e As EventArgs) Handles GunaButton16.Click
        For i = 0 To EtudiantListview.Items.Count() - 1
            pe.Nom = EtudiantListview.Items(i).SubItems(0).Text
            pe.Date_de_naissance = CDate(EtudiantListview.Items(i).SubItems(1).Text)
            pe.Sexe = EtudiantListview.Items(i).SubItems(2).Text
            pe.Niveau = CInt(EtudiantListview.Items(i).SubItems(3).Text)
            pe.Filiere = EtudiantListview.Items(i).SubItems(4).Text
            pe.Groupe_TD = EtudiantListview.Items(i).SubItems(5).Text
            pe.Groupe_TP = EtudiantListview.Items(i).SubItems(6).Text
            pe.Matricule = EtudiantListview.Items(i).SubItems(7).Text
            pe.Heures_absence = 0
            pe.IDE = EtudiantListview.Items(i).SubItems(8).Text
            ps.ouverture_connection()
            ps.AjouterEtudiant(ETUDIANT:=pe)
            ps.fermeture_connection()
            If ps.n = True Then
                MsgBox("LES INFORMATION DE L'ETUDIANT: " & pe.Nom & " ONT ÉTÉ ENREGISTRÉ", MsgBoxStyle.Information)
            Else
                MsgBox("LES INFORMATION DE L'ETUDIANT:" & pe.Nom & " N'ONT PAS ÉTÉ ENREGISTRÉ", MsgBoxStyle.Critical)
            End If

        Next
        For r = 0 To EtudiantListview.Items.Count() - 1
            EtudiantListview.Items.Remove(EtudiantListview.Items(0))
        Next
    End Sub

    Private Sub GunaButton18_Click(sender As Object, e As EventArgs) Handles GunaButton18.Click
        For i = 0 To PersonnelListview.Items.Count() - 1
            pp.Nom = PersonnelListview.Items(i).SubItems(0).Text
            pp.Matiere = PersonnelListview.Items(i).SubItems(1).Text
            pp.Sexe = PersonnelListview.Items(i).SubItems(2).Text
            pp.Statut = PersonnelListview.Items(i).SubItems(3).Text
            pp.salaire_par_heure = CInt(PersonnelListview.Items(i).SubItems(4).Text)
            pp.IDP = PersonnelListview.Items(i).SubItems(5).Text
            pp.heures = 0
            ps.ouverture_connection()
            ps.AjouterPersonnel(PERSONNEL:=pp)
            ps.fermeture_connection()
            If ps.n = True Then
                MsgBox("LES INFORMATION DU PERSONNEL: " & pp.Nom & " ONT ÉTÉ ENREGISTRÉ", MsgBoxStyle.Information)
            Else
                MsgBox("LES INFORMATION DU PERSONNEL:" & pp.Nom & " N'ONT PAS ÉTÉ ENREGISTRÉ", MsgBoxStyle.Critical)
            End If
        Next
        For r = 0 To PersonnelListview.Items.Count() - 1
            PersonnelListview.Items.Remove(PersonnelListview.Items(0))
        Next
    End Sub

    Private Sub GunaButton28_Click(sender As Object, e As EventArgs) Handles GunaButton28.Click
        ListView3.Items.Clear()
        ListView4.Items.Clear()
        GunaElipsePanel6.BringToFront()
        ps.ouverture_connection()
        ps.SelectionEtudiant()

        Try
            For i = 0 To ps.p - 1
                ListView4.Items.Add(New ListViewItem({ps.ETUDIANT(i).Nom, ps.ETUDIANT(i).Date_de_naissance, ps.ETUDIANT(i).Sexe, ps.ETUDIANT(i).Niveau, ps.ETUDIANT(i).Filiere, ps.ETUDIANT(i).Groupe_TD, ps.ETUDIANT(i).Groupe_TP, ps.ETUDIANT(i).Matricule, ps.ETUDIANT(i).IDE, ps.ETUDIANT(i).Heures_absence}))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ps.SelectionPersonnel()
        Try
            For i = 0 To ps.p - 1
                ListView3.Items.Add(New ListViewItem({ps.PERSONNEL(i).Nom, ps.PERSONNEL(i).Matiere, ps.PERSONNEL(i).Sexe, ps.PERSONNEL(i).Statut, ps.PERSONNEL(i).IDP, ps.PERSONNEL(i).salaire_par_heure, ps.PERSONNEL(i).heures, ps.PERSONNEL(i).salaire_total}))
            Next
        Catch ex As Exception

        End Try
        ps.fermeture_connection()

    End Sub

    Private Sub GunaButton30_Click(sender As Object, e As EventArgs) Handles GunaButton30.Click
        ListView4.BringToFront()
        ListView3.SendToBack()

    End Sub

    Private Sub GunaButton31_Click(sender As Object, e As EventArgs) Handles GunaButton31.Click
        ListView3.BringToFront()
        ListView4.SendToBack()
    End Sub

    Private Sub GunaButton32_Click(sender As Object, e As EventArgs) Handles GunaButton32.Click
        Dim i As Integer = 0
        Dim na As String = ""
        choisir.Filter = "File|*.xlsx"
        'choisir.ShowDialog()
        If choisir.ShowDialog = 1 Then
            na = choisir.FileName
        End If
        app = CreateObject("excel.Application")
        app.Visible = True



        book = app.Workbooks.Open(na)
        sheet = book.Worksheets(1)
        i = sheet.UsedRange.Rows.Count

        For j = 2 To i
            Dim car As New ListViewItem
            car.Text = (sheet.Cells(j, 1).value)
            car.SubItems.Add(sheet.Cells(j, 2).value)
            car.SubItems.Add(sheet.Cells(j, 3).value)
            car.SubItems.Add(sheet.Cells(j, 4).value)
            car.SubItems.Add(sheet.Cells(j, 5).value)
            car.SubItems.Add(sheet.Cells(j, 6).value)
            car.SubItems.Add(sheet.Cells(j, 7).value)
            car.SubItems.Add(sheet.Cells(j, 8).value)

            EtudiantListview.Items.Add(car)
        Next

    End Sub

    Private Sub GunaButton33_Click(sender As Object, e As EventArgs) Handles GunaButton33.Click
        Dim i As Integer = 0
        Dim na As String = ""
        choisir.Filter = "File|*.xlsx"
        'choisir.ShowDialog()
        If choisir.ShowDialog = 1 Then
            na = choisir.FileName
        End If
        app = CreateObject("excel.Application")
        app.Visible = True

        book = app.Workbooks.Open(na)
        sheet = book.Worksheets(1)
        i = sheet.UsedRange.Rows.Count

        For j = 2 To i
            Dim car As New ListViewItem
            car.Text = (sheet.Cells(j, 1).value)
            car.SubItems.Add(sheet.Cells(j, 2).value)
            car.SubItems.Add(sheet.Cells(j, 3).value)
            car.SubItems.Add(sheet.Cells(j, 4).value)

            PersonnelListview.Items.Add(car)
        Next

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton26_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton25_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton22_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton23_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton24_Click(sender As Object, e As EventArgs)
        SelectPanel.Visible = True
    End Sub

    Private Sub GunaButton27_Click(sender As Object, e As EventArgs) Handles GunaButton27.Click
        Dim da As DateTime
        Dim jour, tranche As String
        Dim groupe As String = ""
        da = CDate(GunaDateTimePicker2.Text)
        jour = da.DayOfWeek.ToString
        jour = CStr(jour + ", " + GunaDateTimePicker2.Text)
        tranche = GunaComboBox5.Text + "-" + GunaComboBox6.Text
        If ComboBox5.Text <> "" Then
            groupe = ComboBox5.Text
        End If
        ListView5.Items.Add(New ListViewItem({GunaComboBox1.Text, groupe, GunaComboBox2.Text, GunaComboBox4.Text, jour, tranche}))

        GunaComboBox1.Text = ""
        GunaDateTimePicker2.Text = ""
        ComboBox5.Text = ""
        GunaComboBox4.Text = ""
        GunaComboBox2.Text = ""
        GunaComboBox5.Text = ""
        GunaComboBox6.Text = ""

    End Sub

    'fonctions du Menutrîp

    Public filiere As String

    Private Sub ViderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViderToolStripMenuItem.Click
        If ViderToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "INS1A" & " " & "INS1B" & " " & "INS2A" & " " & "INS2B" & " " & " " & "INS3A" & " " & "INS3B"
            INS1ToolStripMenuItem.Visible = False
            INS2ToolStripMenuItem.Visible = False
            INS3ToolStripMenuItem.Visible = False
        Else
            INS1ToolStripMenuItem.Visible = True
            INS2ToolStripMenuItem.Visible = True
            INS3ToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ISNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISNToolStripMenuItem.Click
        If ISNToolStripMenuItem.Checked = True Then
            ISN1ToolStripMenuItem.Visible = False
            ISN2ToolStripMenuItem.Visible = False
            ISN3ToolStripMenuItem.Visible = False
        Else
            ISN1ToolStripMenuItem.Visible = True
            ISN2ToolStripMenuItem.Visible = True
            ISN3ToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub TousÉtudiantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TousÉtudiantsToolStripMenuItem.Click
        If TousÉtudiantsToolStripMenuItem.Checked = True Then
            ViderToolStripMenuItem.Visible = False
            ISNToolStripMenuItem.Visible = False
            CDNToolStripMenuItem.Visible = False
        Else
            ViderToolStripMenuItem.Visible = True
            ISNToolStripMenuItem.Visible = True
            CDNToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub INS1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS1ToolStripMenuItem.Click
        If INS1ToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "INS1A" & " " & "INS1B"
            MsgBox(filiere)
            INS1AToolStripMenuItem.Visible = False
            INS1BToolStripMenuItem.Visible = False
        Else
            INS1AToolStripMenuItem.Visible = True
            INS1BToolStripMenuItem.Visible = True
        End If



    End Sub

    Private Sub INS2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS2ToolStripMenuItem.Click
        If INS2ToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "INS2A" & " " & "INS2B"
            INS2AToolStripMenuItem.Visible = False
            INS2BToolStripMenuItem.Visible = False
        Else
            INS2AToolStripMenuItem.Visible = True
            INS2BToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub INS3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS3ToolStripMenuItem.Click
        If INS3ToolStripMenuItem.Checked = True Then
            INS3AToolStripMenuItem.Visible = False
            INS3BToolStripMenuItem.Visible = False
        Else
            INS3AToolStripMenuItem.Visible = True
            INS3BToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ISN1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN1ToolStripMenuItem.Click
        If ISN1ToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "ISN1A" & " " & "ISN1B"
            ISN1AToolStripMenuItem.Visible = False
            ISN1BToolStripMenuItem.Visible = False
        Else
            ISN1AToolStripMenuItem.Visible = True
            ISN1BToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ISN2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN2ToolStripMenuItem.Click
        If ISN2ToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "ISN2A" & " " & "ISN2B"
            ISN2AToolStripMenuItem.Visible = False
            ISN2BToolStripMenuItem.Visible = False
        Else
            ISN2AToolStripMenuItem.Visible = True
            ISN2BToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ISN3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN3ToolStripMenuItem.Click
        If ISN3ToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "ISN3A" & " " & "ISN3B"
            ISN3AToolStripMenuItem1.Visible = False
            ISN3BToolStripMenuItem1.Visible = False
        Else
            ISN3AToolStripMenuItem1.Visible = True
            ISN3BToolStripMenuItem1.Visible = True
        End If
    End Sub

    Private Sub CDN1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN1ToolStripMenuItem.Click
        If CDN1ToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "CDN1A" & " " & "CDN1B"
            MsgBox(filiere)
            CDN1AToolStripMenuItem.Visible = False
            CDN1BToolStripMenuItem.Visible = False
        Else
            CDN1AToolStripMenuItem.Visible = True
            CDN1BToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub CDN2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN2ToolStripMenuItem.Click
        If CDN2ToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "CDN2A" & " " & "CDN2B"
            MsgBox(filiere)
            CDN2AToolStripMenuItem.Visible = False
            CDN2BToolStripMenuItem.Visible = False
        Else
            CDN2AToolStripMenuItem.Visible = True
            CDN2BToolStripMenuItem.Visible = True
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If GunaLineTextBox12.UseSystemPasswordChar = True Then
            GunaLineTextBox12.UseSystemPasswordChar = False
            GunaLineTextBox12.PasswordChar = ""
            Button1.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox12.UseSystemPasswordChar = False Then
            GunaLineTextBox12.UseSystemPasswordChar = True
            GunaLineTextBox12.PasswordChar = "●"
            Button1.BackgroundImage = My.Resources.yeux
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If GunaLineTextBox14.UseSystemPasswordChar = True Then
            GunaLineTextBox14.UseSystemPasswordChar = False
            GunaLineTextBox14.PasswordChar = ""
            Button2.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox14.UseSystemPasswordChar = False Then
            GunaLineTextBox14.UseSystemPasswordChar = True
            GunaLineTextBox14.PasswordChar = "●"
            Button2.BackgroundImage = My.Resources.yeux
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If GunaLineTextBox17.UseSystemPasswordChar = True Then
            GunaLineTextBox17.UseSystemPasswordChar = False
            GunaLineTextBox17.PasswordChar = ""
            Button3.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox17.UseSystemPasswordChar = False Then
            GunaLineTextBox17.UseSystemPasswordChar = True
            GunaLineTextBox17.PasswordChar = "●"
            Button3.BackgroundImage = My.Resources.yeux
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If GunaLineTextBox20.UseSystemPasswordChar = True Then
            GunaLineTextBox20.UseSystemPasswordChar = False
            GunaLineTextBox20.PasswordChar = ""
            Button4.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox20.UseSystemPasswordChar = False Then
            GunaLineTextBox20.UseSystemPasswordChar = True
            GunaLineTextBox20.PasswordChar = "●"
            Button4.BackgroundImage = My.Resources.yeux
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If GunaLineTextBox18.UseSystemPasswordChar = True Then
            GunaLineTextBox18.UseSystemPasswordChar = False
            GunaLineTextBox18.PasswordChar = ""
            Button5.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox18.UseSystemPasswordChar = False Then
            GunaLineTextBox18.UseSystemPasswordChar = True
            GunaLineTextBox18.PasswordChar = "●"
            Button5.BackgroundImage = My.Resources.yeux

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If GunaLineTextBox26.UseSystemPasswordChar = True Then
            GunaLineTextBox26.UseSystemPasswordChar = False
            GunaLineTextBox26.PasswordChar = ""
            Button6.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox26.UseSystemPasswordChar = False Then
            GunaLineTextBox26.UseSystemPasswordChar = True
            GunaLineTextBox26.PasswordChar = "●"
            Button6.BackgroundImage = My.Resources.yeux

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If GunaLineTextBox28.UseSystemPasswordChar = True Then
            GunaLineTextBox28.UseSystemPasswordChar = False
            GunaLineTextBox28.PasswordChar = ""
            Button7.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox28.UseSystemPasswordChar = False Then
            GunaLineTextBox28.UseSystemPasswordChar = True
            GunaLineTextBox28.PasswordChar = "●"
            Button7.BackgroundImage = My.Resources.yeux

        End If
    End Sub

    Private Sub GunaLineTextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GunaLineTextBox29.KeyPress
        Dim caractere() As Char = {"²", "&", "_", ";", ":", "(", "-", ")", "=", "$", "*", "!", "+", "°", "£", "µ", "%", "§", "/", "?"}
        If caractere.Contains(e.KeyChar) Then
            e.Handled = True
            ErrorProvider1.SetError(GunaLineTextBox29, "Vous ne pouvez pas entrer de caracteres speciaux")
        Else
            ErrorProvider1.Dispose()
        End If
    End Sub

    Private Sub GunaLineTextBox27_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GunaLineTextBox27.KeyPress
        Dim caractere() As Char = {"²", "&", "_", ";", ":", "(", "-", ")", "=", "$", "*", "!", "+", "°", "£", "µ", "%", "§", "/", "?"}
        If caractere.Contains(e.KeyChar) Then
            e.Handled = True
            ErrorProvider2.SetError(GunaLineTextBox27, "Vous ne pouvez pas entrer de caracteres speciaux")
        Else
            ErrorProvider2.Dispose()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If GunaLineTextBox21.UseSystemPasswordChar = True Then
            GunaLineTextBox21.UseSystemPasswordChar = False
            GunaLineTextBox21.PasswordChar = ""
            Button8.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox21.UseSystemPasswordChar = False Then
            GunaLineTextBox21.UseSystemPasswordChar = True
            GunaLineTextBox21.PasswordChar = "●"
            Button8.BackgroundImage = My.Resources.yeux

        End If
    End Sub

    Private Sub INS1AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS1AToolStripMenuItem.Click
        If INS1AToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "INS1A"
            MsgBox(filiere)
        End If
    End Sub


    Private Sub INS1BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS1BToolStripMenuItem.Click
        If INS1BToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "INS1B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub INS2AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS2AToolStripMenuItem.Click
        If INS2AToolStripMenuItem.Checked = True Then
            filiere = filiere + " " + "INS2A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub INS2BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS2BToolStripMenuItem.Click
        If INS2BToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "INS2B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub INS3AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS3AToolStripMenuItem.Click
        If INS3AToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "INS3A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub INS3BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INS3BToolStripMenuItem.Click
        If INS3BToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "INS3B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN1BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN1BToolStripMenuItem.Click
        If ISN1BToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "ISN1B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN1AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN1AToolStripMenuItem.Click
        If ISN1AToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "ISN1A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN2AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN2AToolStripMenuItem.Click
        If ISN2AToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "ISN2A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN2BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISN2BToolStripMenuItem.Click
        If ISN2BToolStripMenuItem.Checked = True Then
            filiere = filiere + " " & "ISN2B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN3AToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ISN3AToolStripMenuItem1.Click
        If ISN3AToolStripMenuItem1.Checked = True Then
            filiere = filiere + " " & "ISN3A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub ISN3BToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ISN3BToolStripMenuItem1.Click
        If ISN3BToolStripMenuItem1.Checked = True Then
            filiere = filiere + " " & "ISN3B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub CDN1BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN1BToolStripMenuItem.Click
        If CDN1BToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "CDN1B"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub CDN1AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN1AToolStripMenuItem.Click
        If CDN1AToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "CDN1A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub CDN2AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN2AToolStripMenuItem.Click
        If CDN2AToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "CDN2A"
            MsgBox(filiere)
        End If
    End Sub

    Private Sub CDN2BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CDN2BToolStripMenuItem.Click
        If CDN2BToolStripMenuItem.Checked = True Then
            filiere = filiere & " " & "CDN2B"
            MsgBox(filiere)
        End If
    End Sub
    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        Form1.Show()
        Form1.BringToFront()
        Me.Dispose()
    End Sub

    Private Sub StatPanel_Paint(sender As Object, e As PaintEventArgs) Handles StatPanel.Paint

    End Sub

    Private Sub ListView6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewINS.SelectedIndexChanged

    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles DispositifButton2.Click
        If DispositifButton2.Checked = False Then
            DispositifButton2.Checked = True
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        DispositifPanel.BringToFront()
        DispositifPanel.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        TabControl1.SelectedIndex = 0

        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()

        ListView1.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.DISPOSITIFS(i).IDD)
            car.SubItems.Add(ps.DISPOSITIFS(i).Salle)
            car.SubItems.Add(ps.DISPOSITIFS(i).Dates)
            car.SubItems.Add(ps.DISPOSITIFS(i).Date_import)
            car.SubItems.Add(ps.DISPOSITIFS(i).Heures)
            ListView1.Items.Add(car)
        Next
    End Sub

    Private Sub PersButton2_Click(sender As Object, e As EventArgs) Handles PersButton2.Click
        If PersButton2.Checked = False Then
            PersButton2.Checked = True
            DispositifButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
            PersonnelPoan.BringToFront()
            PersonnelPoan.Visible = True
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        ' Remplissage Combo date de naissance etudiant
        JourCombo.Items.Clear()
        AnnéeCombo.Items.Clear()
        For i = 1 To 31
            JourCombo.Items.Add(i)
        Next
        For i = 1950 To 2050
            AnnéeCombo.Items.Add(i)
        Next
        Menu.Visible = False
        ProgrPanel.Visible = False
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub GunaAdvenceButton1_Click_1(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        If GunaAdvenceButton1.Checked = False Then
            GunaAdvenceButton1.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        ProgrPanel.BringToFront()
        ProgrPanel.Visible = True

        'affichage
        UersPanel.Visible = True
        Menu.Visible = False
        TabControl1.SelectedIndex = 2

        GunaComboBox2.Items.Clear()
        ps.ouverture_connection()
        ps.SelectionPersonnel()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            GunaComboBox2.Items.Add(ps.PERSONNEL(i).Nom)
        Next
        GunaComboBox1.Items.Clear()
        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            GunaComboBox1.Items.Add(ps.DISPOSITIFS(i).Salle)
        Next
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        If GunaAdvenceButton2.Checked = False Then
            GunaAdvenceButton2.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        PointagePanel.BringToFront()
        PointagePanel.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        TabControl1.SelectedIndex = 3
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        If GunaAdvenceButton4.Checked = False Then
            GunaAdvenceButton4.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        TabControl1.SelectedIndex = 4

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("CDN")
        ps.fermeture_connection()

        ListViewCDN.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewCDN.Items.Add(car)
        Next
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("INS")
        ps.fermeture_connection()

        ListViewINS.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewINS.Items.Add(car)
        Next

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("ISN")
        ps.fermeture_connection()

        ListViewISN.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.ETUDIANT(i).Nom)
            car.SubItems.Add(ps.ETUDIANT(i).Sexe)
            car.SubItems.Add(ps.ETUDIANT(i).Niveau)
            car.SubItems.Add(ps.ETUDIANT(i).Filiere)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TD)
            car.SubItems.Add(ps.ETUDIANT(i).Groupe_TP)
            car.SubItems.Add(ps.ETUDIANT(i).Heures_absence)
            ListViewISN.Items.Add(car)
        Next

        tab_abs_INS(0).Tranche = "Entre 0h et 10h"
        tab_abs_INS(1).Tranche = "Entre 11h et 50h"
        tab_abs_INS(2).Tranche = "Entre 51h et 100h"
        tab_abs_INS(3).Tranche = "Plus de 100h"

        tab_abs_CDN(0).Tranche = "Entre 0h et 10h"
        tab_abs_CDN(1).Tranche = "Entre 11h et 50h"
        tab_abs_CDN(2).Tranche = "Entre 51h et 100h"
        tab_abs_CDN(3).Tranche = "Plus de 100h"

        tab_abs_ISN(0).Tranche = "Entre 0h et 10h"
        tab_abs_ISN(1).Tranche = "Entre 11h et 50h"
        tab_abs_ISN(2).Tranche = "Entre 51h et 100h"
        tab_abs_ISN(3).Tranche = "Plus de 100h"

        tab_abs_total(0).Tranche = "Entre 0h et 10h"
        tab_abs_total(1).Tranche = "Entre 11h et 50h"
        tab_abs_total(2).Tranche = "Entre 51h et 100h"
        tab_abs_total(3).Tranche = "Plus de 100h"


        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("INS")
        ps.fermeture_connection()
        Dim absence_ins_0_10 As Integer = 0
        Dim absence_ins_11_50 As Integer = 0
        Dim absence_ins_51_100 As Integer = 0
        Dim absence_ins_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 And ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_ins_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 And ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_ins_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 And ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_ins_51_100 += 1
            Else
                absence_ins_100 += 1
            End If
        Next
        tab_abs_INS(0).nrbe_abs = absence_ins_0_10
        tab_abs_INS(1).nrbe_abs = absence_ins_11_50
        tab_abs_INS(2).nrbe_abs = absence_ins_51_100
        tab_abs_INS(3).nrbe_abs = absence_ins_100

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("ISN")
        ps.fermeture_connection()
        Dim absence_isn_0_10 As Integer = 0
        Dim absence_isn_11_50 As Integer = 0
        Dim absence_isn_51_100 As Integer = 0
        Dim absence_isn_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 And ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_isn_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 And ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_isn_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 And ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_isn_51_100 += 1
            Else
                absence_isn_100 += 1
            End If
        Next

        tab_abs_ISN(0).nrbe_abs = absence_isn_0_10
        tab_abs_ISN(1).nrbe_abs = absence_isn_11_50
        tab_abs_ISN(2).nrbe_abs = absence_isn_51_100
        tab_abs_ISN(3).nrbe_abs = absence_isn_100

        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("CDN")
        ps.fermeture_connection()
        Dim absence_cdn_0_10 As Integer = 0
        Dim absence_cdn_11_50 As Integer = 0
        Dim absence_cdn_51_100 As Integer = 0
        Dim absence_cdn_100 As Integer = 0
        For i = 0 To ps.p - 1
            If ps.ETUDIANT(i).Heures_absence >= 0 And ps.ETUDIANT(i).Heures_absence <= 10 Then
                absence_cdn_0_10 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 11 And ps.ETUDIANT(i).Heures_absence <= 50 Then
                absence_cdn_11_50 += 1
            ElseIf ps.ETUDIANT(i).Heures_absence >= 51 And ps.ETUDIANT(i).Heures_absence <= 100 Then
                absence_cdn_51_100 += 1
            Else
                absence_cdn_100 += 1
            End If
        Next

        tab_abs_CDN(0).nrbe_abs = absence_cdn_0_10
        tab_abs_CDN(1).nrbe_abs = absence_cdn_11_50
        tab_abs_CDN(2).nrbe_abs = absence_cdn_51_100
        tab_abs_CDN(3).nrbe_abs = absence_cdn_100

        tab_abs_total(0).nrbe_abs = tab_abs_INS(0).nrbe_abs + tab_abs_ISN(0).nrbe_abs + tab_abs_CDN(0).nrbe_abs
        tab_abs_total(1).nrbe_abs = tab_abs_INS(1).nrbe_abs + tab_abs_ISN(1).nrbe_abs + tab_abs_CDN(1).nrbe_abs
        tab_abs_total(2).nrbe_abs = tab_abs_INS(2).nrbe_abs + tab_abs_ISN(2).nrbe_abs + tab_abs_CDN(2).nrbe_abs
        tab_abs_total(3).nrbe_abs = tab_abs_INS(3).nrbe_abs + tab_abs_ISN(3).nrbe_abs + tab_abs_CDN(3).nrbe_abs

        With Chart1
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart2
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart3
            .Series.Clear()
            .Series.Add("Series1")

        End With

        With Chart4
            .Series.Clear()
            .Series.Add("Series1")

        End With


        Dim series As Series = Chart1.Series("Series1")

        series.ChartType = SeriesChartType.Pie


        With Chart1
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_INS(0).Tranche, tab_abs_INS(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(1).Tranche, tab_abs_INS(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(2).Tranche, tab_abs_INS(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_INS(3).Tranche, tab_abs_INS(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series1 As Series = Chart2.Series("Series1")

        series1.ChartType = SeriesChartType.Pie


        With Chart2
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_ISN(0).Tranche, tab_abs_ISN(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(1).Tranche, tab_abs_ISN(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(2).Tranche, tab_abs_ISN(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_ISN(3).Tranche, tab_abs_ISN(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series2 As Series = Chart3.Series("Series1")

        series2.ChartType = SeriesChartType.Pie


        With Chart3
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_CDN(0).Tranche, tab_abs_CDN(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(1).Tranche, tab_abs_CDN(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(2).Tranche, tab_abs_CDN(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_CDN(3).Tranche, tab_abs_CDN(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

        Dim series3 As Series = Chart4.Series("Series1")

        series3.ChartType = SeriesChartType.Pie


        With Chart4
            .Legends(0).Title = "Tranche Horaire"
            .Series(0).Points.AddXY(tab_abs_total(0).Tranche, tab_abs_total(0).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(1).Tranche, tab_abs_total(1).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(2).Tranche, tab_abs_total(2).nrbe_abs)
            .Series(0).Points.AddXY(tab_abs_total(3).Tranche, tab_abs_total(3).nrbe_abs)
            .Series(0).IsValueShownAsLabel = True
        End With

    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        If GunaAdvenceButton3.Checked = False Then
            GunaAdvenceButton3.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False
            GunaAdvenceButton6.Checked = False
        End If
        UersPanel.BringToFront()
        UersPanel.Visible = True
        GunaTileButton1.Visible = True
        GunaTileButton1.BringToFront()
        GunaTileButton2.Visible = True
        GunaTileButton2.BringToFront()

        'Rendre les pannels invisibles
        ProfilPanel.Visible = False
        VerificationPanel.Visible = False
        ModComAdmin.Visible = False
        Menu.Visible = False
        ProgrPanel.Visible = False
        TabControl1.SelectedIndex = 5

    End Sub

    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        If GunaAdvenceButton6.Checked = False Then
            GunaAdvenceButton6.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton5.Checked = False

        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True

        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False
        TabControl1.SelectedIndex = 6
    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        If GunaAdvenceButton5.Checked = False Then
            GunaAdvenceButton5.Checked = True
            DispositifButton2.Checked = False
            PersButton2.Checked = False
            GunaAdvenceButton1.Checked = False
            GunaAdvenceButton2.Checked = False
            GunaAdvenceButton3.Checked = False
            GunaAdvenceButton4.Checked = False
            GunaAdvenceButton6.Checked = False
            MsgBox("Vous devez avoir la connexion internet pour envoyer un mail", MsgBoxStyle.Information, "Mail")
        End If
        PersonnelPoan.BringToFront()
        PersonnelPoan.Visible = True
        Menu.Visible = False
        ProgrPanel.Visible = False
        Panel1.Visible = True

        GunaElipsePanel1.Visible = True
        GunaElipsePanel11.Visible = False
        TabControl1.SelectedIndex = 7
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Menu.Visible = True
        GunaElipsePanel11.Visible = True
        GunaElipsePanel1.Visible = False
        GunaElipsePanel11.Visible = True



    End Sub

    Private Sub GunaButton22_Click_1(sender As Object, e As EventArgs) Handles GunaButton22.Click

        ListViewCDN.Visible = True
        ListViewCDN.BringToFront()
    End Sub

    Private Sub GunaButton24_Click_1(sender As Object, e As EventArgs) Handles GunaButton24.Click

        ListViewINS.Visible = True
        ListViewINS.BringToFront()
    End Sub

    Private Sub GunaButton23_Click_1(sender As Object, e As EventArgs) Handles GunaButton23.Click

        ListViewISN.Visible = True
        ListViewISN.BringToFront()
    End Sub


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
    Public h As New pdf

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        For i = 0 To ListViewCDN.Items.Count() - 1
            Module1.tab_etud_CDN(i).Nom = ListViewCDN.Items(i).SubItems(0).Text
            Module1.tab_etud_CDN(i).Groupe_TD = ListViewCDN.Items(i).SubItems(4).Text
            Module1.tab_etud_CDN(i).Groupe_TP = ListViewCDN.Items(i).SubItems(5).Text
            Module1.tab_etud_CDN(i).Heures_absence = ListViewCDN.Items(i).SubItems(6).Text

        Next
        For i = 0 To ListViewISN.Items.Count() - 1
            Module1.tab_etud_ISN(i).Nom = ListViewISN.Items(i).SubItems(0).Text
            Module1.tab_etud_ISN(i).Groupe_TD = ListViewISN.Items(i).SubItems(4).Text
            Module1.tab_etud_ISN(i).Groupe_TP = ListViewISN.Items(i).SubItems(5).Text
            Module1.tab_etud_ISN(i).Heures_absence = ListViewISN.Items(i).SubItems(6).Text

        Next
        For i = 0 To ListViewINS.Items.Count() - 1
            Module1.tab_etud_INS(i).Nom = ListViewINS.Items(i).SubItems(0).Text
            Module1.tab_etud_INS(i).Groupe_TD = ListViewINS.Items(i).SubItems(4).Text
            Module1.tab_etud_INS(i).Groupe_TP = ListViewINS.Items(i).SubItems(5).Text
            Module1.tab_etud_INS(i).Heures_absence = ListViewINS.Items(i).SubItems(6).Text
        Next
        Module1.pdf_absences()
    End Sub

    Private Sub GunaButton4_Click_1(sender As Object, e As EventArgs) Handles GunaButton4.Click
        ListView7.Items.Clear()
        ListView2.Items.Clear()
        Dim z As New Fichier
        z.voir()
    End Sub


    Private Sub GunaButton25_Click_1(sender As Object, e As EventArgs) Handles GunaButton25.Click

        pd.IDD = DispTextBox.Text
        pd.Salle = SalleTextbox.Text
        ps.ouverture_connection()
        ps.AjouterDispositif(DISPOSITIF:=pd)
        ps.fermeture_connection()

        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()

        ListView1.Items.Clear()
        For i = 0 To ps.p - 1
            Dim car As New ListViewItem
            car.Text = (ps.DISPOSITIFS(i).IDD)
            car.SubItems.Add(ps.DISPOSITIFS(i).Salle)
            car.SubItems.Add(ps.DISPOSITIFS(i).Dates)
            car.SubItems.Add(ps.DISPOSITIFS(i).Date_import)
            car.SubItems.Add(ps.DISPOSITIFS(i).Heures)
            ListView1.Items.Add(car)
        Next
    End Sub

    Private Sub GunaButton29_Click(sender As Object, e As EventArgs) Handles GunaButton29.Click
        GunaElipsePanel5.BringToFront()
    End Sub

    Private Sub GunaButton26_Click_1(sender As Object, e As EventArgs) Handles GunaButton26.Click
        Dim ds As Integer
        If EtudiantListview.SelectedItems.Count = 1 Then
            ds = EtudiantListview.SelectedItems(0).Index
            EtudiantListview.Items.RemoveAt(ds)
            ps.max = ps.max - 1
        Else
            MsgBox("VEUILLEZ SELECTIONNER UN ELEMENT")
        End If
    End Sub

    Private Sub GunaButton34_Click(sender As Object, e As EventArgs) Handles GunaButton34.Click
        Dim ds As Integer
        If PersonnelListview.SelectedItems.Count = 1 Then
            ds = PersonnelListview.SelectedItems(0).Index
            PersonnelListview.Items.RemoveAt(ds)
            ps.maxi = ps.maxi - 1
        Else
            MsgBox("VEUILLEZ SELECTIONNER UN ELEMENT")
        End If
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        GunaComboBox4.Items.Clear()
        pp.Nom = GunaComboBox2.Text
        ps.ouverture_connection()
        ps.SelectionPersonnel_Matiere(Pers:=pp)
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            GunaComboBox4.Items.Add(ps.PERSONNEL(i).Matiere)
        Next
    End Sub

    Private Sub EnregProgram_Click(sender As Object, e As EventArgs) Handles EnregProgram.Click
        Dim d, f, da As String
        For i = 0 To ListView5.Items.Count() - 1
            ppr.Salle = ListView5.Items(i).SubItems(0).Text
            ppr.Groupe = ListView5.Items(i).SubItems(1).Text
            ppr.IDENS = ListView5.Items(i).SubItems(2).Text
            ppr.matiere = ListView5.Items(i).SubItems(3).Text
            da = (ListView5.Items(i).SubItems(4).Text).Split(", ")(1)
            ppr.Dates = CDate(da)
            d = (ListView5.Items(i).SubItems(5).Text).Split("-")(0)
            d = d.Split("h")(0)
            d = d + ":00:00"

            f = (ListView5.Items(i).SubItems(5).Text).Split("-")(1)
            f = f.Split("h")(0)
            f = f + ":00:00"

            ppr.Tranches_horaire_debut = TimeSpan.Parse(d)
            ppr.Tranches_horaire_fin = TimeSpan.Parse(f)
            ppr.semaine_debut = GunaDateTimePicker1.Text
            ppr.semaine_fin = GunaDateTimePicker3.Text
            ps.ouverture_connection()
            ps.AjouterProgrammes(PROGRAMMES:=ppr)
            ps.fermeture_connection()
            If ps.n = True Then
                MsgBox("LE PROGRAMME A ÉTÉ ENREGISTRÉ", MsgBoxStyle.Information)
            Else
                MsgBox("LE PROGRAMME N'A PAS ÉTÉ ENREGISTRÉ", MsgBoxStyle.Critical)
            End If
        Next
        For r = 0 To ListView5.Items.Count() - 1
            ListView5.Items.Remove(ListView5.Items(0))
        Next
    End Sub

    Private Sub GunaButton2_Click_1(sender As Object, e As EventArgs)
        po.IDD = ListView7.Items(0).SubItems(0).Text
        ps.ouverture_connection()
        ps.liste_etudiant_toutefiliere(point:=po)
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            MsgBox(ps.POINTAGE(i).IDE)
        Next
    End Sub

    Private Sub GunaButton2_Click_2(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Dim ds As Integer
        If ListView1.SelectedItems.Count > 0 Then
            Dim selec As ListViewItem = ListView1.SelectedItems(0)
            pd.IDD = selec.Text
            MsgBox(pd.IDD)
            ds = ListView1.SelectedItems(0).Index
            ListView1.Items.RemoveAt(ds)
            ps.maxi = ps.maxi - 1

            ps.ouverture_connection()
            ps.SupprimDispositif(DISPOSITIF:=pd)
            ps.fermeture_connection()

            ps.ouverture_connection()
            ps.SelectionDispositifs()
            ps.fermeture_connection()

            ListView1.Items.Clear()
            For i = 0 To ps.p - 1
                Dim car As New ListViewItem
                car.Text = (ps.DISPOSITIFS(i).IDD)
                car.SubItems.Add(ps.DISPOSITIFS(i).Salle)
                car.SubItems.Add(ps.DISPOSITIFS(i).Dates)
                car.SubItems.Add(ps.DISPOSITIFS(i).Date_import)
                car.SubItems.Add(ps.DISPOSITIFS(i).Heures)
                ListView1.Items.Add(car)
            Next
        Else
            MsgBox("VEUILLEZ SELECTIONNER UN ELEMENT")
        End If
    End Sub

    Private Sub PersonnelPoan_Paint(sender As Object, e As PaintEventArgs) Handles PersonnelPoan.Paint

    End Sub

    Private Sub GunaButton38_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton36_Click(sender As Object, e As EventArgs) Handles GunaButton36.Click
        GunaGradientPanel1.Visible = True
        GunaGradientPanel1.BringToFront()
    End Sub

    Private Sub GunaButton37_Click(sender As Object, e As EventArgs) Handles GunaButton37.Click
        GunaGradientPanel1.Visible = False
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("CDN")
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            Module1.tab_etud_CDN(i).Nom = ps.ETUDIANT(i).Nom
            Module1.tab_etud_CDN(i).ID_Etud = ps.ETUDIANT(i).IDE
        Next
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("ISN")
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            Module1.tab_etud_ISN(i).Nom = ps.ETUDIANT(i).Nom
            Module1.tab_etud_ISN(i).ID_Etud = ps.ETUDIANT(i).IDE
        Next
        ps.ouverture_connection()
        ps.SelectionEtudiant_par_filiere("INS")
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            Module1.tab_etud_INS(i).Nom = ps.ETUDIANT(i).Nom
            Module1.tab_etud_INS(i).ID_Etud = ps.ETUDIANT(i).IDE
        Next
        Module1.identifiants()
    End Sub

    Private Sub GunaButton38_Click_1(sender As Object, e As EventArgs) Handles GunaButton38.Click
        GunaGradientPanel1.Visible = False
        ps.ouverture_connection()
        ps.SelectionPersonnel()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            Module1.tab_pers(i).Nom = ps.PERSONNEL(i).Nom
            Module1.tab_pers(i).ID_pers = ps.PERSONNEL(i).IDP
        Next
        Module1.Personne()
    End Sub

    Private Sub GunaButton35_Click(sender As Object, e As EventArgs) Handles GunaButton35.Click
        ps.ouverture_connection()
        ps.SelectionDispositifs()
        ps.fermeture_connection()
        For i = 0 To ps.p - 1
            Module1.Tab_disp(i).ID_Disp = ps.DISPOSITIFS(i).IDD
            Module1.Tab_disp(i).Salle = ps.DISPOSITIFS(i).Salle
            Module1.Tab_disp(i).Date_enregis = ps.DISPOSITIFS(i).Dates
            MsgBox(Module1.Tab_disp(i).ID_Disp)
        Next
        Module1.Dispositifs()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaButton39_Click(sender As Object, e As EventArgs) Handles GunaButton39.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButton40_Click(sender As Object, e As EventArgs) Handles GunaButton40.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub GunaButton41_Click(sender As Object, e As EventArgs) Handles GunaButton41.Click
        Form1.Show()
        Form1.BringToFront()
        Me.Dispose()
    End Sub

    Private Sub GunaTransfarantPictureBox3_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox3.Click
        Menu.Visible = True
        GunaElipsePanel11.Visible = True
        GunaElipsePanel1.Visible = False
        GunaElipsePanel11.Visible = True

    End Sub

    Private Sub GunaTransfarantPictureBox2_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox2.Click
        Form1.Show()
        Form1.BringToFront()
        Me.Dispose()
    End Sub

    Private Sub GunaButton42_Click(sender As Object, e As EventArgs) Handles GunaButton42.Click
        Menu.Visible = True
        GunaElipsePanel11.Visible = True
        GunaElipsePanel1.Visible = False
        GunaElipsePanel11.Visible = True

    End Sub

    Private Sub GunaElipsePanel1_Paint(sender As Object, e As PaintEventArgs) Handles GunaElipsePanel1.Paint

    End Sub

    Private Sub GunaButton43_Click(sender As Object, e As EventArgs) Handles GunaButton43.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("veuillez remplir toutes les cases avant d'envoyer un mail", MsgBoxStyle.Critical, "Mail")
        Else
            Try
                Dim mail As New MailMessage
                Dim SMTP As New SmtpClient("smtp.gmail.com")
                mail.From = New MailAddress(TextBox2.Text)
                'mail.To.Add("okembaprince3@gmail.com")
                mail.To.Add("talarthur04@gmail.com")
                mail.Subject = TextBox3.Text
                mail.Body = RichTextBox1.Text

                SMTP.Port = "587"
                SMTP.Credentials = New System.Net.NetworkCredential(TextBox2.Text, TextBox4.Text)
                SMTP.EnableSsl = True
                SMTP.Send(mail)
                MsgBox("Le mail est envoyé avec succes", MsgBoxStyle.Information, "Mail")
            Catch ex As Exception
                MsgBox(ex.Message)
                Process.Start("https://myaccount.google.com/lesssecureapps?pli=1&rapt=AEjHL4PlXCJx4wE99pw8tJh47YC9nuZJEqge4ORlpI91GSwzGK-krS7zay7VJ6TetX9rzVFab12K3Kou_5TBDpm0F3hKPVbOSg")
            End Try
        End If

        'https://myaccount.google.com/lesssecureapps?pli=1&rapt=AEjHL4PlXCJx4wE99pw8tJh47YC9nuZJEqge4ORlpI91GSwzGK-krS7zay7VJ6TetX9rzVFab12K3Kou_5TBDpm0F3hKPVbOSg
    End Sub


End Class