using Flunt.Notifications;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.Commands.Update;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Repositories;
using RentEasy.Shared.Commands;
using RentEasy.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Domain.Handlers
{
    public class PhotoHandler : Notifiable,
        IHandler<CreatePhotoCommand>,
           IHandler<UpdatePhotoCommand>,
        IHandler<DeletePhoyoCommand>
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<ICommandResult> Handler(CreatePhotoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao tentar fazer upload da foto", null, command.Notifications);

            var photo = new Photo(command.Data, command.Format, command.HouseId);
            _photoRepository.Create(photo);
            return new GenericCommandResult(true, "Upload concluido com sucesso", photo);
        }

        public async Task<ICommandResult> Handler(UpdatePhotoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao tentar fazer upload da foto", null, command.Notifications);

            var photo = await _photoRepository.GetById(command.Id);
            photo.Update(command.Data, command.Format);
            _photoRepository.Update(photo);
            return new GenericCommandResult(true, "Foto atualizada com sucesso", photo);
        }

        public async Task<ICommandResult> Handler(DeletePhoyoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao tentar remover foto", null, command.Notifications);

            _photoRepository.Delete(command.Id);
            return new GenericCommandResult(true, "Foto removida com sucesso", null);
        }
    }
}
