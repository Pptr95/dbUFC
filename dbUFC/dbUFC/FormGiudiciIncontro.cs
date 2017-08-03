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
    public partial class FormGiudiciIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormGiudiciIncontro()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            AddGiudiceInIncontro();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            AddGiudiceInIncontro();
        }

        private void AddGiudiceInIncontro()
        {
            Giudica si = new Giudica();
            List<Giudica> lsi = dc.Giudicas.ToList();
            si.CodiceCaratteristicheIncontro = new FormCaratteristicheIncontro().SetCodiceCaratteristicheIncontro()-1;
            si.CodiceFiscaleGiudice = bunifuTextbox1.text.Trim();

            this.dc.Giudicas.InsertOnSubmit(si);
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
            MessageBox.Show("Il giudice che ha giudicato è stato inserito correttamente.");
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
