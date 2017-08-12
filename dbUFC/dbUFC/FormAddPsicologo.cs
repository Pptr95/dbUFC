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
            Psicologo psi = new Psicologo();
            List<Psicologo> lp = dc.Psicologos.ToList();
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

            foreach (Psicologo p in lp)
            {
                if (psi.CodiceFiscale.Trim() == p.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo psicologo è già presente e fa già parte di un team. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Psicologos.InsertOnSubmit(psi);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il nuovo psicologo è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Psicologo pi)
        {
            if ((pi.Nome.Length == 0) || (pi.Cognome.Length == 0) || (pi.CodiceFiscale.Length == 0) || (pi.Telefono.Length == 0)
                || (pi.Specializzazione.Length == 0) || (pi.CodiceTeam.Length == 0) )
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito.");
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            var query = from T in dc.Teams
                        select T;
            bunifuCustomDataGrid1.DataSource = query; 
        }
    }
}
