namespace StudentManagementSystem.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task Invoke(HttpContext context)
        {

            Console.WriteLine($"URL : {context.Request.Path}");
            await _next(context);
        }

    }
}
