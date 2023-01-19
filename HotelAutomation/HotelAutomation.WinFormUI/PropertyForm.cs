using HotelAutomation.ORM.Entity;
using HotelAutomation.ORM;
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
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
        }
        PropertyORM pORM = new PropertyORM();
        private void ListProperties()
        {
            dataGridView1.DataSource = pORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            ListProperties();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ORM.Entity.Properties p = new ORM.Entity.Properties();
            p.Name = txtName.Text;
            p.Description = txtDescription.Text;
            bool result = pORM.Insert(p);
            if (result)
            {
                MessageBox.Show("The property has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListProperties();
                txtName.Clear();
                txtDescription.Clear();
            }
            else
            {
                MessageBox.Show("The property could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ORM.Entity.Properties p = new ORM.Entity.Properties();
            p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            p.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            p.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            bool result = pORM.Update(p);
            if (result)
            {
                MessageBox.Show("The property has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListProperties();
            }
            else
            {
                MessageBox.Show("The property could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListProperties();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ORM.Entity.Properties p = new ORM.Entity.Properties();
            p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            p.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            p.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            bool result = pORM.Delete(p);
            if (result)
            {
                MessageBox.Show("The property has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListProperties();
            }
            else
            {
                MessageBox.Show("The property could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
