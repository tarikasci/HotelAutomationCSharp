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
    public partial class CaseForm : Form
    {
        public CaseForm()
        {
            InitializeComponent();
        }
        CaseORM cORM = new CaseORM();
        public void ListCases()
        {
            dataGridView1.DataSource = cORM.Select();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["isActive"].Visible = false;
        }
        private void CaseForm_Load(object sender, EventArgs e)
        {
            ListCases();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cases c = new Cases();
            c.Name = txtCaseName.Text;
            c.Description = txtDescription.Text;
            bool result = cORM.Insert(c);
            if (result)
            {
                MessageBox.Show("The case has been successfully added","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ListCases();
                txtCaseName.Clear();
                txtDescription.Clear();
            }
            else
            {
                MessageBox.Show("The case could not be added","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Cases c = new Cases();
            c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
            c.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
            bool result = cORM.Update(c);
            if (result)
            {
                MessageBox.Show("The case has been successfully updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListCases();
            }
            else
            {
                MessageBox.Show("The case could not be updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListCases();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Cases c = new Cases();
                c.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                c.Name = Convert.ToString(dataGridView1.CurrentRow.Cells["Name"].Value);
                c.Description = Convert.ToString(dataGridView1.CurrentRow.Cells["Description"].Value);
                bool result = cORM.Delete(c);
                if (result)
                {
                    MessageBox.Show("The case has been successfully deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListCases();
                }
                else
                {
                    MessageBox.Show("The case could not be deleted", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
