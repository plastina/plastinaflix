using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Plastinaflix
{
    public partial class criarReserva : Form
    {
        List<int> _idAssentos = new();
        List<int> assentosReservados = new();
        List<Button> _botoes = new();
        public criarReserva()
        {
            InitializeComponent();
            _botoes.Add(button1);
            _botoes.Add(button2);
            _botoes.Add(button3);
            _botoes.Add(button4);
            _botoes.Add(button5);
            _botoes.Add(button6);
            _botoes.Add(button7);
            _botoes.Add(button8);
            _botoes.Add(button9);
            _botoes.Add(button10);
            _botoes.Add(button11);
            _botoes.Add(button12);
            _botoes.Add(button13);
            _botoes.Add(button14);
            _botoes.Add(button15);
            _botoes.Add(button16);
            _botoes.Add(button17);
            _botoes.Add(button18);
            _botoes.Add(button19);
            _botoes.Add(button20);
            GetAssentosReservados();
        }

        private void buttonCompra_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text.Length < 20 || string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Por favor, preencha os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
                {
                    if (_idAssentos.Count > 0)
                    {
                        connection.Open();
                        foreach (var assento in _idAssentos)
                        {
                            using (SqlCommand procedureCommand = new SqlCommand("sp_reservar_assento", connection))
                            {
                                procedureCommand.CommandType = CommandType.StoredProcedure;

                                procedureCommand.Parameters.AddWithValue("@assento_id", assento);

                                procedureCommand.ExecuteNonQuery();

                            }
                        }
                        assentosReservados.AddRange(_idAssentos);

                        _idAssentos.Clear();
                        LimpaCampos();
                        connection.Close();
                        MessageBox.Show("Compra realizada com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecione um assento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void GetAssentosReservados()
        {

            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT assento_id FROM Reserva WHERE STATUS = 1", connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int assentoId = (int)reader["assento_id"];
                        assentosReservados.Add(assentoId);
                    }

                    reader.Close();
                }
            }
            foreach (var item in assentosReservados)
            {
                _botoes[item - 1].BackColor = Color.Red;
            }
        }



        private void buttonLimpa_Click_1(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            textBox5.Text = string.Empty;
            textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(1))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button1.BackColor == Color.ForestGreen)
            {
                button1.BackColor = Color.Red;
                if (!_idAssentos.Contains(1))
                {
                    _idAssentos.Add(1);
                }
            }

            else if (button1.BackColor == Color.Red)
            {
                button1.BackColor = Color.ForestGreen;
                _idAssentos.Remove(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(2))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button2.BackColor == Color.ForestGreen)
            {
                button2.BackColor = Color.Red;
                if (!_idAssentos.Contains(2))
                {
                    _idAssentos.Add(2);
                }
            }

            else if (button2.BackColor == Color.Red)
            {
                button2.BackColor = Color.ForestGreen;
                _idAssentos.Remove(2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(3))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button3.BackColor == Color.ForestGreen)
            {
                button3.BackColor = Color.Red;
                if (!_idAssentos.Contains(3))
                {
                    _idAssentos.Add(3);
                }
            }

            else if (button3.BackColor == Color.Red)
            {
                button3.BackColor = Color.ForestGreen;
                _idAssentos.Remove(3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(4))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button4.BackColor == Color.ForestGreen)
            {
                button4.BackColor = Color.Red;
                if (!_idAssentos.Contains(4))
                {
                    _idAssentos.Add(4);
                }
            }

            else if (button4.BackColor == Color.Red)
            {
                button4.BackColor = Color.ForestGreen;
                _idAssentos.Remove(4);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(5))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button5.BackColor == Color.ForestGreen)
            {
                button5.BackColor = Color.Red;
                if (!_idAssentos.Contains(5))
                {
                    _idAssentos.Add(5);
                }
            }

            else if (button5.BackColor == Color.Red)
            {
                button5.BackColor = Color.ForestGreen;
                _idAssentos.Remove(5);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(6))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button6.BackColor == Color.ForestGreen)
            {
                button6.BackColor = Color.Red;
                if (!_idAssentos.Contains(6))
                {
                    _idAssentos.Add(6);
                }
            }

            else if (button6.BackColor == Color.Red)
            {
                button6.BackColor = Color.ForestGreen;
                _idAssentos.Remove(6);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(7))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button7.BackColor == Color.ForestGreen)
            {
                button7.BackColor = Color.Red;
                if (!_idAssentos.Contains(7))
                {
                    _idAssentos.Add(7);
                }
            }

            else if (button7.BackColor == Color.Red)
            {
                button7.BackColor = Color.ForestGreen;
                _idAssentos.Remove(7);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(8))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button8.BackColor == Color.ForestGreen)
            {
                button8.BackColor = Color.Red;
                if (!_idAssentos.Contains(8))
                {
                    _idAssentos.Add(8);
                }
            }

            else if (button8.BackColor == Color.Red)
            {
                button8.BackColor = Color.ForestGreen;
                _idAssentos.Remove(8);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(9))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button9.BackColor == Color.ForestGreen)
            {
                button9.BackColor = Color.Red;
                if (!_idAssentos.Contains(9))
                {
                    _idAssentos.Add(9);
                }
            }

            else if (button9.BackColor == Color.Red)
            {
                button9.BackColor = Color.ForestGreen;
                _idAssentos.Remove(9);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(10))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button10.BackColor == Color.ForestGreen)
            {
                button10.BackColor = Color.Red;
                if (!_idAssentos.Contains(10))
                {
                    _idAssentos.Add(10);
                }
            }

            else if (button10.BackColor == Color.Red)
            {
                button10.BackColor = Color.ForestGreen;
                _idAssentos.Remove(10);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(11))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button11.BackColor == Color.ForestGreen)
            {
                button11.BackColor = Color.Red;
                if (!_idAssentos.Contains(11))
                {
                    _idAssentos.Add(11);
                }
            }

            else if (button11.BackColor == Color.Red)
            {
                button11.BackColor = Color.ForestGreen;
                _idAssentos.Remove(11);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(12))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button12.BackColor == Color.ForestGreen)
            {
                button12.BackColor = Color.Red;
                if (!_idAssentos.Contains(12))
                {
                    _idAssentos.Add(12);
                }
            }

            else if (button12.BackColor == Color.Red)
            {
                button12.BackColor = Color.ForestGreen;
                _idAssentos.Remove(12);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(13))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button13.BackColor == Color.ForestGreen)
            {
                button13.BackColor = Color.Red;
                if (!_idAssentos.Contains(13))
                {
                    _idAssentos.Add(13);
                }
            }

            else if (button13.BackColor == Color.Red)
            {
                button13.BackColor = Color.ForestGreen;
                _idAssentos.Remove(13);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(14))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button14.BackColor == Color.ForestGreen)
            {
                button14.BackColor = Color.Red;
                if (!_idAssentos.Contains(14))
                {
                    _idAssentos.Add(14);
                }
            }

            else if (button14.BackColor == Color.Red)
            {
                button14.BackColor = Color.ForestGreen;
                _idAssentos.Remove(14);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(15))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button15.BackColor == Color.ForestGreen)
            {
                button15.BackColor = Color.Red;
                if (!_idAssentos.Contains(15))
                {
                    _idAssentos.Add(15);
                }
            }

            else if (button15.BackColor == Color.Red)
            {
                button15.BackColor = Color.ForestGreen;
                _idAssentos.Remove(15);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(16))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button16.BackColor == Color.ForestGreen)
            {
                button16.BackColor = Color.Red;
                if (!_idAssentos.Contains(16))
                {
                    _idAssentos.Add(16);
                }
            }

            else if (button16.BackColor == Color.Red)
            {
                button16.BackColor = Color.ForestGreen;
                _idAssentos.Remove(16);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(17))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button17.BackColor == Color.ForestGreen)
            {
                button17.BackColor = Color.Red;
                if (!_idAssentos.Contains(17))
                {
                    _idAssentos.Add(17);
                }
            }

            else if (button17.BackColor == Color.Red)
            {
                button17.BackColor = Color.ForestGreen;
                _idAssentos.Remove(17);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(18))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button18.BackColor == Color.ForestGreen)
            {
                button18.BackColor = Color.Red;
                if (!_idAssentos.Contains(18))
                {
                    _idAssentos.Add(18);
                }
            }

            else if (button18.BackColor == Color.Red)
            {
                button18.BackColor = Color.ForestGreen;
                _idAssentos.Remove(18);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(19))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button19.BackColor == Color.ForestGreen)
            {
                button19.BackColor = Color.Red;
                if (!_idAssentos.Contains(19))
                {
                    _idAssentos.Add(19);
                }
            }

            else if (button19.BackColor == Color.Red)
            {
                button19.BackColor = Color.ForestGreen;
                _idAssentos.Remove(19);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (assentosReservados.Contains(20))
            {
                MessageBox.Show("Assento já esta reservado, por favor escolha outro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (button20.BackColor == Color.ForestGreen)
            {
                button20.BackColor = Color.Red;
                if (!_idAssentos.Contains(20))
                {
                    _idAssentos.Add(20);
                }
            }

            else if (button20.BackColor == Color.Red)
            {
                button20.BackColor = Color.ForestGreen;
                _idAssentos.Remove(20);
            }
        }

        private void criarReserva_Load(object sender, EventArgs e)
        {

        }
    }
}