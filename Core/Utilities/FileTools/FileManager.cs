﻿using Core.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileTools
{
    public class FileManager:IFileService
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";

        public IDataResult<string> Add(String folderName, IFormFile formFile)
        {
            try
            {
                if (formFile.Length > 0)
                {
                    string fileExtention = Path.GetExtension(formFile.FileName);
                    string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("D"), fileExtention);
                    string uploadPath = Path.Combine(directory, folderName);
                    string fullPath = Path.Combine(uploadPath, fileName);
                    string filePath = Path.Combine(folderName, fileName);

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return new SuccessDataResult<string>(filePath.Replace("\\", "/"),"");
                }
                else
                {
                    return new ErrorDataResult<string>(Messages.FileNotUploaded);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }
        public IResult Delete(string filePath)
        {
            var deletePath = filePath;
            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
                return new SuccessResult(Messages.FileDeleted);
            }
            return new ErrorResult(Messages.FileNotDeleted);
        }
    }
}
