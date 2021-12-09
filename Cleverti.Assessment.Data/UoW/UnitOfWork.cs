using Cleverti.Assessment.Data.Context;
using Cleverti.Assessment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverti.Assessment.Data.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MemoryContext _context;

        public UnitOfWork(MemoryContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
