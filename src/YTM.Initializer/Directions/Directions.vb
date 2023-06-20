Imports System.Runtime.CompilerServices

Public Module Directions
    Friend Const North = "north"
    Friend Const East = "east"
    Friend Const South = "south"
    Friend Const West = "west"
    Friend Const Inward = "in"
    Friend Const Outward = "out"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, DirectionDescriptor) =
        New Dictionary(Of String, DirectionDescriptor) From
        {
            {North, New DirectionDescriptor("North", South, 0, -1)},
            {East, New DirectionDescriptor("East", West, 1, 0)},
            {South, New DirectionDescriptor("South", North, 0, 1)},
            {West, New DirectionDescriptor("West", East, -1, 0)},
            {Inward, New DirectionDescriptor("In", Outward, Nothing, Nothing)},
            {Outward, New DirectionDescriptor("Out", Inward, Nothing, Nothing)}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    Friend ReadOnly Property AllCardinal As IEnumerable(Of String)
        Get
            Return All.Where(Function(x) x.ToDirectionDescriptor.DeltaX.HasValue)
        End Get
    End Property
    <Extension>
    Public Function ToDirectionDescriptor(direction As String) As DirectionDescriptor
        Return Descriptors(direction)
    End Function
End Module
