using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plastinaflix
{
    public partial class Orquestrador : Form
    {
        public Orquestrador()
        {
            InitializeComponent();
        }

        private void btnAdicionarSessão_Click(object sender, EventArgs e)
        {
            controleDeFilmes f = new controleDeFilmes();
            f.Show();
        }

        private void btnControleSessoes_Click(object sender, EventArgs e)
        {
            controleDeSessoes f = new controleDeSessoes();
            f.Show();
        }

        private void btnCriarReserva_Click(object sender, EventArgs e)
        {
            criarReserva f = new criarReserva();
            f.Show();
        }
    }
}
