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
        public ExcluirClasse()
        {
            InitializeComponent();
            addRegistros();
        }



        







        public void addRegistros()
        {
            Classe c = new Classe();
            List<int> codTurma = new List<int>();
            MySqlDataReader le = c.consultarClasse();
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
}
