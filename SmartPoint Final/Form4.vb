Public Class Form4
    Dim sec As Integer = 3
    Private Sub GunaElipsePanel4_Paint(sender As Object, e As PaintEventArgs) Handles GunaElipsePanel4.Paint

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sec -= 1
        If sec = 0 Then
            Form1.Dispose()
            Me.Dispose()
            Form3.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CCréeBut.Click
        Timer1.Enabled = True
        Ccrée.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CvalidéBut.Click
        Timer1.Enabled = True
        CValidé.Visible = True
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Me.Dispose()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Dispose()
    End Sub

    Private Sub CErreurBut_Click(sender As Object, e As EventArgs) Handles CErreurBut.Click
        CErreur.Visible = True
    End Sub

    Private Sub CMotdePErBut_Click(sender As Object, e As EventArgs) Handles CMotdePErBut.Click
        CMotdePEr.Visible = True
    End Sub

    Private Sub GunaPictureBox1_Click(sender As Object, e As EventArgs) Handles GunaPictureBox1.Click

    End Sub

    Private Sub GunaLabel2_Click(sender As Object, e As EventArgs) Handles GunaLabel2.Click

    End Sub
End Class