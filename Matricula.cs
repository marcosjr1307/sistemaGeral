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
    public partial class Matricula : Form
    {
        public Matricula()
        {
            InitializeComponent();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTodasTurmas();
            int i = -1;
            int j = -1;
            int codModal;
            string nomeModal="";
            while (le.Read())
            {
                dataGridView1.Rows.Add();
                j = -1;
                i++;
                j++;
                codModal = int.Parse(le["idModalidade"].ToString());
                MessageBox.Show(le["idModalidade"].ToString());
                Modalidade m = new Modalidade();
                MySqlDataReader le2 = m.consultarNomeModalidade(codModal);
                while (le2.Read())
                {
                    nomeModal = le2["descricaoModalidade"].ToString();
                }
                dataGridView1.Rows[i].Cells[j].Value = nomeModal;
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["professorTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["diasemanaTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["horaTurma"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["nalunosmatriculadosTurma"].ToString();
                j++;
                Classe c = new Classe(int.Parse(le["idEstudio_Turma"].ToString()));
                dataGridView1.Rows[i].Cells[j].Value = c.verificaQtdAluno();
            }
            DAO_Conexao.con.Close();
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {

        }
    }
}
