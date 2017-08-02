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
    public partial class FormAddPsicologo : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddPsicologo()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddPsicologo();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddPsicologo();
        }

        private void AddPsicologo()
        {
            Pisicologo psi = new Pisicologo();
            List<Pisicologo> lp = dc.Pisicologos.ToList();
            psi.Nome = bunifuTextbox1.text.Trim();
            psi.Cognome = bunifuTextbox3.text.Trim();
            psi.CodiceFiscale = bunifuTextbox5.text.Trim();
            psi.Telefono = bunifuTextbox12.text.Trim();
            psi.Specializzazione = bunifuTextbox9.text.Trim();
            psi.CodiceTeam = bunifuTextbox2.text.Trim();
            
            if (CheckIfNotNullAttributes(psi))
            {
                return;
            }

            List<Team> lt = dc.Teams.ToList();
            if (!ContainsTeam(lt, psi.CodiceTeam))
            {
                MessageBox.Show("Il team con il codice inserito non esiste. Inserimento non riuscito.");
                return;
            }

            foreach (Pisicologo p in lp)
            {
                if (psi.CodiceFiscale.Trim() == p.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo psicologo è già presente e fa già parte di un team. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Pisicologos.InsertOnSubmit(psi);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo psicologo è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Pisicologo pi)
        {
            if ((pi.Nome.Length == 0) || (pi.Cognome.Length == 0) || (pi.CodiceFiscale.Length == 0) || (pi.Telefono.Length == 0)
                || (pi.Specializzazione.Length == 0) || (pi.CodiceTeam.Length == 0) )
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContainsTeam(List<Team> lt, string CodiceTeam)
        {
            int counter = 0;
            foreach (Team t in lt)
            {
                if (t.CodiceTeam.Trim() == CodiceTeam)
                {
                    counter++;
                }
            }
            return counter > 0;
        }
    }
}
