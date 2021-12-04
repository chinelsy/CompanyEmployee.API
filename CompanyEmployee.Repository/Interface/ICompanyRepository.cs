using CompanyEmployee.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);


    }
}
