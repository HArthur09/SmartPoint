Public Class Form1
    Public ps As New Class4
    Dim pn As New Class4.T_UTILISATEUR



    Private Function GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        'Validation du formulaire
        Dim valider As Boolean = False
        'Validation pour le nom
        If GunaLineTextBox4.Text = "" Then
            GunaLineTextBox4.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox4, "Veuillez entrer votre nom")
            valider = False
        ElseIf GunaLineTextBox4.Text.Length <= 2 Then
            GunaLineTextBox4.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox4, "Votre nom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox4.LineColor = Color.LightSkyBlue
            ErrorProvider1.Dispose()
            valider = True
        End If

        'Validation pour le prenom
        If GunaLineTextBox5.Text = "" Then
            GunaLineTextBox5.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox5, "Veuillez entrer votre prénom ")
            valider = False
        ElseIf GunaLineTextBox5.Text.Length <= 2 Then
            GunaLineTextBox5.LineColor = Color.Red
            ErrorProvider5.SetError(GunaLineTextBox5, "Votre prénom doit comporter plus de 2 caractères")
            valider = False
        Else
            GunaLineTextBox5.LineColor = Color.LightSkyBlue
            ErrorProvider5.Dispose()
            valider = True
        End If

        'Validation pour l'identifiant
        If GunaLineTextBox11.Text.Length < 3 Or GunaLineTextBox11.Text.Length > 10 Then
            GunaLineTextBox11.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox11, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox11.Text = "" Then
            GunaLineTextBox11.LineColor = Color.LightSkyBlue
            ErrorProvider2.Dispose()
            valider = False
        Else
            GunaLineTextBox11.LineColor = Color.LightSkyBlue
            ErrorProvider2.Dispose()
            valider = True
        End If

        'Validation pour le mot de passe
        If GunaLineTextBox7.Text = "" Then
            GunaLineTextBox7.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox7, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox7.Text.Length < 6 Then
            GunaLineTextBox7.LineColor = Color.Red
            ErrorProvider3.SetError(GunaLineTextBox7, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox7.LineColor = Color.LightSkyBlue
            ErrorProvider3.Dispose()
            valider = True
        End If

        'Validation pour la confirmation
        If GunaLineTextBox3.Text = "" Then
            GunaLineTextBox3.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox3, "Veuillez confirmer votre mot de passe")
            valider = False

        ElseIf GunaLineTextBox3.Text <> GunaLineTextBox7.Text Then
            GunaLineTextBox3.LineColor = Color.Red
            ErrorProvider4.SetError(GunaLineTextBox3, "Les mots de passe ne correspondent pas")
            valider = False

        Else
            GunaLineTextBox3.LineColor = Color.LightSkyBlue
            ErrorProvider4.Dispose()
            valider = True
        End If

        If valider = True Then
            pn.Nom = GunaLineTextBox4.Text
            pn.Prenoms = GunaLineTextBox5.Text
            pn.IDU = GunaLineTextBox11.Text
            ps.ouverture_connection()
            If ps.Verification_base_vide() = True Then
                pn.Statut = "Administrateur"
            End If
            ps.fermeture_connection()
            pn.MDP = GunaLineTextBox7.Text
            ps.ouverture_connection()
            ps.AjoutUtilisateur(UTILISATEUR:=pn)
            ps.fermeture_connection()
        End If

        If ps.n = True Then
            Form4.Show()
            Form4.Ccrée.Visible = True
            Form4.Timer1.Enabled = True
            Me.Dispose()
        End If

        Return valider

    End Function

    Private Sub GunaLineTextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GunaLineTextBox4.KeyPress, GunaLineTextBox5.KeyPress
        Dim caractere() As Char = {"²", "&", "_", ";", ":", "(", "-", ")", "=", "$", "*", "!", "+", "°", "£", "µ", "%", "§", "/", "?"}
        If caractere.Contains(e.KeyChar) Then
            e.Handled = True
            ErrorProvider1.SetError(GunaLineTextBox4, "Vous ne pouvez pas entrer de caracteres speciaux")
            ErrorProvider2.SetError(GunaLineTextBox5, "Vous ne pouvez pas entrer de caracteres speciaux")
        Else
            ErrorProvider1.Dispose()
        End If
    End Sub
    Private Sub GunaLineTextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GunaLineTextBox11.KeyPress
        Dim caractere() As Char = {"!", "?", "<", ">", ";", ":"}
        If caractere.Contains(e.KeyChar) Then
            e.Handled = True
            ErrorProvider1.SetError(GunaLineTextBox11, "Certains caracteres speciaux sont interdit")
        Else
            ErrorProvider1.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If GunaLineTextBox7.UseSystemPasswordChar = True Then
            GunaLineTextBox7.UseSystemPasswordChar = False
            GunaLineTextBox7.PasswordChar = ""
            Button1.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox7.UseSystemPasswordChar = False Then
            GunaLineTextBox7.UseSystemPasswordChar = True
            GunaLineTextBox7.PasswordChar = "●"
            Button1.BackgroundImage = My.Resources.yeux

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If GunaLineTextBox3.UseSystemPasswordChar = True Then
            GunaLineTextBox3.UseSystemPasswordChar = False
            GunaLineTextBox3.PasswordChar = ""
            Button2.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox3.UseSystemPasswordChar = False Then
            GunaLineTextBox3.UseSystemPasswordChar = True
            GunaLineTextBox3.PasswordChar = "●"
            Button2.BackgroundImage = My.Resources.yeux
        End If
    End Sub


    Private Sub GunaButton20_Click(sender As Object, e As EventArgs) Handles GunaButton20.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub GunaButton21_Click(sender As Object, e As EventArgs) Handles GunaButton21.Click
        Me.WindowState = FormWindowState.Minimized


    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim valider As Boolean = False
        'Validation pour l'identifiant
        If GunaLineTextBox1.Text.Length < 3 Or GunaLineTextBox11.Text.Length > 10 Then
            GunaLineTextBox1.LineColor = Color.Red
            ErrorProvider1.SetError(GunaLineTextBox1, "Votre identifiant doit comprendre entre 3 et 10 caractères")
            valider = False
        ElseIf GunaLineTextBox1.Text = "" Then
            GunaLineTextBox1.LineColor = Color.LightSkyBlue
            ErrorProvider1.Dispose()
            valider = False
        Else
            GunaLineTextBox1.LineColor = Color.LightSkyBlue
            ErrorProvider1.Dispose()
            valider = True
        End If
        'Validation pour le mot de passe
        If GunaLineTextBox2.Text = "" Then
            GunaLineTextBox2.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox2, "Vous devez entrer un mot de passe")
            valider = False
        ElseIf GunaLineTextBox2.Text.Length < 6 Then
            GunaLineTextBox2.LineColor = Color.Red
            ErrorProvider2.SetError(GunaLineTextBox2, "Votre mot de passe doit comporter plus de 6 caractères")
            valider = False
        Else
            GunaLineTextBox2.LineColor = Color.LightSkyBlue
            ErrorProvider2.Dispose()
            valider = True
        End If

        ps.ouverture_connection()
        'ps.SelectionUtilisateur()
        pn.IDU = GunaLineTextBox1.Text
        pn.MDP = GunaLineTextBox2.Text
        ps.authentification(util:=pn)

        ps.fermeture_connection()
        If ps.n = True Then
            Form4.Show()
            Form4.CValidé.Visible = True
            Form4.Timer1.Enabled = True
            'Form3.Show()
        Else
            Form4.Show()
            Form4.CMotdePEr.Visible = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If GunaLineTextBox2.UseSystemPasswordChar = True Then
            GunaLineTextBox2.UseSystemPasswordChar = False
            GunaLineTextBox2.PasswordChar = ""
            Button3.BackgroundImage = My.Resources.oeil_caché

        ElseIf GunaLineTextBox2.UseSystemPasswordChar = False Then
            GunaLineTextBox2.UseSystemPasswordChar = True
            GunaLineTextBox2.PasswordChar = "●"
            Button3.BackgroundImage = My.Resources.yeux
        End If
    End Sub

    Private Sub GunaLineTextBox4_TextChanged(sender As Object, e As EventArgs) Handles GunaLineTextBox4.TextChanged

    End Sub
End Class
