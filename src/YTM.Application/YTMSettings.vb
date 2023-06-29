Public Class YTMSettings
    Implements ISettings
    Sub New(defaultWindowSize As (Integer, Integer))
        Dim cfg = ReadConfig(defaultWindowSize)
        WindowSize = (cfg.WindowWidth, cfg.WindowHeight)
        FullScreen = cfg.FullScreen
        Volume = cfg.SfxVolume
    End Sub
    Public Property WindowSize As (Integer, Integer) Implements ISettings.WindowSize
    Public Property FullScreen As Boolean Implements ISettings.FullScreen
    Public Property Volume As Single Implements ISettings.Volume
    Private Const ConfigFileName = "config.json"
    Private Shared Function ReadConfig(defaultWindowSize As (Integer, Integer)) As YTMConfig
        Try
            Return JsonSerializer.Deserialize(Of YTMConfig)(File.ReadAllText(ConfigFileName))
        Catch ex As Exception
            Return New YTMConfig() With
            {
                .FullScreen = False,
                .SfxVolume = 0.5,
                .WindowHeight = defaultWindowSize.Item2,
                .WindowWidth = defaultWindowSize.Item1
            }
        End Try
    End Function
    Public Sub Save() Implements ISettings.Save
        File.WriteAllText(ConfigFileName, JsonSerializer.Serialize(New YTMConfig With {.SfxVolume = Volume, .WindowHeight = WindowSize.Item2, .WindowWidth = WindowSize.Item1, .FullScreen = FullScreen}))
    End Sub
End Class
