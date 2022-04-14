using Application.Common.Mappings;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Items.Commands.Update
{
    public class UpdateRequest : IRequest<Result>, IAutoMap<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
