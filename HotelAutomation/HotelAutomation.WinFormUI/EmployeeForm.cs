using HotelAutomation.ORM;
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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }
        EmployeeORM eORM = new EmployeeORM();
        private void ListEmployees()
        {
            dataGridView1.DataSource = eORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ListEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.Name = txtName.Text;
            emp.Surname = txtSurname.Text;
            emp.IdentityNO = txtIdentityNo.Text;
            emp.Phone = txtPhoneNo.Text;
            emp.Address = txtAddress.Text;
            emp.BirthDate = dtpBirthDate.Value;
            emp.HireDate = dtpHireDate.Value;
            emp.Salary = numSalary.Value;
            emp.UserName = txtUsername.Text;
            emp.Password = txtPassword.Text;
            bool result = eORM.Insert(emp);
            if (result)
            {
                MessageBox.Show("The employee has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListEmployees();
                txtName.Clear();
                txtSurname.Clear();
                txtIdentityNo.Clear();
                txtAddress.Clear();
                txtPhoneNo.Clear();
                dtpBirthDate.Value = DateTime.Now;
                dtpHireDate.Value = DateTime.Now;
                numSalary.Value = 0;
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("The employee could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Employees emp = new Employees();
            emp.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            emp.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            emp.IdentityNO = Convert.ToString(dataGridView1.CurrentRow.Cells["IdentityNO"].Value);
            emp.Phone = Convert.ToString(dataGridView1.CurrentRow.Cells["Phone"].Value);
            emp.Address = Convert.ToString(dataGridView1.CurrentRow.Cells["Address"].Value);
            emp.BirthDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BirthDate"].Value);
            emp.HireDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["HireDate"].Value);
            emp.Salary = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Salary"].Value);
            emp.UserName = Convert.ToString(dataGridView1.CurrentRow.Cells["UserName"].Value);
            emp.Password = Convert.ToString(dataGridView1.CurrentRow.Cells["Password"].Value);
            bool result = eORM.Update(emp);
            if (result)
            {
                MessageBox.Show("The employee has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListEmployees();
            }
            else
            {
                MessageBox.Show("The employee could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListEmployees();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Employees emp = new Employees();
                emp.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                emp.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                emp.IdentityNO = Convert.ToString(dataGridView1.CurrentRow.Cells["IdentityNO"].Value);
                emp.Phone = Convert.ToString(dataGridView1.CurrentRow.Cells["Phone"].Value);
                emp.Address = Convert.ToString(dataGridView1.CurrentRow.Cells["Address"].Value);
                emp.BirthDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BirthDate"].Value);
                emp.HireDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["HireDate"].Value);
                emp.Salary = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Salary"].Value);
                emp.UserName = Convert.ToString(dataGridView1.CurrentRow.Cells["UserName"].Value);
                emp.Password = Convert.ToString(dataGridView1.CurrentRow.Cells["Password"].Value);
                bool result = eORM.Delete(emp);
                if (result)
                {
                    MessageBox.Show("The employee has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListEmployees();
                }
                else
                {
                    MessageBox.Show("The employee could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
