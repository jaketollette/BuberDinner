﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(MenuItemId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.Create(Guid.NewGuid()), name, description);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private MenuItem()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
