using MediatR;

namespace CQRS.Queries.User
{
    public class QueryUserById : IRequest<Domain.Entities.User.User>
    {
        public QueryUserById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}