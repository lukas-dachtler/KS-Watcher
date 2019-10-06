Imports System.ComponentModel
Imports System.Drawing.Color
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Web
Imports HtmlAgilityPack
Imports JCS
Imports NAudio.Wave

Public Class Form_Main
    'Variables
    Private custom_interval As Short
    Private custom_counter As Short
    Private counter_dl_number As Long
    Private counter_dl_size As Decimal
    Private file_size As Decimal
    Private volume As Single
    Public Shared color_ks_primary As Color = FromArgb(3, 71, 82)
    Public Shared color_ks_secondary As Color = White
    'Data structures
    Public Lib_Language_Active As New Language_Library
    Private Language_Library_DE As New Language_Library
    Private Language_Library_EN As New Language_Library
    Public Shared Tiers_Setup As New List(Of Tier)
    Public Tiers_Download As New List(Of Tier)
    'Controls
    Public CLV_Tiers As New Listview_Colored
    Private ReadOnly Btn_Analyze As New Button_Colored
    Private ReadOnly Btn_Start As New Button_Colored
    Private ReadOnly Btn_Stop As New Button_Colored
    Private ReadOnly ToggleSwitch_Lang As New JCS.ToggleSwitch
    Private ReadOnly Cust_OSX_Style As New ToggleSwitchOSXRenderer
    'Objects
    Private Volume_Player_Waveout As WaveOut
    Private Volume_Player_Reader As WaveFileReader

