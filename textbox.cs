// decimal with one '.'
private void TbPrice_KeyPress(object sender, KeyPressEventArgs e)
{
	if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
	{
		e.Handled = true;
	}
	// only allow one decimal point
	if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
	{
		e.Handled = true;
	}
}

// only numerical
private void TbPrice_KeyPress(object sender, KeyPressEventArgs e)
{
	if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
	{
		e.Handled = true;
	}
}

private void txtbox_KeyDown(object sender, KeyEventArgs e)
{
	if (e.KeyCode == Keys.Enter)
	{
		txtbox2.Focus();
	}
}


tb_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
tb_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();

DataTable dtcode = dbFunctions.getTable("select SM_Name from Supplier_Master where SM_Status='A'");
for (int i = 0; i < dtcode.Rows.Count; i++)
{
     strcoll.Add(dtcode.Rows[i]["SM_Name"].ToString());
}
tb_name.AutoCompleteCustomSource = strcoll;
