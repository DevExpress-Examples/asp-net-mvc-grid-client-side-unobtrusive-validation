<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>
    

    @Html.DevExpress().GetStyleSheets(
    new StyleSheet With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout },
    new StyleSheet With { .ExtensionSuite = ExtensionSuite.Editors },
    new StyleSheet With { .ExtensionSuite = ExtensionSuite.GridView }
)
    @Html.DevExpress().GetScripts(
    new Script With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout },
     new Script With { .ExtensionSuite = ExtensionSuite.Editors },
     new Script With { .ExtensionSuite = ExtensionSuite.GridView }
)
</head>

<body>
    @RenderBody()
</body>
</html>
