using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Books book, int qty, double price)
        {
            //grab the info
            BasketLineItem line = Items
                .Where(b => b.book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                //pass the info
                Items.Add(new BasketLineItem
                {
                    book = book,
                    Quantity = qty,
                    Price = price
                }) ;
            }
            else
            {
                line.Quantity += qty;
            }
        }
        //calculate!
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);

            return sum;
        }
    }

    //setting the iteams to load and grab
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books book { get; set; } 
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
