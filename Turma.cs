using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace aula13_banco
{
    class Turma
    {
        private string professor, dia_semana, hora;
        private int modalidade;


        //get and set
        public string getProfessor()
        {
            return professor;
        }

        public void setProfessor(string professor)
        {
            this.professor = professor;
        }

        public string getDia_semana()
        {
            return dia_semana;
        }

        public void setDia_semana(string dia_semana)
        {
            this.dia_semana = dia_semana;
        }

        public string getHora()
        {
            return hora;
        }

        public void setHora(string hora)
        {
            this.hora = hora;
        }

        public int getModalidade()
        {
            return modalidade;
        }

        public void setModalidade(int modalidade)
        {
            this.modalidade = modalidade;
        }
        //fim get and set


        //construtor
        public Turma(string professor, string dia_semana, string hora, int modalidade)
        {
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
            this.modalidade = modalidade;
        }

        public Turma(int modalidade)
        {          
            this.modalidade = modalidade;
        }

        public Turma( string dia_semana, int modalidade)
        {
            this.dia_semana = dia_semana;          
            this.modalidade = modalidade;
        }

        public bool cadastrarTurma()
        {
            bool ready = false; 
            try 
            {
                DAO_Conexao.con.Open();
                MySqlCommand add = MySqlCommand("insert into Estudio_turma (professorTurma, diasemanaTurma, horaTurmar, idModalidade) values ('""') ");
               

            }


            return 
        }
       // public bool excluirTurma() 
      // public MySqlDataReader consultarTurma()

       //public MySqlDataReader consultarTurma01()
    }
}
