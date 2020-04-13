using SuperDigital.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
