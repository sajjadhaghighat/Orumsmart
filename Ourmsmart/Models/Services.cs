using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ourmsmart.Models
{
    public class Services
    {
        public List<string> getServices()
        {
            List<string> ls = new List<string>()
            {
                "صنایع هوشمند",
                "خانه هوشمند",
                "مزارع هوشمند",
                "شهر هوشمند",
                "پارکینگ هوشمند",
                "محصولات هوشمند",
            };
            return ls;
        }
    }
}