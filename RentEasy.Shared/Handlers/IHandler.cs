using RentEasy.Shared.Commands;
using System.Threading.Tasks;

namespace RentEasy.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handler(T command);
    }
}
