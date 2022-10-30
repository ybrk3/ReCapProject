using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        public string Add(IFormFile file);
        public IResult Delete(string path);
        public string Update(string sourcePath, IFormFile file);
        public string newPath(IFormFile file);

    }
}
