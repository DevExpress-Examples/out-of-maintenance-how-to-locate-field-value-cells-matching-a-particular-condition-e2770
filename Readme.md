# How to locate field value cells matching a particular condition


<p>The following example demonstrates how to handle the CustomFieldValueCells event to locate a specific column/row header identified by its column's/row's summary values.<br />
In this example, a predicate is used to locate a column that contains only zero summary values. The column header is obtained by the event parameter's FindCell method, and then removed via the Remove method.</p>

<br/>


