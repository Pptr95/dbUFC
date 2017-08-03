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
    public partial class FormMediciInIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormMediciInIncontro()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            AddMedicoInIncontro();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            AddMedicoInIncontro();
        }

        private void AddMedicoInIncontro()
        {
            Medicazione md = new Medicazione();
            List<Medicazione> lsi = dc.Medicaziones.ToList();
            md.CodiceCaratteristicheIncontro = new FormCaratteristicheIncontro().SetCodiceCaratteristicheIncontro() - 1;
            md.CodiceFiscaleMedico = bunifuTextbox1.text.Trim();

            this.dc.Medicaziones.InsertOnSubmit(md);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il medico che ha medicato è stato inserito correttamente.");
        }
    }
}
