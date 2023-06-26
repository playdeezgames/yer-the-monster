Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Public Sub UseItem(character As ICharacter, item As IItem, verbType As String)
        item.ItemType.ToItemTypeDescriptor.Verbs(verbType).Invoke(character, item)
    End Sub
    Private Sub AddCombatMessage(attacker As ICharacter, defender As ICharacter, ParamArray lines As String())
        attacker.AddMessage(lines)
        defender.AddMessage(lines)
    End Sub
    <Extension>
    Private Function RollAttack(character As ICharacter) As Integer
        Return RNG.FromRange(character.Statistic(StatisticTypes.MinimumAttack), character.Statistic(StatisticTypes.MaximumAttack))
    End Function
    <Extension>
    Private Function RollDefend(character As ICharacter) As Integer
        Return RNG.FromRange(character.Statistic(StatisticTypes.MinimumDefend), character.Statistic(StatisticTypes.MaximumDefend))
    End Function
    <Extension>
    Public Sub Attack(attacker As ICharacter, defender As ICharacter, counterAttack As Boolean)
        Dim message As New List(Of String)
        Dim energyCost = attacker.Statistic(StatisticTypes.AttackEnergyCost)
        If attacker.Energy >= energyCost Then
            attacker.SetEnergy(attacker.Energy - energyCost)
            message.Add($"{attacker.Name} attacks {defender.Name}.")
            Dim attackRoll = attacker.RollAttack
            message.Add($"{attacker.Name} rolls an attack of {attackRoll}.")
            Dim defendRoll = defender.RollDefend
            message.Add($"{defender.Name} rolls an defend of {defendRoll}.")
            Dim damage = Math.Max(0, attackRoll - defendRoll)
            If damage > 0 Then
                message.Add($"{attacker.Name} hits for {damage} damage!")
                defender.SetHealth(defender.Health - damage)
            Else
                message.Add($"{attacker.Name} misses!")
            End If
            If defender.IsDead Then
                message.Add($"{attacker.Name} kills {defender.Name}.")
            Else
                message.Add($"{defender.Name} has {defender.Health}/{defender.MaximumHealth} health.")
            End If
        Else
            message.Add($"{attacker.Name} doesn't have the energy to attack!")
        End If
        AddCombatMessage(attacker, defender, message.ToArray)
        If defender.IsDead Then
            defender.DropLootItem()
            defender.Recycle()
        Else
            If counterAttack Then
                defender.Attack(attacker, False)
            End If
        End If
    End Sub
    <Extension>
    Private Sub DropLootItem(character As ICharacter)
        If character.MapCell.Item Is Nothing Then
            Dim itemType = RNG.FromGenerator(character.CharacterType.ToCharacterTypeDescriptor.ItemTypeDrops)
            If Not String.IsNullOrEmpty(itemType) Then
                character.MapCell.Item = InitializerUtility.CreateItem(character.World, itemType)
            End If
        End If
    End Sub
    <Extension>
    Public Function Move(character As ICharacter, deltaX As Integer, deltaY As Integer) As IMapCell
        Dim mapCell = character.MapCell
        Dim nextColumn = mapCell.Column + deltaX
        Dim nextRow = mapCell.Row + deltaY
        Dim map = mapCell.Map
        If nextColumn < 0 OrElse nextRow < 0 OrElse nextColumn >= map.Columns OrElse nextRow >= map.Rows Then
            Return Nothing
        End If
        Dim nextMapCell = map.Cell(nextColumn, nextRow)
        If Not nextMapCell.TerrainType.ToTerrainTypeDescriptor.Tenable Then
            nextMapCell.Bump(character)
            Return Nothing
        End If
        If nextMapCell.HasCharacter Then
            Return nextMapCell
        End If
        character.ApplyHunger(character.Statistic(StatisticTypes.MoveSatietyCost))
        mapCell.Character = Nothing
        mapCell = nextMapCell
        mapCell.Character = character
        character.MapCell = mapCell
        character.OnEnter()
        Return Nothing
    End Function
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
