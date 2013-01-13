namespace Disc_Golf_Score_Database
{
    partial class GraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphForm));
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.XAxisPanel = new System.Windows.Forms.Panel();
            this.YAxisPanel = new System.Windows.Forms.Panel();
            this.LegendPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // GraphPanel
            // 
            this.GraphPanel.Location = new System.Drawing.Point(48, 12);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(632, 209);
            this.GraphPanel.TabIndex = 0;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // XAxisPanel
            // 
            this.XAxisPanel.Location = new System.Drawing.Point(48, 227);
            this.XAxisPanel.Name = "XAxisPanel";
            this.XAxisPanel.Size = new System.Drawing.Size(632, 73);
            this.XAxisPanel.TabIndex = 1;
            this.XAxisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.XAxisPanel_Paint);
            // 
            // YAxisPanel
            // 
            this.YAxisPanel.Location = new System.Drawing.Point(12, 12);
            this.YAxisPanel.Name = "YAxisPanel";
            this.YAxisPanel.Size = new System.Drawing.Size(30, 240);
            this.YAxisPanel.TabIndex = 1;
            this.YAxisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.YAxisPanel_Paint);
            // 
            // LegendPanel
            // 
            this.LegendPanel.Location = new System.Drawing.Point(686, 52);
            this.LegendPanel.Name = "LegendPanel";
            this.LegendPanel.Size = new System.Drawing.Size(90, 138);
            this.LegendPanel.TabIndex = 2;
            this.LegendPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LegendPanel_Paint);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 310);
            this.Controls.Add(this.LegendPanel);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.XAxisPanel);
            this.Controls.Add(this.YAxisPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphForm";
            this.ShowInTaskbar = false;
            this.Text = "Here is your graph:";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.Panel XAxisPanel;
        private System.Windows.Forms.Panel YAxisPanel;
        private System.Windows.Forms.Panel LegendPanel;
    }
}