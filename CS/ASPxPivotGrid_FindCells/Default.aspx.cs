using System;
using System.Globalization;
using System.Web.UI;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

namespace ASPxPivotGrid_FindCells {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsCallback && !IsPostBack) {
                PivotHelper.FillPivot(pivotGrid);
            }
            pivotGrid.DataSource = PivotHelper.GetDataTable();
        }

        // Handles the CustomFieldValueCells event to remove columns with
        // zero summary values.
        protected void pivotGrid_CustomFieldValueCells(object sender,
                             PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGrid.DataSource == null) return;
            if (radioButtonList.SelectedIndex == 0) return;
            
            // Obtains the first encountered column header whose column
            // matches the specified condition, represented by a predicate.
            FieldValueCell cell = e.FindCell(true, new Predicate<object[]>(
                
                // Defines the predicate returning true for columns
                // that contain only zero summary values.
                delegate(object[] dataCellValues) {
                    foreach (object value in dataCellValues) {
                        if (!object.Equals((decimal)0, value))
                            return false;
                    }
                    return true;
            }));

            // If any column header matches the condition, this column is removed.
            if (cell != null) e.Remove(cell);
        }
        protected void pivotGrid_FieldValueDisplayText(object sender, 
                                    PivotFieldDisplayTextEventArgs e) {
            if (e.Field == pivotGrid.Fields[PivotHelper.Month]) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
    }
}
