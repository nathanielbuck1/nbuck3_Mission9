﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WaterProject.Infastructure;

namespace WaterProject.Models
{
    public class SessionBasket : Basket
    {

        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket; 
        }

        [JsonIgnore]
        public ISession Session { get; set; }



        public override void AddItem(Books book, int qty, double price)
        {
            base.AddItem(book, qty, price);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }
        public override void clearBasket()
        {
            base.clearBasket();
            Session.Remove("Basket");
        }
    }
}
