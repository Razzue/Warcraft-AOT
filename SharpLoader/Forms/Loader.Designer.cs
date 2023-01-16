namespace SharpLoader.Forms
{
    partial class Loader
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
            this.button_Inject = new System.Windows.Forms.Button();
            this.button_Offsets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Inject
            // 
            this.button_Inject.Location = new System.Drawing.Point(12, 12);
            this.button_Inject.Name = "button_Inject";
            this.button_Inject.Size = new System.Drawing.Size(90, 23);
            this.button_Inject.TabIndex = 0;
            this.button_Inject.Text = "Inject Into";
            this.button_Inject.UseVisualStyleBackColor = true;
            // 
            // button_Offsets
            // 
            this.button_Offsets.Enabled = false;
            this.button_Offsets.Location = new System.Drawing.Point(125, 12);
            this.button_Offsets.Name = "button_Offsets";
            this.button_Offsets.Size = new System.Drawing.Size(90, 23);
            this.button_Offsets.TabIndex = 1;
            this.button_Offsets.Text = "Load Offsets";
            this.button_Offsets.UseVisualStyleBackColor = true;
            this.button_Offsets.Click += new System.EventHandler(this.button_Offsets_Click);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 197);
            this.Controls.Add(this.button_Offsets);
            this.Controls.Add(this.button_Inject);
            this.Name = "Loader";
            this.Text = "Loader";
            this.Load += new System.EventHandler(this.Loader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_Inject;
        private Button button_Offsets;
    }
}