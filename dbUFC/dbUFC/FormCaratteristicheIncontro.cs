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
    public partial class FormCaratteristicheIncontro : Form
    {
        public FormCaratteristicheIncontro()
        {
            InitializeComponent();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            FormViewArbitri varbitri = new FormViewArbitri();
            varbitri.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCaratteristicheAtletaInIncontro atl = new FormCaratteristicheAtletaInIncontro();
            atl.Visible = true;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            FormCaratteristicheAtletaInIncontro atl = new FormCaratteristicheAtletaInIncontro();
            atl.Visible = true;
        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
