﻿using System;
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
    public partial class RoomreservationsLOG : Form
    {
        public RoomreservationsLOG()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=WHITEWOLF-PC\SQLEXPRESS;Initial Catalog=ShinyLakesideResort;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();

        private void btnadhome_Click(object sender, EventArgs e)
        {
            AdminHome adhome = new AdminHome();
            this.Hide();
            adhome.Show();
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

        private void RoomreservationsLOG_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");

            string loaddata = "Select * from RoomReserve order by Arrival_Date";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dataGridView1.DataSource = dset.Tables["Reservation"];
        }

         

           

       

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dset.Reset();


             string loaddata = "Select * from RoomReserve Where Arrival_Date='"+dtpchkin.Value.ToString()+"'order by RoomID";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dataGridView1.DataSource = dset.Tables["Reservation"];
        }

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            dset.Reset();
            string loaddata = "Select * from RoomReserve Where RoomID='" + cmbroom.SelectedItem + "' order by Arrival_Date";
            con.Open();
            sqlda = new SqlDataAdapter(loaddata, con);
            sqlda.Fill(dset, "Reservation");
            con.Close();

            dataGridView1.DataSource = dset.Tables["Reservation"];
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }
    }
}
