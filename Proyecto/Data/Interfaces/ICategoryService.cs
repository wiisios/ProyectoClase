using Proyecto.Entities;

namespace Proyecto.Data.Interfaces
{
    public interface ICategoryService
    {
        void Create(string categoryName);
        Category GetByName(string categoryName);
        Category GetById(int categoryId);
    }
}
