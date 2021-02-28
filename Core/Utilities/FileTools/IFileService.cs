using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileTools
{
    public interface IFileService
    {
        IDataResult<string> UploadFile(String webRootPath, String folderName, IFormFile formFile);
        IResult DeleteFileFromFolder(String webRootPath, String filePath);
    }
}
