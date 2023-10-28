﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aula13_banco
{
    class Aluno
    {
        
        private string cpf;
        private string nome;
        private string endereco;
        private string numero;
        private string bairro;
        private string complemento;
        private string cep;
        private string cidade;
        private string estado;
        private string telefone;
        private string email;
        private byte[] foto;
        private int ativo;

        public Aluno(string cpf, string nome, string endereco, string numero, string bairro, string complemento, string cep, string cidade, 
            string estado, string telefone, string email, byte[] foto)
        {
            setCpf(cpf);
            setNome(nome);
            setEndereco(endereco);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCep(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
            setFoto(foto);
        }

        public Aluno(string cpf, string nome, string endereco, string numero, string bairro, string complemento, string cep, string cidade,
           string estado, string telefone, string email, int ativo)
        {
            setCpf(cpf);
            setNome(nome);
            setEndereco(endereco);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCep(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
            setAtivo(ativo);
        }

        public Aluno(string cpf, string nome, string endereco, string numero, string bairro, string complemento, string cep, string cidade,
          string estado, string telefone, string email)
        {
            setCpf(cpf);
            setNome(nome);
            setEndereco(endereco);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCep(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
        }

        public Aluno()
        {
        }



        public Aluno(string cpf)
        {
            setCpf(cpf);
        }

        public bool atualizarAluno()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("update Estudio_aluno set nomeAluno='" + nome + "', ruaAluno='" + endereco + "', numeroAluno='" + numero + "', " +
                    "bairroAluno='" + bairro + "', complementoAluno='" + complemento + "', CEPAluno='" + cep + "', cidadeAluno='" + cidade + "', estadoAluno='" + estado + "'," +
                    " telefoneAluno='" + telefone + "', emailAluno='" + email + "', ativo = "+ativo+" where CPFAluno='" + cpf + "'", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        public MySqlDataReader consultarAluno03()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select ativo from Estudio_aluno where CPFAluno='" + cpf.Replace(",", ".") + "'", DAO_Conexao.con);
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


        public MySqlDataReader consultarAluno2() {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_aluno where CPFAluno='" + cpf.Replace(",",".") + "'", DAO_Conexao.con);
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

        public bool consultarAluno() {
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_aluno where CPFAluno='" + cpf.Replace(",",".") + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read()) {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return existe;
        }

        public bool verificaCPF() //string CPF - sem parâmetro
        {
            int soma, resto, cont = 0;
            soma = 0;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            for (int i = 0; i < cpf.Length; i++)
            {
                int a = cpf[0] - '0';
                int b = cpf[i] - '0';

                if (a == b) cont++;
            }

            if (cont == 11) return false;

            for (int i = 1; i <= 9; i++) soma += int.Parse(cpf.Substring(i - 1, 1)) * (11 - i);

            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11)) resto = 0;

            if (resto != int.Parse(cpf.Substring(9, 1))) return false;

            soma = 0;

            for (int i = 1; i <= 10; i++) soma += int.Parse(cpf.Substring(i - 1, 1)) * (12 - i);

            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11)) resto = 0;

            if (resto != int.Parse(cpf.Substring(10, 1))) return false;

            return true;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public string getCpf()
        {
            return this.cpf;
        }


        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return this.nome;
        }
        
        public void setEndereco(string endereco)
        {
            this.endereco = endereco;
        }

        public string getEndereco()
        {
            return this.endereco;
        }

        public void setNumero(string numero)
        {
            this.numero = numero;
        }

        public string getNumero()
        {
            return this.numero;
        }

        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }

        public string getBairro()
        {
            return this.bairro;
        }

        public void setComplemento(string complemento)
        {
            this.complemento = complemento;
        }

        public string getcComplemento()
        {
            return this.complemento;
        }

        public void setCep(string cep)
        {
            this.cep = cep;
        }

        public string getCep()
        {
            return this.cep;
        }

        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }

        public string getCidade()
        {
            return this.cidade;
        }

        public void setEstado(string estado)
        {
            this.estado = estado;
        }

        public string getEstado()
        {
            return this.estado;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setFoto(byte[] foto)
        {
            this.foto = foto;
        }

        public byte[] getFoto()
        {
            return this.foto;
        }

        public void setAtivo(int ativo)
        {
            this.ativo = ativo;
        }

        public int getAtivo()
        {
            return this.ativo;
        }

        public bool cadastrarAluno() {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_aluno (CPFAluno,nomeAluno,ruaAluno,numeroAluno," +
                    "bairroAluno,complementoAluno,CEPAluno,cidadeAluno,estadoAluno,telefoneAluno,emailAluno) values ('" + cpf + "','" + nome + "','" + endereco + "','" + numero + "','" + bairro + "','"
                    + complemento + "','" + cep + "','" + cidade + "','" + estado + "','" + telefone + "','" + email + "')", DAO_Conexao.con);
                //insere.Parameters.AddWithValue("foto", this.foto);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally 
            {
                DAO_Conexao.con.Close();            
            }
            return cad;
        }

        public bool excluirAluno() {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_aluno set ativo = 1 where CPFAluno = '" + cpf + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally {
                DAO_Conexao.con.Close();
            }
            return exc;
        }

        public MySqlDataReader consultarTodosAlunos()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_aluno",DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }
    }
}
