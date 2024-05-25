using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace course
{
    public partial class DoctorForm : Form
    {
        private int doctorId;

        public DoctorForm(int doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные врача, используя doctorId
        }
    }
}
