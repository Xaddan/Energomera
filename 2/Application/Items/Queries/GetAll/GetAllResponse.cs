using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Items.Queries.GetAll
{
    public class GetAllResponse : IAutoMap<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}