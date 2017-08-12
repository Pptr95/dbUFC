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
    public partial class FormAddCategoria : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

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
            AddCategoria();
        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            AddCategoria();
        }

        private void AddCategoria()
        {
            Categoria cat = new Categoria();
            List<Categoria> lcat = dc.Categorias.ToList();
            cat.CodiceCategoria = SetCodiceCategoria();
            cat.NomeCategoria = bunifuTextbox3.text.Trim();
            cat.Descrizione = bunifuTextbox2.text.Trim();
            if ((cat.NomeCategoria.Length == 0) || (cat.Descrizione.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi per inserire una nuova categoria.");
                return;

            }
            dc.Categorias.InsertOnSubmit(cat);
            try
            {
                dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto, ricontrollare i dati. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("La nuova categoria è stata aggiunta correttamente.");
        }

        private string SetCodiceCategoria()
        {
            int codToSet = 0;
            List<Categoria> lcat = dc.Categorias.ToList();
            foreach (Categoria c in lcat)
            {
                if (int.Parse(c.CodiceCategoria) > codToSet)
                {
                    codToSet = int.Parse(c.CodiceCategoria);
                }
            }
            return (codToSet + 1).ToString();

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            var query = from C in dc.Categorias
                        select C;
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
