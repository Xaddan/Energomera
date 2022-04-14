using Application.Common.Models;
using MediatR;

namespace Application.Items.Queries.GetById
{
    public class GetByIdRequest : IRequest<Result<GetByIdResponse>>
    {
        public int Id { get; set; }
    }
}
