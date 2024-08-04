using WebApi.Domain.Abstract;
using WebApi.Domain.Entities;

namespace WebApi.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Categories> _repository;

        public CategoryService(IRepository<Categories> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _repository.GetData();
        }
    }
}
