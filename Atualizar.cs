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
    public partial class Atualizar : Form
    {
        public Atualizar()
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
            btnAtualizar.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text, txtRua.Text, txtNumero.Text, txtBairro.Text,
                txtComplemento.Text, txtCep.Text.Replace(",", "."), txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text);

            if (aluno.atualizarAluno())
            {
                MessageBox.Show("Aluno atualizado!");
                txtCpf.Text = "";
                txtNome.Text= "";
                txtRua.Text= "";
                txtNumero.Text= "";
                txtBairro.Text= "";
                txtComplemento.Text= "";
                txtCep.Text= "";
                txtCidade.Text= "";
                txtEstado.Text= "";
                txtTelefone.Text= "";
                txtEmail.Text= "";
                txtCpf.Enabled = true;
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
                btnAtualizar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Erro na atualizção!");
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."));

            if (e.KeyChar == 13)
            {
                MySqlDataReader r = aluno.consultarAluno2();
                if (r.Read())
                {
                    MessageBox.Show("Aluno encontrado!");
                    txtNome.Text = r["nomeAluno"].ToString();
                    txtComplemento.Text = r["complementoAluno"].ToString();
                    txtBairro.Text = r["bairroAluno"].ToString();
                    txtEmail.Text = r["emailAluno"].ToString();
                    txtCidade.Text = r["cidadeAluno"].ToString();
                    txtCep.Text = r["CEPAluno"].ToString();
                    txtEstado.Text = r["estadoAluno"].ToString();
                    txtNumero.Text = r["numeroAluno"].ToString();
                    txtTelefone.Text = r["telefoneAluno"].ToString();
                    txtRua.Text = r["ruaAluno"].ToString();
                    if (MessageBox.Show("Você deseja atualizar os dados do aluno?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
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
                        btnAtualizar.Enabled = true;
                        txtNome.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado!");
                }
                DAO_Conexao.con.Close();
            }
             
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
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
        }
    }
}
