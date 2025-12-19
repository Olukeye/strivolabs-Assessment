//using strivolabs_Assessment.Repository;

//namespace strivolabs_Assessment.Middlewares
//{
//    public class ServiceAuthenticationMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public ServiceAuthenticationMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context, IServiceTokenRepository serviceRepo)
//        {
//            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

//            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
//            {
//                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                await context.Response.WriteAsync("Missing or invalid Authorization header");
//                return;
//            }

//            var token = authHeader.Substring("Bearer ".Length).Trim();

//            var service = await serviceRepo.GetServiceByToken(token);
//            if (service == null)
//            {
//                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                await context.Response.WriteAsync("Invalid service token");
//                return;
//            }

//            context.Items["Service"] = service;
//            await _next(context);
//        }
//    }
//}
