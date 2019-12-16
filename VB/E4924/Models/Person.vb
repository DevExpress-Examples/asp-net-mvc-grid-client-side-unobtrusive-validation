Imports System.ComponentModel.DataAnnotations

Public Class Person
    <Required>
    Public Property ID As Integer
    <Required>
    Public Property Name As String
    Public Property CompanyName As String
    <Custom(MinAge:=18)>
    Public Property BirthDate As DateTime
    Public Property CheckAge As Boolean
End Class
