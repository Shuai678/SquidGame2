namespace SquidGame_2
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (IsHandleCreated && disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.imagineSemaforo = new System.Windows.Forms.PictureBox();
            this.areaGioco = new System.Windows.Forms.Panel();
            this.etichettaSemaforo = new System.Windows.Forms.Label();
            this.NumeroGiocatore = new System.Windows.Forms.NumericUpDown();
            this.AvviaGioco = new System.Windows.Forms.Button();
            this.conferma = new System.Windows.Forms.Button();
            this.NumeroGiocatori = new System.Windows.Forms.Label();
            this.Eliminati = new System.Windows.Forms.Label();
            this.Esci = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagineSemaforo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroGiocatore)).BeginInit();
            this.SuspendLayout();
            // 
            // imagineSemaforo
            // 
            this.imagineSemaforo.Image = global::SquidGame_2.Properties.Resources.verde;
            this.imagineSemaforo.Location = new System.Drawing.Point(303, 12);
            this.imagineSemaforo.Name = "imagineSemaforo";
            this.imagineSemaforo.Size = new System.Drawing.Size(412, 248);
            this.imagineSemaforo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagineSemaforo.TabIndex = 0;
            this.imagineSemaforo.TabStop = false;
            // 
            // areaGioco
            // 
            this.areaGioco.BackColor = System.Drawing.Color.DarkGreen;
            this.areaGioco.Location = new System.Drawing.Point(303, 266);
            this.areaGioco.Name = "areaGioco";
            this.areaGioco.Size = new System.Drawing.Size(412, 600);
            this.areaGioco.TabIndex = 1;
            // 
            // etichettaSemaforo
            // 
            this.etichettaSemaforo.AutoSize = true;
            this.etichettaSemaforo.Location = new System.Drawing.Point(207, 26);
            this.etichettaSemaforo.Name = "etichettaSemaforo";
            this.etichettaSemaforo.Size = new System.Drawing.Size(62, 18);
            this.etichettaSemaforo.TabIndex = 2;
            this.etichettaSemaforo.Text = "label1";
            // 
            // NumeroGiocatore
            // 
            this.NumeroGiocatore.Location = new System.Drawing.Point(802, 266);
            this.NumeroGiocatore.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumeroGiocatore.Name = "NumeroGiocatore";
            this.NumeroGiocatore.Size = new System.Drawing.Size(120, 28);
            this.NumeroGiocatore.TabIndex = 3;
            this.NumeroGiocatore.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // AvviaGioco
            // 
            this.AvviaGioco.Location = new System.Drawing.Point(957, 320);
            this.AvviaGioco.Name = "AvviaGioco";
            this.AvviaGioco.Size = new System.Drawing.Size(106, 30);
            this.AvviaGioco.TabIndex = 4;
            this.AvviaGioco.Text = "AvviaGioco";
            this.AvviaGioco.UseVisualStyleBackColor = true;
            this.AvviaGioco.Click += new System.EventHandler(this.AvviaGioco_Click);
            // 
            // conferma
            // 
            this.conferma.Location = new System.Drawing.Point(957, 266);
            this.conferma.Name = "conferma";
            this.conferma.Size = new System.Drawing.Size(106, 28);
            this.conferma.TabIndex = 5;
            this.conferma.Text = "conferma";
            this.conferma.UseVisualStyleBackColor = true;
            this.conferma.Click += new System.EventHandler(this.conferma_Click);
            // 
            // NumeroGiocatori
            // 
            this.NumeroGiocatori.AutoSize = true;
            this.NumeroGiocatori.Location = new System.Drawing.Point(799, 226);
            this.NumeroGiocatori.Name = "NumeroGiocatori";
            this.NumeroGiocatori.Size = new System.Drawing.Size(296, 18);
            this.NumeroGiocatori.TabIndex = 6;
            this.NumeroGiocatori.Text = "Inserisci il numero di giocatori";
            // 
            // Eliminati
            // 
            this.Eliminati.AutoSize = true;
            this.Eliminati.Location = new System.Drawing.Point(748, 26);
            this.Eliminati.Name = "Eliminati";
            this.Eliminati.Size = new System.Drawing.Size(62, 18);
            this.Eliminati.TabIndex = 7;
            this.Eliminati.Text = "label1";
            // 
            // Esci
            // 
            this.Esci.Location = new System.Drawing.Point(957, 378);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(106, 26);
            this.Esci.TabIndex = 8;
            this.Esci.Text = "Esci";
            this.Esci.UseVisualStyleBackColor = true;
            this.Esci.Click += new System.EventHandler(this.Esci_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 864);
            this.Controls.Add(this.Esci);
            this.Controls.Add(this.Eliminati);
            this.Controls.Add(this.NumeroGiocatori);
            this.Controls.Add(this.conferma);
            this.Controls.Add(this.AvviaGioco);
            this.Controls.Add(this.NumeroGiocatore);
            this.Controls.Add(this.etichettaSemaforo);
            this.Controls.Add(this.areaGioco);
            this.Controls.Add(this.imagineSemaforo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagineSemaforo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroGiocatore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagineSemaforo;
        private System.Windows.Forms.Panel areaGioco;
        private System.Windows.Forms.Label etichettaSemaforo;
        private System.Windows.Forms.NumericUpDown NumeroGiocatore;
        private System.Windows.Forms.Button AvviaGioco;
        private System.Windows.Forms.Button conferma;
        private System.Windows.Forms.Label NumeroGiocatori;
        private System.Windows.Forms.Label Eliminati;
        private System.Windows.Forms.Button Esci;
    }
}

