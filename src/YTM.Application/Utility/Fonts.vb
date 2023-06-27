Friend Module Fonts
    Private ReadOnly fontFilenames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {GameFont.Font3x5, "Content/CyFont3x5.json"},
            {GameFont.Font4x6, "Content/CyFont4x6.json"},
            {GameFont.Font5x7, "Content/CyFont5x7.json"},
            {GameFont.Font8x8, "Content/CyFont8x8.json"},
            {GameFont.YTM, "Content/ytm.json"}
        }
    Private fonts As New Dictionary(Of String, Font)
    Friend Sub Load()
        For Each entry In fontFilenames
            fonts(entry.Key) = New Font(JsonSerializer.Deserialize(Of FontData)(File.ReadAllText(entry.Value)))
        Next
    End Sub
    Friend Function GetFont(gameFont As String) As Font
        Return fonts(gameFont)
    End Function
End Module
