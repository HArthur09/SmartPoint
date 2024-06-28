Imports MySql.Data.MySqlClient
Public Class Class4
    Public cmd As New MySqlCommand
    Public con As New MySqlConnection
    Public dr As MySqlDataReader
    Public Utilisateur(100) As T_UTILISATEUR
    Public ETUDIANT(400) As T_ETUDIANT
    Public PERSONNEL(100) As T_PERSONNEL
    Public DISPOSITIFS(10) As T_DISPOSITIF
    Public PROGRAMMES(100) As T_PROGRAMMES
    Public POINTAGE(500) As T_POINTAGE
    Public p, f, b As Integer
    Public n As Boolean = False
    Public t As Boolean = False
    Public heure, idu As String
    Public IDE As String = ""
    Public Io As String = ""
    Public max As Integer = 0
    Public maxi As Integer = 0
    Public ni As Integer = 1


    Public Function creation_base_de_données()
        con = New MySqlConnection
        cmd = con.CreateCommand
        Try
            con.ConnectionString = "server=localhost;database=;User=root;password=;"
            con.Open()
            cmd.CommandText = "CREATE DATABASE IF NOT EXISTS SMARTPOINT"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            MsgBox("ok")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function

    Public Function ouverture_connection()
        Try
            con.ConnectionString = "server=localhost;database=smartpoint;User=root;password=;"
            con.Open()
        Catch ex As Exception
            con = Nothing
            MsgBox("Erreur de connexion")
        End Try
        Return True
    End Function

    Public Function fermeture_connection()
        con.Close()
        Return True
    End Function

    Public Function Creation_table_Utilisateur()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE UTILISATEUR (Nom TEXT, Prenoms TEXT, Statut TEXT, IDU VARCHAR(100) PRIMARY KEY, MDP TEXT)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function Creation_table_etudiant()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE ETUDIANT (Nom TEXT, Date_de_naissance DATE, Niveau INTEGER, Filiere VARCHAR(100), Sexe TEXT, Groupe_TD VARCHAR(100), Groupe_TP TEXT, Matricule TEXT, Heures_absence INTEGER, IDE VARCHAR(100) PRIMARY KEY)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function Creation_table_personnel()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE PERSONNEL (Nom TEXT, Matiere TEXT, Sexe TEXT, Statut TEXT, IDP VARCHAR(100) PRIMARY KEY, Heures_Absence INT, SALAIRE_PAR_HEURE INT, SALAIRE_TOTAL INT)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function Creation_table_dispositifs()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE DISPOSITIFS (IDD VARCHAR(100) PRIMARY KEY, Salle VARCHAR(100), Dates Date, Date_import Date, Heures datetime, foreign key (salle) references programmes.salle)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function Creation_table_programme()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE PROGRAMMES (SALLE VARCHAR(100), Groupe VARCHAR(100), ENSEIGNANT VARCHAR(100), Dates Date, Filiere TEXT, Tranche_horaire_debut Time,Tranche_horaire_fin Time, Semaine_debut Text, Semaine_fin Text, matiere text, foreign key (groupe) references etudiant.filiere, foreign key (groupe) references etudiant.groupe_td, foreign key (enseignant) references personnel.nom, foreign key (salle) references dispositifs.salle)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function Creation_table_pointage()
        cmd = con.CreateCommand
        Try
            cmd.CommandText = "CREATE TABLE POINTAGE (IDE VARCHAR(100), IDP VARCHAR(100), IDD VARCHAR(100), Heures time, Dates Date, FOREIGN KEY (IDD) REFERENCES DISPOSITIFS.IDD, FOREIGN KEY (IDE) REFERENCES ETUDIANT.IDE, FOREIGN KEY (IDP) REFERENCES PERSONNEL.IDP)"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function


    Public Structure T_UTILISATEUR
        Dim Nom As String
        Dim Prenoms As String
        Dim Statut As String
        Dim IDU As String
        Dim MDP As String
        Public Sub New(ByVal IDU As String)
            Nom = ""
            Prenoms = ""
            Statut = ""
            IDU = ""
            MDP = ""
        End Sub
    End Structure
    Public Structure T_ETUDIANT
        Dim Nom As String
        Dim Date_de_naissance As Date
        Dim Niveau As Integer
        Dim Filiere As String
        Dim Sexe As Char
        Dim Groupe_TP As String
        Dim Groupe_TD As String
        Dim Matricule As String
        Dim Heures_absence As Integer
        Dim IDE As String
        Public Sub New(ByVal Niveau As Integer)
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
        Dim Nom As String
        Dim Matiere As String
        Dim Sexe As String
        Dim Statut As String
        Dim IDP As String
        Dim heures As Integer
        Dim salaire_par_heure As Integer
        Dim salaire_total As Integer
        Public Sub New(ByVal Nom As String)
            Nom = ""
            Sexe = ""
            Matiere = ""
            Statut = ""
            IDP = ""
            heures = 0
            salaire_par_heure = 0
            salaire_total = 0
        End Sub
    End Structure
    Public Structure T_DISPOSITIF
        Dim IDD As String
        Dim Salle As String
        Dim Dates As Date
        Dim Date_import As Date
        Dim Heures As DateTime
        Public Sub New(ByVal IDD As String)
            IDD = ""
            Salle = ""
            Dates = ""
            Date_import = ""
            Heures = ""
        End Sub
    End Structure
    Public Structure T_PROGRAMMES
        Dim Salle As String
        Dim Groupe As String
        Dim IDENS As String
        Dim Dates As Date
        Dim Tranches_horaire_debut As TimeSpan
        Dim Tranches_horaire_fin As TimeSpan
        Dim semaine_debut As String
        Dim semaine_fin As String
        Dim matiere As String
        Public Sub New(ByVal Salle As String)
            Salle = ""
            Groupe = ""
            IDENS = ""
            Dates = ""
            Tranches_horaire_debut = TimeSpan.Parse("")
            Tranches_horaire_fin = TimeSpan.Parse("")
            semaine_debut = ""
            semaine_fin = ""
            matiere = ""
        End Sub
    End Structure
    Public Structure T_POINTAGE
        Dim IDE As String
        Dim IDP As String
        Dim IDD As String
        Dim Heures As String
        Dim Dates As Date
        Public Sub New(ByVal IDE As String)
            IDE = ""
            IDP = ""
            IDD = ""
            Dates = ""
            Heures = ""
        End Sub
    End Structure

    Public Function Verification_base_vide()
        cmd = con.CreateCommand
        Dim n As Boolean = False
        Try
            cmd.CommandText = "SELECT * FROM UTILISATEUR"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader
            cmd.Dispose()
            While (dr.Read())
                Utilisateur(0).Nom = dr(0)
            End While
            If Utilisateur(0).Nom = "" Then
                n = True
            Else
                n = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return n
    End Function
    'Fonction d'ajout
    Public Function AjoutUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "INSERT INTO UTILISATEUR VALUES (@Nom,@Prenoms,@Statut,@IDU,@MDP)"
            cmd.Parameters.AddWithValue("@Nom", UTILISATEUR.Nom)
            cmd.Parameters.AddWithValue("@Prenoms", UTILISATEUR.Prenoms)
            cmd.Parameters.AddWithValue("@Statut", UTILISATEUR.Statut)
            cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
            cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return n
        End Try
        Return True
    End Function
    Public Function AjouterEtudiant(ByVal ETUDIANT As T_ETUDIANT)
        n = False
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "INSERT INTO ETUDIANT VALUES(@Nom,@Date_de_naissance,@Niveau,@Filiere,@Sexe,@Groupe_TD,@Groupe_TP,@Matricule,@Heures_absence,@IDE)"
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
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Public Function AjouterPersonnel(ByVal PERSONNEL As T_PERSONNEL)
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "INSERT INTO PERSONNEL VALUES(@Nom,@Matiere,@Sexe,@Statut,@IDP,@Heures_Absence, @salaire_par_heure, @salaire_total)"
            cmd.Parameters.AddWithValue("@Nom", PERSONNEL.Nom)
            cmd.Parameters.AddWithValue("@Matiere", PERSONNEL.Matiere)
            cmd.Parameters.AddWithValue("@Sexe", PERSONNEL.Sexe)
            cmd.Parameters.AddWithValue("@Statut", PERSONNEL.Statut)
            cmd.Parameters.AddWithValue("@IDP", PERSONNEL.IDP)
            cmd.Parameters.AddWithValue("@Heures_Absence", PERSONNEL.heures)
            cmd.Parameters.AddWithValue("@salaire_par_heure", PERSONNEL.salaire_par_heure)
            cmd.Parameters.AddWithValue("@salaire_total", PERSONNEL.salaire_total)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Public Function AjouterDispositif(ByVal DISPOSITIF As T_DISPOSITIF)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "INSERT INTO DISPOSITIFS VALUES(@IDD,@Salle, now(), now(), now())"
            cmd.Parameters.AddWithValue("@IDD", DISPOSITIF.IDD)
            cmd.Parameters.AddWithValue("@Salle", DISPOSITIF.Salle)
            'cmd.Parameters.AddWithValue("@Dates", DISPOSITIF.Dates)
            'cmd.Parameters.AddWithValue("@Date_import", DISPOSITIF.Date_import)
            'cmd.Parameters.AddWithValue("@Heures", DISPOSITIF.Heures)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function AjouterProgrammes(ByVal PROGRAMMES As T_PROGRAMMES)
        n = False
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "INSERT INTO PROGRAMMES VALUES(@Salle,@Groupe,@IDENS,@Dates,@Tranche_horaire_debut,@Tranche_horaire_fin,@semaine_debut,@semaine_fin,@matiere)"
            cmd.Parameters.AddWithValue("@Salle", PROGRAMMES.Salle)
            cmd.Parameters.AddWithValue("@Groupe", PROGRAMMES.Groupe)
            cmd.Parameters.AddWithValue("@IDENS", PROGRAMMES.IDENS)
            cmd.Parameters.AddWithValue("@Dates", PROGRAMMES.Dates)
            cmd.Parameters.AddWithValue("@Tranche_horaire_debut", PROGRAMMES.Tranches_horaire_debut)
            cmd.Parameters.AddWithValue("@Tranche_horaire_fin", PROGRAMMES.Tranches_horaire_fin)
            cmd.Parameters.AddWithValue("@semaine_debut", PROGRAMMES.semaine_debut)
            cmd.Parameters.AddWithValue("@semaine_fin", PROGRAMMES.semaine_fin)
            cmd.Parameters.AddWithValue("@matiere", PROGRAMMES.matiere)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function Ajouterpointage(ByVal POINTAGE As T_POINTAGE)
        Try
            n = False
            cmd = con.CreateCommand
            cmd.CommandText = "INSERT INTO POINTAGE VALUES(@IDE,@IDP,@IDD,@Heures,@Dates)"
            cmd.Parameters.AddWithValue("@IDE", POINTAGE.IDE)
            cmd.Parameters.AddWithValue("@IDP", POINTAGE.IDP)
            cmd.Parameters.AddWithValue("@IDD", POINTAGE.IDD)
            cmd.Parameters.AddWithValue("@Heures", POINTAGE.Heures)
            cmd.Parameters.AddWithValue("@Dates", POINTAGE.Dates)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function

    'fonction de suppression
    Public Function SupprimUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM UTILISATEUR WHERE IDU=@IDU"
            cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function
    Public Function SupprimEtudiant(ByVal ETUDIANT As T_ETUDIANT)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM ETUDIANT WHERE IDE=@IDE"
            cmd.Parameters.AddWithValue("@IDE", ETUDIANT.IDE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function SupprimPersonnel(ByVal PERSONNEL As T_PERSONNEL)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM PERSONNEL WHERE IDP=@IDP"
            cmd.Parameters.AddWithValue("@IDP", PERSONNEL.IDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function SupprimDispositif(ByVal DISPOSITIF As T_DISPOSITIF)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM DISPOSITIFS WHERE IDD=@IDD"
            cmd.Parameters.AddWithValue("@IDD", DISPOSITIF.IDD)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function SupprimProgramme(ByVal PROGRAMMES As T_PROGRAMMES)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM PROGRAMMES WHERE Dates=@Dates"
            cmd.Parameters.AddWithValue("@id", PROGRAMMES.Dates)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function SupprimPointage(ByVal POINTAGE As T_POINTAGE)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "DELETE FROM POINTAGE WHERE IDE=@IDE"
            cmd.Parameters.AddWithValue("@IDE", POINTAGE.IDE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function

    'fonction de modification
    Public Function ModifUtilisateur(ByVal UTILISATEUR As T_UTILISATEUR)
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "UPDATE UTILISATEUR SET Nom=@Nom,Prenoms=@Prenoms,Statut=@Statut,IDU=@IDU,MDP=@MDP WHERE IDU=@id"
            cmd.Parameters.AddWithValue("@Nom", UTILISATEUR.Nom)
            cmd.Parameters.AddWithValue("@Prenoms", UTILISATEUR.Prenoms)
            cmd.Parameters.AddWithValue("@Statut", UTILISATEUR.Statut)
            cmd.Parameters.AddWithValue("@IDU", UTILISATEUR.IDU)
            cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
            cmd.Parameters.AddWithValue("@id", idu)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifMot_de_passe(ByVal UTILISATEUR As T_UTILISATEUR)
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "UPDATE UTILISATEUR SET MDP=@MDP WHERE IDU=@id"
            cmd.Parameters.AddWithValue("@MDP", UTILISATEUR.MDP)
            cmd.Parameters.AddWithValue("@id", idu)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifEtudiant(ByVal ETUDIANT As T_ETUDIANT)
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "UPDATE ETUDIANT SET Nom=@Nom,Date_de_naissance=@Date_de_naissance,Niveau=@Niveau,Filiere=@Filiere,Sexe=@Sexe,Groupe_TD=@Groupe_TD,Group_TP=@Groupe_TP,Matiere=@Matiere,Heures_absence=@Heures_absence WHERE IDE=@IDE"
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
            cmd = con.CreateCommand
            cmd.CommandText = "UPDATE PERSONNEL SET Nom=@Nom,Matiere=@Matiere,Sexe=@Sexe,Statut=@Statut,salaire_par_heure=@salaire_par_heure,salaire_total=@salaire_total WHERE IDP=@IDP"
            cmd.Parameters.AddWithValue("@Nom", PERSONNEL.Nom)
            cmd.Parameters.AddWithValue("@Matiere", PERSONNEL.Matiere)
            cmd.Parameters.AddWithValue("@Statut", PERSONNEL.Statut)
            cmd.Parameters.AddWithValue("@Sexe", PERSONNEL.Sexe)
            cmd.Parameters.AddWithValue("@IDP", PERSONNEL.IDP)
            cmd.Parameters.AddWithValue("@salaire_par_heure", PERSONNEL.salaire_par_heure)
            cmd.Parameters.AddWithValue("@salaire_total", PERSONNEL.salaire_total)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifDispositif(ByVal DISPOSITIF As T_DISPOSITIF)
        Try
            n = False
            cmd = con.CreateCommand
            cmd.CommandText = "UPDATE DISPOSITIFS SET Date_import=@Dates, heures=@heure WHERE IDD=@IDD"
            cmd.Parameters.AddWithValue("@Dates", Now())
            cmd.Parameters.AddWithValue("@heure", Now())
            cmd.Parameters.AddWithValue("@IDD", DISPOSITIF.IDD)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifProgrammes(ByVal PROGRAMMES As T_PROGRAMMES)
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "UPDATE PROGRAMMES SET IDD=@IDD,Groupe=@Groupe,IDENS=@IDENS,Dates=@Dates,Tranche_horaires=@Tranche_horaires,Filiere=@Filiere WHERE IDENS=@IDENS"
            cmd.Parameters.AddWithValue("@IDD", PROGRAMMES.Salle)
            cmd.Parameters.AddWithValue("@Groupe", PROGRAMMES.Groupe)
            cmd.Parameters.AddWithValue("@IDENS", PROGRAMMES.IDENS)
            cmd.Parameters.AddWithValue("@Dates", PROGRAMMES.Dates)
            cmd.Parameters.AddWithValue("@Tranche_horaires", PROGRAMMES.Tranches_horaire_debut)
            cmd.Parameters.AddWithValue("@Filiere", PROGRAMMES.Tranches_horaire_fin)
            cmd.Parameters.AddWithValue("@IDENS", PROGRAMMES.IDENS)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifPointage(ByVal POINTAGE As T_POINTAGE)
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "UPDATE POINTAGE SET IDE=@IDE,IDP=@IDP,IDD=@IDD,Heures=@Heures,Dates=@Dates WHERE IDE=@IDE"
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

    Public Sub SelectionUtilisateur()
        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT * FROM UTILISATEUR"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                Utilisateur(p).Nom = dr(0)
                Utilisateur(p).Prenoms = dr(1)
                Utilisateur(p).Statut = dr(2)
                Utilisateur(p).IDU = dr(3)
                Utilisateur(p).MDP = dr(4)
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub SelectionEtudiant()
        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT * FROM ETUDIANT"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub SelectionEtudiant_par_filiere(ByVal fil As String)
        p = 0
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "SELECT Nom, Sexe, Niveau, filiere, groupe_td, groupe_tp, IDE, heures_absence FROM ETUDIANT WHERE filiere = @filiere"
            cmd.Parameters.AddWithValue("@filiere", fil)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                ETUDIANT(p).Nom = dr(0)
                ETUDIANT(p).Sexe = dr(1)
                ETUDIANT(p).Niveau = dr(2)
                ETUDIANT(p).Filiere = dr(3)
                ETUDIANT(p).Groupe_TD = dr(4)
                ETUDIANT(p).Groupe_TP = dr(5)
                ETUDIANT(p).IDE = dr(6)
                ETUDIANT(p).Heures_absence = dr(7)
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub SelectionPersonnel()
        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT * FROM PERSONNEL"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                PERSONNEL(p).Nom = dr(0)
                PERSONNEL(p).Matiere = dr(1)
                PERSONNEL(p).Sexe = dr(2)
                PERSONNEL(p).Statut = dr(3)
                PERSONNEL(p).IDP = dr(4)
                PERSONNEL(p).heures = dr(5)
                PERSONNEL(p).salaire_par_heure = dr(6)
                PERSONNEL(p).salaire_total = dr(7)
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub SelectionPersonnel_Matiere(ByVal Pers As T_PERSONNEL)
        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT Matiere,Statut FROM PERSONNEL WHERE NOM=@NOM"
            cmd.Parameters.AddWithValue("@Nom", Pers.Nom)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                PERSONNEL(p).Matiere = dr(0)
                PERSONNEL(p).Statut = dr(1)
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Function SelectionDispositifs()

        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT * FROM DISPOSITIFS"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                DISPOSITIFS(p).IDD = dr(0)
                DISPOSITIFS(p).Salle = dr(1)
                DISPOSITIFS(p).Dates = dr(2)
                DISPOSITIFS(p).Date_import = dr(3)
                DISPOSITIFS(p).Heures = dr(4)
                heure = CStr(DISPOSITIFS(p).Heures)
                DISPOSITIFS(p).Heures = CDate(heure.Split(" ")(1))
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function SelectionProgrammes()

        cmd = con.CreateCommand
        p = 0
        Try
            cmd.CommandText = "SELECT * FROM PROGRAMMES"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader

            While (dr.Read())
                PROGRAMMES(p).Salle = dr(0)
                PROGRAMMES(p).Groupe = dr(1)
                PROGRAMMES(p).IDENS = dr(2)
                PROGRAMMES(p).Dates = dr(3)
                PROGRAMMES(p).Tranches_horaire_debut = dr(4)
                PROGRAMMES(p).Tranches_horaire_fin = dr(5)
                PROGRAMMES(p).semaine_debut = dr(6)
                PROGRAMMES(p).semaine_fin = dr(7)
                PROGRAMMES(p).matiere = dr(8)
                p = p + 1
            End While
            dr.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function
    Public Function authentification(ByVal util As T_UTILISATEUR)
        Try
            p = 0
            n = False
            cmd = con.CreateCommand
            cmd.CommandText = "SELECT IDU, MDP, Nom FROM UTILISATEUR WHERE IDU=@IDU"
            cmd.Parameters.AddWithValue("@IDU", util.IDU)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            cmd.Dispose()
            While dr.Read
                If dr(0) = util.IDU And dr(1) = util.MDP Then
                    n = True
                    Utilisateur(p).Nom = dr(2)
                    Utilisateur(p).IDU = dr(0)
                Else
                    n = False
                End If
                p += 1
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Public Function authentification_admin(ByVal util As T_UTILISATEUR)
        Try
            p = 0
            n = False
            cmd = con.CreateCommand
            cmd.CommandText = "SELECT IDU, MDP, Nom, statut FROM UTILISATEUR WHERE IDU=@IDU"
            cmd.Parameters.AddWithValue("@IDU", util.IDU)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            cmd.Dispose()
            While dr.Read
                If dr(0) = util.IDU And dr(1) = util.MDP And dr(3) = "Administrateur" Then
                    n = True
                    Utilisateur(p).Nom = dr(2)
                    Utilisateur(p).IDU = dr(0)
                Else
                    n = False
                End If
                p += 1
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function

    Public Function genererIdEtudiant()
        Dim a As String
        Dim f As Char
        'Dim n As String = 1

        p = 0
        a = Date.Now.Year
        f = "A"
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IDE FROM ETUDIANT"
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            While dr.Read
                ETUDIANT(p).IDE = dr(0)
                p = p + 1
            End While
            If ETUDIANT(0).IDE = "" Then
                IDE = a + f + ni.ToString("D3")
                ni += 1
            Else
                If ETUDIANT(p - 1).IDE.Split("A")(0) = a Then
                    If max < ETUDIANT(p - 1).IDE.Split("A")(1) Then
                        max = CInt(ETUDIANT(p - 1).IDE.Split("A")(1)) + 1
                        IDE = a + f + (CInt(ETUDIANT(p - 1).IDE.Split("A")(1)) + 1).ToString("D3")
                    Else
                        max = max + 1
                        IDE = a + f + max.ToString("D3")
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

        'Dim count As Integer
        p = 0
        a = Date.Now.Year
        f = "B"

        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT IDP FROM PERSONNEL"
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        PERSONNEL(0).IDP = ""
        While dr.Read
            PERSONNEL(p).IDP = dr(0)
            p = p + 1
        End While
        If PERSONNEL(0).IDP = "" Then

            Io = a + f + ni.ToString("D3")
            ni = ni + 1
        Else
            If PERSONNEL(p - 1).IDP.Split("B")(0) = a Then
                If maxi < PERSONNEL(p - 1).IDP.Split("B")(1) Then
                    maxi = CInt(PERSONNEL(p - 1).IDP.Split("B")(1)) + 1
                    Io = a + f + maxi.ToString("D3")
                Else
                    maxi = maxi + 1
                    Io = a + f + maxi.ToString("D3")
                End If
            End If
        End If
        MsgBox(Io)
        cmd.Dispose()
        Return Io
    End Function
    Public Function genererIdDispositifs()
        Dim a As String
        Dim f As Char
        Dim n As String = 1
        Dim Io As String = ""
        Dim max As Integer = 0
        p = 0
        a = Date.Now.Year
        f = "C"

        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT IDD FROM DISPOSITIFS"
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader()
        While dr.Read
            DISPOSITIFS(p).IDD = dr(0)
            p = p + 1
        End While
        If PERSONNEL(0).IDP = "" Then
            Io = a & f & n
        Else
            If DISPOSITIFS(p - 1).IDD.Split("C")(0) = a Then
                If max < DISPOSITIFS(p - 1).IDD.Split("C")(1) Then
                    max = CInt(DISPOSITIFS(p - 1).IDD.Split("C")(1)) + 1
                    Io = a & f & max
                End If
            End If
        End If
        MsgBox(Io)
        cmd.Dispose()
        Return Io
    End Function
    Public Function ModifHeures_absences(ByVal ETUDIANT As T_ETUDIANT)
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "UPDATE ETUDIANT SET Heures_absence=@Heures_absence WHERE IDE=@IDE"
            cmd.Parameters.AddWithValue("@Heures_absence", ETUDIANT.Heures_absence)
            cmd.Parameters.AddWithValue("@IDE", ETUDIANT.IDE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Public Function ModifHeures_presence(ByVal personne As T_PERSONNEL)
        cmd = con.CreateCommand()
        Try
            n = False
            cmd.CommandText = "UPDATE PERSONNEL SET Heures_Absence = @Heure WHERE IDP=@IDP"
            cmd.Parameters.AddWithValue("@Heure", personne.heures)
            cmd.Parameters.AddWithValue("@IDP", personne.IDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "UPDATE PERSONNEL SET salaire_total = salaire_par_heure * Heures_Absence where IDP=@IDP"
            cmd.Parameters.AddWithValue("@IDP", personne.IDP)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    'FONCTION QUI RECUPERE TOUT LES ETUDIANTS QUI DEVAIT ASSSITER AU COURS LA
    Public Function liste_etudiant_toutefiliere(point As T_POINTAGE)
        f = 0
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "select etudiant.IDE, etudiant.filiere, etudiant.heures_absence from (((pointage INNER JOIN dispositifs on dispositifs.IDD = pointage.IDD)INNER JOIN programmes on programmes.Salle = dispositifs.Salle)INNER JOIN etudiant on etudiant.filiere = programmes.groupe) where @horaire between Tranche_horaire_debut and Tranche_horaire_fin and pointage.IDD = @IDD and @Dates = programmes.Dates group by etudiant.IDE"
            cmd.Parameters.AddWithValue("@horaire", point.Heures)
            cmd.Parameters.AddWithValue("@IDD", point.IDD)
            cmd.Parameters.AddWithValue("@Dates", point.Dates)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            While dr.Read
                ETUDIANT(f).IDE = dr(0)
                ETUDIANT(f).Filiere = dr(1)
                ETUDIANT(f).Heures_absence = dr(2)
                f = f + 1
            End While
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Public Function liste_etudiant_grouptp(point As T_POINTAGE)
        b = 0
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "select etudiant.IDE, etudiant.filiere, etudiant.heures_absence from (((pointage INNER JOIN dispositifs on dispositifs.IDD = pointage.IDD)INNER JOIN programmes on programmes.Salle = dispositifs.Salle)INNER JOIN etudiant on etudiant.groupe_td = programmes.groupe) where @horaire between Tranche_horaire_debut and Tranche_horaire_fin and pointage.IDD = @IDD and @Dates = programmes.Dates group by etudiant.IDE"
            cmd.Parameters.AddWithValue("@horaire", point.Heures)
            cmd.Parameters.AddWithValue("@IDD", point.IDD)
            cmd.Parameters.AddWithValue("@Dates", point.Dates)
            MsgBox(point.Heures)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            While dr.Read
                ETUDIANT(b).IDE = dr(0)
                ETUDIANT(b).Filiere = dr(1)
                ETUDIANT(b).Heures_absence = dr(2)
                b = b + 1
            End While
            cmd.Dispose()
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function

    'FONCTION QUI DEDUIT SI C'EST UN TD OU CM
    Public Function TD_CM(ByVal point As T_POINTAGE)
        p = 0
        Try
            n = False
            cmd = con.CreateCommand()
            cmd.CommandText = "select personnel.IDP, personnel.statut, personnel.heures_absence, programmes.groupe, tranche_horaire_debut, tranche_horaire_fin from (((pointage INNER JOIN dispositifs on dispositifs.IDD = pointage.IDD)INNER JOIN programmes on programmes.Salle = dispositifs.Salle)INNER JOIN personnel on personnel.Nom = programmes.enseignant) where pointage.IDD = @IDD and programmes.Dates = @dates and @heures between Tranche_horaire_debut and Tranche_horaire_fin group by programmes.groupe"
            cmd.Parameters.AddWithValue("@IDD", point.IDD)
            cmd.Parameters.AddWithValue("@Dates", point.Dates)
            cmd.Parameters.AddWithValue("@heures", point.Heures)
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader()
            While dr.Read
                PERSONNEL(p).IDP = dr(0)
                PERSONNEL(p).Statut = dr(1)
                PERSONNEL(p).heures = dr(2)
                PROGRAMMES(p).Groupe = dr(3)
                PROGRAMMES(p).Tranches_horaire_debut = dr(4)
                PROGRAMMES(p).Tranches_horaire_fin = dr(5)
                p = p + 1
            End While
            n = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function

End Class
