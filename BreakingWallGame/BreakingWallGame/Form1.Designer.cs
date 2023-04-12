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
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).BeginInit();
            this.SuspendLayout();
            // 
            // pbplatno
            // 
            this.pbplatno.Location = new System.Drawing.Point(65, 40);
            this.pbplatno.Name = "pbplatno";
            this.pbplatno.Size = new System.Drawing.Size(600, 600);
            this.pbplatno.TabIndex = 0;
            this.pbplatno.TabStop = false;
            // 
            // tmrRedraw
            // 
            this.tmrRedraw.Interval = 10;
            this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 686);
            this.Controls.Add(this.pbplatno);
            this.Name = "Form1";
            this.Text = "Breaking Wall";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbplatno;
        private System.Windows.Forms.Timer tmrRedraw;
    }
}

