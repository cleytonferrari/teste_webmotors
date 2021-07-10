using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Teste_WebMotors.RepositorioADO
{
    public class Contexto : IDisposable
    {
        private SqlConnection _minhaConexao;

        public Contexto(string connString)
        {
            _minhaConexao = new SqlConnection(connString);
        }
        public int ExecutaComando(string strQuery)
        {
            if (String.IsNullOrEmpty(strQuery))
                throw new ArgumentException("O comandoSQL não pode ser nulo ou vazio");

            try
            {
                AbrirConexao();
                using var cmdComando = CriarComando(strQuery);
                return cmdComando.ExecuteNonQuery();
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Dictionary<string, string>> ExecutaComandoComRetorno(string comandoSQL)
        {
            List<Dictionary<string, string>> linhas = null;

            if (String.IsNullOrEmpty(comandoSQL))
            {
                throw new ArgumentException("O comandoSQL não pode ser nulo ou vazio");
            }
            try
            {

                using (var cmdComando = CriarComando(comandoSQL))
                {
                    AbrirConexao();
                    using (var reader = cmdComando.ExecuteReader())
                    {
                        linhas = new List<Dictionary<string, string>>();
                        while (reader.Read())
                        {
                            var linha = new Dictionary<string, string>();

                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                var nomeDaColuna = reader.GetName(i);
                                var valorDaColuna = reader.IsDBNull(i) ? "" : reader.GetValue(i);// GetString(i);

                                linha.Add(nomeDaColuna, valorDaColuna.ToString());
                            }
                            linhas.Add(linha);
                        }
                    }
                }

            }
            finally
            {
                FecharConexao();
            }

            return linhas;
        }


        private SqlCommand CriarComando(string comandoSQL)
        {
            var cmdComando = _minhaConexao.CreateCommand();
            cmdComando.CommandText = comandoSQL;
            cmdComando.CommandTimeout = 0;
            return cmdComando;
        }

        private void AbrirConexao()
        {
            var tentativas = 3;

            if (_minhaConexao.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                while (tentativas >= 0 && _minhaConexao.State != ConnectionState.Open)
                {
                    _minhaConexao.Open();
                    tentativas--;
                    Thread.Sleep(30);
                }
            }
        }

        private void FecharConexao()
        {
            if (_minhaConexao.State == ConnectionState.Open)
            {
                _minhaConexao.Dispose();
                _minhaConexao.Close();
            }
            SqlConnection.ClearAllPools();
        }

        public void Dispose()
        {
            if (_minhaConexao == null) return;

            _minhaConexao.Dispose();
            _minhaConexao = null;
            GC.Collect();
        }

    }
}
