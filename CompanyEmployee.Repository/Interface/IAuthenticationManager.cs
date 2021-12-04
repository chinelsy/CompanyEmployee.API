using CompanyEmployee.Entities.Models.DTOS;
using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Interface
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
