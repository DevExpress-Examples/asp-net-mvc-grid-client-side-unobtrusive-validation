Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Mvc
Imports CustomJQuery.Models

Namespace CustomJQuery.Controllers

    Public Class HomeController
        Inherits Controller

        '
        ' GET: /Home/
        Public Function Index() As ActionResult
            Return View()
        End Function

        Private Property Persons As IList(Of Person)
            Get
                If HttpContext.Session("list") Is Nothing Then
                    Dim lPersons As List(Of Person) = New List(Of Person)()
                    For i As Integer = 0 To 20 - 1
                        lPersons.Add(New Person() With {.ID = i, .Name = String.Format("PersonName {0}", i), .CheckAge = i Mod 2 = 0, .CompanyName = "Company" & i, .BirthDate = New DateTime(1990, 6, 1)})
                    Next

                    HttpContext.Session("list") = lPersons
                End If

                Return CType(HttpContext.Session("list"), IList(Of Person))
            End Get

            Set(ByVal value As IList(Of Person))
                HttpContext.Session("list") = value
            End Set
        End Property

        <ValidateInput(False)>
        Public Function GridViewPartial() As ActionResult
            Dim model = Persons
            Return PartialView("_GridViewPartial", model)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialAddNew(ByVal item As Person) As ActionResult
            Dim model = Persons
            If ModelState.IsValid Then
                Try
                    ' Insert here a code to insert the new item in your model
                    Persons.Add(item)
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If

            Return PartialView("_GridViewPartial", model)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialUpdate(ByVal item As Person) As ActionResult
            Dim model = Persons
            If ModelState.IsValid Then
                Try
                    ' Insert here a code to update the item in your model
                    Dim p As Person = model.Where(Function(x) x.ID = item.ID).First()
                    p.Name = item.Name
                    p.CompanyName = item.CompanyName
                    p.BirthDate = item.BirthDate
                    p.CheckAge = item.CheckAge
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            Else
                ViewData("EditError") = "Please, correct all errors."
            End If

            Return PartialView("_GridViewPartial", model)
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function GridViewPartialDelete(ByVal ID As Integer) As ActionResult
            Dim model = Persons
            If ID IsNot Nothing Then
                Try
                    ' Insert here a code to delete the item from your model
                    Persons.Remove(Persons.First(Of Person)(Function(x) x.ID = ID))
                Catch e As Exception
                    ViewData("EditError") = e.Message
                End Try
            End If

            Return PartialView("_GridViewPartial", model)
        End Function
    End Class
End Namespace
