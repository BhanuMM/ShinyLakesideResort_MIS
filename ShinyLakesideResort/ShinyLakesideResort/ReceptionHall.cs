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
    public partial class ReceptionHall : Form
    {
        public ReceptionHall()
        {
            InitializeComponent();
            this.txtcrowd.KeyPress += new KeyPressEventHandler(txtcrowd_KeyPress);
        }

        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();

        string tim,menut,f1,f2,f3,f4,f5,f6,f7,p1,p2,p3,p4,p5,p6,full;

        double pa1, pa2, pa3, pa4, pa5, pa6,tot,advan,bal, mp, lasttot;
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if ( txtname.Text == "")
            {
                MessageBox.Show("Please Enter A name ", "Some Fields required Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {

                if (txtconno.Text == "")
                {
                    MessageBox.Show("Please Enter  Contact Number", "Some Fields required Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    try
                    {
                        try
                        {
                            string inserthall = "Insert Into ReceptionHall values('" + textBox1.Text + "','" + txtname.Text + "','" + txtconno.Text + "','" + cmbevent.SelectedItem + "','" + txtcrowd.Text + "','" + dtpday.Value.ToString() + "','" + tim + "','" + menut + "','" + txttot.Text + "','" + txtadvan.Text + "','" + txtbalance.Text + "','" + full + "')";
                            con.Open();
                            cmd = new SqlCommand(inserthall, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex1) { MessageBox.Show("Error hall" + Environment.NewLine + ex1); }
                        try
                        {
                            string insertselec = "insert into ReceptionHallSelections values('" + textBox1.Text + "','" + f1 + "','" + f2 + "','" + f3 + "','" + f4 + "','" + f5 + "','" + f6 + "','" + f7 + "','" + p1 + "','" + p2 + "','" + p3 + "','" + p4 + "','" + p5 + "','" + p6 + "')";
                            con.Open();
                            cmd = new SqlCommand(insertselec, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex3) { MessageBox.Show("Error selc" + Environment.NewLine + ex3); }

                        MessageBox.Show("Reception Hall Reserved Successfully!", "Reservation Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReceptionHall rechall = new ReceptionHall();
                        this.Hide();
                        rechall.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + Environment.NewLine + ex);
                    }
                }
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            string checkava = "SELECT * FROM ReceptionHall where Held_Date = '" + dateTimePicker1.Value.ToString() + "' And Held_Time='"+comboBox1.SelectedItem+"' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkava, con);
            con.Close();
            DataTable r1 = new DataTable();
            sqlda.Fill(r1);

            if (r1.Rows.Count > 0)
            {
                lblreserved.Visible = true;
                btnresrve.Visible = false;
                btnresrve.Enabled = false;
            }
            else
            {
                btnresrve.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            btnresrve.Enabled = false;
            lblreserved.Visible = false;
            btnresrve.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnresrve.Enabled = false;
           lblreserved.Visible = false;
            btnresrve.Visible = true;
        }

        private void btnresrve_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            dtpday.Value = dateTimePicker1.Value;
            if (comboBox1.SelectedItem.ToString() == "Night") { rbnight.Checked = true; }
            else { rbday.Checked = true; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReceptionMain recmain = new ReceptionMain();
            recmain.Show();
            this.Hide();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void txtcrowd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        private void txtcrowd_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtcrowd_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnoption_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReceptionHall rechall = new ReceptionHall();
            this.Hide();
            rechall.Show();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void cbfull_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfull.Checked == true)
            {
                full = txttot.Text;
                lasttot = 0;
                txtadvan.Text = "0";
                txtbalance.Text = "0";
                txtadvan.Enabled = false;
                txtbalance.Enabled = false;
            }
            else
            {
                full = "0";
                txtadvan.Enabled = true;
                txtbalance.Enabled = true;
            }
        }

        private void txtadvan_TextChanged(object sender, EventArgs e)
        {
           
            if (txtadvan.TextLength > 0)
            {
                if (txttot.Text != "")
                {
                    lasttot = double.Parse(txttot.Text);
                    advan = double.Parse(txtadvan.Text);
                    bal = lasttot - advan;
                    txtbalance.Text = bal.ToString();
                }
                
            }
            else
            {
                advan = 0;
                //nw add
                txtadvan.Text = "0";
                lasttot = 0;
                
                txtbalance.Text = "0";
            }
        }

        private void btncalc_Click(object sender, EventArgs e)
        {
            if (txtcrowd.Text == "") { txttot.Text = "10000"; }
            else
            {
               

                double crwd, menufull;
                if (txtcrowd.TextLength > 0)
                {
                    crwd = double.Parse(txtcrowd.Text);
                }
                else { crwd = 0; }

                menufull = crwd * mp;
                tot = menufull + pa1 + pa2 + pa3 + pa4 + pa5 + pa6;
                txttot.Text = tot.ToString();
            }
            btnoption.Enabled = false;
            button1.Enabled = true;

        }

        private void cbfree7_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree7.Checked == true)
            {
                f7 = "orderd";
            }
            else { f7 = "not"; }
        }

        private void cbpay1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay1.Checked == true)
            {
                p1 = "orderd";
                pa1 = 10000;
            }
            else
            { p1 = "not";
                pa1 = 0;
            }
        }

        private void cbpay2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay2.Checked == true)
            {
                p2 = "orderd";
                pa2 = 5000;
            }
            else
            {
                p2 = "not";
                pa2 = 0;
            }
        }

        private void cbpay3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay3.Checked == true)
            {
                p3 = "orderd";
                pa3 = 10000;
            }
            else
            {
                p3 = "not";
                pa3 = 0;
            }
        }

        private void cbpay4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay4.Checked == true)
            {
                p4 = "orderd";
                pa4 = 10000;
            }
            else
            {
                p4 = "not";
                pa4 = 0;
            }
        }

        private void cbpay5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay5.Checked == true)
            {
                p5 = "orderd";
                pa5 = 15000;
            }
            else
            {
                p5 = "not";
                pa5 = 0;
            }
        }

        private void cbpay6_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpay6.Checked == true)
            {
                p6 = "orderd";
                pa6 = 7000;
            }
            else
            {
                p6 = "not";
                pa6 = 0;
            }
        }

        private void cbfree6_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree6.Checked == true)
            {
                f6 = "orderd";
            }
            else { f6 = "not"; }
        }

        private void cbfree5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree5.Checked == true)
            {
                f5 = "orderd";
            }
            else { f5 = "not"; }
        }

        private void cbfree4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree4.Checked == true)
            {
                f4 = "orderd";
            }
            else { f4 = "not"; }
        }

        private void cbfree3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree3.Checked == true)
            {
                f3 = "orderd";
            }
            else { f3 = "not"; }
        }

        private void cbfree2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree2.Checked == true)
            {
                f2 = "orderd";
            }
            else { f2 = "not"; }
        }

        private void clear()
        {
            lasttot = 0;
            txtname.Clear();
            txtconno.Clear();
            txtcrowd.Clear();
            txtadvan.Clear();
            txtbalance.Clear();
            rbm1.Checked = false;
            rbm2.Checked = false;
            rbm3.Checked = false;
            rbm4.Checked = false;
            cbfull.Checked = false;
            txttot.Clear();
            txtname.Focus();
            cmbevent.ResetText();
            cbfree1.Checked = false;
            cbfree2.Checked = false;
            cbfree3.Checked = false;
            cbfree4.Checked = false;
            cbfree5.Checked = false;
            cbfree6.Checked = false;
            cbfree7.Checked = false;
            cbpay1.Checked = false;
            cbpay2.Checked = false;
            cbpay3.Checked = false;
            cbpay4.Checked = false;
            cbpay5.Checked = false;
            cbpay6.Checked = false;
        }

        private void ReceptionHall_Load(object sender, EventArgs e)
        {
            string cusidload = "SELECT isnull(max(cast(cusid as int)),0)+10 from ReceptionHall";
            con.Open();
            sqlda = new SqlDataAdapter(cusidload, con);
            DataTable cusidloaddt = new DataTable();
            sqlda.Fill(cusidloaddt);
            textBox1.Text = cusidloaddt.Rows[0][0].ToString();
            con.Close();

            lbltime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbldate.Text = DateTime.Today.ToString("dd-MM-yyyy");

            

            f1 = "not"; f2 = "not"; f3 = "not"; f4 = "not"; f5 = "not"; f6 = "not"; f7 = "not";
            p1 = "not"; p2 = "not"; p3 = "not"; p4 = "not"; p5 = "not"; p6 = "not";

            full = "0";
        }

        private void rbday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbday.Checked == true)
            {
                tim = "Day";
            }
        }

        private void rbnight_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnight.Checked == true)
            {
                tim = "Night";
            }
            else { tim = "Day"; }
        }

        private void rbm2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbm2.Checked == true)
            {
                menut = "Menu 02";
                mp = 1200;
            }
        }

        private void rbm3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbm3.Checked == true)
            {
                menut = "Menu 03";
                mp = 1350;
            }
        }

        private void rbm4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbm4.Checked == true)
            {
                menut = "Menu 04";
                mp = 1700;
            }
        }

        private void cbfree1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfree1.Checked == true)
            {
                f1 = "orderd";
            }else { f1 = "not"; }
        }

        private void rbm1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbm1.Checked == true)
            {
                menut = "Menu 01";
                mp=1100;
            }
        }
    }
}
