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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        CategoryORM catORM = new CategoryORM();
        private void ListCategories()
        {
            dataGridView1.DataSource = catORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.Name = txtCategoryName.Text;
            bool result = catORM.Insert(c);
            if (result)
            {
                MessageBox.Show("The category has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCategories();
            }
            else
            {
                MessageBox.Show("The category could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Categories c = new Categories();
            c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            bool result = catORM.Update(c);
            if (result)
            {
                MessageBox.Show("The category has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCategories();
            }
            else
            {
                MessageBox.Show("The category could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListCategories();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Categories c = new Categories();
                c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                bool result = catORM.Delete(c);
                if (result)
                {
                    MessageBox.Show("The category has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListCategories();
                }
                else
                {
                    MessageBox.Show("The category could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
