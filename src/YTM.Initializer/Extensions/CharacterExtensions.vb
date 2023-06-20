Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Public Sub Move(character As ICharacter, direction As String)
        character.Location = character.Location.Route(direction).Destination
    End Sub
    <Extension>
    Public Function Health(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Health)
    End Function
    <Extension>
    Public Function MaximumHealth(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumHealth)
    End Function
    <Extension>
    Public Function Satiety(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Satiety)
    End Function
    <Extension>
    Public Function MaximumSatiety(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumSatiety)
    End Function
    <Extension>
    Public Function Energy(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Energy)
    End Function
    <Extension>
    Public Function MaximumEnergy(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumEnergy)
    End Function
End Module
