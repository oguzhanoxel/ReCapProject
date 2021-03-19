using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileTools
{
    public interface IFileService
    {
        IDataResult<string> Add(String folderName, IFormFile formFile);
        IResult Delete(String filePath);
    }
}
