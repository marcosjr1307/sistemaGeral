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
    public partial class ExcluirClasse : Form
    {
        bool change = true;
        public ExcluirClasse()
        {
            InitializeComponent();
            addRegistros();
        }

        public void addRegistros()
        {
            Classe c = new Classe();
            List<int> codTurma = new List<int>();
            MySqlDataReader le = c.consultarClasse02();
            while (le.Read()) {
                tblTurma.Rows.Add(le["idTurma"].ToString());
                codTurma.Add(int.Parse(le["idTurma"].ToString()));
            }
            DAO_Conexao.con.Close();
            Turma t = new Turma();
            for(int i = 0; i < codTurma.Count; i++)
            {
                le = t.consultarTurma(codTurma[i]);
                if (le.Read())
                {
                    tblTurma.Rows[i].Cells[1].Value = le["professorTurma"].ToString();
                }
                DAO_Conexao.con.Close();
                
            }

        }

        private void tblTurma_SelectionChanged(object sender, EventArgs e)
        {
            if (change)
            {
                int codTurma;
                tblAlunoClasse.Rows.Clear();
                codTurma = int.Parse(tblTurma.SelectedRows[0].Cells[0].Value.ToString());
                Classe c = new Classe(codTurma);
                MySqlDataReader result = c.consultaClasse01();
                while (result.Read())
                {
                    tblAlunoClasse.Rows.Add(result["cpfAluno"].ToString());
                }
                DAO_Conexao.con.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tblAlunoClasse.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um aluno para excluí-lo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int idTurma;
                string cpfAluno;
                idTurma = int.Parse(tblTurma.SelectedRows[0].Cells[0].Value.ToString());
                cpfAluno = tblAlunoClasse.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show("Você realmente deseja excluir o registro a seguir\nCPF " +
                    "Aluno: "+cpfAluno+"\nCódigo Turma: "+idTurma,"Atenção",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Classe c = new Classe(idTurma, cpfAluno);
                    MySqlDataReader result = c.consultarClasse03();
                    int codMatricula = 0;
                    while (result.Read())
                    {
                        codMatricula = int.Parse(result["codMatricula"].ToString());
                    }
                    Console.WriteLine("CODIGO MATRICULA: " + codMatricula);
                    DAO_Conexao.con.Close();
                    if (c.deleteMatricula(codMatricula))
                    {
                        change = false;
                        MessageBox.Show("Excluído com sucesso!", "Sucesso!", MessageBoxButtons.OK);
                        tblAlunoClasse.Rows.Clear();
                        tblTurma.Rows.Clear();
                        addRegistros();
                        change = true;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
