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
    public partial class UnitTypeForm : Form
    {
        public UnitTypeForm()
        {
            InitializeComponent();
        }
        UnitTypeORM utORM = new UnitTypeORM();
        private void ListUnitTypes()
        {
            dataGridView1.DataSource = utORM.Select();
            dataGridView1.Columns["Id"].Visible= false;
            dataGridView1.Columns["isActive"].Visible = false;
        }

        private void UnitTypeForm_Load(object sender, EventArgs e)
        {
            ListUnitTypes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnitTypes ut = new UnitTypes();
            ut.Name = txtUTName.Text;
            bool result = utORM.Insert(ut);
            if (result)
            {
                MessageBox.Show("The unit type has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListUnitTypes();
                txtUTName.Clear();
            }
            else
            {
                MessageBox.Show("The unit type could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UnitTypes ut = new UnitTypes();
            ut.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            ut.Name= Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            bool result = utORM.Update(ut);
            if (result)
            {
                MessageBox.Show("The unit type has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListUnitTypes();
            }
            else
            {
                MessageBox.Show("The unit type could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListUnitTypes();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                UnitTypes ut = new UnitTypes();
                ut.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                ut.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                bool result = utORM.Delete(ut);
                if (result)
                {
                    MessageBox.Show("The unit type has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListUnitTypes();
                }
                else
                {
                    MessageBox.Show("The unit type could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
