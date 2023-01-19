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
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            CustomerORM cORM = new CustomerORM();
            DataTable dt = cORM.Select();
            dt.Columns.Add("FullName");
            foreach (DataRow dr in dt.Rows)
            {
                dr["FullName"] = dr["Name"] + " " + dr["Surname"];
            }
            cmbCustomer.DataSource = dt;
            cmbCustomer.DisplayMember= "FullName";
            cmbCustomer.ValueMember= "Id";

            RoomORM rORM = new RoomORM();
            cmbRoom.DataSource = rORM.Select();
            cmbRoom.DisplayMember = "Name";
            cmbRoom.ValueMember= "Id";

            ProductORM pORM = new ProductORM();
            dataGridView1.DataSource= pORM.Select();
            dataGridView1.Columns["Id"].Visible=false;
            dataGridView1.Columns["isActive"].Visible=false;
        }

        private void btnAddtoSale_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please Select the Product");
                return;
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text = (listView1.Items.Count + 1).ToString();
            lvi.SubItems.Add(dataGridView1.CurrentRow.Cells["Name"].Value.ToString());
            lvi.SubItems.Add(numProductQuantity.Value.ToString());
            lvi.SubItems.Add(numProductPrice.Value.ToString());
            lvi.SubItems.Add(numDiscount.Value.ToString());
            lvi.Tag = dataGridView1.CurrentRow.Cells["Id"].Value;
            listView1.Items.Add(lvi);
            numDiscount.Value = 0;
            numProductQuantity.Value = 0;
            numProductPrice.Value = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count>0)
            {
                SalesORM sORM = new SalesORM();
                Sales s = new Sales();
                s.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                s.RoomID = Convert.ToInt32(cmbRoom.SelectedValue);
                s.EmployeeID = EmployeeORM.ActiveUser.Id;
                s.RoomPrice = numRoomPrice.Value;
                s.SaleDate = DateTime.Now;

                int sID = Convert.ToInt32(sORM.InsertScalar(s));
                if (sID > 0)
                {
                    SalesDetailORM sdORM = new SalesDetailORM();
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        SalesDetails sd = new SalesDetails();
                        sd.SaleID = sID;
                        sd.ProductID = Convert.ToInt32(lvi.Tag);
                        sd.Price = Convert.ToDecimal(lvi.SubItems[3].Text);
                        sd.Quantity = Convert.ToDouble(lvi.SubItems[2].Text);
                        sd.Discount = Convert.ToDouble(lvi.SubItems[4].Text);
                        sdORM.Insert(sd);
                    }
                    MessageBox.Show("Sucsessfully Saved");
                }
            }
            else
            {
                MessageBox.Show("You should add sales before saving.");
            }
        }
    }
}
