using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aula13_banco
{
    public partial class CadastrarModalidade : Form
    {
        public CadastrarModalidade()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "")) {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                bool existe = false;
                Modalidade m = new Modalidade();
                MySqlDataReader le = m.consultarTodasModalidades();
                while (le.Read())
                {
                    if (textBox1.Text == le["descricaoModalidade"].ToString())
                    {
                        existe = true;
                        break;
                    }
                }
                DAO_Conexao.con.Close();

                if (existe)
                {
                    MessageBox.Show("Modalidade já existente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Modalidade modalidade = new Modalidade(textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                    if (modalidade.cadastrarModalidade())
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro no cadastro!");
                    }
                }
            }

        }
    }
}
