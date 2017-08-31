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
    public partial class FormViewEntrateEUscitecs : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormViewEntrateEUscitecs()
        {
            InitializeComponent();
        }

        private void FormViewEntrateEUscitecs_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = from EU in dc.EntrataUscitas
                                               select new
                                               {
                                                   CFAtleta = EU.CodiceFiscaleAtleta,
                                                   EntrataOUscita = EU.EntrataOUscita,
                                                   CodiceTeam = EU.CodiceTeam,
                                                   Data = EU.Data
                                               };
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
