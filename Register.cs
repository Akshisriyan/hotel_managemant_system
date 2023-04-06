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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_sign_up_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_register_un.Text))
                {
                    MetroMessageBox.Show(this, "Please Enter UserName", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrWhiteSpace(txt_register_password.Text))
                {
                    MetroMessageBox.Show(this, "Please Enter Password", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrWhiteSpace(txt_register_cp.Text))
                {
                    MetroMessageBox.Show(this, "Please Enter Confirm Password", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_register_cp.Text != txt_register_password.Text)
                {
                    MetroMessageBox.Show(this, "Password Confim Is Not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Database db = new Database();
                    int row = db.save_delete_update("insert into user_details values('" + txt_register_un.Text + "', '" + txt_register_password.Text + "')");
                    if (row == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Added Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_register_un.Clear();
                        txt_register_password.Clear();
                        txt_register_cp.Clear();
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_register_log_in_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fbook2 = new Login();
            fbook2.ShowDialog();
            this.Close();
        }
    }
}
