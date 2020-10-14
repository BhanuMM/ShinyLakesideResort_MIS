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
    public partial class HomeMenu : Form
    {
        public HomeMenu()
        {
            InitializeComponent();
            Timer tim = new Timer();
            tim.Interval = 5000;
            tim.Tick += new EventHandler(changeimage);
            tim.Start();
        }

        private void changeimage(object sender, EventArgs e)
        {
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.a127fe02_z);
            b1.Add(Properties.Resources.hikkaduwa_shiny_lakeside_resort_14961500176);
            b1.Add(Properties.Resources._408357_13111416570017483665);
            int index = DateTime.Now.Second % b1.Count;
            pictureBox1.Image = b1[index];
        }

        private void HomeMenu_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
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

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void roomReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomReservationMain roommain = new RoomReservationMain();
            this.Hide();
            roommain.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnrest_Click(object sender, EventArgs e)
        {
            Restaurantnew rest = new Restaurantnew();
            this.Hide();
            rest.Show();
        }

        private void btnroomres_Click(object sender, EventArgs e)
        {
            RoomReservationMain roommain = new RoomReservationMain();
            this.Hide();
            roommain.Show();
        }

        private void btnreception_Click(object sender, EventArgs e)
        {
            ReceptionMain mainrec = new ReceptionMain();
            this.Hide();
            mainrec.Show();
        }

        private void receptionHallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionMain mainrec = new ReceptionMain();
            this.Hide();
            mainrec.Show();
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }
    }
}
