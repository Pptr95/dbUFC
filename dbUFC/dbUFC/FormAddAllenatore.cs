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
    public partial class FormAddAllenatore : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddAllenatore()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddAllenatore();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddAllenatore();
        }

        private void AddAllenatore()
        {
            Allenatore all = new Allenatore();
            List<Allenatore> la = dc.Allenatores.ToList();
            all.Nome = bunifuTextbox1.text.Trim();
            all.Cognome = bunifuTextbox3.text.Trim();
            all.CodiceFiscale = bunifuTextbox5.text.Trim();
            all.Telefono = bunifuTextbox12.text.Trim();
            all.TesseraClasseAllenatore = bunifuTextbox9.text.Trim();
            
            if (CheckIfNotNullAttributes(all))
            {
                return;
            }
            foreach (Allenatore a in la)
            {
                if (all.CodiceFiscale == a.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo allenatore è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Allenatores.InsertOnSubmit(all);
            try
                {
                this.dc.SubmitChanges();
            } catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il nuovo allenatore è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(Allenatore all)
        {
            if ((all.Nome.Length == 0) || (all.Cognome.Length == 0) || (all.CodiceFiscale.Length == 0) || (all.Telefono.Length == 0)
                || (all.TesseraClasseAllenatore.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            AddArteMarzialePraticata();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            AddArteMarzialePraticata();
        }

        private void AddArteMarzialePraticata()
        {
            ArteMarzialePraticata art = new ArteMarzialePraticata();
            List<ArteMarzialePraticata> la = dc.ArteMarzialePraticatas.ToList();
            art.CodiceFiscaleAllenatore = bunifuTextbox2.text.Trim();
            art.ArteMarziale = bunifuTextbox4.text.Trim();
            if((art.CodiceFiscaleAllenatore.Length == 0) || (art.ArteMarziale.Length == 0))
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
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("La nuova arte marziale è stata aggiunta correttamente.");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            var query = from A in dc.Allenatores
                        select A;
            bunifuCustomDataGrid2.DataSource = query;
        }
    }
}
