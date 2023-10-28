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
            loadDataGridView1();
            loadDataGridView2();
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count == 1) && (dataGridView2.SelectedRows.Count==1))
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                Color backgroundColor = selectedRow.DefaultCellStyle.BackColor;
                if(backgroundColor != Color.LightGray)
                {
                    addClasse();

                }
                else
                {
                    MessageBox.Show("Essa turma está lotada!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else{
                MessageBox.Show("Selecione uma turma e um aluno!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void changeColor(int k)
        {
            if (dataGridView2.Rows[k].DefaultCellStyle.BackColor == Color.LightGray)
            {
                dataGridView2.Rows[k].DefaultCellStyle.SelectionBackColor = Color.Gray;
            }
        }

        private void loadDataGridView2()
        {
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTodasTurmas();
            int i = -1;
            int j = -1;
            int codModal = 0;
            string nomeModal = "";
            List<int> codTurma = new List<int>();
            List<int> codModalidade = new List<int>();
            List<string> nomeModalidade = new List<string>();
            while (le.Read())
            {
                dataGridView2.Rows.Add();
                j = 0;
                i++;
                j++;
                codModalidade.Add(int.Parse(le["idModalidade"].ToString()));
                codModal = int.Parse(le["idModalidade"].ToString());
                dataGridView2.Rows[i].Cells[j].Value = le["professorTurma"].ToString();
                j++;
                dataGridView2.Rows[i].Cells[j].Value = le["diasemanaTurma"].ToString();
                j++;
                dataGridView2.Rows[i].Cells[j].Value = le["horaTurma"].ToString();
                j++;
                dataGridView2.Rows[i].Cells[j].Value = le["nalunosmatriculadosTurma"].ToString();
                codTurma.Add(int.Parse(le["idEstudio_Turma"].ToString()));
            }
            DAO_Conexao.con.Close();
            Modalidade m = new Modalidade();
            j = 0;
            int j2 = 5;
            for (int k = 0; k < int.Parse(codModalidade.Count.ToString()); k++)
            {
                le = m.consultarNomeModalidade(int.Parse(codModalidade[k].ToString()));
                while (le.Read())
                {
                    nomeModalidade.Add(le["descricaoModalidade"].ToString());
                }
                DAO_Conexao.con.Close();
                dataGridView2.Rows[k].Cells[j].Value = nomeModalidade[k];
                Classe classe = new Classe(codTurma[k]);
                dataGridView2.Rows[k].Cells[j2].Value = classe.verificaQtdAluno();
                if (int.Parse(dataGridView2.Rows[k].Cells[j2 - 1].Value.ToString()) == int.Parse(dataGridView2.Rows[k].Cells[j2].Value.ToString()))
                {
                    dataGridView2.Rows[k].ReadOnly = true;
                    dataGridView2.Rows[k].DefaultCellStyle.BackColor = Color.LightGray;
                    changeColor(k);
                }
            }
        }

        private void loadDataGridView1()
        {
            Aluno a = new Aluno();
            MySqlDataReader le = a.consultarTodosAlunos();
            int i = -1;
            int j = -1;
            while (le.Read())
            {
                dataGridView1.Rows.Add();
                j = -1;
                i++;
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["nomeAluno"].ToString();
                j++;
                dataGridView1.Rows[i].Cells[j].Value = le["CPFAluno"].ToString();
            }
            DAO_Conexao.con.Close();
        }

        private void addClasse()
        {
            Turma t = new Turma();
            string nomeProf = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            string diaSem = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            string hora = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            MySqlDataReader le = t.consultarTurma06(nomeProf, diaSem, hora);
            int codTurma = 0;
            while (le.Read())
            {
                codTurma = int.Parse(le["idEstudio_Turma"].ToString());
            }
            DAO_Conexao.con.Close();
            string cpfAluno = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Classe c = new Classe(codTurma, cpfAluno);
            if(c.verificaSeExiste()==false)
            {
                if (c.cadastraClasse())
                {
                    MessageBox.Show("Sucesso!", "Cadastrado", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Erro no cadastro!", "Impossível!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Esse aluno já está cadastrado nessa turma!","Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
