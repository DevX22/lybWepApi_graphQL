using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Net.Http.Headers;
using Models.err_Models;
using System.Security.Claims;

namespace Presentation.Middleware
{
    public class HelperHttpContext
    {
        public static InfoRequest GetInfoRequest(HttpContext request)
        {
            InfoRequest obj = new InfoRequest();
            obj.Claims = getTokenClaims(request);
            obj.RequestHttp = getHttpContextInfo(request);

            return obj;
        }

        private static TokenClaims getTokenClaims(HttpContext request)
        {
            TokenClaims obj = new TokenClaims();
            string autorizacion = request.Request.Headers[HeaderNames.Authorization];
            if (autorizacion != null)
            {
                var identity = request.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    obj.user_name = identity.Claims.Where(c => c.Type == "user").Select(c => c.Value).SingleOrDefault();
                    obj.user_id = int.Parse(identity.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault());
                    obj.rol_user = identity.Claims.Where(c => c.Type == "rol").Select(c => c.Value).SingleOrDefault();
                }
            }
            return obj;
        }

        private static ApiRequestContext getHttpContextInfo(HttpContext request)
        {
            ApiRequestContext obj = new ApiRequestContext();
            obj.absolutePath = request.Request.GetEncodedUrl(); ;
            obj.absoluteUri = request.Request.GetEncodedPathAndQuery();
            obj.ip = request.Connection.RemoteIpAddress.ToString();
            obj.method = $"{request.Request.Method}";
            obj.userAgent = request.Request.Headers[HeaderNames.UserAgent];
            obj.controller = request.GetEndpoint().DisplayName;
            try
            {
                var reader = new StreamReader(request.Request.Body);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                obj.bodyRequest = reader.ReadToEnd();
            }
            catch (Exception)
            {
                obj.bodyRequest = "";
            }
            return obj;
        }
    }
}
