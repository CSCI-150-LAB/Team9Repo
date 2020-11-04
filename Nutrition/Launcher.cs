using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nutrition
{
    public partial class Nutrition : Form
    {
        public Nutrition()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register y = new Register();
            y.Show();
            this.Close();
        }
    }
}
