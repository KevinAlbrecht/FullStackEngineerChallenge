using MediatR;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using Paybaymax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<LightEmployeeDTO>>
    {
        private readonly IEmployeeRepository EmployeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<LightEmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Employee> employees = await this.EmployeeRepository.GetAllEmployeesAsync();
            return employees.Select(e => LightEmployeeDTO.ProjectionDelegate(e));
        }
    }

    public class GetAllEmployeesQuery : IRequest<IEnumerable<LightEmployeeDTO>> { }
}
