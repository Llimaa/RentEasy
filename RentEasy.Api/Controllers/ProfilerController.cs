using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/v1/profiles")]
    public class ProfilerController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ProfileHandler _profileHandler;

        public ProfilerController(IProfileRepository profileRepository, ProfileHandler profileHandler)
        {
            _profileRepository = profileRepository;
            _profileHandler = profileHandler;
        }

        [Route("")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            var result = await _profileRepository.GetById(id);
            return Ok(result);
        }

        [Route("houses")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetHousersByIdProfile([FromHeader] Guid id)
        {
            var result = await _profileRepository.GetById(id);
            return Ok(result);
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Post([FromBody] CreateProfileCommand createProfile)
        {

            var result = await _profileHandler.Handler(createProfile);
            return Ok(result);
        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> PUT([FromBody] UpdateProfileCommand updateProfile)
        {
            var result = await _profileHandler.Handler(updateProfile);
            return Ok(result);
        }

    }
}
