using FluentValidation;

namespace Blog.Application.Articles.Commands.Create
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(a => a.Title)
                .MaximumLength(40)
                .NotEmpty();

            RuleFor(a => a.Content)
                .NotEmpty();
        }
    }
}
