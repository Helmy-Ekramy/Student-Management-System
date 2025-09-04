using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentManagementSystem.Filters
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
      public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"After Action Executed : {context.Result}");

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Befor Action Executed : {context.ActionDescriptor.DisplayName}");
        }
    }
}
