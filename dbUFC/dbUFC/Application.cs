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
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public Application()
        {
            InitializeComponent();
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
            FormProgrammazioneIncontro pro = new FormProgrammazioneIncontro(this);
            pro.Visible = true;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            FormOpzioni fo = new dbUFC.FormOpzioni();
            fo.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCaratteristicheIncontro car = new FormCaratteristicheIncontro();
            car.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            UpdateIncontriProgrammati();
        }

        public void UpdateIncontriProgrammati()
        {
            var query = from P in dc.ProgrammazioneIncontros
                        select new
                        {
                            P.CodiceFiscaleAtleta1,
                            P.CodiceFiscaleAtleta2,
                            P.Data,
                            NumeroRound = P.CaratteristicheRound_NumeroRound,
                            MinutiPerRound = P.CaratteristicheRound_MinutiPerRound,
                            P.OraInizio,
                            P.Città,
                            P.Stato,
                            P.CostoIngresso
                        };
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
