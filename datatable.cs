DataTable dtTable;

MySQLProcessor.DTTable(mysqlCommand, out dtTable);

// On all tables' rows
foreach (DataRow dtRow in dtTable.Rows)
{
    // On all tables' columns
    foreach(DataColumn dc in dtTable.Columns)
    {
      var field1 = dtRow[dc].ToString();
    }
}

// ----------------------------------------------------------------------------------------------- 
DataTable dt = new DataTable();
 
//Add columns to DataTable.
dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
 
//Set the Default Value.
dt.Columns["Id"].DefaultValue = 0;
 
//Add rows to DataTable.
dt.Rows.Add(null, "John Hammond", "United States");
dt.Rows.Add(1, "Mudassar Khan", "India");
dt.Rows.Add(null, "Suzanne Mathews", "France");
dt.Rows.Add(3, "Robert Schidner", "Russia");
// ----------------------------------------------------------------------------------------------- 
string Text = dataTable.Rows[0]["ColumnName"].ToString();

This is attempting to index the row itself:

row["ColumnName"].ToString()
What you're looking for is to index the items within the row:

row.Item["ColumnName"].ToString()
when DataTable holds a single row, without iteration

If you're guaranteed that there is a row, you can reference it directly:

dt.Rows[0].Item["ColumnName"].ToString()
As with any indexing, you should probably do some bounds checking before trying to index it though.
