Public Class test
    Dim t As New Class1
    'Dim p As Integer = t.p
    'Dim UTILISATEUR(4) As T_UTILISATEUR

    Public Structure T_UTILISATEUR
        Dim Nom As String
        Dim Prenoms As String
        Dim Statut As String
        Dim IDU As String
        Dim MDP As String
        Public Sub New(ByVal mdp As String)
            Nom = ""
            Prenoms = ""
            Statut = ""
            IDU = ""
            mdp = ""
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        t.ouvertureBDD()
        t.SelectionPersonnel()
        t.fermetureBDD()
        For i = 0 To t.p - 1
            MsgBox(t.PERSONNEL(i).Nom)
        Next
    End Sub
End Class