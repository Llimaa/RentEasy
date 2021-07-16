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
    public class ProfileHandler : Notifiable,
        IHandler<CreateProfileCommand>,
        IHandler<UpdateProfileCommand>
    {
        private IProfileRepository _profileRepository;

        public ProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<ICommandResult> Handler(CreateProfileCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel cadastrar seu perfil!", command.Notifications);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);
            var profile = new Profile(command.Name, command.Phone, address, command.UserId);

            _profileRepository.Create(profile);

            return new GenericCommandResult(true, "Perfil cadastrado com sucesso.", profile);
        }

        public async Task<ICommandResult> Handler(UpdateProfileCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel atualizar os dados do perfil!", command.Notifications);
            var profile = await _profileRepository.GetById(command.Id);

            profile.Update(command.Name, command.Phone);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);
            profile.UpdateAddress(address);
            _profileRepository.Update(profile);

            return new GenericCommandResult(true, "Dados atualizados com sucesso", profile);
        }
    }
}
