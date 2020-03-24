using System.Collections.Generic;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.BL
{
    public interface ICategoryBL
    {
        IEnumerable<Category> GetCategory();
        Category GetCategoryById(int categoryId);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int categoryId);
    }
    public class CategoryBL:ICategoryBL
    {
        public IEnumerable<Category> GetCategory()
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.GetCategory();
        }
        public Category GetCategoryById(int categoryId)
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Get_CategoryById(categoryId);
        }
        public int AddCategory(Category category)
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.AddCategory(category);
        }
        public int UpdateCategory(Category category)
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Update_Category(category);
        }
        public int DeleteCategory(int categoryId)
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Delete_Category(categoryId);
        }
    }
}
