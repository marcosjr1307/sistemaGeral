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
    public partial class ConsultarTurma : Form
    {
        public ConsultarTurma()
        {
            InitializeComponent();
            txtModal.DropDownStyle = ComboBoxStyle.DropDownList;
            txtModal.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarModalidadesTurma();

            while (le.Read())
            {
                txtModal.Items.Add(le["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void ConsultarOuAtualizarTurma_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtModal_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma01(txtModal.Text);
            while (le.Read())
            {
                listBox1.Items.Add(le["diasemanaTurma"].ToString());
            }
            DAO_Conexao.con.Close();

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma02(txtModal.Text, listBox1.SelectedItem.ToString());
            while (le.Read())
            {
                listBox2.Items.Add(le["horaTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void listBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
