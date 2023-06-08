using System.Data;
using System.Data.SqlClient;

namespace Plastinaflix
{
    public partial class controleDeFilmes : Form
    {
        public controleDeFilmes()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Obtém os valores dos campos do formulário
            string tituloFilme = textBox1.Text;
            string descricaoFilme = textBox5.Text;
            string duracaoFilme = textBox2.Text;


            // Cria uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um objeto SqlCommand para executar a procedure
                using (SqlCommand command = new SqlCommand("sp_popular_filmes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@titulo", tituloFilme);
                    command.Parameters.AddWithValue("@descricao", descricaoFilme);
                    command.Parameters.AddWithValue("@duracao", duracaoFilme);

                    // Executa a procedure
                    command.ExecuteNonQuery();

                    MessageBox.Show("Procedure executada com sucesso!");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Limpar os campos do formulário
            textBox5.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
