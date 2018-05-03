<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Tb_Url = New System.Windows.Forms.TextBox()
        Me.Lbl_Url = New System.Windows.Forms.Label()
        Me.Lbl_Tiers = New System.Windows.Forms.Label()
        Me.Rb_10sec = New System.Windows.Forms.RadioButton()
        Me.Rb_30sec = New System.Windows.Forms.RadioButton()
        Me.Rb_1min = New System.Windows.Forms.RadioButton()
        Me.Rb_2min = New System.Windows.Forms.RadioButton()
        Me.Rb_5min = New System.Windows.Forms.RadioButton()
        Me.Rb_10min = New System.Windows.Forms.RadioButton()
        Me.Rb_15sec = New System.Windows.Forms.RadioButton()
        Me.GB_RB_Timer = New System.Windows.Forms.GroupBox()
        Me.Rb_15min = New System.Windows.Forms.RadioButton()
        Me.Lbl_Volume = New System.Windows.Forms.Label()
        Me.CMB_Volume = New System.Windows.Forms.ComboBox()
        Me.Lbl_Dl_Counter = New System.Windows.Forms.Label()
        Me.Lbl_Dl_Traffic_Number = New System.Windows.Forms.Label()
        Me.Lbl_Dl_Traffic = New System.Windows.Forms.Label()
        Me.Lbl_Dl_Counter_Number = New System.Windows.Forms.Label()
        Me.Timer_Downloader = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl_Lang_DE = New System.Windows.Forms.Label()
        Me.Lbl_Lang_EN = New System.Windows.Forms.Label()
        Me.Lbl_Version = New System.Windows.Forms.LinkLabel()
        Me.Tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GB_RB_Timer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tb_Url
        '
        Me.Tb_Url.BackColor = System.Drawing.Color.White
        Me.Tb_Url.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Url.ForeColor = System.Drawing.Color.Black
        Me.Tb_Url.Location = New System.Drawing.Point(217, 20)
        Me.Tb_Url.Margin = New System.Windows.Forms.Padding(4)
        Me.Tb_Url.Name = "Tb_Url"
        Me.Tb_Url.Size = New System.Drawing.Size(354, 26)
        Me.Tb_Url.TabIndex = 0
        '
        'Lbl_Url
        '
        Me.Lbl_Url.AutoSize = True
        Me.Lbl_Url.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Url.Location = New System.Drawing.Point(15, 23)
        Me.Lbl_Url.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Url.Name = "Lbl_Url"
        Me.Lbl_Url.Size = New System.Drawing.Size(194, 18)
        Me.Lbl_Url.TabIndex = 13
        Me.Lbl_Url.Text = "Please enter the URL here:"
        '
        'Lbl_Tiers
        '
        Me.Lbl_Tiers.AutoSize = True
        Me.Lbl_Tiers.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tiers.Location = New System.Drawing.Point(15, 126)
        Me.Lbl_Tiers.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Tiers.Name = "Lbl_Tiers"
        Me.Lbl_Tiers.Size = New System.Drawing.Size(347, 18)
        Me.Lbl_Tiers.TabIndex = 14
        Me.Lbl_Tiers.Text = "Please choose the tiers you want to watch out for:"
        '
        'Rb_10sec
        '
        Me.Rb_10sec.AutoSize = True
        Me.Rb_10sec.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_10sec.Location = New System.Drawing.Point(15, 30)
        Me.Rb_10sec.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_10sec.Name = "Rb_10sec"
        Me.Rb_10sec.Size = New System.Drawing.Size(78, 23)
        Me.Rb_10sec.TabIndex = 4
        Me.Rb_10sec.TabStop = True
        Me.Rb_10sec.Text = "10 sec."
        Me.Rb_10sec.UseVisualStyleBackColor = True
        '
        'Rb_30sec
        '
        Me.Rb_30sec.AutoSize = True
        Me.Rb_30sec.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_30sec.Location = New System.Drawing.Point(249, 30)
        Me.Rb_30sec.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_30sec.Name = "Rb_30sec"
        Me.Rb_30sec.Size = New System.Drawing.Size(78, 23)
        Me.Rb_30sec.TabIndex = 6
        Me.Rb_30sec.TabStop = True
        Me.Rb_30sec.Text = "30 sec."
        Me.Rb_30sec.UseVisualStyleBackColor = True
        '
        'Rb_1min
        '
        Me.Rb_1min.AutoSize = True
        Me.Rb_1min.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_1min.Location = New System.Drawing.Point(366, 30)
        Me.Rb_1min.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_1min.Name = "Rb_1min"
        Me.Rb_1min.Size = New System.Drawing.Size(71, 23)
        Me.Rb_1min.TabIndex = 7
        Me.Rb_1min.TabStop = True
        Me.Rb_1min.Text = "1 min."
        Me.Rb_1min.UseVisualStyleBackColor = True
        '
        'Rb_2min
        '
        Me.Rb_2min.AutoSize = True
        Me.Rb_2min.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_2min.Location = New System.Drawing.Point(15, 65)
        Me.Rb_2min.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_2min.Name = "Rb_2min"
        Me.Rb_2min.Size = New System.Drawing.Size(71, 23)
        Me.Rb_2min.TabIndex = 8
        Me.Rb_2min.TabStop = True
        Me.Rb_2min.Text = "2 min."
        Me.Rb_2min.UseVisualStyleBackColor = True
        '
        'Rb_5min
        '
        Me.Rb_5min.AutoSize = True
        Me.Rb_5min.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_5min.Location = New System.Drawing.Point(132, 65)
        Me.Rb_5min.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_5min.Name = "Rb_5min"
        Me.Rb_5min.Size = New System.Drawing.Size(71, 23)
        Me.Rb_5min.TabIndex = 9
        Me.Rb_5min.TabStop = True
        Me.Rb_5min.Text = "5 min."
        Me.Rb_5min.UseVisualStyleBackColor = True
        '
        'Rb_10min
        '
        Me.Rb_10min.AutoSize = True
        Me.Rb_10min.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_10min.Location = New System.Drawing.Point(249, 65)
        Me.Rb_10min.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_10min.Name = "Rb_10min"
        Me.Rb_10min.Size = New System.Drawing.Size(80, 23)
        Me.Rb_10min.TabIndex = 10
        Me.Rb_10min.TabStop = True
        Me.Rb_10min.Text = "10 min."
        Me.Rb_10min.UseVisualStyleBackColor = True
        '
        'Rb_15sec
        '
        Me.Rb_15sec.AutoSize = True
        Me.Rb_15sec.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_15sec.Location = New System.Drawing.Point(132, 30)
        Me.Rb_15sec.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_15sec.Name = "Rb_15sec"
        Me.Rb_15sec.Size = New System.Drawing.Size(78, 23)
        Me.Rb_15sec.TabIndex = 5
        Me.Rb_15sec.TabStop = True
        Me.Rb_15sec.Text = "15 sec."
        Me.Rb_15sec.UseVisualStyleBackColor = True
        '
        'GB_RB_Timer
        '
        Me.GB_RB_Timer.Controls.Add(Me.Rb_15min)
        Me.GB_RB_Timer.Controls.Add(Me.Lbl_Volume)
        Me.GB_RB_Timer.Controls.Add(Me.CMB_Volume)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_15sec)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_5min)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_10min)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_2min)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_1min)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_30sec)
        Me.GB_RB_Timer.Controls.Add(Me.Rb_10sec)
        Me.GB_RB_Timer.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_RB_Timer.ForeColor = System.Drawing.Color.Black
        Me.GB_RB_Timer.Location = New System.Drawing.Point(15, 388)
        Me.GB_RB_Timer.Margin = New System.Windows.Forms.Padding(4)
        Me.GB_RB_Timer.Name = "GB_RB_Timer"
        Me.GB_RB_Timer.Padding = New System.Windows.Forms.Padding(4)
        Me.GB_RB_Timer.Size = New System.Drawing.Size(556, 100)
        Me.GB_RB_Timer.TabIndex = 15
        Me.GB_RB_Timer.TabStop = False
        Me.GB_RB_Timer.Text = "Check every ..."
        '
        'Rb_15min
        '
        Me.Rb_15min.AutoSize = True
        Me.Rb_15min.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_15min.Location = New System.Drawing.Point(366, 65)
        Me.Rb_15min.Margin = New System.Windows.Forms.Padding(4)
        Me.Rb_15min.Name = "Rb_15min"
        Me.Rb_15min.Size = New System.Drawing.Size(80, 23)
        Me.Rb_15min.TabIndex = 13
        Me.Rb_15min.TabStop = True
        Me.Rb_15min.Text = "15 min."
        Me.Rb_15min.UseVisualStyleBackColor = True
        '
        'Lbl_Volume
        '
        Me.Lbl_Volume.AutoSize = True
        Me.Lbl_Volume.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Volume.Location = New System.Drawing.Point(467, 23)
        Me.Lbl_Volume.Name = "Lbl_Volume"
        Me.Lbl_Volume.Size = New System.Drawing.Size(64, 36)
        Me.Lbl_Volume.TabIndex = 12
        Me.Lbl_Volume.Text = "Alarm-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Volume:"
        Me.Lbl_Volume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMB_Volume
        '
        Me.CMB_Volume.BackColor = System.Drawing.Color.White
        Me.CMB_Volume.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_Volume.FormattingEnabled = True
        Me.CMB_Volume.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"})
        Me.CMB_Volume.Location = New System.Drawing.Point(470, 65)
        Me.CMB_Volume.Name = "CMB_Volume"
        Me.CMB_Volume.Size = New System.Drawing.Size(80, 26)
        Me.CMB_Volume.TabIndex = 11
        '
        'Lbl_Dl_Counter
        '
        Me.Lbl_Dl_Counter.AutoSize = True
        Me.Lbl_Dl_Counter.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Dl_Counter.Location = New System.Drawing.Point(11, 580)
        Me.Lbl_Dl_Counter.Name = "Lbl_Dl_Counter"
        Me.Lbl_Dl_Counter.Size = New System.Drawing.Size(196, 20)
        Me.Lbl_Dl_Counter.TabIndex = 16
        Me.Lbl_Dl_Counter.Text = "Number of times downloaded:"
        '
        'Lbl_Dl_Traffic_Number
        '
        Me.Lbl_Dl_Traffic_Number.AutoSize = True
        Me.Lbl_Dl_Traffic_Number.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Dl_Traffic_Number.Location = New System.Drawing.Point(214, 615)
        Me.Lbl_Dl_Traffic_Number.Name = "Lbl_Dl_Traffic_Number"
        Me.Lbl_Dl_Traffic_Number.Size = New System.Drawing.Size(16, 20)
        Me.Lbl_Dl_Traffic_Number.TabIndex = 19
        Me.Lbl_Dl_Traffic_Number.Text = "0"
        '
        'Lbl_Dl_Traffic
        '
        Me.Lbl_Dl_Traffic.AutoSize = True
        Me.Lbl_Dl_Traffic.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Dl_Traffic.Location = New System.Drawing.Point(11, 615)
        Me.Lbl_Dl_Traffic.Name = "Lbl_Dl_Traffic"
        Me.Lbl_Dl_Traffic.Size = New System.Drawing.Size(196, 20)
        Me.Lbl_Dl_Traffic.TabIndex = 18
        Me.Lbl_Dl_Traffic.Text = "Approximate download traffic:"
        '
        'Lbl_Dl_Counter_Number
        '
        Me.Lbl_Dl_Counter_Number.AutoSize = True
        Me.Lbl_Dl_Counter_Number.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Dl_Counter_Number.Location = New System.Drawing.Point(214, 580)
        Me.Lbl_Dl_Counter_Number.Name = "Lbl_Dl_Counter_Number"
        Me.Lbl_Dl_Counter_Number.Size = New System.Drawing.Size(16, 20)
        Me.Lbl_Dl_Counter_Number.TabIndex = 17
        Me.Lbl_Dl_Counter_Number.Text = "0"
        '
        'Timer_Downloader
        '
        '
        'Lbl_Lang_DE
        '
        Me.Lbl_Lang_DE.AutoSize = True
        Me.Lbl_Lang_DE.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Lang_DE.Location = New System.Drawing.Point(405, 580)
        Me.Lbl_Lang_DE.Name = "Lbl_Lang_DE"
        Me.Lbl_Lang_DE.Size = New System.Drawing.Size(59, 20)
        Me.Lbl_Lang_DE.TabIndex = 21
        Me.Lbl_Lang_DE.Text = "Deutsch"
        '
        'Lbl_Lang_EN
        '
        Me.Lbl_Lang_EN.AutoSize = True
        Me.Lbl_Lang_EN.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Lang_EN.Location = New System.Drawing.Point(515, 580)
        Me.Lbl_Lang_EN.Name = "Lbl_Lang_EN"
        Me.Lbl_Lang_EN.Size = New System.Drawing.Size(57, 20)
        Me.Lbl_Lang_EN.TabIndex = 22
        Me.Lbl_Lang_EN.Text = "English"
        '
        'Lbl_Version
        '
        Me.Lbl_Version.AutoSize = True
        Me.Lbl_Version.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Version.Location = New System.Drawing.Point(427, 618)
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Size = New System.Drawing.Size(145, 16)
        Me.Lbl_Version.TabIndex = 23
        Me.Lbl_Version.TabStop = True
        Me.Lbl_Version.Text = "Version: 1.0 | Datum: 09 / 16"
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 641)
        Me.Controls.Add(Me.Lbl_Version)
        Me.Controls.Add(Me.Lbl_Lang_EN)
        Me.Controls.Add(Me.Lbl_Lang_DE)
        Me.Controls.Add(Me.Lbl_Dl_Counter_Number)
        Me.Controls.Add(Me.Lbl_Dl_Traffic)
        Me.Controls.Add(Me.Lbl_Dl_Traffic_Number)
        Me.Controls.Add(Me.Lbl_Dl_Counter)
        Me.Controls.Add(Me.GB_RB_Timer)
        Me.Controls.Add(Me.Lbl_Tiers)
        Me.Controls.Add(Me.Lbl_Url)
        Me.Controls.Add(Me.Tb_Url)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 680)
        Me.MinimumSize = New System.Drawing.Size(600, 680)
        Me.Name = "Form_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KS-Watcher"
        Me.GB_RB_Timer.ResumeLayout(False)
        Me.GB_RB_Timer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tb_Url As TextBox
    Friend WithEvents Lbl_Url As Label
    Friend WithEvents Lbl_Tiers As Label
    Friend WithEvents Rb_10sec As RadioButton
    Friend WithEvents Rb_30sec As RadioButton
    Friend WithEvents Rb_1min As RadioButton
    Friend WithEvents Rb_2min As RadioButton
    Friend WithEvents Rb_5min As RadioButton
    Friend WithEvents Rb_10min As RadioButton
    Friend WithEvents Rb_15sec As RadioButton
    Friend WithEvents GB_RB_Timer As GroupBox
    Friend WithEvents Lbl_Dl_Counter As Label
    Friend WithEvents Lbl_Dl_Traffic_Number As Label
    Friend WithEvents Lbl_Dl_Traffic As Label
    Friend WithEvents Lbl_Dl_Counter_Number As Label
    Friend WithEvents Timer_Downloader As Timer
    Friend WithEvents CMB_Volume As ComboBox
    Friend WithEvents Lbl_Volume As Label
    Friend WithEvents Rb_15min As RadioButton
    Friend WithEvents Lbl_Lang_DE As Label
    Friend WithEvents Lbl_Lang_EN As Label
    Friend WithEvents Lbl_Version As LinkLabel
    Friend WithEvents Tooltip As ToolTip
End Class
