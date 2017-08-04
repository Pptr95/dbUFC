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
    public partial class FormCaratteristicheIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();
        int _CodiceCaratteristicheIncontro = 0;

        public int CodiceCaratteristicheIncontro
        {
            get { return _CodiceCaratteristicheIncontro; }
            set { _CodiceCaratteristicheIncontro = value; }
        }

        public FormCaratteristicheIncontro()
        {
            InitializeComponent();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            FormViewArbitri varbitri = new FormViewArbitri();
            varbitri.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCaratteristicheAtletaInIncontro atl = new FormCaratteristicheAtletaInIncontro();
            atl.Visible = true;
        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            FormGiudiciIncontro fg = new FormGiudiciIncontro();
            fg.Visible = true;
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddCaratteristicheIncontro();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddCaratteristicheIncontro();
        }

        private void AddCaratteristicheIncontro()
        {
            CaratteristicheIncontro car = new CaratteristicheIncontro();
            List<CaratteristicheIncontro> la = dc.CaratteristicheIncontros.ToList();
            car.CodiceCaratteristicheIncontro = SetCodiceCaratteristicheIncontro();
            car.CodiceFiscaleAtleta1 = bunifuTextbox1.text.Trim();
            car.CodiceFiscaleAtleta2 = bunifuTextbox3.text.Trim();
            car.Data = bunifuDatepicker1.Value;
            car.Descrizione = bunifuTextbox5.text.Trim();
            car.Pareggio = bunifuTextbox12.text.Trim();
            MessageBox.Show("Pareggio:" + car.Pareggio+".");
            car.Sconfitto = bunifuTextbox9.text.Trim();
            car.Vincitore = bunifuTextbox2.text.Trim();
            car.CodiceFiscaleArbitro = bunifuTextbox4.text.Trim();

            if(bunifuTextbox12.text.Trim().Length == 0 && bunifuTextbox9.text.Trim().Length == 0 && bunifuTextbox2.text.Trim().Length == 0)
            {
                MessageBox.Show("Almeno uno dei campi Pareggio, codice fiscalde dello Sconfitto e del Vincitore deve essere non vuoto." + "\n"
                    +"Inserimento non riuscito.");
            }

            if (bunifuTextbox6.text.Trim().Length != 0)
            {
                FormAddTeam f = new FormAddTeam();
                List<Sponsor> ls = dc.Sponsors.ToList();
                if (!f.ContainsSponsor(ls, bunifuTextbox6.text.Trim()))
                {
                    MessageBox.Show("Lo sponsor inserito non esiste. Inserimento non riuscito.");
                    return;
                }
                SponsorizzazioneIncontro sp = new SponsorizzazioneIncontro();
                sp.CodiceCaratteristicheIncontro = car.CodiceCaratteristicheIncontro;
                sp.NomeSponsor = bunifuTextbox6.text.Trim();
                this.dc.SponsorizzazioneIncontros.InsertOnSubmit(sp);
            }
            //Update record of atleti based on what is write in textboxs
            UpdateRecord(car.Pareggio, car.Sconfitto, car.Vincitore, car.CodiceFiscaleAtleta1, car.CodiceFiscaleAtleta2);
           
            this.dc.CaratteristicheIncontros.InsertOnSubmit(car);
            try
            {
                this.dc.SubmitChanges();
            } catch(Exception)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non effettutato."
                    +"\n");
                Close();
                return;
            }
            MessageBox.Show("La caratteristica all'incontro è stata inserita correttamente.");
            CodiceCaratteristicheIncontro++;
        }

        public int SetCodiceCaratteristicheIncontro()
        {
            int codToSet = 0;
            List<CaratteristicheIncontro> lcar = dc.CaratteristicheIncontros.ToList();
            foreach (CaratteristicheIncontro c in lcar)
            {
                if (c.CodiceCaratteristicheIncontro > codToSet)
                {
                    codToSet = c.CodiceCaratteristicheIncontro;
                }
            }
            return (codToSet + 1);
        }

        private void UpdateRecord(string pareggio, string cfsconfitto, string cfvincitore, string cfsconfitto2, string cfvincitore2)
        {
            List<Record> rec = dc.Records.ToList();
            if(pareggio.Length != 0)
            {
                foreach(Record r in rec)
                {
                    if(r.CodiceFiscaleAtleta.Trim() == cfsconfitto2)
                    {
                        int pr = int.Parse(r.Pareggi.Trim());
                        pr++;
                        r.Pareggi = pr.ToString();
                    }
                    if (r.CodiceFiscaleAtleta.Trim() == cfvincitore2)
                    {
                        int pr2 = int.Parse(r.Pareggi.Trim());
                        pr2++;
                        r.Pareggi= pr2.ToString();
                    }

                }
            } else
            {
                foreach(Record r in rec)
                {
                    if (r.CodiceFiscaleAtleta.Trim() == cfsconfitto)
                    {
                        int sc = int.Parse(r.Sconfitte.Trim());
                        sc++;
                        r.Sconfitte = sc.ToString();
                    }
                    if (r.CodiceFiscaleAtleta.Trim() == cfvincitore)
                    {
                        int vt = int.Parse(r.Vittorie.Trim());
                        vt++;
                        r.Vittorie = vt.ToString();
                    }
                }
            }


        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            FormMediciInIncontro md = new FormMediciInIncontro();
            md.Visible = true;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        select S;
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
