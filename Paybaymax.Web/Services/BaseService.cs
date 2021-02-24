using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services
{
    public abstract class BaseService
    {
        protected readonly IMediator Mediator;

        public BaseService(IMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}
