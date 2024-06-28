Imports System.Data.SQLite
Imports System.IO
Public Class FONCTION_BD
    Dim base As String
    Dim Con As New SQLiteConnection
    Public com As Boolean
    Dim p As Integer = 0
    Dim UTILISATEUR(5) As T_UTILISATEUR

    'Fonction ouverture de la BD
    Public Sub ouvertureBDD() 'ouverture de la base de donnees

        If IO.File.Exists(CurDir() & "\BDD\CSCS.db3") Then 'verification de l'existance de ce fichier(notre BDD)
            Try
                Con.ConnectionString = "data source=" & CurDir() & "\BDD\CSCS.db3"
                Con.Open()
                com = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            'A defaut la creation d'une base de donnees
            Dim SFD As New SaveFileDialog
            SFD.Filter = "SQLite|*db3"
            SFD.ShowDialog()

            Con.ConnectionString = "data source=" & CurDir() & "\BDD\CSCS.db3"
            Con.Open()
            com = False

        End If
    End Sub
    'Fonction fermeture de la bd
    Public Sub fermetureBDD()
        ' fermeture de la BDD
        Con.Close()
    End Sub
    'Fonction verification de la bdd
    Public Function verification_fichier_vide()
        Dim w As String
        w = IO.File.ReadAllText(CurDir() & "\BDD\CSCS.db3")
        If Len(w) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    'FONCTIONS CREATION DES TABLES
    Public Sub TableUtilisateur() 'creation d'une table pour les comptes des utilisateurs

        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table UTILISATEUR
        SQlCommand.CommandText = "CREATE TABLE UTILISATEUR (Nom TEXT PRIMARY KEY NOT NULL, Prenoms TEXT, Statut TEXT, IDU TEXT, MDP TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
    End Sub
    Public Sub tableEtudiant()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table ETUDIANT
        SQlCommand.CommandText = "CREATE TABLE ETUDIANT (Nom TEXT PRIMARY KEY NOT NULL , Date_de_naissance TEXT, Niveau INTEGER, Filiere TEXT, Sexe TEXT, Groupe_TD TEXT, Groupe_TP TEXT, Heures_absence INTEGER, IDE TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
    End Sub
    Public Sub tablePersonnel()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table PERSONNEL
        SQlCommand.CommandText = "CREATE TABLE PERSONNEL (Nom TEXT PRIMARY KEY NOT NULL, Matiere TEXT, Sexe TEXT, Statut TEXT, IDP TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
    End Sub
    Public Sub tableDispositif()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table DISPOSITIFS
        SQlCommand.CommandText = "CREATE TABLE DISPOSITIFS (IDD TEXT PRIMARY KEY NOT NULL, Salle TEXT, Dates TEXT, Heures INTEGER)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
    End Sub
    Public Sub tableProgramme()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        ' creation de la table TABLES_DE_PROGRAMMES
        SQlCommand.CommandText = "CREATE TABLE PROGRAMMES (IDD TEXT PRIMARY KEY NOT NULL, Groupe TEXT, IDENS TEXT, Dates TEXT, Tranche_horaires TEXT, Filiere TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
    End Sub
    Public Sub tablepointage()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        ' creation de la table POINTAGE
        SQlCommand.CommandText = "CREATE TABLE POINTAGE (IDE TEXT PRIMARY KEY NOT NULL, IDP TEXT, IDD TEXT, Heures INTEGER, Dates TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()

    End Sub

    'FONCTION DES STRUCTURES
    Public Structure T_UTILISATEUR
        Dim Id As Integer
        Dim Nom As String
        Dim Prenoms As String
        Dim Statut As String
        Dim IDU As String
        Dim MDP As String
        Public Sub New(ByVal idx As String)
            Id = idx
            Nom = ""
            Prenoms = ""
            Statut = ""
            IDU = ""
            MDP = ""
        End Sub
    End Structure

    'FONCTIONS AJOUTS DES ELEMENTS
    Public Function AjouterUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        Dim rep As Boolean = False
        Try
            Dim add As String = "INSERT INTO UTILISATEUR VALUES(@Nom,@Prenoms,@Statut,@IDU,@MDP)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@Nom", UTILISATEUR.Nom)
            cmd.Parameters.AddWithValue("@Prenoms", UTILISATEUR.Prenoms)
            cmd.Parameters.AddWithValue("@Statut", UTILISATEUR.Statut)
            cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
            cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            rep = True
        Catch ex As Exception
            rep = False
            MessageBox.Show(ex.Message)
        End Try
        Return rep
        MsgBox("ok")
    End Function

    'FONCTION AUTHENTIFICATION
    Public Function authentification()
        Dim IdUtilisateur As String = Form1.GunaLineTextBox1.Text
        Dim mot_de_passe As String = Form1.GunaLineTextBox2.Text
        For i = 0 To p - 1
            If UTILISATEUR(i).IDU = IdUtilisateur Then
                If UTILISATEUR(i).MDP = mot_de_passe Then
                    Return True
                Else
                    MsgBox("verifiez votre mot de passe")
                    Return False
                End If
            End If
        Next
    End Function
    'FONCTION SELECTIONS DANS LES TABLES
    Public Sub SelectionUtilisateur()
        p = 0
        Dim selec As String = "SELECT * FROM UTILISATEUR"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            UTILISATEUR(p).Nom = dr(0)
            UTILISATEUR(p).Prenoms = dr(1)
            UTILISATEUR(p).Statut = dr(2)
            UTILISATEUR(p).IDU = dr(3)
            UTILISATEUR(p).MDP = dr(4)
            p = p + 1
        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    'FONCTION GENERER_LES_IDENTIFIANT
    Public Sub genere_identifiant()

    End Sub

End Class
