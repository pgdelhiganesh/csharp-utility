// Set cursor as hourglass
Cursor.Current = Cursors.WaitCursor;

// Execute your time-intensive hashing code here...

// Set cursor as default arrow
Cursor.Current = Cursors.Default;

System.Diagnostics.Process.Start("IExplore", "http://www.google.com/");

// ------------------------------------------------------------------------

private void addFile_FormClosing( object sender, FormClosingEventArgs e ) {
    var closeMsg = MessageBox.Show( "Do you really want to close?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

    if (closeMsg == DialogResult.Yes) {
        // do nothing
    } else {
        e.Cancel = true;
    }
}

// ------------------------------------------------------------------------

DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
if(dialogResult == DialogResult.Yes)
{
    //do something
}
else if (dialogResult == DialogResult.No)
{
    //do something else
}

// ------------------------------------------------------------------------

void Rate_Calc()
{
	try
	{
		INV_Discount_Amount.Text = ((decimal.Parse(INV_Rate.Text) / 100) * decimal.Parse(INV_Discount_Percentage.Text)).ToString("0.00");
		decimal Unitprice = decimal.Parse(INV_Rate.Text) - decimal.Parse(INV_Discount_Amount.Text);
		INV_Net_Amount.Text = (decimal.Parse(INV_Qty.Text) * Unitprice).ToString();
	}
	catch { }
}

// ------------------------------------------------------------------------

        string file_path_excel = "";
        string file_name_excel = "";
        FileInfo fileInfo_excel;


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            openFileDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx;*.xls|All Files(*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                dgv.Rows.Clear();
                dgv.ClearSelection();
                dgv.Refresh();

                file_path_excel = openFileDialog.FileName; // with path info + file name
                tbExcelPath.Text = file_path_excel;
                file_name_excel = openFileDialog.SafeFileName; // without path info
                fileInfo_excel = new FileInfo(openFileDialog.FileName);
                file_name_excel = file_name_excel.Replace(fileInfo_excel.Extension, string.Empty);
            }
        }

// ------------------------------------------------------------------------
// ------------------------------------------------------------------------
// ------------------------------------------------------------------------
// ------------------------------------------------------------------------

