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
            });
        }
    }
}