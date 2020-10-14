using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShinyLakesideResort
{
    public partial class Restaurant : Form
    {
        public Restaurant()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VLB16F9;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dst = new DataSet();

        double recieve, balance, tot, service, sub;
        private void cb01_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (cb01.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb01.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "01";
                        txtquantity.Text = "1";
                        string f01 = "01";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";
                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);
                        con.Close();
                        sqlda.Fill(dst);
                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }
                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }              
                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();
                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "01")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();

              
               }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res1 = MessageBox.Show("Are you sure you want to logout?", "logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res1 == DialogResult.Yes)
            {
                UserLogin uslog = new UserLogin();
                this.Hide();
                uslog.Show();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomReservationMain roomm = new RoomReservationMain();
            this.Hide();
            roomm.Show();
        }

        private void Restaurant_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");

            string billnoload = "SELECT isnull(max(cast(Bill_no as int)),0)+1 from Restaurant_Trans";
            con.Open();
            sqlda = new SqlDataAdapter(billnoload, con);
            DataTable billno = new DataTable();
            sqlda.Fill(billno);
            lblbillno.Text = billno.Rows[0][0].ToString();
            con.Close();
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb02_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                if (cb02.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb01.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "02";
                        txtquantity.Text = "1";
                        string f01 = "02";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;

                    }
                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "02")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb03_CheckedChanged(object sender, EventArgs e)
        {
            try

            {
                if (cb03.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb02.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "03";
                        txtquantity.Text = "1";
                        string f03 = "03";
                        string dis03 = "SELECT FName FROM Food_Item Where FNo='" + f03 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis03, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }
                }

                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "03")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb04_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb04.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb04.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "04";
                        txtquantity.Text = "1";
                        string f04 = "04";
                        string dis04 = "SELECT FName FROM Food_Item Where FNo='" + f04 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis04, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }
                }


                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "04")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb05_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb05.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb05.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "05";
                        txtquantity.Text = "1";
                        string f05 = "05";
                        string dis05 = "SELECT FName FROM Food_Item Where FNo='" + f05 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis05, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "05")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb06_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb06.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb06.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "06";
                        txtquantity.Text = "1";
                        string f06 = "06";
                        string dis06 = "SELECT FName FROM Food_Item Where FNo='" + f06 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis06, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "06")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb07_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb07.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb07.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "07";
                        txtquantity.Text = "1";
                        string f07 = "07";
                        string dis07 = "SELECT FName FROM Food_Item Where FNo='" + f07 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis07, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "07")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb08_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb08.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb08.Checked = false;
                    }
                    else
                    {



                        lblfno.Text = "08";
                        txtquantity.Text = "1";
                        string f08 = "08";
                        string dis08 = "SELECT FName FROM Food_Item Where FNo='" + f08 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis08, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "08")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb09_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb09.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb09.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "09";
                        txtquantity.Text = "1";
                        string f09 = "09";
                        string dis09 = "SELECT FName FROM Food_Item Where FNo='" + f09 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis09, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "09")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb10_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb10.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb10.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "10";
                        txtquantity.Text = "1";
                        string f10 = "10";
                        string dis10 = "SELECT FName FROM Food_Item Where FNo='" + f10 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis10, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "10")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb11.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb11.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "11";
                        txtquantity.Text = "1";
                        string f11 = "11";
                        string dis11 = "SELECT FName FROM Food_Item Where FNo='" + f11 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis11, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "11")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb12.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb12.Checked = false;
                    }
                    else
                    { 
                        lblfno.Text = "12";
                        txtquantity.Text = "1";
                        string f12 = "12";
                        string dis12 = "SELECT FName FROM Food_Item Where FNo='" + f12 + "'";
                        con.Open();
                        sqlda = new SqlDataAdapter(dis12, con);
                        con.Close();
                        sqlda.Fill(dst);
                        lblfno.Visible = true;
                        lblfname.Visible = true;                   
                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }            
                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();
                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "12")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb13.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                  
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb13.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "13";
                        txtquantity.Text = "1";
                        string f13 = "13";
                        string dis13 = "SELECT FName FROM Food_Item Where FNo='" + f13 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis13, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "13")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb14_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              
                if (cb14.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb14.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "14";
                        txtquantity.Text = "1";
                        string f14 = "14";
                        string dis14 = "SELECT FName FROM Food_Item Where FNo='" + f14 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis14, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "14")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
        

                if (cb15.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb15.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "15";
                        txtquantity.Text = "1";
                        string f15 = "15";
                        string dis15 = "SELECT FName FROM Food_Item Where FNo='" + f15 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis15, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "15")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb16_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb16.Checked == true)
                {
                    falseCheckSelection();
                    clear();
                  
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb16.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "16";
                        txtquantity.Text = "1";
                        string f16 = "16";
                        string dis16 = "SELECT FName FROM Food_Item Where FNo='" + f16 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis16, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "16")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb17_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb17.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb17.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "17";
                        txtquantity.Text = "1";
                        string f17 = "17";
                        string dis17 = "SELECT FName FROM Food_Item Where FNo='" + f17 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis17, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "17")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }


        private void cb18_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb18.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb18.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "18";
                        txtquantity.Text = "1";
                        string f18 = "18";
                        string dis18 = "SELECT FName FROM Food_Item Where FNo='" + f18 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis18, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "18")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb19.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb19.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "19";
                        txtquantity.Text = "1";
                        string f19 = "19";
                        string dis19 = "SELECT FName FROM Food_Item Where FNo='" + f19 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis19, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "19")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb20_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb20.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb20.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "20";
                        txtquantity.Text = "1";
                        string f20 = "20";
                        string dis20 = "SELECT FName FROM Food_Item Where FNo='" + f20 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis20, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }
                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }
                        } 
                        
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "20")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }

            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb21_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb21.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb21.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "21";
                        txtquantity.Text = "1";
                        string f21 = "21";
                        string dis21 = "SELECT FName FROM Food_Item Where FNo='" + f21 + "'";                    
                        con.Open();
                        sqlda = new SqlDataAdapter(dis21, con);
                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }
                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }
                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();
                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "21")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }                                
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb22_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb22.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb22.Checked = false;
                    }
                    else
                    {




                        lblfno.Text = "22";
                        txtquantity.Text = "1";
                        string f22 = "22";
                        string dis22 = "SELECT FName FROM Food_Item Where FNo='" + f22 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis22, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "22")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                }


                clear();
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb23_CheckedChanged(object sender, EventArgs e)
        {
            try
            {




                if (cb23.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb23.Checked = false;
                    }
                    else
                    {

                        {

                            lblfno.Text = "23";
                            txtquantity.Text = "1";
                            string f23 = "23";
                            string dis23 = "SELECT FName FROM Food_Item Where FNo='" + f23 + "'";

                            con.Open();
                            sqlda = new SqlDataAdapter(dis23, con);

                            con.Close();
                            sqlda.Fill(dst);

                            lblfno.Visible = true;
                            lblfname.Visible = true;
                        }


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    }

                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "23")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }   
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb24_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb24.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb24.Checked = false;
                    }
                    else
                    {
                        

                            lblfno.Text = "24";
                            txtquantity.Text = "1";
                            string f24 = "24";
                            string dis24 = "SELECT FName FROM Food_Item Where FNo='" + f24 + "'";

                            con.Open();
                            sqlda = new SqlDataAdapter(dis24, con);

                            con.Close();
                            sqlda.Fill(dst);

                            lblfno.Visible = true;
                            lblfname.Visible = true;
                        }


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }
                    


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "24")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }

                
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb25_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb25.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb25.Checked = false;
                    }
                    else
                    {


                       

                            lblfno.Text = "25";
                            txtquantity.Text = "1";
                            string f25 = "25";
                            string dis25 = "SELECT FName FROM Food_Item Where FNo='" + f25 + "'";

                            con.Open();
                            sqlda = new SqlDataAdapter(dis25, con);

                            con.Close();
                            sqlda.Fill(dst);

                            lblfno.Visible = true;
                            lblfname.Visible = true;
                        }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "25")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
                

            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb26_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb26.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb26.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "26";
                        txtquantity.Text = "1";
                        string f26 = "26";
                        string dis26 = "SELECT FName FROM Food_Item Where FNo='" + f26 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis26, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "26")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
                

            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb27_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb27.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb27.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "27";
                        txtquantity.Text = "1";
                        string f27 = "27";
                        string dis27 = "SELECT FName FROM Food_Item Where FNo='" + f27 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis27, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "27")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }

                
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb28_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb28.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb28.Checked = false;
                    }
                    else
                    {



                        lblfno.Text = "28";
                        txtquantity.Text = "1";
                        string f28 = "28";
                        string dis28 = "SELECT FName FROM Food_Item Where FNo='" + f28 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis28, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "28")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
                    
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb29_CheckedChanged(object sender, EventArgs e)
        {
            try
            {



                if (cb29.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb29.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "29";
                        txtquantity.Text = "1";
                        string f29 = "29";
                        string dis29 = "SELECT FName FROM Food_Item Where FNo='" + f29 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis29, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "29")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb30_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb30.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb30.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "30";
                        txtquantity.Text = "1";
                        string f30 = "30";
                        string dis30 = "SELECT FName FROM Food_Item Where FNo='" + f30 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis30, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "30")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb31_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb31.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb31.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "31";
                        txtquantity.Text = "1";
                        string f01 = "31";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "31")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();

                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void bc32_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (bc32.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        bc32.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "32";
                        txtquantity.Text = "1";
                        string f01 = "32";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "32")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();

                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb33_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb33.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb33.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "33";
                        txtquantity.Text = "1";
                        string f01 = "33";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "33")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb34_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb34.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb34.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "34";
                        txtquantity.Text = "1";
                        string f01 = "34";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "34")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb35_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb35.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb35.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "35";
                        txtquantity.Text = "1";
                        string f01 = "35";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "35")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb36_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb36.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb36.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "36";
                        txtquantity.Text = "1";
                        string f01 = "36";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "36")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb37_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb37.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb37.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "37";
                        txtquantity.Text = "1";
                        string f01 = "37";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "37")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }




        private void cb38_CheckedChanged(object sender, EventArgs e)
        
            {
                try
                {


                    if (cb38.Checked == true)
                    {
                    clear();
                    falseCheckSelection();
                        if (lblfname.Text != "" && txtquantity.Text != "")
                        {
                            MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            cb38.Checked = false;
                        }
                        else
                        {


                            lblfno.Text = "38";
                            txtquantity.Text = "1";
                            string f01 = "38";
                            string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                            con.Open();
                            sqlda = new SqlDataAdapter(dis01, con);

                            con.Close();
                            sqlda.Fill(dst);

                            lblfno.Visible = true;
                            lblfname.Visible = true;
                        }


                        foreach (DataRow dr01 in dst.Tables[0].Rows)
                        {
                            lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                        }


                    }
                    else
                    {
                        dst.Reset();
                        lblfno.Visible = false;
                        lblfname.Visible = false;
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        truecheckSection();

                        foreach (DataGridViewRow item in this.dgvBill.Rows)
                        {
                            if (item.Cells["FoodNo"].Value.ToString() == "38")
                            {
                                dgvBill.Rows.RemoveAt(item.Index);
                            }
                        }
                    clear();
                }
                }
                catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
            }
        private void cb39_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb39.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb39.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "39";
                        txtquantity.Text = "1";
                        string f01 = "39";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "39")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb40_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb40.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb40.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "40";
                        txtquantity.Text = "1";
                        string f01 = "40";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "40")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }
        private void cb41_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb41.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb41.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "41";
                        txtquantity.Text = "1";
                        string f01 = "41";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "41")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }
        private void cb42_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb42.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb42.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "42";
                        txtquantity.Text = "1";
                        string f01 = "42";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "42")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb43_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb43.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb43.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "43";
                        txtquantity.Text = "1";
                        string f01 = "43";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "43")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb44_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb44.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb44.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "44";
                        txtquantity.Text = "1";
                        string f01 = "44";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "44")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb45_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb45.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb45.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "45";
                        txtquantity.Text = "1";
                        string f01 = "45";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "45")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb46_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb46.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb46.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "46";
                        txtquantity.Text = "1";
                        string f01 = "46";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "46")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb47_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb47.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb47.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "47";
                        txtquantity.Text = "1";
                        string f01 = "47";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "47")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb48_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb48.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb48.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "48";
                        txtquantity.Text = "1";
                        string f01 = "48";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "48")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb49_CheckedChanged(object sender, EventArgs e)
        {

            try
            {


                if (cb49.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb49.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "49";
                        txtquantity.Text = "1";
                        string f01 = "49";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "49")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }


            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }

            }                       
        private void cb50_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb50.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {

                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb50.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "50";
                        txtquantity.Text = "1";
                        string f01 = "50";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "50")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb51_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb51.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb51.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "51";
                        txtquantity.Text = "1";
                        string f01 = "51";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "51")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb52_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb52.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb52.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "52";
                        txtquantity.Text = "1";
                        string f01 = "52";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "52")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb53_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb53.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb53.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "53";
                        txtquantity.Text = "1";
                        string f01 = "53";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "53")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb54_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb54.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb54.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "54";
                        txtquantity.Text = "1";
                        string f01 = "54";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "54")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb55_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb55.Checked == true)
                {
                    clear();
                    falseCheckSelection();


                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb55.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "55";
                        txtquantity.Text = "1";
                        string f01 = "55";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "55")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb56_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb56.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb56.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "56";
                        txtquantity.Text = "1";
                        string f01 = "56";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "56")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb57_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb57.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb57.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "57";
                        txtquantity.Text = "1";
                        string f01 = "57";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "57")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }
                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb58_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb58.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb58.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "58";
                        txtquantity.Text = "1";
                        string f01 = "58";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "58")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb59_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb59.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb59.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "59";
                        txtquantity.Text = "1";
                        string f01 = "59";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "59")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }
        private void cb60_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
             
                if (cb60.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb60.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "60";
                        txtquantity.Text = "1";
                        string f01 = "60";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "60")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb61_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb61.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb61.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "61";
                        txtquantity.Text = "1";
                        string f01 = "61";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "61")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb62_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb62.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb62.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "62";
                        txtquantity.Text = "1";
                        string f01 = "62";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "62")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb63_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb63.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb63.Checked = false;
                    }
                    else
                    {
                        lblfno.Text = "63";
                        txtquantity.Text = "1";
                        string f01 = "63";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "63")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb64_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb64.Checked == true)
                {
                    clear();
                    falseCheckSelection();

                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb64.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "64";
                        txtquantity.Text = "1";
                        string f01 = "64";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();


                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "64")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb65_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb65.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb65.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "65";
                        txtquantity.Text = "1";
                        string f01 = "65";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();


                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "65")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb66_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (cb66.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb66.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "66";
                        txtquantity.Text = "1";
                        string f01 = "66";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "66")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb67_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb67.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb67.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "67";
                        txtquantity.Text = "1";
                        string f01 = "67";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                        
                    }
                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                             truecheckSection();


                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "67")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb68_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb68.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb68.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "68";
                        txtquantity.Text = "1";
                        string f01 = "68";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "68")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb69_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb69.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb69.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "69";
                        txtquantity.Text = "1";
                        string f01 = "69";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "69")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }
        private void cb70_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb70.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb70.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "70";
                        txtquantity.Text = "1";
                        string f01 = "70";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "70")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb71_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb71.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb71.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "71";
                        txtquantity.Text = "1";
                        string f01 = "71";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }


                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }


                }
                else
                {
                    dst.Reset();
                    lblfno.Visible = false;
                    lblfname.Visible = false;
                    lblfname.Text = "";
                    txtquantity.Text = "";
                    truecheckSection();

                    foreach (DataGridViewRow item in this.dgvBill.Rows)
                    {
                        if (item.Cells["FoodNo"].Value.ToString() == "71")
                        {
                            dgvBill.Rows.RemoveAt(item.Index);
                        }
                    }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }
        private void cb72_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            

                if (cb72.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb72.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "72";
                        txtquantity.Text = "1";
                        string f01 = "72";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "72")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb73_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb73.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb73.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "73";
                        txtquantity.Text = "1";
                        string f01 = "73";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "73")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb74_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb74.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb74.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "74";
                        txtquantity.Text = "1";
                        string f01 = "74";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "74")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb75_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              

                if (cb75.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb75.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "75";
                        txtquantity.Text = "1";
                        string f01 = "75";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "75")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb76_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb76.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb76.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "76";
                        txtquantity.Text = "1";
                        string f01 = "76";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "76")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb77_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb77.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb77.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "77";
                        txtquantity.Text = "1";
                        string f01 = "77";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "77")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb78_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              

                if (cb78.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb78.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "78";
                        txtquantity.Text = "1";
                        string f01 = "78";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "78")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb79_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            

                if (cb79.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb79.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "79";
                        txtquantity.Text = "1";
                        string f01 = "79";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "79")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb80_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb80.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb80.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "80";
                        txtquantity.Text = "1";
                        string f01 = "80";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "80")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb81_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb81.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb81.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "81";
                        txtquantity.Text = "1";
                        string f01 = "81";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "81")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb82_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb82.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb82.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "82";
                        txtquantity.Text = "1";
                        string f01 = "82";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "82")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb83_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb83.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb83.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "83";
                        txtquantity.Text = "1";
                        string f01 = "83";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "83")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb84_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb84.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb84.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "84";
                        txtquantity.Text = "1";
                        string f01 = "84";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "84")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb85_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb85.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb85.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "85";
                        txtquantity.Text = "1";
                        string f01 = "85";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "85")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb86_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb86.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb86.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "86";
                        txtquantity.Text = "1";
                        string f01 = "86";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "86")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb87_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (cb87.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb87.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "87";
                        txtquantity.Text = "1";
                        string f01 = "87";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }
                

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "87")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb88_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb88.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb88.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "88";
                        txtquantity.Text = "1";
                        string f01 = "88";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "88")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb89_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb89.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb89.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "89";
                        txtquantity.Text = "1";
                        string f01 = "89";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "89")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb90_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb90.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb90.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "90";
                        txtquantity.Text = "1";
                        string f01 = "90";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "90")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb91_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb91.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb91.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "91";
                        txtquantity.Text = "1";
                        string f01 = "91";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "91")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb92_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb92.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb92.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "92";
                        txtquantity.Text = "1";
                        string f01 = "92";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "92")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb93_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb93.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb93.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "93";
                        txtquantity.Text = "1";
                        string f01 = "93";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "93")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb94_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb94.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb94.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "94";
                        txtquantity.Text = "1";
                        string f01 = "94";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "94")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb95_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
           

                if (cb95.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb95.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "95";
                        txtquantity.Text = "1";
                        string f01 = "95";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "95")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb96_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb96.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb96.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "96";
                        txtquantity.Text = "1";
                        string f01 = "96";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "96")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb97_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb97.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb97.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "97";
                        txtquantity.Text = "1";
                        string f01 = "97";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "97")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb98_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb98.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb98.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "98";
                        txtquantity.Text = "1";
                        string f01 = "98";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "98")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb99_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb99.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb99.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "99";
                        txtquantity.Text = "1";
                        string f01 = "99";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "99")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb100_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb100.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb100.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "100";
                        txtquantity.Text = "1";
                        string f01 = "100";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "100")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb101_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb101.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb101.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "101";
                        txtquantity.Text = "1";
                        string f01 = "101";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "101")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb102_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb102.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb102.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "102";
                        txtquantity.Text = "1";
                        string f01 = "102";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "102")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb103_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb103.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb104.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "103";
                        txtquantity.Text = "1";
                        string f01 = "103";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "103")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb104_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb104.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb104.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "104";
                        txtquantity.Text = "1";
                        string f01 = "104";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "104")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb105_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb105.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb105.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "105";
                        txtquantity.Text = "1";
                        string f01 = "105";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "105")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb106_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb106.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb106.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "106";
                        txtquantity.Text = "1";
                        string f01 = "106";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "106")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }


                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb107_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb107.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb107.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "107";
                        txtquantity.Text = "1";
                        string f01 = "107";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "107")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb108_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cb108.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb108.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "108";
                        txtquantity.Text = "1";
                        string f01 = "108";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "108")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb109_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb109.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb109.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "109";
                        txtquantity.Text = "1";
                        string f01 = "109";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "109")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb110_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              

                if (cb110.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb110.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "110";
                        txtquantity.Text = "1";
                        string f01 = "110";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "110")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb111_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb111.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb111.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "111";
                        txtquantity.Text = "1";
                        string f01 = "111";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "111")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb112_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (cb112.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb112.Checked = false;
                    }
                    else
                    {


                        lblfno.Text = "112";
                        txtquantity.Text = "1";
                        string f01 = "112";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "112")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb113_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (cb113.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb113.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "113";
                        txtquantity.Text = "1";
                        string f01 = "113";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "113")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void cb114_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              

                if (cb114.Checked == true)
                {
                    clear();
                    falseCheckSelection();
                    if (lblfname.Text != "" && txtquantity.Text != "")
                    {
                        MessageBox.Show("Please add the selected Item to the Bill First", ".Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblfname.Text = "";
                        txtquantity.Text = "";
                        cb114.Checked = false;
                    }
                    else
                    {

                        lblfno.Text = "114";
                        txtquantity.Text = "1";
                        string f01 = "114";
                        string dis01 = "SELECT FName FROM Food_Item Where FNo='" + f01 + "'";

                        con.Open();
                        sqlda = new SqlDataAdapter(dis01, con);

                        con.Close();
                        sqlda.Fill(dst);

                        lblfno.Visible = true;
                        lblfname.Visible = true;
                    }

                            foreach (DataRow dr01 in dst.Tables[0].Rows)
                            {
                                lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                            }


                        }
                        else
                        {
                            dst.Reset();
                            lblfno.Visible = false;
                            lblfname.Visible = false;
                            lblfname.Text = "";
                            txtquantity.Text = "";
                            truecheckSection();

                            foreach (DataGridViewRow item in this.dgvBill.Rows)
                            {
                                if (item.Cells["FoodNo"].Value.ToString() == "114")
                                {
                                    dgvBill.Rows.RemoveAt(item.Index);
                                }
                            }

                    clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error while loading" + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string fid;
            fid = lblfno.Text;

            string priceload = "select Price from Food_Item where FNo='" + fid + "'";
            con.Open();
            cmd = new SqlCommand(priceload, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                txtunitprice.Text = r[0].ToString();
               // unitPrice. text = r[0].ToString();
            }
            con.Close();
            float unitPrice;
            unitPrice = float.Parse(txtunitprice.Text);

           string no = lblfno.Text;
            string name = lblfname.Text;
            string quantity=  txtquantity.Text;
            string qity = txtquantity.Text;
            //Collect the unit price using a select querry from the database



            float price = unitPrice * Convert.ToInt32(quantity);

            dgvBill.Rows.Add(no, name, unitPrice, quantity, price);

            truecheckSection();
            dst.Reset();
            lblfno.Visible = false;
            lblfname.Visible = false;
            lblfname.Text = "";
            txtquantity.Text = "";

            //insert query to new dgv 
            /*
            string insrt01 = "insert into foodbill Values('" + no + "','" + name + "','" + unitPrice + "','" + quantity + "','" + price + "')";
            con.Open();
            cmd = new SqlCommand(insrt01, con);
            cmd.ExecuteNonQuery();
            con.Close();
            */

        }

        private void falseCheckSelection()
        {
            btnadd.Enabled = true;
            cb01.Enabled = false;
            cb02.Enabled = false;
            cb03.Enabled = false;
            cb04.Enabled = false;
            cb05.Enabled = false;
            cb06.Enabled = false;
            cb07.Enabled = false;
            cb08.Enabled = false;
            cb09.Enabled = false;
            cb10.Enabled = false;
            cb11.Enabled = false;
            cb12.Enabled = false;
            cb13.Enabled = false;
            cb14.Enabled = false;
            cb15.Enabled = false;
            cb16.Enabled = false;
            cb17.Enabled = false; 
            cb18.Enabled = false;
            cb19.Enabled = false;
            cb20.Enabled = false;
            cb21.Enabled = false;
            cb22.Enabled = false;
            cb23.Enabled = false;
            cb24.Enabled = false;
            cb25.Enabled = false;
            cb26.Enabled = false;
            cb27.Enabled = false;
            cb28.Enabled = false;
            cb29.Enabled = false;
            cb30.Enabled = false;
            cb31.Enabled = false;
            bc32.Enabled = false;
            cb33.Enabled = false;
            cb34.Enabled = false;
            cb35.Enabled = false;
            cb36.Enabled = false;
            cb37.Enabled = false;
            cb38.Enabled = false;
            cb39.Enabled = false;
            cb40.Enabled = false;
            cb41.Enabled = false; 
            cb42.Enabled = false;
            cb43.Enabled = false;
            cb44.Enabled = false;
            cb45.Enabled = false;
            cb46.Enabled = false;
            cb47.Enabled = false;
            cb48.Enabled = false;
            cb49.Enabled = false;
            cb50.Enabled = false;
            cb51.Enabled = false;
            cb52.Enabled = false;
            cb53.Enabled = false;
            cb54.Enabled = false;
            cb55.Enabled = false;
            cb56.Enabled = false;
            cb57.Enabled = false;
            cb58.Enabled = false;
            cb59.Enabled = false;
            cb60.Enabled = false;           
            cb61.Enabled = false;
            cb62.Enabled = false;
            cb63.Enabled = false;
            cb64.Enabled = false;
            cb65.Enabled = false;
            cb66.Enabled = false;
            cb67.Enabled = false;
            cb68.Enabled = false;
            cb69.Enabled = false;
            cb70.Enabled = false;
            cb71.Enabled = false;
            cb72.Enabled = false;
            cb73.Enabled = false;
            cb74.Enabled = false;
            cb75.Enabled = false;
            cb76.Enabled = false;
            cb77.Enabled = false;
            cb78.Enabled = false;
            cb79.Enabled = false;
            cb80.Enabled = false;
            cb81.Enabled = false;
            cb82.Enabled = false;
            cb83.Enabled = false;
            cb84.Enabled = false;
            cb85.Enabled = false;
            cb86.Enabled = false;
            cb87.Enabled = false;
            cb88.Enabled = false;
            cb89.Enabled = false;
            cb90.Enabled = false;
            cb91.Enabled = false;
            cb92.Enabled = false;
            cb93.Enabled = false;
            cb94.Enabled = false;
            cb95.Enabled = false;
            cb96.Enabled = false;
            cb97.Enabled = false;
            cb98.Enabled = false;
            cb99.Enabled = false;
            cb100.Enabled = false;
            cb101.Enabled = false;
            cb102.Enabled = false;
            cb103.Enabled = false;
            cb104.Enabled = false;
            cb105.Enabled = false;
            cb106.Enabled = false;
            cb107.Enabled = false;
            cb108.Enabled = false;
            cb109.Enabled = false;
            cb110.Enabled = false;
            cb111.Enabled = false;
            cb112.Enabled = false;
            cb113.Enabled = false;
            cb114.Enabled = false;







        }
        private void truecheckSection()
        {
            btnadd.Enabled = false;
            cb01.Enabled = true;

            cb01.Enabled = true;
            cb02.Enabled = true;
            cb03.Enabled = true;
            cb04.Enabled = true;
            cb05.Enabled = true;
            cb06.Enabled = true;
            cb07.Enabled = true;
            cb08.Enabled = true;
            cb09.Enabled = true;
            cb10.Enabled = true;
            cb11.Enabled = true;
            cb12.Enabled = true;
            cb13.Enabled = true;
            cb14.Enabled = true;
            cb15.Enabled = true;
            cb16.Enabled = true;
            cb17.Enabled = true;
            cb18.Enabled = true;
            cb19.Enabled = true;
            cb20.Enabled = true;
            cb21.Enabled = true;
            cb22.Enabled = true;
            cb23.Enabled = true;
            cb24.Enabled = true;
            cb25.Enabled = true;
            cb26.Enabled = true;
            cb27.Enabled = true;
            cb28.Enabled = true;
            cb29.Enabled = true;
            cb30.Enabled = true;
            cb31.Enabled = true;
            bc32.Enabled = true;
            cb33.Enabled = true;
            cb34.Enabled = true;
            cb35.Enabled = true;
            cb36.Enabled = true;
            cb37.Enabled = true;
            cb38.Enabled = true;
            cb39.Enabled = true;
            cb40.Enabled = true;
            cb41.Enabled = true;
            cb42.Enabled = true;
            cb43.Enabled = true;
            cb44.Enabled = true;
            cb45.Enabled = true;
            cb46.Enabled = true;
            cb47.Enabled = true;
            cb48.Enabled = true;
            cb49.Enabled = true;
            cb50.Enabled = true;
            cb51.Enabled = true;
            cb52.Enabled = true;
            cb53.Enabled = true;
            cb54.Enabled = true;
            cb55.Enabled = true;
            cb56.Enabled = true;
            cb57.Enabled = true;
            cb58.Enabled = true;
            cb59.Enabled = true;
            cb60.Enabled = true;           
            cb61.Enabled = true;
            cb62.Enabled = true;
            cb63.Enabled = true;
            cb64.Enabled = true;
            cb65.Enabled = true;
            cb66.Enabled = true;
            cb67.Enabled = true;
            cb68.Enabled = true;
            cb69.Enabled = true;
            cb70.Enabled = true;
            cb71.Enabled = true;
            cb72.Enabled = true;
            cb73.Enabled = true;
            cb74.Enabled = true;
            cb75.Enabled = true;
            cb76.Enabled = true;
            cb77.Enabled = true;
            cb78.Enabled = true;
            cb79.Enabled = true;
            cb80.Enabled = true;
            cb81.Enabled = true;
            cb82.Enabled = true;
            cb83.Enabled = true;
            cb84.Enabled = true;
            cb85.Enabled = true;
            cb86.Enabled = true;
            cb87.Enabled = true;
            cb88.Enabled = true;
            cb89.Enabled = true;
            cb90.Enabled = true;
            cb91.Enabled = true;
            cb92.Enabled = true;
            cb93.Enabled = true;
            cb94.Enabled = true;
            cb95.Enabled = true;
            cb96.Enabled = true;
            cb97.Enabled = true;
            cb98.Enabled = true;
            cb99.Enabled = true;
            cb100.Enabled = true;
            cb101.Enabled = true;
            cb102.Enabled = true;
            cb103.Enabled = true;
            cb104.Enabled = true;
            cb105.Enabled = true;
            cb106.Enabled = true;
            cb107.Enabled = true;
            cb108.Enabled = true;
            cb109.Enabled = true;
            cb110.Enabled = true;
            cb111.Enabled = true;
            cb112.Enabled = true;
            cb113.Enabled = true;
            cb114.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            sub = 0;
            for (int i = 0; i < dgvBill.Rows.Count; i++)
            {
                sub += Convert.ToDouble(dgvBill.Rows[i].Cells["Price"].Value);
            }
            txtsub.Text = sub.ToString();
            txtservice.Text = "10%";
            service = 0.1;
            tot = (sub * service)+sub;
            txttot.Text = tot.ToString();
            button1.Enabled = true;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertBill = "insert into Restaurant_Trans values ('" + lblbillno.Text + "','" + txtsub.Text + "','" + txttot.Text + "','"+txtrecieved.Text+"','" + txtbalance.Text + "','"+dateTimePicker1.Value.ToString()+ "','" + dateTimePicker2.Value.ToString() + "')";
            cmd = new SqlCommand(insertBill, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Transaction Log Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void restaurantToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Restaurant rest = new Restaurant();
            this.Hide();
            rest.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            txtbalance.Clear();
            txtsub.Clear();
            txttot.Clear();
            txtservice.Clear();
            txtrecieved.Clear();
        }

        private void txtrecieved_TextChanged(object sender, EventArgs e)
        {

            
            if (txtrecieved.TextLength > 0)
            {
                recieve = double.Parse(txtrecieved.Text);
                tot = double.Parse(txttot.Text);
                balance = recieve - tot;
                txtbalance.Text = balance.ToString();
            }
        }
    }
}

