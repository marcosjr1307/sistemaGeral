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
    public partial class AtualizarTurma : Form
    {
        public AtualizarTurma()
        {
            InitializeComponent();
            txtModal.DropDownStyle = ComboBoxStyle.DropDown
                ;
            txtModal.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarModalidadesTurma();

            while (le.Read())
            {
                txtModal.Items.Add(le["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        List<int> vetCods = new List<int>();
        private void txtModal_SelectedIndexChanged(object sender, EventArgs e)
        {
            vetCods.Clear();
            dataGridView1.Rows.Clear();
            Turma t = new Turma();
            MySqlDataReader le = t.consultarTurma05(txtModal.Text);
            int i = -1;
            int j = -1;
            while (le.Read())
            {
                vetCods.Add(int.Parse(le["idEstudio_Turma"].ToString()));
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if ((txtModal.Text != "") && (dataGridView1.Rows.Count!=0))
            {
                int linhas = dataGridView1.Rows.Count;
                int j = -1;
                for (int i = 0; i < linhas; i++)
                {
                    j = -1;
                    j++;
                    string prof = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    j++;
                    string sem = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    j++;
                    string hora = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    j++;
                    string qtdAluno = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    j++;
                    int ativo;
                    bool chk=false;
                    chk = (Boolean)dataGridView1.Rows[i].Cells[j].Value;
                    if (chk==true)
                    {
                        ativo = 1;
                    }
                    else
                    {
                        ativo = 0;
                    }
                    Turma t2 = new Turma(prof, sem, hora, qtdAluno, ativo);
                    t2.atualizarTurma(vetCods[i]);
                }
                dataGridView1.Rows.Clear();
                MessageBox.Show("Atualizado!","Confirmado",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Selecione uma modalidade", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
