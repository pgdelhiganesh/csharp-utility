
dataGridView1.Columns.Add("newColumnName", "Column Name in Text");
To add rows

dataGridView1.Rows.Add("Value for column#1"); // [,"column 2",...]

var index = dgv.Rows.Add();
dgv.Rows[index].Cells["Column1"].Value = "Column1";
dgv.Rows[index].Cells["Column2"].Value = 5.6;

// Add checkbox column ---------------------------------------------------------
DataGridViewCheckBoxColumndgvCmb = new DataGridViewCheckBoxColumn();  
dgvCmb.ValueType = typeof(bool);  
dgvCmb.Name = "Chk";  
dgvCmb.HeaderText = "CheckBox";  
DataGGridView1.Columns.Add(dgvCmb); 

DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
checkColumn.Name = "X";
checkColumn.HeaderText = "X";
checkColumn.Width = 50;
checkColumn.ReadOnly = false;
checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
dataGridView1.Columns.Add(checkColumn);

DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
... // set properties as needed here
dataGridView1.Columns.Add(col);

officeCheckBoxColumn.TrueValue = 1;
officeCheckBoxColumn.FalseValue = 0;
// ----------------------------------------------------------------------------------------------- 
// DataFGrdiVew Column Searech
This will give you the gridview row index for the value:

String searchValue = "somestring";
int rowIndex = -1;
foreach(DataGridViewRow row in DataGridView1.Rows)
{
    if(row.Cells[1].Value.ToString().Equals(searchValue))
    {
        rowIndex = row.Index;
        break;
    }
}
Or a LINQ query

int rowIndex = -1;

        DataGridViewRow row = dgv.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["SystemId"].Value.ToString().Equals(searchValue))
            .First();

        rowIndex = row.Index;
then you can do:

dataGridView1.Rows[rowIndex].Selected = true;


myvalue =dgvList.Rows[rowindex].Cells[columnindex].Value.ToString();
// ----------------------------------------------------------------------------------------------- 
foreach (DataGridViewRow row in datagridviews.Rows)
{
   currQty += row.Cells["qty"].Value;
   //More code here
}

// ----------------------------------------------------------------------------------------------- 
// ----------------------------------------------------------------------------------------------- 
// 

