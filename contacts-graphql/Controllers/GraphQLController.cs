using contacts_graphql.Queries;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace contacts_graphql.Controllers
{
    [Route("graphql"), ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ContactSchema _schema;

        public GraphQLController(ContactSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
