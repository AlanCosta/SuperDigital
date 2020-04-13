using SuperDigital.IO.Domain.Core.Commands;
using SuperDigital.IO.Domain.Interfaces;
using SuperDigital.IO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContaCorrenteContext context;

        public UnitOfWork(ContaCorrenteContext _context)
        {
            context = _context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
