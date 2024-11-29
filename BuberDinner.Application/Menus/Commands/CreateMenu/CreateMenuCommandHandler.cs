using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (!Guid.TryParse(request.HostId, out Guid hostId))
        {
            return Errors.Common.InvalidId;
        }

        // Create menu
        var menu = Menu.Create(
            hostId: HostId.Create(hostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(s => MenuSection.Create(
                name: s.Name,
                description: s.Description,
                menuItems: s.Items.ConvertAll(i => MenuItem.Create(
                    name: i.Name,
                    description: i.Description
                ))
            ))
            );

        // Persist menu
        menuRepository.Add(menu);

        // Return menu
        return menu;
    }
}