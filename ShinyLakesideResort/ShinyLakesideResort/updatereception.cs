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
    public partial class updatereception : Form
    {
        public updatereception()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();

        private void updatereception_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btncheck_Click(object sender, EventArgs e)
        {

            try
            {
                string selecthall1 = "SELECT * FROM ReceptionHall where Held_Date = '" + dateTimePicker1.Value.ToString() + "' And Held_Time='" + comboBox1.SelectedItem + "' ";
                con.Open();
                sqlda = new SqlDataAdapter(selecthall1, con);
                con.Close();
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    btncheck.Enabled = false;
                    btncancel.Enabled = true;

                    string selecthall = "SELECT * FROM ReceptionHall where Held_Date = '" + dateTimePicker1.Value.ToString() + "' And Held_Time='" + comboBox1.SelectedItem + "' ";
                    con.Open();
                    cmd = new SqlCommand(selecthall, con);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        textBox1.Text = r[0].ToString();
                        txtname.Text = r[1].ToString();
                        txtconno.Text = r[2].ToString();
                        txtevnttyp.Text = r[3].ToString();
                        txtcrowd.Text = r[4].ToString();
                        dateTimePicker2.Text = r[5].ToString();
                        txttime.Text = r[6].ToString();
                        txtmenu.Text = r[7].ToString();
                        txttot.Text = r[8].ToString();
                        txtadvan.Text = r[9].ToString();
                        string full = r[11].ToString();
                        if (full == txttot.Text) { cbfull.Checked = true; }
                        else { cbfull.Checked = false; }
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No Record was found for Inserted Date & Time", "No Record was Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btncheck.Enabled = true;
                }
            }catch(Exception ex) { MessageBox.Show("Error " + Environment.NewLine + ex); }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            clear();
            btncheck.Enabled = true;
            btncancel.Enabled = false;
        }
        private void clear()
        {
            textBox1.Text = "";
            txtname.Text = "";
            txtconno.Text = "";
            txtevnttyp.Text = "";
            txtcrowd.Text = "";
            txttime.Text = "";
            txtmenu.Text = "";
            txttot.Text = "";
            txtadvan.Text = "";
            cbfull.Checked = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            btncheck.Enabled = true;
            btncancel.Enabled = false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure you Want To Cancel The Reservation?", "Confirm To Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res== DialogResult.Yes)
            {
                string delhall = "delete from ReceptionHall where cusid='"+textBox1.Text+"'";
                con.Open();
                cmd = new SqlCommand(delhall, con);
                cmd.ExecuteNonQuery();
                con.Close();

                string delhallselec = "delete from ReceptionHallSelections where cusid='" + textBox1.Text + "'";
                con.Open();
                cmd = new SqlCommand(delhallselec, con);
                cmd.ExecuteNonQuery();
                con.Close();

                string d = dateTimePicker1.Text;

                MessageBox.Show("Reservation For Reception Hall on "+d+" canceled successfully.", "Hall Reservation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updatereception up = new updatereception();
                up.Show();
                this.Hide();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {

            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
      ReceptionMain roomres = new ReceptionMain();
            this.Hide();
            roomres.Show();
        }

        private void lbltime_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew resn = new Restaurantnew();
            this.Hide();
            resn.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionHall rechl = new ReceptionHall();
            this.Hide();
           rechl.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

           HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }
    }
}
