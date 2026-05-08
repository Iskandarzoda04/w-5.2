using Domain;
namespace Infrastructure.Interfaces;

public interface ICompanyService
{Task AddCompany(Company company);
Task UpdateCompany(Company company);
Task DeleteCompany(int id);
Task<Company?> GetCompanyById(int id);
   

}

