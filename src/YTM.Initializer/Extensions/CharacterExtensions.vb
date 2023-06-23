Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Public Sub UseItem(character As ICharacter, item As IItem, verbType As String)
        item.ItemType.ToItemTypeDescriptor.Verbs(verbType).Invoke(character, item)
    End Sub
    <Extension>
    Public Sub Move(character As ICharacter, deltaX As Integer, deltaY As Integer)
        Dim mapCell = character.MapCell
        Dim nextColumn = mapCell.Column + deltaX
        Dim nextRow = mapCell.Row + deltaY
        Dim map = mapCell.Map
        If nextColumn < 0 OrElse nextRow < 0 OrElse nextColumn >= map.Columns OrElse nextRow >= map.Rows Then
            Return
        End If
        Dim nextMapCell = map.Cell(nextColumn, nextRow)
        If Not nextMapCell.TerrainType.ToTerrainTypeDescriptor.Tenable Then
            nextMapCell.Bump(character)
            Return
        End If
        character.ApplyHunger(1)
        mapCell.Character = Nothing
        mapCell = nextMapCell
        mapCell.Character = character
        character.MapCell = mapCell
        character.OnEnter()
    End Sub
    <Extension>
    Friend Sub OnEnter(character As ICharacter)
        Dim mapCell = character.MapCell
        mapCell.TerrainType.ToTerrainTypeDescriptor.OnEnter?.Invoke(character)
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
    Public Sub SetEnergy(character As ICharacter, energy As Integer)
        character.Statistic(StatisticTypes.Energy) = Math.Clamp(energy, 0, character.MaximumEnergy)
    End Sub
    <Extension>
    Public Function MaximumEnergy(character As ICharacter) As Integer
        Return character.Statistic(StatisticTypes.MaximumEnergy)
    End Function
    <Extension>
    Public Function IsDead(character As ICharacter) As Boolean
        Return character.Health <= 0
    End Function
    <Extension>
    Public Sub PickUpItem(character As ICharacter)
        If Not character.MapCell.HasItem Then
            character.AddMessage("There is nothing to pick up!")
            Return
        End If
        Dim item = character.MapCell.Item
        Dim energy = item.PickUpEnergyCost
        If character.Energy < energy Then
            character.AddMessage("Not enough energy!")
            Return
        End If
        character.SetEnergy(character.Energy - energy)
        character.MapCell.Item = Nothing
        character.AddItem(item)
        character.AddMessage($"You pick up the {item.Name}.")
    End Sub
End Module
