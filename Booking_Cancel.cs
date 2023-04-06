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
    public partial class Booking_Cancel : MetroFramework.Forms.MetroForm
    {
        Database db = new Database();
        public Booking_Cancel()
        {
            InitializeComponent();
        }

        private void btn_bc_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txt_bc_id.Text.Any(c => char.IsDigit(c)))
                {
                    MetroMessageBox.Show(this, "Booking ID Cant Be Letter Or Special Character!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db = new Database();
                    DataTable dt = db.GetData("SELECT b.*, h.hotel_name FROM booking b INNER JOIN hotel h ON b.hotel_id = h.hotel_id WHERE b.booking_id = '" + txt_bc_id.Text + "' ");
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            txt_cb_booking_id.Text = dr["booking_id"].ToString();
                            txt_bc_hotel_name.Text = dr["hotel_name"].ToString();
                            txt_cb_customer_name.Text = dr["customer_name"].ToString();
                            txt_cb_address.Text = dr["address"].ToString();
                            txt_cb_telephone.Text = dr["phone_number"].ToString();
                            txt_cb_nic.Text = dr["nic"].ToString();
                            datetime_cb_birth_date.Text = dr["birth_date"].ToString();
                            cmb_cb_gender.Items.Clear();
                            cmb_cb_gender.Items.Add(dr["gender"].ToString());
                            cmb_cb_gender.SelectedIndex = 0;
                            cmb_cb_type.Items.Clear();
                            cmb_cb_type.Items.Add(dr["room_type"].ToString());
                            cmb_cb_type.SelectedIndex = 0;
                            txt_cb_number_of_rooms.Text = dr["number_of_rooms"].ToString();
                            datetime_cb_check_in_date.Text = dr["check_in_date"].ToString();
                            datetime_cb_check_out_date.Text = dr["check_out_date"].ToString();
                        }

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "There is no booking details accompanied with the given booking id", "Invalid booking id", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Booking_Cancel_Load(object sender, EventArgs e)
        {
            txt_bc_id.Focus();
        }


        private void btn_cb_clear_Click(object sender, EventArgs e)
        {
            txt_bc_id.Clear();
            txt_cb_booking_id.Clear();
            txt_bc_hotel_name.Clear();
            txt_cb_customer_name.Clear();
            txt_cb_address.Clear();
            txt_cb_telephone.Clear();
            txt_cb_nic.Clear();
            datetime_cb_birth_date.ResetText();
            cmb_cb_gender.Items.Clear();
            cmb_cb_gender.SelectedIndex = -1;
            cmb_cb_type.Items.Clear();
            cmb_cb_type.SelectedIndex = -1;
            txt_cb_number_of_rooms.Clear();
            datetime_cb_check_in_date.ResetText();
            datetime_cb_check_out_date.ResetText();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fbook2 = new Home();
            fbook2.ShowDialog();
            this.Close();
        }

        private void txt_bc_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_cb_booking_id.Text))
                {
                    MetroMessageBox.Show(this, "Plese Select Record To Cancel", "Emplty Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int ret = db.save_delete_update("delete from booking where booking_id = '" + txt_cb_booking_id.Text + "'");
                    if (ret == 1)
                    {
                        txt_cb_booking_id.Clear();
                        txt_bc_hotel_name.Clear();
                        txt_cb_customer_name.Clear();
                        txt_cb_address.Clear();
                        txt_cb_telephone.Clear();
                        txt_cb_nic.Clear();
                        datetime_cb_birth_date.ResetText();
                        cmb_cb_gender.Items.Clear();
                        cmb_cb_gender.SelectedIndex = -1;
                        cmb_cb_type.Items.Clear();
                        cmb_cb_type.SelectedIndex = -1;
                        txt_cb_number_of_rooms.Clear();
                        datetime_cb_check_in_date.ResetText();
                        datetime_cb_check_out_date.ResetText();
                        MetroMessageBox.Show(this, "Booking Cancel Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Booking Cancel Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
