﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Enabled = false;
        }
        int op = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DAO_Conexao.getConexao("143.106.241.3", "cl202157", "cl202157", "Jclm19ec@"))
                Console.WriteLine("Conectado");
            else 
                Console.WriteLine("Erro de conexão");
        }


        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAO_Conexao.VerificaLogin(textBox1.Text, textBox2.Text);
            if (tipo == 0)
                MessageBox.Show("Usuário/Senha inválidos", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (tipo == 1)
            {
                label3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                this.Text = "Estúdio - ADM";
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                atualizarOuConsultarModalidadeToolStripMenuItem.Text = "Atualizar/Consultar Modalidade";
                op = tipo;
            }
            if (tipo == 2) {
                label3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                this.Text = "Estúdio - RESTRITO";
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarAlunoToolStripMenuItem.Enabled = false;
                excluirModalidadeToolStripMenuItem.Enabled = false;
                cadastrarModalidadeToolStripMenuItem.Enabled = false;
                atualizarOuConsultarModalidadeToolStripMenuItem.Text = "Consultar Modalidade";
                cadastrarTurmaToolStripMenuItem.Enabled = false;
                excluirTurmaToolStripMenuItem.Enabled = false;
                atualizarTurmaToolStripMenuItem.Enabled = false;
                op = tipo;
            }
        }

        private void excluirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excluir excluir = new Excluir();
            excluir.MdiParent = this;
            excluir.Show();
        }

        private void atualizarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Atualizar atualizar = new Atualizar();
            atualizar.MdiParent = this;
            atualizar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cadastrarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarModalidade cadastrar = new CadastrarModalidade();
            cadastrar.MdiParent = this;
            cadastrar.Show();
        }

        private void excluirModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirModalidade excluir = new ExcluirModalidade();
            excluir.MdiParent = this;
            excluir.Show();
        }

        private void atualizarOuConsultarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarModalidade consultar = new ConsultarModalidade(op);
            consultar.MdiParent = this;
            consultar.Show();
        }

        private void cadastrarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarTurma cadastar = new CadastrarTurma();
            cadastar.MdiParent = this;
            cadastar.Show();
        }


        private void excluirTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirTurma excluir = new ExcluirTurma();
            excluir.MdiParent = this;
            excluir.Show();
        }

        private void ConsultarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarTurma consultar = new ConsultarTurma();
            consultar.MdiParent = this;
            consultar.Show();
        }

        private void atualizarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarTurma atualizar = new AtualizarTurma();
            atualizar.MdiParent = this;
            atualizar.Show();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "marcos";
            textBox2.Text = "marcos";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "restrito";
            textBox2.Text = "restrito";
        }

        private void modalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matricula matricular = new Matricula();
            matricular.MdiParent = this;
            matricular.Show();
        }

        private void consultarClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarClasse consulta = new ConsultarClasse();
            consulta.MdiParent = this;
            consulta.Show();
        }
    }
}
