using Secop.Core.Domain.Entities.CustomerEntities;

namespace Secop.Core.Application.Repositories.CustomerRepositories
{
    public interface IContactRepository : IPostgreGenericRepository<Contact>
    {
    }
}
