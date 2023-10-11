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

            txtModal.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarTodasModalidades();
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
            txtSemana.Items.Clear();
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
    }
}
