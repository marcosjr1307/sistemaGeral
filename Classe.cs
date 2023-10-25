using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aula13_banco
{
    class Classe
    {
        private int idTurma;
        private int cpfAluno;

        public Classe(int idTurma, int cpfAluno)
        {
            this.idTurma = idTurma;
            this.cpfAluno = cpfAluno;
        }

        public Classe(int idTurma)
        {
            this.idTurma = idTurma;
        }

        public int IdTurma { get => idTurma; set => idTurma = value; }
        public int CpfAluno { get => cpfAluno; set => cpfAluno = value; }

        public int verificaQtdAluno()
        {
            MySqlDataReader resultado = null;
            int qtd=0;
            try
            {
                MySqlCommand consulta = new MySqlCommand("select count(cpfAluno) from Estudio_classe where idTurma="+idTurma, DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                while (resultado.Read())
                {
                    qtd = int.Parse(resultado["count(cpfAluno)"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return qtd;
        }

    }
}
