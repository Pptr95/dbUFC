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
        dbUFCDataContext dc;

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
            this.dc = new dbUFCDataContext();
            Sponsor spo = new Sponsor();
            List<Sponsor> ls = dc.Sponsors.ToList();
            /*   List<string> str = new List<string>();
               foreach(var v in ls)
               {
                   str.Add(v.NomeSposor.ToString());
                   MessageBox.Show(v.NomeSposor.ToString());
               }
               MessageBox.Show(""+str[0].Length);
               string str1 = bunifuTextbox1.text;
               MessageBox.Show(str1);
               foreach ( string s in str)
               {
                   if(s == str1)
                   {
                       MessageBox.Show("ok");
                   }
               }
               this.dc.Sponsors.InsertOnSubmit(spo);
               this.dc.SubmitChanges();
               MessageBox.Show("The new sponsor has been added correctly.");
               */
            spo.NomeSposor = bunifuTextbox1.text;
            //string trimmed = "careteam order4-26-11.csv".Replace(" ", string.Empty);
            string trim = ls[0].NomeSposor.Replace(" ", string.Empty);
            MessageBox.Show("" + trim.Length);

            if(spo.NomeSposor == trim)
            {
                MessageBox.Show("Ok!!!");
            }



        }
    }
}
