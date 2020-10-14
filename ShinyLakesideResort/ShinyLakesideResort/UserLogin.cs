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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        string role;

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string uname, pswrd;
                uname = txtuname.Text;
                pswrd = txtpass.Text;
                string checkuser = "Select * from ulogin where uname='" + uname + "' and pswrd='" + pswrd + "'";
                con.Open();
                sqlda = new SqlDataAdapter(checkuser, con);
                DataTable checkdt = new DataTable();
                sqlda.Fill(checkdt);
                con.Close();

                if (checkdt.Rows.Count > 0)
                {
                    try
                    {
                        string selectrole = "select * from ulogin where uname='" + uname + "' and pswrd='" + pswrd + "'";
                        con.Open();
                        cmd = new SqlCommand(selectrole, con);
                        SqlDataReader roleR = cmd.ExecuteReader();
                        while (roleR.Read())
                        {
                            textBox1.Text = roleR[2].ToString();
                            role = textBox1.Text;
                        }
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show("Error In selecting role..." + Environment.NewLine + Environment.NewLine + ex); }
                    if (role == "admin")
                    {
                        AdminHome adminhome = new AdminHome();
                        this.Hide();
                        adminhome.Show();
                    }
                    else
                    {
                        HomeMenu hmmenu = new HomeMenu();
                        this.Hide();
                        hmmenu.Show();
                    }
                }
                else
                {
                    MessageBox.Show("INCORRECT USERNAME OR PASSWORD!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtuname.Clear();
                    txtpass.Clear();
                    txtuname.Focus();
                }
            }
            catch (Exception ex1) { MessageBox.Show("Error In selecting username or password..." + Environment.NewLine + Environment.NewLine + ex1); }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbldate.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    

