﻿using System;
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
                    MessageBox.Show("Questo sponsor è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Sponsors.InsertOnSubmit(spo);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il nuovo sponsor è stato aggiunto correttamente.");
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        select S;
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
