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
    public partial class RoomReservationMain : Form
    {
        public RoomReservationMain()
        {
            InitializeComponent();
        }

        private void RoomReservationMain_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void btnhome1_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void btnback1_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeMenu hm = new HomeMenu();
            this.Hide();
            hm.Show();
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

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            
                ReserveRoomDetails roomdet = new ReserveRoomDetails();
                this.Hide();
                roomdet.Show();
            
        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            CheckOut cout = new CheckOut();
            cout.Show();
            this.Hide();
        }

        private void btnreserve_Click(object sender, EventArgs e)
        {
            ReserveRoomDetails roomdet = new ReserveRoomDetails();
            this.Hide();
            roomdet.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain rest = new ReceptionMain();
            this.Hide();
            rest.Show();
        }
    }
}
