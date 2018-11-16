using SleepMakeSense.Controllers;
using System.Threading.Tasks;

namespace SleepMakeSense.Controllers
{
    public interface ITokenManager
    {
        Task<OAuth2AccessToken> RefreshTokenAsync(FitbitClient client);
    }
}