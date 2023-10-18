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
    public partial class ExcluirTurma : Form
    {
        public ExcluirTurma()
        {
            InitializeComponent();

            txtModal.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            txtHora.DropDownStyle = ComboBoxStyle.DropDownList;
            txtModal.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarModalidadesTurma();
            while (le.Read())
            {
                txtModal.Items.Add(le["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void ExcluirTurma_Load(object sender, EventArgs e)
        {

        }

        private void txtModal_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSemana.Text = "";
            txtHora.Text = "";
            txtSemana.Items.Clear();
            txtHora.Items.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma01(txtModal.Text);
            while (le.Read())
            {
                txtSemana.Items.Add(le["diasemanaTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void txtSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHora.Text = "";
            txtHora.Items.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma02(txtModal.Text, txtSemana.Text);
            while (le.Read())
            {
                txtHora.Items.Add(le["horaTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((txtModal.Text=="") || (txtSemana.Text=="") || (txtHora.Text==""))
            {
                MessageBox.Show("Selecione todos os campos!");
            }
            else
            {
                int cod=0;
                Turma t = new Turma();
                MySqlDataReader le = t.consultarTurma03(txtModal.Text, txtSemana.Text, txtHora.Text);
                while (le.Read())
                {
                    cod = int.Parse(le["idEstudio_Turma"].ToString());
                }
                DAO_Conexao.con.Close();
                MySqlDataReader objeto = t.consultarTurma(cod);
                string obj = "";
                while (objeto.Read())
                {
                    obj = "Professor: " + objeto["professorTurma"].ToString() + "\nDia semana: " + objeto["diasemanaTurma"].ToString() + "" +
                        "\nHora: " + objeto["horaTurma"].ToString();
                }
                DAO_Conexao.con.Close();
                if(MessageBox.Show("Você tem certeza que deseja apagar a seguinte turma?\n"+obj,"Atenção",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (t.excluirTurma(cod))
                    {
                        MessageBox.Show("Turma excluída com sucesso!");
                        txtModal.Items.Clear();
                        txtSemana.Items.Clear();
                        txtHora.Items.Clear();
                        txtModal.Text = "";
                        txtSemana.Text = "";
                        txtHora.Text = "";
                        Modalidade m = new Modalidade();
                        MySqlDataReader le2 = m.consultarModalidadesTurma();
                        txtModal.Items.Clear();
                        while (le2.Read())
                        {
                            txtModal.Items.Add(le2["descricaoModalidade"].ToString());
                        }
                        DAO_Conexao.con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir aluno!");
                    }
                }
            }
        }
    }
}
