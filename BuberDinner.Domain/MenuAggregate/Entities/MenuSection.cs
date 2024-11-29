using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> menuItems)
        : base(id)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }

    public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}
