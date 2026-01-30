using System;
using System.Windows.Forms;

namespace AVCount
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblInvoiceNumber;
        private TextBox txtInvoiceNumber;
        private CheckBox chkManualNumber;
        private Label lblSellerName;
        private TextBox txtSellerName;
        private Label lblSellerEIK;
        private TextBox txtSellerEIK;
        private Label lblSellerAddress;
        private TextBox txtSellerAddress;
        private Label lblBuyerName;
        private TextBox txtBuyerName;
        private Label lblBuyerEIK;
        private TextBox txtBuyerEIK;
        private Label lblBuyerAddress;
        private TextBox txtBuyerAddress;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblUnitPrice;
        private TextBox txtUnitPrice;
        private DataGridView dgvItems;
        private Label lblTotal;
        private Button btnAddItem;
        private Button btnGeneratePdf;
        private Button btnPrint;
        private Label lblCurrency;
        private ComboBox cmbCurrencyMode;

        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPriceBGN;
        private DataGridViewTextBoxColumn colTotalBGN;
        private DataGridViewTextBoxColumn colTotalEUR;
        private Label lblSellerVAT;
        private TextBox txtSellerVAT;
        private Label lblSellerCity;
        private TextBox txtSellerCity;
        private Label lblSellerMOL;
        private TextBox txtSellerMOL;
        private Label lblSellerPhone;
        private TextBox txtSellerPhone;

        private Label lblBuyerVAT;
        private TextBox txtBuyerVAT;
        private Label lblBuyerCity;
        private TextBox txtBuyerCity;
        private Label lblBuyerMOL;
        private TextBox txtBuyerMOL;
        private Label lblBuyerPhone;
        private TextBox txtBuyerPhone;

        private Label lblPaymentMethod;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbBank;
        private Label lblBankName;
        private TextBox txtBankName;
        private Label lblIBAN;
        private TextBox txtIBAN;
        private Label lblBIC;
        private TextBox txtBIC;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.chkManualNumber = new System.Windows.Forms.CheckBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbCurrencyMode = new System.Windows.Forms.ComboBox();
            this.lblSellerName = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.lblSellerEIK = new System.Windows.Forms.Label();
            this.txtSellerEIK = new System.Windows.Forms.TextBox();
            this.lblSellerVAT = new System.Windows.Forms.Label();
            this.txtSellerVAT = new System.Windows.Forms.TextBox();
            this.lblSellerCity = new System.Windows.Forms.Label();
            this.txtSellerCity = new System.Windows.Forms.TextBox();
            this.lblSellerMOL = new System.Windows.Forms.Label();
            this.txtSellerMOL = new System.Windows.Forms.TextBox();
            this.lblSellerPhone = new System.Windows.Forms.Label();
            this.txtSellerPhone = new System.Windows.Forms.TextBox();
            this.lblSellerAddress = new System.Windows.Forms.Label();
            this.txtSellerAddress = new System.Windows.Forms.TextBox();
            this.lblBuyerName = new System.Windows.Forms.Label();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.lblBuyerEIK = new System.Windows.Forms.Label();
            this.txtBuyerEIK = new System.Windows.Forms.TextBox();
            this.lblBuyerVAT = new System.Windows.Forms.Label();
            this.txtBuyerVAT = new System.Windows.Forms.TextBox();
            this.lblBuyerCity = new System.Windows.Forms.Label();
            this.txtBuyerCity = new System.Windows.Forms.TextBox();
            this.lblBuyerMOL = new System.Windows.Forms.Label();
            this.txtBuyerMOL = new System.Windows.Forms.TextBox();
            this.lblBuyerPhone = new System.Windows.Forms.Label();
            this.txtBuyerPhone = new System.Windows.Forms.TextBox();
            this.lblBuyerAddress = new System.Windows.Forms.Label();
            this.txtBuyerAddress = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceBGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalEUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGeneratePdf = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbBank = new System.Windows.Forms.RadioButton();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.lblBIC = new System.Windows.Forms.Label();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ddspercenttextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Location = new System.Drawing.Point(30, 20);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(120, 23);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Номер на фактура:";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(160, 18);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(200, 22);
            this.txtInvoiceNumber.TabIndex = 1;
            // 
            // chkManualNumber
            // 
            this.chkManualNumber.AutoSize = true;
            this.chkManualNumber.Location = new System.Drawing.Point(370, 20);
            this.chkManualNumber.Name = "chkManualNumber";
            this.chkManualNumber.Size = new System.Drawing.Size(167, 20);
            this.chkManualNumber.TabIndex = 2;
            this.chkManualNumber.Text = "Въведи ръчно номер";
            this.chkManualNumber.CheckedChanged += new System.EventHandler(this.chkManualNumber_CheckedChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(560, 20);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(54, 23);
            this.lblCurrency.TabIndex = 3;
            this.lblCurrency.Text = "Валута:";
            // 
            // cmbCurrencyMode
            // 
            this.cmbCurrencyMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrencyMode.Items.AddRange(new object[] {
            "BGN и EUR",
            "Само EUR"});
            this.cmbCurrencyMode.Location = new System.Drawing.Point(620, 18);
            this.cmbCurrencyMode.Name = "cmbCurrencyMode";
            this.cmbCurrencyMode.Size = new System.Drawing.Size(150, 24);
            this.cmbCurrencyMode.TabIndex = 4;
            // 
            // lblSellerName
            // 
            this.lblSellerName.Location = new System.Drawing.Point(30, 60);
            this.lblSellerName.Name = "lblSellerName";
            this.lblSellerName.Size = new System.Drawing.Size(76, 23);
            this.lblSellerName.TabIndex = 5;
            this.lblSellerName.Text = "Продавач:";
            // 
            // txtSellerName
            // 
            this.txtSellerName.Location = new System.Drawing.Point(112, 57);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(260, 22);
            this.txtSellerName.TabIndex = 6;
            // 
            // lblSellerEIK
            // 
            this.lblSellerEIK.Location = new System.Drawing.Point(420, 60);
            this.lblSellerEIK.Name = "lblSellerEIK";
            this.lblSellerEIK.Size = new System.Drawing.Size(41, 23);
            this.lblSellerEIK.TabIndex = 7;
            this.lblSellerEIK.Text = "ЕИК:";
            // 
            // txtSellerEIK
            // 
            this.txtSellerEIK.Location = new System.Drawing.Point(470, 58);
            this.txtSellerEIK.Name = "txtSellerEIK";
            this.txtSellerEIK.Size = new System.Drawing.Size(200, 22);
            this.txtSellerEIK.TabIndex = 8;
            // 
            // lblSellerVAT
            // 
            this.lblSellerVAT.Location = new System.Drawing.Point(27, 93);
            this.lblSellerVAT.Name = "lblSellerVAT";
            this.lblSellerVAT.Size = new System.Drawing.Size(56, 23);
            this.lblSellerVAT.TabIndex = 9;
            this.lblSellerVAT.Text = "ДДС №:";
            // 
            // txtSellerVAT
            // 
            this.txtSellerVAT.Location = new System.Drawing.Point(100, 91);
            this.txtSellerVAT.Name = "txtSellerVAT";
            this.txtSellerVAT.Size = new System.Drawing.Size(150, 22);
            this.txtSellerVAT.TabIndex = 10;
            // 
            // lblSellerCity
            // 
            this.lblSellerCity.Location = new System.Drawing.Point(267, 92);
            this.lblSellerCity.Name = "lblSellerCity";
            this.lblSellerCity.Size = new System.Drawing.Size(50, 23);
            this.lblSellerCity.TabIndex = 11;
            this.lblSellerCity.Text = "Град:";
            // 
            // txtSellerCity
            // 
            this.txtSellerCity.Location = new System.Drawing.Point(323, 93);
            this.txtSellerCity.Name = "txtSellerCity";
            this.txtSellerCity.Size = new System.Drawing.Size(138, 22);
            this.txtSellerCity.TabIndex = 12;
            // 
            // lblSellerMOL
            // 
            this.lblSellerMOL.Location = new System.Drawing.Point(470, 94);
            this.lblSellerMOL.Name = "lblSellerMOL";
            this.lblSellerMOL.Size = new System.Drawing.Size(40, 23);
            this.lblSellerMOL.TabIndex = 13;
            this.lblSellerMOL.Text = "МОЛ:";
            // 
            // txtSellerMOL
            // 
            this.txtSellerMOL.Location = new System.Drawing.Point(516, 93);
            this.txtSellerMOL.Name = "txtSellerMOL";
            this.txtSellerMOL.Size = new System.Drawing.Size(244, 22);
            this.txtSellerMOL.TabIndex = 14;
            // 
            // lblSellerPhone
            // 
            this.lblSellerPhone.Location = new System.Drawing.Point(764, 96);
            this.lblSellerPhone.Name = "lblSellerPhone";
            this.lblSellerPhone.Size = new System.Drawing.Size(70, 23);
            this.lblSellerPhone.TabIndex = 15;
            this.lblSellerPhone.Text = "Телефон:";
            // 
            // txtSellerPhone
            // 
            this.txtSellerPhone.Location = new System.Drawing.Point(840, 97);
            this.txtSellerPhone.Name = "txtSellerPhone";
            this.txtSellerPhone.Size = new System.Drawing.Size(200, 22);
            this.txtSellerPhone.TabIndex = 16;
            // 
            // lblSellerAddress
            // 
            this.lblSellerAddress.Location = new System.Drawing.Point(694, 57);
            this.lblSellerAddress.Name = "lblSellerAddress";
            this.lblSellerAddress.Size = new System.Drawing.Size(50, 23);
            this.lblSellerAddress.TabIndex = 17;
            this.lblSellerAddress.Text = "Адрес:";
            // 
            // txtSellerAddress
            // 
            this.txtSellerAddress.Location = new System.Drawing.Point(750, 55);
            this.txtSellerAddress.Name = "txtSellerAddress";
            this.txtSellerAddress.Size = new System.Drawing.Size(180, 22);
            this.txtSellerAddress.TabIndex = 18;
            // 
            // lblBuyerName
            // 
            this.lblBuyerName.Location = new System.Drawing.Point(30, 163);
            this.lblBuyerName.Name = "lblBuyerName";
            this.lblBuyerName.Size = new System.Drawing.Size(70, 23);
            this.lblBuyerName.TabIndex = 19;
            this.lblBuyerName.Text = "Клиент:";
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.Location = new System.Drawing.Point(96, 161);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Size = new System.Drawing.Size(264, 22);
            this.txtBuyerName.TabIndex = 20;
            // 
            // lblBuyerEIK
            // 
            this.lblBuyerEIK.Location = new System.Drawing.Point(379, 164);
            this.lblBuyerEIK.Name = "lblBuyerEIK";
            this.lblBuyerEIK.Size = new System.Drawing.Size(41, 23);
            this.lblBuyerEIK.TabIndex = 21;
            this.lblBuyerEIK.Text = "ЕИК:";
            // 
            // txtBuyerEIK
            // 
            this.txtBuyerEIK.Location = new System.Drawing.Point(423, 164);
            this.txtBuyerEIK.Name = "txtBuyerEIK";
            this.txtBuyerEIK.Size = new System.Drawing.Size(200, 22);
            this.txtBuyerEIK.TabIndex = 22;
            // 
            // lblBuyerVAT
            // 
            this.lblBuyerVAT.Location = new System.Drawing.Point(30, 203);
            this.lblBuyerVAT.Name = "lblBuyerVAT";
            this.lblBuyerVAT.Size = new System.Drawing.Size(70, 23);
            this.lblBuyerVAT.TabIndex = 23;
            this.lblBuyerVAT.Text = "ДДС №:";
            // 
            // txtBuyerVAT
            // 
            this.txtBuyerVAT.Location = new System.Drawing.Point(100, 199);
            this.txtBuyerVAT.Name = "txtBuyerVAT";
            this.txtBuyerVAT.Size = new System.Drawing.Size(150, 22);
            this.txtBuyerVAT.TabIndex = 24;
            // 
            // lblBuyerCity
            // 
            this.lblBuyerCity.Location = new System.Drawing.Point(637, 166);
            this.lblBuyerCity.Name = "lblBuyerCity";
            this.lblBuyerCity.Size = new System.Drawing.Size(47, 23);
            this.lblBuyerCity.TabIndex = 25;
            this.lblBuyerCity.Text = "Град:";
            // 
            // txtBuyerCity
            // 
            this.txtBuyerCity.Location = new System.Drawing.Point(693, 167);
            this.txtBuyerCity.Name = "txtBuyerCity";
            this.txtBuyerCity.Size = new System.Drawing.Size(107, 22);
            this.txtBuyerCity.TabIndex = 26;
            // 
            // lblBuyerMOL
            // 
            this.lblBuyerMOL.Location = new System.Drawing.Point(273, 199);
            this.lblBuyerMOL.Name = "lblBuyerMOL";
            this.lblBuyerMOL.Size = new System.Drawing.Size(40, 23);
            this.lblBuyerMOL.TabIndex = 27;
            this.lblBuyerMOL.Text = "МОЛ:";
            // 
            // txtBuyerMOL
            // 
            this.txtBuyerMOL.Location = new System.Drawing.Point(323, 200);
            this.txtBuyerMOL.Name = "txtBuyerMOL";
            this.txtBuyerMOL.Size = new System.Drawing.Size(337, 22);
            this.txtBuyerMOL.TabIndex = 28;
            // 
            // lblBuyerPhone
            // 
            this.lblBuyerPhone.Location = new System.Drawing.Point(691, 203);
            this.lblBuyerPhone.Name = "lblBuyerPhone";
            this.lblBuyerPhone.Size = new System.Drawing.Size(70, 23);
            this.lblBuyerPhone.TabIndex = 29;
            this.lblBuyerPhone.Text = "Телефон:";
            // 
            // txtBuyerPhone
            // 
            this.txtBuyerPhone.Location = new System.Drawing.Point(767, 200);
            this.txtBuyerPhone.Name = "txtBuyerPhone";
            this.txtBuyerPhone.Size = new System.Drawing.Size(200, 22);
            this.txtBuyerPhone.TabIndex = 30;
            // 
            // lblBuyerAddress
            // 
            this.lblBuyerAddress.Location = new System.Drawing.Point(820, 163);
            this.lblBuyerAddress.Name = "lblBuyerAddress";
            this.lblBuyerAddress.Size = new System.Drawing.Size(50, 23);
            this.lblBuyerAddress.TabIndex = 31;
            this.lblBuyerAddress.Text = "Адрес:";
            // 
            // txtBuyerAddress
            // 
            this.txtBuyerAddress.Location = new System.Drawing.Point(880, 161);
            this.txtBuyerAddress.Name = "txtBuyerAddress";
            this.txtBuyerAddress.Size = new System.Drawing.Size(180, 22);
            this.txtBuyerAddress.TabIndex = 32;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(37, 248);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(84, 23);
            this.lblDescription.TabIndex = 33;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(127, 246);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(360, 22);
            this.txtDescription.TabIndex = 34;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(507, 248);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(85, 23);
            this.lblQuantity.TabIndex = 35;
            this.lblQuantity.Text = "Количество:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(597, 246);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(78, 22);
            this.txtQuantity.TabIndex = 36;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Location = new System.Drawing.Point(697, 248);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(70, 23);
            this.lblUnitPrice.TabIndex = 37;
            this.lblUnitPrice.Text = "Ед. цена:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(767, 246);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 22);
            this.txtUnitPrice.TabIndex = 38;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Location = new System.Drawing.Point(880, 238);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(160, 30);
            this.btnAddItem.TabIndex = 39;
            this.btnAddItem.Text = "Добави артикул";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeight = 29;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Quantity,
            this.UnitPriceBGN,
            this.TotalBGN,
            this.TotalEUR});
            this.dgvItems.Location = new System.Drawing.Point(30, 280);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1010, 250);
            this.dgvItems.TabIndex = 40;
            // 
            // Description
            // 
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // Quantity
            // 
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // UnitPriceBGN
            // 
            this.UnitPriceBGN.MinimumWidth = 6;
            this.UnitPriceBGN.Name = "UnitPriceBGN";
            // 
            // TotalBGN
            // 
            this.TotalBGN.MinimumWidth = 6;
            this.TotalBGN.Name = "TotalBGN";
            // 
            // TotalEUR
            // 
            this.TotalEUR.MinimumWidth = 6;
            this.TotalEUR.Name = "TotalEUR";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(680, 548);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Обща сума: 0.00 лв. / 0.00 EUR";
            // 
            // btnGeneratePdf
            // 
            this.btnGeneratePdf.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGeneratePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePdf.Location = new System.Drawing.Point(41, 632);
            this.btnGeneratePdf.Name = "btnGeneratePdf";
            this.btnGeneratePdf.Size = new System.Drawing.Size(200, 40);
            this.btnGeneratePdf.TabIndex = 42;
            this.btnGeneratePdf.Text = "💾 Генерирай PDF";
            this.btnGeneratePdf.UseVisualStyleBackColor = false;
            this.btnGeneratePdf.Click += new System.EventHandler(this.btnGeneratePdf_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(261, 632);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 40);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "🖨️ Принтирай";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Location = new System.Drawing.Point(30, 551);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(150, 23);
            this.lblPaymentMethod.TabIndex = 44;
            this.lblPaymentMethod.Text = "Начин на плащане:";
            // 
            // rbCash
            // 
            this.rbCash.Checked = true;
            this.rbCash.Location = new System.Drawing.Point(198, 547);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(76, 24);
            this.rbCash.TabIndex = 45;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "В брой";
            // 
            // rbBank
            // 
            this.rbBank.Location = new System.Drawing.Point(300, 549);
            this.rbBank.Name = "rbBank";
            this.rbBank.Size = new System.Drawing.Size(135, 24);
            this.rbBank.TabIndex = 46;
            this.rbBank.Text = "Банков превод";
            // 
            // lblBankName
            // 
            this.lblBankName.Location = new System.Drawing.Point(30, 591);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(120, 23);
            this.lblBankName.TabIndex = 47;
            this.lblBankName.Text = "Банка:";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(160, 589);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(260, 22);
            this.txtBankName.TabIndex = 48;
            // 
            // lblIBAN
            // 
            this.lblIBAN.Location = new System.Drawing.Point(440, 591);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(60, 23);
            this.lblIBAN.TabIndex = 49;
            this.lblIBAN.Text = "IBAN:";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(500, 589);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(260, 22);
            this.txtIBAN.TabIndex = 50;
            // 
            // lblBIC
            // 
            this.lblBIC.Location = new System.Drawing.Point(780, 591);
            this.lblBIC.Name = "lblBIC";
            this.lblBIC.Size = new System.Drawing.Size(40, 23);
            this.lblBIC.TabIndex = 51;
            this.lblBIC.Text = "BIC:";
            // 
            // txtBIC
            // 
            this.txtBIC.Location = new System.Drawing.Point(830, 589);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(210, 22);
            this.txtBIC.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "ДДС Процент";
            // 
            // ddspercenttextbox
            // 
            this.ddspercenttextbox.Location = new System.Drawing.Point(540, 551);
            this.ddspercenttextbox.Name = "ddspercenttextbox";
            this.ddspercenttextbox.Size = new System.Drawing.Size(52, 22);
            this.ddspercenttextbox.TabIndex = 54;
            this.ddspercenttextbox.TextChanged += new System.EventHandler(this.ddspercenttextbox_TextChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1080, 730);
            this.Controls.Add(this.ddspercenttextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.chkManualNumber);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbCurrencyMode);
            this.Controls.Add(this.lblSellerName);
            this.Controls.Add(this.txtSellerName);
            this.Controls.Add(this.lblSellerEIK);
            this.Controls.Add(this.txtSellerEIK);
            this.Controls.Add(this.lblSellerVAT);
            this.Controls.Add(this.txtSellerVAT);
            this.Controls.Add(this.lblSellerCity);
            this.Controls.Add(this.txtSellerCity);
            this.Controls.Add(this.lblSellerMOL);
            this.Controls.Add(this.txtSellerMOL);
            this.Controls.Add(this.lblSellerPhone);
            this.Controls.Add(this.txtSellerPhone);
            this.Controls.Add(this.lblSellerAddress);
            this.Controls.Add(this.txtSellerAddress);
            this.Controls.Add(this.lblBuyerName);
            this.Controls.Add(this.txtBuyerName);
            this.Controls.Add(this.lblBuyerEIK);
            this.Controls.Add(this.txtBuyerEIK);
            this.Controls.Add(this.lblBuyerVAT);
            this.Controls.Add(this.txtBuyerVAT);
            this.Controls.Add(this.lblBuyerCity);
            this.Controls.Add(this.txtBuyerCity);
            this.Controls.Add(this.lblBuyerMOL);
            this.Controls.Add(this.txtBuyerMOL);
            this.Controls.Add(this.lblBuyerPhone);
            this.Controls.Add(this.txtBuyerPhone);
            this.Controls.Add(this.lblBuyerAddress);
            this.Controls.Add(this.txtBuyerAddress);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGeneratePdf);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.rbBank);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.lblBIC);
            this.Controls.Add(this.txtBIC);
            this.Name = "MainForm";
            this.Text = "Фактура";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitPriceBGN;
        private DataGridViewTextBoxColumn TotalBGN;
        private DataGridViewTextBoxColumn TotalEUR;
        private BindingSource bindingSource1;
        private Label label1;
        public TextBox ddspercenttextbox;
    }
}
