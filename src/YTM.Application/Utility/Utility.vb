Friend Module Utility
    Friend Sub ShowHeader(displayBuffer As IPixelSink, font As Font, text As String, foreground As Integer, background As Integer)
        displayBuffer.Fill((0, 0), (ViewWidth, font.Height), background)
        font.WriteText(displayBuffer, (ViewWidth \ 2 - font.TextWidth(text) \ 2, 0), text, foreground)
    End Sub
    Friend Sub ShowStatusBar(displayBuffer As IPixelSink, font As Font, text As String, foreground As Integer, background As Integer)
        displayBuffer.Fill((0, ViewHeight - font.Height), (ViewWidth, font.Height), background)
        font.WriteText(displayBuffer, (ViewWidth \ 2 - font.TextWidth(text) \ 2, ViewHeight - font.Height), text, foreground)
    End Sub
    Friend Function ControlsText(aButtonText As String, bButtonText As String) As String
        Return $"Space/(A) - {aButtonText} | Esc/(B) - {bButtonText}"
    End Function
End Module
