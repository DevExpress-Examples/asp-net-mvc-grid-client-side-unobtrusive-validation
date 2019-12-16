Imports System.ComponentModel.DataAnnotations

Public Class CustomAttribute
    Inherits ValidationAttribute
    Implements IClientValidatable

    Public Property MinAge As Integer

    Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
        Dim p As Person = TryCast(validationContext.ObjectInstance, Person)
        If p Is Nothing Then Return New ValidationResult("Internal  error")
        If Not p.CheckAge Then Return ValidationResult.Success
        Dim ts As TimeSpan = DateTime.Now - p.BirthDate

        If ts.TotalDays / 365 < MinAge Then
            Return New ValidationResult("Age must be more than " & MinAge.ToString())
        Else
            Return ValidationResult.Success
        End If
    End Function

    Public Function GetClientValidationRules(metadata As ModelMetadata, context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) Implements IClientValidatable.GetClientValidationRules
        Dim l As List(Of ModelClientValidationRule) = New List(Of ModelClientValidationRule)
        Dim s As String = "Age must be more than " & MinAge.ToString()
        Dim r As ModelClientValidationRangeDateRule = New ModelClientValidationRangeDateRule(s, MinAge)
        l.Add(r)
        Return l
    End Function

    Public Class ModelClientValidationRangeDateRule
        Inherits ModelClientValidationRule

        Public Sub New(ByVal errorMessage As String, ByVal minAge As Integer)
            Me.ErrorMessage = errorMessage
            Me.ValidationType = "rangedate"
            Me.ValidationParameters("minage") = minAge
        End Sub
    End Class
End Class
