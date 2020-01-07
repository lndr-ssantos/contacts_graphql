using contacts_graphql.Models.EntityModels.Contacts;
using Microsoft.EntityFrameworkCore;

namespace contacts_graphql.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
