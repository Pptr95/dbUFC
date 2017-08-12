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
    public partial class FormAddSponsorToTeam : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddSponsorToTeam()
        {
            InitializeComponent();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        select S;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var query = from T in dc.Teams
                        select T;
            bunifuCustomDataGrid2.DataSource = query;
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {
            AddSponsorToTeam();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            AddSponsorToTeam();
        }
        private void AddSponsorToTeam()
        {

            if ((bunifuCustomDataGrid1.SelectedCells.Count > 1) || (bunifuCustomDataGrid1.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga per Sponsor e solo una per Team. Modifica non effettuata.");
                Close();
                return;
            }
                int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

                string nomeSponsor = Convert.ToString(selectedRow.Cells["NomeSponsor"].Value);
                

                if ((bunifuCustomDataGrid2.SelectedCells.Count > 1) || (bunifuCustomDataGrid2.SelectedCells.Count == 0))
                {
                    MessageBox.Show("Selezionare solo una riga per Sponsor e solo una per Team. Modifica non effettuata.");
                    Close();
                    return;
                }
                
                    int selectedrowindex2 = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow2 = bunifuCustomDataGrid2.Rows[selectedrowindex2];

                    string codiceTeam = Convert.ToString(selectedRow2.Cells["CodiceTeam"].Value);

            SponsorizzazioneTeam st = new SponsorizzazioneTeam();
            st.NomeSponsor = nomeSponsor.Trim();
            st.CodiceTeam = codiceTeam.Trim();
            this.dc.SponsorizzazioneTeams.InsertOnSubmit(st);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception) {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati inseriti. Modifica non effettuata.");
                Close();
                return;
            }
            MessageBox.Show("Lo sponsor è stato aggiunto al team con successo.");
        }
    }
}
