using Microsoft.AspNetCore.Mvc;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/v1/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly PhotoHandler _photoHandler;

        public PhotoController(IPhotoRepository photoRepository, PhotoHandler photoHandler)
        {
            _photoRepository = photoRepository;
            _photoHandler = photoHandler;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            var result = await _photoRepository.GetById(id);
            return Ok(result);
        }

        [Route("house")]
        [HttpGet]
        public async Task<IActionResult> GetAllPhotoByHouseId([FromHeader] Guid id)
        {
            var result = await _photoRepository.GetAllPhotoByHouseId(id);
            return Ok(result);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePhotoCommand createPhoto)
        {
            var result = await _photoHandler.Handler(createPhoto);
            return Ok(result);
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePhotoCommand updatePhoto)
        {
            var result = await _photoHandler.Handler(updatePhoto);
            return Ok(result);
        }

        [Route("")]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePhoyoCommand deletePhoyo)
        {
            var result = await _photoHandler.Handler(deletePhoyo);
            return Ok(result);
        }

    }
}
