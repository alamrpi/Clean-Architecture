using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _menuSections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _menuSections.AsReadOnly();

        public HostId HostId { get; set; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public Menu(MenuId id, HostId hostId, string name, string description, AverageRating averageRating, List<MenuSection>? sections) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
            AverageRating = averageRating;
            _menuSections = sections ?? new();

        }

        public static Menu Create(HostId hostId, string name, string description, List<MenuSection>? sections)
        {
            return new(MenuId.CreateUnique(), hostId, name, description, AverageRating.CreateNew(), sections);
        }
    }
}
