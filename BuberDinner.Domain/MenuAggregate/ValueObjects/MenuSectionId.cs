using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique() => new MenuSectionId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }

        public static MenuSectionId Create(Guid value) => new(value);
        public MenuSectionId()
        {
            
        }
    }
}
