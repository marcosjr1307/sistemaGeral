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
    public partial class CadastrarTurma : Form
    {
        public CadastrarTurma()
        {
            InitializeComponent();

            Modalidade con_mod = new Modalidade();
            MySqlDataReader r = con_mod.consultarTodasModalidades();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int cod_modal=0;
            Modalidade con_mod = new Modalidade(txtModal.Text);
            MySqlDataReader r = con_mod.consultarModalidade();
            while (r.Read())
            {
                cod_modal = int.Parse(r["idEstudio_Modalidade"].ToString());
            }
            DAO_Conexao.con.Close();
            Turma turma = new Turma(txtProf.Text, txtDSemana.Text, txtHora.Text, cod_modal, int.Parse(txtQtdMaxAlunos.Text)); 

            if (turma.cadastrarTurma())
            {
                txtProf.Text = "";
                txtDSemana.Text = "";
                txtHora.Text = "";
                txtQtdMaxAlunos.Text = "";
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Erro de cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtModal.Text =  dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            /*
            Modalidade m = new Modalidade(dataGridView1.SelectedRows.ToString());
            MySqlDataReader r;
            r = m.consultarModalidade();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            }*/
        }

    }
}
