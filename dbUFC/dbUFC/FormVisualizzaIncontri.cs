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
    public partial class FormVisualizzaIncontri : Form
    {

        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormVisualizzaIncontri()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCaratteristicheIncontro car = new FormCaratteristicheIncontro();
            car.Visible = true;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormVisualizzaIncontri_Load(object sender, EventArgs e)
        {
            var query = from I in dc.ProgrammazioneIncontros
                        select I;
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
