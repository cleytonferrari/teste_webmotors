using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste_WebMotors.Dominio.Contratos
{
    public interface IVersaoRest
    {
        Task<List<Versao>> ListarPorModeloId(int modeloId);
    }
}
