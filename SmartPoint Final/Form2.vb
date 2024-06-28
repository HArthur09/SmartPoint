Public Class Form2
    Public time As Byte = 0
    Dim ps As New Class4
    Dim pn As New Class4.T_UTILISATEUR
    Dim p As Integer = 0
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaProgressBar1.Value = time
        time = time + 1
        If time = 7 Then
            Try
                ps.ouverture_connection()
                If IsNothing(ps.con) Then
                    ps.creation_base_de_données()
                    ps.fermeture_connection()
                    ps.ouverture_connection()
                    'ps.creation_base_de_données()
                    ps.Creation_table_Utilisateur()
                    ps.Creation_table_etudiant()
                    ps.Creation_table_programme()
                    ps.Creation_table_personnel()
                    ps.Creation_table_dispositifs()
                    ps.Creation_table_pointage()
                    ps.fermeture_connection()
                Else
                    ps.fermeture_connection()
                End If
            Catch ex As Exception

            End Try


            'MsgBox(t.UTILISATEUR(p).Nom)
            ps.ouverture_connection()
            If ps.Verification_base_vide() = True Then
                Me.Hide()
                Form1.Show()
                Form1.Panelfalse.Visible = False
                Form1.PanelTrue.Visible = True
                Timer1.Stop()

            Else
                Me.Hide()
                Form1.Show()
                Form1.PanelTrue.Visible = False
                Form1.Panelfalse.Visible = True
                Timer1.Stop()
            End If
            ps.fermeture_connection()
        End If

    End Sub
End Class