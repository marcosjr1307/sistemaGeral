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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            txtNome.Enabled = false;
            txtRua.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtComplemento.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            btnCadastro.Enabled = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtCpf.Text == "") || (txtNome.Text == "") || (txtRua.Text == "") || (txtNumero.Text == "") || (txtBairro.Text == "")
                || (txtComplemento.Text == "") || (txtCep.Text == "") || (txtCidade.Text == "") || (txtEstado.Text == "")
                || (txtTelefone.Text == "") || (txtEmail.Text == ""))
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text, txtRua.Text, txtNumero.Text, txtBairro.Text,
                    txtComplemento.Text, txtCep.Text.Replace(",", "."), txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text);

                if (aluno.cadastrarAluno())
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCpf.Text = "";
                    txtNome.Text = "";
                    txtRua.Text = "";
                    txtNumero.Text = "";
                    txtBairro.Text = "";
                    txtComplemento.Text = "";
                    txtCep.Text = "";
                    txtCidade.Text = "";
                    txtEstado.Text = "";
                    txtTelefone.Text = "";
                    txtEmail.Text = "";
                    btnCadastro.Enabled = false;
                    txtNome.Enabled = false;
                    txtRua.Enabled = false;
                    txtNumero.Enabled = false;
                    txtBairro.Enabled = false;
                    txtComplemento.Enabled = false;
                    txtCep.Enabled = false;
                    txtCidade.Enabled = false;
                    txtEstado.Enabled = false;
                    txtTelefone.Enabled = false;
                    txtEmail.Enabled = false;
                    txtCpf.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Erro no cadastro!");
                }
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                Aluno aluno = new Aluno(txtCpf.Text);
                if (aluno.consultarAluno())
                {
                    MessageBox.Show("Aluno já cadastrado!");
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                    txtCpf.Enabled = false;
                    txtNome.Enabled = true;
                    txtRua.Enabled = true;
                    txtNumero.Enabled = true;
                    txtBairro.Enabled = true;
                    txtComplemento.Enabled = true;
                    txtCep.Enabled = true;
                    txtCidade.Enabled = true;
                    txtEstado.Enabled = true;
                    txtTelefone.Enabled = true;
                    txtEmail.Enabled = true;
                    btnCadastro.Enabled = true;
                    txtNome.Focus();
                }
                DAO_Conexao.con.Close();
            }
        }

      
    }
}
