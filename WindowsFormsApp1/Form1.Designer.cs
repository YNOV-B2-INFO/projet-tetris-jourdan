namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuitBtn = new System.Windows.Forms.Button();
            this.OptionBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuitBtn
            // 
            this.QuitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.QuitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.QuitBtn.Location = new System.Drawing.Point(451, 572);
            this.QuitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(149, 47);
            this.QuitBtn.TabIndex = 3;
            this.QuitBtn.Text = "QUIT";
            this.QuitBtn.UseVisualStyleBackColor = false;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // OptionBtn
            // 
            this.OptionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.OptionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OptionBtn.Location = new System.Drawing.Point(451, 473);
            this.OptionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OptionBtn.Name = "OptionBtn";
            this.OptionBtn.Size = new System.Drawing.Size(149, 47);
            this.OptionBtn.TabIndex = 4;
            this.OptionBtn.Text = "OPTION";
            this.OptionBtn.UseVisualStyleBackColor = false;
            this.OptionBtn.Click += new System.EventHandler(this.OptionBtn_Click_1);
            // 
            // PlayBtn
            // 
            this.PlayBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.PlayBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayBtn.Location = new System.Drawing.Point(451, 367);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(149, 47);
            this.PlayBtn.TabIndex = 5;
            this.PlayBtn.Text = "PLAY";
            this.PlayBtn.UseVisualStyleBackColor = false;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 924);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.OptionBtn);
            this.Controls.Add(this.QuitBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button OptionBtn;
        private System.Windows.Forms.Button PlayBtn;
    }
}

