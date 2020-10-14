﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinyLakesideResort
{
    public partial class ReceptionMain : Form
    {
        public ReceptionMain()
        {
            InitializeComponent();
        }

        private void btnhallres_Click(object sender, EventArgs e)
        {
            ReceptionHall rechall = new ReceptionHall();
            rechall.Show();
            this.Hide();
        }

        private void btnuphall_Click(object sender, EventArgs e)
        {
           updatereception uprechall = new updatereception();
            this.Hide();
            uprechall.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomReservationMain rm = new RoomReservationMain();
            this.Hide();
            rm.Show();
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

        private void btnhome1_Click(object sender, EventArgs e)
        {

            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void btnback1_Click(object sender, EventArgs e)
        {

            HomeMenu roomm = new HomeMenu();
            this.Hide();
            roomm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

       

      

       

       

        private void ReceptionMain_Load_3(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}
