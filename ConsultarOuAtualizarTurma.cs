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
    public partial class ConsultarOuAtualizarTurma : Form
    {
        public ConsultarOuAtualizarTurma(int op)
        {
            InitializeComponent();
            if (op == 1)
            {
                this.Text = "Atualizar/Consultar Turma";
            }
            if (op == 2)
            {
                this.Text = "Consultar Turma";
            }
        }

        private void ConsultarOuAtualizarTurma_Load(object sender, EventArgs e)
        {

        }
    }
}
