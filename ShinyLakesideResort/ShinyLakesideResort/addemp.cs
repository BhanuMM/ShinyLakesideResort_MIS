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
    public partial class addemp : Form
    {
        public addemp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        string gen;
        private void addemp_Load(object sender, EventArgs e)
        {
            string empidload = "SELECT isnull(max(cast(empid as int)),0)+1 from EmpDetails";
            con.Open();
            sqlda = new SqlDataAdapter(empidload, con);
            DataTable emploaddt = new DataTable();
            sqlda.Fill(emploaddt);
            txtempid.Text = emploaddt.Rows[0][0].ToString();
            con.Close();

            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (dtpdob.Value.Date == DateTime.Now.Date)
            { MessageBox.Show("Please Enter a Valid Birthday!", "DOB not Valid!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    string addnewemp = "insert into EmpDetails values ('" + txtempid.Text + "','" + txtempname.Text + "','" + txtnic.Text + "','" + dtpdob.Value.ToString() + "','" + txtconno.Text + "','" + txtaddress.Text + "','" + dtpjoindate.Value.ToString() + "','" + cmbjobrole.SelectedItem + "','" + gen + "','" + txtbsal.Text + "')";
                    cmd = new SqlCommand(addnewemp, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Employer Details added succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    addemp frmaddemp = new addemp();
                    this.Hide();
                    frmaddemp.Show();
                }
                catch (Exception ex)
                { MessageBox.Show("Error While adding new employer details," + Environment.NewLine + Environment.NewLine + ex); }
            }
             }


        private void rbmale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmale.Checked == true)
            {
                gen = "Male";
            }
            else { gen="Female";}
          
        }
        private void Clear()
        {
            txtempname.Clear();
            txtnic.Clear();
            dtpdob.ResetText();
            txtconno.Clear();
            txtaddress.Clear();
            dtpjoindate.Text = "";
            cmbjobrole.Text = "";
            rbfemale.Checked = false;
            rbmale.Checked = false;
            txtbsal.Clear();
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtempname_TextChanged(object sender, EventArgs e)
        {
            if (txtempname.Text != "") { btnsave.Enabled = true; }
            else { btnsave.Enabled = false; }
        }

        private void dtpdob_ValueChanged(object sender, EventArgs e)
        {

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

        private void btnadminhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EMPLOYERDETAILS2 empdet = new EMPLOYERDETAILS2();
            this.Hide();
            empdet.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    
    }
}
