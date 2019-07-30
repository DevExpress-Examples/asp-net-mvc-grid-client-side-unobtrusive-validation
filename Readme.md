<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/CustomJQuery/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/CustomJQuery/Controllers/HomeController.vb))
* **[CustomAttribute.cs](./CS/CustomJQuery/Models/CustomAttribute.cs) (VB: [CustomAttribute.vb](./VB/CustomJQuery/Models/CustomAttribute.vb))**
* [Person.cs](./CS/CustomJQuery/Models/Person.cs) (VB: [Person.vb](./VB/CustomJQuery/Models/Person.vb))
* [_GridViewPartial.cshtml](./CS/CustomJQuery/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/CustomJQuery/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to implement client-side unobtrusive validation using a custom attribute
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4924/)**
<!-- run online end -->


<p><strong>Updated: </strong></p>
<p>Starting with version 14.1, unobtrusive validation works for built-in EditForm out of the box (see <a href="https://www.devexpress.com/Support/Center/p/S173266">Support unobtrusive validation for the GridView's built-in edit form</a>). You need to wrap GridView in a form and validation scripts will be automatically registered on a callback.</p>


```cs
@using (Html.BeginForm("Index", "Home", FormMethod.Post, new { id = "frm" })) {
    @Html.Action("GridViewPartial")
}

```


<p><br />This example is based on the approach demonstrated in the <a href="https://www.devexpress.com/Support/Center/p/E3744">E3744: How to enable unobtrusive validation for GridView using the EditForm template</a> thread<u>.<br /> </u>Perform the following steps to accomplish this task:<br /> 1) Create a ValidationAttribute class descendant.<br /> 2) Implement the IClientValidatable interface for this class to enable client side validation.<br /> 3) Write a custom adapter based on custom parameters that are passed from the server<br /> 4) Add a custom validation method</p>
<p>Below are some threads that may be helpful in accomplishing similar tasks:<br /> <a href="http://bradwilson.typepad.com/blog/2010/10/mvc3-unobtrusive-validation.html"><u>Unobtrusive Client Validation in ASP.NET MVC 3</u></a><br /> <a href="http://samipoimala.com/it/2010/11/29/unobtrusive-client-validation-in-asp-net-mvc-3/"><u>Unobtrusive client validation</u></a><br /> <a href="http://thewayofcode.wordpress.com/2012/01/18/custom-unobtrusive-jquery-validation-with-data-annotations-in-mvc-3"><u>Custom Unobtrusive jQuery Validation with Data Annotations in MVC 3</u></a><br /> <u><a href="http://blog.tomasjansson.com/creating-custom-unobtrusive-file-extension-validation-in-asp-net-mvc-3-and-jquery">Creating custom unobtrusive file extension validation in ASP.NET MVC 3 and jQuery<br /></a><a href="https://www.devexpress.com/Support/Center/p/E4741">GridView - How to enable unobtrusive validation for inline edit form</a></u></p>

<br/>


