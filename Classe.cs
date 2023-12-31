﻿using MySql.Data.MySqlClient;
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
        private string cpfAluno;

        public Classe(int idTurma, string cpfAluno)
        {
            this.idTurma = idTurma;
            this.cpfAluno = cpfAluno;
        }

        public Classe()
        {
        }

        public Classe(int idTurma)
        {
            this.idTurma = idTurma;
        }

        public int IdTurma { get => idTurma; set => idTurma = value; }
        public string CpfAluno { get => cpfAluno; set => cpfAluno = value; }

        public int verificaQtdAluno()
        {
            MySqlDataReader resultado;
            int qtd=0;
            try
            {
                DAO_Conexao.con.Open();
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
            finally
            {
                DAO_Conexao.con.Close();
            }
            return qtd;
        }

        public bool verificaSeExiste()
        {
            MySqlDataReader resultado;
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_classe where idTurma="+idTurma+ " and cpfAluno='"+cpfAluno+"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if(resultado.HasRows)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return existe;
        }

        public int verificaQtdRegistros()
        {
            MySqlDataReader resultado = null;
            int qtd = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select count(*) from Estudio_classe",DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                while (resultado.Read())
                {
                    qtd = int.Parse(resultado["count(*)"].ToString());
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
            return qtd;
        }

        public bool cadastraClasse()
        {
            bool ready = false;
            try{
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Insert into Estudio_classe (idTurma,cpfAluno) values (" + idTurma + ",'" + cpfAluno + "')", DAO_Conexao.con);
                consulta.ExecuteNonQuery();
                ready = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return ready;
        }

        public MySqlDataReader consultarClasse() //Consulta todos
        {
            MySqlDataReader resultado=null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select*from Estudio_classe",DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultaClasse01() //Consulta os alunos(cpf) a partir do código da turma
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select cpfAluno from Estudio_classe where idTurma =" + idTurma,DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }

        public MySqlDataReader consultarClasse02() //seleciona as salas sem repetir
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select distinct idTurma from Estudio_classe", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarClasse03() //Consulta cod de matricula a partir do cod da sala e do cpf do aluno
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select codMatricula from Estudio_classe where idTurma="+idTurma+" and cpfAluno='"+cpfAluno+"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool deleteMatricula(int codMatricula)
        {
            bool excluido = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand query = new MySqlCommand("delete from Estudio_classe where codMatricula=" + codMatricula, DAO_Conexao.con);
                query.ExecuteNonQuery();
                excluido = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return excluido;
        }
    }
}
