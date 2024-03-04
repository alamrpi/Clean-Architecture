using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public MenusController(ISender mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody]CreateMenuRequest request, [FromRoute]string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);

            return createMenuResult.Match(
                    menu => Ok(_mapper.Map<MenuResponse>(menu)), Problem);
        }
    }
}