#Region "Language implementation"
    Public Structure Language_Library
        Public s_btn_analyze As String
        Public s_btn_start As String
        Public s_btn_stop As String
        Public s_lbl_url As String
        Public s_lbl_tiers As String
        Public s_gb_title As String
        Public s_rb_10_sec As String
        Public s_rb_15_sec As String
        Public s_rb_30_sec As String
        Public s_rb_1_min As String
        Public s_rb_2_min As String
        Public s_rb_5_min As String
        Public s_rb_10_min As String
        Public s_rb_15_min As String
        Public s_lbl_volume As String
        Public s_lbl_version As String
        Public s_dl_counter As String
        Public s_dl_traffic As String
        Public s_msg_general_content As String
        Public s_msg_general_title As String
        Public s_msg_expired_content As String
        Public s_msg_expired_title As String
        Public s_msg_connection_content As String
        Public s_msg_connection_title As String
        Public s_msg_notiers_content As String
        Public s_msg_notiers_title As String
        Public s_msg_difftiers_content As String
        Public s_msg_difftiers_title As String
        Public s_msg_tieropen_content As String
        Public s_msg_tieropen_title As String
        Public s_msg_allowdl_content As String
        Public s_msg_allowdl_title As String
        Public s_msg_legality_content As String
        Public s_msg_legality_title As String
        Public s_msg_noselection_content As String
        Public s_msg_noselection_title As String
        Public s_msg_linkopen_title As String
        Public s_msg_linkopen_content As String
        Public s_clv_col_1 As String
        Public s_clv_col_2 As String
        Public s_clv_col_3 As String
        Public s_btn_change_limit As String
        Public s_btn_select_all As String
        Public s_btn_deselect_all As String
        Public s_tooltip_link As String
    End Structure

    Private Sub Initialize_Language()
        Language_Library_DE.s_btn_analyze = "Analysiere Projekt"
        Language_Library_DE.s_btn_start = "Starte Überwachung"
        Language_Library_DE.s_btn_stop = "Beende Überwachung"
        Language_Library_DE.s_lbl_url = "Bitte URL hier eingeben:"
        Language_Library_DE.s_lbl_tiers = "Wählen Sie, welche Belohnungen Sie überwachen möchten:"
        Language_Library_DE.s_gb_title = "Überprüfe alle ..."
        Language_Library_DE.s_rb_10_sec = "10 Sek."
        Language_Library_DE.s_rb_15_sec = "15 Sek."
        Language_Library_DE.s_rb_30_sec = "30 Sek."
        Language_Library_DE.s_rb_1_min = "1 Min."
        Language_Library_DE.s_rb_2_min = "2 Min."
        Language_Library_DE.s_rb_5_min = "5 Min."
        Language_Library_DE.s_rb_10_min = "10 Min."
        Language_Library_DE.s_rb_15_min = "15 Min."
        Language_Library_DE.s_lbl_volume = "Alarm-" + Environment.NewLine + "Lautstärke"
        Language_Library_DE.s_lbl_version = "Version: 2.2 | Datum: 10 / 19"
        Language_Library_DE.s_dl_counter = "Anzahl der Downloads:"
        Language_Library_DE.s_dl_traffic = "Ungefähre Download-Menge:"
        Language_Library_DE.s_msg_general_content = "Ein Fehler ist aufgetreten! Die Datei konnte nicht heruntergeladen werden!"
        Language_Library_DE.s_msg_general_title = "Fehler"
        Language_Library_DE.s_msg_expired_content = "Dieses Projekt ist bereits geschlossen!"
        Language_Library_DE.s_msg_expired_title = "Fehler: Projekt geschlossen!"
        Language_Library_DE.s_msg_connection_content = "Sie sind nicht mit dem Internet verbunden!"
        Language_Library_DE.s_msg_connection_title = "Fehler: Verbindung"
        Language_Library_DE.s_msg_notiers_content = "Es wurden keine gesperrten Belohnungen bei diesem Projekt gefunden!"
        Language_Library_DE.s_msg_notiers_title = "Fehler: Keine Belohnungen gefunden!"
        Language_Library_DE.s_msg_difftiers_content = "Es wurden Belohnungen gelöscht oder hinzugefügt. Bitte analysieren Sie das Projekt neu!"
        Language_Library_DE.s_msg_difftiers_title = "Fehler: Unterschiedliche Belohnungen"
        Language_Library_DE.s_msg_tieropen_content = "Mindestens eine Ihrer ausgewählten Belohnungen ist frei oder hat das Limit erreicht!"
        Language_Library_DE.s_msg_tieropen_title = "Achtung: Eine Belohnung ist frei!"
        Language_Library_DE.s_msg_allowdl_content = "Diese Software wird regelmäßig diese Webseite auf Ihren Computer herunterladen!" + Environment.NewLine + "Sind Sie sicher, dass Sie fortfahren wollen?"
        Language_Library_DE.s_msg_allowdl_title = "Downloads zulassen?"
        Language_Library_DE.s_msg_legality_content = "Akzeptieren Sie, dass Sie diese Software auf eigenes Risiko verwenden?"
        Language_Library_DE.s_msg_legality_title = "Gesetzmäßigkeit"
        Language_Library_DE.s_msg_noselection_content = "Bitte selektieren Sie mindestens eine Belohnung und wählen Sie die gewünschte Lautstärke!"
        Language_Library_DE.s_msg_noselection_title = "Fehler: Keine Auswahl"
        Language_Library_DE.s_msg_linkopen_content = "Dieser Link führt Sie zur Produktseite dieser Software."
        Language_Library_DE.s_msg_linkopen_title = "Link öffnen?"
        Language_Library_DE.s_clv_col_1 = "Belohnung"
        Language_Library_DE.s_clv_col_2 = "Kapazität"
        Language_Library_DE.s_clv_col_3 = "Limit"
        Language_Library_DE.s_btn_change_limit = "Ändere Limit"
        Language_Library_DE.s_btn_select_all = "Alle markieren"
        Language_Library_DE.s_btn_deselect_all = "Keine markieren"
        Language_Library_DE.s_tooltip_link = "molistum.de/ks-watcher_de/"

        Language_Library_EN.s_btn_analyze = "Analyze project"
        Language_Library_EN.s_btn_start = "Start watching"
        Language_Library_EN.s_btn_stop = "Stop watching"
        Language_Library_EN.s_lbl_url = "Please enter the URL here:"
        Language_Library_EN.s_lbl_tiers = "Please choose the tiers you want to watch out for:"
        Language_Library_EN.s_gb_title = "Check every ..."
        Language_Library_EN.s_rb_10_sec = "10 sec."
        Language_Library_EN.s_rb_15_sec = "15 sec."
        Language_Library_EN.s_rb_30_sec = "30 sec."
        Language_Library_EN.s_rb_1_min = "1 min."
        Language_Library_EN.s_rb_2_min = "2 min."
        Language_Library_EN.s_rb_5_min = "5 min."
        Language_Library_EN.s_rb_10_min = "10 min."
        Language_Library_EN.s_rb_15_min = "15 min."
        Language_Library_EN.s_lbl_volume = "Alarm-" + Environment.NewLine + "Volume"
        Language_Library_EN.s_lbl_version = "Version: 2.2 | Date: 10 / 19"
        Language_Library_EN.s_dl_counter = "Number of times downloaded:"
        Language_Library_EN.s_dl_traffic = "Approximate download traffic:"
        Language_Library_EN.s_msg_general_content = "An error has occured! The file could not be downloaded!"
        Language_Library_EN.s_msg_general_title = "Error"
        Language_Library_EN.s_msg_expired_content = "This project is already closed!"
        Language_Library_EN.s_msg_expired_title = "Error: Project closed!"
        Language_Library_EN.s_msg_connection_content = "You are not connected to the internet!"
        Language_Library_EN.s_msg_connection_title = "Error: Connection"
        Language_Library_EN.s_msg_notiers_content = "No locked tiers were found on this project!"
        Language_Library_EN.s_msg_notiers_title = "Error: No tiers found!"
        Language_Library_EN.s_msg_difftiers_content = "Tiers have been removed or added. Please analyze the project again!"
        Language_Library_EN.s_msg_difftiers_title = "Error: Different tiers!"
        Language_Library_EN.s_msg_tieropen_content = "At least one of your selected tiers is available again or has reached your limit!"
        Language_Library_EN.s_msg_tieropen_title = "Attention: Tier open!"
        Language_Library_EN.s_msg_allowdl_content = "This software will continuously download this webpage on your computer!" + Environment.NewLine + "Are you sure you want to continue?"
        Language_Library_EN.s_msg_allowdl_title = "Allow download?"
        Language_Library_EN.s_msg_legality_content = "Do you accept to use this software at your own risk?"
        Language_Library_EN.s_msg_legality_title = "Legality"
        Language_Library_EN.s_msg_noselection_content = "Please select at least one tier and set the desired volume!"
        Language_Library_EN.s_msg_noselection_title = "Error: No selection"
        Language_Library_EN.s_msg_linkopen_content = "This link will bring you to the product page of this software."
        Language_Library_EN.s_msg_linkopen_title = "Open link?"
        Language_Library_EN.s_clv_col_1 = "Tier"
        Language_Library_EN.s_clv_col_2 = "Capacity"
        Language_Library_EN.s_clv_col_3 = "Limit"
        Language_Library_EN.s_btn_change_limit = "Change Limit"
        Language_Library_EN.s_btn_select_all = "Select all"
        Language_Library_EN.s_btn_deselect_all = "Select none"
        Language_Library_EN.s_tooltip_link = "molistum.de/ks-watcher/"
    End Sub

    ''' <summary>
    ''' Switches the language of the GUI. (Note: "en" and "de" only).
    ''' </summary>
    ''' <param name="lang">language as defined in ISO 639-1</param>
    Private Sub Switch_Language(lang As String)
        Select Case lang
            Case "de"
                Lib_Language_Active = Language_Library_DE
            Case "en"
                Lib_Language_Active = Language_Library_EN
            Case Else
                Lib_Language_Active = Language_Library_EN
        End Select
        Btn_Analyze.Text = Lib_Language_Active.s_btn_analyze
        Btn_Start.Text = Lib_Language_Active.s_btn_start
        Btn_Stop.Text = Lib_Language_Active.s_btn_stop
        Lbl_Url.Text = Lib_Language_Active.s_lbl_url
        Lbl_Tiers.Text = Lib_Language_Active.s_lbl_tiers
        GB_RB_Timer.Text = Lib_Language_Active.s_gb_title
        Rb_10sec.Text = Lib_Language_Active.s_rb_10_sec
        Rb_15sec.Text = Lib_Language_Active.s_rb_15_sec
        Rb_30sec.Text = Lib_Language_Active.s_rb_30_sec
        Rb_1min.Text = Lib_Language_Active.s_rb_1_min
        Rb_2min.Text = Lib_Language_Active.s_rb_2_min
        Rb_5min.Text = Lib_Language_Active.s_rb_5_min
        Rb_10min.Text = Lib_Language_Active.s_rb_10_min
        Rb_15min.Text = Lib_Language_Active.s_rb_15_min
        Lbl_Volume.Text = Lib_Language_Active.s_lbl_volume
        Lbl_Version.Text = Lib_Language_Active.s_lbl_version
        Tooltip.SetToolTip(Lbl_Version, Lib_Language_Active.s_tooltip_link)
        Lbl_Dl_Counter.Text = Lib_Language_Active.s_dl_counter
        Lbl_Dl_Traffic.Text = Lib_Language_Active.s_dl_traffic
        CLV_Tiers.Columns.Item(0).Text = Lib_Language_Active.s_clv_col_1
        CLV_Tiers.Columns.Item(1).Text = Lib_Language_Active.s_clv_col_2
        CLV_Tiers.Columns.Item(2).Text = Lib_Language_Active.s_clv_col_3
        If Form_Custom_CMS IsNot Nothing Then
            Form_Custom_CMS.Btn_Change_Limit.Text = Lib_Language_Active.s_btn_change_limit
            Form_Custom_CMS.Btn_Select_All.Text = Lib_Language_Active.s_btn_select_all
            Form_Custom_CMS.Btn_Deselect_All.Text = Lib_Language_Active.s_btn_deselect_all
        End If
    End Sub

    Private Sub ToggleSwitch_Lang_CheckedChanged(sender As Object, e As EventArgs)
        If ToggleSwitch_Lang.Checked = True Then
            Switch_Language("en")
        Else
            Switch_Language("de")
        End If
    End Sub
