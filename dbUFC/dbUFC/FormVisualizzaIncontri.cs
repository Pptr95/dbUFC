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
    public partial class FormVisualizzaIncontri : Form
    {
        public FormVisualizzaIncontri()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCaratteristicheIncontro car = new FormCaratteristicheIncontro();
            car.Visible = true;
        }
    }
}
