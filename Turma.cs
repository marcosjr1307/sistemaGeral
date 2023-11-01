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
        private string professor, dia_semana, hora, desc;
        private int modalidade,qtdMaxAluno,ativo;


        //get and set
        public int getAtivo()
        {
            return ativo;
        }

        public void setAtivo(int ativo)
        {
            this.ativo = ativo;
        }

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

        public Turma(string professor, string dia_semana, string hora, string qtdMaxAluno, int ativo)
        {
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
            this.qtdMaxAluno = int.Parse(qtdMaxAluno);
            this.ativo = ativo;
        }

        public Turma(string professor, string dia_semana, string hora, string desc, int modalidade, int qtdMaxAluno)
        {
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
            this.desc = desc;
            this.modalidade = modalidade;
            this.qtdMaxAluno = qtdMaxAluno;
        }

        public bool cadastrarTurma()
        {
            bool ready = false; 
            try 
            {
                DAO_Conexao.con.Open();
                MySqlCommand add = new MySqlCommand("insert into Estudio_turma (idModalidade,professorTurma, diasemanaTurma, horaTurma, nalunosmatriculadosTurma) " +
                    "values (" + modalidade + ",'" + professor + "','" + dia_semana + "','" + hora + "'," + qtdMaxAluno+")", DAO_Conexao.con);
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

        public MySqlDataReader consultarTodasTurmas()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_turma", DAO_Conexao.con);
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
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma,ativo from Estudio_turma inner join " +
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
                MySqlCommand consulta = new MySqlCommand("select horaTurma,ativo from Estudio_turma inner join Estudio_modalidade " +
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

        public MySqlDataReader consultarTurma03(string nomeM, string sem, string horaT) //Pega o ID a partir do nome, dia semana e hora
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

        public MySqlDataReader consultarTurma05(string descM) //Seleciona as turmas daquela modalidade
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_turma inner " +
                    "join Estudio_modalidade on (Estudio_modalidade.idEstudio_Modalidade " +
                    "= Estudio_turma.idModalidade) where " +
                    "Estudio_modalidade.descricaoModalidade='" + descM+"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma06(string nomeProf, string sem, string horaT) //Pega o ID da turma a partir do nome do professor, dia da semana e hora
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Turma from Estudio_turma where professorTurma ='" + nomeProf+"' and diasemanaTurma = '"+sem+"' and horaTurma = '"+horaT+"'", DAO_Conexao.con);
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

        public int consultarTurma07(string nome)
        {
            int codTurma=0;
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                Console.WriteLine("NOME NA QUERRY: |" + nome + "|");
                MySqlCommand consulta = new MySqlCommand("select idEstudio_turma from Estudio_turma where professorTurma='" + nome + "'",DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                while (resultado.Read())
                {
                    codTurma = int.Parse(resultado["idEstudio_turma"].ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return codTurma;
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

        public bool atualizarTurma(int id) //Código da turma
        {
            bool ready = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualizar = new MySqlCommand("update Estudio_turma set " +
                    "professorTurma='" + professor + "', diasemana" +
                    "Turma='"+dia_semana+"', horaTurma='"+hora+"', nalunosmatriculados" +
                    "Turma="+qtdMaxAluno+", ativo="+ativo+" where idEstudio_Turma="+id, DAO_Conexao.con);
                atualizar.ExecuteNonQuery();
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
    }
}
