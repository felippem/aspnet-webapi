
namespace WebAPI.Core.Interfaces.Services
{
    public interface ISmsService
    {
        string From { get; set; }
        string To { get; set; }

        bool Active();
        void Send(string message);
    }
}
