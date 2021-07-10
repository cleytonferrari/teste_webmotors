using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste_WebMotors.Dominio.Contratos
{
    public interface IMarcaRest
    {
        Task<List<Marca>> ListarTodas();
    }
}
