using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menu = Menu.Create(HostId.Create(request.HostId),
                request.Name,
                request.Description,
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description, 
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name, 
                        item.Description))
                    ))
                );
            _menuRepository.Add(menu);
            return menu;
        }
    }
}
