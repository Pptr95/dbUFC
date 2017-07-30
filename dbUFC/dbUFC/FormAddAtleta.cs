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
    }
}
