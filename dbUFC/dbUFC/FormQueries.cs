using System;
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
              order by Cognome asc");

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
                        orderby grp.FirstOrDefault().A.CodiceFiscale ascending
                        select new { CFAtleta = grp.FirstOrDefault().A.CodiceFiscale,
                                     Positività = Convert.ToInt32(grp.FirstOrDefault().R.Vittorie) - Convert.ToInt32(grp.FirstOrDefault().R.Sconfitte)
                        };

            bunifuCustomDataGrid1.DataSource = query;
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            var query = (from A in dc.Atletas
                         join R in dc.Records on A.CodiceFiscale equals R.CodiceFiscaleAtleta
                         select new { A, R } into t1
                         group t1 by t1.A.CodiceTeam into grp
                         orderby (Convert.ToInt32(grp.FirstOrDefault().R.Vittorie) - Convert.ToInt32(grp.FirstOrDefault().R.Sconfitte)) descending
                         select new
                         {
                             CodiceTeam = grp.FirstOrDefault().A.CodiceTeam,
                             Positività = Convert.ToInt32(grp.FirstOrDefault().R.Vittorie) - Convert.ToInt32(grp.FirstOrDefault().R.Sconfitte)
                         }).Take(1);
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
    }
}
//TODO  add query for viewing for each team fisioterapisti e psicologi
/*


    select top(1) t.CodiceTeam, t.NomeTeam, sum(cast(r.Vittorie as int)-cast(r.Sconfitte as int)) as Positività
from Atleta a, Record r, Team t
where a.CodiceFiscale = r.CodiceFiscaleAtleta
and t.CodiceTeam = a.CodiceTeam
group by t.CodiceTeam, t.NomeTeam
order by Positività desc*/