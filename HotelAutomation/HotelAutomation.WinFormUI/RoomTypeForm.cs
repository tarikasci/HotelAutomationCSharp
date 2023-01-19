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
    public partial class RoomTypeForm : Form
    {
        public RoomTypeForm()
        {
            InitializeComponent();
        }
        RoomTypeORM rtORM = new RoomTypeORM();
        private void ListRoomTypes()
        {
            dataGridView1.DataSource = rtORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }
        private void RoomTypeForm_Load(object sender, EventArgs e)
        {
            ListRoomTypes();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                RoomTypes rt = new RoomTypes();
                rt.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                rt.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                rt.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
                bool result = rtORM.Delete(rt);
                if (result)
                {
                    MessageBox.Show("The room type has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListRoomTypes();
                }
                else
                {
                    MessageBox.Show("The room type could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomTypes rt = new RoomTypes();
            rt.Name = txtName.Text;
            rt.Description = txtDescription.Text;
            bool result = rtORM.Insert(rt);
            if (result)
            {
                MessageBox.Show("The room type has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListRoomTypes();
                txtName.Clear();
                txtDescription.Clear();
            }
            else
            {
                MessageBox.Show("The room type could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RoomTypes rt = new RoomTypes();
            rt.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            rt.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            rt.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            bool result = rtORM.Update(rt);
            if (result)
            {
                MessageBox.Show("The room type has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListRoomTypes();
            }
            else
            {
                MessageBox.Show("The room type could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListRoomTypes();
            }
        }
    }
}
