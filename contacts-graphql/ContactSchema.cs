using contacts_graphql.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace contacts_graphql
{
    public class ContactSchema : Schema
    {
        public ContactSchema(IServiceProvider serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ContactQuery>();
        }
    }
}
