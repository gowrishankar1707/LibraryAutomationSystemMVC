using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.Models;

namespace LibraryAutomationSystem.App_Start
{
    public class MapConfig
    {
        public static void Mapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Models.LoginModel, Entity.User>();
                config.CreateMap<Models.BookLanguageModel,Entity.BookLanguage>();
                config.CreateMap<Entity.BookLanguage, Models.EditLanguageModel>();
                config.CreateMap<Models.EditLanguageModel, Entity.BookLanguage>();
                config.CreateMap<Entity.Book, Models.EditBookModel>();
                config.CreateMap<Models.EditBookModel, Entity.Book>();
                config.CreateMap<Entity.Category, Models.CategoryModel>();
                config.CreateMap<Models.CategoryModel, Entity.Category>();
                config.CreateMap<RegistrationModel, User>();
                config.CreateMap<AddBookModel, Book>();
            });
        }
    }
}