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
    public partial class FormEntrataUscita : Form
    {
        public FormEntrataUscita()
        {
            InitializeComponent();
        }


        //this is a test to test date picker format.
        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel9.Text = bunifuDatepicker1.Value.ToString("yyyy-MM-dd");
        }
    }
}
