using SuperDigital.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
