using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            LoadSellerInfo();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateBankFieldsVisibility();
        }

        private void PaymentMethodChanged(object sender, EventArgs e)
        {
            UpdateBankFieldsVisibility();
        }
        private const string productsFile = "products.json";
        private List<Product> LoadProducts()
        {
            if (!File.Exists(productsFile))
                return new List<Product>();

            string json = File.ReadAllText(productsFile);

            var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(json);

            return products ?? new List<Product>();
        }
        private void OpenProductSearch()
        {
            ProductSearchForm form = new ProductSearchForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Product product = form.SelectedProduct;

                if (product != null)
                {
                    txtDescription.Text = product.Description;
                    txtUnitPrice.Text = product.UnitPriceEUR.ToString("N2");
                }
            }
        }
        private void SaveProduct()
        {
            var products = LoadProducts();

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Въведете описание на продукта.");
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Невалидна цена.");
                return;
            }

            Product product = new Product
            {
                Description = txtDescription.Text.Trim(),
                UnitPriceEUR = price
            };

            products.Add(product);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(productsFile, json);

            MessageBox.Show("Продуктът е запазен.");
        }
        private void LoadProduct(Product product)
        {
            txtDescription.Text = product.Description;
            txtUnitPrice.Text = product.UnitPriceEUR.ToString("N2");
        }
        private void SelectProduct()
        {
            var products = LoadProducts();

            if (products.Count == 0)
            {
                MessageBox.Show("Няма запазени продукти.");
                return;
            }

            Product product = products[0]; // simple example

            txtDescription.Text = product.Description;
            txtUnitPrice.Text = product.UnitPriceEUR.ToString("N2");
        }
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }
        private void btnLoadProduct_Click(object sender, EventArgs e)
        {
            OpenProductSearch();
        }

        //sellet sections
        private const string sellerFile = "seller.json";
        private void SaveSellerInfo()
        {
            var seller = new SellerInfo
            {
                Name = txtSellerName.Text.Trim(),
                EIK = txtSellerEIK.Text.Trim(),
                VAT = txtSellerVAT.Text.Trim(),
                City = txtSellerCity.Text.Trim(),
                MOL = txtSellerMOL.Text.Trim(),
                Phone = txtSellerPhone.Text.Trim(),
                Address = txtSellerAddress.Text.Trim(),

                BankName = txtBankName.Text.Trim(),
                IBAN = txtIBAN.Text.Trim(),
                BIC = txtBIC.Text.Trim()
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(seller, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(sellerFile, json);

            MessageBox.Show("Фирмената информация е запазена.");
        }
        private void btnSaveSeller_Click(object sender, EventArgs e)
        {
            SaveSellerInfo();
        }
        private void LoadSellerInfo()
        {
            if (!File.Exists(sellerFile))
                return;

            string json = File.ReadAllText(sellerFile);

            SellerInfo seller = Newtonsoft.Json.JsonConvert.DeserializeObject<SellerInfo>(json);

            if (seller == null)
                return;

            txtSellerName.Text = seller.Name;
            txtSellerEIK.Text = seller.EIK;
            txtSellerVAT.Text = seller.VAT;
            txtSellerCity.Text = seller.City;
            txtSellerMOL.Text = seller.MOL;
            txtSellerPhone.Text = seller.Phone;
            txtSellerAddress.Text = seller.Address;

            txtBankName.Text = seller.BankName;
            txtIBAN.Text = seller.IBAN;
            txtBIC.Text = seller.BIC;
        }

        // client sections
        private const string clientsFile = "clients.json";

        private void SaveClient()
        {
            var clients = LoadClients();

            var client = new Client
            {
                Name = txtBuyerName.Text.Trim(),
                EIK = txtBuyerEIK.Text.Trim(),
                VAT = txtBuyerVAT.Text.Trim(),
                City = txtBuyerCity.Text.Trim(),
                MOL = txtBuyerMOL.Text.Trim(),
                Phone = txtBuyerPhone.Text.Trim(),
                Address = txtBuyerAddress.Text.Trim()
            };

            clients.Add(client);

            // Save the FULL LIST (not a single client)
            string json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            File.WriteAllText(clientsFile, json);

            MessageBox.Show("Клиентът е запазен.");
        }

        private void LoadClient()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Client files (*.client)|*.client";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(ofd.FileName);

                Client client = JsonConvert.DeserializeObject<Client>(json);

                if (client == null) return;

                txtBuyerName.Text = client.Name;
                txtBuyerEIK.Text = client.EIK;
                txtBuyerVAT.Text = client.VAT;
                txtBuyerCity.Text = client.City;
                txtBuyerMOL.Text = client.MOL;
                txtBuyerPhone.Text = client.Phone;
                txtBuyerAddress.Text = client.Address;

                MessageBox.Show("Клиентът е зареден.");
            }
        }

        private List<Client> LoadClients()
        {
            if (!File.Exists(clientsFile))
                return new List<Client>();

            string json = File.ReadAllText(clientsFile).Trim();

            try
            {
                if (json.StartsWith("["))
                {
                    return JsonConvert.DeserializeObject<List<Client>>(json) ?? new List<Client>();
                }
                else
                {
                    // old single-client format
                    Client single = JsonConvert.DeserializeObject<Client>(json);
                    var list = new List<Client>();

                    if (single != null)
                        list.Add(single);

                    return list;
                }
            }
            catch
            {
                return new List<Client>();
            }
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            SaveClient();
        }

        private void OpenClientSearch()
        {
            ClientSearchForm form = new ClientSearchForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Client client = form.SelectedClient;

                if (client != null)
                {
                    txtBuyerName.Text = client.Name;
                    txtBuyerEIK.Text = client.EIK;
                    txtBuyerVAT.Text = client.VAT;
                    txtBuyerCity.Text = client.City;
                    txtBuyerMOL.Text = client.MOL;
                    txtBuyerPhone.Text = client.Phone;
                    txtBuyerAddress.Text = client.Address;
                }
            }
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            OpenClientSearch();
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
            DateTime dateText = dateTimePicker1.Value;

            ddsPercent /= 100m; // 20 → 0.20
            var invoice = new Invoice
            {
                InvoiceNumber = txtInvoiceNumber.Text.Trim(),
                Date = dateText,

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

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtBuyerPhone_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
