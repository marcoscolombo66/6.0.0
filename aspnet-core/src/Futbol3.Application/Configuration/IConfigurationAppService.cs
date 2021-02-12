using System.Threading.Tasks;
using Futbol3.Configuration.Dto;

namespace Futbol3.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
