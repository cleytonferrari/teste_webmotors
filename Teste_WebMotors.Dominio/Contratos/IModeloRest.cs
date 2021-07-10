using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste_WebMotors.Dominio.Contratos
{
    public interface IModeloRest
    {
        Task<List<Modelo>> ListarPorMarcaId(int marcaId);
    }
}
