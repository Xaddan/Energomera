using Application.Common.Models;
using MediatR;

namespace Application.Items.Commands.Remove
{
    public class RemoveRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
