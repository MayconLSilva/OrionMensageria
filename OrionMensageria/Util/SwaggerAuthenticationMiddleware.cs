using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace OrionMensageria.Util
{
    public class SwaggerAuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public SwaggerAuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    // Pega as credenciais a partir do header do request
                    var header = AuthenticationHeaderValue.Parse(authHeader);
                    var inBytes = Convert.FromBase64String(header.Parameter);

                    var credentials = Encoding.UTF8.GetString(inBytes).Split(':');

                    var username = credentials[0];
                    var password = credentials[1];

                    string senhaCorreta = DateTime.Today.Day.ToString("00") + DateTime.Today.Month.ToString("00");
                    //valida as credenciais
                    if (username.ToUpper().Equals("MASTER") && password.Equals(senhaCorreta))
                    {
                        await next.Invoke(context).ConfigureAwait(false);
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await next.Invoke(context).ConfigureAwait(false);
            }
        }    
    }
}
