using CursoDotNet.Application.BusinessModels.Models;

namespace CursoDotNet.CrossCutting.Contracts.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
    }
}
