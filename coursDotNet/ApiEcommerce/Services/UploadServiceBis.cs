using Ecommerce.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class UploadServiceBis : IUpload
    {
        IWebHostEnvironment _env;

        public UploadServiceBis(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string Upload(IFormFile image)
        {
            string uniqueString = Guid.NewGuid().ToString();
            string basePath = @"upload/" + uniqueString + "-" + image.FileName;
            string path = Path.Combine(_env.WebRootPath, basePath);
            Stream s = System.IO.File.Create(path);
            image.CopyTo(s);
            s.Close();
            return basePath;
        }
    }
}
