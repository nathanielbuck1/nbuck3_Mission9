using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Components
{

    //classes
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepo repo { get; set; }

        public TypesViewComponent (IBookRepo temp)
        {
            repo = temp;
        }

        //Getting the categories
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTypes = RouteData?.Values["Category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }

    }
}
