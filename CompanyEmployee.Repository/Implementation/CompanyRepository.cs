using CompanyEmployee.Entities.Models;
using CompanyEmployee.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeeContext companyEmployeeContext)
            : base(companyEmployeeContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);
        //public void Create(T entity) => CompanyEmployeeContext.Set<T>().Add(entity);

        public void DeleteCompany(Company company) => Delete(company);

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
         await FindAll(trackChanges)
         .OrderBy(c => c.Name)
         .ToListAsync();

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
         await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
         .SingleOrDefaultAsync();

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
         await FindByCondition(x => ids.Contains(x.Id), trackChanges)
         .ToListAsync();

    }
}
