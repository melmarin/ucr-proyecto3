using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clienteServicioPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CamelServiceReference.ServiceClient client= new CamelServiceReference.ServiceClient();

            dataGridView1.DataSource = client.getTextoDePrueba();
        }

        private void tb_resultado_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CamelServiceReference.ServiceClient client = new CamelServiceReference.ServiceClient();

            tb_resultado.Text = client.getTextoDePrueba();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
