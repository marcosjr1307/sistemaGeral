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
    public partial class ConsultarModalidade : Form
    {
        int opM = -1;
        public ConsultarModalidade(int op)
        {
            InitializeComponent();
            opM = op;
            if (op == 1)
            {
                this.Text = "Atualizar/Consultar Modalidade";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                txtPreco.ReadOnly = true;
                txtAluno.ReadOnly = true;
                txtAula.ReadOnly = true;
                checkBox1.Enabled = false;
            }
            if (op == 2)
            {
                this.Text = "Consultar Modalidade";
                button1.Visible = false;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                txtPreco.ReadOnly = true;
                txtAluno.ReadOnly = true;
                txtAula.ReadOnly = true;
                checkBox1.Enabled = false;
            }
            comboBox1.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarTodasModalidades();
            while (le.Read())
            {
                comboBox1.Items.Add(le["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((comboBox1.Text!="") && (txtPreco.Text !="") && (txtAluno.Text!="") && (txtAula.Text!=""))
            {
                if(opM == 1)
                {
                    button2.Enabled = true;
                }
                int ativo=0;
                if (checkBox1.Checked == false)
                {
                    ativo = 0;
                }
                else
                {
                    ativo = 1;
                }
                Modalidade m = new Modalidade(comboBox1.Text, float.Parse(txtPreco.Text), int.Parse(txtAluno.Text), int.Parse(txtAula.Text),ativo);
                if (m.atualizarModalidade(int.Parse(cod)))
                {
                    MessageBox.Show("Atualizado!","Sucesso",MessageBoxButtons.OK);
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtPreco.ReadOnly = true;
                    txtAluno.ReadOnly = true;
                    txtAula.ReadOnly = true;
                    checkBox1.Enabled = false;
                    checkBox1.Checked = false;
                    txtPreco.Text = "";
                    txtAluno.Text = "";
                    txtAula.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    Modalidade m2 = new Modalidade();
                    MySqlDataReader le2 = m2.consultarTodasModalidades();
                    while (le2.Read())
                    {
                            comboBox1.Items.Add(le2["descricaoModalidade"].ToString());
                    }
                    DAO_Conexao.con.Close();
                }
            }
            else
            {
                MessageBox.Show("Insira/Consulte os dados!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        string cod;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma modalidade!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Modalidade m = new Modalidade(comboBox1.Text);
                MySqlDataReader le = m.consultarModalidade();
                if (le.Read())
                {
                    cod = le["idEstudio_Modalidade"].ToString();
                    txtPreco.Text = le["precoModalidade"].ToString();
                    txtAluno.Text = le["qtdeAluno"].ToString();
                    txtAula.Text = le["qtdeAulas"].ToString();
                    if (int.Parse(le["ativa"].ToString()) == 1)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    if (opM == 2)
                    {
                    }
                    else
                    {
                        if (MessageBox.Show("Você deseja atualizar os dados da modalidade?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && opM == 1)
                        {
                            if (opM == 1)
                            {
                                comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
                                txtPreco.ReadOnly = false;
                                txtAluno.ReadOnly = false;
                                txtAula.ReadOnly = false;
                                checkBox1.Enabled = true;
                                button2.Enabled = false;
                                button1.Enabled = true;
                            }
                        }
                        else
                        {
                            if (opM == 1)
                            {
                                button2.Enabled = false;
                                button1.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Id não encontrado","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DAO_Conexao.con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            checkBox1.Checked = false;
            txtPreco.Text = "";
            txtAluno.Text = "";
            txtAula.Text = "";
            comboBox1.Text = "";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPreco.ReadOnly = true;
            txtAluno.ReadOnly = true;
            txtAula.ReadOnly = true;
            checkBox1.Enabled = false;
        }

        private void ConsultarModalidade_Load(object sender, EventArgs e)
        {

        }
    }
}
