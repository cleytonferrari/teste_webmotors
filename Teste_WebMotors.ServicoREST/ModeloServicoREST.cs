using System.Collections.Generic;
using System.Threading.Tasks;
using Teste_WebMotors.Dominio;
using Teste_WebMotors.Dominio.Contratos;

namespace Teste_WebMotors.ServicoREST
{
    public class ModeloServicoREST: IModeloRest
    {
        private string _url;
        public ModeloServicoREST(string url)
        {
            _url = url;
        }

        public Task<List<Modelo>> ListarPorMarcaId(int marcaId)
        {
            _url += $"?MakeID={marcaId}";
            var retorno = ServicoREST<List<Modelo>>.Get(_url);
            return retorno;
        }
    }
}
