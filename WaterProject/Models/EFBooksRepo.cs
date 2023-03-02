using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFBooksRepo : IBookRepo
    {
        private BookstoreContext context { get; set; }

        public EFBooksRepo(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Books> Books => context.Books;
    }
}
