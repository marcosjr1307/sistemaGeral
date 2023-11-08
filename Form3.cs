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
            btnFoto.Enabled = false;
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
                || (txtTelefone.Text == "") || (txtEmail.Text == "") || (pictureBox1.Image == null))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                byte[] foto = ConverterFotoParaByteArray();
                Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text, txtRua.Text, txtNumero.Text, txtBairro.Text,
                    txtComplemento.Text, txtCep.Text.Replace(",", "."), txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text,foto);//+foto

                if (aluno.cadastrarAluno())
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso!", MessageBoxButtons.OK);
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
                    pictureBox1.Image = null;
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
                    btnFoto.Enabled = false;
                    txtCpf.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Erro no cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."));
                if (aluno.verificaCPF() == false)
                {
                    MessageBox.Show("CPF inválido","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    Aluno aluno2 = new Aluno(txtCpf.Text);
                    if (aluno2.consultarAluno())
                    {
                        MessageBox.Show("Aluno já cadastrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
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
                        btnCadastro.Enabled = true;
                        btnFoto.Enabled = true;
                        txtNome.Focus();
                    }
                }
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Abrir Foto";
            dialog.Filter = "JPG (*.jpg)|*.jpg" + "|All files (*.*)|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(dialog.OpenFile());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Não foi possível carregar a foto: " + ex.Message);
                }
            }
            dialog.Dispose();
        }

        public byte[] ConverterFotoParaByteArray()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                return bArray;
            }
        }
    }
}
