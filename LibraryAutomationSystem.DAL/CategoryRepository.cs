﻿using LibraryAutomationSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAutomationSystem.DAL
{
    public class CategoryRepository
    {
        public IEnumerable<Category> GetCategory()//Get the Category To list
        {
            using (DBConnection dbConnection = new DBConnection())
            {

                return dbConnection.Categories.ToList();
            }
        }
        public int AddCategory(Category category)//Add category
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                dbConnection.Entry(category).State=System.Data.Entity.EntityState.Added;//Add the category by using Entit state Added
                return dbConnection.SaveChanges();
            }
        }
        public Category Get_CategoryById(int categoryId)//Get the Category By Id
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.Categories.Find(categoryId);
            }
        }
        public int Update_Category(Category category)//Update the Category
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                dbConnection.Entry(category).State = System.Data.Entity.EntityState.Modified;//Modified the Category by using Entity state modified
                return dbConnection.SaveChanges();
            }
        }
        public int Delete_Category(int CategoryId)//Delete the Categoty 
        {

            using (DBConnection dbConnection = new DBConnection())
            {
                Entity.Category category = dbConnection.Categories.Find(CategoryId);
                dbConnection.Entry(category).State = System.Data.Entity.EntityState.Deleted;//Delete the Category by using Entity state:Deleted
                return dbConnection.SaveChanges();
            }
        }
    }
}
