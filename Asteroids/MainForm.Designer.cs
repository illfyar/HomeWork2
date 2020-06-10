namespace YarvimyakiIlyaAsteroids
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ShieldsBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ShieldsLabel = new System.Windows.Forms.Label();
            this.rewardPointsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShieldsBar
            // 
            this.ShieldsBar.BackColor = System.Drawing.Color.Red;
            this.ShieldsBar.ForeColor = System.Drawing.Color.Lime;
            this.ShieldsBar.Location = new System.Drawing.Point(12, 830);
            this.ShieldsBar.Name = "ShieldsBar";
            this.ShieldsBar.Size = new System.Drawing.Size(224, 17);
            this.ShieldsBar.Step = 1;
            this.ShieldsBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ShieldsBar.TabIndex = 0;
            this.ShieldsBar.Value = 50;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ShieldsLabel
            // 
            this.ShieldsLabel.AutoSize = true;
            this.ShieldsLabel.BackColor = System.Drawing.Color.Black;
            this.ShieldsLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ShieldsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShieldsLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ShieldsLabel.Location = new System.Drawing.Point(242, 829);
            this.ShieldsLabel.Name = "ShieldsLabel";
            this.ShieldsLabel.Size = new System.Drawing.Size(36, 20);
            this.ShieldsLabel.TabIndex = 1;
            this.ShieldsLabel.Text = "100";
            // 
            // rewardPointsLabel
            // 
            this.rewardPointsLabel.AutoSize = true;
            this.rewardPointsLabel.BackColor = System.Drawing.Color.Black;
            this.rewardPointsLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rewardPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rewardPointsLabel.ForeColor = System.Drawing.Color.White;
            this.rewardPointsLabel.Location = new System.Drawing.Point(315, 828);
            this.rewardPointsLabel.Name = "rewardPointsLabel";
            this.rewardPointsLabel.Size = new System.Drawing.Size(18, 20);
            this.rewardPointsLabel.TabIndex = 2;
            this.rewardPointsLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 846);
            this.Controls.Add(this.rewardPointsLabel);
            this.Controls.Add(this.ShieldsLabel);
            this.Controls.Add(this.ShieldsBar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ShieldsBar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label ShieldsLabel;
        private System.Windows.Forms.Label rewardPointsLabel;
    }
}