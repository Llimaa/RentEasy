using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using RentEasy.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/v1/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly TenantHandler _tenantHandler;

        public TenantController(ITenantRepository tenantRepository, TenantHandler tenantHandler)
        {
            _tenantRepository = tenantRepository;
            _tenantHandler = tenantHandler;
        }

        [Route("")]
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            var result = await _tenantRepository.GetById(id);
            return Ok(result);
        }


        [Route("")]
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Post(CreateTenantCommand createTenant)
        {
            var exiteTenantByHouseId = await _tenantRepository.ExisteTenantByHouseId(createTenant.HouseId);
            if (!exiteTenantByHouseId)
            {
                var result = await _tenantHandler.Handler(createTenant);
                return Ok(result);
            }
            return Ok(new GenericCommandResult(false, "Tenant", null, new Notification("Tenant", "Inquilo ja possue uma casa!")));

        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Update(UpdateTenantCommand updateTenant)
        {
            var result = await _tenantHandler.Handler(updateTenant);
            return Ok(result);
        }

        [Route("desactive")]
        [HttpPatch]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Desactive(UpdateTenantExitCommand updateTenant)
        {
            var result = await _tenantHandler.Handler(updateTenant);
            return Ok(result);
        }

        [Route("status-payment")]
        [HttpPatch]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> UpdateStatusPayment(UpdateStatusPaymentTenantCommand updateTenant)
        {
            var result = await _tenantHandler.Handler(updateTenant);
            return Ok(result);
        }

        [Route("last-payment")]
        [HttpPatch]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> UpdateTenantLastPayment(UpdateTenantLastPaymentDateCommand updateTenant)
        {
            var result = await _tenantHandler.Handler(updateTenant);
            return Ok(result);
        }
    }
}
