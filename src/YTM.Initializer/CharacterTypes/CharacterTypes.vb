Imports System.Runtime.CompilerServices

Public Module CharacterTypes
    Friend Const Monster = "Monster"
    Friend Const Badger = "Badger"
    Friend Const Snake = "Snake"
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
                        {StatisticTypes.Energy, 100},
                        {StatisticTypes.MinimumAttack, 25},
                        {StatisticTypes.MaximumAttack, 50},
                        {StatisticTypes.MinimumDefend, 10},
                        {StatisticTypes.MaximumDefend, 20},
                        {StatisticTypes.MoveSatietyCost, 1},
                        {StatisticTypes.AttackEnergyCost, 5}
                    },
                    New List(Of String) From
                    {
                        TerrainTypes.Lair
                    },
                    New Dictionary(Of String, Integer) From
                    {
                        {String.Empty, 1}
                    })
            }, {
                Badger,
                New CharacterTypeDescriptor(
                    "+"c,
                    Hue.LightGray,
                    New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.MaximumHealth, 50},
                        {StatisticTypes.MaximumSatiety, 50},
                        {StatisticTypes.MaximumEnergy, 50},
                        {StatisticTypes.Health, 50},
                        {StatisticTypes.Satiety, 50},
                        {StatisticTypes.Energy, 50},
                        {StatisticTypes.MinimumAttack, 15},
                        {StatisticTypes.MaximumAttack, 30},
                        {StatisticTypes.MinimumDefend, 5},
                        {StatisticTypes.MaximumDefend, 10},
                        {StatisticTypes.MoveSatietyCost, 0},
                        {StatisticTypes.AttackEnergyCost, 0}
                    },
                    New List(Of String) From
                    {
                        TerrainTypes.Empty
                    },
                    New Dictionary(Of String, Integer) From
                    {
                        {String.Empty, 1},
                        {ItemTypes.BadgerSkin, 1}
                    })
            },
            {
                Snake,
                New CharacterTypeDescriptor(
                    "*"c,
                    Hue.Green,
                    New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.MaximumHealth, 25},
                        {StatisticTypes.MaximumSatiety, 25},
                        {StatisticTypes.MaximumEnergy, 25},
                        {StatisticTypes.Health, 25},
                        {StatisticTypes.Satiety, 25},
                        {StatisticTypes.Energy, 25},
                        {StatisticTypes.MinimumAttack, 10},
                        {StatisticTypes.MaximumAttack, 20},
                        {StatisticTypes.MinimumDefend, 20},
                        {StatisticTypes.MaximumDefend, 40},
                        {StatisticTypes.MoveSatietyCost, 0},
                        {StatisticTypes.AttackEnergyCost, 0}
                    },
                    New List(Of String) From
                    {
                        TerrainTypes.Empty
                    },
                    New Dictionary(Of String, Integer) From
                    {
                        {String.Empty, 1},
                        {ItemTypes.SnakeSkin, 1}
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
