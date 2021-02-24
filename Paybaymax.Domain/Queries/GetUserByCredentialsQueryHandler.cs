using MediatR;
using Paybaymax.Domain.Repositories;
using Paybaymax.Models;
using Paybaymax.Data;
using System.Threading;
using System.Threading.Tasks;
using Paybaymax.Models.Exceptions;

namespace Paybaymax.Domain.Queries
{
    public class GetUserByCredentialsQueryHandler : IRequestHandler<GetUserByCredentialsQuery, UserDTO>
    {
        private readonly IUserRepository userRepository;

        public GetUserByCredentialsQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
        {
            User user = await this.userRepository.GetUserByCredentials(request.email, request.password);
            if (user == null)
                throw new UserNotFoundException();

            return UserDTO.ProjectionDelegate(user);
        }
    }

    public class GetUserByCredentialsQuery : IRequest<UserDTO>
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
