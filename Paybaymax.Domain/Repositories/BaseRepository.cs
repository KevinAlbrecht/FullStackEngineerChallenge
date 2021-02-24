using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paybaymax.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PaybaymaxContext Context;
        public BaseRepository(PaybaymaxContext context)
        {
            this.Context = context;
        }
    }
}
