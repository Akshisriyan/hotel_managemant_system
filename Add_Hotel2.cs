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
    public partial class Add_Hotel2 : MetroFramework.Forms.MetroForm
    {
        Database db = new Database();
        String ghotel_id;
        String ghotel_name;
        String gcity;
        String gabout;
        String gaddress;
        public Add_Hotel2(String hotel_id, String hotel_name, String city, String about, String address)
        {
            InitializeComponent();
            txt_ah2_hotel_id.Text = hotel_id;
            txt_ah2_hotel_name.Text = hotel_name;
            txt_ah2_hotel_id.ReadOnly = true;
            txt_ah2_hotel_name.ReadOnly = true;

            ghotel_id = hotel_id;
            ghotel_name = hotel_name;
            gcity = city;
            gabout = about;
            gaddress = address;
        }

        private void Add_Hotel2_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_ah2_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ah2_room_type.Text))
            {
                MetroMessageBox.Show(this, "Please Enter Room Type!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah2_facilities.Text))
            {
                MetroMessageBox.Show(this, "Please Enter Facilities!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah2_rate.Text))
            {
                MetroMessageBox.Show(this, "Please Enter Rate!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah2_available_room.Text))
            {
                MetroMessageBox.Show(this, "Please Available Rooms!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_ah2_rate.Text.Any(c => char.IsLetter(c)))
            {
                MetroMessageBox.Show(this, "Rate can not contain Letters!", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!txt_ah2_rate.Text.Any(c => char.IsDigit(c)))
            {
                MetroMessageBox.Show(this, "Rate can not contain Letters or Symbols!", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_ah2_available_room.Text.Any(c => char.IsLetter(c)))
            {
                MetroMessageBox.Show(this, "Available Room can not contain Letters!", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!txt_ah2_available_room.Text.Any(c => char.IsDigit(c)))
            {
                MetroMessageBox.Show(this, "Available Room can not contain Letters or Symbols!", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_ah2_available_room.Text.Any(c => char.IsPunctuation(c)))
            {
                MetroMessageBox.Show(this, "Available Room can contain Full Numbers only!", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grid_ah2_rooms.Rows.Add(txt_ah2_room_type.Text, txt_ah2_available_room.Text, txt_ah2_rate.Text, txt_ah2_facilities.Text);
                txt_ah2_room_type.Clear();
                txt_ah2_facilities.Clear();
                txt_ah2_rate.Clear();
                txt_ah2_available_room.Clear();
            }
        }

        private void btn_ah2_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Hotel1 fbook2 = new Add_Hotel1();
            fbook2.ShowDialog();
            this.Close();
        }

        private void btn_ah2_add2_Click(object sender, EventArgs e)
        {
           try
            {
                if (grid_ah2_rooms.Rows.Count == 0)
                {
                    MetroMessageBox.Show(this, "no selected orders!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int ret = db.save_delete_update("insert into hotel values('" + ghotel_id + "','" + ghotel_name + "', '" + gcity + "', '" + gaddress + "', '" + gabout + "')");
                    if(ret == 1)
                    {
                        for (int i = 0; i < grid_ah2_rooms.Rows.Count; i++)
                        {
                            string type = grid_ah2_rooms.Rows[i].Cells[0].Value + string.Empty;
                            string rooms = grid_ah2_rooms.Rows[i].Cells[1].Value + string.Empty;
                            string rate = grid_ah2_rooms.Rows[i].Cells[2].Value + string.Empty;
                            string facilities = grid_ah2_rooms.Rows[i].Cells[3].Value + string.Empty;

                            db.save_delete_update("insert into hotel_details (type, facilities, rate, available_rooms, hotel_id) values('" + type + "', '" + facilities + "', '" + rate + "', '" + rooms + "', '" + ghotel_id + "')");
                        }

                        grid_ah2_rooms.Rows.Clear();
                        MessageBox.Show(this, "Insert Successfuly!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        this.Hide();
                        Add_Hotel1 fbook2 = new Add_Hotel1();
                        fbook2.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ah_clear_Click(object sender, EventArgs e)
        {
            txt_ah2_room_type.Clear();
            txt_ah2_facilities.Clear();
            txt_ah2_rate.Clear();
            txt_ah2_available_room.Clear();
            grid_ah2_rooms.Rows.Clear();
        }
    }
}
