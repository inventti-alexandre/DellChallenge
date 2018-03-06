using DellChallange.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallange.Repository.Transactions
{
    public class Uow : IUow
    {
        private readonly DellContext _context;

        public Uow(DellContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
           
        }
    }
}
