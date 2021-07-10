using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_WebMotors.Dominio;
using Teste_WebMotors.Dominio.Contratos;

namespace Teste_WebMotors.RepositorioADO
{
    public class AnuncioWebmotorsRepositorio : IAnuncioWebmotors
    {
        private readonly string _connString;
        private Contexto contexto;
        public AnuncioWebmotorsRepositorio(string connString)
        {
            _connString = connString;
        }

        public int Atualizar(AnuncioWebmotors entidade)
        {
            var strQuery = new StringBuilder();
            strQuery.Append(" UPDATE tb_AnuncioWebmotors SET ");
            strQuery.Append($" marca = '{entidade.Marca}', ");
            strQuery.Append($" modelo = '{entidade.Modelo}', ");
            strQuery.Append($" versao = '{entidade.Versao}', ");
            strQuery.Append($" ano = '{entidade.Ano}', ");
            strQuery.Append($" quilometragem = '{entidade.Quilometragem}', ");
            strQuery.Append($" observacao = '{entidade.Observacao}' ");
            strQuery.Append($" WHERE ID = {entidade.Id} ");
            
            using (contexto = new Contexto(_connString))
            {
                return contexto.ExecutaComando(strQuery.ToString());
            }
        }

        public List<AnuncioWebmotors> Buscar()
        {
            var strQuery = new StringBuilder();
            strQuery.Append(" SELECT ID, marca, modelo, versao, ano, quilometragem, observacao ");
            strQuery.Append(" FROM tb_AnuncioWebmotors ");
            
            using (contexto = new Contexto(_connString))
            {
                var retorno = contexto.ExecutaComandoComRetorno(strQuery.ToString());
                return TransformaReaderEmListaDeObjeto(retorno);
            }
        }

        public AnuncioWebmotors BuscarPorId(int id)
        {
            var strQuery = new StringBuilder();
            strQuery.Append(" SELECT ID, marca, modelo, versao, ano, quilometragem, observacao ");
            strQuery.Append(" FROM tb_AnuncioWebmotors ");
            strQuery.Append($" WHERE ID = {id} ");
            using (contexto = new Contexto(_connString))
            {
                var retorno = contexto.ExecutaComandoComRetorno(strQuery.ToString());
                return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
            }
        }

        public int Inserir(AnuncioWebmotors entidade)
        {
            var strQuery = new StringBuilder();
            strQuery.Append(" INSERT INTO tb_AnuncioWebmotors (marca, modelo, versao, ano, quilometragem, observacao) ");
            strQuery.Append($" VALUES ('{entidade.Marca}','{entidade.Modelo}','{entidade.Versao}','{entidade.Ano}','{entidade.Quilometragem}','{entidade.Observacao}') ");

            using (contexto = new Contexto(_connString))
            {
                //TODO: retornar o id do objeto inserido
                return contexto.ExecutaComando(strQuery.ToString());
            }
        }

        public int Remover(int id)
        {
            var strQuery = new StringBuilder();
            strQuery.Append(" DELETE FROM tb_AnuncioWebmotors ");
            strQuery.Append($" WHERE ID = {id} ");

            using (contexto = new Contexto(_connString))
            {
                return contexto.ExecutaComando(strQuery.ToString());
            }
        }

        private List<AnuncioWebmotors> TransformaReaderEmListaDeObjeto(List<Dictionary<string, string>> rows)
        {
            var anuncio = new List<AnuncioWebmotors>();
            foreach (var row in rows)
            {
                var temObjeto = new AnuncioWebmotors()
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["ID"]) ? row["ID"] : "0"),
                    Marca = row["marca"],
                    Modelo = row["modelo"],
                    Versao = row["versao"],
                    Ano = int.Parse(!string.IsNullOrEmpty(row["ano"]) ? row["ano"] : "0"),
                    Quilometragem = int.Parse(!string.IsNullOrEmpty(row["quilometragem"]) ? row["quilometragem"] : "0"),
                    Observacao = row["observacao"],
                };
                anuncio.Add(temObjeto);
            }
            return anuncio;
        }
    }
}
