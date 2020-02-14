using System.Threading.Tasks;

namespace TaskManager.Domain.Ports
{
    public interface IInputPort<in TInput, out TOutput>
    {
        Task Handle(TInput input, IOutputPort<TOutput> outputPort);
    }
}
