using System.Collections.Generic;
using System.Threading.Tasks;
using Teste_WebMotors.Dominio;
using Teste_WebMotors.Dominio.Contratos;

namespace Teste_WebMotors.ServicoREST
{
    public class VersaoServicoREST: IVersaoRest
    {
        private string _url;
        public VersaoServicoREST(string url)
        {
            _url = url;
        }

        public Task<List<Versao>> ListarPorModeloId(int modeloId)
        {
            _url += $"?ModelID={modeloId}";
            var retorno = ServicoREST<List<Versao>>.Get(_url);
            return retorno;
        }
    }
}
