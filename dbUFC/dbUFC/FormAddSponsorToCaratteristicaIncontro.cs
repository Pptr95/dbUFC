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
    public partial class FormAddSponsorToCaratteristicaIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddSponsorToCaratteristicaIncontro()
        {
            InitializeComponent();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        select C;
            bunifuCustomDataGrid2.DataSource = query;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        select S;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddSponsorToCaratteriticaAtletaAddSponsorToTeam()
        {

            if ((bunifuCustomDataGrid1.SelectedCells.Count > 1) || (bunifuCustomDataGrid1.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga per Sponsor e solo una per CaratteristicaIncontro. Modifica non effettuata.");
                Close();
                return;
            }
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            string nomeSponsor = Convert.ToString(selectedRow.Cells["NomeSponsor"].Value);


            if ((bunifuCustomDataGrid2.SelectedCells.Count > 1) || (bunifuCustomDataGrid2.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga per Sponsor e solo una per CaratteristicaIncontro. Modifica non effettuata.");
                Close();
                return;
            }

            int selectedrowindex2 = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow2 = bunifuCustomDataGrid2.Rows[selectedrowindex2];

            int codiceCar = int.Parse(Convert.ToString(selectedRow2.Cells["CodiceCaratteristicheIncontro"].Value));

            SponsorizzazioneIncontro si = new SponsorizzazioneIncontro();
            si.NomeSponsor = nomeSponsor.Trim();
            si.CodiceCaratteristicheIncontro = codiceCar;
            this.dc.SponsorizzazioneIncontros.InsertOnSubmit(si);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Modifica non effettuata.");
                Close();
                return;
            }
            MessageBox.Show("Lo sponsor è stato aggiunto alla caratteristica dell'incontro con successo.");
        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {
            AddSponsorToCaratteriticaAtletaAddSponsorToTeam();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            AddSponsorToCaratteriticaAtletaAddSponsorToTeam();
        }
    }
}
