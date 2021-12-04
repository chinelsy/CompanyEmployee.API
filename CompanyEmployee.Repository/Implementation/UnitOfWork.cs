using CompanyEmployee.Entities.Models;
using CompanyEmployee.Repository.Interface;
using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyEmployeeContext _companyEmployeeContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(CompanyEmployeeContext companyEmployeeContext)
        {
            _companyEmployeeContext = companyEmployeeContext;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_companyEmployeeContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_companyEmployeeContext);
                return _employeeRepository;
            }
        }
        public Task SaveAsync() => _companyEmployeeContext.SaveChangesAsync();
    }
}
