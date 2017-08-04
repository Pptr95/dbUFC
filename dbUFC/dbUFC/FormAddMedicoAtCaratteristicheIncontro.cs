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
    public partial class FormAddMedicoAtCaratteristicheIncontro : Form
    {

        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddMedicoAtCaratteristicheIncontro()
        {
            InitializeComponent();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from M in dc.Medicos
                        select M;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        select C;
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
            AddMedicoAtCaratteristicheIncontro();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            AddMedicoAtCaratteristicheIncontro();
        }

        private void AddMedicoAtCaratteristicheIncontro()
        {

            if ((bunifuCustomDataGrid1.SelectedCells.Count > 1) || (bunifuCustomDataGrid1.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga per Medico e solo una per CaratteristicaIncontro. Modifica non effettuata");
                Close();
                return;
            }
            int selectedrowindex = bunifuCustomDataGrid1.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = bunifuCustomDataGrid1.Rows[selectedrowindex];

            string codiceFiscaleMedico = Convert.ToString(selectedRow.Cells["CodiceFiscale"].Value);


            if ((bunifuCustomDataGrid2.SelectedCells.Count > 1) || (bunifuCustomDataGrid2.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga per Medico e solo una per CaratteristicaIncontro. Modifica non effettuata.");
                Close();
                return;
            }

            int selectedrowindex2 = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow2 = bunifuCustomDataGrid2.Rows[selectedrowindex2];

            int codiceCar = int.Parse(Convert.ToString(selectedRow2.Cells["CodiceCaratteristicheIncontro"].Value));

            Medicazione me = new Medicazione();
            me.CodiceFiscaleMedico= codiceFiscaleMedico.Trim();
            me.CodiceCaratteristicheIncontro = codiceCar;
            this.dc.Medicaziones.InsertOnSubmit(me);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Modifica non effettuata.");
                Close();
                return;
            }
            MessageBox.Show("Il medico è stato aggiunto alla caratteristica dell'incontro con successo.");
        }
    }
}
