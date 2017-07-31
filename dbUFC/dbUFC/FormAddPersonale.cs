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
    public partial class FormAddPersonale : Form
    {
        public FormAddPersonale()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiPsicologoButton(true);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiPsicologoButton(true);
        }

        private void SetVisibleAggiungiPsicologoButton(bool value)
        {
            FormAddPsicologo psi = new FormAddPsicologo();
            psi.Visible = true;
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiFifioterapistaButton(true);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiFifioterapistaButton(true);
        }

        private void SetVisibleAggiungiFifioterapistaButton(bool value)
        {
            FormAddFisioterapista fisio = new FormAddFisioterapista();
            fisio.Visible = true;
        }

        private void bunifuCustomLabel15_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiArbitroButton(true);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            SetVisibleAggiungiArbitroButton(true);
        }

        private void SetVisibleAggiungiArbitroButton(bool value)
        {
            FormAddArbitro arbitro = new FormAddArbitro();
            arbitro.Visible = true;
        }
    }
}
