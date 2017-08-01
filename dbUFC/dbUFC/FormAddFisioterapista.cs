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
    public partial class FormAddFisioterapista : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddFisioterapista()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddFisioterapista();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddFisioterapista();
        }

        private void AddFisioterapista()
        {
            Fisioterapista fisio = new Fisioterapista();
            List<Fisioterapista> lf = dc.Fisioterapistas.ToList();
            fisio.Nome = bunifuTextbox1.text.Trim();
            fisio.Cognome = bunifuTextbox3.text.Trim();
            fisio.CodiceFiscale = bunifuTextbox5.text.Trim();
            fisio.Telefono = bunifuTextbox12.text.Trim();
            fisio.Specializzazione = bunifuTextbox9.text.Trim();
            fisio.CodiceTeam = bunifuTextbox2.text.Trim();
            fisio.OspedaleProvenienza = bunifuTextbox2.text.Trim();

            if (CheckIfNotNullAttributes(fisio))
            {
                return;
            }

            Team t = new Team();
            List<Team> lt = dc.Teams.ToList();
           if(!ContainsTeam(lt, fisio.CodiceTeam))
            {
                MessageBox.Show("Il team con il codice inserito non esiste. Inserimento non riuscito.");
                return;
            }

            foreach (Fisioterapista f in lf)
            {
                if (fisio.CodiceFiscale.Trim() == f.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo fisioterapista è già presente e fa già parte di un team. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Fisioterapistas.InsertOnSubmit(fisio);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo fisioterapista è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Fisioterapista fi)
        {
            if ((fi.Nome.Length == 0) || (fi.Cognome.Length == 0) || (fi.CodiceFiscale.Length == 0) || (fi.Telefono.Length == 0)
                || (fi.Specializzazione.Length == 0) || (fi.CodiceTeam.Length == 0) || (fi.OspedaleProvenienza.Length == 0))
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
