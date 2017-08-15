﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbUFC
{
    public partial class FormQueries : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormQueries()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        where C.Data.Equals(bunifuDatepicker1.Value)
                        select C;
            bunifuCustomDataGrid1.DataSource = query;
        }
       
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var query = from g in dc.Giudicas
                        join ci in dc.CaratteristicheIncontros on g.CodiceCaratteristicheIncontro equals ci.CodiceCaratteristicheIncontro
                        select new { g, ci } into t1
                        group t1 by t1.g.CodiceFiscaleGiudice into grp
                        select new
                        {
                            CFGiudice = grp.FirstOrDefault().g.CodiceFiscaleGiudice,
                            IncontriGiudicati = grp.Count()
                        };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            var query = from m in dc.Medicaziones
                        join ci in dc.CaratteristicheIncontros on m.CodiceCaratteristicheIncontro equals ci.CodiceCaratteristicheIncontro
                        select new { m, ci } into t1
                        group t1 by t1.m.CodiceFiscaleMedico into grp
                        select new
                        {
                            CFMedico = grp.FirstOrDefault().m.CodiceFiscaleMedico,
                            IncontriMedicati = grp.Count()
                        };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            var results = dc.ExecuteQuery<Atleta>(
            @"select *
              from Atleta 
              order by Cognome desc");

            bunifuCustomDataGrid1.DataSource = results.ToList();

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            var results = dc.ExecuteQuery<Team>(
            @"select *
              from Team 
              order by CodiceTeam asc");

            bunifuCustomDataGrid1.DataSource = results.ToList();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var query = from A in dc.Atletas
                        join R in dc.Records on A.CodiceFiscale equals R.CodiceFiscaleAtleta
                        select new
                        {
                            CFAtleta = A.CodiceFiscale,
                            MatchTotali = Convert.ToInt32(R.Sconfitte) + Convert.ToInt32(R.Vittorie) + Convert.ToInt32(R.Pareggi),
                            Vittorie = R.Vittorie,
                            Sconfitte = R.Sconfitte,
                            Pareggi = R.Pareggi
                        };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var query = from A in dc.Atletas
                         join R in dc.Records on A.CodiceFiscale equals R.CodiceFiscaleAtleta
                         select new { A, R } into t1
                         group t1 by t1.A.CodiceFiscale into grp
                         orderby (Convert.ToInt32(grp.FirstOrDefault().R.Vittorie) - Convert.ToInt32(grp.FirstOrDefault().R.Sconfitte)) descending
                         select new
                         {
                             Nome = grp.FirstOrDefault().A.Nome,
                             Cognome = grp.FirstOrDefault().A.Cognome,
                             Positività = Convert.ToInt32(grp.FirstOrDefault().R.Vittorie) - Convert.ToInt32(grp.FirstOrDefault().R.Sconfitte)
                         };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            var query = (from A in dc.Atletas
                        select new {
                            EtàMedia = dc.Atletas.Average(p => (Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(p.AnnoNascita)))
                        }).Distinct();

            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            var query = from S in dc.Sponsors
                        where !(from ST in dc.SponsorizzazioneTeams
                                select ST.NomeSponsor).Contains(S.NomeSponsor)
                        where !(from SI in dc.SponsorizzazioneIncontros
                                select SI.NomeSponsor).Contains(S.NomeSponsor)
                        select S;

            bunifuCustomDataGrid1.DataSource = query;

        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            if((bunifuCustomDataGrid3.SelectedCells.Count > 1) || (bunifuCustomDataGrid3.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga.");
                Close();
                return;
            }
            int selectedrowindex = bunifuCustomDataGrid3.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = bunifuCustomDataGrid3.Rows[selectedrowindex];

            string marca = Convert.ToString(selectedRow.Cells["MarcaGuantini"].Value);

            var query = (from C in dc.CaratteristicheIncontros
                         where (from CA in dc.CaratteristicheAtletaInIncontros
                                where CA.Guantini_Marca.Trim() == marca
                                select CA.CodiceFiscaleAtleta).Contains(C.Sconfitto)
                         select new { Atleti = C.Sconfitto.Trim() }).Distinct();
            bunifuCustomDataGrid1.DataSource = query;

        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            var query = from A in dc.Atletas
                        where !(from AT in dc.Atletas
                                join T in dc.Teams on AT.CodiceTeam equals T.CodiceTeam
                                select AT.CodiceFiscale).Contains(A.CodiceFiscale)
                        select new { CodiceFiscale = A.CodiceFiscale, Nome = A.Nome, Cognome = A.Cognome, A.Categoria.NomeCategoria };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton16_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        join CA in dc.CaratteristicheAtletaInIncontros on C.CodiceCaratteristicheIncontro
                        equals CA.CodiceCaratteristicheIncontro
                        select new { CFAtleta = CA.CodiceFiscaleAtleta, Stato = CA.StatoAtleta, MisuraGuantini = CA.Guantini_Misura,
                        MarcaGuantini = CA.Guantini_Marca, Vincitore = C.Vincitore, Sconfitto = C.Sconfitto, DataIncontro = C.Data };
            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            if ((bunifuCustomDataGrid2.SelectedCells.Count > 1) || (bunifuCustomDataGrid2.SelectedCells.Count == 0))
            {
                MessageBox.Show("Selezionare solo una riga.");
                Close();
                return;
            }
            int selectedrowindex = bunifuCustomDataGrid2.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = bunifuCustomDataGrid2.Rows[selectedrowindex];

            string nomeSponsor = Convert.ToString(selectedRow.Cells["NomeSponsor"].Value);


            var query = from ST in dc.SponsorizzazioneTeams
                        join S in dc.Sponsors on ST.NomeSponsor equals S.NomeSponsor
                        select new { ST, S } into t1
                        group t1 by t1.S.NomeSponsor into grp
                        where grp.FirstOrDefault().S.NomeSponsor.Trim() == nomeSponsor
                        select new { NumeroTeamSponsorizzati = grp.Count() };
            bunifuCustomDataGrid1.DataSource = query;

        }

        private void FormQueries_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = from S in dc.Sponsors
                                               select S;

            bunifuCustomDataGrid3.DataSource = (from CA in dc.CaratteristicheAtletaInIncontros
                                                select new { MarcaGuantini = CA.Guantini_Marca }).Distinct();
        }
    }
}
