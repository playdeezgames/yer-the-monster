Imports System.Runtime.CompilerServices

Public Module ItemExtensions
    <Extension>
    Friend Function PickUpEnergyCost(item As IItem) As Integer
        Return item.ItemType.ToItemTypeDescriptor.PickUpEnergyCost
    End Function
    <Extension>
    Public Function AvailableVerbs(item As IItem) As IEnumerable(Of String)
        Return item.ItemType.ToItemTypeDescriptor.Verbs.Keys
    End Function
End Module
