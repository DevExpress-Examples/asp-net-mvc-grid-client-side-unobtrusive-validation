@ModelType IList(Of E4924.Person)
@Imports DevExpress.Web.ASPxEditors
@Imports Devexpress.Web.ASPxGridView
@Code
    Dim grid = Html.DevExpress().GridView(Sub(settings)

                                              settings.Name = "grid"
                                              settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

                                              settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialAddNew"}
                                              settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialUpdate"}
                                              settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialDelete"}
                                              settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow

                                              settings.SettingsEditing.ShowModelErrorsForEditors = True
                                              settings.SettingsBehavior.ConfirmDelete = True

                                              settings.CommandColumn.Visible = True
                                              settings.CommandColumn.ShowNewButton = True
                                              settings.CommandColumn.ShowDeleteButton = True
                                              settings.CommandColumn.ShowEditButton = True
                                              settings.KeyFieldName = "ID"
                                              settings.SettingsPager.Visible = True
                                              settings.Settings.ShowGroupPanel = True
                                              settings.Settings.ShowFilterRow = False
                                              settings.SettingsBehavior.AllowSelectByRowClick = False
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
                                              settings.CellEditorInitialize = Sub(s, e)
                                                                                  Dim editor = CType(e.Editor, ASPxEdit)
                                                                                  editor.ValidationSettings.Display = Display.Dynamic
                                                                                  editor.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText
                                                                              End Sub

                                          End Sub)
    If ViewData("EditError") IsNot Nothing Then
        grid.SetEditErrorText(CStr(ViewData("EditError")))
    End If
End  Code
@grid.Bind(Model).GetHtml()