#End Region

#Region "Initializing form and data"
    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize controls
        CLV_Tiers.Font = New Font("Arial", 12.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
        CLV_Tiers.Size = New Size(556, 214)
        CLV_Tiers.Location = New Point(15, 159)
        CLV_Tiers.Enabled = False

        Btn_Analyze.Font = New Font("Arial", 15.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Analyze.Size = New Size(556, 50)
        Btn_Analyze.Location = New Point(15, 61)
        AddHandler Btn_Analyze.Click, AddressOf Btn_Analyze_Click

        Btn_Start.Font = New Font("Arial", 15.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Start.Size = New Size(270, 50)
        Btn_Start.Location = New Point(15, 503)
        AddHandler Btn_Start.Click, AddressOf Btn_Start_Click

        Btn_Stop.Font = New Font("Arial", 15.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Stop.Size = New Size(270, 50)
        Btn_Stop.Location = New Point(301, 503)
        AddHandler Btn_Stop.Click, AddressOf Btn_Stop_Click

        Cust_OSX_Style.BackColor1 = color_ks_primary
        Cust_OSX_Style.BackColor2 = color_ks_primary
        Cust_OSX_Style.ButtonNormalSurfaceColor1 = color_ks_secondary
        Cust_OSX_Style.ButtonNormalSurfaceColor2 = color_ks_secondary
        Cust_OSX_Style.ButtonHoverSurfaceColor1 = color_ks_secondary
        Cust_OSX_Style.ButtonHoverSurfaceColor2 = color_ks_secondary
        Cust_OSX_Style.ButtonPressedSurfaceColor1 = color_ks_secondary
        Cust_OSX_Style.ButtonPressedSurfaceColor2 = color_ks_secondary
        Cust_OSX_Style.ButtonNormalBorderColor1 = color_ks_primary
        Cust_OSX_Style.ButtonNormalBorderColor2 = color_ks_primary
        Cust_OSX_Style.ButtonHoverBorderColor1 = color_ks_primary
        Cust_OSX_Style.ButtonHoverBorderColor2 = color_ks_primary
        Cust_OSX_Style.ButtonPressedBorderColor1 = color_ks_primary
        Cust_OSX_Style.ButtonPressedBorderColor2 = color_ks_primary
        Cust_OSX_Style.InnerBorderColor1 = color_ks_primary
        Cust_OSX_Style.InnerBorderColor2 = color_ks_primary
        Cust_OSX_Style.OuterBorderColor = color_ks_primary

        ToggleSwitch_Lang.Name = "ToggleSwitch_Lang"

        ToggleSwitch_Lang.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX
        ToggleSwitch_Lang.SetRenderer(Cust_OSX_Style)
        ToggleSwitch_Lang.BackColor = White
        ToggleSwitch_Lang.Update()
        ToggleSwitch_Lang.Size = New Size(50, 20)
        ToggleSwitch_Lang.Location = New Point(465, 580)
        ToggleSwitch_Lang.OnText = ""
        AddHandler ToggleSwitch_Lang.CheckedChanged, AddressOf ToggleSwitch_Lang_CheckedChanged

        Controls.Add(CLV_Tiers)
        Controls.Add(Btn_Analyze)
        Controls.Add(Btn_Start)
        Controls.Add(Btn_Stop)
        Controls.Add(ToggleSwitch_Lang)
        CLV_Tiers.Items.Clear()

        Tb_Url.Clear()
        Tb_Url.Focus()
        Btn_Start.Enabled = False
        Btn_Stop.Enabled = False
        Rb_2min.Checked = True
        Timer_Downloader.Enabled = False
        custom_interval = 0
        custom_counter = 0
        counter_dl_number = 0
        counter_dl_size = 0
        file_size = 0
        volume = 0
        Lbl_Dl_Counter_Number.Text = 0
        Lbl_Dl_Traffic_Number.Text = 0

        Lbl_Version.ForeColor = FromArgb(60, 60, 60)
        Lbl_Version.LinkColor = FromArgb(60, 60, 60)
        Lbl_Version.ActiveLinkColor = color_ks_primary
        Lbl_Version.VisitedLinkColor = color_ks_primary
        Lbl_Version.DisabledLinkColor = Black

        Tb_Url.TabIndex = 0
        Btn_Analyze.TabIndex = 1
        CLV_Tiers.TabIndex = 2
        GB_RB_Timer.TabIndex = 3
        Rb_10sec.TabIndex = 4
        Rb_15sec.TabIndex = 5
        Rb_30sec.TabIndex = 6
        Rb_1min.TabIndex = 7
        Rb_2min.TabIndex = 8
        Rb_5min.TabIndex = 9
        Rb_10min.TabIndex = 10
        Rb_15min.TabIndex = 11
        CMB_Volume.TabIndex = 12
        Btn_Start.TabIndex = 13
        Btn_Stop.TabIndex = 14
        Lbl_Version.TabIndex = 15

        CLV_Tiers.Enabled = True
        CLV_Tiers.Columns.Add("Tier")
        CLV_Tiers.Columns.Add("Capacity")
        CLV_Tiers.Columns.Add("Limit")
        CLV_Tiers.Columns.Item(0).TextAlign = HorizontalAlignment.Center
        CLV_Tiers.Columns.Item(1).TextAlign = HorizontalAlignment.Right
        CLV_Tiers.Columns.Item(2).TextAlign = HorizontalAlignment.Right
        CLV_Tiers.Columns.Item(0).Width = 345
        CLV_Tiers.Columns.Item(1).Width = 120
        CLV_Tiers.Columns.Item(2).Width = 70

        Initialize_Language()

        Select Case Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            Case "de"
                ToggleSwitch_Lang.Checked = False
                Switch_Language(Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            Case "en"
                ToggleSwitch_Lang.Checked = True
                Switch_Language(Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            Case Else
                ToggleSwitch_Lang.Checked = True
                Switch_Language(Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
        End Select
    End Sub
#End Region

#Region "Click-events for buttons"
    Private Sub Btn_Analyze_Click(sender As Object, e As EventArgs)
        CLV_Tiers.Enabled = False
        Btn_Start.Enabled = False
        Btn_Stop.Enabled = False
        GB_RB_Timer.Enabled = True
        Btn_Analyze.Enabled = True
        If Timer_Downloader.Enabled = True Then
            Timer_Downloader.Stop()
        End If
        If My.Computer.Network.IsAvailable = True Then
            Download_Tiers_initial()
        Else
            MessageBox.Show(Lib_Language_Active.s_msg_connection_content, Lib_Language_Active.s_msg_connection_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Btn_Start_Click(sender As Object, e As EventArgs)
        If My.Computer.Network.IsAvailable = True Then
            If MessageBox.Show(Lib_Language_Active.s_msg_legality_content, Lib_Language_Active.s_msg_legality_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If CLV_Tiers.CheckedItems.Count <> 0 And CMB_Volume.Text <> "" Then
                    Btn_Stop.Enabled = True
                    Btn_Start.Enabled = False
                    GB_RB_Timer.Enabled = False
                    Btn_Analyze.Enabled = False
                    Timer_Downloader.Interval = 5000
                    custom_counter = 1
                    Lbl_Dl_Counter_Number.Text = 0
                    Lbl_Dl_Traffic_Number.Text = 0
                    Timer_Downloader.Enabled = False
                    counter_dl_number = 0
                    counter_dl_size = 0
                    Select Case True
                        Case Rb_10sec.Checked
                            custom_interval = 2
                        Case Rb_15sec.Checked
                            custom_interval = 3
                        Case Rb_30sec.Checked
                            custom_interval = 6
                        Case Rb_1min.Checked
                            custom_interval = 12
                        Case Rb_2min.Checked
                            custom_interval = 24
                        Case Rb_5min.Checked
                            custom_interval = 60
                        Case Rb_10min.Checked
                            custom_interval = 120
                        Case Rb_15min.Checked
                            custom_interval = 180
                    End Select
                    Timer_Downloader.Start()
                Else
                    MessageBox.Show(Lib_Language_Active.s_msg_noselection_content, Lib_Language_Active.s_msg_noselection_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else
            MessageBox.Show(Lib_Language_Active.s_msg_connection_content, Lib_Language_Active.s_msg_connection_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Btn_Stop_Click(sender As Object, e As EventArgs)
        Btn_Start.Enabled = True
        Btn_Stop.Enabled = False
        GB_RB_Timer.Enabled = True
        Btn_Analyze.Enabled = True
        Timer_Downloader.Stop()
    End Sub
#End Region

#Region "Handle other components and events from form"
    Private Sub CMB_Volume_TextChanged(sender As Object, e As EventArgs) Handles CMB_Volume.TextChanged
        If CMB_Volume.Items.Contains(CMB_Volume.Text) Then
            If IsNothing(Volume_Player_Waveout) = False Then
                Volume_Player_Waveout.Stop()
                Volume_Player_Waveout.Dispose()
            End If
            Volume_Player_Waveout = New WaveOut()
            Volume_Player_Reader = New WaveFileReader(My.Resources.notify)
            Volume_Player_Waveout.Init(Volume_Player_Reader)
            If CMB_Volume.SelectedIndex >= 0 Then
                volume = (CMB_Volume.SelectedIndex + 1) / 10
                Volume_Player_Waveout.Volume = volume
                Volume_Player_Waveout.Play()
            End If
        Else
            CMB_Volume.Text = ""
        End If
    End Sub

    Private Sub Form_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Timer_Downloader.Enabled = True Then
            Timer_Downloader.Stop()
        End If
    End Sub

    Private Sub Lbl_Version_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lbl_Version.LinkClicked
        If MessageBox.Show(Lib_Language_Active.s_msg_linkopen_content, Lib_Language_Active.s_msg_linkopen_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If ToggleSwitch_Lang.Checked = True Then
                Process.Start("http://molistum.de/ks-watcher/")
            Else
                Process.Start("http://molistum.de/ks-watcher_de/")
            End If
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Wrapper function for initially downloading the tiers.
    ''' </summary>
    ''' <returns>True if successful, false otherwise.</returns>
    Private Function Download_Tiers_initial() As Boolean
        CLV_Tiers.Items.Clear()
        Tiers_Setup.Clear()
        Dim msgresult As MsgBoxResult = MessageBox.Show(Lib_Language_Active.s_msg_allowdl_content, Lib_Language_Active.s_msg_allowdl_title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If msgresult = MsgBoxResult.Yes Then
            'Simple url check
            If Regex.IsMatch(Tb_Url.Text, "^(https?:\/\/)?www\.kickstarter\.com\/projects\/.*") = False Then
                MessageBox.Show(Lib_Language_Active.s_msg_general_content, Lib_Language_Active.s_msg_general_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            'Download webpage and calculate size
            Try
                Dim request As HttpWebRequest = WebRequest.Create(Tb_Url.Text)
                Dim response As HttpWebResponse = request.GetResponse()
                file_size = response.ContentLength / 1024
                request.Abort()
                response.Dispose()
            Catch ex As Exception
                MessageBox.Show(Lib_Language_Active.s_msg_general_content, Lib_Language_Active.s_msg_general_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Else
            Return False
        End If
        If Download_Tiers(True) Then
            If Tiers_Setup.Count > 0 Then
                Btn_Start.Enabled = True
                CLV_Tiers.Enabled = True
                Return True
            Else
                Disable_Timer()
                MessageBox.Show(Lib_Language_Active.s_msg_notiers_content, Lib_Language_Active.s_msg_notiers_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Wrapper function for continuosly downloading the tiers.
    ''' </summary>
    ''' <returns>True if Download_Tiers(False) was successful, false on error.</returns>
    Private Function Download_Tiers_continuous() As Boolean
        Tiers_Download.Clear()
        Return Download_Tiers(False)
    End Function

    ''' <summary>
    ''' Downloads and parses the webpage for the limited tiers.
    ''' </summary>
    ''' <param name="initial_analysis">true for intial analysis, false for continuous analysis</param>
    ''' <returns>True if successful, false on error.</returns>
    Private Function Download_Tiers(initial_analysis As Boolean) As Boolean
        Dim web As New HtmlWeb
        Dim doc As HtmlDocument = web.Load(Tb_Url.Text)
        Dim node As HtmlNode
        Dim node_limit As HtmlNode
        Dim node_name As HtmlNode
        Dim node_value As HtmlNode
        Dim name As String
        Dim value As UInteger
        Dim s_max As String
        Dim active = False
        Dim max As UInteger
        'Check if project is live
        Dim nodes_btn As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//*[contains(concat(' ', @class, ' '), ' bttn-green ')]")
        For i = 0 To nodes_btn.Count - 1
            If nodes_btn.Item(i).InnerHtml.ToLower.Contains("back this project") Then
                active = True
                Exit For
            End If
        Next
        If active = False Then
            Disable_Timer()
            MessageBox.Show(Lib_Language_Active.s_msg_expired_content, Lib_Language_Active.s_msg_expired_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Try
            'Find every tier
            Dim nodes_tiers As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//*[contains(concat(' ', @class, ' '), ' pledge__info ')]")
            For i = 0 To nodes_tiers.Count - 1
                node = HtmlNode.CreateNode(nodes_tiers.Item(i).OuterHtml)
                'Filter for limited tiers
                node_limit = node.SelectSingleNode("//*[contains(concat(' ', @class, ' '), ' pledge__limit ')]")
                If IsNothing(node_limit) = False Then
                    'Exclude time limited tiers
                    If node_limit.HasClass("ksr_page_timer") = False Then
                        'Extract values from HTML
                        node_name = node.SelectSingleNode("//*[contains(concat(' ', @class, ' '), ' pledge__title ')]")
                        name = HttpUtility.HtmlDecode(Remove_Linebreak(node_name.InnerHtml))
                        node_value = node.SelectSingleNode("//*[contains(concat(' ', @class, ' '), ' pledge__backer-count ')]")
                        value = Convert.ToUInt32(Regex.Match(Remove_Linebreak(node_value.InnerHtml), "\d*(,)?\d*").Value.Replace(",", ""))
                        'Evaluate if tier is locked or still available
                        If Remove_Linebreak(node_limit.InnerHtml) = "Reward no longer available" Then
                            max = value
                        Else
                            s_max = Regex.Match(node_limit.InnerHtml, "\d*(,)?\d*\)").Value.Replace(",", "")
                            max = Convert.ToUInt32(Strings.Left(s_max, s_max.Length - 1))
                        End If
                        'Add tier
                        Dim new_tier As Tier
                        If initial_analysis = True Then
                            Dim limit As UInteger = Calculate_Limit(value, max)
                            new_tier = New Tier(name, value, max, limit)
                            Tiers_Setup.Add(new_tier)
                        Else
                            new_tier = New Tier(name, value, max)
                            Tiers_Download.Add(new_tier)
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Disable_Timer()
            MessageBox.Show(Lib_Language_Active.s_msg_general_content, Lib_Language_Active.s_msg_general_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Checks if any monitored tier matches the limit criteria.
    ''' </summary>
    ''' <returns>True if successful, false on error.</returns>
    Private Function Check_for_Tier_Availability() As Boolean
        Try
            Dim cf_title As String
            Dim dl_tier As Tier
            For i = 0 To Tiers_Setup.Count - 1
                cf_title = Tiers_Setup(i).Title
                dl_tier = Tiers_Download.Find(Function(x) x.Title = cf_title)
                Tiers_Setup(i).Value = dl_tier.Value
                Tiers_Setup(i).Max = dl_tier.Max
                If (Tiers_Setup(i).Value < Tiers_Setup(i).Max And Tiers_Setup(i).Max = Tiers_Setup(i).Limit And Tiers_Setup(i).Marked = True) Or
                   (Tiers_Setup(i).Value >= Tiers_Setup(i).Limit And Tiers_Setup(i).Max <> Tiers_Setup(i).Limit And Tiers_Setup(i).Marked = True) Then
                    If Timer_Downloader.Enabled = True Then
                        Disable_Timer()
                        Alert()
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            MessageBox.Show(Lib_Language_Active.s_msg_general_content, Lib_Language_Active.s_msg_general_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Calls Check_for_Tier_Availability() in the set interval.
    ''' </summary>
    Private Sub Timer_Downloader_Tick(sender As Object, e As EventArgs) Handles Timer_Downloader.Tick
        If My.Computer.Network.IsAvailable = True Then
            If custom_counter >= custom_interval Then
                custom_counter = 1
                If CLV_Tiers.CheckedItems.Count <> 0 Then
                    If Download_Tiers_continuous() = True Then
                        If Tiers_Setup.Count = Tiers_Download.Count Then
                            If Check_for_Tier_Availability() = True Then
                                counter_dl_number += 1
                                Lbl_Dl_Counter_Number.Text = counter_dl_number.ToString
                                Lbl_Dl_Traffic_Number.Text = Compute_Download_Unit(file_size)
                            End If
                        Else
                            Disable_Timer()
                            MessageBox.Show(Lib_Language_Active.s_msg_difftiers_content, Lib_Language_Active.s_msg_difftiers_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                custom_counter += 1
            End If
        Else
            Disable_Timer()
            MessageBox.Show(Lib_Language_Active.s_msg_connection_content, Lib_Language_Active.s_msg_connection_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ''' <summary>
    ''' Disables timer and restores GUI.
    ''' </summary>
    Private Sub Disable_Timer()
        Btn_Start.Enabled = True
        Btn_Stop.Enabled = False
        GB_RB_Timer.Enabled = True
        Btn_Analyze.Enabled = True
        Timer_Downloader.Stop()
    End Sub

    ''' <summary>
    ''' Minimizes all windows, flashes the application in the taskbar and plays the notification sound in loop.
    ''' </summary>
    Private Sub Alert()
        'Minimize all windows
        Keyboard_Simulator.Simulate_Key_Down(Keys.LWin)
        Keyboard_Simulator.Simulate_Key_Down(Keys.D)
        Keyboard_Simulator.Simulate_Key_Up(Keys.LWin)
        Keyboard_Simulator.Simulate_Key_Up(Keys.D)
        'Play alert-sound
        Dim player_waveout As New WaveOut
        Dim player_reader As New WaveFileReader(My.Resources.notify)
        Dim player_loopstream As New LoopStream(player_reader)
        player_waveout.Init(player_loopstream)
        player_waveout.Volume = volume
        player_waveout.Play()
        'Flash window
        Flash_Window_Handler.Flash_Window(Process.GetCurrentProcess().MainWindowHandle, True, True, 5)
        'Show message
        MessageBox.Show(Lib_Language_Active.s_msg_tieropen_content, Lib_Language_Active.s_msg_tieropen_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Stop player
        player_waveout.Stop()
        player_waveout.Dispose()
        player_reader.Dispose()
        player_loopstream.Dispose()
        'Open project in webbrowser
        Try
            Process.Start(Tb_Url.Text)
        Catch : End Try
    End Sub

#Region "Helper functions"
    ''' <summary>
    ''' Calculates the predefined limit based on given current and maximum backers.
    ''' </summary>
    ''' <param name="value">current number of backers</param>
    ''' <param name="max">maximum number of backers</param>
    ''' <returns>Limit</returns>
    Private Shared Function Calculate_Limit(value As UInteger, max As UInteger) As UInteger
        Dim limit As UInteger
        Dim diff As UInteger = max - value
        If max > 10 And diff > 10 Then
            limit = If(max - Math.Floor(max / 10) > value, max - Math.Floor(max / 10), max - Math.Floor((diff) / 10))
        Else
            limit = value + Math.Floor(diff / 2)
        End If
        Return limit
    End Function

    ''' <summary>
    ''' Computes size of download by rounding and converting to MB if necessary.
    ''' </summary>
    ''' <param name="download_size">size of download in kb</param>
    ''' <returns>rounded size of download in kB or MB</returns>
    Private Function Compute_Download_Unit(download_size As Decimal) As String
        counter_dl_size += Convert.ToDecimal(Math.Ceiling(download_size))
        If counter_dl_size > 1024 Then
            Return (Convert.ToString(Math.Round(counter_dl_size / 1024, 2)) & " MB")
        Else
            Return (Convert.ToString(Math.Round(counter_dl_size, 2)) & " kB")
        End If
    End Function

    ''' <summary>
    ''' Removes linebreaks from string.
    ''' </summary>
    ''' <param name="text">String to remove linebreaks on</param>
    ''' <returns>String with no linebreaks</returns>
    Private Shared Function Remove_Linebreak(text As String)
        Dim result As String = text
        result = result.Replace(vbCr, "")
        result = result.Replace(vbLf, "")
        Return result
    End Function
#End Region

#Region "Flash window implementation"
    Public Class Flash_Window_Handler
        Private Declare Function Flash_Window_Ex Lib "User32" Alias "FlashWindowEx" (ByRef fw_info As FLASHWINDOWINFO) As Boolean

        Public Enum Flash_Window_Flags As UInt32
            'FLASHWINDOW_STOP = 0
            FLASHWINDOW_CAPTION = 1
            FLASHWINDOW_TRAY = 2
            'FLASHWINDOW_ALL = 3
            'FLASHWINDOW_TIMER = 4
            FLASHWINDOW_TIMERNOFG = 12
        End Enum

        Public Structure FLASHWINDOWINFO
            Public size As UInt32
            Public hwnd As IntPtr
            Public flags As Flash_Window_Flags
            Public count As UInt32
            Public timeout As UInt32
        End Structure

        Public Shared Sub Flash_Window(ByRef handle As IntPtr, title_bar As Boolean, tray As Boolean, count As UInteger)
            If handle = Nothing Then Exit Sub
            Try
                Dim fwi As New FLASHWINDOWINFO
                With fwi
                    .hwnd = handle
                    If title_bar Then .flags = .flags Or Flash_Window_Flags.FLASHWINDOW_CAPTION
                    If tray Then .flags = .flags Or Flash_Window_Flags.FLASHWINDOW_TRAY
                    .count = count
                    If count = 0 Then .flags = .flags Or Flash_Window_Flags.FLASHWINDOW_TIMERNOFG
                    .timeout = 0
                    .size = CUInt(Marshal.SizeOf(fwi))
                End With
                Flash_Window_Ex(fwi)
            Catch : End Try
        End Sub
    End Class
#End Region

#Region "Keyboard_Simulator implementation"
    Public Class Keyboard_Simulator

        Declare Function Keybd_Event Lib "user32" Alias "keybd_event" (bVk As Byte, bScan As Byte, dwFlags As Integer, dwExtraInfo As Integer) As Integer

        Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
        Private Const KEYEVENTF_KEYUP As Integer = &H2

        Public Shared Sub Simulate_Key_Down(key As Keys)
            Keybd_Event(key, 0, KEYEVENTF_EXTENDEDKEY, 0)
        End Sub

        Public Shared Sub Simulate_Key_Up(key As Keys)
            Keybd_Event(key, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        End Sub
    End Class
#End Region
End Class