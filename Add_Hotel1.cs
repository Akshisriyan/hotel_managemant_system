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
    public partial class Add_Hotel1 : MetroFramework.Forms.MetroForm
    {
        public Add_Hotel1()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Add_Hotel1_Load(object sender, EventArgs e)
        {
            IdIncrement();
        }

        private void IdIncrement()
        {
            try
            {
                txt_ah1_hotel_name.Focus();
                DataTable dt = db.GetData("select top 1 hotel_id from hotel order by hotel_id desc");
                if(dt.Rows.Count == 0)
                {
                    txt_ah1_hotel_id.Text = 1.ToString();
                }
                else
                {
                    int no = Int32.Parse(dt.Rows[0][0].ToString());
                    no++;
                    txt_ah1_hotel_id.Text = no.ToString();
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Error on load ID!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ah1_hotel_id.Text))
            {
                MetroMessageBox.Show(this, "Hotel ID Empty. Please Check Database Connection!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah1_hotel_name.Text))
            {
                MetroMessageBox.Show(this, "Please Enter Hotel Name!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah1_city.Text))
            {
                MetroMessageBox.Show(this, "Please Enter City!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah1_about.Text))
            {
                MetroMessageBox.Show(this, "Please Enter About!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txt_ah1_address.Text))
            {
                MetroMessageBox.Show(this, "Please Enter Address!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                Add_Hotel2 fbook2 = new Add_Hotel2(txt_ah1_hotel_id.Text, txt_ah1_hotel_name.Text, txt_ah1_city.Text, txt_ah1_about.Text, txt_ah1_address.Text);
                fbook2.ShowDialog();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fbook2 = new Home();
            fbook2.ShowDialog();
            this.Close();
        }
    }
}
