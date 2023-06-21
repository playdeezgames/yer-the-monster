﻿Public Class CharacterData
    Public Property CharacterType As String
    Public Property Name As String
    Public Property Recycled As Boolean
    Public Property LocationId As Integer
    Public Property ItemIds As New HashSet(Of Integer)
    Public Property Statistics As New Dictionary(Of String, Integer)
    Public Property MapName As String
    Public Property Column As Integer
    Public Property Row As Integer
End Class
