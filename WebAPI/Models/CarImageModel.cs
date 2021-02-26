using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CarImageModel:CarImage
    {
        public IFormFile ImageFile { get; set; }
        public string FileName { get; set; }
    }
}
