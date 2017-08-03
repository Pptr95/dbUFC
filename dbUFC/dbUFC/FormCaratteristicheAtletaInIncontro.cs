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
    public partial class FormCaratteristicheAtletaInIncontro : Form
    {
        readonly dbUFCDataContext dc = new dbUFCDataContext();

        public FormCaratteristicheAtletaInIncontro()
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
        
        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            AddCaratteristicaAtletaInIncontro();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddCaratteristicaAtletaInIncontro();
        }

        private void AddCaratteristicaAtletaInIncontro()
        {
            CaratteristicheAtletaInIncontro car = new CaratteristicheAtletaInIncontro();
            List<CaratteristicheAtletaInIncontro> la = dc.CaratteristicheAtletaInIncontros.ToList();
            car.CodiceCaratteristicheIncontro = new FormCaratteristicheIncontro().SetCodiceCaratteristicheIncontro() - 1;
            car.CodiceFiscaleAtleta = bunifuTextbox1.text.Trim();
            car.StatoAtleta = bunifuTextbox5.text.Trim();
            car.Guantini_Misura = bunifuTextbox12.text.Trim();
            car.Guantini_Marca = bunifuTextbox9.text.Trim();

            if (CheckIfNotNullAttributes(car))
            {
                return;
            }
            this.dc.CaratteristicheAtletaInIncontros.InsertOnSubmit(car);
            try
            {
                this.dc.SubmitChanges();

            } catch (Exception e)
            {
                MessageBox.Show("Qualcosa è andato storto. Ricontrollare i dati inseriti. Inserimento non riuscito.");
                Close();
                return;
            }

            MessageBox.Show("La caratteristica dell'atleta nell'incontro è stata correttamente inserita.");
        }

        private bool CheckIfNotNullAttributes(CaratteristicheAtletaInIncontro car)
        {
            if ((car.CodiceFiscaleAtleta.Length == 0) || (car.StatoAtleta.Length == 0) || (car.Guantini_Misura.Length == 0) 
                || (car.Guantini_Marca.Length == 0))
            {
                MessageBox.Show("Riempi tutti i campi. Inserimento non riuscito");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var query = from C in dc.CaratteristicheIncontros
                        select C; // query test
            bunifuCustomDataGrid1.DataSource = query;
        }
    }
}
