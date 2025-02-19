Public Class LISTBOXITEM

    Public Property Text As String
    Public Property Tag As Object

    Public Sub New(ByVal text As String, ByVal tag As Object)
        Me.Text = text
        Me.Tag = tag
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Text
    End Function
End Class

