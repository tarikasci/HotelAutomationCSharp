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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UnitTypeForm ut = new UnitTypeForm();
        private void unitTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ut.MdiParent = this;
            if (ut.IsDisposed)
            {
                ut = new UnitTypeForm();
            }
            ut.Show();
        }
        CaseForm cf = new CaseForm();
        private void caseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cf.MdiParent = this;
            if (cf.IsDisposed)
            {
                cf = new CaseForm();
            }
            cf.Show();
        }
        CategoryForm cat = new CategoryForm();
        private void categoriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cat.MdiParent = this;
            if (cat.IsDisposed)
            {
                cat = new CategoryForm();
            }
            cat.Show();
        }
        ProductForm pf = new ProductForm();
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pf.IsDisposed)
            {
                pf = new ProductForm();
            }
            pf.MdiParent = this;
            pf.Show();
        }
        RoomForm rf = new RoomForm();   
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rf.IsDisposed)
            {
                rf = new RoomForm();
            }
            rf.MdiParent= this;
            rf.Show();
        }
        RoomTypeForm rtf = new RoomTypeForm();
        private void roomTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtf.IsDisposed)
            {
                rtf = new RoomTypeForm();
            }
            rtf.MdiParent = this;
            rtf.Show();
        }
        RoomPropertyForm rpf = new RoomPropertyForm();
        private void roomPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rpf.IsDisposed)
            {
                rpf = new RoomPropertyForm();
            }
            rpf.MdiParent = this;
            rpf.Show();
        }
        PropertyForm prf = new PropertyForm();
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (prf.IsDisposed)
            {
                prf = new PropertyForm();
            }
            prf.MdiParent = this;
            prf.Show();
        }
        CustomerForm cstf = new CustomerForm();
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cstf.IsDisposed)
            {
                cstf = new CustomerForm();
            }
            cstf.MdiParent = this;
            cstf.Show();
        }
        EmployeeForm empf = new EmployeeForm();
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empf.IsDisposed)
            {
                empf = new EmployeeForm();
            }
            empf.MdiParent = this;
            empf.Show();
        }
        SalesForm sf = new SalesForm();
        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sf.IsDisposed)
            {
                sf = new SalesForm();
            }
            sf.MdiParent = this;
            sf.Show();
        }
    }
}
