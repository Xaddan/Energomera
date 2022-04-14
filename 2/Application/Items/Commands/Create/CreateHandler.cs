using System.Threading;
using System.Threading.Tasks;
using Application.Common.Context;
using Domain.Entities;
using MediatR;

namespace Application.Items.Commands.Create
{
    public class CreateHandler : IRequestHandler<CreateRequest>
    {
        private readonly IDbContext _context;

        public CreateHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name,
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
