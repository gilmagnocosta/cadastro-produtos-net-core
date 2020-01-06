using CadastroProdutos.Infra.Data.Interface;
using System;
using CadastroProdutos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
