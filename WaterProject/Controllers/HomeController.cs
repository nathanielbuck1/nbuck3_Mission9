using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepo repo;

        public HomeController (IBookRepo temp)
        {
            repo = temp;
        }
        //page info and code
        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            //setting the page
            var x = new ProjectViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == Category || Category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                //setting the page numbers
                PageInfo = new PageInfo
                {

                    TotalNumBooks = (
                        Category == null
                        ? repo.Books.Count()
                        :repo.Books.Where(x => x.Category == Category).Count()),
                    BookPerPage = pageSize,
                    CurrentPage = pageNum

                }


            };

            return View(x);
        }
    }
}
