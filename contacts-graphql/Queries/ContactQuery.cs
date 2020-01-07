using contacts_graphql.Models.EntityModels.Contacts;
using contacts_graphql.Types;
using GraphQL.Types;

namespace contacts_graphql.Queries
{
    public class ContactQuery : ObjectGraphType<object>
    {
        public ContactQuery(ContactRepository repository)
        {
            Field<ListGraphType<ContactType>>("contact", arguments: new QueryArguments(new QueryArgument[]
            {
                new QueryArgument<IdGraphType> {Name = "id"},
                new QueryArgument<StringGraphType> { Name = "nome" },
            }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("nome");

                return repository.GetContacts(name);
            });
        }
    }
}
