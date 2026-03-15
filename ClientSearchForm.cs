using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace AVCount
{
    public partial class ClientSearchForm : Form
    {
        public Client SelectedClient { get; private set; }
        private List<Client> clients = new List<Client>();

        public ClientSearchForm()
        {
            InitializeComponent();
            LoadClients();
        }
        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClients.CurrentRow == null)
                return;

            SelectedClient = (Client)dgvClients.CurrentRow.DataBoundItem;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void LoadClients()
        {
            if (!File.Exists("clients.json"))
                return;

            string json = File.ReadAllText("clients.json");

            clients = JsonConvert.DeserializeObject<List<Client>>(json);

            if (clients == null)
                clients = new List<Client>();

            dgvClients.DataSource = clients;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            var filtered = clients
                .Where(c => c.Name != null && c.Name.ToLower().Contains(search))
                .ToList();

            dgvClients.DataSource = filtered;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
                return;

            SelectedClient = (Client)dgvClients.CurrentRow.DataBoundItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}