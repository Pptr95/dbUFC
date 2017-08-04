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
    public partial class FormViewArbitri : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormViewArbitri()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormViewArbitri_Load(object sender, EventArgs e)
        {
            var query = from A in dc.Arbitros
                        select A;
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
