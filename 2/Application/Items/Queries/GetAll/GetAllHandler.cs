using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Context;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Items.Queries.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, Result<List<GetAllResponse>>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetAllHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllResponse>>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var items = await _context.Items
                .ProjectTo<GetAllResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!items.Any())
            {
                return Result<List<GetAllResponse>>.Fail("Не найден не один Item");
            }

            return Result<List<GetAllResponse>>.Success(items);
        }
    }
}
