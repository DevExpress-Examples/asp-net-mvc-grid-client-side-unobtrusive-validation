@ModelType IList(Of CustomJQuery.Models.Person)
@Code
    Dim grid = Html.DevExpress().GridView(Sub(settings)
    
        settings.Name = "grid"
        settings.CallbackRouteValues = new With { .Controller = "Home", .Action = "GridViewPartial" }

        settings.SettingsEditing.AddNewRowRouteValues = new With { .Controller = "Home", .Action = "GridViewPartialAddNew" }
        settings.SettingsEditing.UpdateRowRouteValues = new With { .Controller = "Home", .Action = "GridViewPartialUpdate" }
        settings.SettingsEditing.DeleteRowRouteValues = new With { .Controller = "Home", .Action = "GridViewPartialDelete" }
        settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow


        settings.SettingsEditing.ShowModelErrorsForEditors = true
        settings.SettingsBehavior.ConfirmDelete = true

        settings.CommandColumn.Visible = true
        settings.CommandColumn.ShowNewButton = true
        settings.CommandColumn.ShowDeleteButton = true
        settings.CommandColumn.ShowEditButton = true
        settings.KeyFieldName = "ID"
        settings.SettingsPager.Visible = true
        settings.Settings.ShowGroupPanel = true
        settings.Settings.ShowFilterRow = false
        settings.SettingsBehavior.AllowSelectByRowClick = false
        settings.Columns.Add("ID")
        settings.Columns.Add("Name")
        settings.Columns.Add("CompanyName")
        settings.Columns.Add(Sub(col)
            col.FieldName = "BirthDate"
            col.ColumnType = MVCxGridViewColumnType.DateEdit
        End Sub)
        settings.Columns.Add(Sub(col)
            col.FieldName = "CheckAge"
            col.ColumnType = MVCxGridViewColumnType.CheckBox
        End Sub)
        settings.CellEditorInitialize = Sub (s, e) 
            CType(e.Editor, ASPxEdit).ValidationSettings.Display = Display.Dynamic
        End Sub
     
    End Sub)
    If ViewData("EditError") IsNot Nothing Then
		grid.SetEditErrorText(CStr(ViewData("EditError")))
 End If
End  Code
@grid.Bind(Model).GetHtml()