namespace My.D3.Configurations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Authorization;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// 配置swag的权限的校验
    /// </summary>
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        /// <summary>
        /// filter监控
        /// </summary>
        /// <param name="operation">操作对象</param>
        /// <param name="context">请求上下文</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (!context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {
                return;
            }

            var scopes = context.MethodInfo
                        .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Select(attr => attr.Roles);
            var requiredScopes = scopes.Distinct();

            if (requiredScopes.Any())
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
                operation.Security.Add(new Dictionary<string, IEnumerable<string>>
                {
                    { "bearerAuth", requiredScopes }
                });
            }

        }
    }
}
