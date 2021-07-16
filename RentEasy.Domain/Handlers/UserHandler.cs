using Flunt.Notifications;
using RentEasy.Domain.Commands.Auth;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Repositories;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Commands;
using RentEasy.Shared.Handlers;
using System.Threading.Tasks;

namespace RentEasy.Domain.Handlers
{
    public class UserHandler : Notifiable,
        IHandler<CreateUserCommand>,
         IHandler<LoginUserCommand>,
         IHandler<UpdatePasswordCommand>
    {

        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handler(CreateUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel cadastrar um usuário", false, command.Notifications);

            var getUser = await _userRepository.GetUserByEmail(command.Email);
            if (getUser != null)
                return new GenericCommandResult(false, "Endereço de E-mail já cadastrado.", null, new Notification("E-mail", "Endereço de e-mail já esta em uso"));

            var email = new Email(command.Email);
            var password = new Password(command.Password);
            var user = new User(email, password, command.Role);

            _userRepository.Create(user);

            user.CreanPassword();

            return new GenericCommandResult(true, "Dados do usuário cadastrado com sucesso", user);
        }

        public async Task<ICommandResult> Handler(LoginUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possivel fazer login", false, command.Notifications);

            var user = await _userRepository.GetUserByEmail(command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Não foi possivel fazer login", false, command.Notifications);

            var validateUser = user.ValidateUser(command.Email, command.Password);

            if (!validateUser)
                return new GenericCommandResult(false, "Usuário ou senha inválidos");

            user.CreanPassword();
            return new GenericCommandResult(true, "Usuário Autenticado", user);
        }

        public async Task<ICommandResult> Handler(UpdatePasswordCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", null, command.Notifications);


            var user = await _userRepository.GetUserByEmail(command.Email);

            if (user.Password.Value != new Password(command.PastPassword).Value)
                return new GenericCommandResult(false, "Dados inválidos", null, new Notification("Senha", "A senha não confere com a cadastrada no sistema"));

            user.Password.update(command.NewPassword);
            _userRepository.AlterPassword(user);
            user.CreanPassword();
            return new GenericCommandResult(true, "Senha atualizada com sucesso", user);
        }
    }
}
