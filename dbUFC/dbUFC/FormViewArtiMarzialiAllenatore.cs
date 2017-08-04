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
    public partial class FormViewArtiMarzialiAllenatore : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormViewArtiMarzialiAllenatore()
        {
            InitializeComponent();
        }

        private void FormViewArtiMarzialiAllenatore_Load(object sender, EventArgs e)
        {
            ExecQuery();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            AddArteMarzialePraticata();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            AddArteMarzialePraticata();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddArteMarzialePraticata()
        {
            ArteMarzialePraticata art = new ArteMarzialePraticata();
            List<ArteMarzialePraticata> la = dc.ArteMarzialePraticatas.ToList();
            art.CodiceFiscaleAllenatore = bunifuTextbox2.text.Trim();
            art.ArteMarziale = bunifuTextbox4.text.Trim();
            if ((art.CodiceFiscaleAllenatore.Length == 0) || (art.ArteMarziale.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return;
            }
            foreach (ArteMarzialePraticata a in la)
            {
                if ((art.CodiceFiscaleAllenatore.Trim() == a.CodiceFiscaleAllenatore.Trim()) &&
                    (art.ArteMarziale.Trim() == a.ArteMarziale.Trim()))
                {
                    MessageBox.Show("Questa arte marziale è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.ArteMarzialePraticatas.InsertOnSubmit(art);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("La nuova arte marziale è stata aggiunta correttamente.");
            ExecQuery();
        }

        private void ExecQuery()
        {
            //classic join query
            var query = from A in dc.Allenatores
                        join M in dc.ArteMarzialePraticatas on A.CodiceFiscale equals M.CodiceFiscaleAllenatore
                        select new { A.CodiceFiscale, A.Nome, A.Cognome, M.ArteMarziale };
            bunifuCustomDataGrid2.DataSource = query;
        }
    }
}
