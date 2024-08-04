using WebApi.Domain.Entities;

namespace WebApi.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetCategories();
    }
}