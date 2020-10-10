namespace Summative2DGame
{
    partial class PauseScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.coverLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coverLabel
            // 
            this.coverLabel.BackColor = System.Drawing.Color.Black;
            this.coverLabel.Location = new System.Drawing.Point(0, 0);
            this.coverLabel.Name = "coverLabel";
            this.coverLabel.Size = new System.Drawing.Size(912, 482);
            this.coverLabel.TabIndex = 0;
            this.coverLabel.Text = "label1";
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.coverLabel);
            this.Name = "PauseScreen";
            this.Size = new System.Drawing.Size(912, 482);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PauseScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PauseScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label coverLabel;
    }
}
