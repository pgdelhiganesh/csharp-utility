private void chbx_CheckedChanged(object sender, EventArgs e)
{
	CheckBox currentchbx = (CheckBox)sender;
	//MessageBox.Show(currentchbx.Tag.ToString());
	if (currentchbx.Checked == true)
	{
		currentchbx.ForeColor = Color.DarkBlue;
		currentchbx.BackColor = Color.White;
	}

	if (currentchbx.Checked == false)
	{
		currentchbx.ForeColor = Color.Black;
		currentchbx.BackColor = Color.LightGray;
	}
}

// --------------------------------------------------------------------------------

private void chbx_selectall_CheckedChanged(object sender, EventArgs e)
{
	foreach (Control ctrl in flowLayoutPanel.Controls)
	{
		CheckBox chbx = ctrl as CheckBox;
		if (chbx != null)
		{
			if (chbx_selectall.Checked == false)
			{
				chbx.Checked = false;
			}
			else
			{
				chbx.Checked = true;
			}
		}
	}
}

// --------------------------------------------------------------------------------

private void CbProductName_SelectedValueChanged(object sender, EventArgs e)
{
	string id = CbProductName.SelectedValue.ToString();
	string str_tmp_query = ""; DataTable dt = null;
	str_tmp_query = "SELECT * FROM `product_master` WHERE Product_Master_ID = "+id+" ORDER BY Product_Name;";
	dt = ClsDbFunctions.GetTable(str_tmp_query);
	if (dt.Rows.Count > 0)
	{
		TbProductCode.Text = dt.Rows[0]["Product_Code"].ToString();
		TbLowLimit.Text = dt.Rows[0]["Low_Limit"].ToString();
		TbHighLimit.Text = dt.Rows[0]["High_Limit"].ToString();
		TbUOM.Text = dt.Rows[0]["uom"].ToString();
	}
}

private void IN_Customer_ID_SelectedIndexChanged(object sender, EventArgs e)
{
	if (isCusomer_Load)
	{
		try
		{
			DataTable dt = dbFunctions.getTable("Pr_Fetch_Customer_Master_ByID  " + IN_Customer_ID.SelectedValue);
			if (dt.Rows.Count > 0)
			{
				IN_Customer_Address.Text = dt.Rows[0]["CM_BillingAddress"].ToString();
				IN_Customer_State.Text = dt.Rows[0]["CM_TIN_No"].ToString();
				IN_Customer_State_Code.Text = dt.Rows[0]["CM_ECC_No"].ToString();
				IN_Customer_GST_No.Text = dt.Rows[0]["CM_GSTProvisonalID"].ToString();
				GST = decimal.Parse(dt.Rows[0]["IM_GST_Percentage"].ToString());
			}
		}
		catch { }
	}
}


private void cbPartNumber_SelectedIndexChanged(object sender, EventArgs e)
{
	if (form_load_complted == true)
	{
		string tmp_part_no = cbPartNumber.Text.Trim();
		string str_tmp_query = "EXEC Pr_Fetch_Part_Details '" + tmp_part_no + "'";
		DataTable dt = new DataTable();
		dt = ClsDbFunctions.GetTable(str_tmp_query);
		if (dt.Rows.Count > 0)
		{
			if (dt.Rows[0][0].ToString() != "")
			{
				str_part_number = dt.Rows[0][0].ToString();

				if (dt.Rows[0][1].ToString() != "")
				{ int_part_qty = Convert.ToInt32(dt.Rows[0][1].ToString()); }
				else
				{ int_part_qty = 0; }

				if (dt.Rows[0][2].ToString() != "")
				{ double_part_unit_weight = Convert.ToDouble(dt.Rows[0][2].ToString()); }
				else
				{ double_part_unit_weight = 0; }

				if (dt.Rows[0][3].ToString() != "")
				{ str_part_location_code = dt.Rows[0][3].ToString(); }
				else
				{ str_part_location_code = ""; }

				if (dt.Rows[0][4].ToString() != "")
				{ str_part_location_name = dt.Rows[0][4].ToString(); }
				else
				{ str_part_location_name = ""; }

				if (dt.Rows[0][5].ToString() != "")
				{ str_part_location_syntax = dt.Rows[0][5].ToString(); }
				else
				{ str_part_location_syntax = ""; }

				cbPartNumber.Text = str_part_number;
				tbPartQty.Text = int_part_qty.ToString();
				tbLocationName.Text = str_part_location_name;
				tbLocationSyntax.Text = str_part_location_syntax;
				tbPartWeight.Text = double_part_unit_weight.ToString();

				tbTotalQty.Focus();
			}
			else
			{
				cbPartNumber.Text = "";
				tbPartQty.Text = "0";
				tbLocationName.Text = "";
				tbLocationSyntax.Text = "";
				tbPartWeight.Text = "0.000";

				str_part_number = ""; int_part_qty = 0; double_part_unit_weight = 0;
				str_part_location_code = ""; str_part_location_name = ""; str_part_location_syntax = "";

				cbPartNumber.Text = "Please Update Product Master.";
				cbPartNumber.ForeColor = Color.White;
				cbPartNumber.BackColor = Color.Red; cbPartNumber.Update(); System.Threading.Thread.Sleep(3000);
				cbPartNumber.BackColor = Color.White; cbPartNumber.Update(); System.Threading.Thread.Sleep(100);
				cbPartNumber.ForeColor = Color.Black; cbPartNumber.Text = "";
			}
		}
		else
		{
			cbPartNumber.Text = "";
			tbPartQty.Text = "0";
			tbLocationName.Text = "";
			tbLocationSyntax.Text = "";
			tbPartWeight.Text = "0.000";

			str_part_number = ""; int_part_qty = 0; double_part_unit_weight = 0;
			str_part_location_code = ""; str_part_location_name = ""; str_part_location_syntax = "";

			cbPartNumber.Text = "Please Update Product Master.";
			cbPartNumber.ForeColor = Color.White;
			cbPartNumber.BackColor = Color.Red; cbPartNumber.Update(); System.Threading.Thread.Sleep(3000);
			cbPartNumber.BackColor = Color.White; cbPartNumber.Update(); System.Threading.Thread.Sleep(100);
			cbPartNumber.ForeColor = Color.Black; cbPartNumber.Text = "";
		}
		tbTotalQty_TextChanged(0, System.EventArgs.Empty);
	}
}

