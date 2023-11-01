using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            var query = db.Employees.Where(x => x.Email == txtEmail.Text).Select(x => new EmployeeLoginDto
            {
                Email = x.Email,
                Password = x.Password,
            });

            var result = query.FirstOrDefault();

            if (result == null)
            {
                MessageBox.Show("帳號密碼錯誤");
                return;
            }
            if (result != null)
            {
                if (result.Password == txtPassword.Text)
                {
                    var frm = new FormHomePage();
                    frm.Owner = this;
                    this.Hide();
                    frm.Show();
                    txtEmail.Text = "";
                    txtPassword.Text = "";

                }
                else
                {
                    MessageBox.Show("帳號密碼錯誤");
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "xxx@gmail.com";
            txtPassword.Text = "123456";
        }
    }
}
