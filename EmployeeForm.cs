using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace course
{
    public partial class EmployeeForm : Form
    {
        private int employeeId;

        public EmployeeForm(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные сотрудника, используя employeeId
        }
    }

}
