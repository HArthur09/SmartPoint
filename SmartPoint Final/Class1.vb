Imports System.Data.SQLite
Imports System.IO
'Public Shared Name

Public Class Class1
    Dim base As String
    Public Con As New SQLiteConnection
    Public ide As String
    Public p As Integer = 0
    Public IDU As String = 0
    Public ep As Boolean = False
    Public UTILISATEUR(4) As T_UTILISATEUR
    Public ETUDIANT(9) As T_ETUDIANT
    Public PERSONNEL(4) As T_PERSONNEL
    Public DISPOSITIFS(3) As T_DISPOSITIF
    Public PROGRAMMES(5) As T_TABLEDEPROGRAMMES
    Public POINTAGE(5) As T_POINTAGE
    Shared heis As String
    Public IdUtilisateur As String
    Public mot_de_passe As String

    'fonction verification_fichier_vide
    Public Function verification_fichier_vide()
        Dim w As String
        w = IO.File.ReadAllText(CurDir() & "\BDD\CSCS.db3")
        If Len(w) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'FONCTIONS OUVERTURE/CREATION ET FERMETURE DES LA BDD
    Public Function ouvertureBDD() 'ouverture de la base de donnees
        If IO.File.Exists(CurDir() & "\BDD\CSCS.db3") Then 'verification de l'existance de ce fichier(notre BDD)
            Try
                Con.ConnectionString = "data source=" & CurDir() & "\BDD\CSCS.db3"
                Con.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Return True
        Else
            'A defaut la creation d'une base de donnees
            Try
                Dim fc As FileStream = File.Create(CurDir() & "\BDD\CSCS.db3")
                Con.ConnectionString = "data source=" & CurDir() & "\BDD\CSCS.db3"
                'Con.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Return False
        End If
    End Function
    Public Sub fermetureBDD()
        ' fermeture de la BDD
        Con.Close()
    End Sub

    'FONCTIONS CREATION DES TABLES
    Public Function tableUtilisateur() 'creation d'une table pour les comptes des utilisateurs
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table UTILISATEUR
        SQlCommand.CommandText = "CREATE TABLE UTILISATEUR (Nom TEXT PRIMARY KEY, Prenoms TEXT, Statut TEXT, IDU TEXT, MDP TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function
    Public Function tableEtudiant()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table ETUDIANT
        SQlCommand.CommandText = "CREATE TABLE ETUDIANT (Nom TEXT PRIMARY KEY, Date_de_naissance TEXT, Niveau INTEGER, Filiere TEXT, Sexe TEXT, Groupe_TD TEXT, Groupe_TP TEXT, Matricule TEXT, Heures_absence INTEGER, IDE TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function
    Public Function tablePersonnel()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table PERSONNEL
        SQlCommand.CommandText = "CREATE TABLE PERSONNEL (Nom TEXT PRIMARY KEY, Matiere TEXT, Sexe TEXT, Statut TEXT, IDP TEXT, Heures_Absence TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function
    Public Function tableDispositif()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        'creation de la table DISPOSITIFS
        SQlCommand.CommandText = "CREATE TABLE DISPOSITIFS (IDD TEXT PRIMARY KEY, Salle TEXT, Dates TEXT, Date_import TEXT, Heures INTEGER)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function
    Public Function tableProgramme()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        ' creation de la table TABLES_DE_PROGRAMMES
        SQlCommand.CommandText = "CREATE TABLE PROGRAMMES (Id INTEGER PRIMARY KEY AUTOINCREMENT, IDD TEXT, Groupe TEXT, IDENS TEXT, Dates TEXT, Tranche_horaires TEXT, Filiere TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function
    Public Function tablepointage()
        Dim SQlCommand As SQLiteCommand = Con.CreateCommand
        ' creation de la table POINTAGE
        SQlCommand.CommandText = "CREATE TABLE POINTAGE (Id INTEGER PRIMARY KEY AUTOINCREMENT, IDE TEXT, IDP TEXT, IDD TEXT, Heures INTEGER, Dates TEXT)"
        SQlCommand.ExecuteNonQuery()
        SQlCommand.Dispose()
        Return True
    End Function

    'FONCTIONS CREATION DES STRUCTIONS
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
    Public Structure T_ETUDIANT
        Dim Id As Integer
        Dim Nom As String
        Dim Date_de_naissance As String
        Dim Niveau As Integer
        Dim Filiere As String
        Dim Sexe As Char
        Dim Groupe_TP As String
        Dim Groupe_TD As String
        Dim Matricule As String
        Dim Heures_absence As Integer
        Dim IDE As String
        Public Sub New(ByVal idx As Integer)
            Id = idx
            Nom = ""
            Date_de_naissance = ""
            Niveau = 0
            Filiere = ""
            Sexe = ""
            Groupe_TP = ""
            Groupe_TD = ""
            Matricule = ""
            Heures_absence = 0
            IDE = ""
        End Sub
    End Structure
    Public Structure T_PERSONNEL
        Dim id As Integer
        Dim Nom As String
        Dim Matiere As String
        Dim Sexe As String
        Dim Statut As String
        Dim IDP As String
        Public Sub New(ByVal idx As Integer)
            id = idx
            Nom = ""
            Sexe = ""
            Matiere = ""
            Statut = ""
            IDP = ""
        End Sub
    End Structure
    Public Structure T_DISPOSITIF
        Dim Id As Integer
        Dim IDD As String
        Dim Salle As String
        Dim Dates As String
        Dim Heures As Integer
        Public Sub New(ByVal IDD As String)
            Id = 0
            IDD = ""
            Salle = ""
            Dates = ""
            Heures = 0
        End Sub
    End Structure
    Public Structure T_TABLEDEPROGRAMMES
        Dim Id As Integer
        Dim IDD As String
        Dim Groupe As String
        Dim IDENS As String
        Dim Dates As String
        Dim Tranche_horaires As String
        Dim Filiere As String
        Public Sub New(ByVal IDD As String)
            Id = 0
            IDD = ""
            Groupe = ""
            IDENS = ""
            Dates = ""
            Tranche_horaires = ""
            Filiere = ""
        End Sub
    End Structure
    Public Structure T_POINTAGE
        Dim Id As Integer
        Dim IDE As String
        Dim IDP As String
        Dim IDD As String
        Dim Heures As Integer
        Dim Dates As String
        Public Sub New(ByVal IDE As String)
            Id = 0
            IDE = ""
            IDP = ""
            IDD = ""
            Dates = ""
            Heures = 0
        End Sub
    End Structure

    'FONCTIONS AJOUTS DES ELEMENTS
    Public Function AjouterUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        'Try
        Dim add As String = "INSERT INTO UTILISATEUR VALUES(@Nom,@Prenoms,@Statut,@IDU,@MDP)"
        Dim cmd = New SQLiteCommand(add, Con)
        cmd.Parameters.AddWithValue("@Nom", UTILISATEUR.Nom)
        cmd.Parameters.AddWithValue("@Prenoms", UTILISATEUR.Prenoms)
        cmd.Parameters.AddWithValue("@Statut", UTILISATEUR.Statut)
        cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
        cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        ep = True
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
        Return True
    End Function
    Public Function AjouterEtudiant(ByVal ETUDIANT As T_ETUDIANT)
        Try
            Dim add As String = "INSERT INTO ETUDIANT VALUES(@Nom,@Date_de_naissance,@Niveau,@Filiere,@Sexe,@Groupe_TD,@Groupe_TP,@Matricule,@Heures_absence,@IDE)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@Nom", ETUDIANT.Nom)
            cmd.Parameters.AddWithValue("@Date_de_naissance", ETUDIANT.Date_de_naissance)
            cmd.Parameters.AddWithValue("@Niveau", ETUDIANT.Niveau)
            cmd.Parameters.AddWithValue("@Filiere", ETUDIANT.Filiere)
            cmd.Parameters.AddWithValue("@Sexe", ETUDIANT.Sexe)
            cmd.Parameters.AddWithValue("@Groupe_TD", ETUDIANT.Groupe_TD)
            cmd.Parameters.AddWithValue("@Groupe_TP", ETUDIANT.Groupe_TP)
            cmd.Parameters.AddWithValue("@Matricule", ETUDIANT.Matricule)
            cmd.Parameters.AddWithValue("@Heures_absence", ETUDIANT.Heures_absence)
            cmd.Parameters.AddWithValue("@IDE", ETUDIANT.IDE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function AjouterPersonnel(ByVal PERSONNEL As T_PERSONNEL)
        Try
            Dim add As String = "INSERT INTO PERSONNEL VALUES(@Nom,@Matiere,@Sexe,@Statut,@IDP)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@Nom", PERSONNEL.Nom)
            cmd.Parameters.AddWithValue("@Matiere", PERSONNEL.Matiere)
            cmd.Parameters.AddWithValue("@Sexe", PERSONNEL.Sexe)
            cmd.Parameters.AddWithValue("@Statut", PERSONNEL.Statut)
            cmd.Parameters.AddWithValue("@IDP", PERSONNEL.IDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function AjouterDispositif(ByVal DISPOSITIF As T_DISPOSITIF)
        Try
            Dim add As String = "INSERT INTO DISPOSITIF VALUES(@IDD,@Salle,@Dates,@Heures)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@IDD", DISPOSITIF.IDD)
            cmd.Parameters.AddWithValue("@Salle", DISPOSITIF.Salle)
            cmd.Parameters.AddWithValue("@Dates", DISPOSITIF.Dates)
            cmd.Parameters.AddWithValue("@Heures", DISPOSITIF.Heures)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function AjouterProgrammes(ByVal PROGRAMMES As T_TABLEDEPROGRAMMES)
        Try
            Dim add As String = "INSERT INTO PREOGRAMMES VALUES(@Id,@IDD,@Groupe,@Dates,@Tranche_horaires,@Filiere)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@Id", PROGRAMMES.Id)
            cmd.Parameters.AddWithValue("@IDD", PROGRAMMES.IDD)
            cmd.Parameters.AddWithValue("@Groupe", PROGRAMMES.Groupe)
            cmd.Parameters.AddWithValue("@Dates", PROGRAMMES.Dates)
            cmd.Parameters.AddWithValue("@Tranche_horaires", PROGRAMMES.Tranche_horaires)
            cmd.Parameters.AddWithValue("@Filiere", PROGRAMMES.Filiere)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function Ajouterpointage(ByVal POINTAGE As T_POINTAGE)
        Try
            Dim add As String = "INSERT INTO POINTAGE VALUES(@Id,@IDE,@IDP,@IDD,@Heures,@Dates)"
            Dim cmd = New SQLiteCommand(add, Con)
            cmd.Parameters.AddWithValue("@Id", POINTAGE.Id)
            cmd.Parameters.AddWithValue("@IDE", POINTAGE.IDE)
            cmd.Parameters.AddWithValue("@IDP", POINTAGE.IDP)
            cmd.Parameters.AddWithValue("@IDD", POINTAGE.IDD)
            cmd.Parameters.AddWithValue("@Heures", POINTAGE.Heures)
            cmd.Parameters.AddWithValue("@Dates", POINTAGE.Dates)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    'FONCTIONS SELECTION DES ELEMENTS
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
    Public Sub SelectionEtudiant()
        p = 0
        Dim selec As String = "SELECT * FROM ETUDIANT"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            ETUDIANT(p).Nom = dr(0)
            ETUDIANT(p).Date_de_naissance = dr(1)
            ETUDIANT(p).Niveau = dr(2)
            ETUDIANT(p).Filiere = dr(3)
            ETUDIANT(p).Sexe = dr(4)
            ETUDIANT(p).Groupe_TD = dr(5)
            ETUDIANT(p).Groupe_TP = dr(6)
            ETUDIANT(p).Matricule = dr(7)
            ETUDIANT(p).Heures_absence = dr(8)
            ETUDIANT(p).IDE = dr(9)
            p = p + 1
        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Public Sub SelectionPersonnel()
        p = 0
        Dim selec As String = "SELECT * FROM PERSONNEL"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            PERSONNEL(p).Nom = dr(0)
            PERSONNEL(p).Matiere = dr(1)
            PERSONNEL(p).Sexe = dr(2)
            PERSONNEL(p).Statut = dr(3)
            PERSONNEL(p).IDP = dr(4)
            p = p + 1
        End While
        'MsgBox(PERSONNEL(p).IDP)
        dr.Close()
        cmd.Dispose()
    End Sub
    Public Sub SelectionDispositif()
        p = 0
        Dim selec As String = "SELECT * FROM DISPOSITIFS"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            DISPOSITIFS(p).IDD = dr(0)
            DISPOSITIFS(p).Salle = dr(1)
            DISPOSITIFS(p).Dates = dr(2)
            DISPOSITIFS(p).Heures = dr(3)
        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Public Sub SelectionProgrammes()
        p = 0
        Dim selec As String = "SELECT * FROM PROGRAMMES"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            PROGRAMMES(p).Id = dr(0)
            PROGRAMMES(p).IDD = dr(1)
            PROGRAMMES(p).Groupe = dr(2)
            PROGRAMMES(p).IDENS = dr(3)
            PROGRAMMES(p).Dates = dr(4)
            PROGRAMMES(p).Filiere = dr(5)
        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Public Sub SelectionPointage()
        p = 0
        Dim selec As String = "SELECT * FROM PROGRAMMES"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        While (dr.Read())
            POINTAGE(0).Id = dr(0)
            POINTAGE(1).IDE = dr(1)
            POINTAGE(2).IDP = dr(2)
            POINTAGE(3).IDD = dr(3)
            POINTAGE(4).Heures = dr(4)
            POINTAGE(5).Dates = dr(5)
        End While
        dr.Close()
        cmd.Dispose()
    End Sub

    'AFFICHER LE CONTENU
    Public Sub afficherutilisateur()
        For i = 0 To p - 1
            MsgBox(UTILISATEUR(i).Id)
        Next
    End Sub
    Public Sub afficheretudiant()
        For i = 0 To p - 1
            MsgBox(ETUDIANT(i).IDE)
        Next
    End Sub
    Public Sub afficherPersonnel()
        For i = 0 To p - 1
            MsgBox(PERSONNEL(i).IDP)
        Next
    End Sub

    'FONCTIONs SUPPRESSION DES ELEMENTS
    Public Function SupprimUtilisateur()
        Dim sup As String = "DELETE FROM UTILISATEUR WHERE Id=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MsgBox("ok")
        Return True
    End Function
    Public Function SupprimEtudiant()
        Dim sup As String = "DELETE FROM ETUDIANT WHERE IDE=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Return True
    End Function
    Public Function SupprimPersonnel()
        Dim sup As String = "DELETE FROM PERSONNEL WHERE IDD=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Return True
    End Function
    Public Function SupprimDispositif()
        Dim sup As String = "DELETE FROM DISPOSITIF WHERE IDD=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Return True
    End Function
    Public Function SupprimProgramme()
        Dim sup As String = "DELETE FROM PROGRAMME WHERE Id=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Return True
    End Function
    Public Function SupprimPointage()
        Dim sup As String = "DELETE FROM POINTAGE WHERE Id=" & ide
        Dim cmd As New SQLiteCommand(sup, Con)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Return True
    End Function

    'selection precise
    Public Sub selecte()
        p = 0
        Try
            Dim selec As String = "SELECT * FROM UTILISATEUR"
            Dim cmf = New SQLiteCommand(selec, Con)
            Dim dr As SQLiteDataReader = cmf.ExecuteReader

            While (dr.Read())
                UTILISATEUR(p).IDU = dr(4)
            End While
            For i = 0 To p - 1
                If UTILISATEUR(i).IDU = IDU Then
                    MsgBox("present")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'FONCTION MODIFICATIONS DES INFORMATIONS A PARTIR DES IDENTIFIANT UNIQUE
    Public Function ModifUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        Try
            Dim modi As String = "UPDATE UTILISATEUR SET Nom=@Nom,Prenoms=@Prenoms,Statut=@Statut,MDP=@MDP WHERE IDU=@IDU"
            Dim cmd = New SQLiteCommand(modi, Con)
            cmd.Parameters.AddWithValue("@Nom", UTILISATEUR.Nom)
            cmd.Parameters.AddWithValue("@Prenoms", UTILISATEUR.Prenoms)
            cmd.Parameters.AddWithValue("@Statut", UTILISATEUR.Statut)
            cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
            cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifEtudiant(ByVal ETUDIANT As T_ETUDIANT)
        Try
            Dim modi As String = "UPDATE ETUDIANT SET Nom=@Nom,Date_de_naissance=@Date_de_naissance,Niveau=@Niveau,Filiere=@Filiere,Sexe=@Sexe,Groupe_TD=@Groupe_TD,Group_TP=@Groupe_TP,Matiere=@Matiere,Heures_absence=@Heures_absence WHERE IDE=@IDE"
            Dim cmd = New SQLiteCommand(modi, Con)
            cmd.Parameters.AddWithValue("@Nom", ETUDIANT.Nom)
            cmd.Parameters.AddWithValue("@Date_de_naissance", ETUDIANT.Date_de_naissance)
            cmd.Parameters.AddWithValue("@Niveau", ETUDIANT.Niveau)
            cmd.Parameters.AddWithValue("@Filiere", ETUDIANT.Filiere)
            cmd.Parameters.AddWithValue("@Sexe", ETUDIANT.Sexe)
            cmd.Parameters.AddWithValue("@Groupe_TD", ETUDIANT.Groupe_TD)
            cmd.Parameters.AddWithValue("@Groupe_TP", ETUDIANT.Groupe_TP)
            cmd.Parameters.AddWithValue("@Heures_absence", ETUDIANT.Heures_absence)
            cmd.Parameters.AddWithValue("@IDE", ETUDIANT.IDE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifPersonnel(ByVal PERSONNEL As T_PERSONNEL)
        Try
            Dim modi As String = "UPDATE PERSONNEL SET Nom=@Nom,Matiere=@Matiere,Sexe=@Sexe,Statut=@Statut WHERE IDP=@IDP"
            Dim cmd = New SQLiteCommand(modi, Con)
            cmd.Parameters.AddWithValue("@Nom", PERSONNEL.Nom)
            cmd.Parameters.AddWithValue("@Matiere", PERSONNEL.Matiere)
            cmd.Parameters.AddWithValue("@Statut", PERSONNEL.Statut)
            cmd.Parameters.AddWithValue("@IDP", PERSONNEL.IDP)
            cmd.Parameters.AddWithValue("@Sexe", PERSONNEL.Sexe)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifDispositif(ByVal DISPOSITIF As T_DISPOSITIF)
        Try
            Dim modif As String = "UPDATE DISPOSITIF SET Salle=@Salle,Dates=@Dates,Heures=@Heures WHERE IDD=@IDD"
            Dim cmd = New SQLiteCommand(modif, Con)
            cmd.Parameters.AddWithValue("@IDD", DISPOSITIF.IDD)
            cmd.Parameters.AddWithValue("@Salle", DISPOSITIF.Salle)
            cmd.Parameters.AddWithValue("@Dates", DISPOSITIF.Dates)
            cmd.Parameters.AddWithValue("@Heures", DISPOSITIF.Heures)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifProgrammes(ByVal PROGRAMMES As T_TABLEDEPROGRAMMES)
        Try
            Dim modif As String = "UPDATE PREOGRAMMES SET IDD=@IDD,Groupe=@Groupe,Dates=@Dates,Tranche_horaires=@Tranche_horaires,Filiere=@Filiere WHERE Id=@Id"
            Dim cmd = New SQLiteCommand(modif, Con)
            cmd.Parameters.AddWithValue("@Id", PROGRAMMES.Id)
            cmd.Parameters.AddWithValue("@IDD", PROGRAMMES.IDD)
            cmd.Parameters.AddWithValue("@Groupe", PROGRAMMES.Groupe)
            cmd.Parameters.AddWithValue("@Dates", PROGRAMMES.Dates)
            cmd.Parameters.AddWithValue("@Tranche_horaires", PROGRAMMES.Tranche_horaires)
            cmd.Parameters.AddWithValue("@Filiere", PROGRAMMES.Filiere)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifPointage(ByVal POINTAGE As T_POINTAGE)
        Try
            Dim modif As String = "UPDATE POINTAGE SET IDE=@IDE,IDP=@IDP,IDD=@IDD,Heures=@Heures,Dates=@Dates WHERE Id=@Id"
            Dim cmd = New SQLiteCommand(modif, Con)
            cmd.Parameters.AddWithValue("@Id", POINTAGE.Id)
            cmd.Parameters.AddWithValue("@IDE", POINTAGE.IDE)
            cmd.Parameters.AddWithValue("@IDP", POINTAGE.IDP)
            cmd.Parameters.AddWithValue("@IDD", POINTAGE.IDD)
            cmd.Parameters.AddWithValue("@Heures", POINTAGE.Heures)
            cmd.Parameters.AddWithValue("@Dates", POINTAGE.Dates)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    'FONCTION DE L'AUTHENTIFICATION
    Public Function authentification()
        Dim n As Boolean = False
        Try
            For i = 0 To p - 1
                If UTILISATEUR(i).IDU = IdUtilisateur Then
                    If UTILISATEUR(i).MDP = mot_de_passe Then
                        n = True
                    Else
                        MsgBox("verifiez votre mot de passe")
                        n = False
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return n
    End Function

    'FONCTION GEENERER LES IDENTIFIANT

    Public Function genererIdEtudiant()
        Dim a As String
        Dim f As Char
        Dim n As String = 1
        Dim IDE As String = ""
        Dim max As Integer = 0
        p = 0
        a = Date.Now.Year
        f = "A"
        Try
            Dim selec As String = "SELECT * FROM ETUDIANT"
            Dim cmd = New SQLiteCommand(selec, Con)
            Dim dr As SQLiteDataReader = cmd.ExecuteReader

            If dr(8).ToString = "" Then
                IDE = a & f & n
            Else
                If ETUDIANT(p).IDE.Split("A")(0) = a Then
                    If max < ETUDIANT(p).IDE.Split("A")(1) Then
                        max = CInt(ETUDIANT(p).IDE.Split("A")(1)) + 1
                        IDE = a & f & max
                    End If
                End If
            End If
            MsgBox(IDE)
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return IDE
    End Function
    Public Function genererIdPersonnel()
        Dim a As String
        Dim f As Char
        Dim n As String = 1
        Dim Io As String = ""
        Dim max As Integer = 0
        p = 0
        a = Date.Now.Year
        f = "B"

        Dim selec As String = "SELECT * FROM PERSONNEL"
        Dim cmd = New SQLiteCommand(selec, Con)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader

        'MsgBox(dr(4))
        If dr(4).ToString = "" Then
            Io = a & f & n
        Else
            If PERSONNEL(p).IDP.Split("B")(0) = a Then
                If max < PERSONNEL(p).IDP.Split("B")(1) Then
                    max = CInt(PERSONNEL(p).IDP.Split("B")(1)) + 1
                    Io = a & f & CStr(max)
                End If
            End If
        End If
        cmd.Dispose()
        Return Io
    End Function
    Public Function genererIdDispositif()
        Dim a As String
        Dim f As Char
        Dim n As String = 1
        Dim IDd As String = 0
        Dim max As Integer = 0
        p = 0
        a = Date.Now.Year
        f = "C"
        Try
            Dim selec As String = "SELECT * FROM DISPOSITIF"
            Dim cmd = New SQLiteCommand(selec, Con)
            Dim dr As SQLiteDataReader = cmd.ExecuteReader

            If dr(1).ToString = "" Then
                IDd = a & f & n
            Else
                If DISPOSITIFS(p).IDD.Split("C")(0) = a Then
                    If max < DISPOSITIFS(p).IDD.Split("C")(1) Then
                        max = CInt(ETUDIANT(p).IDE.Split("C")(1)) + 1
                        IDd = a & f & CStr(max)
                    End If
                End If
            End If
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return IDd
    End Function

End Class