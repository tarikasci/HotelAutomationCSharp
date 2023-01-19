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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }
        RoomORM rORM = new RoomORM();
        RoomTypeORM rtORM = new RoomTypeORM();
        private void ListRooms()
        {
            dataGridView1.DataSource = rORM.Select();
            dataGridView1.Columns["Id"].Visible= false;
            dataGridView1.Columns["RoomTypeID"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            ListRooms();
            cmbRoomType.DataSource = rtORM.Select();
            cmbRoomType.ValueMember = "Id";
            cmbRoomType.DisplayMember = "Name";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Rooms r = new Rooms();
            r.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            r.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            r.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            r.RoomTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RoomTypeID"].Value);
            bool result = rORM.Update(r);
            if (result)
            {
                MessageBox.Show("The room has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListRooms();
            }
            else
            {
                MessageBox.Show("The room could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListRooms();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms r = new Rooms();
            r.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            r.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            r.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            r.RoomTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RoomTypeID"].Value);
            bool result = rORM.Delete(r);
            if (result)
            {
                MessageBox.Show("The room has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListRooms();
            }
            else
            {
                MessageBox.Show("The room could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Rooms r = new Rooms();
            r.Name = txtName.Text;
            r.Description = txtDescription.Text;
            r.RoomTypeID = (int)cmbRoomType.SelectedValue;
            bool result = rORM.Insert(r);
            if (result)
            {
                MessageBox.Show("The room has been successfully added", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListRooms();
                txtName.Clear();
                txtDescription.Clear();
                cmbRoomType.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("The room could not be added", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
