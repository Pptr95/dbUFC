﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbUFC
{
    public partial class FormAddSponsor : Form
    {
        dbUFCDataContext dc;

        public FormAddSponsor()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            this.dc = new dbUFCDataContext();
            Sponsor spo = new Sponsor();
            List<Sponsor> ls = dc.Sponsors.ToList();
            string str = (string) bunifuTextbox1.text;
            

            /*this.dc.Sponsors.InsertOnSubmit(spo);
            this.dc.SubmitChanges();
            MessageBox.Show("The new sponsor has been added correctly.");*/


        }
    }
}
