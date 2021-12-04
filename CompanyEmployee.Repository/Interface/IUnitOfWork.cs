using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Interface
{
    public interface IUnitOfWork
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        Task SaveAsync();

    }
}
