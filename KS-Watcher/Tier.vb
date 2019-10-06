Public Class Tier

    ''' <summary>
    ''' Creates a new tier object.
    ''' </summary>
    ''' <param name="p_Title">title of tier</param>
    ''' <param name="p_Value">current number of backers</param>
    ''' <param name="p_Max">maximum number of backers</param>
    ''' <param name="p_Limit">custom limit for tier</param>
    Public Sub New(p_Title As String, p_Value As UInteger, p_Max As UInteger, p_Limit As UInteger)
        Title = p_Title
        i_Value = p_Value
        i_Max = p_Max
        i_Limit = p_Limit
        Display_Tier()
    End Sub

    ''' <summary>
    ''' Creates a new tier object without displaying it.
    ''' </summary>
    ''' <param name="p_Title">title of tier</param>
    ''' <param name="p_Value">current number of backers</param>
    ''' <param name="p_Max">maximum number of backers</param>
    Public Sub New(p_Title As String, p_Value As UInteger, p_Max As UInteger)
        Title = p_Title
        i_Value = p_Value
        i_Max = p_Max
        i_Limit = 0
    End Sub

    ''' <summary>
    ''' Creates a new entry in the listview to display the tier.
    ''' </summary>
    Private Sub Display_Tier()
        Dim lvi As New ListViewItem(Title)
        lvi.SubItems.Add(Max.ToString + " / " + Value.ToString)
        lvi.SubItems.Add(Limit.ToString)
        Form_Main.CLV_Tiers.Items.Add(lvi)
        Index = Form_Main.CLV_Tiers.Items.Count - 1
    End Sub

#Region "Properties"
    Public Property Title As String

    Private i_Value As UInteger
    Public Property Value As UInteger
        Get
            Return i_Value
        End Get
        Set(arg As UInteger)
            i_Value = arg
            Form_Main.CLV_Tiers.Items.Item(Index).SubItems.Item(1).Text = i_Max.ToString + " / " + i_Value.ToString
        End Set
    End Property

    Private i_Max As UInteger
    Public Property Max As UInteger
        Get
            Return i_Max
        End Get
        Set(arg As UInteger)
            i_Max = arg
            Form_Main.CLV_Tiers.Items.Item(Index).SubItems.Item(1).Text = i_Max.ToString + " / " + i_Value.ToString
        End Set
    End Property

    Private i_Limit As UInteger
    Public Property Limit As UInteger
        Get
            Return i_Limit
        End Get
        Set(arg As UInteger)
            i_Limit = arg
            Form_Main.CLV_Tiers.Items.Item(Index).SubItems.Item(2).Text = i_Limit.ToString
        End Set
    End Property

    Public Property Index As UShort

    ''' <returns>True if tier should be tracked</returns>
    Public Property Marked As Boolean
#End Region
End Class