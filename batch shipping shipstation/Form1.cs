using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using shipstationtest4.shipstation;
using System.Threading;


namespace shipstationtest4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void next_Click(object sender, EventArgs e)
        {
            ShipStationEntities entities = new ShipStationEntities(new Uri("http://data.shipstation.com/1.2"));
            entities.Credentials = new System.Net.NetworkCredential("eewholesale", "kennyb15");

            int nubs = 200;
            int i = 0;

            string[] orders = bin.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int sack = orders.Length;

            

            try
            {
            goober:
                var orderToUpdate = entities.Orders.Where(x => x.OrderNumber == orders[i]).FirstOrDefault();

                int taint = nubs + i;



                orderToUpdate.CustomField1 = taint.ToString();

                entities.UpdateObject(orderToUpdate);
                entities.SaveChanges();

                if (i >= sack)
                {
                    Environment.Exit(0);
                }

                i++;
                goto goober;
            }
           
           catch 
            {
                Environment.Exit(0);
            }

            Environment.Exit(0);
          }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        }
    }

