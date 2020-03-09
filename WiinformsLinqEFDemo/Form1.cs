using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiinformsLinqEFDemo
{
    public partial class Form1 : Form
    {
        #region Global Variables

        NorthwindEntities dbManager = new NorthwindEntities();

        #endregion

        #region Form Events

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Control Events

        private void btnWhere_Click(object sender, EventArgs e)
        {
            //var customers = dbManager.Customers.Where(rec=> rec.Country == "MEXICO" && rec.PostalCode == "05033").ToList();
            var customers = dbManager.Customers.Where(rec => rec.Country == "Mexico" || rec.Country == "Germany").ToList();
            dataGridView1.DataSource = customers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (dbManager.Customers.Any(rec => rec.Country == "India"))
            {
                MessageBox.Show("We have records from India");
            }
            else { MessageBox.Show("We have no records from India"); }
            */

            var record = dbManager.Customers.FirstOrDefault(rec => rec.Country == "India");
            if (record != null)
            { 
            
            }

        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            var distinctCountries = dbManager.Customers.Select(rec => rec.Country).Distinct().ToList();
            foreach (string country in distinctCountries)
            {
                MessageBox.Show(country);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var order1 = dbManager.Orders.First();
        }
    }
}
