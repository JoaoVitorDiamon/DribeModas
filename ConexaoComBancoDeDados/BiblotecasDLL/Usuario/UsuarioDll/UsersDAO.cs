﻿using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;

namespace Usuario
{
    public static class UserDao
    {
        private static MySqlConnection conexaoBancoDeDados;
        private static MySqlCommand comandoSql;
        private static MySqlDataReader comandoSqlDataReade;
        private static string stringConexao = "server=localhost;port=3308;Database=GerenciamentoDeLojasADM;uid=root;";

        public static void ConectarBancoDeDados()
        {
            try
            {
                conexaoBancoDeDados = new MySqlConnection(stringConexao);
                conexaoBancoDeDados.Open();
                Console.WriteLine("Conexão estabelecida com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public static void DefinirComandoSql(string comandoSqlString)
        {
            comandoSql = new MySqlCommand(comandoSqlString, conexaoBancoDeDados);
        }


        public static void VerificarLinhasAfetadas()
        {
            int linhasafetadas = comandoSql.ExecuteNonQuery();

            if (linhasafetadas == 0)
            {
                throw new Exception("Nenhuma linha foi afetada pela consulta.");
            }
            else
            {
                Console.WriteLine("Linhas afetadas:{0}", linhasafetadas);
            }
        }


        public static void FecharConexao()
        {
            conexaoBancoDeDados.Close();
        }

        public static void AdicionarDados(string parametro, string valor)
        {
            try
            {
                comandoSql.Parameters.AddWithValue(parametro, valor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void ListarUsuarios()
        {
            try
            {
                comandoSql = new MySqlCommand("select *from user", conexaoBancoDeDados);
                comandoSqlDataReade = comandoSql.ExecuteReader();

                while (comandoSqlDataReade.Read())
                {
                    Console.WriteLine($"Nome da Loja:{comandoSqlDataReade["nome_loja"]}\nCNPJ:{comandoSqlDataReade["cnpj"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                comandoSqlDataReade.Close();
            }
        }
    }
}
