using System;
using Microsoft.AspNetCore.Mvc;
using PhotoAPI.Model;
using PhotoAPI.Services;

namespace PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPhoto([FromBody] PhotoRequest request)
        {
            var result = _photoService.AddPhoto(request);
            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.Id);
            }
            return BadRequest(result.Error);
        }

        [HttpGet]
        public IActionResult GetAllPhotos()
        {
            var result = _photoService.GetAllPhotos();
            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.Photos);
            }
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoto(int id)
        {
            var result = _photoService.GetPhoto(id);
            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.photo);
            }
            return BadRequest(result.Error);
        }

        [HttpDelete]
        public IActionResult DeleteAllPhotos()
        {
            var result = _photoService.DeleteAllPhotos();
            if (String.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoto(int id)
        {
            var result = _photoService.DeletePhoto(id);
            if (String.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
       
        [HttpPost]
        [Route("[action]")]
        public IActionResult GetPhotoByDate([FromBody] GetPhotoByDateRequest request)
        {
            var result = _photoService.GetPhotoByDate(request.Date, request.UserId);
            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.Photos);
            }
            return BadRequest(result.Error);
        }
    }
}
