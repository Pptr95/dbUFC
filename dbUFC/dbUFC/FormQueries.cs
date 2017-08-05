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
    public partial class FormQueries : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormQueries()
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
           
            var query = from C in dc.CaratteristicheIncontros
                        where C.Data.Equals(bunifuDatepicker1.Value)
                        select C;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            /*select AVG(DATEDIFF(yyyy, (a.AnnoNascita), GETDATE()))
            from Atleta a*/

            List<int> list = new List<int>();
            foreach (Atleta a in dc.Atletas.ToList())
            {
                list.Add(int.Parse(a.AnnoNascita.Trim()));
            }
            var query = list.Average();
            MessageBox.Show("" + query);
            bunifuCustomDataGrid1.DataSource = query;
        }

    }
}
