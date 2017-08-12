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
    public partial class FormEntrataUscita : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();
        public const string ENTRATA = "Entrata";
        public const string USCITA = "Uscita";

        public FormEntrataUscita()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {
            //bunifuCustomLabel9.Text = bunifuDatepicker1.Value.ToString("yyyy-MM-dd"); test for date format
            Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {
            AddEntrataUscita();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AddEntrataUscita();
        }

        private void AddEntrataUscita()
        {
            EntrataUscita eu = new EntrataUscita();
            List<EntrataUscita> leu = dc.EntrataUscitas.ToList();
            eu.CodiceFiscaleAtleta = bunifuTextbox1.text.Trim();
            eu.EntrataOUscita = bunifuTextbox2.text.Trim();
            eu.CodiceTeam = bunifuTextbox3.text.Trim();
            eu.Data = bunifuDatepicker1.Value;

            if((eu.EntrataOUscita != ENTRATA) && (eu.EntrataOUscita != USCITA))
            {
                MessageBox.Show("Inserire nel campo dell'entrata/uscita la parola 'Entrata' per eseguire un'entrata" + "\n" +
                    "o 'Uscita' per eseguire un'uscita. Inserimento non riuscito.");
                return;
            }

            if(!ContainsAtleta(eu.CodiceFiscaleAtleta))
            {
                MessageBox.Show("Il codice fiscale inserito non appartine e nessun'atleta. Inserimento non  riuscito.");
                return;
            }

            if(CheckIfNotNullAttributes(eu))
            {
                return;
            }
            try
            {

                if (!UpdateAtleta(eu.CodiceFiscaleAtleta, eu.EntrataOUscita, eu.CodiceTeam))
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i campi ed assicurarsi che un atleta non deve appartenere" + 
                    "a nessun Team se vuole fare un'Entrata e che se vuole fare un'Uscita allora deve appartenere ad un Team."
                    + "Inserimento non riuscito.");
                return;
            }
            this.dc.EntrataUscitas.InsertOnSubmit(eu);
                this.dc.SubmitChanges();
            } catch (Exception)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Inserimento esegito correttamente.");
        }

        private bool CheckIfNotNullAttributes(EntrataUscita eu)
        {
            if ((eu.CodiceFiscaleAtleta.Length == 0) || (eu.EntrataOUscita.Length == 0) || (eu.CodiceTeam.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var query = from A in dc.Atletas
                        select A;
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            var query = from T in dc.Teams
                        select T;
            bunifuCustomDataGrid2.DataSource = query;
        }

        private bool UpdateAtleta(string cfAtleta, string entrataOrUscita, string codTeam)
        {
           
            List<Atleta> la = dc.Atletas.ToList();
            foreach(Atleta a in la)
            {
                if ((a.CodiceFiscale.Trim() == cfAtleta) && (string.Equals(entrataOrUscita, USCITA) && a.CodiceTeam.Trim() == codTeam))
                {
                    a.CodiceTeam = null;
                    return true;
                }
                if ((a.CodiceFiscale.Trim() == cfAtleta) && (string.Equals(entrataOrUscita, ENTRATA) && (a.CodiceTeam == null)))
                {
                    a.CodiceTeam = codTeam;
                    return true;
                } 
            }
            return false;
         }

        private bool ContainsAtleta(string cfAtleta)
        {
            foreach (Atleta a in dc.Atletas.ToList())
            {
                if (a.CodiceFiscale.Trim() == cfAtleta)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
