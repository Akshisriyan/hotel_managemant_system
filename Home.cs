using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_managemant_system
{
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void tile_home_add_hotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Hotel1 or1 = new Add_Hotel1();
            or1.ShowDialog();
            this.Close();
        }

        private void tile_home_add_booking_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Booking1 fbook2 = new Add_Booking1();
            fbook2.ShowDialog();
            this.Close();
        }

        private void tile_home_cancel_booking_Click(object sender, EventArgs e)
        {
            this.Hide();
            Booking_Cancel or1 = new Booking_Cancel();
            or1.ShowDialog();
            this.Close();
        }

        private void tile_home_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fbook2 = new Login();
            fbook2.ShowDialog();
            this.Close();
        }

        private void tile_view_booking_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Booking fbook2 = new View_Booking();
            fbook2.ShowDialog();
            this.Close();
        }

        private void tile_home_add_booking_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Add_Booking1 fbook2 = new Add_Booking1();
            fbook2.ShowDialog();
            this.Close();
        }
    }
}
