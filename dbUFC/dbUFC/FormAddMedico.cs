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
    public partial class FormAddMedico : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddMedico()
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
            AddMedico();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddMedico();
        }

        private void AddMedico()
        {
            Medico med = new Medico();
            List<Medico> la = dc.Medicos.ToList();
            med.Nome = bunifuTextbox1.text.Trim();
            med.Cognome = bunifuTextbox3.text.Trim();
            med.CodiceFiscale = bunifuTextbox5.text.Trim();
            med.Telefono = bunifuTextbox12.text.Trim();
            med.OspedaleProvenienza = bunifuTextbox9.text.Trim();
            med.Specilizzazione = bunifuTextbox2.text.Trim();

            if (CheckIfNotNullAttributes(med))
            {
                return;
            }
            foreach (Medico g in la)
            {
                if (med.CodiceFiscale.Trim() == g.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo medico è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Medicos.InsertOnSubmit(med);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo medico è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Medico arb)
        {
            if ((arb.Nome.Length == 0) || (arb.Cognome.Length == 0) || (arb.CodiceFiscale.Length == 0) || (arb.Telefono.Length == 0)
                || (arb.OspedaleProvenienza.Length == 0) || (arb.Specilizzazione.Length == 0))
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
