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
using System.Xml.Linq;

namespace HotelAutomation.WinFormUI
{
    public partial class RoomPropertyForm : Form
    {
        public RoomPropertyForm()
        {
            InitializeComponent();
        }
        

        private void RoomPropertyForm_Load(object sender, EventArgs e)
        {
            RoomORM rORM = new RoomORM();
            cmbRooms.DataSource = rORM.Select();
            cmbRooms.DisplayMember= "Name";
            cmbRooms.ValueMember= "Id";

            PropertyORM pORM = new PropertyORM();
            listProperties.DataSource= pORM.Select();
            listProperties.DisplayMember= "Name";
            listProperties.ValueMember= "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomPropertiesORM rpORM = new RoomPropertiesORM();
            RoomProperties rp = new RoomProperties();
            rp.RoomID = (int)cmbRooms.SelectedValue;
            rp.PropertyID = (int)listProperties.SelectedValue;
            short value;
            if (short.TryParse(txtValue.Text,out value))
            {
                rp.Value = value;
            }
            bool result = rpORM.Insert(rp);
            if (result)
            {
                MessageBox.Show("The property has been successfully added to the room", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValue.Clear();
            }
            else
            {
                MessageBox.Show("The property could not be added to the room", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
