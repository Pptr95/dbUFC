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
    public partial class FormAddAtleta : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();
        int _CodiceRecord;

        public int CodiceRecord
        {
            get { return _CodiceRecord; }
            set { _CodiceRecord = value; }
        }

        public FormAddAtleta()
        {
            InitializeComponent();
        }

        private void AddAtletaButton_Click(object sender, EventArgs e)
        {
            SetVisibleAddCategoryButton(true);
        }
        

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            SetVisibleAddCategoryButton(true);
        }

        private void SetVisibleAddCategoryButton(bool value)
        {
            FormAddCategoria cat = new FormAddCategoria();
            cat.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SetVisibleAddTeamButton(true);
        }

        private void bunifuCustomLabel13_Click(object sender, EventArgs e)
        {
            SetVisibleAddTeamButton(true);
        }

        private void SetVisibleAddTeamButton(bool value)
        {
            FormAddTeam team = new FormAddTeam();
            team.Visible = true;
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {
            AddAtleta();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            AddAtleta();
        }

        private void AddAtleta()
        {
            Atleta atl = new Atleta();
            List<Atleta> latl = dc.Atletas.ToList();
            atl.Nome = bunifuTextbox1.text.Trim();
            atl.Cognome = bunifuTextbox11.text.Trim();
            atl.Classe = bunifuTextbox3.text.Trim();
            atl.CodiceFiscale = bunifuTextbox10.text.Trim();
            atl.Età= bunifuTextbox5.text.Trim();
            atl.Nazionalità = bunifuTextbox8.text.Trim();
            atl.Altezza = bunifuTextbox12.text.Trim();
            atl.NomeDarte = bunifuTextbox4.text.Trim();
            atl.Peso = bunifuTextbox9.text.Trim();
            atl.RaggioGamba = bunifuTextbox2.text.Trim();
            atl.CodiceCategoria = bunifuTextbox7.text.Trim();
            atl.CodiceTeam = bunifuTextbox16.text.Trim();

            if (CheckIfNotNullAttributes(atl))
            {
                return;
            }


            List<Categoria> lc = dc.Categorias.ToList();
            if (!ContainsCategoria(lc, atl.CodiceCategoria))
            {
                MessageBox.Show("La categoria con il codice inserito non esiste. Inserimento non riuscito.");
                return;
            }

            if(atl.CodiceTeam.Length > 0)
            {
                List<Team> lt = dc.Teams.ToList();
                if (!ContainsTeam(lt, atl.CodiceTeam))
                {
                    MessageBox.Show("Il team con il codice inserito non esiste. Inserimento non riuscito.");
                    return;
                }
            }
            else
            {
                atl.CodiceTeam = null;
            }

            foreach (Atleta p in latl)
            {
                if (atl.CodiceFiscale.Trim() == p.CodiceFiscale.Trim())
                {
                    MessageBox.Show("Questo atleta è già presente. Inserimento non riuscito.");
                    return;
                }
            }
            this.dc.Atletas.InsertOnSubmit(atl);
            this.dc.SubmitChanges();
            //insert record of given atleta
            Record rec = new Record();
            List<Record> lrec = dc.Records.ToList();
            rec.CodiceRecord = SetCodiceRecord();
            rec.CodiceFiscaleAtleta = bunifuTextbox10.text.Trim();
            rec.Vittorie = bunifuTextbox15.text.Trim();
            rec.Sconfitte = bunifuTextbox14.text.Trim();
            rec.Pareggi = bunifuTextbox13.text.Trim();
            if(CheckIfNotNullRecordAttributes(rec))
            {
                MessageBox.Show("Riempi tutti i campi del record dell'atleta. Inserimento non riuscito.");
                return;
            }
            this.dc.Records.InsertOnSubmit(rec);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo atleta è stato inserito correttamente.");
        }

        private bool CheckIfNotNullAttributes(Atleta atl)
        {
            if ((atl.Nome.Length == 0) || (atl.Cognome.Length == 0) || (atl.CodiceFiscale.Length == 0) || (atl.Classe.Length == 0)
                || (atl.Età.Length == 0) || (atl.Altezza.Length == 0) || (atl.Peso.Length == 0) || (atl.NomeDarte.Length == 0)
                || (atl.RaggioGamba.Length == 0) || (atl.Nazionalità.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfNotNullRecordAttributes(Record r)
        {
            if((r.Vittorie.Length == 0) || (r.Sconfitte.Length == 0) || (r.Pareggi.Length == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContainsTeam(List<Team> lt, string CodiceTeam)
        {
            int counter = 0;
            foreach (Team t in lt)
            {
                if (t.CodiceTeam.Trim() == CodiceTeam)
                {
                    counter++;
                }
            }
            return counter > 0;
        }

        private bool ContainsCategoria(List<Categoria> lc, string CodiceCategoria)
        {
            int counter = 0;
            foreach (Categoria t in lc)
            {
                if (t.CodiceCategoria.Trim() == CodiceCategoria)
                {
                    counter++;
                }
            }
            return counter > 0;
        }

        private string SetCodiceRecord()
        {
            int codToSet = 0;
            List<Record> lcat = dc.Records.ToList();
            foreach (Record c in lcat)
            {
                if (int.Parse(c.CodiceRecord) > codToSet)
                {
                    codToSet = int.Parse(c.CodiceRecord);
                }
            }
            return (codToSet + 1).ToString();

        }
    }
}
