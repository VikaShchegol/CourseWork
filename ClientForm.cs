using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace course
{
    public partial class ClientForm : Form
    {
        private int clientId;

        public ClientForm(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
