using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace course
{
    public partial class CoachForm : Form
    {
        private int coachId;

        public CoachForm(int coachId)
        {
            InitializeComponent();
            this.coachId = coachId;
        }

        private void CoachForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные тренера, используя coachId
        }
    }

}
