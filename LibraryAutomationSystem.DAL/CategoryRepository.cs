using LibraryAutomationSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.DAL
{
    public class CategoryRepository
    {
        public IEnumerable<Category> GetCategory()
        {
            using (DBConnection dbConnection = new DBConnection())
            {

                return dbConnection.Categories.ToList();
            }
        }
        public int AddCategory(Category category)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                dbConnection.Categories.Add(category);
                return dbConnection.SaveChanges();
            }
        }
        public Category Get_CategoryById(int categoryId)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.Categories.Find(categoryId);
            }
        }
        public int Update_Category(Category category)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                dbConnection.Entry(category).State = System.Data.Entity.EntityState.Modified;
                return dbConnection.SaveChanges();
            }
        }
        public int Delete_Category(int CategoryId)
        {

            using (DBConnection dbConnection = new DBConnection())
            {
                Entity.Category category = dbConnection.Categories.Find(CategoryId);
                dbConnection.Categories.Remove(category);
                return dbConnection.SaveChanges();
            }
        }
    }
}
