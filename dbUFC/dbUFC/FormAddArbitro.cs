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
    public partial class FormAddArbitro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddArbitro()
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
            AddArbitro();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddArbitro();
        }

        private void AddArbitro()
        {
            Arbitro arb = new Arbitro();
            List<Arbitro> la = dc.Arbitros.ToList();
            arb.Nome = bunifuTextbox1.text.Trim();
            arb.Cognome = bunifuTextbox3.text.Trim();
            arb.CodiceFiscale = bunifuTextbox5.text.Trim();
            arb.Telefono = bunifuTextbox12.text.Trim();
            arb.Classe = bunifuTextbox4.text.Trim();
            arb.CodiceTesseraArbitro = bunifuTextbox9.text.Trim();
            arb.NumeroPresenzeIncontriUfficiali = bunifuTextbox2.text.Trim();
            if(CheckIfNotNullAttributes(arb))
            {
                return;
            }
            foreach ( Arbitro a in la )
            {
                if(arb.CodiceFiscale.Trim() == a.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo arbitro è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Arbitros.InsertOnSubmit(arb);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Inserimento non riuscito.");
            }
            MessageBox.Show("Il nuovo arbitro è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Arbitro arb)
        {
            if((arb.Nome.Length == 0) || (arb.Cognome.Length == 0) || (arb.CodiceFiscale.Length == 0) || (arb.Telefono.Length == 0)
                || (arb.Classe.Length == 0) || (arb.CodiceTesseraArbitro.Length == 0) || (arb.NumeroPresenzeIncontriUfficiali.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
