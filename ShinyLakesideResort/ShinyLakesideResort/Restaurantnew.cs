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
    public partial class Restaurantnew : Form
    {
        public Restaurantnew()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dst = new DataSet();

        double recieve, balance, tot, service, sub;

        private void btnadd_Click(object sender, EventArgs e)
        {
            /* if (txtquantity.Text == "")
             {
                 MessageBox.Show("Enter the quantity to proceed","Quantity Required",MessageBoxButtons.)
             }
 */
            
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
            string quantity = txtquantity.Text;
            string qity = txtquantity.Text;
            //Collect the unit price using a select querry from the database



            float price = unitPrice * Convert.ToInt32(quantity);

            dgvBill.Rows.Add(no, name, unitPrice, quantity, price);


            dst.Reset();
            lblfno.Visible = false;
            lblfname.Visible = false;
            lblfname.Text = "";
            txtquantity.Text = "";
            textBox1.Text = "";
        }

        private void btnok_Click(object sender, EventArgs e)
        {


            string displaydet = "SELECT FName FROM Food_Item Where FNo='" + textBox1.Text + "'";
            con.Open();
            sqlda = new SqlDataAdapter(displaydet, con);
            con.Close();
            sqlda.Fill(dst);
            lblfno.Visible = true;
            lblfno.Text = textBox1.Text.ToString();
            lblfname.Visible = true;
        
                    foreach (DataRow dr01 in dst.Tables[0].Rows)
                    {
                        lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                    }

            btnadd.Enabled = true;
            txtquantity.Text = "1";
            btnok.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnadd.Enabled = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            btnok.Enabled = true;
            btnadd.Enabled = false;
            lblfno.Text = "";
            lblfname.Text = "";
            dst.Reset();
            txtquantity.Clear();

            txtsub.Clear();
            txttot.Clear();
            txtservice.Clear();
            txtrecieved.Clear();
            txtbalance.Clear();
            button1.Enabled = false;
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in this.dgvBill.SelectedRows)
            {
                dgvBill.Rows.RemoveAt(item.Index);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string displaydet = "SELECT FName FROM Food_Item Where FNo='" + textBox1.Text + "'";
                con.Open();
                sqlda = new SqlDataAdapter(displaydet, con);
                con.Close();
                sqlda.Fill(dst);
                lblfno.Visible = true;
                lblfno.Text = textBox1.Text.ToString();
                lblfname.Visible = true;

                foreach (DataRow dr01 in dst.Tables[0].Rows)
                {
                    lblfname.Text += dst.Tables[0].Rows[0]["fName"].ToString();
                }

                btnadd.Enabled = true;
                txtquantity.Text = "1";
                btnok.Enabled = false;
            }
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

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomReservationMain roomm = new RoomReservationMain();
            this.Hide();
            roomm.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew restn = new Restaurantnew();
            this.Hide();
            restn.Show();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res1 = MessageBox.Show("Are you sure you want to logout?", "logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res1 == DialogResult.Yes)
            {
                UserLogin uslog = new UserLogin();
                this.Hide();
                uslog.Show();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string insertBill = "insert into Restaurant_Trans values ('" + lblbillno.Text + "','" + txtsub.Text + "','" + txttot.Text + "','" + txtrecieved.Text + "','" + txtbalance.Text + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "')";
            cmd = new SqlCommand(insertBill, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Transaction Log Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Restaurantnew_Load(object sender, EventArgs e)
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
            tot = (sub * service) + sub;
            txttot.Text = tot.ToString();
            button1.Enabled = true;
        }
    }
}
