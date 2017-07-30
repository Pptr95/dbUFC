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
    public partial class FormAddTeam : Form
    {
        public FormAddTeam()
        {
            InitializeComponent();
        }

        private void AddAtletaButton_Click(object sender, EventArgs e)
        {
            SetVisibleAddTrainerButton(true);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            SetVisibleAddTrainerButton(true);
        }

        private void SetVisibleAddTrainerButton(bool value)
        {
            FormAddTrainer team = new FormAddTrainer();
            team.Visible = true;
        }
    }
}
