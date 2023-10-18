﻿using MySql.Data.MySqlClient;
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
    public partial class ExcluirModalidade : Form
    {
        public ExcluirModalidade()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            Modalidade m = new Modalidade();
            MySqlDataReader le = m.consultarTodasModalidades();
            while (le.Read())
            {
                if(int.Parse(le["ativa"].ToString())!=1)
                {
                    comboBox1.Items.Add(le["descricaoModalidade"].ToString());
                }
            }
            DAO_Conexao.con.Close();
        }

        private void ExcluirModalidade_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int id=0;
            Modalidade m = new Modalidade(comboBox1.Text);
            MySqlDataReader le = m.consultarModalidade();
            if (le.Read())
            {
                id = int.Parse(le["idEstudio_Modalidade"].ToString());
            }
            else
            {
                MessageBox.Show("Id não encontrado");
            }
            DAO_Conexao.con.Close();
            if (comboBox1.Text != "")
            {
                if (m.excluirModalidade(id))
                {
                    Turma t = new Turma();
                    int codTurma = 0;
                    MySqlDataReader qtd = t.consultarTurma04(id);
                    List<int> vet = new List<int>();
                    while (qtd.Read())
                    {
                        vet.Add(int.Parse(qtd["idEstudio_Turma"].ToString()));
                    }
                    DAO_Conexao.con.Close();
                    for(int i=0; i < vet.Count(); i++)
                    {
                        t.excluirTurma01(vet[i]);
                    }
                    comboBox1.Text = "";
                    MessageBox.Show("Excluído com sucesso");
                    comboBox1.Items.Clear();
                    Modalidade m2 = new Modalidade();
                    MySqlDataReader le2 = m2.consultarTodasModalidades();
                    while (le2.Read())
                    {
                        if (int.Parse(le2["Ativa"].ToString()) != 1)
                        {
                            comboBox1.Items.Add(le2["descricaoModalidade"].ToString());
                        }
                    }
                    DAO_Conexao.con.Close();
                }
                else
                {
                    MessageBox.Show("Erro!!");
                }
            }
            
        }
    }
}
