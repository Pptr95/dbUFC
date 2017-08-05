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
    public partial class FormOpzioni : Form
    {
        public FormOpzioni()
        {
            InitializeComponent();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            FormAddSponsorToTeam tta = new FormAddSponsorToTeam();
            tta.Visible = true;
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            FormViewArtiMarzialiAllenatore vm = new FormViewArtiMarzialiAllenatore();
            vm.Visible = true;
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            FormAddSponsorToCaratteristicaIncontro sci = new FormAddSponsorToCaratteristicaIncontro();
            sci.Visible = true;
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            FormAddGiudiceAtCaratteristicheIncontro addg = new FormAddGiudiceAtCaratteristicheIncontro();
            addg.Visible = true;
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            FormAddMedicoAtCaratteristicheIncontro addm = new FormAddMedicoAtCaratteristicheIncontro();
            addm.Visible = true;
        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
