using MyAspNetCoreApp.Models;
using WebApplicationfin.Models;

namespace WebApplicationfin.repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RoommeetContext _dbContext;

        public CompanyRepository(RoommeetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company GetById(int id)
        {
            return _dbContext.Companies.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        public void Insert(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
        }

        public void Update(Company company)
        {
            _dbContext.Companies.Update(company);
            _dbContext.SaveChanges();
        }

        public void Delete(Company company)
        {
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
        }
    }

}
