using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace AVCount
{
    public partial class ProductSearchForm : Form
    {
        private const string productsFile = "products.json";

        public Product SelectedProduct { get; private set; }

        private List<Product> products = new List<Product>();

        public ProductSearchForm()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            if (!File.Exists(productsFile))
            {
                products = new List<Product>();
                dgvProducts.DataSource = products;
                return;
            }

            try
            {
                string json = File.ReadAllText(productsFile);

                products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products;
            }
            catch
            {
                MessageBox.Show("Error loading products file.");
                products = new List<Product>();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            var filtered = products
                .Where(p => p.Description.ToLower().Contains(search))
                .ToList();

            dgvProducts.DataSource = filtered;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            SelectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Product name:", "New Product", "");

            // check cancel or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Product name cannot be empty.");
                return;
            }

            string priceText = Microsoft.VisualBasic.Interaction.InputBox(
                "Unit price (€):", "New Product", "");

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            Product product = new Product
            {
                Description = name.Trim(),
                UnitPriceEUR = price
            };

            products.Add(product);

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(productsFile, json);

            // reload list
            LoadProducts();

            MessageBox.Show("Product saved.");
        }
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelect_Click(sender, e);
        }
    }
}