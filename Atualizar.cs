using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            checkBox1.Enabled = false;
            btnFoto.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int ativo = -1;
            if (checkBox1.Checked == false)
            {
                ativo = 0;
            }
            else
            {
                ativo = 1;
            }
            byte[] foto = ConverterFotoParaByteArray();

            Aluno aluno = new Aluno(txtCpf.Text.Replace(",", "."), txtNome.Text, txtRua.Text, txtNumero.Text, txtBairro.Text,
                txtComplemento.Text, txtCep.Text.Replace(",", "."), txtCidade.Text, txtEstado.Text, txtTelefone.Text, txtEmail.Text, ativo, foto);

            if (aluno.atualizarAluno())
            {
                MessageBox.Show("Aluno atualizado!", "Sucesso", MessageBoxButtons.OK);
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
                checkBox1.Enabled = false;
                btnFoto.Enabled = false;
            }
            else
            {
                MessageBox.Show("Erro na atualizção!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        string imagem = Convert.ToString(DateTime.Now.ToFileTime());
                        byte[] bimage = (byte[])r["fotoAluno"];
                        FileStream fs = new FileStream(imagem, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(bimage, 0, bimage.Length - 1);
                        fs.Close();
                        pictureBox1.Image = Image.FromFile(imagem);
                    }
                    catch
                    {
                        pictureBox1.Image = Image.FromFile("negado.png");
                        MessageBox.Show("Erro ao carregar a foto");
                    }
                    MessageBox.Show("Aluno encontrado!", "Sucesso", MessageBoxButtons.OK);
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
                    if (int.Parse(r["ativo"].ToString()) == 1)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
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
                        checkBox1.Enabled = true;
                        btnFoto.Enabled = true;
                        txtNome.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pictureBox1.Image = null;
            checkBox1.Checked = false;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Abrir Foto";
            dialog.Filter = "JPG (*.jpg)|*.jpg" + "|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(dialog.OpenFile());
                }
                catch (Exception ex)
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
