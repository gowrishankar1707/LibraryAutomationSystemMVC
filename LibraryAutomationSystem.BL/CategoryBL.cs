using System.Collections.Generic;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.BL
{
    public interface ICategoryBL//Category Interface
    {
        IEnumerable<Category> GetCategory();
        Category GetCategoryById(int categoryId);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int categoryId);
    }
    public class CategoryBL:ICategoryBL
    {
        public IEnumerable<Category> GetCategory()//Get the Category By List
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.GetCategory();
        }
        public Category GetCategoryById(int categoryId)//Get the particular by Id
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Get_CategoryById(categoryId);
        }
        public int AddCategory(Category category)//Add the Category 
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.AddCategory(category);
        }
        public int UpdateCategory(Category category)//Update the category
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Update_Category(category);
        }
        public int DeleteCategory(int categoryId)//Delete the category
        {
            CategoryRepository repository = new CategoryRepository();
            return repository.Delete_Category(categoryId);
        }
    }
}
