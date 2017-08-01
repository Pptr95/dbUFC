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
              //  if(value == _CodiceCategoria+1)
              //  {
                    _CodiceCategoria = value;
               // }
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
            Categoria cat = new Categoria();
            List<Categoria> lcat = dc.Categorias.ToList();
            CodiceCategoria++;
            MessageBox.Show("" + CodiceCategoria);
            cat.CodiceCategoria = CodiceCategoria.ToString().Trim();
            cat.NomeCategoria = bunifuTextbox3.text.Trim();
            cat.Descrizione = bunifuTextbox2.text.Trim();
            dc.Categorias.InsertOnSubmit(cat);
            dc.SubmitChanges();
            MessageBox.Show("la nuova categoria è stata aggiunta correttamente.");


        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //TODO
        }

       
    }
}
