using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.BL;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryBL categoryBL;
        public CategoryController()
        {
            categoryBL = new CategoryBL();//Creates the object to the Category Bl by the Reference variable of ICategoryBl
        }
        CategoryRepository repository = new CategoryRepository();

        public ActionResult Category()// GET: Category
        {
            var category = categoryBL.GetCategory();//Get the Category and stored in dynamic datatype
            return View(category);//pass the details to the view to display the Categories
        }
        [HttpGet]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Get()//Get Method of Create Categories
        {
            return View();
        }
        public ActionResult Edit_Category(int CategoryId)//Get the Particular Category By Id
        {
            if (ModelState.IsValid)
            {
                Models.Category categorylist = new Models.Category();

                Entity.Category category = categoryBL.GetCategoryById(CategoryId);//Get the Particular Category By its Id
                Models.Category categoryList = AutoMapper.Mapper.Map<Entity.Category, Models.Category>(category);//Automap the Category Entity to Category Model
                return View(categoryList);//Pass the Details to the View to Show the Existing Details
            }
            return View();
        }

        [HttpPost]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Post(Models.Category category)
        {
            Entity.Category entityCategory=AutoMapper.Mapper.Map<Models.Category, Entity.Category>(category);
            if (categoryBL.AddCategory(entityCategory) >= 1)//If the result is greater than 1 return to Categories View
                return RedirectToAction("Category");
            return View();//If result is lesser than 0 It existing at current created view
        }
        [HttpPost]
        public ActionResult Update_Category(Models.Category category)//Update the Category By Passing the values from Model to Entity
        {
            Entity.Category entityCategory = AutoMapper.Mapper.Map<Models.Category, Entity.Category>(category);
            if (categoryBL.UpdateCategory(entityCategory) >= 1)//Result is greater than 0
                return RedirectToAction("Category");
            return View();


        }

        public ActionResult Delete_Category(int CategoryID)//Delete the Category By CategoryId
        {
            if (categoryBL.DeleteCategory(CategoryID) >= 1)//If result is Greator than  it will return to the Category
                return RedirectToAction("Category");
            return View();
        }
    }
}