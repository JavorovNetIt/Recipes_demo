namespace Recipes_Demo
{
    partial class Form1
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
            this.btnRecipes = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRecipes
            // 
            this.btnRecipes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecipes.Location = new System.Drawing.Point(60, 67);
            this.btnRecipes.Name = "btnRecipes";
            this.btnRecipes.Size = new System.Drawing.Size(273, 246);
            this.btnRecipes.TabIndex = 0;
            this.btnRecipes.Text = "РЕЦЕПТИ";
            this.btnRecipes.UseVisualStyleBackColor = true;
            this.btnRecipes.Click += new System.EventHandler(this.btnRecipes_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAuthors.Location = new System.Drawing.Point(385, 67);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(273, 246);
            this.btnAuthors.TabIndex = 1;
            this.btnAuthors.Text = "АВТОРИ";
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 391);
            this.Controls.Add(this.btnAuthors);
            this.Controls.Add(this.btnRecipes);
            this.Name = "Form1";
            this.Text = "Рецепти";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecipes;
        private System.Windows.Forms.Button btnAuthors;
    }
}

