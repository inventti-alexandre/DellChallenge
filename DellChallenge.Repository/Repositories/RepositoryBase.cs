using DellChallenge.Domain.Interfaces.Repositories;
using DellChallange.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DellChallange.Repository.Transactions;

namespace DellChallange.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DellContext _context;
        protected readonly DbSet<T> DbSet;
        private readonly IUow uow;

        public RepositoryBase(DellContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
            uow = new Uow(_context);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public T RecuperarPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> List()
        {
            return DbSet;
        }

        public void Inserir(T t)
        {
            DbSet.Add(t);
            uow.Commit();
        }

        public void Atualizar(T t)
        {
            DbSet.Update(t);
            uow.Commit();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
