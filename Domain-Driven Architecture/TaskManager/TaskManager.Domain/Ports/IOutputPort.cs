namespace TaskManager.Domain.Ports
{
    public interface IOutputPort<in TOutputModel>
    {
        void Success(TOutputModel output);

        void Error(string message = null);
    }
}
