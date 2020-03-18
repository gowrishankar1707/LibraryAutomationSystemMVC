using LibraryAutomationSystem.Entity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.App_Start
{
    public class MapConfig
    {
        public static void Mapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Models.BookLanguage, BookLanguage>();
                config.CreateMap<Entity.BookLanguage, Models.Edit_Language>();
                config.CreateMap<Models.Edit_Language, Entity.BookLanguage>();
                config.CreateMap<Entity.Book, Models.Edit_Book>();
                config.CreateMap<Models.Edit_Book, Entity.Book>();
            });
        }
    }
}