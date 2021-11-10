using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controller.Models
{
    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "Blabla1",
                        Company = "Company 1",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Blabla2",
                        Company = "Company 2",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Blabla3",
                        Company = "Company 3",
                        Price = 500
                    },
                     new Phone
                     {
                         Name = "Blabla4",
                         Company = "Company 4",
                         Price = 500
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
