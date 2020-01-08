using Microsoft.EntityFrameworkCore;
using System;

namespace CadastroProdutos.Infra.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}
