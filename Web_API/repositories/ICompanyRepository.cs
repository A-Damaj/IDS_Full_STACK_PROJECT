using WebApplicationfin.Models;

namespace WebApplicationfin.repositories
{
    public interface ICompanyRepository
    {
        Company GetById(int id);
        IEnumerable<Company> GetAll();
        void Insert(Company company);
        void Update(Company company);
        void Delete(Company company);
    }

}
