using Ecommerce.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class DisplayService : IDisplayer
    {
        private IHttpContextAccessor _accessor;

        public DisplayService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string ReWriteImageUrl(string url)
        {
            string host = _accessor.HttpContext.Request.Scheme +@"://"+ _accessor.HttpContext.Request.Host.Value;
            if(url.Contains("http"))
            {
                return url;
            }
            return host +@"/" + url;
        }
    }
}
