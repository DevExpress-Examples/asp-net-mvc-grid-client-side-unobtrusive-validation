Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace CustomJQuery.Models
	Public Class Person
		' Fields...
		Private _CheckAge As Boolean
		Private _BirthDate As DateTime
		Private _CompanyName As String
		Private _Name As String
		Private _ID As Integer
		<Required> _
		Public Property ID() As Integer
			Get
				Return _ID
			End Get
			Set(ByVal value As Integer)
				_ID = value
			End Set
		End Property
		<Required> _
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				_Name = value
			End Set
		End Property

		Public Property CompanyName() As String
			Get
				Return _CompanyName
			End Get
			Set(ByVal value As String)
				_CompanyName = value
			End Set
		End Property
		<CustomAttribute(MinDate:=20)> _
		Public Property BirthDate() As DateTime
			Get
				Return _BirthDate
			End Get
			Set(ByVal value As DateTime)
				_BirthDate = value
			End Set
		End Property

		Public Property CheckAge() As Boolean
			Get
				Return _CheckAge
			End Get
			Set(ByVal value As Boolean)
				_CheckAge = value
			End Set
		End Property
	End Class
End Namespace