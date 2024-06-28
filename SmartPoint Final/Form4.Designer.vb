<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Ccrée = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaElipsePanel2 = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPictureBox1 = New Guna.UI.WinForms.GunaPictureBox()
        Me.CValidé = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaElipsePanel4 = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.namelab = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPictureBox2 = New Guna.UI.WinForms.GunaPictureBox()
        Me.CErreur = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaElipsePanel6 = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPictureBox3 = New Guna.UI.WinForms.GunaPictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CCréeBut = New System.Windows.Forms.Button()
        Me.CvalidéBut = New System.Windows.Forms.Button()
        Me.CMotdePEr = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaElipsePanel3 = New Guna.UI.WinForms.GunaElipsePanel()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPictureBox4 = New Guna.UI.WinForms.GunaPictureBox()
        Me.CErreurBut = New System.Windows.Forms.Button()
        Me.CMotdePErBut = New System.Windows.Forms.Button()
        Me.Ccrée.SuspendLayout()
        Me.GunaElipsePanel2.SuspendLayout()
        CType(Me.GunaPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CValidé.SuspendLayout()
        Me.GunaElipsePanel4.SuspendLayout()
        CType(Me.GunaPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CErreur.SuspendLayout()
        Me.GunaElipsePanel6.SuspendLayout()
        CType(Me.GunaPictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMotdePEr.SuspendLayout()
        Me.GunaElipsePanel3.SuspendLayout()
        CType(Me.GunaPictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ccrée
        '
        Me.Ccrée.BackColor = System.Drawing.Color.Transparent
        Me.Ccrée.BaseColor = System.Drawing.Color.Green
        Me.Ccrée.Controls.Add(Me.GunaElipsePanel2)
        Me.Ccrée.Location = New System.Drawing.Point(41, 46)
        Me.Ccrée.Name = "Ccrée"
        Me.Ccrée.Radius = 20
        Me.Ccrée.Size = New System.Drawing.Size(394, 163)
        Me.Ccrée.TabIndex = 0
        Me.Ccrée.Visible = False
        '
        'GunaElipsePanel2
        '
        Me.GunaElipsePanel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel2.BaseColor = System.Drawing.Color.White
        Me.GunaElipsePanel2.Controls.Add(Me.GunaLabel1)
        Me.GunaElipsePanel2.Controls.Add(Me.GunaPictureBox1)
        Me.GunaElipsePanel2.Location = New System.Drawing.Point(12, 11)
        Me.GunaElipsePanel2.Name = "GunaElipsePanel2"
        Me.GunaElipsePanel2.Radius = 20
        Me.GunaElipsePanel2.Size = New System.Drawing.Size(369, 140)
        Me.GunaElipsePanel2.TabIndex = 1
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(38, 73)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(286, 32)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "Compte crée avec succès"
        '
        'GunaPictureBox1
        '
        Me.GunaPictureBox1.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox1.Image = CType(resources.GetObject("GunaPictureBox1.Image"), System.Drawing.Image)
        Me.GunaPictureBox1.Location = New System.Drawing.Point(114, -14)
        Me.GunaPictureBox1.Name = "GunaPictureBox1"
        Me.GunaPictureBox1.Size = New System.Drawing.Size(114, 107)
        Me.GunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaPictureBox1.TabIndex = 2
        Me.GunaPictureBox1.TabStop = False
        '
        'CValidé
        '
        Me.CValidé.BackColor = System.Drawing.Color.Transparent
        Me.CValidé.BaseColor = System.Drawing.Color.DodgerBlue
        Me.CValidé.Controls.Add(Me.GunaElipsePanel4)
        Me.CValidé.Location = New System.Drawing.Point(4, 5)
        Me.CValidé.Name = "CValidé"
        Me.CValidé.Radius = 20
        Me.CValidé.Size = New System.Drawing.Size(415, 219)
        Me.CValidé.TabIndex = 2
        Me.CValidé.Visible = False
        '
        'GunaElipsePanel4
        '
        Me.GunaElipsePanel4.BackColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel4.BaseColor = System.Drawing.Color.White
        Me.GunaElipsePanel4.Controls.Add(Me.GunaLabel5)
        Me.GunaElipsePanel4.Controls.Add(Me.namelab)
        Me.GunaElipsePanel4.Controls.Add(Me.GunaLabel2)
        Me.GunaElipsePanel4.Controls.Add(Me.GunaPictureBox2)
        Me.GunaElipsePanel4.Location = New System.Drawing.Point(8, 8)
        Me.GunaElipsePanel4.Name = "GunaElipsePanel4"
        Me.GunaElipsePanel4.Radius = 20
        Me.GunaElipsePanel4.Size = New System.Drawing.Size(397, 202)
        Me.GunaElipsePanel4.TabIndex = 1
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(79, 146)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(248, 25)
        Me.GunaLabel5.TabIndex = 4
        Me.GunaLabel5.Text = "Bienvenu dans Smart Point!"
        '
        'namelab
        '
        Me.namelab.AutoSize = True
        Me.namelab.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.namelab.ForeColor = System.Drawing.Color.DodgerBlue
        Me.namelab.Location = New System.Drawing.Point(161, 102)
        Me.namelab.Name = "namelab"
        Me.namelab.Size = New System.Drawing.Size(0, 32)
        Me.namelab.TabIndex = 3
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(72, 67)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(257, 21)
        Me.GunaLabel2.TabIndex = 0
        Me.GunaLabel2.Text = "Connexion effectuée avec succès!"
        '
        'GunaPictureBox2
        '
        Me.GunaPictureBox2.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox2.Image = CType(resources.GetObject("GunaPictureBox2.Image"), System.Drawing.Image)
        Me.GunaPictureBox2.Location = New System.Drawing.Point(166, 4)
        Me.GunaPictureBox2.Name = "GunaPictureBox2"
        Me.GunaPictureBox2.Size = New System.Drawing.Size(56, 50)
        Me.GunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GunaPictureBox2.TabIndex = 2
        Me.GunaPictureBox2.TabStop = False
        '
        'CErreur
        '
        Me.CErreur.BackColor = System.Drawing.Color.Transparent
        Me.CErreur.BaseColor = System.Drawing.Color.Orange
        Me.CErreur.Controls.Add(Me.GunaElipsePanel6)
        Me.CErreur.Location = New System.Drawing.Point(2, 16)
        Me.CErreur.Name = "CErreur"
        Me.CErreur.Radius = 20
        Me.CErreur.Size = New System.Drawing.Size(480, 221)
        Me.CErreur.TabIndex = 2
        Me.CErreur.Visible = False
        '
        'GunaElipsePanel6
        '
        Me.GunaElipsePanel6.BackColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel6.BaseColor = System.Drawing.Color.White
        Me.GunaElipsePanel6.Controls.Add(Me.GunaButton2)
        Me.GunaElipsePanel6.Controls.Add(Me.GunaLabel3)
        Me.GunaElipsePanel6.Controls.Add(Me.GunaPictureBox3)
        Me.GunaElipsePanel6.Location = New System.Drawing.Point(12, 12)
        Me.GunaElipsePanel6.Name = "GunaElipsePanel6"
        Me.GunaElipsePanel6.Radius = 20
        Me.GunaElipsePanel6.Size = New System.Drawing.Size(454, 196)
        Me.GunaElipsePanel6.TabIndex = 1
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.Orange
        Me.GunaButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaButton2.BorderSize = 2
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.Black
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(201, 142)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.Green
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 20
        Me.GunaButton2.Size = New System.Drawing.Size(66, 42)
        Me.GunaButton2.TabIndex = 1
        Me.GunaButton2.Text = "OK"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(16, 96)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(417, 25)
        Me.GunaLabel3.TabIndex = 0
        Me.GunaLabel3.Text = "Une erreur est survenue.Veuillez recommencer!"
        '
        'GunaPictureBox3
        '
        Me.GunaPictureBox3.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox3.Image = CType(resources.GetObject("GunaPictureBox3.Image"), System.Drawing.Image)
        Me.GunaPictureBox3.Location = New System.Drawing.Point(201, 8)
        Me.GunaPictureBox3.Name = "GunaPictureBox3"
        Me.GunaPictureBox3.Size = New System.Drawing.Size(79, 75)
        Me.GunaPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GunaPictureBox3.TabIndex = 2
        Me.GunaPictureBox3.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'CCréeBut
        '
        Me.CCréeBut.Location = New System.Drawing.Point(0, 0)
        Me.CCréeBut.Name = "CCréeBut"
        Me.CCréeBut.Size = New System.Drawing.Size(75, 23)
        Me.CCréeBut.TabIndex = 3
        Me.CCréeBut.Text = "Ccrée"
        Me.CCréeBut.UseVisualStyleBackColor = True
        Me.CCréeBut.Visible = False
        '
        'CvalidéBut
        '
        Me.CvalidéBut.Location = New System.Drawing.Point(95, 0)
        Me.CvalidéBut.Name = "CvalidéBut"
        Me.CvalidéBut.Size = New System.Drawing.Size(75, 23)
        Me.CvalidéBut.TabIndex = 4
        Me.CvalidéBut.Text = "Cvalidé"
        Me.CvalidéBut.UseVisualStyleBackColor = True
        Me.CvalidéBut.Visible = False
        '
        'CMotdePEr
        '
        Me.CMotdePEr.BackColor = System.Drawing.Color.Transparent
        Me.CMotdePEr.BaseColor = System.Drawing.Color.Red
        Me.CMotdePEr.Controls.Add(Me.GunaElipsePanel3)
        Me.CMotdePEr.Location = New System.Drawing.Point(11, 37)
        Me.CMotdePEr.Name = "CMotdePEr"
        Me.CMotdePEr.Radius = 20
        Me.CMotdePEr.Size = New System.Drawing.Size(452, 186)
        Me.CMotdePEr.TabIndex = 3
        Me.CMotdePEr.Visible = False
        '
        'GunaElipsePanel3
        '
        Me.GunaElipsePanel3.BackColor = System.Drawing.Color.Transparent
        Me.GunaElipsePanel3.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaElipsePanel3.Controls.Add(Me.GunaButton1)
        Me.GunaElipsePanel3.Controls.Add(Me.GunaLabel4)
        Me.GunaElipsePanel3.Controls.Add(Me.GunaPictureBox4)
        Me.GunaElipsePanel3.Location = New System.Drawing.Point(10, 10)
        Me.GunaElipsePanel3.Name = "GunaElipsePanel3"
        Me.GunaElipsePanel3.Radius = 20
        Me.GunaElipsePanel3.Size = New System.Drawing.Size(430, 167)
        Me.GunaElipsePanel3.TabIndex = 1
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.Red
        Me.GunaButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaButton1.BorderSize = 2
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.Black
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(179, 111)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.DarkRed
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 20
        Me.GunaButton1.Size = New System.Drawing.Size(66, 42)
        Me.GunaButton1.TabIndex = 1
        Me.GunaButton1.Text = "OK"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(6, 76)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(416, 23)
        Me.GunaLabel4.TabIndex = 0
        Me.GunaLabel4.Text = "L'identifiant et le mot de passe ne correspondent pas"
        '
        'GunaPictureBox4
        '
        Me.GunaPictureBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GunaPictureBox4.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox4.Image = CType(resources.GetObject("GunaPictureBox4.Image"), System.Drawing.Image)
        Me.GunaPictureBox4.Location = New System.Drawing.Point(172, 3)
        Me.GunaPictureBox4.Name = "GunaPictureBox4"
        Me.GunaPictureBox4.Size = New System.Drawing.Size(87, 57)
        Me.GunaPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GunaPictureBox4.TabIndex = 2
        Me.GunaPictureBox4.TabStop = False
        '
        'CErreurBut
        '
        Me.CErreurBut.Location = New System.Drawing.Point(596, 34)
        Me.CErreurBut.Name = "CErreurBut"
        Me.CErreurBut.Size = New System.Drawing.Size(75, 23)
        Me.CErreurBut.TabIndex = 5
        Me.CErreurBut.Text = "CErreur"
        Me.CErreurBut.UseVisualStyleBackColor = True
        Me.CErreurBut.Visible = False
        '
        'CMotdePErBut
        '
        Me.CMotdePErBut.Location = New System.Drawing.Point(569, 5)
        Me.CMotdePErBut.Name = "CMotdePErBut"
        Me.CMotdePErBut.Size = New System.Drawing.Size(75, 23)
        Me.CMotdePErBut.TabIndex = 6
        Me.CMotdePErBut.Text = "CMotdePEr"
        Me.CMotdePErBut.UseVisualStyleBackColor = True
        Me.CMotdePErBut.Visible = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(489, 262)
        Me.Controls.Add(Me.CMotdePErBut)
        Me.Controls.Add(Me.CErreurBut)
        Me.Controls.Add(Me.CvalidéBut)
        Me.Controls.Add(Me.CCréeBut)
        Me.Controls.Add(Me.CErreur)
        Me.Controls.Add(Me.CMotdePEr)
        Me.Controls.Add(Me.CValidé)
        Me.Controls.Add(Me.Ccrée)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        Me.TransparencyKey = System.Drawing.Color.Maroon
        Me.Ccrée.ResumeLayout(False)
        Me.GunaElipsePanel2.ResumeLayout(False)
        Me.GunaElipsePanel2.PerformLayout()
        CType(Me.GunaPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CValidé.ResumeLayout(False)
        Me.GunaElipsePanel4.ResumeLayout(False)
        Me.GunaElipsePanel4.PerformLayout()
        CType(Me.GunaPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CErreur.ResumeLayout(False)
        Me.GunaElipsePanel6.ResumeLayout(False)
        Me.GunaElipsePanel6.PerformLayout()
        CType(Me.GunaPictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMotdePEr.ResumeLayout(False)
        Me.GunaElipsePanel3.ResumeLayout(False)
        Me.GunaElipsePanel3.PerformLayout()
        CType(Me.GunaPictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ccrée As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents CValidé As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaElipsePanel4 As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPictureBox2 As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents GunaElipsePanel2 As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPictureBox1 As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents CErreur As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaElipsePanel6 As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPictureBox3 As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CCréeBut As Button
    Friend WithEvents CvalidéBut As Button
    Friend WithEvents CMotdePEr As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaElipsePanel3 As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPictureBox4 As Guna.UI.WinForms.GunaPictureBox
    Friend WithEvents CErreurBut As Button
    Friend WithEvents CMotdePErBut As Button
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents namelab As Guna.UI.WinForms.GunaLabel
End Class
