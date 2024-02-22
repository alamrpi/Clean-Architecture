using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public MenuSection(MenuSectionId id, string name, string description, List<MenuItem>? menuItems) : base(id)
        {
            Name = name;
            Description = description;
            _items = menuItems ?? new();
        }

        public static MenuSection Create(string name, string description, List<MenuItem>? menuItems)
        {
            return new(MenuSectionId.CreateUnique(), name, description, menuItems);
        }
    }
}
