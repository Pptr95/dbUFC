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

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            FormAddArbitro arbitro = new FormAddArbitro();
            arbitro.Visible = true;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            FormAddGiudice giudice = new FormAddGiudice();
            giudice.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            FormAddMedico medico = new FormAddMedico();
            medico.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormAddFisioterapista fisio = new FormAddFisioterapista();
            fisio.Visible = true;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            FormAddPsicologo psi = new FormAddPsicologo();
            psi.Visible = true;
        }
    }
}
