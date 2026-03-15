namespace AVCount
{
    partial class ProductSearchForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(96, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Product:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(114, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dgvProducts
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(15, 45);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(460, 220);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);

            // btnSelect
            this.btnSelect.Location = new System.Drawing.Point(320, 280);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 30);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(400, 280);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // ProductSearchForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 325);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnAdd);
            this.Name = "ProductSearchForm";
            this.Text = "Product Manager";

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}