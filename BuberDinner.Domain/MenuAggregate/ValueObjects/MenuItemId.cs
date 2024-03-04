using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique() => new MenuItemId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }

        public static MenuItemId Create(Guid value) => new MenuItemId(value);
        public MenuItemId()
        {
            
        }
    }
}
