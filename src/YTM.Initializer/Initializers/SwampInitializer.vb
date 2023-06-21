Friend Module SwampInitializer
    Const SwampColumns = 8
    Const SwampRows = 8
    Friend Sub Initialize(world As IWorld)
        Dim mapDescriptor = MapNames.Swamp.ToMapDescriptor
        Dim swampMap = world.CreateMap(MapNames.Swamp, "The Swamp", MapDescriptor.Columns, MapDescriptor.Rows, MapDescriptor.DefaultTerrain)
        Dim locations(SwampColumns - 1, SwampRows - 1) As ILocation
        For column = 0 To SwampColumns - 1
            For row = 0 To SwampRows - 1
                locations(column, row) = world.CreateLocation(LocationTypes.Swamp, $"Swamp {column + 1}-{row + 1}")
            Next
        Next
        Dim allCardinal = Directions.AllCardinal
        For column = 0 To SwampColumns - 1
            For row = 0 To SwampRows - 1
                Dim location = locations(column, row)
                For Each direction In allCardinal
                    Dim descriptor = direction.ToDirectionDescriptor
                    Dim nextColumn = column + descriptor.DeltaX.Value
                    Dim nextRow = row + descriptor.DeltaY.Value
                    If nextColumn >= SwampColumns Then
                        nextColumn -= SwampColumns
                    End If
                    If nextColumn < 0 Then
                        nextColumn += SwampColumns
                    End If
                    If nextRow >= SwampRows Then
                        nextRow -= SwampRows
                    End If
                    If nextRow < 0 Then
                        nextRow += SwampRows
                    End If
                    Dim nextLocation = locations(nextColumn, nextRow)
                    location.CreateRoute(direction, RouteTypes.Path, nextLocation)
                Next
            Next
        Next
    End Sub
End Module
