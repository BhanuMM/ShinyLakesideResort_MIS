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
    public partial class ReserveRoomDetails : Form
    {
        public ReserveRoomDetails()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();

        string idtype, full ;
        double tot, advan,bal,R1,R2,R3,R4,R5,R6,R7,R8,R9,R10,R11,R12,R13,R14,R15,sub;

        

        private void checkr4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr4.Checked == true && checkr4.BackColor == Color.ForestGreen)
            {
                R4 = 7000;
                cbr4.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R4 = 0;
            }
        }

        private void checkr5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr5.Checked == true && checkr5.BackColor == Color.ForestGreen)
            {
                R5 = 7000;
                cbr5.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R5 = 0;
            }
        }

        private void checkr6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr6.Checked == true && checkr6.BackColor == Color.ForestGreen)
            {
                R6 = 6000;
                cbr6.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R6 = 0;

            }
        }

        private void checkr7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr7.Checked == true && checkr7.BackColor == Color.ForestGreen)
            {
                R7 = 6000;
                cbr7.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R7 = 0;
            }
        }

        private void checkr8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr8.Checked == true && checkr8.BackColor == Color.ForestGreen)
            {
                R8 = 6000;
                cbr8.Checked = true;
                btnreserve.Enabled = true;
            }
            else
            {
                R8 = 0;
            }
        }

        private void checkr9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr9.Checked == true && checkr9.BackColor == Color.ForestGreen)
            {
                R9 = 6000;
                cbr9.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R9 = 0;
            }
        }

        private void checkr10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr10.Checked == true && checkr10.BackColor == Color.ForestGreen)
            {
                R10 = 6000;
                cbr10.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R10 = 0;
            }
        }

        private void checkr11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr11.Checked == true && checkr11.BackColor == Color.ForestGreen)
            {
                R11 = 4000;
                cbr11.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R11 = 0;
            }
        }

        private void checkr12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr12.Checked == true && checkr12.BackColor == Color.ForestGreen)
            {
                R12 = 4000;
                cbr12.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R12 = 0;
            }
        }

        private void checkr13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr13.Checked == true && checkr13.BackColor == Color.ForestGreen)
            {
                R13 = 4000;
                cbr13.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R13 = 0;
            }
        }

        private void checkr14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr14.Checked == true && checkr14.BackColor == Color.ForestGreen)
            {
                R14 = 4000;
                cbr14.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R14 = 0;
            }
        }

        private void checkr15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr15.Checked == true && checkr15.BackColor == Color.ForestGreen)
            {
                R15 = 4000;
                cbr15.Checked = true;
                btnreserve.Enabled = true;
            }
            else
            {
                R15 = 0;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            RoomReservationMain rrd = new RoomReservationMain();
            this.Hide();
            rrd.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomReservationMain roomm = new RoomReservationMain();
            this.Hide();
            roomm.Show();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void btnback1_Click(object sender, EventArgs e)
        {
            RoomReservationMain roomm = new RoomReservationMain();
            this.Hide();
            roomm.Show();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
        }

        private void panelcheckavail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkr3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr3.Checked == true && checkr3.BackColor == Color.ForestGreen)
            {
                R3 = 8500;
                cbr3.Checked = true;
                btnreserve.Enabled = true;


            }
            else
            {
                R3 = 0;
            }
        }

        private void checkr2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr2.Checked == true && checkr2.BackColor == Color.ForestGreen)
            {
                R2 = 8500;
                cbr2.Checked = true;
                btnreserve.Enabled = true;

            }
            else
            {
                R2= 0;
            }
        }

        private void dtpcheckout_ValueChanged(object sender, EventArgs e)
        {
            dtpdept.Value = dtpcheckout.Value;
        }

        private void dtpcheckin_ValueChanged(object sender, EventArgs e)
        {
            dtparrival.Value = dtpcheckin.Value;
            dtpcheckout.Value = dtpcheckin.Value.AddDays(1);
        }

        private void checkr1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkr1.Checked == true && checkr1.BackColor == Color.ForestGreen)
            {
                R1 = 8500;
                cbr1.Checked = true;
                btnreserve.Enabled = true;
             
            }
            else
            {
                R1 = 0;
            }
        }

        private void txtadvance_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (txtadvance.TextLength > 0)
            {
                if (txtsub.Visible == true)
                {
                    if (cbfull.Checked == true)
                    {
                        txtbalance.Text = "0";
                    }
                    else {
                        sub = double.Parse(txtsub.Text);
                        advan = double.Parse(txtadvance.Text);
                        bal = sub - advan;
                        txtbalance.Text = bal.ToString();
                    }
                }
                else
                {
                    if (cbfull.Checked == true)
                    {
                        
                        txtbalance.Text = "0";
                    }else
                    {
                        tot = double.Parse(txttot.Text);
                        advan = double.Parse(txtadvance.Text);
                        bal = tot - advan;
                        txtbalance.Text = bal.ToString();
                    }
                }
            }
            else
            {
               
                advan = 0;
                txtbalance.Text = "";
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

        private void ReserveRoomDetails_Load(object sender, EventArgs e)
        {
            dtpcheckout.Value = dtpcheckin.Value.AddDays(1);

            string cusidload = "SELECT isnull(max(cast(cusid as int)),0)+2 from RoomReserve";
            con.Open();
            sqlda = new SqlDataAdapter(cusidload, con);
            DataTable cusidloaddt = new DataTable();
            sqlda.Fill(cusidloaddt);
            txtcusid.Text = cusidloaddt.Rows[0][0].ToString();
            con.Close();

            lbltime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbldate.Text = DateTime.Today.ToString("dd-MM-yyyy");

            if (cbfull.Checked == false)
            {
                full = "0";
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcusname.Text != "" && txtidno.Text != "")
            { 
                //INSERTING DETAILS FOR ROOM 01
                if (cbr1.Checked == true)
            {
                
                try
                {
                    string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "01" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','"+"YES"+ "','" + "NO" + "')";
                    cmd = new SqlCommand(reserveroom, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                catch (Exception ex)
                { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
               
            }
            //.................
            //INSERTING DETAILS FOR ROOM 02
            if (cbr2.Checked == true)
            {
                
                try
                {
                    string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "02" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                    cmd = new SqlCommand(reserveroom, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                catch (Exception ex)
                { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                
            }
            //..............................
            //INSERTING DETAILS FOR ROOM 03
            if (cbr3.Checked == true)
            {
                
                try
                {
                    string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "03" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                    cmd = new SqlCommand(reserveroom, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                catch (Exception ex)
                { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                
            }
            //.................
            //INSERTING DETAILS FOR ROOM 04
            if (cbr4.Checked == true)
            {
                
                try
                {
                    string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "04" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                    cmd = new SqlCommand(reserveroom, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                catch (Exception ex)
                { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                
            }
                //.................
                //INSERTING DETAILS FOR ROOM 05
                if (cbr5.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "05" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                   
                }
                //.................

                //INSERTING DETAILS FOR ROOM 06
                if (cbr6.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "06" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }
                //.................
                //INSERTING DETAILS FOR ROOM 07
                if (cbr7.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "07" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }
                //.................
                //INSERTING DETAILS FOR ROOM 08
                if (cbr8.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "08" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                   
                }
                //.................

                //INSERTING DETAILS FOR ROOM 09
                if (cbr9.Checked == true)
                {
                       try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "09" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                   
                }
                //.................

                //INSERTING DETAILS FOR ROOM 10
                if (cbr10.Checked == true)
                {
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "10" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }
                //.................
                //INSERTING DETAILS FOR ROOM 11
                if (cbr11.Checked == true)
                {
                   
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "11" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }
                //.................
                //INSERTING DETAILS FOR ROOM 12
                if (cbr12.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "12" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }
                //.................
                //INSERTING DETAILS FOR ROOM 13
                if (cbr13.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "13" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                   
                }
                //.................
                //INSERTING DETAILS FOR ROOM 14
                if (cbr14.Checked == true)
                {
                    
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "14" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                  
                }
                //.................
                //INSERTING DETAILS FOR ROOM 15
                if (cbr15.Checked == true)
                {
                   
                        try
                        {
                            string reserveroom = "insert into RoomReserve values ('" + txtcusid.Text + "','" + "15" + "','" + txtcusname.Text + "','" + idtype + "','" + txtidno.Text + "','" + dtparrival.Value.ToString() + "','" + dtpdept.Value.ToString() + "','" + nudadults.Value.ToString() + "','" + nudkids.Value.ToString() + "','" + txtnoroom.Text + "','" + txttot.Text + "','" + txtadvance.Text + "','" + txtbalance.Text + "','" + full + "','" + "YES" + "','" + "NO" + "')";
                            cmd = new SqlCommand(reserveroom, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error While reserving room," + Environment.NewLine + Environment.NewLine + ex); }
                    
                }

                
                MessageBox.Show("Reservation succesfull!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReserveRoomDetails rrd = new ReserveRoomDetails();
                this.Hide();
                rrd.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Customer Name And ID No!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //.................

        }

        private void nuddays_ValueChanged(object sender, EventArgs e)
        {
            cbfull.Checked = false;
            txtadvance.Clear();
            txtbalance.Clear();
            double dayss;
            dayss = Convert.ToDouble(nuddays.Value) ;
        
            tot = sub * dayss;
            txttot.Text = tot.ToString();
            txtsub.Visible = false;


        }

        private void cbfull_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
           if (cbfull.Checked == true) {
                

                if (txtsub.Visible == true)
                {
                   
                    full = txtsub.Text;
                    
                    txtbalance.Text = "0";
                    txtadvance.Text = "0";
                    
                    txtbalance.Enabled = false;
                    txtadvance.Enabled = false;
                }
                else
                {
                    
                    full = txttot.Text;
                  
                    txtbalance.Text = "0";
                    txtadvance.Text = "0";
                    
                    txtbalance.Enabled = false;
                    txtadvance.Enabled = false;
                }
                
                
            }
            else { full = "0";
                txtbalance.Enabled = true;
                txtadvance.Enabled = true;

            }
            
           
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnreserve_Click(object sender, EventArgs e)
        {
           
            /*
            //date difference..........
            DateTime indate = dtparrival.Value;
            DateTime outdate = dtpdept.Value;

            TimeSpan dpan = outdate-indate;
            int datedif = dpan.Days;
            txtstay.Text = datedif.ToString();
            if (indate = DateTime.Today)
            {
                double tx = double.Parse(txtstay.Text);
                double ty = tx + 1;
                txtsub.Text = ty.ToString();
            }
           */

            //DISPLAYING sub TOTAL
            sub = R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8 + R9 + R10 + R11 + R12 + R13 + R14 + R15;
            txtsub.Text = sub.ToString();  
                
                      
            //..................count the number of rooms


            int count = 0;
            if (checkr1.Checked)
            {
                count++;
            }
            if (checkr2.Checked)
            {
                count++;
            }
            if (checkr3.Checked)
            {
                count++;
            }
            if (checkr4.Checked)
            {
                count++;
            }
            if (checkr5.Checked)
            {
                count++;
            }
            if (checkr6.Checked)
            {
                count++;
            }
            if (checkr7.Checked)
            {
                count++;
            }
            if (checkr8.Checked)
            {
                count++;
            }
            if (checkr9.Checked)
            {
                count++;
            }
            if (checkr10.Checked)
            {
                count++;
            }
            if (checkr11.Checked)
            {
                count++;
            }
            if (checkr12.Checked)
            {
                count++;
            }
            if (checkr13.Checked)
            {
                count++;
            }
            if (checkr14.Checked)
            {
                count++;
            }
            if (checkr15.Checked)
            {
                count++;
            }
            txtnoroom.Text = count.ToString();



            DialogResult sure= MessageBox.Show("Do you want to Reserve Selected Rooms?", "Confirm to Reserve!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sure == DialogResult.Yes)
            { panelcheckavail.Visible = false; }
            else { panelcheckavail.Visible = true; }

         

        }

        private void rbnic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnic.Checked == true) { idtype = "NIC"; }
            else { idtype = "Passport"; }
        }

        private void Clear()
        {
            txtcusname.Clear();
            rbnic.Checked = false;
            rbpassport.Checked = false;
            txtidno.Clear();
            nudadults.Value = 0;
            nuddays.Value = 0;
            nudkids.Value = 0;
            
            cbfull.Checked = false;
            txtadvance.Text = "0";
            txtbalance.Clear();
            txtsub.Visible = true;

        }

        private void btncheck_Click(object sender, EventArgs e)
        { string fromDate, toDate;
            fromDate = dtpcheckin.Value.ToString();
            toDate = dtpcheckout.Value.ToString();
            //check Room 01
            string checkr01= "SELECT * FROM RoomReserve where(((Arrival_Date <= '" +fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate+ "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '"+ toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "01" + "' and checkedOUT='"+"NO"+"' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr01, con);
            con.Close();
            DataTable r1 = new DataTable();
            sqlda.Fill(r1);

            if (r1.Rows.Count > 0)
            { checkr1.BackColor = Color.Red;
                checkr1.Enabled = false;
            }
            else { checkr1.BackColor = Color.ForestGreen;
                checkr1.Enabled = true;
            }

            //check Room 02
            string checkr02 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "02" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr02, con);
            con.Close();
            DataTable r2 = new DataTable();
            sqlda.Fill(r2);

            if (r2.Rows.Count > 0)
            {
                checkr2.BackColor = Color.Red;
                checkr2.Enabled = false;
            }
            else { checkr2.BackColor = Color.ForestGreen;
                checkr2.Enabled = true;
            }

            //check Room 03
            string checkr03 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "03" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr03, con);
            con.Close();
            DataTable r3 = new DataTable();
            sqlda.Fill(r3);

            if (r3.Rows.Count > 0)
            {
                checkr3.BackColor = Color.Red;
                checkr3.Enabled = false;
            }
            else { checkr3.BackColor = Color.ForestGreen;
                checkr3.Enabled = true;
            }

            //check Room 04
            string checkr04 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "04" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr04, con);
            con.Close();
            DataTable r4 = new DataTable();
            sqlda.Fill(r4);

            if (r4.Rows.Count > 0)
            {
                checkr4.BackColor = Color.Red;
                checkr4.Enabled = false;
            }
            else { checkr4.Enabled = true; checkr4.BackColor = Color.ForestGreen; }

            //check Room 05
            string checkr05 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "05" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr05, con);
            con.Close();
            DataTable r5 = new DataTable();
            sqlda.Fill(r5);

            if (r5.Rows.Count > 0)
            {
                checkr5.BackColor = Color.Red;
                checkr5.Enabled = false;
            }
            else { checkr5.BackColor = Color.ForestGreen;
                checkr5.Enabled = true;
            }

            //check Room 06
            string checkr06 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "06" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr06, con);
            con.Close();
            DataTable r6 = new DataTable();
            sqlda.Fill(r6);

            if (r6.Rows.Count > 0)
            {
                checkr6.BackColor = Color.Red;
                checkr6.Enabled = false;
            }
            else { checkr6.BackColor = Color.ForestGreen;
                checkr6.Enabled = true;
            }

            //check Room 07
            string checkr07 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "07" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr07, con);
            con.Close();
            DataTable r7 = new DataTable();
            sqlda.Fill(r7);

            if (r7.Rows.Count > 0)
            {
                checkr7.BackColor = Color.Red;
                checkr7.Enabled = false;
            }
            else { checkr7.Enabled = true; checkr7.BackColor = Color.ForestGreen; }

            //check Room 08
            string checkr08 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "08" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr08, con);
            con.Close();
            DataTable r8 = new DataTable();
            sqlda.Fill(r8);

            if (r8.Rows.Count > 0)
            {
                checkr8.BackColor = Color.Red;
                checkr8.Enabled = false;
            }
            else { checkr8.BackColor = Color.ForestGreen;
                checkr8.Enabled = true;
            }

            //check Room 09
            string checkr09 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "09" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr09, con);
            con.Close();
            DataTable r9 = new DataTable();
            sqlda.Fill(r9);

            if (r9.Rows.Count > 0)
            {
                checkr9.BackColor = Color.Red;
                checkr9.Enabled = false;
            }
            else { checkr9.Enabled = true; checkr9.BackColor = Color.ForestGreen; }

            //check Room 10
            string checkr010 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "10" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr010, con);
            con.Close();
            DataTable r10 = new DataTable();
            sqlda.Fill(r10);

            if (r10.Rows.Count > 0)
            {
                checkr10.BackColor = Color.Red;
                checkr10.Enabled = false;
            }
            else { checkr10.Enabled = true;
                checkr10.BackColor = Color.ForestGreen; }

            //check Room 11
            string checkr011 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "11" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr011, con);
            con.Close();
            DataTable r11 = new DataTable();
            sqlda.Fill(r11);

            if (r11.Rows.Count > 0)
            {
                checkr11.BackColor = Color.Red;
                checkr11.Enabled = false;
            }
            else { checkr11.Enabled = true;
                checkr11.BackColor = Color.ForestGreen; }

            //check Room 12
            string checkr012 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "12" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr012, con);
            con.Close();
            DataTable r12 = new DataTable();
            sqlda.Fill(r12);

            if (r12.Rows.Count > 0)
            {
                checkr12.BackColor = Color.Red;
                checkr12.Enabled = false;
            }
            else { checkr12.Enabled = true;
                checkr12.BackColor = Color.ForestGreen; }

            //check Room 13
            string checkr013 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "13" + "' and checkedOUT='" + "NO" + "'";
            con.Open();
            sqlda = new SqlDataAdapter(checkr013, con);
            con.Close();
            DataTable r13 = new DataTable();
            sqlda.Fill(r13);

            if (r13.Rows.Count > 0)
            {
                checkr13.BackColor = Color.Red;
                checkr13.Enabled = false;
            }
            else { checkr13.Enabled = true; checkr13.BackColor = Color.ForestGreen; }

            //check Room 14
            string checkr014 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "14" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr014, con);
            con.Close();
            DataTable r14 = new DataTable();
            sqlda.Fill(r14);

            if (r14.Rows.Count > 0)
            {
                checkr14.BackColor = Color.Red;
                checkr14.Enabled = false;
            }
            else { checkr14.Enabled = true; checkr14.BackColor = Color.ForestGreen; }

            //check Room 15
            string checkr015 = "SELECT * FROM RoomReserve where(((Arrival_Date <= '" + fromDate + "' and Departure_Date >= '" + toDate + "') OR (Departure_Date >= '" + fromDate + "' and Departure_Date <= '" + toDate + "') OR (Arrival_Date>= '" + fromDate + "' and Arrival_Date <= '" + toDate + "'))and (Departure_Date !='" + fromDate + "')and(Arrival_Date !='" + toDate + "') )and RoomID = '" + "15" + "'and checkedOUT='" + "NO" + "' ";
            con.Open();
            sqlda = new SqlDataAdapter(checkr015, con);
            con.Close();
            DataTable r15 = new DataTable();
            sqlda.Fill(r15);

            if (r15.Rows.Count > 0)
            {
                checkr15.BackColor = Color.Red;
                checkr15.Enabled = false;
            }
            else { checkr15.Enabled = true; checkr15.BackColor = Color.ForestGreen; }

            
        }

        private void btnhome1_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

       

        private void rbpassport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbpassport.Checked == true) { idtype = "Passport"; }
            else { idtype = "NIC"; }
        }
    }
}
