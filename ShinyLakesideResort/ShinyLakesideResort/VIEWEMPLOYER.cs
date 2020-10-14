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
    public partial class viewemployer : Form
    {
        public viewemployer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();
        private void viewemployer_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");


            try
            {
                cmbempid.Items.Clear();
                con.Open();
                string loadempid = "select empid from EmpDetails";
                sqlda = new SqlDataAdapter(loadempid, con);
                DataTable loadempiddt = new DataTable();
                sqlda.Fill(loadempiddt);
                con.Close();
                cmbempid.Items.Add("");
                foreach (DataRow row in loadempiddt.Rows)
                {
                    cmbempid.Items.Add(row["empid"]);
                }
                cmbempid.SelectedIndex = 0;

                dset.Reset();
                string viewemp = "Select * from EmpDetails";
                con.Open();
                sqlda = new SqlDataAdapter(viewemp, con);
                sqlda.Fill(dset, "employers");
                con.Close();

                dgvviewemp.DataSource = dset.Tables["employers"];

            }
            catch (Exception ex) { MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        { 
            
            dset.Reset();
            
            
            string viewemp = "Select * from EmpDetails where empid='"+cmbempid.SelectedItem+"'";
            con.Open();
            sqlda = new SqlDataAdapter(viewemp, con);
            sqlda.Fill(dset,"employers");
            con.Close();

            dgvviewemp.DataSource = dset.Tables["employers"];
        }

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

        private void btnadminhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            EMPLOYERDETAILS2 empdel = new EMPLOYERDETAILS2();
            this.Hide();
            empdel.Show();
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

       
    }
}
