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
                "روشنایی هوشمند",
                "سیستم امنیتی هوشمند",
                "سرمایش و گرمایش هوشمند",
                "اطلاع رسانی هوشمند",
                "کنترل از راه دور",
                "بهینه سازی مصرف انرژی",
                  
            };
            return ls;
        }
    }
}