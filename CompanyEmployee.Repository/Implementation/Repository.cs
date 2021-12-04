using CompanyEmployee.Entities.Models;
using CompanyEmployee.Entities.RequestFeatures;
using CompanyEmployee.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyEmployee.Repository.Implementation
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CompanyEmployeeContext CompanyEmployeeContext;
        public Repository(CompanyEmployeeContext companyEmployeeContext)
        {
            CompanyEmployeeContext = companyEmployeeContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
             !trackChanges ?
             CompanyEmployeeContext.Set<T>()
             .AsNoTracking() :
             CompanyEmployeeContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
             CompanyEmployeeContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            CompanyEmployeeContext.Set<T>() 
            .Where(expression);

        public void Create(T entity) => CompanyEmployeeContext.Set<T>().Add(entity);
        public void Update(T entity) => CompanyEmployeeContext.Set<T>().Update(entity);
        public void Delete(T entity) => CompanyEmployeeContext.Set<T>().Remove(entity);

    }
}

