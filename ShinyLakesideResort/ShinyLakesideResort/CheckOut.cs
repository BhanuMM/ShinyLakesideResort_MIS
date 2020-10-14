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
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();
        private void btnhome_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            RoomReservationMain roomm = new RoomReservationMain();
            this.Hide();
            roomm.Show();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbldate.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string giveid;
            giveid = txtgiveid.Text;
            try {
                string checkdata = "Select * from RoomReserve Where ID_no='" + giveid + "'";
                con.Open();
                sqlda = new SqlDataAdapter(checkdata, con);
                con.Close();
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    try {


                        string loaddata = "Select * from RoomReserve Where ID_no='" + giveid + "'";
                        con.Open();
                        cmd = new SqlCommand(loaddata, con);
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            textBox1.Text = r[0].ToString();
                            string idtype = r[3].ToString();
                            if (idtype == "NIC")
                            {
                                rbnic.Checked = true;
                            }
                            else { rbpassport.Checked = true; }
                            txtidno.Text = r[4].ToString();
                            txtcusname.Text = r[2].ToString();
                            dtparrival.Text = r[5].ToString();
                            dtpdept.Text = r[6].ToString();
                            txtnoroom.Text = r[9].ToString();
                            txtadults.Text = r[7].ToString();
                            txtkids.Text = r[8].ToString();
                            txttot.Text = r[10].ToString();
                            txtadvance.Text = r[11].ToString();
                            txtbalance.Text = r[12].ToString();
                            string full = r[13].ToString();
                            if (full == "0.00")
                            {
                                cbfull.Checked = false;
                            }
                            else { cbfull.Checked = true; }
                            txtgiveid.Clear();
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("Error" + Environment.NewLine + ex);
                    }
                }
                else
                {
                     MessageBox.Show("No Record was Found, Please Check the ID No and Type Again", "NO Record For the Given ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtgiveid.Clear();
                    txtgiveid.Focus();
                    txtidno.Clear();
                    txtcusname.Clear();
                    rbnic.Checked = false;
                    rbpassport.Checked = false;
                    cbfull.Checked = false;
                    txtadults.Clear();
                    txtkids.Clear();
                    txtnoroom.Clear();
                    txttot.Clear();
                    txtadvance.Clear();
                    txtbalance.Clear();
                    textBox1.Clear();
                }

            }
            catch (Exception ex) { MessageBox.Show("Error" + Environment.NewLine + ex); }
            }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter A ID Number To Proceed", "ID No.Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            
            {
                string updata = "update RoomReserve set checkedOUT='" + "YES" + "' where cusid= '" + textBox1.Text + "'";
                con.Open();
                cmd = new SqlCommand(updata, con);
                cmd.ExecuteNonQuery();
                con.Close();

               

                string id = txtidno.Text;


                DialogResult res = MessageBox.Show("Are you sure you want to checkout " + id + " ?", "CheckOut Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    MessageBox.Show(id + " checked out successfully", "Checking Out Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RoomReservationMain roomm = new RoomReservationMain();
                    this.Hide();
                    roomm.Show();
                }
            }
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurant rest = new Restaurant();
            this.Hide();
            rest.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
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

        private void txtgiveid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
