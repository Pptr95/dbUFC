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

        private void bunifuImageButton3_Click(object sender, EventArgs e)
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

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

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
            car.Sconfitto = bunifuTextbox9.text.Trim();
            car.Vincitore = bunifuTextbox2.text.Trim();
            car.CodiceFiscaleArbitro = bunifuTextbox4.text.Trim();


            if (CheckIfNotNullAttributes(car))
            {
                return;
            }

            this.dc.CaratteristicheIncontros.InsertOnSubmit(car);
            this.dc.SubmitChanges();
            MessageBox.Show("Il nuovo giudice è stato aggiunto correttamente.");
        }

        private bool CheckIfNotNullAttributes(CaratteristicheIncontro cc)
        {
        }

        private int SetCodiceCaratteristicheIncontro()
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
    }
}
