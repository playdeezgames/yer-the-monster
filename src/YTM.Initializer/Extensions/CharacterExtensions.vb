Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Public Sub Move(character As ICharacter, direction As String)
        character.ApplyHunger(1)
        character.Location = character.Location.Route(direction).Destination
        character.AddMessage($"{character.Name} moves {direction.ToDirectionDescriptor.Name}!")
    End Sub
    <Extension>
    Friend Sub ApplyHunger(character As ICharacter, hunger As Integer)
        If character.Satiety >= hunger Then
            character.SetSatiety(character.Satiety - hunger)
            Return
        End If
        hunger -= character.Satiety
        character.SetSatiety(0)
        character.SetHealth(character.Health - hunger)
    End Sub
    <Extension>
    Public Function Health(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.Health)
    End Function
    <Extension>
    Friend Sub SetHealth(character As ICharacter, health As Integer)
        character.Statistic(StatisticTypes.Health) = Math.Clamp(health, 0, character.MaximumHealth)
    End Sub
    <Extension>
    Public Function MaximumHealth(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumHealth)
    End Function
    <Extension>
    Friend Sub SetSatiety(character As ICharacter, satiety As Integer)
        character.Statistic(StatisticTypes.Satiety) = Math.Clamp(satiety, 0, character.MaximumSatiety)
    End Sub
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
    <Extension>
    Public Function IsDead(character As ICharacter) As Boolean
        Return character.Health <= 0
    End Function
End Module
