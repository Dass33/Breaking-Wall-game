namespace BreakingWallGame
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbplatno = new System.Windows.Forms.PictureBox();
            this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMouseCor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPlayerCor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbGameOver = new System.Windows.Forms.Label();
            this.btStartOver = new System.Windows.Forms.Button();
            this.lbScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbplatno
            // 
            this.pbplatno.Location = new System.Drawing.Point(2, 0);
            this.pbplatno.Name = "pbplatno";
            this.pbplatno.Size = new System.Drawing.Size(680, 600);
            this.pbplatno.TabIndex = 0;
            this.pbplatno.TabStop = false;
            // 
            // tmrRedraw
            // 
            this.tmrRedraw.Interval = 10;
            this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMouseCor,
            this.tsPlayerCor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsMouseCor
            // 
            this.tsMouseCor.Name = "tsMouseCor";
            this.tsMouseCor.Size = new System.Drawing.Size(76, 17);
            this.tsMouseCor.Text = "coordionates";
            // 
            // tsPlayerCor
            // 
            this.tsPlayerCor.Name = "tsPlayerCor";
            this.tsPlayerCor.Size = new System.Drawing.Size(118, 17);
            this.tsPlayerCor.Text = "toolStripStatusLabel1";
            // 
            // lbGameOver
            // 
            this.lbGameOver.AutoSize = true;
            this.lbGameOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbGameOver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbGameOver.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbGameOver.Location = new System.Drawing.Point(150, 300);
            this.lbGameOver.Name = "lbGameOver";
            this.lbGameOver.Size = new System.Drawing.Size(401, 75);
            this.lbGameOver.TabIndex = 2;
            this.lbGameOver.Text = "Game Over!!";
            this.lbGameOver.Visible = false;
            // 
            // btStartOver
            // 
            this.btStartOver.Location = new System.Drawing.Point(313, 376);
            this.btStartOver.Name = "btStartOver";
            this.btStartOver.Size = new System.Drawing.Size(75, 23);
            this.btStartOver.TabIndex = 3;
            this.btStartOver.Text = "button1";
            this.btStartOver.UseVisualStyleBackColor = true;
            this.btStartOver.Visible = false;
            this.btStartOver.Click += new System.EventHandler(this.btStartOver_Click);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(300, 620);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(33, 13);
            this.lbScore.TabIndex = 4;
            this.lbScore.Text = "score";
            this.lbScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 681);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.btStartOver);
            this.Controls.Add(this.lbGameOver);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbplatno);
            this.Name = "Form1";
            this.Text = "Breaking Wall";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbplatno;
        private System.Windows.Forms.Timer tmrRedraw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsMouseCor;
        private System.Windows.Forms.ToolStripStatusLabel tsPlayerCor;
        private System.Windows.Forms.Label lbGameOver;
        private System.Windows.Forms.Button btStartOver;
        private System.Windows.Forms.Label lbScore;
    }
}

