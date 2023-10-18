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
        private int modalidade,qtdMaxAluno;


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

        public int getQtdMaxAluno()
        {
            return qtdMaxAluno;
        }

        public void setQtdMaxAluno(int qtdMaxAluno)
        {
            this.qtdMaxAluno = qtdMaxAluno;
        }
        //fim get and set


        //construtor
        public Turma(string professor, string dia_semana, string hora, int modalidade, int qtdMaxAluno)
        {
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
            this.modalidade = modalidade;
            this.qtdMaxAluno = qtdMaxAluno;
        }

        public Turma(int modalidade)
        {          
            this.modalidade = modalidade;
        }

        public Turma()
        { 
        }

        public Turma(string dia_semana, int modalidade)
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
                MySqlCommand add = new MySqlCommand("insert into Estudio_turma (idModalidade,professorTurma, diasemanaTurma, horaTurma, nalunosmatriculadosTurma) " +
                    "values (" + modalidade + ",'" + professor + "','" + dia_semana + "','" + hora + "'," + qtdMaxAluno + ")", DAO_Conexao.con);
                add.ExecuteNonQuery();
                ready = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally{
                DAO_Conexao.con.Close();
            }

            return ready;
        }

        public MySqlDataReader consultarTurma(int cod) //Consultar por código
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_turma where idEstudio_Turma=" + cod,DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma01(string nome) //Consulta a semana
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma from Estudio_turma inner join " +
                    "Estudio_modalidade on (Estudio_modalidade.idEstudio_Modalidade = Estudio_turma.idModalidade) " +
                    "where Estudio_modalidade.descricaoModalidade = '"+nome+"'",DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //DAO_Conexao.con.Close();
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma02(string nomeM, string sem) //Consulta a hora
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select horaTurma from Estudio_turma inner join Estudio_modalidade " +
                    "on(Estudio_modalidade.idEstudio_Modalidade=Estudio_turma.idModalidade) where " +
                    "Estudio_modalidade.descricaoModalidade='"+nomeM+"' and diasemanaTurma='"+sem+"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //DAO_Conexao.con.Close();
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma03(string nomeM, string sem, string horaT) //Pega o ID a partir do nome e hora
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Turma from Estudio_turma inner join Estudio_modalidade " +
                    "on(Estudio_modalidade.idEstudio_Modalidade=Estudio_turma.idModalidade) where " +
                    "Estudio_modalidade.descricaoModalidade='" + nomeM + "' and diasemanaTurma='" + sem + "' and horaTurma='"+horaT+"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //DAO_Conexao.con.Close();
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma04(int id) //Pega a quantidade de turmas daquela modalidade
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Turma from Estudio_turma inner join Estudio_modalidade " +
                    "on(Estudio_modalidade.idEstudio_Modalidade=Estudio_turma.idModalidade) " +
                    "where Estudio_modalidade.idEstudio_Modalidade="+id, DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }


        public bool excluirTurma(int id)
        {
            bool ready = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand excluir = new MySqlCommand("update Estudio_turma set ativo = 1 where idEstudio_Turma=" + id,DAO_Conexao.con);
                excluir.ExecuteNonQuery();
                ready = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return ready;
        }

        public bool excluirTurma01(int id) //Exluir a partir da modalidade
        {
            bool ready = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand excluir = new MySqlCommand("update Estudio_turma set ativo = 1 where idEstudio_Turma=" + id, DAO_Conexao.con);
                excluir.ExecuteNonQuery();
                ready = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return ready;
        }
    }
}
