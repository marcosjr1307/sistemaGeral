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
    public partial class ConsultarClasse : Form
    {
        public ConsultarClasse()
        {
            InitializeComponent();
            addRegistros();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTodasTurmas();
            while (le.Read())
            {
                comboBox1.Items.Add(le["nome"].ToString());
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DAO_Conexao.con.Close();
            comboBox1.Items.Add("SEM FILTRO");
        }

        private void ConsultarClasse_Load(object sender, EventArgs e)
        {

        }


        public void addRegistros()
        {
            int qtdRegistros = -1;
            Classe c = new Classe();
            qtdRegistros = c.verificaQtdRegistros();
            List<int> vetIdTurma = new List<int>();
            List<string> nomeProf = new List<string>();
            List<string> cpfAluno = new List<string>();
            MySqlDataReader le = c.consultarClasse();
            while (le.Read())
            {
                vetIdTurma.Add(int.Parse(le["idTurma"].ToString()));
                cpfAluno.Add(le["cpfAluno"].ToString());
            }
            DAO_Conexao.con.Close();
            Turma t = new Turma();
            for (int i = 0; i < qtdRegistros; i++)
            {
                le = t.consultarTurma(vetIdTurma[i]);
                while (le.Read())
                {
                    nomeProf.Add(le["professorTurma"].ToString());
                }
                DAO_Conexao.con.Close();
            }

            int j;
            for (int i = 0; i < qtdRegistros; i++)
            {
                tblClasse.Rows.Add();
                j = 0;
                tblClasse.Rows[i].Cells[j].Value = vetIdTurma[i];
                j++;
                tblClasse.Rows[i].Cells[j].Value = nomeProf[i];
                j++;
                tblClasse.Rows[i].Cells[j].Value = cpfAluno[i];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("SEM FILTRO"))
            {
                tblClasse.Rows.Clear();
                addRegistros();
                txtHora.Clear();
                txtQtd.Clear();
                txtSemana.Clear();
            }
            else
            {
                tblClasse.Rows.Clear();
                string nomeTurma = comboBox1.Text;
                Turma t = new Turma();
                MySqlDataReader result = t.consultarTurma07(nomeTurma);
                int idTurma=0;
                while (result.Read())
                {
                    txtSemana.Text = result["diasemanaTurma"].ToString();
                    txtHora.Text = result["horaTurma"].ToString();
                    idTurma = int.Parse(result["idEstudio_Turma"].ToString());
                }
                DAO_Conexao.con.Close();
                Classe c = new Classe(idTurma);
                MySqlDataReader le = c.consultaClasse01();
                int i = 0;
                while (le.Read())
                {
                    tblClasse.Rows.Add();
                    tblClasse.Rows[i].Cells[0].Value = idTurma;
                    tblClasse.Rows[i].Cells[1].Value = nomeTurma;
                    tblClasse.Rows[i].Cells[2].Value = le["cpfAluno"].ToString();
                    i++;
                }
                DAO_Conexao.con.Close();
                txtQtd.Text = tblClasse.Rows.Count.ToString();
            }


        }
    }
}
