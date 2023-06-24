Imports System.Runtime.CompilerServices

Public Module VerbTypes
    Friend Const Eat = "Eat"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, VerbTypeDescriptor) =
        New Dictionary(Of String, VerbTypeDescriptor) From
        {
            {
                VerbTypes.Eat,
                New VerbTypeDescriptor("Eat")
            }
        }
    <Extension>
    Public Function ToVerbTypeDescriptor(verbType As String) As VerbTypeDescriptor
        Return Descriptors(verbType)
    End Function
End Module
