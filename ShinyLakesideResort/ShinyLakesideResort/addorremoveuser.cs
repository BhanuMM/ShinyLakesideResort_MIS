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
    public partial class addorremoveuser : Form
    {
        public addorremoveuser()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        string role, uname, pswrd;


        

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

        private void rbadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbadmin.Checked == true) { role = "admin"; }
            else { role = "user"; }
        }

        private void rbuser_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuser.Checked == true) { role = "user"; }
            else { role = "admin"; }
        }

        private void addorremoveuser_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnadhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
        }

        private void btnremoveuser_Click(object sender, EventArgs e)
        {
            lblremoveuser.Visible = true;
            lbladduser.Visible = false;
            panel3.Visible = false;
            lblrepass.Visible = false;
            txtrepass.Visible = false;
            btnaduser.Visible = false;
            btnruser.Visible = true;
            lblacc.Visible = false;
            btnclear.Visible=false;
            Clear();
            btnremoveuser.Enabled = false;
            btnauser.Enabled = true;
        }

        private void btnauser_Click(object sender, EventArgs e)
        {
            lblremoveuser.Visible = false;
            lbladduser.Visible = true;
            panel3.Visible = true;
            lblrepass.Visible = true;
            txtrepass.Visible = true;
            btnaduser.Visible = true;
            btnruser.Visible = false;
            lblacc.Visible = true;
            btnclear.Visible = true;
            Clear();
            btnremoveuser.Enabled = true;
            btnauser.Enabled = false;
        }
         private void Clear()
        {
            txtpass.Clear();
            txtusname.Clear();
            rbadmin.Checked = false;
            rbuser.Checked = false;
            txtrepass.Clear();
            txtusname.Focus();
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnruser_Click(object sender, EventArgs e)
        {
            if (txtusname.Text == "") { MessageBox.Show("Please Enter A username and Password", "Username Required", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                string slecu = "Select * from ulogin where uname='" + txtusname.Text + "' and pswrd='" + txtpass.Text + "'";
                    con.Open();
                sqlda = new SqlDataAdapter(slecu, con);
                con.Close();
                DataTable r1 = new DataTable();
                sqlda.Fill(r1);

                if (r1.Rows.Count > 0)
                {
                    string removeu = "delete from ulogin where uname='" + txtusname.Text + "' and pswrd='" + txtpass.Text + "'";
                    cmd = new SqlCommand(removeu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("USER Successfully Removed!", "User Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Incorrect Username Or Password !", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
               
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addOrRemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addorremoveuser ademprem = new addorremoveuser();
            this.Hide();
            ademprem.Show();
        }

        private void btnaduser_Click(object sender, EventArgs e)
        {
            if (txtpass.Text !="")
            {
                if (txtpass.Text == txtrepass.Text)
                {
                    if (rbadmin.Checked == false && rbuser.Checked == false) { MessageBox.Show("Please select Account Type!", "Adding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        try
                        {
                            uname = txtusname.Text;
                            pswrd = txtpass.Text;

                            string adduser = "INSERT INTO ulogin VALUES('" + uname + "','" + pswrd + "','" + role + "')";
                            cmd = new SqlCommand(adduser, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("USER Added Succesfully!", "New User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtpass.Clear();
                            txtusname.Clear();
                            rbadmin.Checked = false;
                            rbuser.Checked = false;
                            txtrepass.Clear();



                        }
                        catch (Exception )
                        {
                            MessageBox.Show("USERNAME ALREADY EXCISTS!", "Excisting USERNAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtusname.Clear();
                            txtpass.Clear();
                            txtusname.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Doesn't match!", "Adding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Clear();
                    txtrepass.Clear();
                    txtpass.Focus();
                }
            }
            else { MessageBox.Show("Please Enter A Password!", "Adding Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
            }
        }
    }
}
