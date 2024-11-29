using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories;
public class MenuRepository(BuberDinnerDbContext dbContext) : IMenuRepository
{
    public void Add(Menu menu)
    {
        dbContext.Add(menu);
        dbContext.SaveChanges();
    }
}
