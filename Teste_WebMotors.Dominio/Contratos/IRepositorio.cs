using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste_WebMotors.Dominio.Contratos
{
    public interface IRepositorio<T> where T: class
    {
        T BuscarPorId(int id);

        List<T> Buscar();

        int Inserir(T entidade);

        int Atualizar(T entidade);

        int Remover(int id);
    }
}
