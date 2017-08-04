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
            if (bunifuCustomDataGrid2.SelectedCells.Count == 0 || bunifuCustomDataGrid2.SelectedCells.Count > 1)
            {
                MessageBox.Show("Seleziona il codice (solo uno) della caratteristica incontro per inserire in medico."
                    + " Inserimento non riuscito.");
            }

            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];
            md.CodiceCaratteristicheIncontro = int.Parse(Convert.ToString(selectedRow.Cells["CodiceCaratteristicheIncontro"].Value));
            md.CodiceFiscaleMedico = bunifuTextbox1.text.Trim();

            this.dc.Medicaziones.InsertOnSubmit(md);
            try
            {
                this.dc.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il medico che ha medicato è stato inserito correttamente.");
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from M in dc.Medicos
                        select M;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        select C;
            bunifuCustomDataGrid2.DataSource = query;
        }
    }
}
