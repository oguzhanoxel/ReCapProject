using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileTools;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        string uploadPath = "images";
        ICarImageService _carImageService;
        IFileService _fileService;
        private static IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("details")]
        public IActionResult GetCarDetails()
        {
            var result = _carImageService.GetCarImageDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage)
        {
            var resultUpload = _fileService.UploadFile(_webHostEnvironment.WebRootPath, uploadPath, carImage.FormFile);

            if (!resultUpload.Success)
            {
                return BadRequest(resultUpload.Message);
            }
            carImage.ImagePath = resultUpload.Data;
            carImage.CarID = carImage.CarID;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var resultDelete = _fileService.DeleteFileFromFolder(_webHostEnvironment.WebRootPath, carImage.ImagePath);
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            _fileService.DeleteFileFromFolder(_webHostEnvironment.WebRootPath, carImage.ImagePath);
            var resultUpload = _fileService.UploadFile(_webHostEnvironment.WebRootPath, uploadPath, carImage.FormFile);

            carImage.ImagePath = resultUpload.Data;
            carImage.CarID = carImage.CarID;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
