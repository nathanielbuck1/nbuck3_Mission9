using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class PageInfo
    {

        //setting infor for paes
        public int TotalNumBooks { get; set; }
        public int BookPerPage { get; set; }
        public int CurrentPage { get; set;}
        //figure out the amount of pages we gon need
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BookPerPage);
    }
}
