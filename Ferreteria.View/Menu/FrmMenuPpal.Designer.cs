namespace Ferreteria.View.Menu
{
    partial class FrmMenuPpal
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
            this.btnFrmLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmLocal
            // 
            this.btnFrmLocal.Location = new System.Drawing.Point(202, 122);
            this.btnFrmLocal.Name = "btnFrmLocal";
            this.btnFrmLocal.Size = new System.Drawing.Size(75, 23);
            this.btnFrmLocal.TabIndex = 0;
            this.btnFrmLocal.Text = "Local";
            this.btnFrmLocal.UseVisualStyleBackColor = true;
            this.btnFrmLocal.Click += new System.EventHandler(this.btnFrmLocal_Click);
            // 
            // FrmMenuPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFrmLocal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "FrmMenuPpal";
            this.Text = "Menú Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmLocal;
    }
}