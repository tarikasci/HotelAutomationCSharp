using HotelAutomation.ORM.Entity;
using HotelAutomation.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelAutomation.WinFormUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeORM eORM= new EmployeeORM();
            Employees emp = new Employees();
            emp.UserName = txtUserName.Text;
            emp.Password= txtPassword.Text;
            Employees Active = eORM.Login(emp);
            if (Active == null)
            {
                MessageBox.Show("Wrong Username or Password! Try Again!!!!!!","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                EmployeeORM.ActiveUser = Active;
                Form1 fr = new Form1();
                this.Hide();
                fr.ShowDialog();
            }
        }
    }
}
