using contacts_graphql.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacts_graphql.Models.EntityModels.Contacts
{
    public class ContactRepository
    {
        private readonly ContactContext _dbContext;

        public ContactRepository(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetContacts(string name)
        {
            var query = _dbContext.Contacts.AsTracking();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }
           
            return await query.ToListAsync();
        }
    }
}
