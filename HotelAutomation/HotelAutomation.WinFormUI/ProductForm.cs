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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        ProductORM pORM = new ProductORM();
        private void ListProducts()
        {
            dataGridView1.DataSource = pORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            CategoryORM cORM = new CategoryORM();
            UnitTypeORM utORM = new UnitTypeORM();
            cmbCategory.DataSource = cORM.Select();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
            cmbUnitType.DataSource = utORM.Select();
            cmbUnitType.ValueMember = "Id";
            cmbUnitType.DisplayMember = "Name";
            ListProducts();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Products p = new Products();
            p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            p.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            p.Price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Price"].Value);
            p.Quantity = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Quantity"].Value);
            p.CategoryID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryID"].Value);
            p.UnitTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UnitTypeID"].Value);
            bool result = pORM.Update(p);
            if (result)
            {
                MessageBox.Show("The product has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListProducts();
            }
            else
            {
                MessageBox.Show("The product could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListProducts();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Products p = new Products();
                p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                p.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                p.Price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Price"].Value);
                p.Quantity = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Quantity"].Value);
                p.CategoryID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryID"].Value);
                p.UnitTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UnitTypeID"].Value);
                bool result = pORM.Delete(p);
                if (result)
                {
                    MessageBox.Show("The product has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListProducts();
                }
                else
                {
                    MessageBox.Show("The product could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.Name = txtName.Text;
            p.Price = (decimal)numPrice.Value;
            p.Quantity = (double)numQuantity.Value;
            p.CategoryID = (int)cmbCategory.SelectedValue;
            p.UnitTypeID = (int)cmbUnitType.SelectedValue;
            bool result = pORM.Insert(p);
            if (result)
            {
                MessageBox.Show("The product has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListProducts();
                txtName.Clear();
                numPrice.Value = 0;
                numQuantity.Value = 0;
                cmbCategory.SelectedIndex = 0;
                cmbUnitType.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("The product could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
