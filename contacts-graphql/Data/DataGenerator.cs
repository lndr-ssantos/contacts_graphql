using contacts_graphql.Models.EntityModels.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace contacts_graphql.Data
{
    public static class DataGenerator
    {
        public static void Initiate(IServiceProvider serviceProvider)
        {
            using (var context = new ContactContext(serviceProvider.GetRequiredService<DbContextOptions<ContactContext>>()))
            {
                if (context.Contacts.Any())
                    return;

                var contact1 = new Contact
                {
                    Name = "Leandro Souza",
                    Birthday = new DateTime(1996, 07, 19),
                    PhoneNumber = "(79) 95555-9999"
                };

                var contact2 = new Contact
                {
                    Name = "Felipe Oliveira",
                    Birthday = new DateTime(1991, 11, 17),
                    PhoneNumber = "(79) 95574-9879"
                };

                var contact3 = new Contact
                {
                    Name = "Raquel Costa",
                    Birthday = new DateTime(1994, 12, 15),
                    PhoneNumber = "(79) 95123-9789"
                };

                context.Contacts.AddRange(contact1, contact2, contact3);
                context.SaveChanges();
            }
        }
    }
}
