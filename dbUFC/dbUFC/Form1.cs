using System;
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
    public partial class Form1 : Form
    {
        private dbUFCDataContext dc;

        public Form1()
        {
            InitializeComponent();
            this.dc = new dbUFCDataContext();
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

     
    }
}
