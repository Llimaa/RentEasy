using Flunt.Notifications;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Repositories;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;
using RentEasy.Shared.Handlers;
using System.Threading.Tasks;

namespace RentEasy.Domain.Handlers
{
    public class HouseHandler : Notifiable,
        IHandler<CreateHouseCommand>,
         IHandler<UpdateHouseCommand>,
        IHandler<UpdateStatusHouseCommand>,
        IHandler<UpdateRentAmountHouseCommand>
    {
        private readonly IHouseRepository _houseRepository;

        public HouseHandler(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<ICommandResult> Handler(CreateHouseCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel cadastrar a Casa", null, command.Notifications);

            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);
            var house = new House(command.Descricao, command.RentAmount, address, command.ProfileId);

            _houseRepository.Create(house);

            return new GenericCommandResult(true, "Casa cadastrada com sucesso", house);
        }

        public async Task<ICommandResult> Handler(UpdateHouseCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel atualizar as informações da casa", null, command.Notifications);

            var house = await _houseRepository.GetById(command.Id);
            house.Update(command.Descricao);
            house.UpdateRentAmount(command.RentAmount);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);
            house.UpdateAddess(address);

            _houseRepository.Update(house);
            return new GenericCommandResult(true, "Dados Atualizados", house);
        }

        public async Task<ICommandResult> Handler(UpdateStatusHouseCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel atualizar o status da casa", null, command.Notifications);

            var house = await _houseRepository.GetById(command.Id);
            house.UpdateStatus(command.Status);

            _houseRepository.Update(house);
            return new GenericCommandResult(true, "Dados Atualizados", house);
        }

        public async Task<ICommandResult> Handler(UpdateRentAmountHouseCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel atualizar o valor do aluguel", null, command.Notifications);

            var house = await _houseRepository.GetById(command.Id);
            house.UpdateRentAmount(command.RentAmount);

            _houseRepository.Update(house);
            return new GenericCommandResult(true, "Dados Atualizados", house);
        }
    }
}
