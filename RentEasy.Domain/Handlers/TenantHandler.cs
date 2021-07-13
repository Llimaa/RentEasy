using Flunt.Notifications;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Repositories;
using RentEasy.Shared.Commands;
using RentEasy.Shared.Handlers;
using System.Threading.Tasks;

namespace RentEasy.Domain.Handlers
{
    public class TenantHandler : Notifiable,
        IHandler<CreateTenantCommand>,
        IHandler<UpdateTenantCommand>,
        IHandler<UpdateTenantExitCommand>,
        IHandler<UpdateStatusPaymentTenantCommand>,
        IHandler<UpdateTenantLastPaymentDateCommand>
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<ICommandResult> Handler(CreateTenantCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao adicionar Inquilino", null, command.Notifications);

            var tenant = new Tenant(command.Name, command.Phone, command.PayDay, command.HouseId);
            _tenantRepository.Create(tenant);
            return new GenericCommandResult(true, "Dados cadastrados com sucesso", tenant);
        }

        public async Task<ICommandResult> Handler(UpdateTenantCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar dados do Inquilino", null, command.Notifications);

            var tenant = await _tenantRepository.GetById(command.Id);
            tenant.Update(command.Name, command.Phone, command.PayDay);

            _tenantRepository.Update(tenant);

            return new GenericCommandResult(true, "Dados atualizados", tenant);
        }

        public async Task<ICommandResult> Handler(UpdateTenantExitCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar status do Inquilino", null, command.Notifications);

            var tenant = await _tenantRepository.GetById(command.Id);
            tenant.TenantExit();

            _tenantRepository.Desactive(tenant);

            return new GenericCommandResult(true, "Dados atualizados", tenant);
        }

        public async Task<ICommandResult> Handler(UpdateStatusPaymentTenantCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar status pagamento do Inquilino", null, command.Notifications);

            var tenant = await _tenantRepository.GetById(command.Id);
            tenant.UpdateStatusPayment(command.StatusPayment);

            _tenantRepository.Update(tenant);

            return new GenericCommandResult(true, "Dados atualizados", tenant);
        }

        public async Task<ICommandResult> Handler(UpdateTenantLastPaymentDateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar status pagamento do Inquilino", null, command.Notifications);

            var tenant = await _tenantRepository.GetById(command.Id);
            tenant.UpdateLastPaymentDate(command.LastPaymentDate);

            _tenantRepository.Update(tenant);

            return new GenericCommandResult(true, "Dados atualizados", tenant);
        }
    }
}
