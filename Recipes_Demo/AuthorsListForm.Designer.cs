namespace Recipes_Demo
{
    partial class AuthorsListForm
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
            this.gvAuthors = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthors)).BeginInit();
            this.SuspendLayout();
            // 
            // gvAuthors
            // 
            this.gvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAuthors.Location = new System.Drawing.Point(0, 0);
            this.gvAuthors.Name = "gvAuthors";
            this.gvAuthors.RowHeadersWidth = 51;
            this.gvAuthors.RowTemplate.Height = 24;
            this.gvAuthors.Size = new System.Drawing.Size(800, 450);
            this.gvAuthors.TabIndex = 0;
            // 
            // AuthorsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gvAuthors);
            this.Name = "AuthorsListForm";
            this.Text = "Автори";
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvAuthors;
    }
}