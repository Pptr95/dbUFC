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
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            FormVisualizzaIncontri caratt = new FormVisualizzaIncontri();
            caratt.Visible = true;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            FormAddSponsorToTeam tta = new FormAddSponsorToTeam();
            tta.Visible = true;
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

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            FormViewArtiMarzialiAllenatore vm = new FormViewArtiMarzialiAllenatore();
            vm.Visible = true;
        }

        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FormAddAtleta form2 = new FormAddAtleta();
            form2.Visible = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            FormAddTeam team = new FormAddTeam();
            team.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            FormAddCategoria cat = new FormAddCategoria();
            cat.Visible = true;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            FormAddSponsor sponsor = new FormAddSponsor();
            sponsor.Visible = true;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            FormAddPersonale personale = new FormAddPersonale();
            personale.Visible = true;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            FormEntrataUscita team = new FormEntrataUscita();
            team.Visible = true;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            FormProgrammazioneIncontro pro = new FormProgrammazioneIncontro();
            pro.Visible = true;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
