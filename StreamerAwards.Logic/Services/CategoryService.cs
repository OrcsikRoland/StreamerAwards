using StreamerAwards.Data.Repositories;
using StreamerAwards.Entities.DTOs;
using StreamerAwards.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Logic.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        // Összes kategória lekérdezése
        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        // Kategória lekérdezése ID alapján
        public Category? GetCategoryById(string id)
        {
            return _repository.GetById(id);
        }

        // Új kategória hozzáadása
        public void AddCategory(Category category)
        {
            _repository.Add(category);
            _repository.SaveChanges();
        }

        // Kategória frissítése
        public void UpdateCategory(string id, Category updatedCategory)
        {
            var existingCategory = _repository.GetById(id);
            if (existingCategory == null)
                throw new Exception($"Category with ID {id} not found.");

            existingCategory.Name = updatedCategory.Name;
            existingCategory.Description = updatedCategory.Description;

            _repository.Update(existingCategory);
            _repository.SaveChanges();
        }

        // Kategória törlése
        public void DeleteCategory(string id)
        {
            var existingCategory = _repository.GetById(id);
            if (existingCategory == null)
                throw new Exception($"Category with ID {id} not found.");

            _repository.Delete(id);
            _repository.SaveChanges();
        }

        // Kategóriák lekérdezése streamerekkel együtt
        
    }
}
