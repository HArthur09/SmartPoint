<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaProgressBar1 = New Guna.UI.WinForms.GunaProgressBar()
        Me.GunaPictureBox1 = New Guna.UI.WinForms.GunaPictureBox()
        CType(Me.GunaPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.BackColor = System.Drawing.Color.White
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GunaLabel1.Location = New System.Drawing.Point(51, 404)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(79, 13)
        Me.GunaLabel1.TabIndex = 4
        Me.GunaLabel1.Text = "Chargement..."
        '
        'GunaProgressBar1
        '
        Me.GunaProgressBar1.BackgroundImage = CType(resources.GetObject("GunaProgressBar1.BackgroundImage"), System.Drawing.Image)
        Me.GunaProgressBar1.BorderColor = System.Drawing.Color.Black
        Me.GunaProgressBar1.ColorStyle = Guna.UI.WinForms.ColorStyle.[Default]
        Me.GunaProgressBar1.IdleColor = System.Drawing.Color.Gainsboro
        Me.GunaProgressBar1.Location = New System.Drawing.Point(20, 428)
        Me.GunaProgressBar1.Maximum = 7
        Me.GunaProgressBar1.Name = "GunaProgressBar1"
        Me.GunaProgressBar1.ProgressMaxColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBar1.ProgressMinColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaProgressBar1.Size = New System.Drawing.Size(134, 10)
        Me.GunaProgressBar1.TabIndex = 2
        Me.GunaProgressBar1.UseWaitCursor = True
        '
        'GunaPictureBox1
        '
        Me.GunaPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaPictureBox1.BaseColor = System.Drawing.Color.White
        Me.GunaPictureBox1.Image = CType(resources.GetObject("GunaPictureBox1.Image"), System.Drawing.Image)
        Me.GunaPictureBox1.Location = New System.Drawing.Point(1, -4)
        Me.GunaPictureBox1.Name = "GunaPictureBox1"
        Me.GunaPictureBox1.Size = New System.Drawing.Size(763, 504)
        Me.GunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.GunaPictureBox1.TabIndex = 3
        Me.GunaPictureBox1.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(760, 496)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.GunaProgressBar1)
        Me.Controls.Add(Me.GunaPictureBox1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "c"
        Me.TransparencyKey = System.Drawing.Color.Black
        CType(Me.GunaPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaProgressBar1 As Guna.UI.WinForms.GunaProgressBar
    Friend WithEvents GunaPictureBox1 As Guna.UI.WinForms.GunaPictureBox
End Class
