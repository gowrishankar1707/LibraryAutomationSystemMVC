﻿using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Models;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class CategoryController : Controller
    {
        ICategoryBL categoryBL;
        public CategoryController()
        {
            categoryBL = new CategoryBL();//Creates the object to the Category Bl by the Reference variable of ICategoryBl
        }
        [Authorize(Roles = "admin,user")]
        public ActionResult Category()// GET: Category
        {
            var category = categoryBL.GetCategory();//Get the Category and stored in dynamic datatype
            return View(category);//pass the details to the view to display the Categories
        }
        [HttpGet]
        [ActionName("Create_Category")]
        [Authorize(Roles = "admin")]
        public ActionResult Create_Category_Get()//Get Method of Create Categories
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit_Category(int categoryId)//Get the Particular Category By Id
        {
            if (ModelState.IsValid)
            {
                CategoryModel categorylist = new CategoryModel();

                Entity.Category category = categoryBL.GetCategoryById(categoryId);//Get the Particular Category By its Id
                Models.CategoryModel categoryList = AutoMapper.Mapper.Map<Entity.Category, Models.CategoryModel>(category);//Automap the Category Entity to Category Model
                return View(categoryList);//Pass the Details to the View to Show the Existing Details
            }
            return View();
        }

        [HttpPost]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Post(Models.CategoryModel category)
        {
            Entity.Category entityCategory = AutoMapper.Mapper.Map<Models.CategoryModel, Entity.Category>(category);
            if (categoryBL.AddCategory(entityCategory) >= 1)//If the result is greater than 1 return to Categories View
                return RedirectToAction("Category");
            return View();//If result is lesser than 0 It existing at current created view
        }
        [HttpPost]
        [ActionName("Edit_Category")]
        public ActionResult Update_Category(CategoryModel category)//Update the Category By Passing the values from Model to Entity
        {
            if (ModelState.IsValid)
            {
                Entity.Category entityCategory = AutoMapper.Mapper.Map<CategoryModel, Entity.Category>(category);
                if (categoryBL.UpdateCategory(entityCategory) >= 1)//Result is greater than 0
                    return RedirectToAction("Category");
            }
            return View(category);//Return to edit if the model state is failed


        }

        public ActionResult Delete_Category(int categoryID)//Delete the Category By CategoryId
        {
            if (categoryBL.DeleteCategory(categoryID) >= 1)//If result is Greator than  it will return to the Category
                return RedirectToAction("Category");
            return RedirectToAction("Edit_Category", new { categoryId = categoryID });
        }
    }
}