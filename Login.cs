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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register fbook2 = new Register();
            fbook2.ShowDialog();
            this.Close();
        }

        private void btn_login_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_login_username.Text))
                {
                    MetroMessageBox.Show(this, "Please Enter UserName", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrWhiteSpace(txt_login_password.Text))
                {
                    MetroMessageBox.Show(this, "Please Enter Password", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Database db = new Database();
                    DataTable dt = db.GetData("select * from user_details where username='" + txt_login_username.Text + "' and password = '" + txt_login_password.Text + "'");
                    if (dt.Rows.Count == 1)
                    {
                        this.Hide();
                        Home fbook2 = new Home();
                        fbook2.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "The username and password that you've entered doesn't match any account.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
