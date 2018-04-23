@Code
    ViewBag.Title = "Index"
End Code

<h2>This project demonstrates a custom client side age validation based on a custom attribute. Note, client side Validation is performed if checkbox is checked</h2>
<script type="text/javascript">
 
    $(function () {     
        // Registering  custom adapter
        $.validator.unobtrusive.adapters.add('rangedate', ['mindate'],
            function (options) {
                debugger;
                var params = {
                    minDate: options.params.mindate,                   
                };
                options.rules['rangeDate'] = params;
                if (options.message) {
                    options.messages['rangeDate'] = options.message;
                }
            });
        // Add validator function
        $.validator.addMethod('rangeDate',
            function (value, element, param) {
                if (!grid.GetEditor("CheckAge").GetChecked()) {
                    return true;
                }
                else {
                    var msecPerYear = 1000 * 60 * 60 * 24 * 365;
                    var BirthDate = grid.GetEditor("BirthDate");
                    var years = (Date.now() - BirthDate.GetValue().getTime()) / msecPerYear;
                    if (years < parseInt(param.minDate, 10))
                        return false;
                    else
                        return true;
                }
            }
        );
    });
</script>
@Using (Html.BeginForm("Index", "Home", FormMethod.Post, new with { .id = "frm" })) 
    @Html.Action("GridViewPartial")
End Using
