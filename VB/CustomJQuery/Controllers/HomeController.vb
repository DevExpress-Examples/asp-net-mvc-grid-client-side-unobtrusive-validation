Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports CustomJQuery.Models

Namespace CustomJQuery.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function

		Private Property Persons() As IList(Of Person)
			Get
				If HttpContext.Session("list") Is Nothing Then

                    Dim _persons As New List(Of Person)()

                    For i As Integer = 0 To 19
                        _persons.Add(New Person() With {.ID = i, .Name = String.Format("PersonName {0}", i), .CheckAge = i Mod 2 = 0, .CompanyName = "Company" & i, .BirthDate = New DateTime(1990, 6, 1)})
                    Next i

                    HttpContext.Session("list") = _persons
				End If

				Return CType(HttpContext.Session("list"), IList(Of Person))
			End Get
			Set(ByVal value As IList(Of Person))
				HttpContext.Session("list") = value
			End Set
		End Property
		<ValidateInput(False)> _
		Public Function GridViewPartial() As ActionResult
			Dim model = Persons
			Return PartialView("_GridViewPartial", model)
		End Function

		<HttpPost, ValidateInput(False)> _
		Public Function GridViewPartialAddNew(ByVal item As CustomJQuery.Models.Person) As ActionResult
			Dim model = Persons
			If ModelState.IsValid Then
				Try
					Persons.Add(item)
					' Insert here a code to insert the new item in your model
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			Else
				ViewData("EditError") = "Please, correct all errors."
			End If
			Return PartialView("_GridViewPartial", model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewPartialUpdate(ByVal item As CustomJQuery.Models.Person) As ActionResult
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
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewPartialDelete(ByVal ID As System.Int32) As ActionResult
			Dim model = Persons
            Try
                ' Insert here a code to delete the item from your model
                Dim p As Person = (From x In Persons Where x.ID = ID Select x).FirstOrDefault
                Persons.Remove(p)
            Catch e As Exception
                ViewData("EditError") = e.Message
            End Try
			Return PartialView("_GridViewPartial", model)
		End Function
	End Class
End Namespace
