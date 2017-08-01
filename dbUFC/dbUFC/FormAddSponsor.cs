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
    public partial class FormAddSponsor : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormAddSponsor()
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
            AddSponsor();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            AddSponsor();
        }

        private void AddSponsor()
        {
            Sponsor spo = new Sponsor();
            List<Sponsor> ls = dc.Sponsors.ToList();
            spo.NomeSponsor = bunifuTextbox1.text.Trim();
            if(spo.NomeSponsor.Length == 0)
            {
                MessageBox.Show("Inserisci il nome di uno sponsor.");
                return;
            }
            foreach (Sponsor s in ls)
            {
                if (s.NomeSponsor.Trim() == spo.NomeSponsor)
                {
                    MessageBox.Show("Questo sponsor è già presente. Inserimento non riuscito");
                    return;
                }
            }

            this.dc.Sponsors.InsertOnSubmit(spo);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo sponsor è stato aggiunto correttamente.");
        }
        //this is a test to remove instance in database
        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

            List<Sponsor> ls = dc.Sponsors.ToList();
            foreach( Sponsor s in ls)
            {
                if (s.NomeSponsor.Trim() == bunifuTextbox1.text.Trim())
                {
                    dc.Sponsors.DeleteOnSubmit(s);
                    dc.SubmitChanges();
                    MessageBox.Show("Il nuovo sponsor è stato rimosso correttamente.");
                    return;
                }
            }
            MessageBox.Show("Lo sponsor non è presente.");
        }
    }
}
