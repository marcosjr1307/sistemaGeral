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

        private void txtModal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma05(txtModal.Text);
            int i=-1;
            int j=-1;
            while (le.Read())
            {
                dataGridView1.Rows.Add();
                j = -1;
                i++;
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["professorTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["diasemanaTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["horaTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["nalunosmatriculadosTurma"].ToString();
                j++;
                if (int.Parse(le["ativo"].ToString()) == 1)
                { 
                    dataGridView1.Rows[i].Cells[j].Value = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[j].Value = false;
                }
            }
            DAO_Conexao.con.Close();

        }
    }
}
