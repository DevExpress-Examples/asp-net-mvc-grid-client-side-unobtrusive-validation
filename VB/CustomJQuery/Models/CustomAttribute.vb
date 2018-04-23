Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace CustomJQuery.Models
    Public Class CustomAttribute
        Inherits ValidationAttribute
        Implements IClientValidatable
        ' Fields...
        Private _MinDate As Integer
        Public Property MinDate() As Integer
            Get
                Return _MinDate
            End Get
            Set(ByVal value As Integer)
                _MinDate = value
            End Set
        End Property
        Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
            Dim p As Person = TryCast(validationContext.ObjectInstance, Person)
            If p Is Nothing Then
                Return New ValidationResult("Internal  error")
            End If
            If (Not p.CheckAge) Then
                Return ValidationResult.Success
            End If
            Dim ts As TimeSpan = DateTime.Now - p.BirthDate
            If ts.TotalDays / 365 < MinDate Then
                Return New ValidationResult("Age must be more than " & MinDate.ToString())
            Else
                Return ValidationResult.Success
            End If
        End Function
        Public Function GetClientValidationRules(ByVal metadata As ModelMetadata, ByVal context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) Implements IClientValidatable.GetClientValidationRules
            Dim l As List(Of ModelClientValidationRangeDateRule) = New List(Of ModelClientValidationRangeDateRule)()
            Dim s As String = "Age must be more than " & MinDate.ToString()
            l.Add(New ModelClientValidationRangeDateRule("somemessage", MinDate))
            Return l
        End Function
        Public Class ModelClientValidationRangeDateRule
            Inherits ModelClientValidationRule
            Public Sub New(ByVal errorMessage As String, ByVal minDate As Integer)
                errorMessage = errorMessage
                ValidationType = "rangedate"
                ValidationParameters("mindate") = minDate
            End Sub
        End Class
    End Class
End Namespace
