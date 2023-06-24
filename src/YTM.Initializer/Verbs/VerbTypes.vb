Imports System.Runtime.CompilerServices

Public Module VerbTypes
    Friend Const Eat = "Eat"
    Friend Const Drop = "Drop"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, VerbTypeDescriptor) =
        New Dictionary(Of String, VerbTypeDescriptor) From
        {
            {
                VerbTypes.Eat,
                New VerbTypeDescriptor("Eat")
            },
            {
                VerbTypes.Drop,
                New VerbTypeDescriptor("Drop")
            }
        }
    <Extension>
    Public Function ToVerbTypeDescriptor(verbType As String) As VerbTypeDescriptor
        Return Descriptors(verbType)
    End Function
End Module
