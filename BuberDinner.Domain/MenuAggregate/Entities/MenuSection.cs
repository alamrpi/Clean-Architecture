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
        public string Name { get; private set; }
        public string Description { get; private set; }

        public List<MenuItem> Items { get; set; }

        public MenuSection(MenuSectionId id, string name, string description, List<MenuItem>? menuItems) : base(id)
        {
            Name = name;
            Description = description;
            Items = menuItems ?? new();
        }

        public static MenuSection Create(string name, string description, List<MenuItem>? menuItems)
        {
            return new(MenuSectionId.CreateUnique(), name, description, menuItems);
        }
        public MenuSection()
        {
            
        }
    }
}
