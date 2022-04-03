using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProfilePhotosController : ControllerBase
    {
        private IProfilePhotoService _profilePhotoService;

        public ProfilePhotosController(IProfilePhotoService profilePhotoService)
        {
            _profilePhotoService = profilePhotoService;
        }

        [HttpPut("update")]
        public IActionResult UploadImage(ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Update(profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult ImageDelete(ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Delete(profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
    }
