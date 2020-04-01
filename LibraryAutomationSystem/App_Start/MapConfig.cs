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
                config.CreateMap<Models.Login, Entity.User>();
                config.CreateMap<Models.BookLanguage,Entity.BookLanguage>();
                config.CreateMap<Entity.BookLanguage, Models.Edit_Language>();
                config.CreateMap<Models.Edit_Language, Entity.BookLanguage>();
                config.CreateMap<Entity.Book, Models.Edit_Book>();
                config.CreateMap<Models.Edit_Book, Entity.Book>();
                config.CreateMap<Entity.Category, Models.Category>();
                config.CreateMap<Models.Category, Entity.Category>();
                config.CreateMap<UserModel, User>();
                config.CreateMap<AddBook, Book>();
            });
        }
    }
}