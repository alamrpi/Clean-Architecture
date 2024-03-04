using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistance.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDinnerDbContext _context;

        public MenuRepository(BuberDinnerDbContext context)
        {
            this._context = context;
        }
        public void Add(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }
    }
}
