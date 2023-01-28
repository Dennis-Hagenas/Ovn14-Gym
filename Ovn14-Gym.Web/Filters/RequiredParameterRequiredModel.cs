using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ovn14_Gym.Web.Filters
{
    public class RequiredParameterRequiredModel: ActionFilterAttribute
    {
        public string ParameterName { get; }

        public RequiredParameterRequiredModel(string ParameterName)
        {
            if (string.IsNullOrWhiteSpace(ParameterName))
            {
                throw new ArgumentException($"'{nameof(ParameterName)}' cannot be null or whitespace.", nameof(ParameterName));
            }

            this.ParameterName = ParameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.RouteData.Values[ParameterName] == null)
            {
                context.Result = new NotFoundResult();
            }
                }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
        if(context.Result is ViewResult viewResult)
            {
                if (viewResult.Model == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }

    }
}
