using System.Threading;
using System.Threading.Tasks;
using Application.Common.Context;
using Application.Common.Models;
using MediatR;

namespace Application.Items.Commands.Remove
{
    public class RemoveHandler : IRequestHandler<RemoveRequest, Result>
    {
        private readonly IDbContext _context;

        public RemoveHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(RemoveRequest request, CancellationToken cancellationToken)
        {
            var item = await _context.Items
                .FindAsync(request.Id);

            if (item == null)
            {
                return Result.Fail("Не найден указанный Item");
            }

            _context.Items.Remove(item);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
