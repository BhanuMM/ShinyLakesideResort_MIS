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
    public partial class reseptionhalllog : Form
    {
        public reseptionhalllog()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res1 = MessageBox.Show("Are you sure you want to logout?", "logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res1 == DialogResult.Yes)
            {
                UserLogin uslog = new UserLogin();
                this.Hide();
                uslog.Show();
            }
        }

        private void roomReservationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomreservationsLOG roomreslog = new RoomreservationsLOG();
            this.Hide();
            roomreslog.Show();
        }

        private void restaurantTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestaurantTrans restrans = new RestaurantTrans();
            this.Hide();
            restrans.Show();
        }

        private void receptionHallBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reseptionhalllog reshall = new reseptionhalllog();
            this.Hide();
            reshall.Show();
        }

        private void employerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMPLOYERDETAILS2 empdel = new EMPLOYERDETAILS2();
            this.Hide();
            empdel.Show();
        }

        private void addOrRemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addorremoveuser ademprem = new addorremoveuser();
            this.Hide();
            ademprem.Show();
        }

        private void reseptionhalllog_Load(object sender, EventArgs e)
        {
            string loaddata = "Select * from ReceptionHall order by Held_Date";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dgvhalllog.DataSource = dset.Tables["Reservation"];

            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpsearch_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            dset.Reset();


            string loaddata = "Select * from ReceptionHall Where Held_Date='" + dateTimePicker1.Value.ToString() + "'";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dgvhalllog.DataSource = dset.Tables["Reservation"];
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            

            string loaddataselec1 = "Select * from ReceptionHallSelections Where cusid='" + txtcusid.Text + "'";
            con.Open();
            sqlda = new SqlDataAdapter(loaddataselec1, con);
            con.Close();
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                
                string loaddataselec = "Select * from ReceptionHallSelections Where cusid='" + txtcusid.Text + "'";

                con.Open();
                cmd = new SqlCommand(loaddataselec, con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    string f1, f2, f3, f4, f5, f6, f7, p1, p2, p3, p4, p5, p6;
                    f1 = r[1].ToString();
                    f2 = r[2].ToString();
                    f3 = r[3].ToString();
                    f4 = r[4].ToString();
                    f5 = r[5].ToString();
                    f6 = r[6].ToString();
                    f7 = r[7].ToString();
                    p1 = r[8].ToString();
                    p2 = r[9].ToString();
                    p3 = r[10].ToString();
                    p4 = r[11].ToString();
                    p5 = r[12].ToString();
                    p6 = r[13].ToString();
                    if (f1 == "orderd") { cbfree1.Checked = true; }
                    if (f2 == "orderd") { cbfree2.Checked = true; }
                    if (f3 == "orderd") { cbfree3.Checked = true; }
                    if (f4 == "orderd") { cbfree4.Checked = true; }
                    if (f5 == "orderd") { cbfree5.Checked = true; }
                    if (f6 == "orderd") { cbfree6.Checked = true; }
                    if (f7 == "orderd") { cbfree7.Checked = true; }
                    if (p1 == "orderd") { cbpay1.Checked = true; }
                    if (p2 == "orderd") { cbpay2.Checked = true; }
                    if (p3 == "orderd") { cbpay3.Checked = true; }
                    if (p4 == "orderd") { cbpay4.Checked = true; }
                    if (p5 == "orderd") { cbpay5.Checked = true; }
                    if (p6 == "orderd") { cbpay6.Checked = true; }
                }
                con.Close();
                //date 
                string loaddate = "Select Held_Date from ReceptionHall Where cusid='" + txtcusid.Text + "'";

                con.Open();
                cmd = new SqlCommand(loaddate, con);
                SqlDataReader r1 = cmd.ExecuteReader();
                while (r1.Read())
                {
                    dateTimePicker1.Text = r1[0].ToString();
                }
                con.Close();
                    //.........
                    btnsearch.Enabled = false;
                btnview.Enabled = false;
                dateTimePicker1.Enabled = false;
                panel3.Visible = true;
            }
            else { MessageBox.Show("Please Enter Valid Customer Id", "Customer ID not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcusid.Clear();
                txtcusid.Focus();
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            txtcusid.Clear();
            btnsearch.Enabled = true;
            btnview.Enabled = true;
            dateTimePicker1.Enabled = true;

            dset.Reset();
            string loaddata = "Select * from ReceptionHall order by Held_Date";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dgvhalllog.DataSource = dset.Tables["Reservation"];
        }
    }
}