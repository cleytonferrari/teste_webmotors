using System.Collections.Generic;
using System.Threading.Tasks;
using Teste_WebMotors.Dominio;
using Teste_WebMotors.Dominio.Contratos;

namespace Teste_WebMotors.ServicoREST
{
    public class MarcaServicoREST: IMarcaRest
    {
        private readonly string _url;
        public MarcaServicoREST(string url)
        {
            _url = url;
        }

        public Task<List<Marca>> ListarTodas()
        {
            var retorno = ServicoREST<List<Marca>>.Get(_url);
            return retorno;
        }
    }
}
