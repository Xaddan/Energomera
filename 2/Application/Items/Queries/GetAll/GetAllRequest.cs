using System.Collections.Generic;
using Application.Common.Models;
using MediatR;

namespace Application.Items.Queries.GetAll
{
    public class GetAllRequest : IRequest<Result<List<GetAllResponse>>>
    {
    }
}
