using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Context;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Items.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, Result<GetByIdResponse>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GetByIdResponse>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Items
                .Where(i => i.Id == request.Id)
                .ProjectTo<GetByIdResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (item == null)
            {
                return Result<GetByIdResponse>.Fail("Не найден указанный Item");
            }

            return Result<GetByIdResponse>.Success(item);
        }
    }
}
