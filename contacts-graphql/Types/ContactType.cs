using contacts_graphql.Models.EntityModels.Contacts;
using GraphQL.Types;

namespace contacts_graphql.Types
{
    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType()
        {
            Name = "Contact";
            Field(x => x.Id, type:typeof(IdGraphType)).Description("Contact id");
            Field(x => x.Name).Description("Contact name");
            Field(x => x.PhoneNumber).Description("Contact phone number");
            Field(x => x.Birthday).Description("Contact birthday");
        }
    }
}
