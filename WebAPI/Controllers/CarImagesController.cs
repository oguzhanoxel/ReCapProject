using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        private static IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Add([FromForm] CarImageModel carImageModel)
        {
            CarImage carImage = new CarImage();
            var resultUpload = UploadImage(carImageModel);

            if (!resultUpload.Success)
            {
                return BadRequest(resultUpload.Message);
            }

            carImage.ImagePath = resultUpload.Data.ImagePath;
            carImage.CarID = carImageModel.CarID;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            DeleteImageFromFolder(_carImageService.GetById(carImage.ID).Data.ImagePath);
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImageModel carImageModel, int Id)
        {
            CarImage carImage = new CarImage();
            carImage = _carImageService.GetById(Id).Data;

            DeleteImageFromFolder(carImage.ImagePath);

            var resultUpload = UploadImage(carImageModel);

            if (!resultUpload.Success)
            {
                return BadRequest(resultUpload.Message);
            }

            carImage.ImagePath = resultUpload.Data.ImagePath;
            carImage.CarID = carImageModel.CarID;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        private IDataResult<CarImage> UploadImage(CarImageModel carImageModel)
        {
            CarImage carImage = new CarImage();
            try
            {
                if (carImageModel.ImageFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\images\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filePath = path + carImageModel.FileName +"_"+ Guid.NewGuid().ToString() + ".jpg";
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        carImageModel.ImageFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    carImage.ImagePath = filePath;
                    return new SuccessDataResult<CarImage>(carImage);
                }
                else
                {
                    return new ErrorDataResult<CarImage>("Not Uploaded");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CarImage>(ex.Message);
            }
        }

        private void DeleteImageFromFolder(string path)
        {
            var deletePath = Path.Combine(path);
            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }
        }
    }
}
