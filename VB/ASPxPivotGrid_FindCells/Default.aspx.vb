Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Web.UI
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid

Namespace ASPxPivotGrid_FindCells
	Partial Public Class _Default
		Inherits Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsCallback) AndAlso (Not IsPostBack) Then
				PivotHelper.FillPivot(pivotGrid)
			End If
			pivotGrid.DataSource = PivotHelper.GetDataTable()
		End Sub

		' Handles the CustomFieldValueCells event to remove columns with
		' zero summary values.
        Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, _
                                                      ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGrid.DataSource Is Nothing Then
                Return
            End If
            If radioButtonList.SelectedIndex = 0 Then
                Return
            End If

            ' Obtains the first encountered column header whose column
            ' matches the specified condition, represented by a predicate.
            Dim cell As FieldValueCell = _
                e.FindCell(True, New Predicate(Of Object())(AddressOf AnonymousMethod1))

            ' If any column header matches the condition, this column is removed.
            If cell IsNot Nothing Then
                e.Remove(cell)
            End If
        End Sub

        ' Defines the predicate returning true for columns
        ' that contain only zero summary values.
        Private Function AnonymousMethod1(ByVal dataCellValues() As Object) As Boolean
            For Each value As Object In dataCellValues
                If (Not Object.Equals(CDec(0), value)) Then
                    Return False
                End If
            Next value
            Return True
        End Function
        Protected Sub pivotGrid_FieldValueDisplayText(ByVal sender As Object, _
                                                      ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Field Is pivotGrid.Fields(PivotHelper.Month) Then
                e.DisplayText = _
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
            End If
        End Sub
    End Class
End Namespace
