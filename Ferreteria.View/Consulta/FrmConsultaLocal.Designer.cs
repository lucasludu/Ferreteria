namespace Ferreteria.View.Consulta
{
    partial class FrmConsultaLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaLocal));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.stripMessage = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCantRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.bsLocales = new System.Windows.Forms.BindingSource(this.components);
            this.bsLocal = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLocales = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbxEvents = new System.Windows.Forms.GroupBox();
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.stripMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocales)).BeginInit();
            this.gbxEvents.SuspendLayout();
            this.gbxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(197, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.Image = ((System.Drawing.Image)(resources.GetObject("btnClean.Image")));
            this.btnClean.Location = new System.Drawing.Point(151, 37);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(40, 40);
            this.btnClean.TabIndex = 2;
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleDescription = "";
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(9, 37);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(243, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // stripMessage
            // 
            this.stripMessage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stripMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCantRegistros});
            this.stripMessage.Location = new System.Drawing.Point(0, 427);
            this.stripMessage.Name = "stripMessage";
            this.stripMessage.Size = new System.Drawing.Size(682, 26);
            this.stripMessage.TabIndex = 5;
            this.stripMessage.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(170, 20);
            this.toolStripStatusLabel1.Text = "Cantidad de Registros: ";
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantRegistros.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(0, 20);
            // 
            // bsLocales
            // 
            this.bsLocales.DataSource = typeof(Ferreteria.Models.DTOs.LocalDto);
            // 
            // bsLocal
            // 
            this.bsLocal.DataSource = typeof(Ferreteria.Models.Local);
            // 
            // dgvLocales
            // 
            this.dgvLocales.AllowUserToAddRows = false;
            this.dgvLocales.AllowUserToDeleteRows = false;
            this.dgvLocales.AllowUserToResizeColumns = false;
            this.dgvLocales.AllowUserToResizeRows = false;
            this.dgvLocales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocales.AutoGenerateColumns = false;
            this.dgvLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.dgvColEliminar});
            this.dgvLocales.DataSource = this.bsLocales;
            this.dgvLocales.Location = new System.Drawing.Point(12, 121);
            this.dgvLocales.Name = "dgvLocales";
            this.dgvLocales.ReadOnly = true;
            this.dgvLocales.RowHeadersVisible = false;
            this.dgvLocales.RowHeadersWidth = 51;
            this.dgvLocales.RowTemplate.Height = 24;
            this.dgvLocales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocales.Size = new System.Drawing.Size(658, 303);
            this.dgvLocales.TabIndex = 6;
            this.dgvLocales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocales_CellClick);
            this.dgvLocales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocales_CellDoubleClick);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgvColEliminar
            // 
            this.dgvColEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvColEliminar.HeaderText = "";
            this.dgvColEliminar.Image = ((System.Drawing.Image)(resources.GetObject("dgvColEliminar.Image")));
            this.dgvColEliminar.MinimumWidth = 6;
            this.dgvColEliminar.Name = "dgvColEliminar";
            this.dgvColEliminar.ReadOnly = true;
            this.dgvColEliminar.Width = 6;
            // 
            // gbxEvents
            // 
            this.gbxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEvents.Controls.Add(this.btnShow);
            this.gbxEvents.Controls.Add(this.btnClean);
            this.gbxEvents.Controls.Add(this.btnAdd);
            this.gbxEvents.Controls.Add(this.btnExcel);
            this.gbxEvents.Controls.Add(this.btnClose);
            this.gbxEvents.Location = new System.Drawing.Point(381, 12);
            this.gbxEvents.Name = "gbxEvents";
            this.gbxEvents.Size = new System.Drawing.Size(289, 100);
            this.gbxEvents.TabIndex = 7;
            this.gbxEvents.TabStop = false;
            // 
            // gbxFilter
            // 
            this.gbxFilter.Controls.Add(this.label2);
            this.gbxFilter.Controls.Add(this.txtFilter);
            this.gbxFilter.Location = new System.Drawing.Point(12, 12);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(363, 100);
            this.gbxFilter.TabIndex = 17;
            this.gbxFilter.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filtrar por nombre";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(6, 37);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(351, 22);
            this.txtFilter.TabIndex = 15;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnShow
            // 
            this.btnShow.AccessibleName = "";
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(55, 37);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(40, 40);
            this.btnShow.TabIndex = 5;
            this.btnShow.Tag = "";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // FrmConsultaLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.gbxFilter);
            this.Controls.Add(this.gbxEvents);
            this.Controls.Add(this.dgvLocales);
            this.Controls.Add(this.stripMessage);
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "FrmConsultaLocal";
            this.Text = "Consulta Local";
            this.Load += new System.EventHandler(this.FrmConsultaLocal_Load);
            this.stripMessage.ResumeLayout(false);
            this.stripMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocales)).EndInit();
            this.gbxEvents.ResumeLayout(false);
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.StatusStrip stripMessage;
        private System.Windows.Forms.BindingSource bsLocales;
        private System.Windows.Forms.BindingSource bsLocal;
        private System.Windows.Forms.DataGridView dgvLocales;
        private System.Windows.Forms.GroupBox gbxEvents;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCantRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvColEliminar;
        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnShow;
    }
}