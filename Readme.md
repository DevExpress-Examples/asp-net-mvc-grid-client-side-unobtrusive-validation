<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550219/19.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4924)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Grid View for ASP.NET MVC - How to implement client-side unobtrusive validation using a custom attribute

Follow the steps below to implement unobtrusive client-side validation:

1. Create a [ValidationAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute) class descendant.
2. Implement the [IClientValidatable](https://learn.microsoft.com/en-us/dotnet/api/system.web.mvc.iclientvalidatable) interface for this class to enable client validation.
3. Write a custom adapter based on custom parameters that are passed from the server.
4. Add a custom validation method.

Wrap the [Grid View](https://docs.devexpress.com/AspNetMvc/8966/components/grid-view) extension in a `<form>` element that can be rendered with `Html.BeginForm()﻿`. Validation scripts will be automatically registered on a callback.

```cs
@using (Html.BeginForm("Index", "Home", FormMethod.Post, new { id = "frm" })) {
    @Html.Action("GridViewPartial")
}
```

## Files to Review

* [HomeController.cs](./CS/E4924/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/E4924/Controllers/HomeController.vb))
* [CustomAttribute.cs](./CS/E4924/Models/CustomAttribute.cs) (VB: [CustomAttribute.vb](./VB/E4924/Models/CustomAttribute.vb))
* [Person.cs](./CS/E4924/Models/Person.cs) (VB: [Person.vb](./VB/E4924/Models/Person.vb))
* [_GridViewPartial.cshtml](./CS/E4924/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/E4924/Views/Home/Index.cshtml)

## Documentation

* [Unobtrusive Client Validation](https://docs.devexpress.com/AspNetMvc/12060/components/data-editors-extensions/common-concepts/validation/unobtrusive-client-validation)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-client-side-unobtrusive-validation&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-client-side-unobtrusive-validation&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
