using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace EFCommands
{
   public abstract class EFBaseCommand
    {
        protected readonly DatabaseContext _context;

        public EFBaseCommand(DatabaseContext context)
        {
            this._context = context;
        }
    }
}
