Friend Module Utility
    Friend Sub ShowStatusBar(Of THue As Structure)(displayBuffer As IPixelSink(Of THue), font As Font, text As String, foreground As THue, background As THue)
        displayBuffer.Fill((0, ViewHeight - font.Height), (ViewWidth, font.Height), background)
        font.WriteText(displayBuffer, (ViewWidth \ 2 - font.TextWidth(text) \ 2, ViewHeight - font.Height), text, foreground)
    End Sub
End Module
