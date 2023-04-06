using MetroFramework;
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
    public partial class View_Booking : MetroFramework.Forms.MetroForm
    {
        Database db = new Database();
        public View_Booking()
        {
            InitializeComponent();
        }

        private void btn_vb_search_Click(object sender, EventArgs e)
        {
            try
            {
                grid_ah2_rooms.Rows.Clear();
                db = new Database();
                    DataTable dt = db.GetData("SELECT * FROM booking b INNER JOIN hotel h ON b.hotel_id = h.hotel_id WHERE b.check_in_date > = '" + datetime_vb_from_date.Value.ToString() + "' AND b.check_out_date <= '" + datetime_vb_to_date.Value.ToString() + "'");
                    if (dt.Rows.Count > 0)
                    {


                        foreach (DataRow dr in dt.Rows)
                        {
                            DateTime bd = Convert.ToDateTime(dr["birth_date"]);
                            DateTime cid = Convert.ToDateTime(dr["check_in_date"]);
                            DateTime cod = Convert.ToDateTime(dr["check_out_date"]);
                            grid_ah2_rooms.Rows.Add(dr["hotel_name"].ToString(), dr["customer_name"].ToString(), dr["address"].ToString(), dr["phone_number"].ToString(), dr["nic"].ToString(), bd.ToShortDateString(), dr["gender"].ToString(), dr["room_type"].ToString(), dr["number_of_rooms"].ToString(), cid.ToShortDateString(), cod.ToShortDateString());
                        }

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "There is no Records", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void View_Booking_Load(object sender, EventArgs e)
        {

        }

        private void btn_view_booking_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fbook2 = new Home();
            fbook2.ShowDialog();
            this.Close();
        }

        private void btn_vb_search_bboking_id_Click(object sender, EventArgs e)
        {
            grid_ah2_rooms.Rows.Clear();
            if (txt_vb_booking_id.Text.Any(c => char.IsDigit(c)))
            {
                db = new Database();
                DataTable dt = db.GetData("SELECT * FROM booking b INNER JOIN hotel h ON b.hotel_id = h.hotel_id WHERE b.booking_id = '" + txt_vb_booking_id.Text.ToString() + "'");
                if (dt.Rows.Count > 0)
                {


                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime bd = Convert.ToDateTime(dr["birth_date"]);
                        DateTime cid = Convert.ToDateTime(dr["check_in_date"]);
                        DateTime cod = Convert.ToDateTime(dr["check_out_date"]);
                        grid_ah2_rooms.Rows.Add(dr["hotel_name"].ToString(), dr["customer_name"].ToString(), dr["address"].ToString(), dr["phone_number"].ToString(), dr["nic"].ToString(), bd.ToShortDateString(), dr["gender"].ToString(), dr["room_type"].ToString(), dr["number_of_rooms"].ToString(), cid.ToShortDateString(), cod.ToShortDateString());
                    }

                }
                else
                {
                    MetroMessageBox.Show(this, "There is no Record", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
