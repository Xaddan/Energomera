using MediatR;

namespace Application.Items.Commands.Create
{
    public class CreateRequest : IRequest
    {
        public string Name { get; set; }
    }
}
