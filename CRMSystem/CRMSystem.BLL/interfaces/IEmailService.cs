namespace CRMSystem.BLL.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
}
