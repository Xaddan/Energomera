using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Context
{
    public interface IDbContext
    {
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
