using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AML_Find
{
    public partial class Vehicle_Entry : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=DEV-001\\SQLEXPRESS;Initial Catalog=AMLCARDATA;Integrated Security=True");
        SqlConnection conn = new SqlConnection("Data Source=SQL5041,1433;Initial Catalog=DB_A4A319_AMLCARDATA;User Id=DB_A4A319_AMLCARDATA_admin;Password=Innocent8#;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Disable Update & Delete Buttons
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    txtvehcode.Enabled = false;
                    //--------------------------------------------------------------------------------
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT [VEHMKE] FROM [AMLCARMDLS]", conn);
                    conn.Open();
                    txtvehmke.DataSource = cmd.ExecuteReader();
                    txtvehmke.TextField = "VEHMKE";
                    //txtvehmke.ValueField = "VMDL_ID";
                    txtvehmke.DataBind();

                }
                catch (Exception ex)
                {
                    lblerr.Text = ex.Message;
                }
            }

        }

        //SQL: INSERT NEW RECORD:
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [dbo].[AMLCARDTLS] VALUES('" + txtprefix.Text + "','" + txtvehmke.Text + "','" + txtvehmdl.Text + "','" + txtvehyear.Text + "', '"+ txtclrprice.Text +"')";
                cmd.ExecuteNonQuery();
                conn.Close();
                lblerr.Text = "Entry Successfull!";
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }
        }

        
        protected void txtvehmke_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblerr.Text = "Hello World!";
            //lblerr.Text = "Test Test!";
            if (txtvehmke.SelectedItem != null)
            {
                try
                {
                    txtvehmdl.Text = "";
                    SqlCommand cmd = new SqlCommand("SELECT [VEHMDL] FROM [dbo].[AMLCARMDLS] WHERE [VEHMKE] = '" + txtvehmke.Text + "'", conn);
                    conn.Open();
                    txtvehmdl.DataSource = cmd.ExecuteReader();
                    //txtvehmdl.TextField = "VEHMDL";
                    //txtvehmke.ValueField = "VMDL_ID";
                    txtvehmdl.DataBind();
                    //lblerr.Text = "Working!";
                }
                catch (Exception ex)
                {
                    lblerr.Text = ex.Message;
                }
            }
        }

        //Search AMLCARDTLS:
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtvehcode.Enabled == false)
                {
                    txtvehcode.Enabled = true;
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    //------------------------
                    txtvehmdl.Text = "";
                    txtvehmke.Text = "";
                    txtvehyear.Text = "";
                    txtclrprice.Text = "";
                    lblerr.Text = "";

                }
                else if (txtvehcode.Text == "")
                {
                    lblerr.Text = "Enter Vehicle Code!";
                }
                else
                {
                    SqlCommand command;
                    string sql = "SELECT VEH_MKE, VEH_MDL, MAN_YR, CLR_PRI FROM AMLCARDTLS WHERE VEH_CODE='" + txtvehcode.Text + "'";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        command = new SqlCommand(sql, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            txtvehmke.Text = reader[0].ToString(); //Vehicle Make
                            txtvehmdl.Text = reader[1].ToString(); //Vehicle Model
                            txtvehyear.Text = reader[2].ToString(); //Manufacture Year
                            txtclrprice.Text = reader[3].ToString(); //Clearing Price
                            //----------Disable Inputs for Make, Model & Year------------
                            txtvehmke.Enabled = false;
                            txtvehmdl.Enabled = false;
                            txtvehyear.Enabled = false;
                        }
                        else
                        {
                            //MessageBox.Show("User does not exist!");
                            lblerr.Text = "Vehicle not available!";
                        }
                        conn.Close();

                    }
                }
            }
            catch(Exception ex)
            {
                lblerr.Text = ex.Message;
            }
        }

        //Cancel Entry:
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtvehcode.Enabled == true)
                {
                    //Clear Form:
                    txtvehcode.Text = "";
                    txtvehmdl.Text = "";
                    txtvehmke.Text = "";
                    txtvehyear.Text = "";
                    txtclrprice.Text = "";
                    lblerr.Text = "";
                    //----------------------
                    //Enable/Disable Buttons:
                    txtvehcode.Enabled = false;
                    txtvehmke.Enabled = true;
                    txtvehmdl.Enabled = true;
                    txtvehyear.Enabled = true;
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    //txtvehcode.Text = "";
                    txtvehmdl.Text = "";
                    txtvehmke.Text = "";
                    txtvehyear.Text = "";
                    txtclrprice.Text = "";
                    lblerr.Text = "";
                }
            }
            catch(Exception ex)
            {
                lblerr.Text = ex.Message;
            }
        }

        //UPDATE VEHICLE RECORDS:
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                conn.Open(); //Open Connection to SQL Server DB...AMLCARADATA...
                command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE [dbo].[AMLCARDTLS] SET VEH_MKE='" + txtvehmke.Text + "', VEH_MDL='"+txtvehmdl.Text+"', MAN_YR='"+txtvehyear.Text+"', CLR_PRI='"+txtclrprice.Text+"' where VEH_CODE='" + txtvehcode.Text + "'";
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                lblerr.Text = ex.Message;
                lblerr.BackColor = System.Drawing.Color.Red;
            }
        }

        //DELETE VEHICLE RECORDS:
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        //Populate Vehicle Model based on vehicle make selection:



    }
}