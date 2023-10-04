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
    public partial class CadastrarTurma : Form
    {
        public CadastrarTurma()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            Turma turma = new Turma(txtProf.Text, txtDSemana.Text, txtHora.Text, int.Parse(txtModal.Text));

            if (turma.cadastrarTurma())
            {
                txtProf.Text = "";
                txtDSemana.Text = "";
                txtHora.Text = "";
                txtModal.Text = "";

                MessageBox.Show("Cadastro realizado com sucesso!");
            }

            else
                MessageBox.Show("Erro de cadastro!"); 
            

        }
    }
}
