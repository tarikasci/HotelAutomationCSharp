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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        CustomerORM cORM = new CustomerORM();
        private void ListCustomers()
        {
            dataGridView1.DataSource = cORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ListCustomers();
            cmbMaritalStatus.DataSource = Enum.GetNames(typeof(MaritalStatusType));
            cmbGender.DataSource = Enum.GetNames(typeof(GenderType));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.Name = txtName.Text;
            c.Surname = txtSurname.Text;
            c.CompanyName= txtCompanyName.Text;
            c.IdentityNO = txtIdentityNo.Text;
            c.Phone = txtPhoneNo.Text;
            c.BirthDate = dtpBirthDate.Value;
            c.MaritalStatus = (MaritalStatusType)Enum.Parse(typeof(MaritalStatusType), cmbMaritalStatus.SelectedItem.ToString());
            c.Gender = (GenderType)Enum.Parse(typeof(GenderType), cmbGender.SelectedItem.ToString());
            bool result = cORM.Insert(c);
            if (result)
            {
                MessageBox.Show("The customer has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCustomers();
                txtName.Clear();
                txtSurname.Clear();
                txtCompanyName.Clear();
                txtIdentityNo.Clear();
                txtPhoneNo.Clear();
                cmbGender.SelectedIndex = 0;
                cmbMaritalStatus.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("The customer could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Customers c = new Customers();
            c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            c.Surname = Convert.ToString(dataGridView1.CurrentRow.Cells["Surname"].Value);
            c.CompanyName = Convert.ToString(dataGridView1.CurrentRow.Cells["Company Name"].Value);
            c.IdentityNO = Convert.ToString(dataGridView1.CurrentRow.Cells["Identity Number"].Value);
            c.Phone = Convert.ToString(dataGridView1.CurrentRow.Cells["Phone Number"].Value);
            c.BirthDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Birth Date"].Value);
            c.MaritalStatus = (MaritalStatusType)Enum.Parse(typeof(MaritalStatusType), Convert.ToString(dataGridView1.CurrentRow.Cells["Marital Status"].Value));
            c.Gender = (GenderType)Enum.Parse(typeof(GenderType), Convert.ToString(dataGridView1.CurrentRow.Cells["Gender"].Value));
            bool result = cORM.Update(c);
            if (result)
            {
                MessageBox.Show("The customer has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCustomers();
            }
            else
            {
                MessageBox.Show("The customer could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListCustomers();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            c.Surname = Convert.ToString(dataGridView1.CurrentRow.Cells["Surname"].Value);
            c.CompanyName = Convert.ToString(dataGridView1.CurrentRow.Cells["CompanyName"].Value);
            c.IdentityNO = Convert.ToString(dataGridView1.CurrentRow.Cells["IdentityNO"].Value);
            c.Phone = Convert.ToString(dataGridView1.CurrentRow.Cells["Phone"].Value);
            c.BirthDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BirthDate"].Value);
            c.MaritalStatus = (MaritalStatusType)Enum.Parse(typeof(MaritalStatusType), Convert.ToString(dataGridView1.CurrentRow.Cells["MaritalStatus"].Value));
            c.Gender = (GenderType)Enum.Parse(typeof(GenderType), Convert.ToString(dataGridView1.CurrentRow.Cells["Gender"].Value));
            bool result = cORM.Delete(c);
            if (result)
            {
                MessageBox.Show("The customer has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCustomers();
            }
            else
            {
                MessageBox.Show("The customer could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
