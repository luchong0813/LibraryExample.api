using LibraryExample.api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Filters
{
    public class CheckAutoExistFilterAttribute : ActionFilterAttribute
    {
        public IRepositoryWrapper _repositoryWrapper { get; }

        public CheckAutoExistFilterAttribute(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authorIdParameter = context.ActionArguments.Single(m => m.Key == "authorId");
            int authorId = Convert.ToInt32(authorIdParameter.Value);
            var isExist = await _repositoryWrapper.Author.IsExistAsync(authorId);
            if (!isExist)
            {
                context.Result = new NotFoundResult();
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
