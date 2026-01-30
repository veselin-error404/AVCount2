using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AVCount
{
    public partial class MainForm : Form
    {


        private readonly CultureInfo bg = new CultureInfo("bg-BG");
        private readonly List<InvoiceItem> items = new List<InvoiceItem>();
        private const string numberFile = "last_number.txt";

        public MainForm()
        {
            InitializeComponent();
            LoadLastInvoiceNumber();
            SetupGridColumnNames();
            UpdateBankFieldsVisibility();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateBankFieldsVisibility();
        }

        private void PaymentMethodChanged(object sender, EventArgs e)
        {
            UpdateBankFieldsVisibility();
        }

        private void UpdateBankFieldsVisibility()
        {
            bool show = rbBank.Checked;

            lblBankName.Visible = show;
            txtBankName.Visible = show;
            lblIBAN.Visible = show;
            txtIBAN.Visible = show;
            lblBIC.Visible = show;
            txtBIC.Visible = show;
        }

        private void SetupGridColumnNames()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("Description", "Описание");
            dgvItems.Columns.Add("Quantity", "Количество");
            dgvItems.Columns.Add("UnitPriceEUR", "Ед. цена (€)");
            dgvItems.Columns.Add("TotalEUR", "Общо (€)");
        }

        private void LoadLastInvoiceNumber()
        {
            if (File.Exists(numberFile))
            {
                var text = File.ReadAllText(numberFile).Trim();
                if (long.TryParse(text, out long n))
                    txtInvoiceNumber.Text = n.ToString("D10");
                else
                    txtInvoiceNumber.Text = "0000000001";
            }
            else
            {
                txtInvoiceNumber.Text = "0000000001";
            }
        }

        private void SaveNextInvoiceNumber()
        {
            if (long.TryParse(txtInvoiceNumber.Text, out long cur))
                File.WriteAllText(numberFile, (cur + 1).ToString());
        }

        private void chkManualNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtInvoiceNumber.ReadOnly = !chkManualNumber.Checked;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Моля, въведете описание.", "Грешка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), NumberStyles.Integer, bg, out int qty) || qty <= 0)
            {
                MessageBox.Show("Невалидно количество.", "Грешка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), NumberStyles.Number, bg, out decimal unitPriceEUR) || unitPriceEUR < 0)
            {
                MessageBox.Show("Невалидна единична цена.", "Грешка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new InvoiceItem
            {
                Description = txtDescription.Text.Trim(),
                Quantity = qty,
                UnitPriceEUR = Math.Round(unitPriceEUR, 2)
            };

            items.Add(item);

            dgvItems.Rows.Add(
                item.Description,
                item.Quantity,
                item.UnitPriceEUR.ToString("N2", bg),
                item.TotalEUR.ToString("N2", bg)
            );

            UpdateTotals();

            txtDescription.Clear();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
            txtDescription.Focus();
        }

        private void UpdateTotals()
        {
            decimal sumEUR = 0m;

            foreach (var it in items)
                sumEUR += it.TotalEUR;

            lblTotal.Text = $"Обща сума: {sumEUR:N2} €";
        }

        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Добавете поне един артикул.", "Грешка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal ddsPercent;

            string text = ddspercenttextbox.Text.Trim().Replace("%", "");

            if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out ddsPercent))
            {
                MessageBox.Show("Невалидна стойност за ДДС.");
                return;
            }

            ddsPercent /= 100m; // 20 → 0.20
            var invoice = new Invoice
            {
                InvoiceNumber = txtInvoiceNumber.Text.Trim(),
                Date = DateTime.Now,

                SellerName = txtSellerName.Text.Trim(),
                SellerEIK = txtSellerEIK.Text.Trim(),
                SellerVAT = txtSellerVAT.Text.Trim(),
                SellerCity = txtSellerCity.Text.Trim(),
                SellerMOL = txtSellerMOL.Text.Trim(),
                SellerPhone = txtSellerPhone.Text.Trim(),
                SellerAddress = txtSellerAddress.Text.Trim(),

                BuyerName = txtBuyerName.Text.Trim(),
                BuyerEIK = txtBuyerEIK.Text.Trim(),
                BuyerVAT = txtBuyerVAT.Text.Trim(),
                BuyerCity = txtBuyerCity.Text.Trim(),
                BuyerMOL = txtBuyerMOL.Text.Trim(),
                BuyerPhone = txtBuyerPhone.Text.Trim(),
                BuyerAddress = txtBuyerAddress.Text.Trim(),

                Items = new List<InvoiceItem>(items),
                PaymentMethod = rbBank.Checked ? PaymentMethod.Bank : PaymentMethod.Cash,
                BankName = txtBankName.Text.Trim(),
                IBAN = txtIBAN.Text.Trim(),
                BIC = txtBIC.Text.Trim()
            };

            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"Фактура_{invoice.InvoiceNumber}.pdf");

            try
            {
                PdfGenerator.CreateInvoicePdf(invoice, filePath, ddsPercent);

                MessageBox.Show($"Фактурата е генерирана:\n{filePath}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveNextInvoiceNumber();
                items.Clear();
                dgvItems.Rows.Clear();
                UpdateTotals();
                LoadLastInvoiceNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при генериране на PDF:\n" + ex.Message,
                    "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"Фактура_{txtInvoiceNumber.Text}.pdf");

            if (!File.Exists(pdfPath))
            {
                MessageBox.Show("PDF не е намерен.", "Грешка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Diagnostics.Process.Start(pdfPath);
        }

        private void ddspercenttextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
