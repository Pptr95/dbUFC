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
    public partial class FormProgrammazioneIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormProgrammazioneIncontro()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = from A in dc.Atletas
                                               select A; // this is for testing. Change select A and create a custom select.
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddProgrammazioneIncontro();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddProgrammazioneIncontro();
        }

        private void AddProgrammazioneIncontro()
        {
            ProgrammazioneIncontro pro = new ProgrammazioneIncontro();
            List<ProgrammazioneIncontro> lpr = dc.ProgrammazioneIncontros.ToList();
            pro.CodiceFiscaleAtleta1 = bunifuTextbox1.text.Trim();
            pro.CodiceFiscaleAtleta2 = bunifuTextbox3.text.Trim();
            pro.Data = bunifuDatepicker1.Value;
            pro.CaratteristicheRound_NumeroRound = bunifuTextbox5.text.Trim();
            pro.CaratteristicheRound_MinutiPerRound = bunifuTextbox12.text.Trim();
            pro.OraInizio = bunifuTextbox9.text.Trim();
            pro.Città = bunifuTextbox2.text.Trim();
            pro.Stato = bunifuTextbox4.text.Trim();
            pro.CostoIngresso = bunifuTextbox6.text.Trim();

            if (CheckIfNotNullAttributes(pro))
            {
                return;
            }

            if (pro.CodiceFiscaleAtleta1 == pro.CodiceFiscaleAtleta2)
            {
                MessageBox.Show("Un'atleta non può sfidare sè stesso. Programmazione non riuscita.");
                return;
            }

            if(CheckIfPresent(lpr, pro.CodiceFiscaleAtleta1, pro.CodiceFiscaleAtleta2, pro.Data.ToShortDateString()))
            {
                MessageBox.Show("Questo incontro è già stato programmato. Programmazione non riuscita.");
                return;
            }
            if(!CheckIfAtletiExists(pro.CodiceFiscaleAtleta1, pro.CodiceFiscaleAtleta2))
            {
                MessageBox.Show("Ricontrollare i codici fiscali degli atleti. Programmazione non riuscita.");
                return;
            }
            this.dc.ProgrammazioneIncontros.InsertOnSubmit(pro);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception e)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }
            MessageBox.Show("Il nuovo incontro è stato programmato correttamente il: "+ pro.Data.ToShortDateString());
        }

        private bool CheckIfNotNullAttributes(ProgrammazioneIncontro arb)
        {
            if ((arb.CodiceFiscaleAtleta1.Length == 0) || (arb.CodiceFiscaleAtleta2.Length == 0)
                || (arb.CaratteristicheRound_NumeroRound.Length == 0) || (arb.CaratteristicheRound_MinutiPerRound.Length == 0) 
                || (arb.OraInizio.Length == 0) || (arb.Città.Length == 0) || (arb.Stato.Length == 0) || (arb.CostoIngresso.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfPresent(List<ProgrammazioneIncontro> lpr, string cfAtleta1, string cfAtleta2, string date)
        {
            foreach(ProgrammazioneIncontro p in lpr)
            {
                if(((p.CodiceFiscaleAtleta1.Trim() == cfAtleta1) && (p.CodiceFiscaleAtleta2.Trim() == cfAtleta2) && (p.Data.ToShortDateString() == date))
                    || ((p.CodiceFiscaleAtleta1.Trim() == cfAtleta2) && (p.CodiceFiscaleAtleta2.Trim() == cfAtleta1) && (p.Data.ToShortDateString() == date)))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfAtletiExists(string cfAtleta1, string cfAtleta2)
        {
            int counter = 0;
            foreach( Atleta a in dc.Atletas.ToList())
            {
                if ((a.CodiceFiscale.Trim() == cfAtleta1) || (a.CodiceFiscale.Trim() == cfAtleta2))
                {
                    counter++;
                }
            }
            return counter == 2;
        }
    }
}

