Imports System.Runtime.CompilerServices

Friend Module ItemExtensions
    <Extension>
    Friend Function PickUpEnergyCost(item As IItem) As Integer
        Return item.ItemType.ToItemTypeDescriptor.PickUpEnergyCost
    End Function
End Module
