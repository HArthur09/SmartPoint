Module Module1

    Structure Dispositif

        Dim ID_Disp As String
        Dim Salle As String
        Dim Date_enregis As Date
        Dim Date_last_import As Date
        Dim Heure_last_impor As Integer
    End Structure

    Public Tab_disp(50) As Dispositif

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

End Module
