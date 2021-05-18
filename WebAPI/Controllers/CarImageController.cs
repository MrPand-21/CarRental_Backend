using Business.Abstract;
using Core.Utilities.Helper.FileHelper.Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHelper _file;

        public CarImageController(ICarImageService carImageService, IFileHelper file, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _carImageService = carImageService;
            _file = file;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file, CarImage carImage)
        {
            var imageResult = _file.Update(file, carImage.ImagePath, _webHostEnvironment.WebRootPath + "\\uploads\\");
            if (!imageResult.Success) return BadRequest(imageResult);
            carImage.ImagePath = imageResult.Message;
            var result = _carImageService.Update(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add( [FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var imageResult = _file.Upload(file, _webHostEnvironment.WebRootPath + "\\uploads\\");
            if (!imageResult.Success) return BadRequest(imageResult.Message);
            carImage.ImagePath = imageResult.Message;
            var result = _carImageService.Add(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
