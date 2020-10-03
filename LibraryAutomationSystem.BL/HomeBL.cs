using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;

namespace LibraryAutomationSystem.BL
{
    public interface IHomeBL
    {
        IEnumerable<Entity.Book> DisplayBooks();
    }
    public class HomeBL : IHomeBL
    {
       
        public IEnumerable<Entity.Book> DisplayBooks()
        {
            BookRepository bookRepository = new BookRepository();
            return bookRepository.DisplayBook();
        }
    }
}
