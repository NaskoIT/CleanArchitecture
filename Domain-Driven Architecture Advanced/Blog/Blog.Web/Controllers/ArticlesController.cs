using Blog.Application.Articles.Commands.ChangeVisibility;
using Blog.Application.Articles.Commands.Create;
using Blog.Application.Articles.Queries.Details;
using Blog.Application.Articles.Queries.IsByUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Authorize]
    public class ArticlesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailsViewModel>> Details([FromRoute] ArticleDetailsQuery query) => 
            await this.Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArticleCommand command)
            => await this.Mediator.Send(command);

        [HttpPut("[action]")]
        public async Task<ActionResult> ChangeVisibility(ChangeArticleVisibilityCommand command)
        {
            await this.Mediator.Send(command);
            return this.NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<bool>> IsByUser([FromRoute] ArticleIsByUserQuery query)
            => await this.Mediator.Send(query);
    }
}
