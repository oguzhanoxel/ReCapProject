using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Utilities.FileTools
{
    public class FormFileModel
    {
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
