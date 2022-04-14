using System.Threading;
using System.Threading.Tasks;
using Application.Common.Context;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Items.Commands.Update
{
    public class UpdateHandler : IRequestHandler<UpdateRequest, Result>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public UpdateHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Items
                .FindAsync(request.Id);

            if (item == null)
            {
                return Result.Fail("Не найден указанный Item");
            }

            _mapper.Map(request, item);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
