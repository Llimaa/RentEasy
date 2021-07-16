using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/v1/houses")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository _houseRepository;
        private readonly HouseHandler _houseHandler;

        public HouseController(IHouseRepository houseRepository, HouseHandler houseHandler)
        {
            _houseRepository = houseRepository;
            _houseHandler = houseHandler;
        }

        [Route("profiles")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetHousersByIdProfile([FromHeader] Guid id)
        {
            var result = await _houseRepository.GetHousersByIdProfile(id);
            return Ok(result);
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<House> GetById([FromHeader] Guid id)
        {
            var result = await _houseRepository.GetById(id);
            return result;
        }


        [Route("")]
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Post([FromBody] CreateHouseCommand houseCommand)
        {
            var result = await _houseHandler.Handler(houseCommand);
            return Ok(result);
        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Put([FromBody] UpdateHouseCommand houseCommand)
        {
            var result = await _houseHandler.Handler(houseCommand);
            return Ok(result);
        }
    }
}
