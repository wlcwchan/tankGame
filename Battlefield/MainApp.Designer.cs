namespace Battlefield
{
    partial class mainApp
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
            this.screenSpliter = new System.Windows.Forms.SplitContainer();
            this.gameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.screenSpliter)).BeginInit();
            this.screenSpliter.Panel1.SuspendLayout();
            this.screenSpliter.Panel2.SuspendLayout();
            this.screenSpliter.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenSpliter
            // 
            this.screenSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenSpliter.Location = new System.Drawing.Point(0, 0);
            this.screenSpliter.Name = "screenSpliter";
            // 
            // screenSpliter.Panel1
            // 
            this.screenSpliter.Panel1.Controls.Add(this.gameGrid);
            // 
            // screenSpliter.Panel2
            // 
            this.screenSpliter.Panel2.Controls.Add(this.messageBox);
            this.screenSpliter.Size = new System.Drawing.Size(1012, 721);
            this.screenSpliter.SplitterDistance = 856;
            this.screenSpliter.TabIndex = 0;
            // 
            // gameGrid
            // 
            this.gameGrid.ColumnCount = 9;
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.gameGrid.Location = new System.Drawing.Point(0, 0);
            this.gameGrid.Margin = new System.Windows.Forms.Padding(0);
            this.gameGrid.Name = "gameGrid";
            this.gameGrid.RowCount = 9;
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.gameGrid.Size = new System.Drawing.Size(856, 721);
            this.gameGrid.TabIndex = 0;
            // 
            // messageBox
            // 
            this.messageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageBox.Location = new System.Drawing.Point(0, 0);
            this.messageBox.Margin = new System.Windows.Forms.Padding(0);
            this.messageBox.Name = "messageBox";
            this.messageBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(152, 721);
            this.messageBox.TabIndex = 0;
            this.messageBox.Text = "";
            // 
            // mainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 721);
            this.Controls.Add(this.screenSpliter);
            this.Name = "mainApp";
            this.Text = "Battlefield";
            this.screenSpliter.Panel1.ResumeLayout(false);
            this.screenSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.screenSpliter)).EndInit();
            this.screenSpliter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer screenSpliter;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.TableLayoutPanel gameGrid;

    }
}

