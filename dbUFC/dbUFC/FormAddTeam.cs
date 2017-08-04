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
    public partial class FormAddTeam : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();
        int _CodiceTeam;
       
        public int CodiceTeam
        {
            get { return _CodiceTeam; }
            set { _CodiceTeam = value; }
        }

        public FormAddTeam()
        {
            InitializeComponent();
        }

        private void AddAtletaButton_Click(object sender, EventArgs e)
        {
            SetVisibleAddTrainerButton(true);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            SetVisibleAddTrainerButton(true);
        }

        private void SetVisibleAddTrainerButton(bool value)
        {
            FormAddAllenatore team = new FormAddAllenatore();
            team.Visible = true;
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddTeam()
        {
            Team tea = new Team();
            List<Team> lt = dc.Teams.ToList();
            tea.CodiceTeam = SetCodiceTeam();
            CodiceTeam = int.Parse(tea.CodiceTeam);
            tea.NomeTeam = bunifuTextbox1.text.Trim();
            tea.CodiceFiscaleAllenatore = bunifuTextbox3.text.Trim();
            if (bunifuTextbox2.text.Trim().Length != 0)
            {
                List<Sponsor> ls = dc.Sponsors.ToList();
               if(!ContainsSponsor(ls, bunifuTextbox2.text.Trim()))
                {
                    MessageBox.Show("Lo sponsor inserito non esiste. Inserimento non riuscito.");
                    return;
                }
                SponsorizzazioneTeam sp = new SponsorizzazioneTeam();
                sp.CodiceTeam = tea.CodiceTeam.Trim();
                sp.NomeSponsor = bunifuTextbox2.text.Trim();

                this.dc.SponsorizzazioneTeams.InsertOnSubmit(sp);
            }

            if (CheckIfNotNullAttributes(tea))
            {
                return;
            }

            foreach (Team t in lt)
            {
                if (tea.CodiceFiscaleAllenatore.Trim() == t.CodiceFiscaleAllenatore.Trim())
                {
                    MessageBox.Show("Questo allenatore fa già parte di un team. Inserimento non riuscito.");
                    return;
                }
            }

            if (!CheckIfContainsForeignKey(dc.Allenatores.ToList(), tea.CodiceFiscaleAllenatore))
            {
                MessageBox.Show("Il codice fiscale inserito non appartiene a nessun'allenatore.");
                return;
            }
            this.dc.Teams.InsertOnSubmit(tea);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo team è stato aggiunto correttamente.");
            bunifuImageButton1.Visible = true;
        }

        private bool CheckIfNotNullAttributes(Team tea)
        {
            if ((tea.NomeTeam.Length == 0) || (tea.CodiceFiscaleAllenatore.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private string SetCodiceTeam()
        {
            int codToSet = 0;
            List<Team> lcat = dc.Teams.ToList();
            foreach (Team t in lcat)
            {
                if (int.Parse(t.CodiceTeam) > codToSet)
                {
                    codToSet = int.Parse(t.CodiceTeam);
                }
            }
            return (codToSet + 1).ToString().Trim();

        }

        private bool CheckIfContainsForeignKey(List<Allenatore> all, string fk)
        {
            foreach (Allenatore a in all)
            {
                if(a.CodiceFiscale.Trim() == fk)
                {
                    return true;
                }
            }
            return false;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            FormAddAllenatore al = new FormAddAllenatore();
            al.Visible = true;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            FormAddSponsor sp = new FormAddSponsor();
            sp.Visible = true;
        }

        public bool ContainsSponsor(List<Sponsor> spo, string sponsorName)
        {
            int counter = 0;
            foreach(Sponsor s in spo)
            {
                if(s.NomeSponsor.Trim() == sponsorName )
                {
                    counter++;
                }
            }
            return counter > 0;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        select S;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            AddTeam();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
                
                List<Sponsor> ls = dc.Sponsors.ToList();
                if (!ContainsSponsor(ls, bunifuTextbox2.text.Trim()))
                {
                    MessageBox.Show("Lo sponsor inserito non esiste. Inserimento non riuscito.");
                    return;
                }
                SponsorizzazioneTeam sp = new SponsorizzazioneTeam(); 
                sp.CodiceTeam = CodiceTeam.ToString();
                sp.NomeSponsor = bunifuTextbox2.text.Trim();
                this.dc.SponsorizzazioneTeams.InsertOnSubmit(sp);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Inserimento non effettuato.");
                Close();
                return;
            }
            MessageBox.Show("Lo Sponsor al Team è stato aggiunto con successo.");
          
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            var query = from A in dc.Allenatores
                        select A;
            bunifuCustomDataGrid2.DataSource = query;
        }
    }
}
