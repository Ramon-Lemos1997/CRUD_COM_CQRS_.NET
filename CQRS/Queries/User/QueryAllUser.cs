using MediatR;

namespace CQRS.Queries.User
{
    public class QueryAllUser : IRequest<IEnumerable<Domain.Entities.User.User>>
    {
    }
}
