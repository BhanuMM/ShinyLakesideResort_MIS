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
    public partial class UPDATEOR_DELETEEMP : Form
    {
        public UPDATEOR_DELETEEMP()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        



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

        private void btnadminhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
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

        private void btnback_Click(object sender, EventArgs e)
        {
            EMPLOYERDETAILS2 empdet = new EMPLOYERDETAILS2();
            this.Hide();
            empdet.Show();
        }

        private void UPDATEOR_DELETEEMP_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");

           

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

          
        }

        private void cmbempid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string empid = cmbempid.SelectedItem.ToString();
                con.Open();
                string retrieveemp = "select * from EmpDetails Where empid='"+empid+"'";
                cmd = new SqlCommand(retrieveemp, con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    txtempname.Text = r[1].ToString();
                    txtnic.Text = r[2].ToString();
                    dtpdob.Value = (DateTime)r["dob"];
                    txtconno.Text = r[4].ToString();
                    txtadrs.Text = r[5].ToString();
                    dtpjoin.Value = (DateTime)r["joindate"];
                    cmbtit.Text = r[7].ToString();
                    string gen = r[8].ToString();
                    if (gen == "Male")
                    {
                        rbmale.Checked = true;
                    }else
                    {
                        rbfemale.Checked = true;
                    }
                    txtbsal.Text = r[9].ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error While Retrieving Data...." + Environment.NewLine + Environment.NewLine + ex);
            }
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string empid = cmbempid.SelectedItem.ToString();
            DialogResult sure = MessageBox.Show("Are You sure You want update the details of Employe ID- " + empid + "?", "Confirm To Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sure == DialogResult.Yes)
            {
                string updatedet = "update EmpDetails set empname='" + txtempname.Text + "',nic='" + txtnic.Text + "',dob='" + dtpdob.Value.ToString() + "',conno='" + txtconno.Text + "',empaddress='" + txtadrs.Text + "',joindate='" + dtpjoin.Value.ToString() + "',jobrole='" + cmbtit.SelectedItem + "',bsal='" + txtbsal.Text + "'";
                cmd = new SqlCommand(updatedet, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employer Details updated succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UPDATEOR_DELETEEMP upemp = new UPDATEOR_DELETEEMP();
                this.Hide();
                upemp.Show();
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            string empid = cmbempid.SelectedItem.ToString();
            DialogResult sure = MessageBox.Show("Are You sure You want Delete the Record of Employe ID- " + empid + "?", "Confirm To Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sure == DialogResult.Yes)
            {
                string delemp= "delete from EmpDetails where empid='"+empid+"'";
                cmd = new SqlCommand(delemp, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employer Details succesfully Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UPDATEOR_DELETEEMP upemp = new UPDATEOR_DELETEEMP();
                this.Hide();
                upemp.Show();
            }
        }

        private void rbfemale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
