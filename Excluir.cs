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
    public partial class Excluir : Form
    {
        public Excluir()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Aluno aluno = new Aluno(maskedTextBox1.Text.Replace(",", "."));
                MySqlDataReader le = aluno.consultarAluno03();
                bool excluido=false;
                while (le.Read())
                {
                    if(int.Parse(le["ativo"].ToString()) == 1)
                    {
                        excluido = true;
                    }
                }
                DAO_Conexao.con.Close();
                if (aluno.consultarAluno())
                {
                    if (excluido == false)
                    {
                        if (aluno.excluirAluno())
                        {
                            MessageBox.Show("Aluno foi excluído", "Sucesso!", MessageBoxButtons.OK);
                            maskedTextBox1.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("O aluno já está excluído!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Excluir_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
