using System.Threading.Tasks;
using Wpf_Desktop_Robitusin.Models;

namespace Wpf_Desktop_Robitusin
{
    public interface IApiSettings
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}