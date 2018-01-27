namespace HexMaps
{
    partial class map
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
            this.SuspendLayout();
            // 
            // map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 494);
            this.Name = "map";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.map_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.map_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}