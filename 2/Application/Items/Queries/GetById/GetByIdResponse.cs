using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Items.Queries.GetById
{
    public class GetByIdResponse : IAutoMap<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}