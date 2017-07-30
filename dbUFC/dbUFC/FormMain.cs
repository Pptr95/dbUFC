﻿using System;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            SetVisibleAddAtletaButton(true);
        }

        private void AddAtletaButton_Click(object sender, EventArgs e)
        {
            SetVisibleAddAtletaButton(true);
        }

        private void SetVisibleAddAtletaButton(bool value)
        {
            FormAddAtleta form2 = new FormAddAtleta();
            form2.Visible = value;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            SetVisibleAddSponsorButton(true);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            SetVisibleAddSponsorButton(true);
        }

        private void SetVisibleAddSponsorButton(bool value)
        {
            FormAddSponsor sponsor = new FormAddSponsor();
            sponsor.Visible = value;
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            SetVisibleAddPersonaleButton(true);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SetVisibleAddPersonaleButton(true);
        }

        private void SetVisibleAddPersonaleButton(bool value)
        {
            FormAddPersonale personale = new FormAddPersonale();
            personale.Visible = value;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            SetVisibleAddCategoryButton(true);
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            SetVisibleAddCategoryButton(true);
        }

        private void SetVisibleAddCategoryButton(bool value)
        {
            FormAddCategoria cat = new FormAddCategoria();
            cat.Visible = true;
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            SetVisibleAddTeamButton(true);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            SetVisibleAddTeamButton(true);
        }

        private void SetVisibleAddTeamButton(bool value)
        {
            FormAddTeam team = new FormAddTeam();
            team.Visible = true;
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            SetVisibleEntrataUscitaButton(true);
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            SetVisibleEntrataUscitaButton(true);
        }

        private void SetVisibleEntrataUscitaButton(bool value)
        {
            FormEntrataUscita team = new FormEntrataUscita();
            team.Visible = true;
        }
    }
}
