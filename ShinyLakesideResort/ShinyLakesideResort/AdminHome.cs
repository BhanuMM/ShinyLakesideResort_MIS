using System;
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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }
     

        

        

        private void btnroomreslog_Click(object sender, EventArgs e)
        {
            RoomreservationsLOG roomreslog = new RoomreservationsLOG();
            this.Hide();
            roomreslog.Show();
        }

        private void btnrestra_Click(object sender, EventArgs e)
        {
            RestaurantTrans restrans = new RestaurantTrans();
            this.Hide();
            restrans.Show();
        }

        private void btnrechallbook_Click(object sender, EventArgs e)
        {
            reseptionhalllog reshall = new reseptionhalllog();
            this.Hide();
            reshall.Show();
        }

        private void btnempdet_Click(object sender, EventArgs e)
        {
            EMPLOYERDETAILS2 empdel = new EMPLOYERDETAILS2();
            this.Hide();
            empdel.Show();
            
        }

        private void btnaddrem_Click(object sender, EventArgs e)
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

        private void roomReservationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomreservationsLOG roomreslog = new RoomreservationsLOG();
            this.Hide();
            roomreslog.Show();
        }

        private void receptionHallBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reseptionhalllog reshall = new reseptionhalllog();
            this.Hide();
            reshall.Show();
        }

        private void restaurantTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestaurantTrans restrans = new RestaurantTrans();
            this.Hide();
            restrans.Show();
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

        private void AdminHome_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
