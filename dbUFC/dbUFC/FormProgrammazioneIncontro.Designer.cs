namespace dbUFC
{
    partial class FormProgrammazioneIncontro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgrammazioneIncontro));
            this.bunifuiOSSwitch1 = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.bunifuGauge1 = new Bunifu.Framework.UI.BunifuGauge();
            this.SuspendLayout();
            // 
            // bunifuiOSSwitch1
            // 
            this.bunifuiOSSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuiOSSwitch1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuiOSSwitch1.BackgroundImage")));
            this.bunifuiOSSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuiOSSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuiOSSwitch1.Location = new System.Drawing.Point(477, 154);
            this.bunifuiOSSwitch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuiOSSwitch1.Name = "bunifuiOSSwitch1";
            this.bunifuiOSSwitch1.OffColor = System.Drawing.Color.Gray;
            this.bunifuiOSSwitch1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.bunifuiOSSwitch1.Size = new System.Drawing.Size(35, 20);
            this.bunifuiOSSwitch1.TabIndex = 0;
            this.bunifuiOSSwitch1.Value = true;
            // 
            // bunifuGauge1
            // 
            this.bunifuGauge1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGauge1.BackgroundImage")));
            this.bunifuGauge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.bunifuGauge1.Location = new System.Drawing.Point(522, 113);
            this.bunifuGauge1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuGauge1.Name = "bunifuGauge1";
            this.bunifuGauge1.ProgressBgColor = System.Drawing.Color.Gray;
            this.bunifuGauge1.ProgressColor1 = System.Drawing.Color.SeaGreen;
            this.bunifuGauge1.ProgressColor2 = System.Drawing.Color.Tomato;
            this.bunifuGauge1.Size = new System.Drawing.Size(174, 117);
            this.bunifuGauge1.Suffix = "";
            this.bunifuGauge1.TabIndex = 1;
            this.bunifuGauge1.Thickness = 30;
            this.bunifuGauge1.Value = 0;
            // 
            // FormProgrammazioneIncontro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 485);
            this.Controls.Add(this.bunifuGauge1);
            this.Controls.Add(this.bunifuiOSSwitch1);
            this.Name = "FormProgrammazioneIncontro";
            this.Text = "FormProgrammazioneIncontro";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuiOSSwitch bunifuiOSSwitch1;
        private Bunifu.Framework.UI.BunifuGauge bunifuGauge1;
    }
}