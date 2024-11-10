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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPpal));
            this.btnFrmLocal = new System.Windows.Forms.Button();
            this.btnModificarRegistro = new System.Windows.Forms.Button();
            this.lblNombreLocal = new System.Windows.Forms.Label();
            this.bsEmpleado = new System.Windows.Forms.BindingSource(this.components);
            this.lblRolEmpleado = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFrmCategoria = new System.Windows.Forms.Button();
            this.btnFrmArticulo = new System.Windows.Forms.Button();
            this.btnFrmVenta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFrmEmpleados = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpleado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFrmLocal
            // 
            this.btnFrmLocal.Location = new System.Drawing.Point(218, 158);
            this.btnFrmLocal.Name = "btnFrmLocal";
            this.btnFrmLocal.Size = new System.Drawing.Size(252, 30);
            this.btnFrmLocal.TabIndex = 0;
            this.btnFrmLocal.Text = "Local";
            this.btnFrmLocal.UseVisualStyleBackColor = true;
            this.btnFrmLocal.Click += new System.EventHandler(this.btnFrmLocal_Click);
            // 
            // btnModificarRegistro
            // 
            this.btnModificarRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarRegistro.Image")));
            this.btnModificarRegistro.Location = new System.Drawing.Point(174, 21);
            this.btnModificarRegistro.Name = "btnModificarRegistro";
            this.btnModificarRegistro.Size = new System.Drawing.Size(20, 20);
            this.btnModificarRegistro.TabIndex = 2;
            this.btnModificarRegistro.UseVisualStyleBackColor = true;
            this.btnModificarRegistro.Click += new System.EventHandler(this.btnModificarRegistro_Click);
            // 
            // lblNombreLocal
            // 
            this.lblNombreLocal.AutoSize = true;
            this.lblNombreLocal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpleado, "Local", true));
            this.lblNombreLocal.Location = new System.Drawing.Point(10, 240);
            this.lblNombreLocal.Name = "lblNombreLocal";
            this.lblNombreLocal.Size = new System.Drawing.Size(0, 16);
            this.lblNombreLocal.TabIndex = 7;
            // 
            // bsEmpleado
            // 
            this.bsEmpleado.DataSource = typeof(Ferreteria.Models.Empleado);
            // 
            // lblRolEmpleado
            // 
            this.lblRolEmpleado.AutoSize = true;
            this.lblRolEmpleado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpleado, "Puesto", true));
            this.lblRolEmpleado.Location = new System.Drawing.Point(10, 180);
            this.lblRolEmpleado.Name = "lblRolEmpleado";
            this.lblRolEmpleado.Size = new System.Drawing.Size(0, 16);
            this.lblRolEmpleado.TabIndex = 6;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpleado, "Correo", true));
            this.lblCorreo.Location = new System.Drawing.Point(10, 120);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(0, 16);
            this.lblCorreo.TabIndex = 5;
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpleado, "Nombre", true));
            this.lblNombreEmpleado.Location = new System.Drawing.Point(10, 60);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(0, 16);
            this.lblNombreEmpleado.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(10, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Correo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // btnFrmCategoria
            // 
            this.btnFrmCategoria.Location = new System.Drawing.Point(218, 194);
            this.btnFrmCategoria.Name = "btnFrmCategoria";
            this.btnFrmCategoria.Size = new System.Drawing.Size(252, 30);
            this.btnFrmCategoria.TabIndex = 2;
            this.btnFrmCategoria.Text = "Categoria";
            this.btnFrmCategoria.UseVisualStyleBackColor = true;
            this.btnFrmCategoria.Click += new System.EventHandler(this.btnFrmCategoria_Click);
            // 
            // btnFrmArticulo
            // 
            this.btnFrmArticulo.Location = new System.Drawing.Point(218, 65);
            this.btnFrmArticulo.Name = "btnFrmArticulo";
            this.btnFrmArticulo.Size = new System.Drawing.Size(252, 30);
            this.btnFrmArticulo.TabIndex = 3;
            this.btnFrmArticulo.Text = "Articulo";
            this.btnFrmArticulo.UseVisualStyleBackColor = true;
            this.btnFrmArticulo.Click += new System.EventHandler(this.btnFrmArticulo_Click);
            // 
            // btnFrmVenta
            // 
            this.btnFrmVenta.Location = new System.Drawing.Point(218, 101);
            this.btnFrmVenta.Name = "btnFrmVenta";
            this.btnFrmVenta.Size = new System.Drawing.Size(252, 30);
            this.btnFrmVenta.TabIndex = 4;
            this.btnFrmVenta.Text = "Venta";
            this.btnFrmVenta.UseVisualStyleBackColor = true;
            this.btnFrmVenta.Click += new System.EventHandler(this.btnFrmVenta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificarRegistro);
            this.groupBox1.Controls.Add(this.lblNombreLocal);
            this.groupBox1.Controls.Add(this.lblRolEmpleado);
            this.groupBox1.Controls.Add(this.lblCorreo);
            this.groupBox1.Controls.Add(this.lblNombreEmpleado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 279);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfil";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(416, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFrmEmpleados
            // 
            this.btnFrmEmpleados.Location = new System.Drawing.Point(218, 230);
            this.btnFrmEmpleados.Name = "btnFrmEmpleados";
            this.btnFrmEmpleados.Size = new System.Drawing.Size(252, 30);
            this.btnFrmEmpleados.TabIndex = 6;
            this.btnFrmEmpleados.Text = "Empleados";
            this.btnFrmEmpleados.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Location = new System.Drawing.Point(218, 266);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(252, 30);
            this.btnProveedores.TabIndex = 7;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // FrmMenuPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnFrmEmpleados);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFrmVenta);
            this.Controls.Add(this.btnFrmArticulo);
            this.Controls.Add(this.btnFrmCategoria);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFrmLocal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "FrmMenuPpal";
            this.Text = "Menú Principal";
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpleado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombreLocal;
        private System.Windows.Forms.Label lblRolEmpleado;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblNombreEmpleado;
        private System.Windows.Forms.BindingSource bsEmpleado;
        private System.Windows.Forms.Button btnModificarRegistro;
        private System.Windows.Forms.Button btnFrmCategoria;
        private System.Windows.Forms.Button btnFrmArticulo;
        private System.Windows.Forms.Button btnFrmVenta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFrmEmpleados;
        private System.Windows.Forms.Button btnProveedores;
    }
}