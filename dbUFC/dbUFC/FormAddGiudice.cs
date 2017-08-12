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
    public partial class FormAddGiudice : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddGiudice()
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
            AddGudice();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddGudice();
        }

        private void AddGudice()
        {
            Giudice giu = new Giudice();
            List<Giudice> la = dc.Giudices.ToList();
            giu.Nome = bunifuTextbox1.text.Trim();
            giu.Cognome = bunifuTextbox3.text.Trim();
            giu.CodiceFiscale = bunifuTextbox5.text.Trim();
            giu.Telefono = bunifuTextbox12.text.Trim();
            giu.CodiceCartellinoGiudice= bunifuTextbox9.text.Trim();
            giu.NumeroIncotriGiudicati = bunifuTextbox2.text.Trim();

            if (CheckIfNotNullAttributes(giu))
            {
                return;
            }
            foreach (Giudice g in la)
            {
                if (giu.CodiceFiscale.Trim() == g.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo giudice è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Giudices.InsertOnSubmit(giu);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il nuovo giudice è stato aggiunto correttamente.");
            Close();
        }

        private bool CheckIfNotNullAttributes(Giudice arb)
        {
            if ((arb.Nome.Length == 0) || (arb.Cognome.Length == 0) || (arb.CodiceFiscale.Length == 0) || (arb.Telefono.Length == 0)
                || (arb.CodiceCartellinoGiudice.Length == 0) || (arb.NumeroIncotriGiudicati.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FormAddGiudice_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = from G in dc.Giudices select G;
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {
            DeleteGiudice();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            DeleteGiudice();
        }

        private void DeleteGiudice()
        {
            if ((bunifuCustomDataGrid2.SelectedCells.Count > 1) || (bunifuCustomDataGrid2.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo la riga del giudice da eliminare. Modifica non effettuata.");
                Close();
                return;
            }
            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];
            string cfGiudice = Convert.ToString(selectedRow.Cells["CodiceFiscale"].Value);
            foreach (Giudice g in dc.Giudices.ToList())
            {
                if(g.CodiceFiscale.Trim() == Convert.ToString(selectedRow.Cells["CodiceFiscale"].Value).Trim()) {
                    dc.Giudices.DeleteOnSubmit(g);
                }
            }
            try
            {
                dc.SubmitChanges();
            } catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati. Eliminazione non effettuata.");
                return;
            }
            MessageBox.Show("Giudice eliminato con successo.");
            Close();
        }
    }
}
