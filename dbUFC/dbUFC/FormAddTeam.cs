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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            AddTeam();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            AddTeam();
        }

        private void AddTeam()
        {
            Team tea = new Team();
            List<Team> lt = dc.Teams.ToList();
            tea.CodiceTeam = SetCodiceTeam();
            tea.NomeTeam = bunifuTextbox1.text.Trim();
            tea.CodiceFiscaleAllenatore = bunifuTextbox3.text.Trim();
            //tea.CodiceFiscale = bunifuTextbox5.text.Trim(); this in for the sponsor of team TODO.

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
            CodiceTeam++;
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
            return (codToSet + 1).ToString();

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
    }
}
