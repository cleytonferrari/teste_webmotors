﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_WebMotors.Dominio.Contratos
{
    public interface IRepositorio<T> where T: class
    {
        Task<T> BuscarPorId(string id);

        IQueryable<T> Buscar();

        Task<IEnumerable<T>> Todos();

        Task InserirAsync(T entidade);

        void Inserir(T entidade);

        Task InserirAsync(IEnumerable<T> entidades);

        Task AtualizarAsync(T entidade);

        void Atualizar(T entidade);

        Task Remover(string id);
    }
}
