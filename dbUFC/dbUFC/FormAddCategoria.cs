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
    public partial class FormAddCategoria : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();
        int _CodiceCategoria = 0;
        public int CodiceCategoria
        {
            get { return _CodiceCategoria; }
            set
            {
                if(value == _CodiceCategoria+1)
                {
                    _CodiceCategoria = value;
                }
            }
        }

        public FormAddCategoria()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void Todelete() // this is the insert of sponsor. Just take a look to implement insert Categoria. TODELETE
        {
            Sponsor spo = new Sponsor();
            List<Sponsor> ls = dc.Sponsors.ToList();
            spo.NomeSposor = bunifuTextbox1.text.Trim();
            if (spo.NomeSposor.Length == 0)
            {
                MessageBox.Show("Inserisci il nome di uno sponsor.");
                return;
            }
            foreach (Sponsor s in ls)
            {
                if (s.NomeSposor.Trim() == spo.NomeSposor)
                {
                    MessageBox.Show("Questo sponsor è già presente. Inserimento non riuscito");
                    return;
                }
            }

            this.dc.Sponsors.InsertOnSubmit(spo);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo sponsor è stato aggiunto correttamente.");
        }
}
}
