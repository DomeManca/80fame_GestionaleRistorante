
namespace _80fame
{
    partial class HOME
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.DE2 = new System.Windows.Forms.Label();
            this.DE1 = new System.Windows.Forms.Label();
            this.btINIZIAMO = new System.Windows.Forms.Button();
            this.pnINIZIAMO = new System.Windows.Forms.Panel();
            this.btHOME = new System.Windows.Forms.Button();
            this.btCLIENTE = new System.Windows.Forms.Button();
            this.btPROPETARIO = new System.Windows.Forms.Button();
            this.DE3 = new System.Windows.Forms.Label();
            this.pnPROPETARIO = new System.Windows.Forms.Panel();
            this.btPASSWORD = new System.Windows.Forms.Button();
            this.tbPASSWORD = new System.Windows.Forms.TextBox();
            this.DE4 = new System.Windows.Forms.Label();
            this.pnINIZIAMO.SuspendLayout();
            this.pnPROPETARIO.SuspendLayout();
            this.SuspendLayout();
            // 
            // DE2
            // 
            this.DE2.AutoSize = true;
            this.DE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DE2.Location = new System.Drawing.Point(305, 100);
            this.DE2.Name = "DE2";
            this.DE2.Size = new System.Drawing.Size(241, 44);
            this.DE2.TabIndex = 0;
            this.DE2.Text = "Benvenuti da";
            // 
            // DE1
            // 
            this.DE1.AutoSize = true;
            this.DE1.Font = new System.Drawing.Font("Microsoft Sans Serif", 68.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DE1.Location = new System.Drawing.Point(246, 174);
            this.DE1.Name = "DE1";
            this.DE1.Size = new System.Drawing.Size(399, 102);
            this.DE1.TabIndex = 1;
            this.DE1.Text = "80FAME";
            // 
            // btINIZIAMO
            // 
            this.btINIZIAMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btINIZIAMO.Location = new System.Drawing.Point(313, 297);
            this.btINIZIAMO.Name = "btINIZIAMO";
            this.btINIZIAMO.Size = new System.Drawing.Size(233, 78);
            this.btINIZIAMO.TabIndex = 2;
            this.btINIZIAMO.Text = "Iniziamo!";
            this.btINIZIAMO.UseVisualStyleBackColor = true;
            this.btINIZIAMO.Click += new System.EventHandler(this.btINIZIAMO_Click);
            // 
            // pnINIZIAMO
            // 
            this.pnINIZIAMO.Controls.Add(this.btHOME);
            this.pnINIZIAMO.Controls.Add(this.btCLIENTE);
            this.pnINIZIAMO.Controls.Add(this.btPROPETARIO);
            this.pnINIZIAMO.Controls.Add(this.DE3);
            this.pnINIZIAMO.Location = new System.Drawing.Point(191, 89);
            this.pnINIZIAMO.Name = "pnINIZIAMO";
            this.pnINIZIAMO.Size = new System.Drawing.Size(499, 313);
            this.pnINIZIAMO.TabIndex = 3;
            // 
            // btHOME
            // 
            this.btHOME.Location = new System.Drawing.Point(466, 4);
            this.btHOME.Name = "btHOME";
            this.btHOME.Size = new System.Drawing.Size(30, 27);
            this.btHOME.TabIndex = 3;
            this.btHOME.Text = " H";
            this.btHOME.UseVisualStyleBackColor = true;
            this.btHOME.Click += new System.EventHandler(this.btHOME_Click);
            // 
            // btCLIENTE
            // 
            this.btCLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCLIENTE.Location = new System.Drawing.Point(299, 140);
            this.btCLIENTE.Name = "btCLIENTE";
            this.btCLIENTE.Size = new System.Drawing.Size(152, 62);
            this.btCLIENTE.TabIndex = 2;
            this.btCLIENTE.Text = "Cliente";
            this.btCLIENTE.UseVisualStyleBackColor = true;
            this.btCLIENTE.Click += new System.EventHandler(this.btCLIENTE_Click);
            // 
            // btPROPETARIO
            // 
            this.btPROPETARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPROPETARIO.Location = new System.Drawing.Point(52, 140);
            this.btPROPETARIO.Name = "btPROPETARIO";
            this.btPROPETARIO.Size = new System.Drawing.Size(152, 62);
            this.btPROPETARIO.TabIndex = 1;
            this.btPROPETARIO.Text = "Propetario";
            this.btPROPETARIO.UseVisualStyleBackColor = true;
            this.btPROPETARIO.Click += new System.EventHandler(this.btPROPETARIO_Click);
            // 
            // DE3
            // 
            this.DE3.AutoSize = true;
            this.DE3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DE3.Location = new System.Drawing.Point(168, 23);
            this.DE3.Name = "DE3";
            this.DE3.Size = new System.Drawing.Size(159, 39);
            this.DE3.TabIndex = 0;
            this.DE3.Text = "CHI SEI?";
            // 
            // pnPROPETARIO
            // 
            this.pnPROPETARIO.Controls.Add(this.btPASSWORD);
            this.pnPROPETARIO.Controls.Add(this.tbPASSWORD);
            this.pnPROPETARIO.Controls.Add(this.DE4);
            this.pnPROPETARIO.Location = new System.Drawing.Point(191, 89);
            this.pnPROPETARIO.Name = "pnPROPETARIO";
            this.pnPROPETARIO.Size = new System.Drawing.Size(460, 313);
            this.pnPROPETARIO.TabIndex = 4;
            // 
            // btPASSWORD
            // 
            this.btPASSWORD.Location = new System.Drawing.Point(396, 114);
            this.btPASSWORD.Name = "btPASSWORD";
            this.btPASSWORD.Size = new System.Drawing.Size(38, 38);
            this.btPASSWORD.TabIndex = 3;
            this.btPASSWORD.Text = "✓";
            this.btPASSWORD.UseVisualStyleBackColor = true;
            this.btPASSWORD.Click += new System.EventHandler(this.btPASSWORD_Click);
            // 
            // tbPASSWORD
            // 
            this.tbPASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPASSWORD.Location = new System.Drawing.Point(128, 114);
            this.tbPASSWORD.Name = "tbPASSWORD";
            this.tbPASSWORD.Size = new System.Drawing.Size(262, 38);
            this.tbPASSWORD.TabIndex = 2;
            this.tbPASSWORD.UseSystemPasswordChar = true;
            // 
            // DE4
            // 
            this.DE4.AutoSize = true;
            this.DE4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DE4.Location = new System.Drawing.Point(168, 23);
            this.DE4.Name = "DE4";
            this.DE4.Size = new System.Drawing.Size(170, 39);
            this.DE4.TabIndex = 0;
            this.DE4.Text = "Password";
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(868, 518);
            this.Controls.Add(this.pnPROPETARIO);
            this.Controls.Add(this.pnINIZIAMO);
            this.Controls.Add(this.btINIZIAMO);
            this.Controls.Add(this.DE1);
            this.Controls.Add(this.DE2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 80FAME - Home";
            this.Load += new System.EventHandler(this.HOME_Load);
            this.pnINIZIAMO.ResumeLayout(false);
            this.pnINIZIAMO.PerformLayout();
            this.pnPROPETARIO.ResumeLayout(false);
            this.pnPROPETARIO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DE2;
        private System.Windows.Forms.Label DE1;
        private System.Windows.Forms.Button btINIZIAMO;
        private System.Windows.Forms.Panel pnINIZIAMO;
        private System.Windows.Forms.Button btCLIENTE;
        private System.Windows.Forms.Button btPROPETARIO;
        private System.Windows.Forms.Label DE3;
        private System.Windows.Forms.Panel pnPROPETARIO;
        private System.Windows.Forms.Label DE4;
        private System.Windows.Forms.Button btHOME;
        private System.Windows.Forms.TextBox tbPASSWORD;
        private System.Windows.Forms.Button btPASSWORD;
    }
}

