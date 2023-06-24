Imports System.Runtime.CompilerServices

Public Module CharacterTypes
    Friend Const Monster = "Monster"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, CharacterTypeDescriptor) =
        New Dictionary(Of String, CharacterTypeDescriptor) From
        {
            {
                Monster,
                New CharacterTypeDescriptor(
                    " "c,
                    Hue.LightGreen,
                    New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.MaximumHealth, 100},
                        {StatisticTypes.MaximumSatiety, 100},
                        {StatisticTypes.MaximumEnergy, 100},
                        {StatisticTypes.Health, 100},
                        {StatisticTypes.Satiety, 100},
                        {StatisticTypes.Energy, 100}
                    })
            }
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Public Function ToCharacterTypeDescriptor(characterType As String) As CharacterTypeDescriptor
        Return Descriptors(characterType)
    End Function
End Module
