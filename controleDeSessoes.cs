using System.Data;
using System.Data.SqlClient;

namespace Plastinaflix
{
    public partial class controleDeSessoes : Form
    {
        public controleDeSessoes()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Obtém os valores dos campos do formulário
            string tituloFilme = textBox1.Text;
            string numeroSala = textBox5.Text;
            //string numeroSessao = textBox2.Text;
            DateTime data = dateTimePicker.Value.Date;
            TimeSpan horario = hourPicker.Value.TimeOfDay;


            // Cria uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um objeto SqlCommand para executar a procedure
                using (SqlCommand command = new SqlCommand("sp_popular_sessoes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Adiciona os parâmetros necessários e define seus valores
                    command.Parameters.AddWithValue("@titulo", tituloFilme);
                    //command.Parameters.AddWithValue("@sessao_id", numeroSessao);
                    //command.Parameters.AddWithValue("@sala_id", numeroSala);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@horario", horario);

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
            dateTimePicker.Value = DateTime.Now;
            hourPicker.Value = DateTime.Now;
        }
    }
}
