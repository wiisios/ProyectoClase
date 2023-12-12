using Proyecto.Data;
using Proyecto.Data.Interfaces;
using Proyecto.Entities;

namespace Proyecto.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly URLContext _context;


        public CategoryService(URLContext context)
        {
            _context = context;

        }

        public void Create(string categoryName)
        {

            Category categoryExists = GetByName(categoryName);

            if (categoryExists == null)
            {

                Category category = new Category()
                {
                    Name = categoryName,

                };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            
        }

        public Category GetByName(string categoryName)
        {
            var category = _context.Categories.SingleOrDefault(u => u.Name == categoryName);
            if (category is not null)
            {
                return category;
            }
            return null;
        }

        public Category GetById(int categoryId)
        {
            var category = _context.Categories.SingleOrDefault(u => u.Id == categoryId);
            if (category is not null)
            {
                return category;
            }
            return null;
        }

    }
}
